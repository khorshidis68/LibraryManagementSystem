<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMembers.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageMembers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Members - Library Management System</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Manage Members</h1>
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
                    <label for="txtEmail">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid email format." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtPhone">Phone:</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\+?[0-9]{10,15}$" ErrorMessage="Invalid phone number format." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtAddress">Address:</label>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Member" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Member" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvMembers_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="MemberID" HeaderText="ID" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditMember" CommandArgument='<%# Eval("MemberID") %>' Text="Edit"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteMember" CommandArgument='<%# Eval("MemberID") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this member?');"></asp:LinkButton>
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