using System;
using System.Data;

namespace LibraryManagementSystem.Member
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // بررسی نقش کاربر
                if (Session["Role"] == null || Session["Role"].ToString() != "Member")
                {
                    Response.Redirect("~/Login.aspx", false); // هدایت به صفحه ورود اگر کاربر عضو نباشد
                }

                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            try
            {
                int memberID = Convert.ToInt32(Session["UserID"]);

                string query = $"SELECT FullName, Email, Phone, Address FROM Members WHERE MemberID={memberID}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                }
                else
                {
                    lblMessage.Text = "خطا در بارگذاری پروفایل.";
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
                int memberID = Convert.ToInt32(Session["UserID"]);
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();

                string query = $"UPDATE Members SET Email='{email}', Phone='{phone}', Address='{address}' WHERE MemberID={memberID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "پروفایل با موفقیت به‌روزرسانی شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "خطا در به‌روزرسانی پروفایل.";
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
    }
}