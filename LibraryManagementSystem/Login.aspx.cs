using System;
using System.Data;

namespace LibraryManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // هیچ منطق خاصی برای بارگذاری صفحه نیاز نیست
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // گرفتن مقادیر ورودی
                string username = txtUsername.Text.Trim();
                string password = SecurityHelper.HashPassword(txtPassword.Text.Trim());

                // جستجوی کاربر در دیتابیس
                string query = $"SELECT * FROM Users WHERE Username='{username}' AND Password='{password}'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    // اطلاعات کاربر را در Session ذخیره کنید
                    Session["UserID"] = dt.Rows[0]["UserID"];
                    Session["Role"] = dt.Rows[0]["Role"];

                    // هدایت کاربر به صفحه مناسب بر اساس نقش
                    if (Session["Role"].ToString() == "Admin")
                    {
                        Response.Redirect("~/Admin/Dashboard.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Member/MyBooks.aspx", false);
                    }
                }
                else
                {
                    lblMessage.Text = "نام کاربری یا رمز عبور نامعتبر است!";
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