using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class ManageCategories : System.Web.UI.Page
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
            }
        }

        private void LoadCategories()
        {
            string query = "SELECT * FROM Category";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvCategories.DataSource = dt;
            gvCategories.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string categoryName = txtCategoryName.Text.Trim();

                string query = $"INSERT INTO Category (CategoryName) VALUES ('{categoryName}')";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "دسته بندی با موفقیت اضافه شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearFields();
                    LoadCategories();
                }
                else
                {
                    lblMessage.Text = "خطا در اضافه کردن دسته بندی.";
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
                int categoryID = Convert.ToInt32(ViewState["CategoryID"]);
                string categoryName = txtCategoryName.Text.Trim();

                string query = $"UPDATE Category SET CategoryName='{categoryName}' WHERE CategoryID={categoryID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "دسته بندی با موفقیت بروزرسانی شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    ClearFields();
                    LoadCategories();
                }
                else
                {
                    lblMessage.Text = "خطا در به‌روزرسانی دسته‌بندی.";
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

        protected void gvCategories_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCategory")
            {
                int categoryID = Convert.ToInt32(e.CommandArgument);

                string query = $"SELECT * FROM Category WHERE CategoryID={categoryID}";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    txtCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
                    ViewState["CategoryID"] = categoryID;

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteCategory")
            {
                int categoryID = Convert.ToInt32(e.CommandArgument);

                string query = $"DELETE FROM Category WHERE CategoryID={categoryID}";
                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "دسته بندی با موفقیت حذف شد !";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    LoadCategories();
                }
                else
                {
                    lblMessage.Text = "خطا در حذف دسته بندی.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void ClearFields()
        {
            txtCategoryName.Text = string.Empty;
        }
    }
}