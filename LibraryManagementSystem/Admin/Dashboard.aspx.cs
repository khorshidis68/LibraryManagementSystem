using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class Dashboard : System.Web.UI.Page
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

                // بارگذاری آمارها
                LoadStatistics();
            }
        }

        private void LoadStatistics()
        {
            try
            {
                // تعداد کتاب‌ها
                string queryBooks = "SELECT COUNT(*) FROM Books";
                int totalBooks = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryBooks));
                lblTotalBooks.Text = $"مجموع کتاب‌ها: {totalBooks}";

                // تعداد اعضا
                string queryMembers = "SELECT COUNT(*) FROM Members";
                int totalMembers = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryMembers));
                lblTotalMembers.Text = $"کل اعضا: {totalMembers}";

                // تعداد کارمندان
                string queryEmployees = "SELECT COUNT(*) FROM Employee";
                int totalEmployees = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryEmployees));
                lblTotalEmployees.Text = $"کل کارمندان: {totalEmployees}";

                // تعداد امانات
                string queryIssues = "SELECT COUNT(*) FROM Issue_Books";
                int totalIssues = Convert.ToInt32(DatabaseHelper.ExecuteScalar(queryIssues));
                lblTotalIssues.Text = $"کل امانات: {totalIssues}";
            }
            catch (Exception ex)
            {
                lblTotalBooks.Text = "خطا در بارگیری آمار.";
                lblTotalMembers.Text = ex.Message;
            }
        }
    }
}