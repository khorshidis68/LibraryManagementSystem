<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageBooks.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageBooks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Books - Library Management System</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Manage Books</h1>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtTitle">Title:</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtAuthor">Author:</label>
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="txtAuthor" ErrorMessage="Author is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="ddlCategory">Category:</label>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory" InitialValue="0" ErrorMessage="Category is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtQuantity">Quantity:</label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revQuantity" runat="server" ControlToValidate="txtQuantity" ValidationExpression="^\d+$" ErrorMessage="Quantity must be a number." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Book" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Book" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvBooks_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="BookID" HeaderText="ID" />
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                            <asp:BoundField DataField="Author" HeaderText="Author" />
                            <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditBook" CommandArgument='<%# Eval("BookID") %>' Text="Edit"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteBook" CommandArgument='<%# Eval("BookID") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this book?');"></asp:LinkButton>
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