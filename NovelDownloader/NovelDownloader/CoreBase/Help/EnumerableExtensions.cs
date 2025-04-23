using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NovelDownloader.Library;
using Oracle.ManagedDataAccess.Client;

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
            if (object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, Formatting.None), deserializeSettings);
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
        /// <code> source.MappingData(new Dictionary&gt;string, object>{{"ColumnName1", "ColumnValue1"},{"ColumnName2", "ColumnValue2"},}) </code>
        /// </summary>
        /// <typeparam name="T">Model 態型</typeparam>
        /// <param name="model"></param>
        /// <param name="data"></param>
        /// <param name="IsIgnoreModelNameCase">是否忽略Column Name大小寫</param>
        /// <returns></returns>
        public static T MappingSource<T>(this T model, Dictionary<string, Object> data, bool IsIgnoreModelNameCase = false)
        {
            var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var row in data)
            {
                var column = modelInfos.FirstOrDefault(o => (IsIgnoreModelNameCase ? o.Name?.ToUpper() == row.Key.ToString()?.ToUpper() : o.Name == row.Key.ToString()) );

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
                if (column.CanWrite)
                {
                    column.SetValue(model, rowValue);
                }
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
        /// 取出Model內的Field及 [Display(Name)]
        /// <code> source.GetFieldValue() </code>
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDisplayName<T>(this T model)
        {
            try
            {
                var result = typeof(T).GetProperties()
                    .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty);
                return result;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 取出Model內的Field及 [Display(Description)]
        /// <code> source.GetFieldValue() </code>
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDisplayDescription<T>(this T model)
        {
            try
            {
                var result = typeof(T).GetProperties()
                    .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DisplayAttribute>()?.Description ?? string.Empty);
                return result;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 取出Model內的Field及 [Description.Description]
        /// <code> source.GetFieldValue() </code>
        /// </summary>
        /// <typeparam name="T">Model 型態</typeparam>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldDescription<T>(this T model)
        {
            try
            {
                var result = typeof(T).GetProperties()
                    .ToDictionary(p => p.Name, p => p?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty);
                return result;
            }
            catch
            {
                throw;
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
        /// <param name="isIgnoreModelCase">是否忽略Column Name大小寫</param>
        /// <returns></returns>
        public static T CovertModel<T, TSource>(this T model, TSource data, bool isIgnoreModelCase = false)
        {
            return model.MappingSource(data.GetFieldValue(), isIgnoreModelCase);
        }


        #region Dictionary<string, object> To Model Class
        /// <summary>
        /// Dictionary&lt; string, object &gt; To Model&lt;T&gt;
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="dict">Dictionary</param>
        /// <returns></returns>
        public static T GetObject<T>(this Dictionary<string, object> dict)
        {
            return (T)GetObject(dict, typeof(T));
        }
        /// <summary>
        /// Dictionary&lt; string, object &gt; To Model&lt;T&gt;
        /// </summary>
        /// <param name="dict">Dictionary</param>
        /// <param name="type">T</param>
        /// <returns></returns>
        public static Object GetObject(this Dictionary<string, object> dict, Type type)
        {
            var obj = Activator.CreateInstance(type);
            foreach (var kv in dict)
            {
                var prop = type.GetProperty(kv.Key);
                if(prop == null) continue;
                object value = kv.Value;
                if (value is Dictionary<string, object>)
                {
                    value = GetObject((Dictionary<string, object>)value, prop.PropertyType);
                }
                prop.SetValue(obj, value, null);
            }
            return obj;
        }
        /// <summary>
        /// Dictionary To 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns>發生錯誤時候 回傳 default></returns>
        public static T DictionaryToModel<T>(this Dictionary<string, object> dict) where T : new()
        {
            T obj = new T();
            try
            {
                foreach (var item in dict)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(item.Key);
                    if (prop != null && prop.CanWrite)
                    {
                        Type propertType = prop.PropertyType;
                        //Type nullableType = GetNullableType(propertType);

                        if (item.Value == null || item.Value == DBNull.Value)
                        {
                            
                        }
                        else
                        {
                            //var value = Convert.ChangeType(item.Value, nullableType);
                            //prop.SetValue(obj, value, null);

                            if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                var value = Convert.ChangeType(item.Value, Nullable.GetUnderlyingType(prop.PropertyType));
                                prop.SetValue(obj, value, null);
                            }
                            else
                            {
                                var value = Convert.ChangeType(item.Value, prop.PropertyType);
                                prop.SetValue(obj, value, null);
                            }
                        }
                    }
                }
            }
            catch
            {
                obj = default;
            }
            return obj;
        }
        /// <summary>
        /// 取得轉換型態後的Type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetNullableType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return type;
            }

            if (type.IsValueType is false)
            {
                return type;
            }

            return Nullable.GetUnderlyingType(type);
        }

        #endregion



        #region Class 屬性 Description 轉 Dictionary<string, string>
        /// <summary>
        /// Model轉換 CLASS.Description轉成Dictionary(PROPERTY_NAME, PROPERTY_DESCRIPTION)，找不到相對應的Description皆會預設為string.Empoty
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns>(PROPERTY_NAME, PROPERTY_DESCRIPTION)</returns>
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
                .ToDictionary(p => p.Name, p => p.GetCustomAttributes(true).Count() > 0 ?  
                    (p.GetCustomAttributes(true).Any(x => x is DescriptionAttribute CM ) ? 
                        ((DescriptionAttribute)p.GetCustomAttributes(true).Where(x => x is DescriptionAttribute CM).FirstOrDefault()).Description : 
                        string.Empty ) : 
                string.Empty);
                return Dict;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Model轉換 CLASS.Display Name轉成Dictionary(PROPERTY_NAME, PROPERTY_Display Name)，找不到相對應的Display Name皆會預設為string.Empty
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns>(PROPERTY_NAME, PROPERTY_Display Name)</returns>
        public static Dictionary<string, string> GetClassDisplayNameDictionary<T>()
            where T : class
        {
            try
            {
                var Dict = new Dictionary<string, string>();
                Dict = typeof(T).GetProperties()
                .ToDictionary(p => p.Name, p => !string.IsNullOrWhiteSpace(p.GetCustomAttribute<DisplayAttribute>()?.Name) ? p.GetCustomAttribute<DisplayAttribute>().Name : string.Empty);
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

        /// <summary>
        /// 二個Model相比，是否有異動欄位
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">原本Model</param>
        /// <param name="data">比較Model</param>
        /// <returns></returns>
        public static bool IsModify<T>(this T model, T data)
        {
            var result = false;
            #region 
            //var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (var prop in typeof(T).GetProperties())
            //{
            //    var modelValue = typeof(T).GetProperties()
            //        .Where(o => o.Name == prop.Name)
            //        .ToDictionary(p => p.Name, p => p.GetValue(model)).FirstOrDefault().Value;
            //    var dataValue = typeof(T).GetProperties()
            //        .Where(o => o.Name == prop.Name)
            //        .ToDictionary(p => p.Name, p => p.GetValue(data)).FirstOrDefault().Value;

            //    switch(prop.PropertyType.ToString().ToString().Split('.').Last().TrimEnd(']'))
            //    {
            //        case "Int32":
            //        case "Decimal":
            //        case "Single":
            //        case "Double":
            //            if (modelValue == null && dataValue != null)
            //            {
            //                return true;

            //            }
            //            else if (modelValue != null && dataValue == null)
            //            {
            //                return true;

            //            }
            //            else if(modelValue != null && dataValue != null
            //                && (double.Parse(modelValue?.ToString()) != double.Parse(dataValue?.ToString())))
            //            {
            //                return true;
            //            }

            //            break;
            //        case "DateTime":
            //            if (modelValue == null && dataValue != null)
            //            {
            //                return true;

            //            }
            //            else if (modelValue != null && dataValue == null)
            //            {
            //                return true;

            //            }
            //            else if (modelValue != null && dataValue != null
            //                && (((DateTime)modelValue).ToFullDateTime() != ((DateTime)dataValue).ToFullDateTime()))
            //            {
            //                return true;
            //            }
            //            break;
            //        default:
            //            if (modelValue?.ToString() != dataValue?.ToString())
            //            {
            //                return true;
            //            }

            //            break;
            //    }
            //}
            #endregion 

            var modifyResult = model.ModifyList(data);

            if (modifyResult.Any())
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 取得修改清單(IDictionary&lt;string, object&gt;使用)
        /// </summary>
        /// <typeparam name="T">IDictionary&lt;string, object&gt;</typeparam>
        /// <param name="model">原始資料Dictionary</param>
        /// <param name="data">修改資料Dictionary</param>
        /// <param name="modelColumnType">Dictionary對照表[Key=ColumnName,Value=Oracle Column_Data_Type]</param>
        /// <returns></returns>
        public static ServiceResult<List<(string Column, string ChangeNote)>> ModifyDictioary<T>(this T model, T data, Dictionary<string, string> modelColumnType)
            where T : class
        {
            ServiceResult<List<(string Column, string ChangeNote)>> returnResult = new ServiceResult<List<(string Column, string ChangeNote)>>(false, string.Empty, new List<(string Column, string ChangeNote)>());
            try
            {
                IDictionary<string, object> modelSource = null;
                IDictionary<string, object> dataSource = null;
                try
                {
                    modelSource = model as IDictionary<string, object>;
                    dataSource = data as IDictionary<string, object>;
                }
                catch(Exception ex)
                {
                    var InnerEx = ex.GetInnerException();
                    returnResult.Message += "Dictionary資料陣列轉換失敗[THROW]:" + InnerEx.ErrorMessage + Environment.NewLine;
                    returnResult.Exception = ex;
                }
                List<(string ColumnName, object ColumnValue, OracleDbType DbType)> modelInfoList = new List<(string, object, OracleDbType)>();
                List<(string ColumnName, object ColumnValue, OracleDbType DbType)> dataInfoList = new List<(string, object, OracleDbType)>();

                if (modelSource != null)
                {
                    foreach (KeyValuePair<string, object> item in modelSource)
                    {
                        if (modelColumnType != null && modelColumnType.Any(x => x.Key == item.Key))
                        {
                            modelInfoList.Add((item.Key, item.Value, modelColumnType.FirstOrDefault(x => x.Key == item.Key).Value.GetOracleDbType()));
                        }
                    }
                }
                if (dataSource != null)
                {
                    foreach (KeyValuePair<string, object> item in dataSource)
                    {
                        if (modelColumnType != null && modelColumnType.Any(x => x.Key == item.Key))
                        {
                            dataInfoList.Add((item.Key, item.Value, modelColumnType.FirstOrDefault(x => x.Key == item.Key).Value.GetOracleDbType()));
                        }
                    }
                }
                foreach (var modelItem in modelInfoList)
                {
                    var dataItem = dataInfoList.Any(x => x.ColumnName == modelItem.ColumnName) ?
                        dataInfoList.FirstOrDefault(x => x.ColumnName == modelItem.ColumnName) : (string.Empty, null, OracleDbType.Varchar2);
                    // Inference of DbType, OracleDbType, and .NET Types
                    // https://docs.oracle.com/cd/B19306_01/win.102/b14307/featOraCommand.htm#i1007432
                    //.Net 資料庫 型態轉換 點部落
                    //http://webcache.googleusercontent.com/search?q=cache:QXFyG3VQ2h4J:https://www.dotblogs.com.tw/timothy/2014/06/11/145500&sca_esv=569007408&hl=zh-TW&gl=tw&strip=1&vwsrc=0
                    if (!string.IsNullOrWhiteSpace(modelItem.ColumnName))
                    {
                        switch (modelItem.DbType) 
                        {
                            case OracleDbType.Varchar2:
                            case OracleDbType.NVarchar2:
                            case OracleDbType.Char:
                            case OracleDbType.NChar:
                            case OracleDbType.NClob:
                            case OracleDbType.Long:
                            case OracleDbType.XmlType:
                                var modelValueString = modelItem.ColumnValue as String;
                                var dataValueString = dataItem.ColumnValue as String;
                                if (string.IsNullOrEmpty(modelValueString) && string.IsNullOrEmpty(dataValueString) == false)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueString?.ToString()}"));
                                }
                                else if (string.IsNullOrEmpty(modelValueString) == false && string.IsNullOrEmpty(dataValueString))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueString?.ToString()} → Null"));
                                }
                                else if (string.IsNullOrEmpty(modelValueString) == false && string.IsNullOrEmpty(dataValueString) == false && (modelValueString != dataValueString))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueString?.ToString()} → {dataValueString?.ToString()}"));
                                }
                                break;
                            case OracleDbType.Date:
                            case OracleDbType.TimeStamp:
                            case OracleDbType.TimeStampLTZ:
                            case OracleDbType.TimeStampTZ:
                                var modelValueDateTime = modelItem.ColumnValue as DateTime?;
                                var dataValueDateTime = dataItem.ColumnValue as DateTime?;
                                if (modelValueDateTime.HasValue == false && dataValueDateTime.HasValue)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDateTime?.ToString()}"));
                                }
                                else if (modelValueDateTime.HasValue && dataValueDateTime.HasValue == false)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDateTime?.ToString()} → Null"));
                                }
                                else if (modelValueDateTime.HasValue && dataValueDateTime.HasValue && (modelValueDateTime.Value.ToFullDateTimeMillisecond() != dataValueDateTime.Value.ToFullDateTimeMillisecond()))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDateTime.Value.ToFullDateTimeMillisecond()} → {dataValueDateTime.Value.ToFullDateTimeMillisecond()}"));
                                }
                                break;
                            case OracleDbType.Decimal:
                                var modelValueDecimal = modelItem.ColumnValue as Decimal?;
                                var dataValueDecimal = dataItem.ColumnValue as Decimal?;
                                if (modelValueDecimal == null && dataValueDecimal != null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDecimal?.ToString()}"));
                                }
                                else if (modelValueDecimal != null && dataValueDecimal == null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDecimal?.ToString()} → Null"));
                                }
                                else if (modelValueDecimal != null && dataValueDecimal != null && (modelValueDecimal != dataValueDecimal))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDecimal?.ToString()} → {dataValueDecimal?.ToString()}"));
                                }
                                break;
                            case OracleDbType.BinaryDouble:
                            case OracleDbType.Double:
                                if (modelItem.ColumnValue as Double? == null && dataItem.ColumnValue as Double? == null)
                                {
                                    var modelValueDouble = modelItem.ColumnValue as decimal?;
                                    var dataValueDouble = dataItem.ColumnValue as decimal?;
                                    if (modelValueDouble == null && dataValueDouble != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDouble?.ToString()}"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → Null"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble != null && (modelValueDouble != dataValueDouble))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → {dataValueDouble?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueDouble = modelItem.ColumnValue as Double?;
                                    var dataValueDouble = dataItem.ColumnValue as Double?;
                                    if (modelValueDouble == null && dataValueDouble != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueDouble?.ToString()}"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → Null"));
                                    }
                                    else if (modelValueDouble != null && dataValueDouble != null && (modelValueDouble != dataValueDouble))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueDouble?.ToString()} → {dataValueDouble?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.BinaryFloat:
                            case OracleDbType.Single:
                                //如果轉換Float失敗則改轉換成Decimal
                                if(modelItem.ColumnValue as float? == null && dataItem.ColumnValue as float? == null)
                                {
                                    var modelValueFloat = modelItem.ColumnValue as decimal?;
                                    var dataValueFloat = dataItem.ColumnValue as decimal?;
                                    if (modelValueFloat == null && dataValueFloat != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueFloat?.ToString()}"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → Null"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat != null && (modelValueFloat != dataValueFloat))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → {dataValueFloat?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueFloat = modelItem.ColumnValue as float?;
                                    var dataValueFloat = dataItem.ColumnValue as float?;
                                    if (modelValueFloat == null && dataValueFloat != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueFloat?.ToString()}"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → Null"));
                                    }
                                    else if (modelValueFloat != null && dataValueFloat != null && (modelValueFloat != dataValueFloat))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueFloat?.ToString()} → {dataValueFloat?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Int16:
                                if (modelItem.ColumnValue as Int16? == null && dataItem.ColumnValue as Int16? == null)
                                {
                                    var modelValueInt16 = modelItem.ColumnValue as decimal?;
                                    var dataValueInt16 = dataItem.ColumnValue as decimal?;
                                    if (modelValueInt16 == null && dataValueInt16 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt16?.ToString()}"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 != null && (modelValueInt16 != dataValueInt16))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → {dataValueInt16?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueInt16 = modelItem.ColumnValue as Int16?;
                                    var dataValueInt16 = dataItem.ColumnValue as Int16?;
                                    if (modelValueInt16 == null && dataValueInt16 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt16?.ToString()}"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt16 != null && dataValueInt16 != null && (modelValueInt16 != dataValueInt16))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt16?.ToString()} → {dataValueInt16?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Int32:
                                if (modelItem.ColumnValue as Double? == null && dataItem.ColumnValue as Double? == null)
                                {
                                    var modelValueInt32 = modelItem.ColumnValue as decimal?;
                                    var dataValueInt32 = dataItem.ColumnValue as decimal?;
                                    if (modelValueInt32 == null && dataValueInt32 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt32?.ToString()}"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 != null && (modelValueInt32 != dataValueInt32))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → {dataValueInt32?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueInt32 = modelItem.ColumnValue as Int32?;
                                    var dataValueInt32 = dataItem.ColumnValue as Int32?;
                                    if (modelValueInt32 == null && dataValueInt32 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt32?.ToString()}"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt32 != null && dataValueInt32 != null && (modelValueInt32 != dataValueInt32))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt32?.ToString()} → {dataValueInt32?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Int64:
                                if (modelItem.ColumnValue as Double? == null && dataItem.ColumnValue as Double? == null)
                                {
                                    var modelValueInt64 = modelItem.ColumnValue as decimal?;
                                    var dataValueInt64 = dataItem.ColumnValue as decimal?;
                                    if (modelValueInt64 == null && dataValueInt64 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt64?.ToString()}"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 != null && (modelValueInt64 != dataValueInt64))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → {dataValueInt64?.ToString()}"));
                                    }
                                }
                                else
                                {
                                    var modelValueInt64 = modelItem.ColumnValue as Int64?;
                                    var dataValueInt64 = dataItem.ColumnValue as Int64?;
                                    if (modelValueInt64 == null && dataValueInt64 != null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueInt64?.ToString()}"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 == null)
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → Null"));
                                    }
                                    else if (modelValueInt64 != null && dataValueInt64 != null && (modelValueInt64 != dataValueInt64))
                                    {
                                        returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueInt64?.ToString()} → {dataValueInt64?.ToString()}"));
                                    }
                                }
                                break;
                            case OracleDbType.Boolean:
                                var modelValueBool = modelItem.ColumnValue as Boolean?;
                                var dataValueBool = dataItem.ColumnValue as Boolean?;
                                if (modelValueBool == null && dataValueBool != null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueBool?.ToString()}"));
                                }
                                else if (modelValueBool != null && dataValueBool == null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueBool?.ToString()} → Null"));
                                }
                                else if (modelValueBool != null && dataValueBool != null && (modelValueBool != dataValueBool))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueBool?.ToString()} → {dataValueBool?.ToString()}"));
                                }
                                break;
                            case OracleDbType.Byte:
                                //暫時不知道該如何呈現~故直接轉換成object輸出
                            case OracleDbType.LongRaw:
                            case OracleDbType.BFile:
                            case OracleDbType.Clob:
                            case OracleDbType.Raw:
                            case OracleDbType.RefCursor:
                            default:
                                var modelValueObject = modelItem.ColumnValue;
                                var dataValueObject = dataItem.ColumnValue;
                                if (modelValueObject == null && dataValueObject != null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"Null → {dataValueObject?.ToString()}"));
                                }
                                else if (modelValueObject != null && dataValueObject == null)
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueObject?.ToString()} → Null"));
                                }
                                else if (modelValueObject != null && dataValueObject != null && (modelValueObject != dataValueObject))
                                {
                                    returnResult.Data.Add((modelItem.ColumnName, $@"{modelValueObject?.ToString()} → {dataValueObject?.ToString()}"));
                                }
                                break;
                        }
                    }
                }
                if (modelSource != null && dataSource != null && modelColumnType != null && modelInfoList.Any())
                {
                    returnResult.IsOk = true;
                    returnResult.Message += $"原始資料總數[{modelInfoList.Count}]" + Environment.NewLine +
                        $"修改資料總數[{modelInfoList.Count}]" + Environment.NewLine +
                        $"Dictionary對照表總數[{modelColumnType.Count}]" + Environment.NewLine +
                        $"全部資料比對完成.";
                }
                else
                {
                    returnResult.IsOk = false;
                    returnResult.Message += modelSource == null ? $"[原始資料陣列為Null]" + Environment.NewLine : string.Empty;
                    returnResult.Message += dataSource == null ? $"[修改資料陣列為Null]" + Environment.NewLine : string.Empty;
                    returnResult.Message += modelColumnType == null ? $"[修改資料陣列為Null]" + Environment.NewLine : string.Empty;
                }
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                returnResult.Exception = ex;
                returnResult.Message += "[THROW]:" + ex.Message + Environment.NewLine ;
            }
            return returnResult;
        }

        /// <summary>
        /// 取得修改清單(List)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">原始資料</param>
        /// <param name="data">修改資料</param>
        /// <returns></returns>
        public static List<(string Column, string ChangeNote, string ColumnDisplayName)> ModifyList<T>(this T model, T data)
        {
            var resultData = new List<(string Column, string ChangeNote, string ColumnDisplayName)>();

            try
            {
                var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in typeof(T).GetProperties())
                {
                    var modelValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(model)).FirstOrDefault().Value;
                    var dataValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(data)).FirstOrDefault().Value;

                    var modelDisplayName = prop.GetCustomAttribute<DisplayAttribute>()?.Name ?? prop.Name;

                    switch (prop.PropertyType.ToString().ToString().Split('.').Last().TrimEnd(']'))
                    {
                        case "Int32":
                        case "Decimal":
                        case "Single":
                        case "Double":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {dataValue?.ToString()}", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → Null", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue != null
                                && (double.Parse(modelValue?.ToString()) != double.Parse(dataValue?.ToString())))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → {dataValue?.ToString()}", modelDisplayName));
                            }

                            break;
                        case "DateTime":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → Null", modelDisplayName));
                            }
                            else if (modelValue != null && dataValue != null
                                && (((DateTime)modelValue).ToFullDateTime() != ((DateTime)dataValue).ToFullDateTime()))
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName));
                            }
                            break;
                        default:
                            if (modelValue?.ToString() != dataValue?.ToString() &&( string.IsNullOrWhiteSpace(modelValue?.ToString()) == false || string.IsNullOrWhiteSpace(dataValue?.ToString()) == false))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString() ?? "Null"} → {dataValue?.ToString() ?? "Null"}", modelDisplayName));
                            }

                            break;
                    }
                }

                return resultData;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取得修改清單(List)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">原始資料</param>
        /// <param name="data">修改資料</param>
        /// <returns>List&lt;(string Column, string ChangeNote, string ColumnDisplayName, object SourceValue, object ModifyValue)&gt;</returns>
        public static List<(string Column, string ChangeNote, string ColumnDisplayName, object SourceValue, object ModifyValue)> ModifyList_Extract<T>(this T model, T data)
        {
            var resultData = new List<(string Column, string ChangeNote, string ColumnDisplayName, object SourceValue, object ModifyValue)>();

            try
            {
                var modelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in typeof(T).GetProperties())
                {
                    var modelValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(model)).FirstOrDefault().Value;
                    var dataValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(data)).FirstOrDefault().Value;

                    var modelDisplayName = prop.GetCustomAttribute<DisplayAttribute>()?.Name ?? prop.Name;

                    switch (prop.PropertyType.ToString().ToString().Split('.').Last().TrimEnd(']'))
                    {
                        case "Int32":
                        case "Decimal":
                        case "Single":
                        case "Double":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {dataValue?.ToString()}", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → Null", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue != null
                                && (double.Parse(modelValue?.ToString()) != double.Parse(dataValue?.ToString())))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString()} → {dataValue?.ToString()}", modelDisplayName, modelValue, dataValue));
                            }

                            break;
                        case "DateTime":
                            if (modelValue == null && dataValue != null)
                            {
                                resultData.Add((prop.Name, $@"Null → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue == null)
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → Null", modelDisplayName, modelValue, dataValue));
                            }
                            else if (modelValue != null && dataValue != null
                                && (((DateTime)modelValue).ToFullDateTime() != ((DateTime)dataValue).ToFullDateTime()))
                            {
                                //return true;
                                resultData.Add((prop.Name, $@"{((DateTime)modelValue).ToFullDateTime()} → {((DateTime)dataValue).ToFullDateTime()}", modelDisplayName, modelValue, dataValue));
                            }
                            break;
                        default:
                            if (modelValue?.ToString() != dataValue?.ToString() && (string.IsNullOrWhiteSpace(modelValue?.ToString()) == false || string.IsNullOrWhiteSpace(dataValue?.ToString()) == false))
                            {
                                resultData.Add((prop.Name, $@"{modelValue?.ToString() ?? "Null"} → {dataValue?.ToString() ?? "Null"}", modelDisplayName, modelValue, dataValue));
                            }

                            break;
                    }
                }

                return resultData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改清單
        /// </summary>
        /// <typeparam name="TKey">string</typeparam>
        /// <typeparam name="TValue">object</typeparam>
        /// <param name="model">原始</param>
        /// <param name="data">修改</param>
        /// <returns></returns>
        public static ServiceResult<List<(string Column, string ChangeNote, string ColumnDisplayName)>> ModifyDic_Interface<TKey, TValue>(
            this Dictionary<TKey, TValue> model,
            Dictionary<TKey, TValue> data)
        {
            ServiceResult<List<(string Column, string ChangeNote, string ColumnDisplayName)>> returnResult = 
                new ServiceResult<List<(string Column, string ChangeNote, string ColumnDisplayName)>>
                (false, string.Empty, new List<(string Column, string ChangeNote, string ColumnDisplayName)>()); ;
            try
            {
                var result = model.ModifyDic(data);
                if(result != null)
                {
                    returnResult.Data.AddRange(result);
                    returnResult.IsOk = true;
                }
                else
                {
                    returnResult.Message += "修改清單回傳Null";
                }
            }
            catch(Exception ex)
            {
                returnResult.IsOk = false;
                var errorException = ex.GetInnerException(); 
                returnResult.Message += "[THROW]:" + errorException.ErrorMessage + Environment.NewLine;
                returnResult.Exception = ex;
            }
            return returnResult;
        }

        /// <summary>
        /// 取得修改清單
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="model">原始</param>
        /// <param name="data">修改</param>
        /// <returns></returns>
        public static List<(string Column, string ChangeNote, string ColumnDisplayName)> ModifyDic<TKey, TValue>(
            this Dictionary<TKey, TValue> model,
            Dictionary<TKey, TValue> data)
        {
            var resultData = new List<(string Column, string ChangeNote, string ColumnDisplayName)>();

            try
            {
                foreach (var key in model.Keys)
                {
                    if (!data.TryGetValue(key, out TValue dataValue))
                        continue;

                    var modelValue = model[key];

                    if (modelValue == null && dataValue != null)
                    {
                        resultData.Add((key.ToString(), $@"Null → {dataValue?.ToString()}", key.ToString()));
                    }
                    else if (modelValue != null && dataValue == null)
                    {
                        resultData.Add((key.ToString(), $@"{modelValue?.ToString()} → Null", key.ToString()));
                    }
                    else if (modelValue != null && dataValue != null && !modelValue.Equals(dataValue))
                    {
                        resultData.Add((key.ToString(), $@"{modelValue?.ToString()} → {dataValue?.ToString()}", key.ToString()));
                    }
                }

                return resultData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 二個Model相比，返回有異動欄位的Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SourceModel">原始Model</param>
        /// <param name="Data">欲比較之Model</param>
        /// <returns></returns>
        private static ServiceResult<Dictionary<string, object>> IsModifyDictionary<T>(this T SourceModel, T Data)
        {
            ServiceResult<Dictionary<string, object>> ReturnResult = new ServiceResult<Dictionary<string, object>>(true, string.Empty, new Dictionary<string, object>());
            try
            {
                Regex stringRegex = new Regex("string");
                Regex datetimeRegex = new Regex("datetime");
                Regex singleRegex = new Regex("single");
                Regex doubleRegex = new Regex("double");
                Regex decimalRegex = new Regex("decimal");
                Regex intRegex = new Regex("int");
                var SourceModelInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var prop in SourceModelInfos)
                {
                    var sourceValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(SourceModel)).FirstOrDefault().Value?.ToString();
                    var dataValue = typeof(T).GetProperties()
                        .Where(o => o.Name == prop.Name)
                        .ToDictionary(p => p.Name, p => p.GetValue(Data)).FirstOrDefault().Value;
                    Type dataValueType = dataValue?.GetType();
                        //typeof(T).GetProperties()
                        //.Where(o => o.Name == prop.Name)
                        //.ToDictionary(p => p.Name, p => p.GetValue(Data)).FirstOrDefault().Value?.GetType();
                    if (sourceValue != dataValue?.ToString())
                    {
                        if (stringRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as String);
                        }
                        else if (datetimeRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as DateTime?);
                        }
                        else if (singleRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Single?);
                        }
                        else if (doubleRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Double?);
                        }
                        else if (decimalRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Decimal?);
                        }
                        else if (intRegex.IsMatch(dataValueType?.FullName?.ToLower() ?? string.Empty))
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue as Int32?);
                        }
                        else
                        {
                            ReturnResult.Data.Add(prop.Name, dataValue);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ReturnResult.IsOk = false;
                ReturnResult.Message = "Throw:" + ex.Message;
            }
            return ReturnResult;
        }

        public static string Display(this IEnumerable<string> Source,bool newline = true)
        {
            string result = "";

            foreach (string item in Source)
            {
                result += $"【{item}】";
                if (newline)
                    result += Environment.NewLine;
            }

            return result;
        }
    }
}
