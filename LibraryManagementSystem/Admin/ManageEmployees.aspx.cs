using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // بررسی نقش کاربر
                if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                {
                    Response.Redirect("~/Login.aspx"); // هدایت به صفحه ورود اگر کاربر مدیر نباشد
                }

                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            string query = "SELECT * FROM Employee";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvEmployees.DataSource = dt;
            gvEmployees.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text.Trim();
                string position = txtPosition.Text.Trim();
                DateTime hireDate = Convert.ToDateTime(txtHireDate.Text);

                string query = $"INSERT INTO Employee (FullName, Position, HireDate) VALUES ('{fullName}', '{position}', '{hireDate:yyyy-MM-dd}')";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کارمند با موفقیت اضافه شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearFields();
                    LoadEmployees();
                }
                else
                {
                    lblMessage.Text = "خطا در اضافه کردن کارمند.";
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
                int employeeID = Convert.ToInt32(ViewState["EmployeeID"]);
                string fullName = txtFullName.Text.Trim();
                string position = txtPosition.Text.Trim();
                DateTime hireDate = Convert.ToDateTime(txtHireDate.Text);

                string query = $"UPDATE Employee SET FullName='{fullName}', Position='{position}', HireDate='{hireDate:yyyy-MM-dd}' WHERE EmployeeID={employeeID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کارمند با موفقیت به‌روزرسانی شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    ClearFields();
                    LoadEmployees();
                }
                else
                {
                    lblMessage.Text = "خطا در به‌روزرسانی کارمند.";
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

        protected void gvEmployees_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                int employeeID = Convert.ToInt32(e.CommandArgument);

                string query = $"SELECT * FROM Employee WHERE EmployeeID={employeeID}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtPosition.Text = dt.Rows[0]["Position"].ToString();
                    txtHireDate.Text = Convert.ToDateTime(dt.Rows[0]["HireDate"]).ToString("yyyy-MM-dd");
                    ViewState["EmployeeID"] = employeeID;

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteEmployee")
            {
                int employeeID = Convert.ToInt32(e.CommandArgument);

                string query = $"DELETE FROM Employee WHERE EmployeeID={employeeID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کارمند با موفقیت حذف شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    LoadEmployees();
                }
                else
                {
                    lblMessage.Text = "خطا در حذف کارمند.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void ClearFields()
        {
            txtFullName.Text = string.Empty;
            txtPosition.Text = string.Empty;
            txtHireDate.Text = string.Empty;
        }
    }
}