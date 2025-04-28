<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMembers.aspx.cs" Inherits="LibraryManagementSystem.Admin.ManageMembers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>مدیریت اعضا - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>مدیریت اعضا</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtFullName">نام کامل:</label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" ErrorMessage="نام کامل اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <label for="txtEmail">ایمیل:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="ایمیل اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="فرمت ایمیل نادرست است." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtPhone">تلفن:</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="شماره تلفن اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\+?[0-9]{10,15}$" ErrorMessage="فرمت شماره تلفن نادرست است." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtAddress">آدرس:</label>
                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="آدرس اجباری است." ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                </div>
                <div>
                    <asp:Button ID="btnAdd" runat="server" Text="افزودن عضو" OnClick="btnAdd_Click" CssClass="btn" />
                    <asp:Button ID="btnUpdate" runat="server" Text="ویرایش عضو" OnClick="btnUpdate_Click" CssClass="btn" Visible="false" />
                </div>
                <hr />
                <div>
                    <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="false" CssClass="table" OnRowCommand="gvMembers_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="MemberID" HeaderText="شناسه" />
                            <asp:BoundField DataField="FullName" HeaderText="نام کامل" />
                            <asp:BoundField DataField="Email" HeaderText="ایمیل" />
                            <asp:BoundField DataField="Phone" HeaderText="تلفن" />
                            <asp:BoundField DataField="Address" HeaderText="آدرس" />
                            <asp:TemplateField HeaderText="عملیات">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditMember" CommandArgument='<%# Eval("MemberID") %>' Text="ویرایش"></asp:LinkButton> |
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteMember" CommandArgument='<%# Eval("MemberID") %>' Text="حذف" OnClientClick="return confirm('آیا مطمئن هستید که می‌خواهید این عضو را حذف کنید؟');"></asp:LinkButton>
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