using System;
using System.Globalization;

/// <summary>
/// کلاس Helper برای تبدیل تاریخ میلادی به تاریخ شمسی
/// </summary>
public static class PersianDate
{
    /// <summary>
    /// تبدیل تاریخ میلادی به تاریخ شمسی
    /// </summary>
    /// <param name="date">تاریخ میلادی</param>
    /// <returns>تاریخ شمسی به فرمت "yyyy/MM/dd"</returns>
    public static string ToShamsi(DateTime date)
    {
        try
        {
            // ایجاد یک شیء از کلاس PersianCalendar
            PersianCalendar pc = new PersianCalendar();

            // گرفتن سال، ماه و روز تاریخ شمسی
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);

            // بازگرداندن تاریخ شمسی به فرمت "yyyy/MM/dd"
            return $"{year}/{month:00}/{day:00}";
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در تبدیل تاریخ: " + ex.Message);
        }
    }

    /// <summary>
    /// تبدیل تاریخ شمسی به تاریخ میلادی
    /// </summary>
    /// <param name="persianDate">تاریخ شمسی به فرمت "yyyy/MM/dd"</param>
    /// <returns>تاریخ میلادی</returns>
    public static DateTime ToMiladi(string persianDate)
    {
        try
        {
            // جدا کردن سال، ماه و روز از تاریخ شمسی
            string[] parts = persianDate.Split('/');
            if (parts.Length != 3)
            {
                throw new ArgumentException("فرمت تاریخ شمسی نادرست است. باید به شکل yyyy/MM/dd باشد.");
            }

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            // ایجاد یک شیء از کلاس PersianCalendar
            PersianCalendar pc = new PersianCalendar();

            // تبدیل تاریخ شمسی به تاریخ میلادی
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
        catch (Exception ex)
        {
            // در صورت بروز خطا، پیام خطا را نمایش دهید
            throw new Exception("خطا در تبدیل تاریخ: " + ex.Message);
        }
    }
}