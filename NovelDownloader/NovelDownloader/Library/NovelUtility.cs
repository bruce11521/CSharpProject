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
using Telerik.WinControls.FileDialogs;
using Telerik.WinControls.Localization;
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
                RadMessageLocalizationProvider.CurrentProvider = new ResetRadMessageBoxLocalizationProvider();
                RadMessageBox.Instance.AutoScaleMode = AutoScaleMode.None;
                RadMessageBox.Instance.TopMost = true;
            }
        }

        #region RadButton Localization 
        /// <summary>
        /// RadMessagebox Button 文字
        /// </summary>
        public class RadMessageBoxLocalizationText
        {
            public RadMessageBoxLocalizationText()
            {
                YES = "是";
                NO = "否";
                OK = "確認";
                CANCEL = "取消";
                RETRY = "重試";
                IGNORE = "忽略";
                ABORT = "放棄";
                DETAILS = "詳細資訊";
            }
            public string YES { get; set; }
            public string NO { get; set; }
            public string OK { get; set; }
            public string CANCEL { get; set; }
            public string RETRY { get; set; }
            public string ABORT { get; set; }
            public string IGNORE { get; set; }
            public string DETAILS { get; set; }
        }
        public class ManualRadMessageBoxLocalizationProvider : RadMessageLocalizationProvider
        {
            public string YesButton { get; set; }
            public string NoButton { get; set; }
            public string OKButton { get; set; }
            public string CancelButton { get; set; }
            public string RetryButton { get; set; }
            public string IgnoreButton { get; set; }
            public string AbortButton { get; set; }
            public string DetailsButton { get; set; }
            public override string GetLocalizedString(string id)
            {
                switch (id)
                {
                    case RadMessageStringID.YesButton:
                        return YesButton;
                    case RadMessageStringID.NoButton:
                        return NoButton;
                    case RadMessageStringID.OKButton:
                        return OKButton;
                    case RadMessageStringID.CancelButton:
                        return CancelButton;
                    case RadMessageStringID.RetryButton:
                        return RetryButton;
                    case RadMessageStringID.IgnoreButton:
                        return IgnoreButton;
                    case RadMessageStringID.AbortButton:
                        return AbortButton;
                    case RadMessageStringID.DetailsButton:
                        return DetailsButton;
                    default:
                        return base.GetLocalizedString(id);
                }
            }
        }
        /// <summary>
        /// 更改Button字詞
        /// </summary>
        public class ResetRadMessageBoxLocalizationProvider : RadMessageLocalizationProvider
        {
            //需加入這段RadMessageLocalizationProvider.CurrentProvider = new CustomRadMessageBoxLocalizationProvider();
            public override string GetLocalizedString(string id)
            {
                RadMessageBoxLocalizationText SetText = new RadMessageBoxLocalizationText();
                switch (id)
                {
                    case RadMessageStringID.YesButton:
                        return SetText.YES;
                    case RadMessageStringID.NoButton:
                        return SetText.NO;
                    case RadMessageStringID.OKButton:
                        return SetText.OK;
                    case RadMessageStringID.CancelButton:
                        return SetText.CANCEL;
                    case RadMessageStringID.RetryButton:
                        return SetText.RETRY;
                    case RadMessageStringID.IgnoreButton:
                        return SetText.IGNORE;
                    case RadMessageStringID.AbortButton:
                        return SetText.ABORT;
                    case RadMessageStringID.DetailsButton:
                        return SetText.DETAILS;
                    default:
                        return base.GetLocalizedString(id);
                }
            }
        }

        #endregion
        #region File Dialogs Localization 
        public class FileDialogsLocalizationText
        {
            public FileDialogsLocalizationText()
            {
                OK = "確認";
                Yes = "是";
                No = "否";
                Cancel = "取消";
                Back = "返回";
                Forward = "前進";
                Up = "上一層";
                NewFolder = "新資料夾";
                SearchIn = "搜尋";
                SearchResults = "搜尋結果";
                ExtraLargeIcons = "超大圖示";
                LargeIcons = "大圖示";
                MediumIcons = "中圖示";
                SmallIcons = "小圖示";
                List = "清單";
                Tiles = "並排";
                Details = "詳細資料";
                NameHeader = "名稱";
                SizeHeader = "大小";
                TypeHeader = "類型";
                DateHeader = "修改日期";
                FileSizes_B = "位元組";
                FileSizes_GB = "GB";
                FileSizes_KB = "KB";
                FileSizes_MB = "MB";
                FileSizes_TB = "TB";
                OpenFileDialogHeader = "開啟檔案";
                OpenFolderDialogHeader = "開啟資料夾";
                SaveFileDialogHeader = "另存新檔";
                FileName = "檔案名稱:";
                Folder = "資料夾名稱:";
                SaveAsType = "另存為...";
                OpenFolder = "開啟資料夾";
                FileFolderType = "檔案資料夾";
                Cut = "剪下";
                Copy = "複製";
                CopyTo = "複製到...";
                Delete = "刪除";
                Edit = "編輯";
                MoveTo = "移動到";
                Open = "開啟";
                Paste = "貼上";
                Properties = "屬性";
                Rename = "重新命名";
                Save = "儲存";
                View = "瀏覽";
                CheckThePath = "請檢查路徑是否正確.";
                ConfirmSave = "確認另存檔案.";
                FileExists = "檔案已經存在.";
                FileNameWrongCharacters = "請勿在檔案名稱中包含\\ / : * ？ \" < > |等字元.";
                InvalidExtensionConfirmation = "是否要變更副檔名?";
                InvalidFileName = "檔案名稱無效.";
                InvalidOrMissingExtension = "如果變更此副檔名，可能會造成該檔案無法使用.";
                InvalidPath = "該目錄路徑無效.";
                OpenReadOnly = "是否以唯獨模式開啟?";
                ReplacementQuestion = "確認是否取代該檔案?";
            }
            public string OK { get; set; }
            public string Yes { get; set; }
            public string No { get; set; }
            public string Cancel { get; set; }
            public string Back { get; set; }
            public string Forward { get; set; }
            public string Up { get; set; }
            public string NewFolder { get; set; }
            public string SearchIn { get; set; }
            public string SearchResults { get; set; }
            public string ExtraLargeIcons { get; set; }
            public string LargeIcons { get; set; }
            public string MediumIcons { get; set; }
            public string SmallIcons { get; set; }
            public string List { get; set; }
            public string Tiles { get; set; }
            public string Details { get; set; }
            public string NameHeader { get; set; }
            public string SizeHeader { get; set; }
            public string TypeHeader { get; set; }
            public string DateHeader { get; set; }
            public string FileSizes_B { get; set; }
            public string FileSizes_GB { get; set; }
            public string FileSizes_KB { get; set; }
            public string FileSizes_MB { get; set; }
            public string FileSizes_TB { get; set; }
            public string OpenFileDialogHeader { get; set; }
            public string OpenFolderDialogHeader { get; set; }
            public string SaveFileDialogHeader { get; set; }
            public string FileName { get; set; }
            public string Folder { get; set; }
            public string SaveAsType { get; set; }
            public string OpenFolder { get; set; }
            public string FileFolderType { get; set; }
            public string Cut { get; set; }
            public string Copy { get; set; }
            public string CopyTo { get; set; }
            public string Delete { get; set; }
            public string Edit { get; set; }
            public string MoveTo { get; set; }
            public string Open { get; set; }
            public string Paste { get; set; }
            public string Properties { get; set; }
            public string Rename { get; set; }
            public string Save { get; set; }
            public string View { get; set; }
            public string CheckThePath { get; set; }
            public string ConfirmSave { get; set; }
            public string FileExists { get; set; }
            public string FileNameWrongCharacters { get; set; }
            public string InvalidExtensionConfirmation { get; set; }
            public string InvalidFileName { get; set; }
            public string InvalidOrMissingExtension { get; set; }
            public string InvalidPath { get; set; }
            public string OpenReadOnly { get; set; }
            public string ReplacementQuestion { get; set; }
        }
        
        public class ManualFileDialogsLocalizationProvider : FileDialogsLocalizationProvider
        {
            public override string GetLocalizedString(string id)
            {
                FileDialogsLocalizationText SetText = new FileDialogsLocalizationText();
                switch (id)
                {
                    case FileDialogsStringId.OK:
                        return SetText.OK;
                    case FileDialogsStringId.Yes:
                        return SetText.Yes;
                    case FileDialogsStringId.No:
                        return SetText.No;
                    case FileDialogsStringId.Cancel:
                        return SetText.Cancel;

                    case FileDialogsStringId.Back:
                        return SetText.Back;
                    case FileDialogsStringId.Forward:
                        return SetText.Forward;
                    case FileDialogsStringId.Up:
                        return SetText.Up;
                    case FileDialogsStringId.NewFolder:
                        return SetText.NewFolder;
                    case FileDialogsStringId.SearchIn:
                        return SetText.SearchIn;
                    case FileDialogsStringId.SearchResults:
                        return SetText.SearchResults;

                    case FileDialogsStringId.ExtraLargeIcons:
                        return SetText.ExtraLargeIcons;
                    case FileDialogsStringId.LargeIcons:
                        return SetText.LargeIcons;
                    case FileDialogsStringId.MediumIcons:
                        return SetText.MediumIcons;
                    case FileDialogsStringId.SmallIcons:
                        return SetText.SmallIcons;
                    case FileDialogsStringId.List:
                        return SetText.List;
                    case FileDialogsStringId.Tiles:
                        return SetText.Tiles;
                    case FileDialogsStringId.Details:
                        return SetText.Details;

                    case FileDialogsStringId.NameHeader:
                        return SetText.NameHeader;
                    case FileDialogsStringId.SizeHeader:
                        return SetText.SizeHeader;
                    case FileDialogsStringId.TypeHeader:
                        return SetText.TypeHeader;
                    case FileDialogsStringId.DateHeader:
                        return SetText.DateHeader;

                    case FileDialogsStringId.FileSizes_B:
                        return SetText.FileSizes_B;
                    case FileDialogsStringId.FileSizes_GB:
                        return SetText.FileSizes_GB;
                    case FileDialogsStringId.FileSizes_KB:
                        return SetText.FileSizes_KB;
                    case FileDialogsStringId.FileSizes_MB:
                        return SetText.FileSizes_MB;
                    case FileDialogsStringId.FileSizes_TB:
                        return SetText.FileSizes_TB;

                    case FileDialogsStringId.OpenFileDialogHeader:
                        return SetText.OpenFileDialogHeader;
                    case FileDialogsStringId.OpenFolderDialogHeader:
                        return SetText.OpenFileDialogHeader;
                    case FileDialogsStringId.SaveFileDialogHeader:
                        return SetText.SaveFileDialogHeader;

                    case FileDialogsStringId.FileName:
                        return SetText.FileName;
                    case FileDialogsStringId.Folder:
                        return SetText.Folder;
                    case FileDialogsStringId.SaveAsType:
                        return SetText.SaveAsType;

                    case FileDialogsStringId.OpenFolder:
                        return SetText.OpenFolder;
                    case FileDialogsStringId.FileFolderType:
                        return SetText.FileFolderType;

                    case FileDialogsStringId.Cut:
                        return SetText.Cut;
                    case FileDialogsStringId.Copy:
                        return SetText.Copy;
                    case FileDialogsStringId.CopyTo:
                        return SetText.CopyTo;
                    case FileDialogsStringId.Delete:
                        return SetText.Delete;
                    case FileDialogsStringId.Edit:
                        return SetText.Edit;
                    case FileDialogsStringId.MoveTo:
                        return SetText.MoveTo;
                    case FileDialogsStringId.Open:
                        return SetText.Open;
                    case FileDialogsStringId.Paste:
                        return SetText.Paste;
                    case FileDialogsStringId.Properties:
                        return SetText.Properties;
                    case FileDialogsStringId.Rename:
                        return SetText.Rename;
                    case FileDialogsStringId.Save:
                        return SetText.Save;
                    case FileDialogsStringId.View:
                        return SetText.View;

                    case FileDialogsStringId.CheckThePath:
                        return SetText.CheckThePath;
                    case FileDialogsStringId.ConfirmSave:
                        return SetText.ConfirmSave;
                    case FileDialogsStringId.FileExists:
                        return SetText.FileExists;
                    case FileDialogsStringId.FileNameWrongCharacters:
                        return SetText.FileNameWrongCharacters;
                    case FileDialogsStringId.InvalidExtensionConfirmation:
                        return SetText.InvalidExtensionConfirmation;
                    case FileDialogsStringId.InvalidFileName:
                        return SetText.InvalidFileName;
                    case FileDialogsStringId.InvalidOrMissingExtension:
                        return SetText.InvalidOrMissingExtension;
                    case FileDialogsStringId.InvalidPath:
                        return SetText.InvalidPath;
                    case FileDialogsStringId.OpenReadOnly:
                        return SetText.OpenReadOnly;
                    case FileDialogsStringId.ReplacementQuestion:
                        return SetText.ReplacementQuestion;

                    default:
                        return string.Empty;
                }
            }
        }

        #endregion


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