using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class ManageMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // بررسی نقش کاربر
                if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                {
                    Response.Redirect("~/Login.aspx", false); // هدایت به صفحه ورود اگر کاربر مدیر نباشد
                }

                LoadMembers();
            }
        }

        private void LoadMembers()
        {
            string query = "SELECT * FROM Members";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvMembers.DataSource = dt;
            gvMembers.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();

                bool isValid = Validation();
                if (isValid == false)
                {
                    return;
                }

                string query = $"INSERT INTO Members (FullName, Email, Phone, Address) VALUES (N'{fullName}', N'{email}', '{phone}', N'{address}')";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "عضو با موفقیت اضافه شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearFields();
                    LoadMembers();
                }
                else
                {
                    lblMessage.Text = "خطا در اضافه کردن عضو.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int memberID = Convert.ToInt32(ViewState["MemberID"]);
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();

                bool isValid = Validation();
                if (isValid == false)
                {
                    return;
                }

                string query = $"UPDATE Members SET FullName=N'{fullName}', Email=N'{email}', Phone='{phone}', Address=N'{address}' WHERE MemberID={memberID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "عضو با موفقیت به‌روزرسانی شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    ClearFields();
                    LoadMembers();
                }
                else
                {
                    lblMessage.Text = "خطا در به‌روزرسانی عضو.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "خطا: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        protected void gvMembers_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMember")
            {
                int memberID = Convert.ToInt32(e.CommandArgument);

                string query = $"SELECT * FROM Members WHERE MemberID={memberID}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    ViewState["MemberID"] = memberID;

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteMember")
            {
                int memberID = Convert.ToInt32(e.CommandArgument);

                string query = $"DELETE FROM Members WHERE MemberID={memberID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "عضو با موفقیت حذف شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    LoadMembers();
                }
                else
                {
                    lblMessage.Text = "خطا در حذف عضو.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private bool Validation()
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            lblMessage.Text = "";

            if (string.IsNullOrEmpty(fullName))
            {
                lblMessage.Text = "نام کامل اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(email))
            {
                lblMessage.Text += "ایمیل اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(phone))
            {
                lblMessage.Text += "تلفن اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(address))
            {
                lblMessage.Text += "آدرس اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }

            return true;
        }
    }


}