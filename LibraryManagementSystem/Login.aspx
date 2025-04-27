<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagementSystem.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ورود - سیستم مدیریت کتابخانه</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>ورود</h1>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtUsername">نام کاربری:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="نام کاربری الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtPassword">رمز عبور:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="رمز عبور الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="ورود" OnClick="btnLogin_Click" CssClass="btn" />
                </div>
                <div>
                    <p>حساب کاربری ندارید؟ <a href="Register.aspx">اینجا ثبت‌نام کنید</a>.</p>
                </div>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>