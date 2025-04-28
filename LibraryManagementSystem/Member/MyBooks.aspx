<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBooks.aspx.cs" Inherits="LibraryManagementSystem.Member.MyBooks" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>کتاب‌های من - سیستم مدیریت کتابخانه</title>
    <link href="../Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h3>کتاب‌های من</h3>
        </header>
        <main>
            <div>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <div>
                    <asp:GridView ID="gvMyBooks" runat="server" AutoGenerateColumns="false" CssClass="table">
                        <Columns>
                            <asp:BoundField DataField="BookTitle" HeaderText="عنوان کتاب" />
                            <asp:BoundField DataField="IssueDate" HeaderText="تاریخ امان" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="ReturnDate" HeaderText="تاریخ بازپس‌گیری" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:BoundField DataField="FineAmount" HeaderText="مبلغ جریمه" DataFormatString="{0:C}" />
                            <asp:TemplateField HeaderText="وضعیت">
                                <ItemTemplate>
                                    <%# Eval("ReturnDate") == DBNull.Value ? "بازپس‌داده نشده" : "بازپس‌داده شده" %>
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