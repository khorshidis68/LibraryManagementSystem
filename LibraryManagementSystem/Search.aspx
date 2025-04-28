<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibraryManagementSystem.Search" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>جستجوی کتاب‌ها - سیستم مدیریت کتابخانه</title>
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>جستجوی کتاب‌ها</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <label for="txtSearch">جستجو بر اساس عنوان یا نویسنده:</label>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="جستجو" OnClick="btnSearch_Click" CssClass="btn" />
                </div>
                <div>
                    <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="BookID" HeaderText="شناسه" />
                            <asp:BoundField DataField="Title" HeaderText="عنوان" />
                            <asp:BoundField DataField="Author" HeaderText="نویسنده" />
                            <asp:BoundField DataField="CategoryName" HeaderText="دسته‌بندی" />
                            <asp:BoundField DataField="Quantity" HeaderText="تعداد موجود" />
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