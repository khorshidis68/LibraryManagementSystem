<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryManagementSystem.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>صفحه اصلی - سیستم مدیریت کتابخانه</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>به سیستم مدیریت کتابخانه خوش آمدید</h1>
        </header>
        <main>
            <div>
                <p>این یک سیستم مدیریت کتابخانه است که به مدیریت کارآمد کتاب‌ها، اعضا و کارمندان کمک می‌کند.</p>
                <ul>
                    <li><a href="Login.aspx">ورود</a> برای دسترسی به حساب کاربری خود.</li>
                    <li><a href="Register.aspx">ثبت‌نام</a> اگر حساب کاربری ندارید.</li>
                    <li><a href="Search.aspx">جستجوی کتاب‌ها</a> برای پیدا کردن کتاب‌های موجود.</li>
                    <li><a href="AboutUs.aspx">درباره ما</a> برای کسب اطلاعات بیشتر درباره سیستم.</li>
                    <li><a href="ContactUs.aspx">تماس با ما</a> برای هرگونه سوال یا پشتیبانی.</li>
                </ul>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>