using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace NovelDownloader.CoreBase.Help
{
    /// <summary>
    /// String的擴充
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 民國年月日時分(10701020304)轉西元年月日時分
        /// </summary>
        /// <param name="stringDate">民國年月(10701)</param>
        /// <returns></returns>
        public static string ToDCFullDateTimeString(this string stringDate)
        {
            CultureInfo culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();
            //DateTime dateTime = DateTime.MinValue;
            DateTime? dateTime = stringDate.FromChineseFullStringToDate();

            if (dateTime == null)
            {
                return string.Empty;
            }

            return dateTime.Value.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture); ;
        }

        /// <summary>
        /// 民國年月(10701)轉西元年月
        /// </summary>
        /// <param name="yearMonth">民國年月(10701)</param>
        /// <returns></returns>
        public static string ToDCYearMonthString(this string yearMonth)
        {
            CultureInfo culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();
            DateTime dateTime = DateTime.MinValue;

            // 判斷是否包含日期
            if (yearMonth.Length == 5)
            {
                // 切割年
                var year = yearMonth.Substring(0, 3);

                // 切割月
                var month = yearMonth.Substring(3, 2);

                // 轉成DateTime格式
                var totalDate = year + "/" + month + "/01";

                // 轉成西元年
                dateTime = DateTime.Parse(totalDate, culture);
            }

            string dcYearMonth = dateTime.ToString("yyyyMM", CultureInfo.CurrentCulture);
            return dcYearMonth;
        }

        /// <summary>
        /// 民國年月日時分秒字串轉西元日期
        /// </summary>
        /// <param name="value">yyyMMddHHmmss</param>
        /// <returns></returns>
        public static DateTime? FromChineseFullStringToDate(this string value)
        {
            string[] format = { "yyyyMMddHHmmss" };
            string stripped = Regex.Replace(value, "[^0-9]", string.Empty);

            if (stripped.Length < 13)
            {
                return DateTime.MinValue;
            }

            int yearInt = Convert.ToInt16(stripped.Substring(0, 3), CultureInfo.CurrentCulture) + 1911;
            string yearString = Convert.ToString(yearInt, CultureInfo.CurrentCulture);
            string dateString = yearString + stripped.Substring(3, 10);
            if (DateTime.TryParseExact(dateString, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }

            return null;
        }

        /// <summary>
        /// 民國年月日時分字串轉西元日期
        /// </summary>
        /// <param name="value">yyyMMddHHmmss</param>
        /// <returns></returns>
        public static DateTime? FromChineseStringToDate(this string value)
        {
            string[] format = { "yyyyMMddHHmm" };
            string stripped = Regex.Replace(value, "[^0-9]", string.Empty);

            if (value.Trim() == string.Empty)
            {
                return null;
            }

            if (stripped.Length < 11)
            {
                return DateTime.MinValue;
            }

            int yearInt = Convert.ToInt16(stripped.Substring(0, 3), CultureInfo.CurrentCulture) + 1911;
            string yearString = Convert.ToString(yearInt, CultureInfo.CurrentCulture);
            string dateString = yearString + stripped.Substring(3, 8);
            if (DateTime.TryParseExact(dateString, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }

            return null;
        }

        /// <summary>
        /// 民國年(1070101)轉西元年
        /// </summary>
        /// <param name="rOCYear">民國年字串</param>
        /// <returns>格式不正確回傳null</returns>
        public static DateTime? ConvertDCYear(this string rOCYear)
        {
            DateTime? gongYuanyan;
            try
            {
                // 判斷是否是民國年
                if (rOCYear.Length == 7)
                {
                    // 切割年
                    var year = rOCYear.Substring(0, 3);

                    // 切割月
                    var month = rOCYear.Substring(3, 2);

                    // 切割日
                    var day = rOCYear.Substring(5, 2);

                    // 轉成DateTime格式
                    var totalDate = year + "/" + month + "/" + day;

                    // 轉成西元年
                    CultureInfo culture = new CultureInfo("zh-TW");
                    culture.DateTimeFormat.Calendar = new TaiwanCalendar();

                    gongYuanyan = DateTime.Parse(totalDate, culture);
                }
                else
                {
                    // 如果字串傳入字串不等於7，則回傳null
                    gongYuanyan = null;
                }
            }
            catch
            {
                // 如果字串傳入字串格式不正確(ex:英文)，則回傳null
                gongYuanyan = null;
            }

            return gongYuanyan;
        }

        /// <summary>
        /// 民國年(107/01/01 or 1070101)轉西元
        /// </summary>
        /// <param name="rocYear">民國年(107/01/01)</param>
        /// <returns></returns>
        public static DateTime ToDCYear(this string rocYear)
        {
            CultureInfo tc = new CultureInfo("zh-TW");
            tc.DateTimeFormat.Calendar = new TaiwanCalendar();
            if (!rocYear.Contains("/"))
            {
                string Date = rocYear.Substring(0, 3) + "/" + rocYear.Substring(3, 2) + "/" + rocYear.Substring(5, 2);
                return DateTime.Parse(Date, tc).Date;
            }
            else
            { return DateTime.Parse(rocYear, tc).Date; }
        }

        /// <summary>
        /// 字串轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringToDateTime(this string value)
        {
            if (DateTime.TryParse(value, out DateTime dt))
            {
                return dt;
            }

            return null;
        }

        /// <summary>
        /// 字串yyyyMMdd轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime(this string value)
        {
            string[] format = { "yyyyMMdd" };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }
        /// <summary>
        /// 字串yyyy/MM/dd hh:mm轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime2(this string value)
        {
            string[] format = { "yyyy/MM/dd HH:mm" };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }
        /// <summary>
        /// 字串yyyyMMddHHmmss轉DateTime
        /// </summary>
        /// <param name="value">字串</param>
        /// <returns></returns>
        public static DateTime? StringDCToDateTime3(this string value)
        {
            string[] format = { "yyyyMMddHHmmss" };
            if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime dt))
            {
                return dt;
            }

            return null;
        }

        /// <summary>
        /// 字串轉布林
        /// (不能保證值只有0/1/N/Y，就用這組)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? ToBooleanNull(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)
                || value.Trim().Length > 1)
            {
                return null;
            }
            else if (value == "0" || value.ToUpper() == "N")
            {
                return false;
            }
            else if (value == "1" || value.ToUpper() == "Y")
            {
                return true;
            }

            return null;
        }

        /// <summary>
        /// 字串轉布林
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string value)
        {
            if (value != null && (value == "1" || value == "-1" || value.ToUpper() == "Y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取得目前 string 物件中字元的數目，Null 和 Empty 回傳0。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetNullLength(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            else
            {
                return value.Length;
            }
        }

        /// <summary>
        /// 字串轉數值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return decimal.TryParse(value, out var number) ? number : 0;
        }

        /// <summary>
        /// 字串轉數值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(this string value)
        {
            if (decimal.TryParse(value, out decimal number))
            {
                return number;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 文字 轉為 Enums(以DisplayName)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DisplayToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

                if (attributes.Length > 0 && attributes[0].Name == value)
                {
                    result = eVal;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Description)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T DescriptionToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                FieldInfo fi = eVal.GetType().GetField(eVal.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0 && attributes[0].Description == value)
                {
                    result = eVal;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以Name)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T NameToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            foreach (T eVal in Enum.GetValues(enumType))
            {
                if (eVal.ToString() == value)
                {
                    result = eVal;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 文字 轉為 Enums(以值)
        /// 找不到時，會預設給予第一個Enum，請慎用
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <returns></returns>
        public static T ValueToEnum<T>(this string value)
            where T : struct
        {
            var enumType = typeof(T);
            T result = default;

            if (int.TryParse(value, out int intValue))
            {
                result = intValue.ToEnum<T>();
            }
            return result;
        }

        /// <summary>
        /// 字串文字遮罩
        /// </summary>
        /// <param name="sensitiveData">來源字串</param>
        /// <param name="startMaskIndex">遮罩起始位置</param>
        /// <param name="maskCount">遮罩字元數</param>
        /// <param name="maskChar">遮罩替代字元(預設為'*')</param>
        /// <returns></returns>
        public static string Mask(this string sensitiveData, int startMaskIndex, int maskCount, char maskChar = '*')
        {
            try
            {
                var stringBuilder = new StringBuilder(sensitiveData)
                    .Remove(startMaskIndex, maskCount)
                    .Insert(startMaskIndex, new string(maskChar, maskCount));
                return Convert.ToString(stringBuilder, null);
            }
            catch
            {
                return sensitiveData;
            }
        }

        /// <summary>
        /// 身分證字號隱碼
        /// </summary>
        /// <param name="idNo">身分證字號</param>
        /// <returns></returns>
        public static string MaskIdNo(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return value;
                }

                return value.Mask(3, 4);
            }
            catch
            {
                return value;
            }
        }

        /// <summary>
        /// String To StringBuilder
        /// </summary>
        /// <param name="value">傳入之String</param>
        /// <returns></returns>
        public static StringBuilder ToStringBuilder(this string value)
        {
            try
            {
                var Result = new StringBuilder();
                if (string.IsNullOrEmpty(value))
                {
                    Result.Append("");
                }
                else
                {
                    Result.Append(value);
                }
                return Result;
            }
            catch
            {
                return new StringBuilder("");
            }
        }
    }
}
