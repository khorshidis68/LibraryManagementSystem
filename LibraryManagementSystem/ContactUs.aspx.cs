using System;

namespace LibraryManagementSystem
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // هیچ منطق خاصی برای بارگذاری صفحه نیاز نیست
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // گرفتن مقادیر ورودی
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string message = txtMessage.Text.Trim();

                // ایجاد کوئری برای ذخیره پیام در دیتابیس
                string query = $"INSERT INTO ContactMessages (Name, Email, Message, SubmitDate) " +
                               $"VALUES ('{name}', '{email}', '{message}', GETDATE())";

                // اجرای کوئری
                int result = DatabaseHelper.ExecuteNonQuery(query);
                
                if (result > 0)
                {
                    lblMessage.Text = "Your message has been submitted successfully!";
                    lblMessage.Visible = true;

                    // پاک کردن فیلدها پس از ارسال موفق
                    txtName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtMessage.Text = string.Empty;
                }
                else
                {
                    lblMessage.Text = "An error occurred while submitting your message.";
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