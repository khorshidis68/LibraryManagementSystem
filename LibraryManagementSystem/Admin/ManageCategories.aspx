<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageCategories" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Categories - Library Management System</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Manage Categories</h1>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtCategoryName">Category Name:</label>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName" ErrorMessage="Category name is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Category" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Category" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvCategories_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="CategoryID" HeaderText="ID" />
                            <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditCategory" CommandArgument='<%# Eval("CategoryID") %>' Text="Edit"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteCategory" CommandArgument='<%# Eval("CategoryID") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this category?');"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </main>
        <footer>
            <p>&copy; 2023 Library Management System. All rights reserved.</p>
        </footer>
    </form>
</body>
</html>