using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class ManageBooks : System.Web.UI.Page
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

                LoadCategories();
                LoadBooks();
            }
        }

        private void LoadCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM Category";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();

            // افزودن آیتم پیش‌فرض
            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- انتخاب دسته بندی --", "0"));
        }

        private void LoadBooks()
        {
            string query = "SELECT b.BookID, b.Title, b.Author, c.CategoryName, b.Quantity " +
                           "FROM Books b INNER JOIN Category c ON b.CategoryID = c.CategoryID";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvBooks.DataSource = dt;
            gvBooks.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text.Trim();
                string author = txtAuthor.Text.Trim();
                int categoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim());

                string query = $"INSERT INTO Books (Title, Author, CategoryID, Quantity) VALUES ('{title}', '{author}', {categoryID}, {quantity})";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کتاب با موفقیت اضافه شد!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearFields();
                    LoadBooks();
                }
                else
                {
                    lblMessage.Text = "خطا در اضافه کردن کتاب.";
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
                int bookID = Convert.ToInt32(ViewState["BookID"]);
                string title = txtTitle.Text.Trim();
                string author = txtAuthor.Text.Trim();
                int categoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                int quantity = Convert.ToInt32(txtQuantity.Text.Trim());

                string query = $"UPDATE Books SET Title='{title}', Author='{author}', CategoryID={categoryID}, Quantity={quantity} WHERE BookID={bookID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کتاب با موفقیت به‌روزرسانی شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    ClearFields();
                    LoadBooks();
                }
                else
                {
                    lblMessage.Text = "خطا در به‌روزرسانی کتاب.";
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

        protected void gvBooks_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBook")
            {
                int bookID = Convert.ToInt32(e.CommandArgument);

                string query = $"SELECT * FROM Books WHERE BookID={bookID}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    txtTitle.Text = dt.Rows[0]["Title"].ToString();
                    txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                    ddlCategory.SelectedValue = dt.Rows[0]["CategoryID"].ToString();
                    txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();

                    ViewState["BookID"] = bookID;

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteBook")
            {
                int bookID = Convert.ToInt32(e.CommandArgument);

                string query = $"DELETE FROM Books WHERE BookID={bookID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کتاب با موفقیت حذف شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    LoadBooks();
                }
                else
                {
                    lblMessage.Text = "خطا در حذف کتاب.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            txtQuantity.Text = string.Empty;
        }
    }
}