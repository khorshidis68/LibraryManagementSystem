<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LibraryManagementSystem.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ثبت‌نام - سیستم مدیریت کتابخانه</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>ثبت‌نام</h1>
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
                    <label for="txtConfirmPassword">تکرار رمز عبور:</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="تکرار رمز عبور الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="رمزهای عبور مطابقت ندارند." ForeColor="Red"></asp:CompareValidator>
                </div>
                <div>
                    <label for="txtEmail">ایمیل:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="ایمیل الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="فرمت ایمیل نادرست است." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Button ID="btnRegister" runat="server" Text="ثبت‌نام" OnClick="btnRegister_Click" CssClass="btn" />
                </div>
                <div>
                    <p>حساب کاربری دارید؟ <a href="Login.aspx">ورود از اینجا</a>.</p>
                </div>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>