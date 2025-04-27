using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class ManageIssues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // بررسی نقش کاربر
                if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
                {
                    Response.Redirect("../Login.aspx"); // هدایت به صفحه ورود اگر کاربر مدیر نباشد
                }

                LoadBooks();
                LoadMembers();
                LoadIssues();
            }
        }

        private void LoadBooks()
        {
            string query = "SELECT BookID, Title FROM Books";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            ddlBooks.DataSource = dt;
            ddlBooks.DataTextField = "Title";
            ddlBooks.DataValueField = "BookID";
            ddlBooks.DataBind();

            // افزودن آیتم پیش‌فرض
            ddlBooks.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Book --", "0"));
        }

        private void LoadMembers()
        {
            string query = "SELECT MemberID, FirstName + ' ' + LastName as FullName FROM Members";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            ddlMembers.DataSource = dt;
            ddlMembers.DataTextField = "FullName";
            ddlMembers.DataValueField = "MemberID";
            ddlMembers.DataBind();

            // افزودن آیتم پیش‌فرض
            ddlMembers.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- عضو را انتخاب کنید --", "0"));
        }

        private void LoadIssues()
        {
            string query = "SELECT i.IssueID, b.Title AS BookTitle, m.FirstName + ' ' + m.LastName as MemberName, i.IssueDate, i.ReturnDate, i.LateFee as FineAmount FROM Issue_Books i INNER JOIN Books b ON i.BookID = b.BookID INNER JOIN Members m ON i.MemberID = m.MemberID";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvIssues.DataSource = dt;
            gvIssues.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = Convert.ToInt32(ddlBooks.SelectedValue);
                int memberID = Convert.ToInt32(ddlMembers.SelectedValue);
                DateTime issueDate = Convert.ToDateTime(txtIssueDate.Text);
                DateTime returnDate = Convert.ToDateTime(txtReturnDate.Text);

                string query = $"INSERT INTO Issue_Books (BookID, MemberID, IssueDate, ReturnDate) VALUES ({bookID}, {memberID}, '{issueDate:yyyy-MM-dd}', '{returnDate:yyyy-MM-dd}')";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "امانت با موفقیت اضافه شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearFields();
                    LoadIssues();
                }
                else
                {
                    lblMessage.Text = "خطا در اضافه کردن امانات.";
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        protected void gvIssues_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ClearIssue")
            {
                int issueID = Convert.ToInt32(e.CommandArgument);

                string query = $"UPDATE Issue_Books SET ReturnDate=GETDATE(), LateFee=0 WHERE IssueID={issueID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "امانت با موفقیت تسویه شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    LoadIssues();
                }
                else
                {
                    lblMessage.Text = "خطا در تسویه امانات.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void ClearFields()
        {
            ddlBooks.SelectedIndex = 0;
            ddlMembers.SelectedIndex = 0;
            txtIssueDate.Text = string.Empty;
            txtReturnDate.Text = string.Empty;
        }
    }
}