<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="LibraryManagementSystem.ContactUs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>تماس با ما - سیستم مدیریت کتابخانه</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>تماس با ما</h1>
        </header>
        <main>
            <div>
                <h2>با ما در تماس باشید</h2>
                <p>اگر سوالی دارید یا نیاز به پشتیبانی دارید، لطفاً فرم زیر را تکمیل کنید و ما در اسرع وقت به شما پاسخ خواهیم داد.</p>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
                <div>
                    <label for="txtName">نام:</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="نام الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <label for="txtEmail">ایمیل:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="ایمیل الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="فرمت ایمیل نادرست است." ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
                <div>
                    <label for="txtMessage">پیام:</label>
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage" ErrorMessage="پیام الزامی است." ForeColor="Red">*</asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Button ID="btnSubmit" runat="server" Text="ارسال" OnClick="btnSubmit_Click" CssClass="btn" />
                </div>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>