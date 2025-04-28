<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryManagementSystem.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="rtl">
<head runat="server">
    <title>صفحه اصلی - سیستم مدیریت کتابخانه</title>
    <link href="Styles/Site.css" rel="stylesheet" />
    <style>
        /* تنظیمات عمومی */
        body {
            font-family: 'Vazirmatn', Tahoma, Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
            color: #333;
            direction: rtl;
            text-align: right;
        }

        header {
            background-color: #4CAF50;
            color: white;
            padding: 20px;
            text-align: center;
        }

        form {
            width: 80%; /* عرض فرم */
            max-width: 1200px; /* حداکثر عرض */
            margin: 0 auto; /* قرار دادن فرم در وسط */
            padding: 20px;
            box-sizing: border-box;
        }

        main {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(250px, 1fr)); /* تنظیم تعداد ستون‌ها */
            gap: 20px; /* فاصله بین کادرهای مربعی */
        }

        .card {
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 12px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding: 30px; /* کاهش فضای داخلی کادر */
            text-align: center;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            display: flex;
            flex-direction: column;
            justify-content: space-between; /* مدیریت فضای بین محتوا و دکمه */
            height: auto; /* ارتفاع خودکار */
        }

        .card:hover {
            transform: translateY(-10px);
            box-shadow: 0 8px 12px rgba(0, 0, 0, 0.2);
        }

        .card h3 {
            margin: 0 0 1px; /* کاهش فاصله بین عنوان و متن */
            font-size: 16px;
            color: #4CAF50;
        }

        .card p {
            font-size: 14px;
            color: #555;
            margin-bottom: 10px; /* کاهش فاصله بین متن و دکمه */
        }

        .card a {
            display: inline-block;
            width: 90%; /* عرض دکمه‌ها به اندازه کادر */
            padding: 15px; /* کاهش پدینگ دکمه */
            background-color: #4CAF50;
            color: white;
            text-decoration: none;
            border-radius: 4px;
            text-align: center;
            transition: background-color 0.3s ease;
            margin-top: 5px; /* دکمه را در پایین کادر قرار می‌دهد */
        }

        .card a:hover {
            background-color: #45a049;
        }

        footer {
            background-color: #333;
            color: white;
            text-align: center;
            padding: 10px;
            position: relative;
            bottom: 0;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3 style="text-align:center">به سیستم مدیریت کتابخانه خوش آمدید</h3>
        </header>
        <main>
            <div class="card">
                <h3>ورود</h3>
                <p>برای دسترسی به حساب کاربری خود وارد شوید.</p>
                <a href="Login.aspx">ورود</a>
            </div>
            <div class="card">
                <h3>ثبت‌نام</h3>
                <p>اگر حساب کاربری ندارید، ثبت‌نام کنید.</p>
                <a href="Register.aspx">ثبت‌نام</a>
            </div>
            <div class="card">
                <h3>جستجوی کتاب‌ها</h3>
                <p>کتاب‌های موجود را جستجو کنید و اطلاعات بیشتری کسب کنید.</p>
                <a href="Search.aspx">جستجوی کتاب‌ها</a>
            </div>
            <div class="card">
                <h3>درباره ما</h3>
                <p>اطلاعات بیشتری درباره سیستم مدیریت کتابخانه کسب کنید.</p>
                <a href="AboutUs.aspx">درباره ما</a>
            </div>
            <div class="card">
                <h3>تماس با ما</h3>
                <p>برای هرگونه سوال یا پشتیبانی با ما تماس بگیرید.</p>
                <a href="ContactUs.aspx">تماس با ما</a>
            </div>
        </main>
        <footer>
            <p>&copy; 2025 سیستم مدیریت کتابخانه. تمام حقوق محفوظ است.</p>
        </footer>
    </form>
</body>
</html>