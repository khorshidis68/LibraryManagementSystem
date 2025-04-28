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
                LoadBooks();
                LoadMembers();
                LoadEmployees();
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
        }

        private void LoadMembers()
        {
            string query = "SELECT MemberID, FullName FROM Members";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            ddlMembers.DataSource = dt;
            ddlMembers.DataTextField = "FullName";
            ddlMembers.DataValueField = "MemberID";
            ddlMembers.DataBind();
        }

        private void LoadEmployees()
        {
            string query = "SELECT EmployeeID, FirstName + ' ' + LastName as FullName FROM Employee";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            ddlEmployees.DataSource = dt;
            ddlEmployees.DataTextField = "FullName";
            ddlEmployees.DataValueField = "EmployeeID";
            ddlEmployees.DataBind();
        }

        private void LoadIssues()
        {
            string query = @"
                SELECT 
                    i.IssueID, 
                    b.Title AS BookTitle, 
                    m.fullName AS MemberName, 
                    i.IssueDate, 
                    i.DueDate, 
                    i.ReturnDate, 
                    e.FirstName + ' ' + e.LastName AS EmployeeName, 
                    i.LateFee, 
                    i.Status
                FROM Issue_Books i
                INNER JOIN Books b ON i.BookID = b.BookID
                INNER JOIN Members m ON i.MemberID = m.MemberID
                INNER JOIN Employee e ON i.EmployeeID = e.EmployeeID";

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
                string dueDate = (DateTime.Parse(txtDueDate.Text)).ToString("yyyy-MM-dd");
                int employeeID = Convert.ToInt32(ddlEmployees.SelectedValue);
                decimal lateFee = Convert.ToDecimal(txtLateFee.Text);
                string status = ddlStatus.SelectedValue;

                string query = $" INSERT INTO Issue_Books ( BookID, MemberID, DueDate, EmployeeID, LateFee, Status ) VALUES ( '{bookID}', '{memberID}', '{dueDate}', '{employeeID}', '{lateFee}', N'{status}' )";

                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "امانت با موفقیت اضافه شد.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearForm();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IssueID"] == null)
                {
                    lblMessage.Text = "شناسه امانت معتبر نیست.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    return;
                }

                int issueID = Convert.ToInt32(ViewState["IssueID"]);
                int bookID = Convert.ToInt32(ddlBooks.SelectedValue);
                int memberID = Convert.ToInt32(ddlMembers.SelectedValue);
                string dueDate = (DateTime.Parse(txtDueDate.Text)).ToString("yyyy-MM-dd");
                int employeeID = Convert.ToInt32(ddlEmployees.SelectedValue);
                decimal lateFee = Convert.ToDecimal(txtLateFee.Text);
                string status = ddlStatus.SelectedValue;

                string query = $" UPDATE Issue_Books SET  BookID = '{bookID}', MemberID = '{memberID}', DueDate = '{dueDate}', EmployeeID = '{employeeID}', LateFee = '{lateFee}', Status = N'{status}' WHERE IssueID = '{issueID}'";

                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "امانت با موفقیت ویرایش شد.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearForm();
                    LoadIssues();

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    lblMessage.Text = "خطا در ویرایش امانت.";
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

        protected void gvIssues_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditIssue")
            {
                int issueID = Convert.ToInt32(e.CommandArgument);
                ViewState["IssueID"] = issueID;

                string query = $"SELECT * FROM Issue_Books WHERE IssueID = '{issueID}'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ddlBooks.SelectedValue = row["BookID"].ToString();
                    ddlMembers.SelectedValue = row["MemberID"].ToString();
                    txtDueDate.Text = Convert.ToDateTime(row["DueDate"]).ToString("yyyy-MM-dd");
                    ddlEmployees.SelectedValue = row["EmployeeID"].ToString();
                    txtLateFee.Text = row["LateFee"].ToString();
                    ddlStatus.SelectedValue = row["Status"].ToString();

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteIssue")
            {
                try
                {
                    int issueID = Convert.ToInt32(e.CommandArgument);

                    string query = $"DELETE FROM Issue_Books WHERE IssueID = '{issueID}'";
                    int result = DatabaseHelper.ExecuteNonQuery(query);

                    if (result > 0)
                    {
                        lblMessage.Text = "امانت با موفقیت حذف شد.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Visible = true;

                        LoadIssues();
                    }
                    else
                    {
                        lblMessage.Text = "خطا در حذف امانت.";
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

        private void ClearForm()
        {
            ddlBooks.SelectedIndex = 0;
            ddlMembers.SelectedIndex = 0;
            txtDueDate.Text = string.Empty;
            ddlEmployees.SelectedIndex = 0;
            txtLateFee.Text = "0";
            ddlStatus.SelectedIndex = 0;

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            ViewState["IssueID"] = null;
        }
    }
}