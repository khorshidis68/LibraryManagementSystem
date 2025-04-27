<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageEmployees" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Employees - Library Management System</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Manage Employees</h1>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtFullName">Full Name:</label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" ErrorMessage="Full name is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtPosition">Position:</label>
                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPosition" runat="server" ControlToValidate="txtPosition" ErrorMessage="Position is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtHireDate">Hire Date:</label>
                    <asp:TextBox ID="txtHireDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvHireDate" runat="server" ControlToValidate="txtHireDate" ErrorMessage="Hire date is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Employee" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvEmployees_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="Position" HeaderText="Position" />
                            <asp:BoundField DataField="HireDate" HeaderText="Hire Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditEmployee" CommandArgument='<%# Eval("EmployeeID") %>' Text="Edit"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteEmployee" CommandArgument='<%# Eval("EmployeeID") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this employee?');"></asp:LinkButton>
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