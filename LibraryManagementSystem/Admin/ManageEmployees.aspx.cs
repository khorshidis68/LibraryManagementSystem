using System;
using System.Data;

namespace LibraryManagementSystem.Admin
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            string query = @"
                SELECT 
                    EmployeeID, 
                    FirstName, 
                    LastName, 
                    NationalCode, 
                    PhoneNumber, 
                    Address, 
                    HireDate, 
                    IsActive 
                FROM Employee";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            gvEmployees.DataSource = dt;
            gvEmployees.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string nationalCode = txtNationalCode.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string address = txtAddress.Text.Trim();

                bool isValid = Validation();
                if (isValid == false)
                {
                    return;
                }

                string hireDate = (DateTime.Parse(txtHireDate.Text)).ToString("yyyy-MM-dd");
                bool isActive = chkIsActive.Checked;

                string query = $" INSERT INTO Employee ( FirstName, LastName, NationalCode, PhoneNumber, Address, HireDate, IsActive ) VALUES ( N'{firstName}', N'{lastName}', N'{nationalCode}', N'{phoneNumber}', N'{address}', '{hireDate}', '{isActive}' )";

                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کارمند با موفقیت اضافه شد.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearForm();
                    LoadEmployees();
                }
                else
                {
                    lblMessage.Text = "خطا در افزودن کارمند.";
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
                if (ViewState["EmployeeID"] == null)
                {
                    lblMessage.Text = "شناسه کارمند معتبر نیست.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    return;
                }

                int employeeID = Convert.ToInt32(ViewState["EmployeeID"]);
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string nationalCode = txtNationalCode.Text.Trim();
                string phoneNumber = txtPhoneNumber.Text.Trim();
                string address = txtAddress.Text.Trim();

                bool isValid = Validation();
                if (isValid == false)
                {
                    return;
                }

                string hireDate = (DateTime.Parse(txtHireDate.Text)).ToString("yyyy/MM/dd");

                bool isActive = chkIsActive.Checked;

                string query = $" UPDATE Employee SET  FirstName = N'{firstName}', LastName = N'{lastName}', NationalCode = N'{nationalCode}', PhoneNumber = N'{phoneNumber}', Address = N'{address}', HireDate = '{hireDate}', IsActive = '{isActive}' WHERE EmployeeID = '{employeeID}'";

                int result = DatabaseHelper.ExecuteNonQuery(query);

                if (result > 0)
                {
                    lblMessage.Text = "کارمند با موفقیت ویرایش شد.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;

                    ClearForm();
                    LoadEmployees();

                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    lblMessage.Text = "خطا در ویرایش کارمند.";
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

        protected void gvEmployees_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                int employeeID = Convert.ToInt32(e.CommandArgument);
                ViewState["EmployeeID"] = employeeID;

                string query = $"SELECT * FROM Employee WHERE EmployeeID = '{employeeID}'";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtFirstName.Text = row["FirstName"].ToString();
                    txtLastName.Text = row["LastName"].ToString();
                    txtNationalCode.Text = row["NationalCode"].ToString();
                    txtPhoneNumber.Text = row["PhoneNumber"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                    txtHireDate.Text = Convert.ToDateTime(row["HireDate"]).ToString("yyyy-MM-dd");
                    chkIsActive.Checked = Convert.ToBoolean(row["IsActive"]);

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteEmployee")
            {
                try
                {
                    int employeeID = Convert.ToInt32(e.CommandArgument);

                    string query = $"DELETE FROM Employee WHERE EmployeeID = '{employeeID}'";
                    int result = DatabaseHelper.ExecuteNonQuery(query);

                    if (result > 0)
                    {
                        lblMessage.Text = "کارمند با موفقیت حذف شد.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Visible = true;

                        LoadEmployees();
                    }
                    else
                    {
                        lblMessage.Text = "خطا در حذف کارمند.";
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
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalCode.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtHireDate.Text = string.Empty;
            chkIsActive.Checked = true;

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            ViewState["EmployeeID"] = null;
        }

        private bool Validation()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string nationalCode = txtNationalCode.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string address = txtAddress.Text.Trim();
            lblMessage.Text = "";

            if (string.IsNullOrEmpty(firstName))
            {
                lblMessage.Text = "نام اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(lastName))
            {
                lblMessage.Text += "نام خانوادگی اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(nationalCode))
            {
                lblMessage.Text += "کد ملی اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                lblMessage.Text += "شماره تلفن اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }
            if (string.IsNullOrEmpty(address))
            {
                lblMessage.Text += "آدرس اجباری است";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return false;
            }

            return true;
        }

    }
}