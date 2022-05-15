using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NovelDownloader.Library
{
    public class NovelUtility
    {
        private DesktopAlertUtil _desktopAlertUtil = new DesktopAlertUtil();

        /// <summary>
        /// RadMessageBox樣式設定
        /// </summary>
        /// <param name="size">字體大小</param>
        public void radMsgboxFont(int? FontSize = null, int? ButtonSize = null, int? DetailFontSize = null)        //radMessageBox.show樣式設定, 可傳入int設定
        {
            float fontsize = float.Parse((FontSize != null ? FontSize.Value : 13).ToString());
            float buttonsize = float.Parse((ButtonSize != null ? ButtonSize.Value : 13).ToString());
            float detailsize = float.Parse((DetailFontSize != null ? DetailFontSize.Value : 13).ToString());
            if (RadMessageBox.Instance != null)
            {
                RadMessageBox.Instance.ThemeName = "ControlDefault";
                RadMessageBox.Instance.FormElement.TitleBar.Font = new Font(FontsProxy.Fonts[0], 12, FontStyle.Regular);//變更TitleBar 字大小
                RadMessageBox.Instance.Controls["radLabel1"].Font = new Font(FontsProxy.Fonts[0], fontsize, FontStyle.Regular);
                RadMessageBox.Instance.Controls["radButton1"].Font = new Font(FontsProxy.Fonts[0], buttonsize, FontStyle.Regular);
                RadMessageBox.Instance.Controls["radButton2"].Font = new Font(FontsProxy.Fonts[0], buttonsize, FontStyle.Regular);
                RadMessageBox.Instance.Controls["radButton3"].Font = new Font(FontsProxy.Fonts[0], buttonsize, FontStyle.Regular);
                RadMessageBox.Instance.Controls["radButtonDetails"].Font = new Font(FontsProxy.Fonts[0], buttonsize, FontStyle.Regular);
                RadMessageBox.Instance.Controls["radButtonDetails"].Size = new Size(110, 27);
                RadMessageBox.Instance.Controls["radTextBoxDetials"].Font = new Font(FontsProxy.Fonts[0], detailsize, FontStyle.Regular);
                RadMessageBox.Instance.AutoScaleMode = AutoScaleMode.None;
                RadMessageBox.Instance.TopMost = true;
            }
        }

        #region 抓取該Control全域中的所有Type
        /// <summary>
        /// 抓取該 Form 全域 Control
        /// </summary>
        /// <param name="control">欲抓取的Control(Ex:this)</param>
        /// <param name="type">欲抓取的Type(Ex:typeof(Button))</param>
        /// <returns></returns>
        public IEnumerable<Control> GetAllControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControl(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }
        #endregion
        /// <summary>
        /// 回傳輸入的Font
        /// </summary>
        /// <param name="FontSizeFloat">字體大小(預設12f)</param>
        /// <param name="IsBold">是否為粗體(預設否)</param>
        /// <returns></returns>
        public Font SetFontSize(float FontSizeFloat = 12f, bool IsBold = false)
        {
            if (IsBold)
            {
                return new Font(FontsProxy.Fonts[0], FontSizeFloat, FontStyle.Bold);
            }
            else
            {
                return new Font(FontsProxy.Fonts[0], FontSizeFloat, FontStyle.Regular);
            }

        }
        /// <summary>
        /// 設定所有Control Font (預設12f)
        /// </summary>
        /// <param name="form_">FORM</param>
        /// <param name="SetFont">字型大小(預設12f)</param>
        /// <param name="ThemeName">主題名稱(預設ControlDefault)</param>
        public void SetControlFont(Form form_, float SetFont = 12f, string ThemeName = "ControlDefault")
        {
            //TimeSpan Start, End;
            //Start = TimeSpan.FromTicks(DateTime.Now.Ticks);
            //string ThemeName = "ControlDefault";
            Font Fonts = SetFontSize(SetFont);
            foreach (RadLabel itemLabel in GetAllControl(form_, typeof(RadLabel)))
            {
                if (itemLabel.Name == "radLabel_MainTitle")
                {
                    itemLabel.Font = SetFontSize(26f);
                    itemLabel.ThemeName = ThemeName;
                }
                else
                {
                    itemLabel.Font = Fonts;
                    itemLabel.ThemeName = ThemeName;
                }

            }
            foreach (RadButton itemButton in GetAllControl(form_, typeof(RadButton)))
            {
                itemButton.Font = Fonts;
                itemButton.ThemeName = ThemeName;
            }
            foreach (RadTextBox itemTextBox in GetAllControl(form_, typeof(RadTextBox)))
            {
                itemTextBox.Font = Fonts;
                itemTextBox.ThemeName = ThemeName;
            }
            foreach (RadTextBoxControl itemTextBoxControl in GetAllControl(form_, typeof(RadTextBoxControl)))
            {
                itemTextBoxControl.Font = Fonts;
                itemTextBoxControl.ThemeName = ThemeName;
            }
            foreach (RadDropDownList itemRDDL in GetAllControl(form_, typeof(RadDropDownList)))
            {
                itemRDDL.Font = Fonts;
                itemRDDL.ListElement.Font = Fonts;
                itemRDDL.DropDownListElement.Font = Fonts;
                itemRDDL.ThemeName = ThemeName;
            }
            foreach (RadMultiColumnComboBox itemRMCCB in GetAllControl(form_, typeof(RadMultiColumnComboBox)))
            {
                itemRMCCB.Font = Fonts;
                itemRMCCB.MultiColumnComboBoxElement.TextboxContentElement.Font = Fonts;
                itemRMCCB.MultiColumnComboBoxElement.TextBoxElement.Font = Fonts;
                itemRMCCB.EditorControl.TableElement.Font = Fonts;  //下拉選單Font Size
                itemRMCCB.ThemeName = ThemeName;
            }

            foreach (RadRadioButton itemRadioButton in GetAllControl(form_, typeof(RadRadioButton)))
            {
                itemRadioButton.Font = Fonts;
                itemRadioButton.ThemeName = ThemeName;
            }
            foreach (RadGridView itemGridView in GetAllControl(form_, typeof(RadGridView)))
            {
                itemGridView.Font = Fonts;
                itemGridView.ThemeName = ThemeName;
            }
            foreach (RadGroupBox itemGroupBox in GetAllControl(form_, typeof(RadGroupBox)))
            {
                itemGroupBox.Font = Fonts;
                itemGroupBox.GroupBoxElement.Header.Font = Fonts;
                itemGroupBox.GroupBoxElement.Content.Font = Fonts;
                itemGroupBox.ThemeName = ThemeName;
            }
            foreach (RadCheckBox itemCheckBox in GetAllControl(form_, typeof(RadCheckBox)))
            {
                itemCheckBox.Font = Fonts;
                itemCheckBox.ThemeName = ThemeName;
            }
            foreach (RadPageView itemPageView in GetAllControl(form_, typeof(RadPageView)))
            {
                itemPageView.Font = Fonts;
                foreach (RadPageViewPage itemPageViewPage in itemPageView.Pages)
                {
                    itemPageViewPage.Font = Fonts;
                }
                //itemPageViewPage.ThemeName = ThemeName;
            }

            //End = TimeSpan.FromTicks(DateTime.Now.Ticks);
            //TimeDifferent(Start, End, true);
        }

        #region 使用 RNGCryptoServiceProvider 產生由密碼編譯服務供應者 (CSP) 提供的亂數產生器。
        private static RNGCryptoServiceProvider rngp = new RNGCryptoServiceProvider();
        private static byte[] rb = new byte[4];
        /// <summary>
        /// 產生一個非負數的亂數
        /// </summary>
        public static int Next()
        {
            rngp.GetBytes(rb);
            int value = BitConverter.ToInt32(rb, 0);
            if (value < 0) value = -value;
            return value;
        }
        /// <summary>
        /// 產生一個非負數且最大值 max 以下的亂數
        /// </summary>
        /// <param name="max">最大值</param>
        public static int Next(int max)
        {
            rngp.GetBytes(rb);
            int value = BitConverter.ToInt32(rb, 0);
            value = value % (max + 1);
            if (value < 0) value = -value;
            return value;
        }
        /// <summary>
        /// 產生一個非負數且最小值在 min 以上最大值在 max 以下的亂數
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public static int Next(int min, int max)
        {
            int value = Next(max - min) + min;
            return value;
        }
        /// <summary>
        /// 隨機字串產生器(不含符號)
        /// </summary>
        /// <param name="strLength">字串長度</param>
        /// <returns></returns>
        public string RandomStr(int strLength)
        {
            if (strLength > 0)
            {
                StringBuilder sb = new StringBuilder();
                char[] chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                int length = Next(strLength, strLength);
                for (int i = 0; i < length; i++)
                {
                    sb.Append(chars[Next(chars.Length - 1)]);
                }
                return sb.ToString();
            }
            else
            {
                RadMessageBox.Show("產生字串長度需要大於0!", "RNG亂數產生器", MessageBoxButtons.OK, RadMessageIcon.Error);
                return "";
            }
        }
        public int RandomNext(int min, int max)
        {
            int value = Next(max - min) + min;
            return value;
        }
        #endregion

        #region C# 正則表達式 過濾特殊字符，保留中文，字母，數字，和-
        /// <summary>
        /// 自訂過濾條件
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string FilterChar(string inputValue, string Filter)
        {
            byte[] bytArray = System.Text.Encoding.Default.GetBytes(Filter);
            for (int index = 0; index < bytArray.Length; index++)
            {
                string Strbuf = string.Format("{0}", (char)bytArray[index]);
                inputValue = inputValue.Replace(Strbuf, "");
            }
            return inputValue;
        }
        /// <summary>
        /// 取得過濾條件[A-Za-z0-9\u4e00-\u9fa5-]
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string FilterChar(string inputValue)
        {
            // return Regex.Replace(inputValue, "[`~!@#$^&*()=|{}‘:;‘,\\[\\].<>/?~！@#￥……&*（）&mdash;|{}【】；‘’，。/*-+]+", "", RegexOptions.IgnoreCase);
            if (Regex.IsMatch(inputValue, "[A-Za-z0-9\u4e00-\u9fa5-]+"))
            {
                return Regex.Match(inputValue, "[A-Za-z0-9\u4e00-\u9fa5-]+").Value; //取得A-Z,a-z,0-9,unicode編碼[\u4e00-\u9fa5]指中文範圍
            }
            return "";
        }
        #endregion

        #region Read Write TXT File 
        /// <summary>
        /// 刪除TXT
        /// </summary>
        /// <param name="FilePath">檔案路徑 EX:[C:\TSGH\ABC.txt]</param>
        public void TXT_Delete(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 寫入TXT
        /// </summary>
        /// <param name="FilePath">寫入之檔案路徑 EX:"C:\TSGH\"</param>
        /// <param name="FileName">檔案名稱 Ex:"ABC.txt"</param>
        /// <param name="WriteContent">寫入之內容</param>
        /// <param name="DeleteFileWhenExist">當檔案存在時候，是否先刪除在寫入[Default:true]</param>
        /// <param name="AppendMode">TXT寫入模式</param>
        /// <returns></returns>
        public bool TXT_WriteString(string FilePath, string FileName, string WriteContent, bool DeleteFileWhenExist = true, bool AppendMode = false)
        {
            try
            {
                var FullFilePath = FilePath + FileName;
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                if (DeleteFileWhenExist)
                {
                    if (File.Exists(FullFilePath))
                    {
                        File.Delete(FullFilePath);
                    }
                }
                if (!string.IsNullOrEmpty(WriteContent))
                {
                    using (StreamWriter sw = new StreamWriter(FullFilePath, AppendMode, Encoding.UTF8))
                    {
                        sw.WriteLine(WriteContent);

                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 寫入TXT
        /// </summary>
        /// <param name="FilePath">寫入之檔案路徑 EX:"C:\TSGH\"</param>
        /// <param name="FileName">檔案名稱 Ex:"ABC.txt"</param>
        /// <param name="WriteContent">寫入之內容</param>
        /// <param name="DeleteFileWhenExist">當檔案存在時候，是否先刪除在寫入[Default:true]</param>
        /// <param name="AppendMode">TXT寫入模式</param>
        /// <returns></returns>
        public bool TXT_WriteStringArray(string FilePath, string FileName, string[] WriteContent, bool DeleteFileWhenExist = true, bool AppendMode = false)
        {
            try
            {
                var FullFilePath = FilePath + FileName;
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                if (DeleteFileWhenExist)
                {
                    if (File.Exists(FullFilePath))
                    {
                        File.Delete(FullFilePath);
                    }
                }
                if (WriteContent != null)
                {

                    using (StreamWriter sw = new StreamWriter(FullFilePath, AppendMode, Encoding.UTF8))
                    {
                        foreach (string item in WriteContent)
                        {
                            sw.WriteLine(item);
                        }
                    }

                    //File.WriteAllLines(FullFilePath, WriteContent, Encoding.UTF8);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
       

        /// <summary>
        /// 讀取TXT
        /// </summary>
        /// <param name="FilePath">讀取檔案路徑</param>
        /// <returns></returns>
        public string TXT_ReadString(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return File.ReadAllText(FilePath);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 讀取TXT
        /// </summary>
        /// <param name="FilePath">讀取檔案路徑</param>
        /// <returns></returns>
        public string[] TXT_ReadStringArray(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return File.ReadAllLines(FilePath);
                }
                else
                {
                    return new string[0] { };
                }
            }
            catch
            {
                throw;
            }
        }


        #endregion

        #region Class 屬性 Description 轉 Dictionary<string, string>
        /// <summary>
        /// Class.Property 轉成Dictionary<PROPERTY_NAME, PROPERTY_DESCRIPTION>
        /// </summary>
        /// <typeparam name="T">CLASS</typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> GetDictionary<T>()
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
        #endregion


    }
}
