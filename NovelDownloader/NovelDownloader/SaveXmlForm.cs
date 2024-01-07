using Newtonsoft.Json;
using NovelDownloader.CoreBase.Help;
using NovelDownloader.Library;
using NovelDownloader.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Telerik.WinControls;
using Telerik.WinControls.FileDialogs;
using Telerik.WinControls.UI;
using static NovelDownloader.Library.NovelUtility;

namespace NovelDownloader
{
    public partial class SaveXmlForm : Telerik.WinControls.UI.RadForm
    {
        private DropDownListUtility _common = new DropDownListUtility();
        private NovelUtility _utility = new NovelUtility();
        private DesktopAlertUtil _desktopAlert = new DesktopAlertUtil();

        private List<string> DownloadUrlList = new List<string>();
        /// <summary>
        /// XML File
        /// </summary>
        private XmlToJson LoadFromXmlData;
        /// <summary>
        /// 小說名稱
        /// </summary>
        private string NovelName_GLOBLE = "";
        /// <summary>
        /// 參數設定
        /// </summary>
        private NovelSettings Settings = new NovelSettings();
        /// <summary>
        /// 進階參數設定
        /// </summary>
        private AdvanceSettings AdvanceSettings = new AdvanceSettings();
        /// <summary>
        /// 下載Text檔案List
        /// </summary>
        private List<(int ThreadSearial, bool DownloadFinish, List<StringBuilder> DownloadTextList)> DownloadNovelTextList = new List<(int ThreadSearial, bool DownloadFinish, List<StringBuilder> DownloadTextList)>();
        /// <summary>
        /// 下載URL List
        /// </summary>
        private List<(int ThreadSerial, List<string> DownloadUrl)> DownloadNovelURLList = new List<(int ThreadSerial, List<string> DownloadUrl)>();

        public delegate void ReturnSaveXmlFormDelegate(bool IsNeedReloadXmlFile);
        public event ReturnSaveXmlFormDelegate ReturnSaveXmlForm_CallBack; 

        public SaveXmlForm()
        {
            try
            {
                InitializeComponent();
                this.Text = "編輯\"網頁抓取屬性\"設定檔";
                UI_Settings();
                UI_Register();

                LoadXmlFile();
                
            }
            catch
            {
                throw;
            }

        }
        
        private void UI_Settings()
        {
           
            this.Font = _utility.SetFontSize(12);
            _utility.SetControlFont(this);
            foreach (RadTextBoxControl rtbc in _utility.GetAllControl(this, typeof(RadTextBoxControl)))
            {
                rtbc.Font = _utility.SetFontSize();
                rtbc.Multiline = true;
                rtbc.AcceptsReturn = true;
                rtbc.WordWrap = true;
                //rtbc.VerticalScroll.Visible = true;
            }

            #region RadTextBoxControl MaxLength
            radTextBoxControl_NovelName_Start_SearchFlag.MaxLength = 2;
            radTextBoxControl_Title_Start_SearchFlag.MaxLength = 2;
            radTextBoxControl_Content_Start_SearchFlag.MaxLength = 2;
            #endregion


        }


        private void UI_Register()
        {
            radTextBoxControl_NovelName_Start_SearchFlag.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        e.Cancel = true;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.NovelName_Start_SearchFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                    }
                }
            };
            radTextBoxControl_Title_Start_SearchFlag.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        rtbc.Text = string.Empty;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.Title_Start_SearchFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                        e.Cancel = true;
                    }
                }
            };
            radTextBoxControl_Content_Start_SearchFlag.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        e.Cancel = true;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.Content_Start_SearchFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                    }
                }
            };

            foreach (RadLabel rlb in _utility.GetAllControl(this, typeof(RadLabel)))
            {
                rlb.ToolTipTextNeeded += (sender, e) =>
                {
                    if (sender is RadLabelElement lab)
                        e.ToolTipText = lab.Text;
                };
            }

            radButton_SaveFileDialog.Click += RadButton_SaveFileDialog_Click;

            radButton_Save.Click += RadButton_Save_Click;
            radButton_Cancel.Click += RadButton_Cancel_Click;

            radButton_Settings_ClearTextBoxValue.Click += RadButton_Settings_ClearTextBoxValue_Click;

            radDropDownList_ButtonList.SelectedIndexChanged += RadDropDownList_ButtonList_SelectedIndexChanged;

            radButton_ReloadXmlFile.Click += RadButton_ReloadXmlFile_Click;
        }

        private void RadButton_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(radDropDownList_ButtonList.SelectedValue?.ToString()))
                {
                    (string Content, string Cpation) ErrorMsg = ("", "");
                    foreach (RadTextBoxControl rtbc in _utility.GetAllControl(this, typeof(RadTextBoxControl)))
                    {
                        switch (rtbc.Name)
                        {
                            case nameof(radTextBoxControl_ButtonName):
                            case nameof(radTextBoxControl_NovelName_Start_SearchFlag):
                            case nameof(radTextBoxControl_Title_Start_SearchFlag):
                            case nameof(radTextBoxControl_Content_Start_SearchFlag):
                                if (string.IsNullOrWhiteSpace(rtbc.Text))
                                {
                                    var tempIndex = rtbc.Name.IndexOf("_") + 1;
                                    var name = rtbc.Name.Substring(tempIndex, rtbc.Name.Length - tempIndex);
                                    //var name = nameSplit
                                    ErrorMsg = ("不可為空值!", EnumerableExtensions.GetClassDisplayNameDictionary<ShortCut_Button>().Where(x => x.Key == name).FirstOrDefault().Value);
                                    break;
                                }
                                break;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(ErrorMsg.Cpation) || !string.IsNullOrWhiteSpace(ErrorMsg.Content))
                    {
                        RadMessageBox.Show(ErrorMsg.Content, ErrorMsg.Cpation, MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        return;
                    }

                    ShortcutButton SaveModel = new ShortcutButton();
                    var modelDic = EnumerableExtensions.GetFieldValue(SaveModel);
                    foreach (RadTextBoxControl rtbc in _utility.GetAllControl(this, typeof(RadTextBoxControl)))
                    {
                        var tempIndex = rtbc.Name.IndexOf("_") + 1;
                        var name = rtbc.Name.Substring(tempIndex, rtbc.Name.Length - tempIndex);
                        if (modelDic.Any(x=>x.Key == name))
                        {
                            var oldModel = modelDic.Where(x => x.Key == name).FirstOrDefault().Key;
                            modelDic.Remove(oldModel);
                            modelDic.Add(oldModel, rtbc.Text);
                        }

                    }
                    SaveModel.MappingSource(modelDic);
                    //SaveModel.CovertModel(modelDic);
                    SaveModel.ButtonSerialNumber = Convert.ToInt32(radDropDownList_ButtonList.SelectedValue?.ToString());
                    if (SaveModel != null)
                    {
                        var ModifyXmlStatus = ModifyXmlFile(nameof(XmlToJson.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton), SaveModel);
                        if(ModifyXmlStatus.Status)
                        {
                            radButton_ReloadXmlFile.PerformClick();
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show("\"標籤編號\"不可為空值!", "儲存檢核", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                }
            }
            catch
            {
                throw;
            }
        }

        private void RadButton_ReloadXmlFile_Click(object sender, EventArgs e)
        {
            LoadXmlFile();
        }

        private void RadButton_Cancel_Click(object sender, EventArgs e)
        {
            ReturnSaveXmlForm_CallBack(false);
            Close();
        }

        private void RadDropDownList_ButtonList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (sender is RadDropDownList rddl)
                {
                    if (!string.IsNullOrWhiteSpace(rddl.SelectedValue?.ToString()))
                    {
                        if (LoadFromXmlData.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Any(x => x.ButtonSerialNumber.ToString() == rddl.SelectedValue?.ToString()))
                        {
                            var XmlData = LoadFromXmlData.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Where(x => x.ButtonSerialNumber.ToString() == rddl.SelectedValue?.ToString()).FirstOrDefault();
                            radTextBoxControl_ButtonName.Text = XmlData.ButtonName;
                            radTextBoxControl_PageType.Text = XmlData.PageType;
                            radTextBoxControl_ButtonUrl.Text = XmlData.ButtonUrl;
                            radTextBoxControl_NovelTextFileSavePath.Text = XmlData.NovelTextFileSavePath;
                            radTextBoxControl_NovelName_Start.Text = XmlData.NovelName_Start;
                            radTextBoxControl_NovelName_Start_SearchFlag.Text = XmlData.NovelName_Start_SearchFlag.ToString();
                            radTextBoxControl_NovelName_End.Text = XmlData.NovelName_End;
                            radTextBoxControl_Title_Start.Text = XmlData.Title_Start;
                            radTextBoxControl_Title_End.Text = XmlData.Title_End;
                            radTextBoxControl_Title_Start_SearchFlag.Text = XmlData.Title_Start_SearchFlag.ToString();
                            radTextBoxControl_Content_Start.Text = XmlData.Content_Start;
                            radTextBoxControl_Content_End.Text = XmlData.Content_End;
                            radTextBoxControl_Content_Start_SearchFlag.Text = XmlData.Content_Start_SearchFlag.ToString();
                            radTextBoxControl_Content_NewLine.Text = XmlData.Content_NewLine;
                            radTextBoxControl_Content_WhiteSpace.Text = XmlData.Content_WhiteSpace;
                            radGroupBox_HTMLTag.GroupBoxElement.Header.Text = $"第{XmlData.ButtonSerialNumber}組 HTML標籤設定";
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void RadButton_Settings_ClearTextBoxValue_Click(object sender, EventArgs e)
        {
            try
            {
                var Controls = tableLayoutPanel_HTMLSettings.Controls;
                foreach (var control in Controls)
                {
                    if (control is RadTextBoxControl rtbc)
                    {
                        rtbc.Text = string.Empty;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void RadButton_SaveFileDialog_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var FilePath = "";
                if (!string.IsNullOrWhiteSpace(radTextBoxControl_NovelTextFileSavePath.Text))
                {
                    FilePath = radTextBoxControl_NovelTextFileSavePath.Text;
                }
                FileDialogsLocalizationProvider.CurrentProvider = new ManualFileDialogsLocalizationProvider();
                RadOpenFolderDialog radOpenFolderDialog = new RadOpenFolderDialog();
                radOpenFolderDialog.OpenFolderDialogForm.FormElement.Font = _utility.SetFontSize();
                radOpenFolderDialog.RestoreDirectory = true;
                radOpenFolderDialog.InitialSelectedLayout = Telerik.WinControls.FileDialogs.LayoutType.Details;
                //radSaveFileDialog.SaveFileDialogForm.ThemeName = "Fluent";
                radOpenFolderDialog.InitialDirectory = !string.IsNullOrWhiteSpace(FilePath) ? FilePath : Directory.GetCurrentDirectory();//Assembly.GetExecutingAssembly().Location;
                radOpenFolderDialog.OpenFolderDialogForm.Text = "TXT 另存新檔路徑";
                radOpenFolderDialog.OpenFolderDialogForm.Font = _utility.SetFontSize();
                radOpenFolderDialog.OpenFolderDialogForm.StartPosition = FormStartPosition.CenterScreen;
                //radOpenFolderDialog.FileName = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss_")}.text";
                radOpenFolderDialog.EditingOptions ^= (Telerik.WinControls.FileDialogs.EditingOptions.Rename | Telerik.WinControls.FileDialogs.EditingOptions.NewFolder);
                radOpenFolderDialog.OpenFolderDialogForm.ExplorerControl.IsDragDropEnabled = false;
                //Cursor = Cursors.Default;
                DialogResult DR = radOpenFolderDialog.ShowDialog();
                if (DR == DialogResult.OK)
                {
                    radTextBoxControl_NovelTextFileSavePath.Text = radOpenFolderDialog.FileName;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        
        
        /// <summary>
        /// 綁定Settings
        /// </summary>
        private void BindSettings()
        {
            Settings.Title_Start = radTextBoxControl_Title_Start.Text;
            Settings.Title_Start_SearchFlag = int.TryParse(radTextBoxControl_Title_Start_SearchFlag.Text, out int titleStart) ? (titleStart > 0 ? titleStart : 1) : 1;
            Settings.Title_End = radTextBoxControl_Title_End.Text;
            //Settings.Title_End_SerachFlag = int.TryParse(radTextBoxControl_Title_Start_SearchFlag.Text, out int titleEnd) ? (titleEnd > 0 ? titleEnd : 1) : 1;
            Settings.Content_Start = radTextBoxControl_Content_Start.Text;
            Settings.Content_Start_SearchFlag = int.TryParse(radTextBoxControl_Content_Start_SearchFlag.Text, out int contentStart) ? (contentStart > 0 ? contentStart : 1) : 1;
            Settings.Content_End = radTextBoxControl_Content_End.Text;
            //Settings.Content_End_SerachFlag = int.TryParse(radTextBoxControl_Content_End_SearchFlag.Text, out int contentEnd) ? (contentEnd > 0 ? contentEnd : 1) : 1;
            Settings.Content_NewLine = radTextBoxControl_Content_NewLine.Text;
            Settings.Content_WhiteSpace = radTextBoxControl_Content_WhiteSpace.Text;
            Settings.NovelName_Start = radTextBoxControl_NovelName_Start.Text;
            Settings.NovelName_End = radTextBoxControl_NovelName_End.Text;

        }

        #region XML 
        /// <summary>
        /// 更改XML檔案
        /// </summary>
        /// <param name="XMLTagName">標籤名稱</param>
        /// <param name="XMLTagValue">欲更改之物件數值</param>
        private (bool Status, string Msg) ModifyXmlFile(string XMLTagName, object XMLTagValue)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                var defaultPath = Environment.CurrentDirectory;
                var defaultFileName = "NovelDownload_Settings.xml";
                if (File.Exists(defaultPath + "\\" + defaultFileName))
                {
                    xmlDoc.Load(defaultPath + "\\" + defaultFileName);
                    XmlNode NovelDownloader_Node = xmlDoc.SelectSingleNode($"//NovelDownloader");
                    string jsonText = JsonConvert.SerializeXmlNode(NovelDownloader_Node);
                    var xml = JsonConvert.DeserializeObject<XmlToJson>(jsonText);
                    if (xml != null)
                    {
                        if (xml.NovelDownloader.ADVANCE_SETTINGS != null)
                        {
                            switch (XMLTagName)
                            {
                                case nameof(xml.NovelDownloader.ADVANCE_SETTINGS.DownloadWaitingTimeOutSeconds):
                                    xml.NovelDownloader.ADVANCE_SETTINGS.DownloadWaitingTimeOutSeconds = Convert.ToInt32(XMLTagValue);
                                    break;
                            }
                        }
                        if (xml.NovelDownloader.HTML_SHORTCUT_SETTINGS != null)
                        {
                            switch (XMLTagName)
                            {
                                case nameof(xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton):
                                    if (XMLTagValue != null && XMLTagValue is ShortcutButton SCB)
                                    {
                                        if (xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Any(x => x.ButtonSerialNumber == SCB.ButtonSerialNumber))
                                        {
                                            var temp = xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton
                                                .Where(x => x.ButtonSerialNumber == SCB.ButtonSerialNumber)
                                                .FirstOrDefault();
                                            xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Remove(temp);
                                            xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Add(SCB);
                                        }
                                    }
                                    break;
                            }
                        }
                        #region 建立存檔用XML
                        XmlDocument saveXmlDoc = new XmlDocument();
                        //宣告段落
                        XmlDeclaration xmlDeclaration = saveXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                        saveXmlDoc.AppendChild(xmlDeclaration);
                        //ROOT
                        XmlElement Root = saveXmlDoc.CreateElement("NovelDownloader");
                        saveXmlDoc.AppendChild(Root);

                        var ADVANCE_SETTINGS_Element = CreateNode(saveXmlDoc, Root, nameof(XmlToJson.NovelDownloader.ADVANCE_SETTINGS), "");

                        var HTML_SHORTCUT_Element = CreateNode(saveXmlDoc, Root, nameof(XmlToJson.NovelDownloader.HTML_SHORTCUT_SETTINGS), "");

                        CreateNode(saveXmlDoc, ADVANCE_SETTINGS_Element, nameof(XmlToJson.NovelDownloader.ADVANCE_SETTINGS.DownloadWaitingTimeOutSeconds), xml.NovelDownloader.ADVANCE_SETTINGS.DownloadWaitingTimeOutSeconds.ToString());

                        var NovelList = xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton;
                        foreach (var item in NovelList.OrderBy(x => x.ButtonSerialNumber))
                        {
                            XmlElement HTML_SHORTCUT_BTN_ELement = CreateNode(saveXmlDoc, HTML_SHORTCUT_Element, nameof(XmlToJson.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton), "");
                            CreateButtonSettings(saveXmlDoc, HTML_SHORTCUT_BTN_ELement, item);
                        }
                        #endregion



                        if (File.Exists(defaultPath + "\\" + defaultFileName))
                        {
                            if(Directory.Exists(defaultPath  + "\\BackupSettingsXml\\"))
                            {
                                if(Directory.GetFiles(defaultPath + "\\BackupSettingsXml\\")?.Length > 20)
                                {
                                    var directoryFilesList = Directory.GetFiles(defaultPath + "\\BackupSettingsXml\\");
                                    if(directoryFilesList.Length > 0)
                                    {
                                        var LastModifyDateTime = DateTime.Now;
                                        var LastModifyFilePath = "";
                                        foreach(var filePath in directoryFilesList)
                                        {
                                            if(Directory.GetLastAccessTime(filePath).CompareTo(LastModifyDateTime) < 0)
                                            {
                                                LastModifyDateTime = Directory.GetLastWriteTime(filePath);
                                                LastModifyFilePath = filePath;
                                            }
                                        }
                                        if (!string.IsNullOrWhiteSpace(LastModifyFilePath))
                                        {
                                            if (File.Exists(LastModifyFilePath))
                                            {
                                                File.Delete(LastModifyFilePath);
                                            }
                                        }
                                    }
                                }

                                File.Copy(defaultPath + "\\" + defaultFileName, defaultPath + "\\BackupSettingsXml\\" + $"NovelDownload_Settings_{DateTime.Now:yyyyMMdd_HHmmss}.xml"  , true);
                            }
                            else
                            {
                                Directory.CreateDirectory(defaultPath + "\\BackupSettingsXml");
                                File.Copy(defaultPath + "\\" + defaultFileName, defaultPath + "\\BackupSettingsXml\\" + $"NovelDownload_Settings_{DateTime.Now:yyyyMMdd_HHmmss}.xml", true);
                            }
                            saveXmlDoc.Save(defaultPath + "\\" + defaultFileName);
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"已經將舊設定檔案，備份在\"BackupSettingsXml\\{$"NovelDownload_Settings_{DateTime.Now:yyyyMMdd_HHmmss}.xml"}\".\n設定檔儲存成功!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                            //File.Copy(defaultPath + "\\" + defaultFileName, defaultPath + "\\" + defaultFileName + ".BAK", true);
                            return (true, "檔案備份成功!設定檔儲存成功!");
                        }
                        else
                        {
                            saveXmlDoc.Save(defaultPath + "\\" + defaultFileName);
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"設定檔儲存成功!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                            return (true, "設定檔儲存成功!");
                        }
                    }
                    else
                    {
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, $"舊設定檔讀取失敗，設定檔案未儲存!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                        return (false, "舊設定檔讀取失敗，設定檔案未儲存!");
                    }
                }
                else
                {
                    _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, $"舊設定檔不存在，設定檔案未儲存!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                    return (false, "舊設定檔不存在，設定檔案未儲存!");
                }
            }
            catch
            {
                throw;
            }
        }
        private void LoadXmlFile()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                var defaultPath = Environment.CurrentDirectory;
                var defaultFileName = "NovelDownload_Settings.xml";
                if (File.Exists(defaultPath + "\\" + defaultFileName))
                {
                    xmlDoc.Load(defaultPath + "\\" + defaultFileName);
                    XmlNode NovelDownloader_Node = xmlDoc.SelectSingleNode($"//NovelDownloader");
                    string jsonText = JsonConvert.SerializeXmlNode(NovelDownloader_Node);


                    List<RadButton> DefaultButtonList = new List<RadButton>();

                    
                    var xml = JsonConvert.DeserializeObject<XmlToJson>(jsonText);
                    if (xml != null)
                    {
                        LoadFromXmlData = new XmlToJson();
                        LoadFromXmlData = xml;
                        var buttonList = new List<DropDownModel>();
                        foreach(var item in LoadFromXmlData.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.OrderBy(x=>x.ButtonSerialNumber))
                        {
                            buttonList.Add(new DropDownModel() { VALUE = item.ButtonSerialNumber.ToString(), DISPLAYTEXT = $"第{item.ButtonSerialNumber}組 " + item.ButtonName?.ToString(), CONTENT = item.ButtonUrl?.ToString() });
                        }

                        _common.DropDownListSet(buttonList, radDropDownList_ButtonList, true, false, false, 10, RadDropDownStyle.DropDownList);

                    }
                    else
                    {
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "設定檔讀取失敗!", "讀取設定XML", -1, AlertScreenPosition.BottomRight);

                    }
                }
                else
                {
                    if (DialogResult.No == RadMessageBox.Show("於程式根目錄下未找到\"網頁抓取設定檔\"NovelDownload_Settings.xml，是否產生預設設定檔至程式根目錄下 ?", "Xml設定檔", MessageBoxButtons.YesNo, RadMessageIcon.Exclamation))
                    {
                        ReturnSaveXmlForm_CallBack(false);
                        Close();
                        return;
                    }
                    else
                    {
                        RadMessageBox.Show($"預設設定檔案不存在!\n\n檔案路徑:\n{defaultPath + "\\" + defaultFileName}\n\n請確認檔案後再進行快捷鍵設定檔載入!", "Xml設定檔案載入檢測", MessageBoxButtons.OKCancel, RadMessageIcon.Exclamation);
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        private void CreateXmlFile(bool IsInitLoading = false)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                //宣告段落
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);
                //ROOT
                XmlElement Root = xmlDoc.CreateElement("NovelDownloader");
                xmlDoc.AppendChild(Root);

                var ADVANCE_SETTINGS_Element = CreateNode(xmlDoc, Root, nameof(XmlToJson.NovelDownloader.ADVANCE_SETTINGS), "");

                var HTML_SHORTCUT_Element = CreateNode(xmlDoc, Root, nameof(XmlToJson.NovelDownloader.HTML_SHORTCUT_SETTINGS), "");

                CreateNode(xmlDoc, ADVANCE_SETTINGS_Element, nameof(XmlToJson.NovelDownloader.ADVANCE_SETTINGS.DownloadWaitingTimeOutSeconds), "30000");

                //var NovelList = DefaultNovelXmlSettings();

                //for (int i = 1; i < NovelList.Count + 1; i++)
                //{

                //    XmlElement HTML_SHORTCUT_BTN_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, nameof(XmlToJson.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton), "");
                //    CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN_ELement, NovelList[i - 1]);
                //}



                var defaultPath = Environment.CurrentDirectory;
                var defaultFileName = "NovelDownload_Settings.xml";

                if (File.Exists(defaultPath + "\\" + defaultFileName))
                {
                    if (IsInitLoading)
                    {
                        xmlDoc.Save(defaultPath + "\\" + defaultFileName);
                    }
                    else
                    {
                        if (DialogResult.Yes == RadMessageBox.Show("NovelDownload_Settings.xml 設定檔存在，是否覆蓋?", "檔案覆蓋詢問", MessageBoxButtons.YesNo, RadMessageIcon.Question))
                        {
                            xmlDoc.Save(defaultPath + "\\" + defaultFileName);
                        }
                    }
                }
                else
                {
                    xmlDoc.Save(defaultPath + "\\" + defaultFileName);
                }
                if (!IsInitLoading)
                {
                    _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"xml產生成功!\n\n路徑:\n{defaultPath + "\\" + defaultFileName}", "XML產出", -1, AlertScreenPosition.BottomRight);
                }
            }
            catch
            {
                throw;
            }
        }
        private void CreateButtonSettings(XmlDocument xmlDoc, XmlElement ButtonData, ShortCut_Button NovelData)
        {
            if (NovelData != null)
            {
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.ButtonSerialNumber), NovelData.ButtonSerialNumber.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.ButtonName), NovelData.ButtonName);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.ButtonUrl), NovelData.ButtonUrl);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_Start), NovelData.Title_Start);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_Start_SearchFlag), NovelData.Title_Start_SearchFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_End), NovelData.Title_End);
                //CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_End_SerachFlag), NovelData.Title_End_SerachFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_Start), NovelData.Content_Start);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_Start_SearchFlag), NovelData.Content_Start_SearchFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_End), NovelData.Content_End);
                //CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_End_SerachFlag), NovelData.Content_End_SerachFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_NewLine), NovelData.Content_NewLine);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_WhiteSpace), NovelData.Content_WhiteSpace);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.PageType), NovelData.PageType);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelTextFileSavePath), NovelData.NovelTextFileSavePath);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelName_Start), NovelData.NovelName_Start);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelName_End), NovelData.NovelName_End);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelName_Start_SearchFlag), NovelData.NovelName_Start_SearchFlag.ToString());
            }
        }
        




        /// <summary>
        /// Add New Node
        /// </summary>
        /// <param name="xmlDoc">MainDocument</param>
        /// <param name="ParentNode">Parent Node</param>
        /// <param name="ChildName">Child Name</param>
        /// <param name="ChildValue">Child Value</param>
        /// <returns>Child XmlElement</returns>
        public XmlElement CreateNode(XmlDocument xmlDoc, XmlElement ParentNode, string ChildName, string ChildValue)
        {
            XmlElement element = xmlDoc.CreateElement(ChildName);
            //避免相關標籤連在一起
            if (!string.IsNullOrEmpty(ChildValue))
            {
                element.InnerText = ChildValue;
            }

            ParentNode.AppendChild(element);
            return element;
            //XmlNode Node = xmlDoc.CreateNode(XmlNodeType.Element, ChildName, null);
            //Node.InnerText = ChildValue;
            //ParentNode.AppendChild(Node);
        }

        #endregion

    }
}