<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LibraryManagementSystem.Admin.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>داشبورد مدیریت - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>داشبورد مدیریت</h1>
        </header>
        <main>
            <div>
                <h2>خوش آمدید، مدیر!</h2>
                <p>در اینجا خلاصه‌ای از وضعیت فعلی کتابخانه آورده شده است:</p>
                <div>
                    <asp:Label ID="lblTotalBooks" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTotalMembers" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTotalEmployees" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblTotalIssues" runat="server"></asp:Label>
                </div>
                <hr />
                <h3>دسترسی سریع</h3>
                <ul>
                    <li><a href="ManageBooks.aspx">مدیریت کتاب‌ها</a></li>
                    <li><a href="ManageCategories.aspx">مدیریت دسته‌بندی‌ها</a></li>
                    <li><a href="ManageMembers.aspx">مدیریت اعضا</a></li>
                    <li><a href="ManageEmployees.aspx">مدیریت کارمندان</a></li>
                    <li><a href="ManageIssues.aspx">مدیریت امانات</a></li>
                </ul>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>