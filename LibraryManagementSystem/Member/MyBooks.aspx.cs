using System;
using System.Data;

namespace LibraryManagementSystem.Member
{
    public partial class MyBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // بررسی نقش کاربر
                if (Session["Role"] == null || Session["Role"].ToString() != "Member")
                {
                    Response.Redirect("~/Login.aspx"); // هدایت به صفحه ورود اگر کاربر عضو نباشد
                }

                LoadMyBooks();
            }
        }

        private void LoadMyBooks()
        {
            try
            {
                int memberID = Convert.ToInt32(Session["UserID"]);

                string query = "SELECT b.Title AS BookTitle, i.IssueDate, i.ReturnDate, i.LateFee as FineAmount " +
                               "FROM Issue_Books i " +
                               "INNER JOIN Books b ON i.BookID = b.BookID " +
                               "WHERE i.MemberID = " + memberID;
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    gvMyBooks.DataSource = dt;
                    gvMyBooks.DataBind();
                }
                else
                {
                    lblMessage.Text = "شما هنوز کتابی امانت نگرفته‌اید.";
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