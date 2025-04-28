using System;
using System.Data;

namespace LibraryManagementSystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // هیچ عملیات خاصی در بارگذاری اولیه نیاز نیست
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // گرفتن مقدار جستجو
                string searchTerm = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    lblMessage.Text = "لطفا عبارت جستجو را وارد کنید.";
                    lblMessage.Visible = true;
                    return;
                }

                // اجرای کوئری جستجو
                string query = $"SELECT b.BookID, b.Title, b.Author, c.CategoryName, b.Quantity " +
                               $"FROM Books b " +
                               $"INNER JOIN Category c ON b.CategoryID = c.CategoryID " +
                               $"WHERE b.Title LIKE '%{searchTerm}%' OR b.Author LIKE '%{searchTerm}%'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                    lblMessage.Visible = false;
                }
                else
                {
                    lblMessage.Text = "هیچ کتابی مطابق با جستجوی شما یافت نشد.";
                    lblMessage.Visible = true;
                    gvBooks.DataSource = null;
                    gvBooks.DataBind();
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