using System;
using System.Globalization;

namespace NovelDownloader.CoreBase.Help
{
    /// <summary>
    /// 日期型態擴充功能
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日)("yyyy/MM/dd")
        /// </summary>
        /// <param name="dateTime">日期時間</param>
        /// <returns>Birthday date in string format</returns>
        /// <example>2017/08/04</example>
        public static string ToDateTimeString(this DateTime dateTime)
        {
            //CultureInfo culture = CultureInfo.GetCultureInfo("zh-TW");, culture
            return dateTime.ToString("yyyy/MM/dd");
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日)("yyyy/MM/dd")
        /// </summary>
        /// <param name="dateTime">日期時間</param>
        /// <returns>Birthday date in string format</returns>
        /// <example>2017/08/04</example>
        public static string ToDateTimeString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToDateTimeString() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒)("yyyy/MM/dd HH:mm:ss")
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒)("yyyy/MM/dd HH:mm:ss")
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTime(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToFullDateTime() : null;
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒 毫秒)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTimeMillisecond(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/dd HH:mm:ss fff");
        }

        /// <summary>
        /// 轉換為 客製化的日期字串(年/月/日 時:分:秒 毫秒)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFullDateTimeMillisecond(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToFullDateTimeMillisecond() : null;
        }

        /// <summary>
        /// 民國年月日(yyyMMdd)
        /// </summary>
        /// <param name="dateTime">Datetime</param>
        /// <returns></returns>
        public static string ToClaimTaiwanDate(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            return string.Format(
                    CultureInfo.CurrentCulture, "{0}{1}{2}",
                    dateTime.ToClaimTaiwanYearNumber(),
                    dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Day.ToString("D2", CultureInfo.CurrentCulture)
                   );
        }

        /// <summary>
        /// 民國年月日(yyyMMdd)
        /// </summary>
        /// <param name="dateTime">Nullable Datetime</param>
        /// <returns></returns>
        public static string ToClaimTaiwanDate(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDate();
        }

        /// <summary>
        /// 民國年月日時分(yyyMMddHHmm)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTimeHHmm(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            return string.Format(
                   CultureInfo.CurrentCulture, "{0}{1}{2}{3}{4}",
                   dateTime.ToClaimTaiwanYearNumber(),
                   dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Day.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Hour.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Minute.ToString("D2", CultureInfo.CurrentCulture)
                   );
        }

        /// <summary>
        /// 民國年月日時分(yyyMMddHHmm)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTimeHHmm(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDateTimeHHmm();
        }

        /// <summary>
        /// 民國年月日時分秒(yyyMMddHHmmss)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTime(this DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return string.Empty;
            }

            return string.Format(
                   CultureInfo.CurrentCulture, "{0}{1}{2}{3}{4}{5}",
                   dateTime.ToClaimTaiwanYearNumber(),
                   dateTime.Month.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Day.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Hour.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Minute.ToString("D2", CultureInfo.CurrentCulture),
                   dateTime.Second.ToString("D2", CultureInfo.CurrentCulture)
                   );
        }

        /// <summary>
        /// 民國年月日時分秒(yyyMMddHHmmss)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanDateTime(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return string.Empty;
            }

            return dateTime.Value.ToClaimTaiwanDateTime();
        }

        /// <summary>
        /// 取得民國年(國字樣式ex:1911→前1；1912→元；1913→2)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanYear(this DateTime dateTime)
        {
            var taiwanCalendar = new TaiwanCalendar();

            if (dateTime >= new DateTime(1913, 1, 1))
            {
                return taiwanCalendar.GetYear(dateTime).ToString();
            }
            if (dateTime >= new DateTime(1912, 1, 1))
            {
                return "元";
            }
            else
            {
                return "前" + Math.Abs(dateTime.Year - 1912).ToString(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// 取得民國年(數值樣式ex:1911→-01；1912→001；1913→002)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClaimTaiwanYearNumber(this DateTime dateTime)
        {
            var taiwanCalendar = new TaiwanCalendar();

            if (dateTime >= new DateTime(1912, 1, 1))
            {
                return taiwanCalendar.GetYear(dateTime).ToString("D3");
            }
            else
            {
                return "-" + Math.Abs(dateTime.Year - 1912).ToString(CultureInfo.CurrentCulture).PadLeft(2, '0');
            }
        }

        /// <summary>
        /// 取得月份最後一天最後一秒
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime getLastDayLastMoment(this DateTime datetime)
        {
            return datetime.getLastDay().getDateEnd();
        }

        /// <summary>
        /// 取得月份最後一天
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns></returns>
        public static DateTime getLastDay(this DateTime dateTime)
        {
            var days = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, days);
        }

        /// <summary>
        /// 取得月份第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getFirstDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// 取得月份上個月最後一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getLastMonthLasttDay(this DateTime dateTime)
        {
            return dateTime.getFirstDay().AddDays(-1);
        }

        /// <summary>
        /// 取得月份上個月第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getLastMonthFirstDay(this DateTime dateTime)
        {
            return dateTime.getLastMonthLasttDay().getFirstDay();
        }

        /// <summary>
        /// 取得當日一開始那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getDateStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// 取得當日一開始那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? getDateStart(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return dateTime;
            }

            return dateTime.Value.getDateStart();
        }

        /// <summary>
        /// 取得當日最後那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime getDateEnd(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddSeconds(-1);
        }

        /// <summary>
        /// 取得當日最後那一秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? getDateEnd(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return dateTime;
            }

            return dateTime.Value.getDateEnd();
        }

        /// <summary>
        /// 取得兩日期差異之年、月、日
        /// </summary>
        /// <param name="self"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static (int years, int months, int days) TimespanToDate(this DateTime self, DateTime target)
        {
            int years, months, days;
            // 因為只需取量，不決定誰大誰小，所以如果self < target時要交換將大的擺前面
            if (self < target)
            {
                var tmp = target;
                target = self;
                self = tmp;
            }

            // 將年轉換成月份以便用來計算
            months = 12 * (self.Year - target.Year) + (self.Month - target.Month);

            // 如果天數要相減的量不夠時要向月份借天數補滿該月再來相減
            if (self.Day < target.Day)
            {
                months--;
                days = DateTime.DaysInMonth(target.Year, target.Month) - target.Day + self.Day;
            }
            else
            {
                days = self.Day - target.Day;
            }

            // 天數計算完成後將月份轉成年
            years = months / 12;
            months = months % 12;

            return (years, months, days);
        }

        /// <summary>
        /// 健保年齡計算
        /// Example: 2018/05/05 ~ 2019/05/01 => (0, 11, 26)
        /// Example: 2018/05/05 ~ 2019/05/05 => (1, 0, 0)
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="specificDate">指定日期</param>
        /// <returns>(年, 月, 日)</returns>
        public static (int years, int months, int days) ConvertToNHIAges(this DateTime birthday, DateTime specificDate)
        {
            int enoughOneMonthDays = 30; // 足月天數
            int enoughOneYearMonths = 12; // 足年月數

            int birthdayYear = birthday.Year;
            int birthdayMonth = birthday.Month;
            int birthdayDay = birthday.Day;

            int specificYear = specificDate.Year;
            int specificMonth = specificDate.Month;
            int specificDay = specificDate.Day;

            int resultYear = 0;
            int resultMonth = 0;
            int resultDay = 0;

            // 年月日相減
            resultYear = specificYear - birthdayYear;
            resultMonth = specificMonth - birthdayMonth;
            resultDay = specificDay - birthdayDay;

            // 天數不足 則往前借一個月
            if (resultDay < 0)
            {
                resultDay += enoughOneMonthDays;
                resultMonth--;
            }

            // 月份不足 則往前借一年
            if (resultMonth < 0)
            {
                resultMonth += enoughOneYearMonths;
                resultYear--;
            }

            // 超過30天則為足月 換成多一個月
            if (resultDay >= enoughOneMonthDays)
            {
                resultDay -= enoughOneMonthDays;
                resultMonth++;

                // 超過12月則足年 換成多一年
                if (resultMonth >= enoughOneYearMonths)
                {
                    resultMonth -= enoughOneYearMonths;
                    resultYear++;
                }
            }

            return (resultYear, resultMonth, resultDay);
        }

        /// <summary>
        /// 健保年齡計算
        /// Example: 2018/05/05 ~ 2019/05/01 => (0, 11, 26)
        /// Example: 2018/05/05 ~ 2019/05/05 => (1, 0, 0)
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <param name="specificDate">指定日期</param>
        /// <returns>(年, 月, 日)</returns>
        public static (int years, int months, int days) ConvertToNHIAges(this DateTime birthday, DateTime specificDate, string returnUnit)
        {
            int enoughOneMonthDays = 30; // 足月天數
            int enoughOneYearMonths = 12; // 足年月數

            int birthdayYear = birthday.Year;
            int birthdayMonth = birthday.Month;
            int birthdayDay = birthday.Day;

            int specificYear = specificDate.Year;
            int specificMonth = specificDate.Month;
            int specificDay = specificDate.Day;

            int resultYear = 0;
            int resultMonth = 0;
            int resultDay = 0;

            // 年月日相減
            resultYear = specificYear - birthdayYear;
            resultMonth = specificMonth - birthdayMonth;
            resultDay = specificDay - birthdayDay;

            // 天數不足 則往前借一個月
            if (resultDay < 0)
            {
                resultDay += enoughOneMonthDays;
                resultMonth--;
            }

            // 月份不足 則往前借一年
            if (resultMonth < 0)
            {
                resultMonth += enoughOneYearMonths;
                resultYear--;
            }

            return (resultYear, resultMonth, resultDay);
        }
    }
}