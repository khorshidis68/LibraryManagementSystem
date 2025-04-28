<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageBooks.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageBooks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>مدیریت کتاب‌ها - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>مدیریت کتاب‌ها</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtTitle">عنوان:</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="عنوان اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="txtAuthor">نویسنده:</label>
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="txtAuthor" ErrorMessage="نویسنده اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="ddlCategory">دسته‌بندی:</label>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory" InitialValue="0" ErrorMessage="دسته‌بندی اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="txtQuantity">تعداد:</label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="تعداد اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revQuantity" runat="server" ControlToValidate="txtQuantity" ValidationExpression="^\d+$" ErrorMessage="تعداد باید عدد باشد." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="افزودن کتاب" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="ویرایش کتاب" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvBooks_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="BookID" HeaderText="شناسه" />
                            <asp:BoundField DataField="Title" HeaderText="عنوان" />
                            <asp:BoundField DataField="Author" HeaderText="نویسنده" />
                            <asp:BoundField DataField="CategoryName" HeaderText="دسته‌بندی" />
                            <asp:BoundField DataField="Quantity" HeaderText="تعداد" />
                            <asp:TemplateField HeaderText="عملیات">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditBook" CommandArgument='<%# Eval("BookID") %>' Text="ویرایش"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteBook" CommandArgument='<%# Eval("BookID") %>' Text="حذف" OnClientClick="return confirm('آیا مطمئن هستید که می‌خواهید این کتاب را حذف کنید؟');"></asp:LinkButton>
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