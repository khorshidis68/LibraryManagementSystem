using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// کلاس Helper برای مدیریت اتصال به دیتابیس و اجرای کوئری‌ها
/// </summary>
public static class DatabaseHelper
{
    /// <summary>
    /// گرفتن Connection String از فایل Web.config
    /// </summary>
    /// <returns>رشته اتصال به دیتابیس</returns>
    private static string GetConnectionString()
    {
        // از فایل Web.config رشته اتصال به دیتابیس را می‌خوانیم
        return System.Configuration.ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
    }

    /// <summary>
    /// اجرای کوئری‌های SELECT و بازگرداندن نتیجه به صورت DataTable
    /// </summary>
    /// <param name="query">کوئری SQL</param>
    /// <returns>جدول داده‌ها (DataTable)</returns>
    public static DataTable ExecuteQuery(string query)
    {
        try
        {
            // ایجاد اتصال به دیتابیس
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open(); // باز کردن اتصال

                // ایجاد دستور SQL
                SqlCommand cmd = new SqlCommand(query, conn);

                // استفاده از SqlDataAdapter برای پر کردن DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt); // پر کردن جدول داده‌ها

                return dt; // بازگرداندن جدول داده‌ها
            }
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در اجرای کوئری: " + ex.Message);
        }
    }

    /// <summary>
    /// اجرای کوئری‌های INSERT, UPDATE, DELETE
    /// </summary>
    /// <param name="query">کوئری SQL</param>
    /// <returns>تعداد ردیف‌های تحت تأثیر قرار گرفته</returns>
    public static int ExecuteNonQuery(string query)
    {
        try
        {
            // ایجاد اتصال به دیتابیس
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open(); // باز کردن اتصال

                // ایجاد دستور SQL
                SqlCommand cmd = new SqlCommand(query, conn);

                // اجرای کوئری و بازگرداندن تعداد ردیف‌های تحت تأثیر قرار گرفته
                return cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در اجرای کوئری: " + ex.Message);
        }
    }

    /// <summary>
    /// اجرای کوئری‌هایی که یک مقدار اسکالر (Scalar) بازمی‌گردانند
    /// </summary>
    /// <param name="query">کوئری SQL</param>
    /// <returns>مقدار اسکالر (مثلاً COUNT, SUM, MAX)</returns>
    public static object ExecuteScalar(string query)
    {
        try
        {
            // ایجاد اتصال به دیتابیس
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open(); // باز کردن اتصال

                // ایجاد دستور SQL
                SqlCommand cmd = new SqlCommand(query, conn);

                // اجرای کوئری و بازگرداندن مقدار اسکالر
                return cmd.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در اجرای کوئری: " + ex.Message);
        }
    }
}