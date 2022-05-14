using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace NovelDownloader.CoreBase.Help
{
    /// <summary>
    /// IEnumerable型態擴充功能
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Perform a deep Copy of the object, using Json as a serialisation method. NOTE: Private members are not cloned using this method.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T CloneJson<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }

        /// <summary>
        /// Linq擴充方法By (範例如下)
        /// <code>source.Distinct(Compare.By(a => a.Id));</code>
        /// </summary>
        /// <typeparam name="TSource">來源泛型類別</typeparam>
        /// <typeparam name="TIdentity">識別器泛型類別</typeparam>
        /// <param name="identitySelector">識別器</param>
        /// <returns></returns>
        private static IEqualityComparer<TSource> By<TSource, TIdentity>(Func<TSource, TIdentity> identitySelector)
        {
            return new DelegateComparer<TSource, TIdentity>(identitySelector);
        }

        private class DelegateComparer<T, TIdentity> : IEqualityComparer<T>
        {
            private readonly Func<T, TIdentity> identitySelector;

            public DelegateComparer(Func<T, TIdentity> identitySelector)
            {
                this.identitySelector = identitySelector;
            }

            public bool Equals(T x, T y)
            {
                return Equals(identitySelector(x), identitySelector(y));
            }

            public int GetHashCode(T obj)
            {
                return identitySelector(obj).GetHashCode();
            }
        }

        /// <summary>
        /// Mapping Data (範例如下)
        /// <code> source.MappingData(new Dictionary<string, object>{{"ColumnName1", "ColumnValue1"},{"ColumnName2", "ColumnValue2"},}) </code>
        /// </summary>
        /// <typeparam name="T">Model 態型</typeparam>
        /// <param name="model"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T MappingSource<T>(this T model, Dictionary<string, Object> data)
        {
            var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var row in data)
            {
                var column = modelInfos.FirstOrDefault(o => o.Name == row.Key.ToString());

                // 找不到欄位相符的名稱
                if (column == null)
                {
                    continue;
                }

                var valueType = Nullable.GetUnderlyingType(column?.PropertyType) ?? column?.PropertyType;

                object rowValue = null;
                try
                {
                    // 預防型態可Null結果Value Type不可Null時，塞不了Null值
                    if (valueType != null && row.Value == null)
                    {
                        rowValue = null;
                    }
                    else
                    {
                        rowValue = Convert.ChangeType(row.Value, valueType, CultureInfo.CurrentCulture);
                    }
                }
                catch(Exception ex)
                {
                    continue;
                }

                column.SetValue(model, rowValue);
            }

            return model;
        }

        /// <summary>
        /// 取出Model內的Field及Value
        /// <code> source.GetFieldValue() </code>
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, object> GetFieldValue<T>(this T model)
        {
            try
            {

                var result = typeof(T).GetProperties()
                     .ToDictionary(p => p.Name, p => p.GetValue(model));

                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Model轉換，找不到相同的欄位名稱或是可放置的屬性，皆會被略過
        /// <code> target.ConvertModel(source) </code>
        /// </summary>
        /// <typeparam name="T">目標Model 型態</typeparam>
        /// <typeparam name="TSource">資料來源Model 型態</typeparam>
        /// <param name="model">目標Model</param>
        /// <param name="data">資料Model</param>
        /// <returns></returns>
        public static T CovertModel<T, TSource>(this T model, TSource data)
        {
            return model.MappingSource(data.GetFieldValue());
        }


        #region Class 屬性 Description 轉 Dictionary<string, string>
        /// <summary>
        /// Model轉換 CLASS.Description轉成Dictionary<PROPERTY_NAME, PROPERTY_DESCRIPTION>，找不到相對應的Description皆會預設為string.Empoty
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> GetClassDescriptionDictionary<T>()
            where T : class
        {
            try
            {
                //foreach (var prop in typeof(HeavySickRecord).GetProperties())
                //{
                //    object[] attrs = prop.GetCustomAttributes(true);
                //    foreach (var attr in attrs)
                //    {
                //        DescriptionAttribute da = attr as DescriptionAttribute;
                //        if (da != null)
                //        {
                //            var ssss = da.Description;
                //        }
                //    }
                //}
                //Dictionary<string, string> Class_Description = typeof(T).GetProperties()
                //.ToDictionary(p => p.Name, p => p.GetCustomAttributes(true).Count() > 0 ? ((DescriptionAttribute)p.GetCustomAttributes(true)?.FirstOrDefault()).Description : "");
                var Dict = new Dictionary<string, string>();
                Dict = typeof(T).GetProperties()
                .ToDictionary(p => p.Name, p => p.GetCustomAttributes(true).Count() > 0 ? ((DescriptionAttribute)p.GetCustomAttributes(true)?.FirstOrDefault()).Description : string.Empty);
                return Dict;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Model轉換 CLASS.DisplayName轉成Dictionary<PROPERTY_NAME, PROPERTY_DESCRIPTION>，找不到相對應的DisplayName皆會預設為string.Empoty
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> GetClassDisplayNameDictionary<T>()
            where T : class
        {
            try
            {
                var Dict = new Dictionary<string, string>();
                Dict = typeof(T).GetProperties()
                .ToDictionary(p => p.Name, p => !string.IsNullOrWhiteSpace(p.GetCustomAttribute<DisplayAttribute>().Name) ? p.GetCustomAttribute<DisplayAttribute>().Name : string.Empty);
                return Dict;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// Distinct 去除重複資料時，過濾指定成員屬性
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="Source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> Source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach(TSource element in Source)
            {
                var elementValue = keySelector(element);
                if (seenKeys.Add(elementValue))
                {
                    yield return element;
                }
            }
        }
    }
}
