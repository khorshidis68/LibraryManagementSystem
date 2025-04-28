<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageCategories" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>مدیریت دسته‌بندی‌ها - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>مدیریت دسته‌بندی‌ها</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtCategoryName">نام دسته‌بندی:</label>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="نام دسته‌بندی اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="افزودن دسته‌بندی" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="ویرایش دسته‌بندی" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvCategories_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="CategoryID" HeaderText="شناسه" />
                            <asp:BoundField DataField="CategoryName" HeaderText="نام دسته‌بندی" />
                            <asp:TemplateField HeaderText="عملیات">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditCategory" CommandArgument='<%# Eval("CategoryID") %>' Text="ویرایش"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteCategory" CommandArgument='<%# Eval("CategoryID") %>' Text="حذف" OnClientClick="return confirm('آیا مطمئن هستید که می‌خواهید این دسته‌بندی را حذف کنید؟');"></asp:LinkButton>
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