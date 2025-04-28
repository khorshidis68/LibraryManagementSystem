<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageEmployees" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>مدیریت کارمندان - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>مدیریت کارمندان</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtFirstName">نام:</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="نام اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="txtLastName">نام خانوادگی:</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="نام خانوادگی اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="txtNationalCode">کد ملی:</label>
                    <asp:TextBox ID="txtNationalCode" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvNationalCode" runat="server" ControlToValidate="txtNationalCode" ErrorMessage="کد ملی اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revNationalCode" runat="server" ControlToValidate="txtNationalCode" ValidationExpression="^\d{10}$" ErrorMessage="کد ملی باید 10 رقمی باشد." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtPhoneNumber">شماره تلفن:</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="شماره تلفن اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" ValidationExpression="^\d{11}$" ErrorMessage="شماره تلفن باید 11 رقمی باشد." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtAddress">آدرس:</label>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <label for="txtHireDate">تاریخ استخدام:</label>
                    <asp:TextBox ID="txtHireDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvHireDate" runat="server" ControlToValidate="txtHireDate" ErrorMessage="تاریخ استخدام اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="chkIsActive">وضعیت فعال:</label>
                    <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" />
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="افزودن کارمند" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="ویرایش کارمند" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvEmployees_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="EmployeeID" HeaderText="شناسه" />
                            <asp:BoundField DataField="FirstName" HeaderText="نام" />
                            <asp:BoundField DataField="LastName" HeaderText="نام خانوادگی" />
                            <asp:BoundField DataField="NationalCode" HeaderText="کد ملی" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="شماره تلفن" />
                            <asp:BoundField DataField="Address" HeaderText="آدرس" />
                            <asp:BoundField DataField="HireDate" HeaderText="تاریخ استخدام" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="IsActive" HeaderText="وضعیت فعال" />
                            <asp:TemplateField HeaderText="عملیات">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditEmployee" CommandArgument='<%# Eval("EmployeeID") %>' Text="ویرایش"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteEmployee" CommandArgument='<%# Eval("EmployeeID") %>' Text="حذف" OnClientClick="return confirm('آیا مطمئن هستید که می‌خواهید این کارمند را حذف کنید؟');"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>