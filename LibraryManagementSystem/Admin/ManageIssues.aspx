<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageIssues.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageIssues" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>مدیریت امانت کتاب‌ها - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>مدیریت امانت کتاب‌ها</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="ddlBooks">کتاب:</label>
                    <asp:DropDownList ID="ddlBooks" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                        <asp:ListItem Text="-- انتخاب کتاب --" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvBooks" runat="server" ControlToValidate="ddlBooks" InitialValue="0" ErrorMessage="انتخاب کتاب اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="ddlMembers">عضو:</label>
                    <asp:DropDownList ID="ddlMembers" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                        <asp:ListItem Text="-- انتخاب عضو --" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMembers" runat="server" ControlToValidate="ddlMembers" InitialValue="0" ErrorMessage="انتخاب عضو اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtDueDate">تاریخ سررسید:</label>
                    <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDueDate" runat="server" ControlToValidate="txtDueDate" ErrorMessage="تاریخ سررسید اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="ddlEmployees">کارمند:</label>
                    <asp:DropDownList ID="ddlEmployees" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                        <asp:ListItem Text="-- انتخاب کارمند --" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvEmployees" runat="server" ControlToValidate="ddlEmployees" InitialValue="0" ErrorMessage="انتخاب کارمند اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtLateFee">جریمه تأخیر:</label>
                    <asp:TextBox ID="txtLateFee" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revLateFee" runat="server" ControlToValidate="txtLateFee" ValidationExpression="^\d+(\.\d{1,2})?$" ErrorMessage="جریمه باید عددی با حداکثر دو رقم اعشار باشد." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="ddlStatus">وضعیت:</label>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Text="امانت داده شده" Value="Issued"></asp:ListItem>
                        <asp:ListItem Text="بازگردانده شده" Value="Returned"></asp:ListItem>
                        <asp:ListItem Text="سررسید گذشته" Value="Overdue"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="افزودن امانت" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="ویرایش امانت" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvIssues" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvIssues_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IssueID" HeaderText="شناسه" />
                            <asp:BoundField DataField="BookTitle" HeaderText="عنوان کتاب" />
                            <asp:BoundField DataField="MemberName" HeaderText="نام عضو" />
                            <asp:BoundField DataField="IssueDate" HeaderText="تاریخ امانت" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="DueDate" HeaderText="تاریخ سررسید" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="ReturnDate" HeaderText="تاریخ بازگشت" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="EmployeeName" HeaderText="نام کارمند" />
                            <asp:BoundField DataField="LateFee" HeaderText="جریمه تأخیر" DataFormatString="{0:C}" />
                            <asp:BoundField DataField="Status" HeaderText="وضعیت" />
                            <asp:TemplateField HeaderText="عملیات">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditIssue" CommandArgument='<%# Eval("IssueID") %>' Text="ویرایش"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteIssue" CommandArgument='<%# Eval("IssueID") %>' Text="حذف" OnClientClick="return confirm('آیا مطمئن هستید که می‌خواهید این امانت را حذف کنید؟');"></asp:LinkButton>
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