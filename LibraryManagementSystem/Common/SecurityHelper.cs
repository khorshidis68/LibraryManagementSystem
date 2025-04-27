using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// کلاس Helper برای مدیریت امنیت و رمزگذاری
/// </summary>
public static class SecurityHelper
{
    /// <summary>
    /// رمزگذاری گذرواژه با استفاده از الگوریتم SHA256
    /// </summary>
    /// <param name="password">گذرواژه اصلی</param>
    /// <returns>گذرواژه رمزنگاری‌شده به صورت رشته Hexadecimal</returns>
    public static string HashPassword(string password)
    {
        try
        {
            // ایجاد شیء SHA256 برای رمزگذاری
            using (SHA256 sha256 = SHA256.Create())
            {
                // تبدیل گذرواژه به آرایه بایتی
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // رمزگذاری گذرواژه
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // تبدیل نتیجه به رشته Hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2")); // x2 به معنای دو رقم Hexadecimal
                }

                return builder.ToString(); // بازگرداندن گذرواژه رمزنگاری‌شده
            }
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در رمزگذاری گذرواژه: " + ex.Message);
        }
    }

    /// <summary>
    /// مقایسه گذرواژه ورودی با گذرواژه رمزنگاری‌شده
    /// </summary>
    /// <param name="inputPassword">گذرواژه ورودی کاربر</param>
    /// <param name="hashedPassword">گذرواژه رمزنگاری‌شده ذخیره‌شده در دیتابیس</param>
    /// <returns>True اگر گذرواژه‌ها یکسان باشند، در غیر این صورت False</returns>
    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        try
        {
            // رمزگذاری گذرواژه ورودی
            string hashedInput = HashPassword(inputPassword);

            // مقایسه گذرواژه رمزنگاری‌شده ورودی با گذرواژه ذخیره‌شده
            return string.Equals(hashedInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در تأیید گذرواژه: " + ex.Message);
        }
    }
}