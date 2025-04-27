<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageIssues.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageIssues" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Issues - Library Management System</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Manage Issues</h1>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="ddlBooks">Book:</label>
                    <asp:DropDownList ID="ddlBooks" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvBooks" runat="server" ControlToValidate="ddlBooks" InitialValue="0" ErrorMessage="Book is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="ddlMembers">Member:</label>
                    <asp:DropDownList ID="ddlMembers" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMembers" runat="server" ControlToValidate="ddlMembers" InitialValue="0" ErrorMessage="Member is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtIssueDate">Issue Date:</label>
                    <asp:TextBox ID="txtIssueDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvIssueDate" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="Issue date is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtReturnDate">Return Date:</label>
                    <asp:TextBox ID="txtReturnDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvReturnDate" runat="server" ControlToValidate="txtReturnDate" ErrorMessage="Return date is required." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Issue" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CssClass="btn" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvIssues" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvIssues_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IssueID" HeaderText="ID" />
                            <asp:BoundField DataField="BookTitle" HeaderText="Book Title" />
                            <asp:BoundField DataField="MemberName" HeaderText="Member Name" />
                            <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="ReturnDate" HeaderText="Return Date" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="FineAmount" HeaderText="Fine Amount" DataFormatString="{0:C}" />
                            <asp:TemplateField HeaderText="Actions">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkClear" runat="server" CommandName="ClearIssue" CommandArgument='<%# Eval("IssueID") %>' Text="Clear" OnClientClick="return confirm('Are you sure you want to clear this issue?');"></asp:LinkButton>
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