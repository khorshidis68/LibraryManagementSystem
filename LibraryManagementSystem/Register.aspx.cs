using System;
using System.Data;

namespace LibraryManagementSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // هیچ منطق خاصی برای بارگذاری صفحه نیاز نیست
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // گرفتن مقادیر ورودی
                string username = txtUsername.Text.Trim();
                string password = SecurityHelper.HashPassword(txtPassword.Text.Trim());
                string email = txtEmail.Text.Trim();

                // بررسی تکراری بودن نام کاربری
                string checkQuery = $"SELECT COUNT(*) FROM Users WHERE Username='{username}'";
                int userCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));

                if (userCount > 0)
                {
                    lblMessage.Text = "این نام کاربری قبلاً استفاده شده است!";
                    lblMessage.Visible = true;
                    return;
                }

                // اضافه کردن کاربر به دیتابیس
                string insertQuery = $"INSERT INTO Users (Username, Password, Email, Role) VALUES ('{username}', '{password}', '{email}', 'Member')";
                int result = DatabaseHelper.ExecuteNonQuery(insertQuery);

                if (result > 0)
                {
                    lblMessage.Text = "ثبت نام با موفقیت انجام شد! اکنون می‌توانید وارد شوید.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    // پاک کردن فیلدها پس از ثبت‌نام موفق
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                }
                else
                {
                    lblMessage.Text = "An error occurred during registration.";
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