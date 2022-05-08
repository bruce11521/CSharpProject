using System;
using System.Runtime.CompilerServices;

namespace NovelDownloader.CoreBase.Help
{
    /// <summary>
    /// 數值型態擴充功能
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// 四捨五入小數位數
        /// </summary>
        /// <param name="number"></param>
        /// <param name="pointCount"></param>
        /// <returns></returns>
        public static decimal ToRound(this decimal number, int pointCount = 0)
        {
            return Math.Round(number, pointCount, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 轉換成千分位文字
        /// </summary>
        /// <param name="number">數值</param>
        /// <param name="format">格式</param>
        /// <returns>數值字串</returns>
        public static string ToThousandBit(this decimal number, string format = "#,##0")
        {
            // Step: 分隔小數欄位
            var pointMapping = format.Split('.');

            // Step: 取得小數位數
            var pointCount = pointMapping.Length > 1 ? pointMapping[1].Length : 0;

            // Step: 依小數位數四捨五入
            var roundResult = number.ToRound(pointCount);//Math.Round(number, pointCount, MidpointRounding.AwayFromZero);

            // Step: 轉文字
            return roundResult.ToString(format, null);
        }

        /// <summary>
        /// 轉換成千分位文字
        /// </summary>
        /// <param name="number">數值</param>
        /// <param name="format">格式</param>
        /// <returns>數值字串</returns>
        public static string ToThousandBit(this decimal? number, string format = "#,##0")
        {
            if (number.HasValue)
            {
                return number.Value.ToThousandBit(format);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 轉換成千分位文字
        /// </summary>
        /// <param name="number">數值</param>
        /// <param name="format">格式</param>
        /// <returns>數值字串</returns>
        public static string ToThousandBit(this int number, string format = "#,##0")
        {
            return number.ToString(format, null);
        }

        /// <summary>
        /// 轉換成千分位文字
        /// </summary>
        /// <param name="number">數值</param>
        /// <param name="format">格式</param>
        /// <returns>數值字串</returns>
        public static string ToThousandBit(this Single number, string format = "#,##0")
        {
            // Step: 分隔小數欄位
            var pointMapping = format.Split('.');

            // Step: 取得小數位數
            var pointCount = pointMapping.Length > 1 ? pointMapping[1].Length : 0;

            // Step: 依小數位數四捨五入
            var roundResult = Math.Round(number, pointCount, MidpointRounding.AwayFromZero);

            // Step: 轉文字
            return roundResult.ToString(format, null);
        }

        /// <summary>
        /// 轉換成千分位文字
        /// </summary>
        /// <param name="number">數值</param>
        /// <param name="format">格式</param>
        /// <returns>數值字串</returns>
        public static string ToThousandBit(this Single? number, string format = "#,##0")
        {
            if (number.HasValue)
            {
                return number.Value.ToThousandBit(format);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 數值轉列舉
        /// </summary>
        /// <typeparam name="T">列舉</typeparam>
        /// <param name="value">數值</param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        /// <summary>
        /// 可丟入 Enum 形態及 value 查出 Name
        /// </summary>
        /// <typeparam name="TEnum">Enum的型態</typeparam>
        /// <param name="enumValue">Enum的數值</param>
        /// <returns></returns>
        public static string GetEnumDisplayName<TEnum>(this int enumValue)
            where TEnum : struct, IConvertible
        {
            return (enumValue.ToEnum<TEnum>() as Enum).GetEnumDisplayName();
        }

        /// <summary>
        /// 可丟入 Enum 形態及 value 查出 Description
        /// </summary>
        /// <typeparam name="TEnum">Enum的型態</typeparam>
        /// <param name="enumValue">Enum的數值</param>
        /// <returns></returns>
        public static string GetEnumDescription<TEnum>(this int enumValue)
            where TEnum : struct, IConvertible
        {
            return (enumValue.ToEnum<TEnum>() as Enum).GetEnumDescription();
        }

        /// <summary>
        /// 取得數值（null回傳0）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int GetValue(this int? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        /// <summary>
        /// 取得數值（null回傳0）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static decimal GetValue(this decimal? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        /// <summary>
        /// 取得數值（null回傳0）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static float GetValue(this float? number)
        {
            return number.HasValue ? number.Value : 0;
        }

        /// <summary>
        /// 轉成字串（null回傳null，而非string.Empty）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToStringNull(this int? number)
        {
            return number.HasValue ? number.ToString() : null;
        }

        /// <summary>
        /// 轉成字串（null回傳null，而非string.Empty）
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToStringNull(this decimal? number)
        {
            return number.HasValue ? number.ToString() : null;
        }

        /// <summary>
        /// Decimal轉成Int
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int ToInt(this decimal number)
        {
            return int.TryParse(number.ToString(), out int value) ? value : 0;
        }

        /// <summary>
        /// Decimal轉成Int
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int ToInt(this decimal? number)
        {
            return number.GetValue().ToInt();
        }

        /// <summary>
        /// 毫秒換算成時間，最高只到時
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string LongMillisecondsToDateTime(this long number, bool showDay = false)
        {
            //var result = new DateTime();
            var result = string.Empty;
            int milliseconds = 0;
            int seconds = 0;
            int minutes = 0;
            int hours = 0;
            int day = 1;
            int month = 1;
            int year = 1;
            var Remaining = number;

            milliseconds = (int)(number % 1000);
            Remaining = (Remaining - milliseconds) / 1000; // 換成秒
            seconds = (int)(Remaining % 60);
            Remaining /= 60; // 換成分
            minutes = (int)(Remaining % 60);
            Remaining /= 60; // 換成時
            hours = showDay ? (int)(Remaining % 24) :(int)Remaining;
            if (showDay)
            {
                Remaining /= 24; // 換成日
                day = (int)(Remaining);
                result = day + "天";
            }

            if (hours > 0)
            {
                result += $" {hours}小時";
            }

            if (minutes > 0)
            {
                result += $" {minutes}分鐘";
            }

            if (seconds > 0)
            {
                result += $" {seconds}秒";
            }

            if (milliseconds > 0)
            {
                result += $" {milliseconds}毫秒";
            }

            //result += $"{hours}小時 {minutes}分鐘 {seconds}秒 {milliseconds}毫秒";
            //result = new DateTime(year, month, day, hours, minutes, seconds, milliseconds);

            return result;
        }
    }
}