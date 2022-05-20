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
    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        private NovelUtility _utility = new NovelUtility();
        private DesktopAlertUtil _desktopAlert = new DesktopAlertUtil();

        private List<string> DownloadUrlList = new List<string>();
        /// <summary>
        /// XML
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
        #region backgroundworker
        /// <summary>
        /// 多執行續序列
        /// </summary>
        private BackgroundWorker[] bgw_DownloadQuery;
        /// <summary>
        /// 下載進度條%數
        /// </summary>
        private int progressBarValue = 0;
        #endregion



        #region FlAG
        /// <summary>
        /// BackgroundWorker 是否顯示過警告視窗
        /// </summary>
        private bool IsShowAlert = false;
        /// <summary>
        /// 當目的地檔案存在時候，是否進行覆蓋
        /// </summary>
        private bool IsDeleteFileWhenTargetFileExist = false;
        #endregion
        #region LoadingType Enum
        /// <summary>
        /// 多執行序
        /// </summary>
        public enum LoadingThread
        {
            ExceptionError,
            Thread1,
            Thread2,
            Thread3,
            Thread4,
            Thread5,
            Thread6,
            Thread7,
            Thread8,
            Thread9,
            Thread10,
            Thread11,
            Thread12,
            Thread13,
            Thread14,
            Thread15,
            Thread16,
        }
        #endregion

        public Main()
        {
            try
            {
                InitializeComponent();
                _utility.radMsgboxFont();
                _utility.SetControlFont(this);

                this.Text = "NovelDownloader" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                this.Font = _utility.SetFontSize(12);

                radLabel_Version.Text = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion; ;

                UI_Settings();
                UI_Register();

                UI_DefaultSettings();

                LoadXmlFile(true);
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// 設定下載路徑(程式根目錄下) + 小說名稱(預設為yyyyMMdd_HHmmss_Novel.txt)
        /// </summary>
        /// <param name="NovelName">小說名稱</param>
        private void UI_DefaultSettings(string NovelName = null)
        {
            try
            {
                var ExecuteFilePath = Assembly.GetExecutingAssembly().Location;
                var FileName = Assembly.GetExecutingAssembly().ManifestModule.Name;
                var FilePath = "";
                //!string.IsNullOrWhiteSpace(NovelName) ?
                //Directory.GetCurrentDirectory() + DateTime.Now.ToString("yyyyMMdd_HHmmss") + NovelName + ".txt" :
                //Directory.GetCurrentDirectory() + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_Novel.txt";
                if (ExecuteFilePath.Length > FileName.Length)
                {
                    FilePath = ExecuteFilePath.Substring(0, ExecuteFilePath.Length - FileName.Length);
                }
                radTextBoxControl_SaveFileName.Text = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_Novel.txt";
                radTextBoxControl_SaveFilePath.Text = FilePath;
            }
            catch
            {
                throw;
            }
        }
        private void UI_Settings()
        {

            if (radPageView_Main.ViewElement is RadPageViewStripElement radPageViewStripElement)
            {
                radPageViewStripElement.StripButtons = StripViewButtons.ItemList;
                radPageViewStripElement.ShowItemCloseButton = false;
                radPageViewStripElement.ShowItemPinButton = false;
            }
            radPageView_Main.DefaultPage = radPageViewPage_Main;


            #region Glyphs Fonts dropdownbutton
            radMenu_Utility.BackColor = Color.Transparent;
            radMenuItem_Utility.FillPrimitive.BackColor = radMenuItem_Utility.FillPrimitive.BackColor2
            = radMenuItem_Utility.FillPrimitive.BackColor3 = radMenuItem_Utility.FillPrimitive.BackColor4
            = Color.FromArgb(233, 240, 249);  //SystemColors.Control;
            var glyphsFont = ThemeResolutionService.GetCustomFont("TelerikWebUI");
            radMenuItem_Utility.CustomFont = glyphsFont.Name;
            radMenuItem_Utility.Text = "\ue13C";
            radMenuItem_Utility.CustomFontSize = 20f;
            radMenu_Utility.MenuElement.ItemsLayout.Alignment = ContentAlignment.TopRight;
            radMenu_Utility.RightToLeft = RightToLeft.Yes;
            RadMenuItem_Utility_Init();
            #endregion

            foreach (RadTextBoxControl rtbc in _utility.GetAllControl(this, typeof(RadTextBoxControl)))
            {
                rtbc.Multiline = true;
                rtbc.AcceptsReturn = true;
                rtbc.WordWrap = true;
                //rtbc.VerticalScroll.Visible = true;
            }



            #region RadTextBoxControl MaxLength
            radTextBoxControl_PageType.TextBoxElement.MaxLength = 5;
            radTextBoxControl_Title_Start_SearchFlag.MaxLength = 3;
            radTextBoxControl_Title_End_SearchFlag.MaxLength = 3;
            radTextBoxControl_Content_Start_SearchFlag.MaxLength = 3;
            radTextBoxControl_Content_End_SearchFlag.MaxLength = 3;
            #endregion

            radCheckBox_ActivateAdvanceSettings.ButtonElement.CheckMarkPrimitive.CheckElement.UseFixedCheckSize = false;
            radCheckBox_ActivateAdvanceSettings.ButtonElement.CheckMarkPrimitive.CheckElement.MinSize = new Size(20, 20);

            #region advance settings Default
            AdvanceSettings.DownloadWaitingTimeOutSeconds = 30000;
            radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Text = AdvanceSettings.DownloadWaitingTimeOutSeconds.ToString();
            #endregion

            radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Enabled = false;
            radButton_AdvanceSettings_Save.Enabled = false;
            radButton_AdvanceSettings_RestoreDefault.Enabled = false;

            radButton_Download.Font = _utility.SetFontSize(14f, true);
            radButton_Download_Cancel.Font = _utility.SetFontSize(14f, false);

        }

        private void RadMenuItem_Utility_Init()
        {
            try
            {
                RadMenuItem item0 = new RadMenuItem
                {
                    Name = "ReloadXmlFile",
                    Text = "重新讀取Xml設定至網頁參數快速鍵",
                    Font = _utility.SetFontSize()
                };
                item0.Click += (sender, e) =>
                {
                    LoadXmlFile();
                };
                RadMenuItem item1 = new RadMenuItem
                {
                    Name = "RestoreXmlFile",
                    Text = "重新產出預設快捷鍵Xml檔案至程式目錄下",
                    Font = _utility.SetFontSize()
                };
                item1.Click += (sender, e) =>
                {
                    CreateXmlFile();
                };

                radMenuItem_Utility.Items.Add(item0);
                radMenuItem_Utility.Items.Add(item1);

            }
            catch
            {
                throw;
            }
        }

        private void UI_Register()
        {
            radTextBoxControl_Title_Start_SearchFlag.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        rtbc.Text = string.Empty;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.Title_Start_SerachFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                        e.Cancel = true;
                    }
                }
            };
            radTextBoxControl_Title_End_SearchFlag.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        e.Cancel = true;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.Title_End_SerachFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
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
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.Content_Start_SerachFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                    }
                }
            };
            radTextBoxControl_Content_End_SearchFlag.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        e.Cancel = true;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<NovelSettings>().Where(x => x.Key == nameof(Settings.Content_End_SerachFlag)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                    }
                }
            };
            this.FormClosing += (sender, e) =>
            {
                if (RadMessageBox.Show($"是否關閉 NovelDownloader ?", "系統提醒", MessageBoxButtons.YesNo, RadMessageIcon.Question) ==
                    DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

            };
            #region Advance Settings 
            radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.TextChanging += (sender, e) =>
            {
                if (sender is RadTextBoxControl rtbc)
                {
                    if (!int.TryParse(e.NewValue?.ToString(), out int result) && !string.IsNullOrWhiteSpace(e.NewValue))
                    {
                        e.Cancel = true;
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "輸入之數值，必須為數字且不可為負數!", EnumerableExtensions.GetClassDisplayNameDictionary<AdvanceSettings>().Where(x => x.Key == nameof(AdvanceSettings.DownloadWaitingTimeOutSeconds)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
                    }
                }
            };
            radButton_AdvanceSettings_Save.Click += RadButton_AdvanceSettings_Save_Click;
            radButton_AdvanceSettings_RestoreDefault.Click += (sender, e) =>
            {
                AdvanceSettings.DownloadWaitingTimeOutSeconds = 30000;
                radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Text = AdvanceSettings.DownloadWaitingTimeOutSeconds.ToString();
                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "回復預設值成功!", EnumerableExtensions.GetClassDisplayNameDictionary<AdvanceSettings>().Where(x => x.Key == nameof(AdvanceSettings.DownloadWaitingTimeOutSeconds)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);

            };
            radCheckBox_ActivateAdvanceSettings.CheckStateChanged += RadCheckBox_ActivateAdvanceSettings_CheckStateChanged;

            #endregion

            radButton_SaveFileDialog.Click += RadButton_SaveFileDialog_Click;

            radButton_SensorNovelName.Click += RadButton_SensorNovelName_Click;

            radButton_Settings_ClearTextBoxValue.Click += RadButton_Settings_ClearTextBoxValue_Click;

            radButton_Download.Click += RadButton_Download_Click;
            radButton_PreviewDownload.Click += RadButton_Download_Click;
            radButton_Download_Cancel.Click += RadButton_Download_Cancel_Click;

            radButton_DefaultSettings_1.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_2.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_3.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_4.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_5.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_6.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_7.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_8.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_9.Click += RadButton_DefaultSettings_Click;
            radButton_DefaultSettings_10.Click += RadButton_DefaultSettings_Click;
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
                if (!string.IsNullOrWhiteSpace(radTextBoxControl_SaveFilePath.Text))
                {
                    FilePath = radTextBoxControl_SaveFilePath.Text;
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
                    radTextBoxControl_SaveFilePath.Text = radOpenFolderDialog.FileName;
                }

                //radOpenFolderDialog.OpenFolderDialogForm.Filter = "文本 檔案|*.txt";

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

        private void RadButton_AdvanceSettings_Save_Click(object sender, EventArgs e)
        {
            if (int.TryParse(radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Text, out var ms))
            {
                if (ms < 1000)
                {
                    RadMessageBox.Show("下載逾時毫秒不可小於1000!", EnumerableExtensions.GetClassDisplayNameDictionary<AdvanceSettings>().Where(x => x.Key == nameof(AdvanceSettings.DownloadWaitingTimeOutSeconds)).FirstOrDefault().Value, MessageBoxButtons.OK, RadMessageIcon.Info);
                    ms = 1000;
                }
                ModifyXmlFile(nameof(AdvanceSettings.DownloadWaitingTimeOutSeconds), ms.ToString());
                radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Text = ms.ToString();
                AdvanceSettings.DownloadWaitingTimeOutSeconds = ms;
                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "儲存成功!", EnumerableExtensions.GetClassDisplayNameDictionary<AdvanceSettings>().Where(x => x.Key == nameof(AdvanceSettings.DownloadWaitingTimeOutSeconds)).FirstOrDefault().Value, -1, AlertScreenPosition.BottomRight);
            }
        }

        private void RadCheckBox_ActivateAdvanceSettings_CheckStateChanged(object sender, EventArgs e)
        {
            if (sender is RadCheckBox rcb)
            {
                var RcbCheckState = rcb.CheckState == CheckState.Checked;

                radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Enabled = RcbCheckState;
                radButton_AdvanceSettings_Save.Enabled = RcbCheckState;
                radButton_AdvanceSettings_RestoreDefault.Enabled = RcbCheckState;

            }

        }

        private void RadButton_Download_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (bgw_DownloadQuery.Any(x => x.IsBusy))
                {
                    foreach (BackgroundWorker item in bgw_DownloadQuery)
                    {
                        item.CancelAsync();
                    }
                    radLabel_Main_Status.Text = "多執行續下載已經終止!";
                    radProgressBar_Download.Value1 = 0;
                    radProgressBar_Download.ProgressBarElement.Text = "";
                }
                ControlEnabledStatus(nameof(RadTextBoxControl), true);
                ControlEnabledStatus(nameof(RadButton), true);
                ControlEnabledStatus(nameof(RadRadioButton), true);
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
        /// Control Enabled Status
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="Status"></param>
        private void ControlEnabledStatus(string ControlName, bool Status = true)
        {
            switch (ControlName)
            {
                case nameof(RadTextBoxControl):
                    foreach (RadTextBoxControl rtbc in _utility.GetAllControl(this, typeof(RadTextBoxControl)))
                    {
                        rtbc.Enabled = Status;
                    }
                    break;
                case nameof(RadButton):
                    foreach (RadButton rbtn in _utility.GetAllControl(this, typeof(RadButton)))
                    {
                        rbtn.Enabled = Status;
                    }
                    break;
                case nameof(RadRadioButton):
                    foreach (RadRadioButton rrb in _utility.GetAllControl(this, typeof(RadRadioButton)))
                    {
                        rrb.Enabled = Status;
                    }
                    break;
                default:
                    break;
            }



        }


        /// <summary>
        /// 經由URL下載抓取小說名稱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_SensorNovelName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(radTextBoxControl_Url.Text))
            {
                var CheckURLList = radTextBoxControl_Url.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                if (CheckURLList != null && CheckURLList.Length >= 1)
                {
                    Regex regex = new Regex(@"^(http|https)://?\S*$", RegexOptions.IgnoreCase);
                    Match m = regex.Match(CheckURLList[0]);
                    if (!m.Success)
                    {
                        RadMessageBox.Show($"小說下載URL網址不合法，請重新檢查！", "URL網址檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        var URL = "";
                        if (radRadioButton_ContinuedUrl.CheckState == CheckState.Checked)
                        {
                            if (string.IsNullOrWhiteSpace(radTextBoxControl_PageStart.Text))
                            {
                                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "參數不可為空!", "連續網址-起始參數", -1, AlertScreenPosition.BottomRight);
                                return;
                            }
                            if (string.IsNullOrWhiteSpace(radTextBoxControl_PageType.Text))
                            {
                                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "參數不可為空!", "連續網址-副檔名", -1, AlertScreenPosition.BottomRight);
                                return;
                            }
                            URL = CheckURLList[0] + radTextBoxControl_PageStart.Text + "." + radTextBoxControl_PageType.Text;
                        }
                        else
                        {
                            URL = CheckURLList[0];
                        }

                        if (!string.IsNullOrWhiteSpace(radTextBoxControl_NovelName_Start.Text) &&
                                        !string.IsNullOrWhiteSpace(radTextBoxControl_NovelName_End.Text))
                        {
                            Cursor = Cursors.WaitCursor;
                            try
                            {
                                //URL = CheckURLList[0] + radTextBoxControl_PageStart.Text + "." + radTextBoxControl_PageType.Text;

                                HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                                if (request != null)
                                {
                                    request.Method = "GET";
                                    request.ContentType = "text/html; charset=UTF-8";
                                    //request.Accept = "application/json";
                                    request.Timeout = AdvanceSettings.DownloadWaitingTimeOutSeconds;


                                    using (WebResponse response = request.GetResponse())
                                    {
                                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                        {

                                            var resultdata = sr.ReadToEnd();
                                            if (!string.IsNullOrWhiteSpace(resultdata))
                                            {
                                                NovelName_GLOBLE = string.Empty;
                                                BindSettings();
                                                RegexHtmlElement(resultdata);
                                                if (!string.IsNullOrWhiteSpace(NovelName_GLOBLE))
                                                {
                                                    radTextBoxControl_SaveFileName.Text = NovelName_GLOBLE + ".txt";
                                                }
                                                else
                                                {
                                                    _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "小說名稱轉換失敗!", "小說名稱抓取", -1, AlertScreenPosition.BottomRight);
                                                }
                                            }
                                            else
                                            {
                                                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "小說資料讀取失敗!", "小說名稱抓取", -1, AlertScreenPosition.BottomRight);
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "小說資料獲取失敗!", "小說名稱抓取", -1, AlertScreenPosition.BottomRight);
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message == "作業逾時")
                                {
                                    RadMessageBox.Show($"與 {URL}\n連接逾時!請確認該網站是否存在!", "網站連接逾時", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }
                                else if (ex.Message.Contains("遠端伺服器傳回一個錯誤: (404) 找不到。"))
                                {
                                    RadMessageBox.Show($"於 {URL} \n下找不到該網站!請確認該網址是否正確!", "網站連接逾時", MessageBoxButtons.OK, RadMessageIcon.Error);
                                    return;
                                }
                                throw;
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "小說名稱\"起始\"以及\"結束\"標籤，皆不可為空!", "網頁抓取屬性", -1, AlertScreenPosition.BottomRight);
                        }
                    }

                }

            }
            else
            {
                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "小說下載網址不可為空!", "小說下載網址", -1, AlertScreenPosition.BottomRight);

            }
        }

        private void RadButton_Download_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is RadButton rbtn)
                {
                    //檢測網頁參數是否填入
                    if (string.IsNullOrWhiteSpace(radTextBoxControl_Title_Start.Text) ||
                        string.IsNullOrWhiteSpace(radTextBoxControl_Title_End.Text) ||
                        string.IsNullOrWhiteSpace(radTextBoxControl_Content_Start.Text) ||
                        string.IsNullOrWhiteSpace(radTextBoxControl_Content_End.Text))
                    {
                        if (DialogResult.Cancel == RadMessageBox.Show($"檢測到\n" +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Title_Start.Text) ? "標題文字起始標籤, " : string.Empty) + Environment.NewLine +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Title_End.Text) ? "標題文字結束標籤, " : string.Empty) + Environment.NewLine +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Content_Start.Text) ? "內容文字起始標籤, " : string.Empty) + Environment.NewLine +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Content_End.Text) ? "內容文字結束標籤" : string.Empty) + "\n為空，是否繼續下載?", "網頁參數缺失", MessageBoxButtons.OKCancel, RadMessageIcon.Question))
                        {
                            return;
                        }
                    }
                    //檢測檔案路徑是否合法
                    if (!string.IsNullOrWhiteSpace(radTextBoxControl_SaveFilePath.Text) &&
                        !string.IsNullOrWhiteSpace(radTextBoxControl_SaveFileName.Text))
                    {
                        Regex regex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
                        Match m = regex.Match(radTextBoxControl_SaveFilePath.Text);
                        if (!m.Success)
                        {
                            RadMessageBox.Show("非法的檔案儲存路徑，請重新選擇或輸入！", "檔案儲存路徑檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            return;
                        }
                        regex = new Regex(@"^[^\/\:\*\?\""\<\>\|\,]+$");
                        m = regex.Match(radTextBoxControl_SaveFileName.Text);
                        if (!m.Success)
                        {
                            RadMessageBox.Show("請勿在檔名中包含\\ / : * ？ \" < > |等字元，請重新輸入有效檔名！", "檔案儲存名稱檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        RadMessageBox.Show("儲存檔案路徑或是檔案名稱不可為空!", "檔案儲存路徑及名稱檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        return;
                    }

                    if (Directory.Exists(radTextBoxControl_SaveFilePath.Text))
                    {
                        if (File.Exists(radTextBoxControl_SaveFileName.Text))
                        {
                            if (DialogResult.Cancel == RadMessageBox.Show($"檢測到該目錄\n\"{radTextBoxControl_SaveFilePath.Text}\"\n下，檔案\"{radTextBoxControl_SaveFileName.Text}\"已經存在，是否進行覆蓋?", "檔案存在檢測", MessageBoxButtons.OKCancel, RadMessageIcon.Exclamation))
                            {
                                return;
                            }
                            IsDeleteFileWhenTargetFileExist = true;
                        }
                    }


                    switch (rbtn.Name)
                    {
                        case nameof(radButton_PreviewDownload):
                            if (string.IsNullOrWhiteSpace(radTextBoxControl_PreviewUrl.Text))
                            {
                                RadMessageBox.Show("\"單頁網址\"，不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                return;
                            }
                            if (!string.IsNullOrWhiteSpace(radTextBoxControl_PreviewUrl.Text))
                            {
                                Regex regex = new Regex(@"^(http|https)://?\S*$", RegexOptions.IgnoreCase);
                                Match m = regex.Match(radTextBoxControl_PreviewUrl.Text);
                                if (!m.Success)
                                {
                                    RadMessageBox.Show("URL網址不合法，請重新輸入！", "URL網址檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }
                            }

                            BindSettings();
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                HttpWebRequest request = WebRequest.Create(radTextBoxControl_PreviewUrl.Text) as HttpWebRequest;
                                if (request != null)
                                {
                                    request.Method = "GET";
                                    request.ContentType = "text/html; charset=UTF-8";
                                    //request.Accept = "application/json";
                                    request.Timeout = AdvanceSettings.DownloadWaitingTimeOutSeconds;

                                    using (WebResponse response = request.GetResponse())
                                    {
                                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                        {
                                            var resultdata = sr.ReadToEnd();
                                            if (!string.IsNullOrWhiteSpace(resultdata))
                                            {

                                                radTextBoxControl_PreviewText.Text = RegexHtmlElement(resultdata);
                                                //radTextBoxControl_PreviewText.Text = StripHTML(resultdata);
                                                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "預覽TXT轉換成功!", "小說下載轉換_預覽", -1, AlertScreenPosition.BottomRight);
                                                radLabel_Preview_Status.Text = "預覽TXT轉換成功!";
                                            }
                                            else
                                            {
                                                radLabel_Preview_Status.Text = "預覽TXT轉換失敗!";
                                            }
                                        }
                                    }

                                }
                            }
                            catch(Exception ex)
                            {
                                radLabel_Preview_Status.Text = "預覽TXT轉換失敗!";
                                if (ex.Message == "作業逾時")
                                {
                                    RadMessageBox.Show($"與 {radTextBoxControl_PreviewUrl.Text}\n連接逾時!請確認該網站是否存在!", "網站連接逾時", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }
                                throw;
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                            }
                            break;
                        case nameof(radButton_Download):
                            if (string.IsNullOrWhiteSpace(radTextBoxControl_Url.Text))
                            {
                                RadMessageBox.Show("\"小說下載網址\"，不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                return;
                            }
                            var CheckURLList = radTextBoxControl_Url.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            if (CheckURLList != null && CheckURLList.Length > 0)
                            {
                                Regex regex = new Regex(@"^(http|https)://?\S*$", RegexOptions.IgnoreCase);
                                var ErrorUrlMsg = "";
                                int ErrorCount = 0;
                                foreach (var url in CheckURLList)
                                {
                                    Match m = regex.Match(url);
                                    if (!m.Success)
                                    {
                                        ErrorUrlMsg += url + Environment.NewLine;
                                        ErrorCount++;
                                    }
                                }
                                if (ErrorUrlMsg.Length > 0)
                                {
                                    RadMessageBox.Show($"URL網址中有 {ErrorCount} 個不合法，請重新檢查！不合法清單在詳細資料中", "URL網址檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation, ErrorUrlMsg);
                                    return;
                                }
                            }

                            if (radRadioButton_ContinuedUrl.CheckState == CheckState.Unchecked &&
                                radRadioButton_NoneContinuedUrl.CheckState == CheckState.Unchecked)
                            {
                                RadMessageBox.Show("未選擇網址相關參數!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                //_desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "未選擇網址相關參數!", "網址相關參數缺失", -1, AlertScreenPosition.BottomRight);
                                return;
                            }



                            if (radRadioButton_ContinuedUrl.CheckState == CheckState.Checked)
                            {
                                if (string.IsNullOrWhiteSpace(radTextBoxControl_PageStart.Text))
                                {
                                    RadMessageBox.Show("\"起始\"，參數不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }
                                else if (string.IsNullOrWhiteSpace(radTextBoxControl_PageEnd.Text))
                                {
                                    RadMessageBox.Show("\"結束\"，參數不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }
                                else if (string.IsNullOrWhiteSpace(radTextBoxControl_PageType.Text))
                                {
                                    RadMessageBox.Show("\"副檔名\"，參數不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }

                                decimal PageCount = 0M;
                                if (decimal.TryParse(radTextBoxControl_PageStart.Text, out decimal pageStart))
                                {
                                    if (decimal.TryParse(radTextBoxControl_PageEnd.Text, out decimal pageEnd))
                                    {
                                        PageCount = pageEnd - pageStart;
                                        if (PageCount >= 0)
                                        {
                                            DownloadUrlList = new List<string>();
                                            for (decimal index = pageStart; index <= pageEnd; index++)
                                            {
                                                DownloadUrlList.Add(radTextBoxControl_Url.Text + index + "." + radTextBoxControl_PageType.Text);
                                            }
                                            if (string.IsNullOrWhiteSpace(NovelName_GLOBLE))
                                            {
                                                radButton_SensorNovelName.PerformClick();//預先抓取小說名稱
                                            }

                                            if (DialogResult.Cancel == RadMessageBox.Show($"小說名稱:{NovelName_GLOBLE}\n預計下載章節數:{PageCount + 1}章.\n預覽小說下載網址:\n{DownloadUrlList?.FirstOrDefault()}\n\n請確認資訊是否正確，並進行下載?", "小說章節總數", MessageBoxButtons.OKCancel, RadMessageIcon.Info))
                                            {
                                                return;
                                            }
                                            //_desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"共{PageCount + 1}章.", "小說章節總數", -1, AlertScreenPosition.BottomRight);
                                        }
                                        else
                                        {
                                            RadMessageBox.Show($"\"結束:{pageEnd}\" - \"起始:{pageStart}\" = {PageCount} ，兩者相減不可為負數!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        RadMessageBox.Show("\"結束\"，參數須為數字!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                        return;
                                    }
                                }
                                else
                                {
                                    RadMessageBox.Show("\"起始\"，參數須為數字!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }

                                if (!DownloadUrlList.Any())
                                {
                                    RadMessageBox.Show("無下載網址!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    var urlStr = "";
                                    foreach (var item in DownloadUrlList)
                                    {
                                        urlStr += item + Environment.NewLine;
                                    }
                                    //radTextBoxControl_Url.Text = urlStr;
                                    BindSettings();

                                    var URLList = urlStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                                    //預設核心數(不可小於3)
                                    var ThreadCore = 16;

                                    if (URLList.Length > 0)
                                    {
                                        var ListCountMod = URLList.Length % (ThreadCore - 1); //算出餘數 
                                        var ListCount = (URLList.Length - ListCountMod) / (ThreadCore - 1);//平均每個Thread下載的URL,第16個拿來下載餘數

                                        DownloadNovelURLList = new List<(int ThreadSerial, List<string>)>();

                                        List<string> downloadURLList = new List<string>();
                                        var threadNum = 1;
                                        for (var index = 0; index < (URLList.Length - ListCountMod); index++)
                                        {
                                            if ((index) == ListCount * threadNum)
                                            {
                                                DownloadNovelURLList.Add((threadNum, downloadURLList.ToList()));
                                                downloadURLList = new List<string>();
                                                threadNum++;
                                            }
                                            downloadURLList.Add(URLList[index]);
                                        }
                                        DownloadNovelURLList.Add((threadNum, downloadURLList.ToList())); //第15個Thread
                                        downloadURLList = new List<string>();
                                        for (var i = ListCount * (ThreadCore - 1); i < URLList.Length; i++)
                                        {
                                            downloadURLList.Add(URLList[i]);
                                        }
                                        DownloadNovelURLList.Add((threadNum + 1, downloadURLList.ToList())); //第16個Thread


                                        DownloadNovelTextList = new List<(int ThreadSearial, bool DownloadFinish, List<StringBuilder> DownloadTextList)>();
                                        //初始化
                                        for (int it = 1; it <= (ThreadCore); it++)
                                        {
                                            DownloadNovelTextList.Add((it, false, new List<StringBuilder>(8192)));
                                        }


                                        //鎖定所有控制項
                                        ControlEnabledStatus(nameof(RadTextBoxControl), false);
                                        ControlEnabledStatus(nameof(RadButton), false);
                                        ControlEnabledStatus(nameof(RadRadioButton), false);
                                        radButton_Download_Cancel.Enabled = true;

                                        ResetProgressBarValueAndPermeter();
                                        Cursor = Cursors.WaitCursor;
                                        List<LoadingThread> loadingThreads = new List<LoadingThread>()
                                        {
                                            LoadingThread.Thread1,
                                            LoadingThread.Thread2,
                                            LoadingThread.Thread3,
                                            LoadingThread.Thread4,
                                            LoadingThread.Thread5,
                                            LoadingThread.Thread6,
                                            LoadingThread.Thread7,
                                            LoadingThread.Thread8,
                                            LoadingThread.Thread9,
                                            LoadingThread.Thread10,
                                            LoadingThread.Thread11,
                                            LoadingThread.Thread12,
                                            LoadingThread.Thread13,
                                            LoadingThread.Thread14,
                                            LoadingThread.Thread15,
                                            LoadingThread.Thread16
                                        };
                                        bgw_DownloadQuery = new BackgroundWorker[loadingThreads.Count()];
                                        for (int i = 0; i < loadingThreads.Count(); i++)
                                        {
                                            bgw_DownloadQuery[i] = new BackgroundWorker();
                                            bgw_DownloadQuery[i].WorkerReportsProgress = true;
                                            bgw_DownloadQuery[i].DoWork += new DoWorkEventHandler(Bgw_Download_Dowork);
                                            bgw_DownloadQuery[i].ProgressChanged += new ProgressChangedEventHandler(Bgw_Download_ProgressChanged);
                                            bgw_DownloadQuery[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_Download_RunWorkerCompleted);
                                            bgw_DownloadQuery[i].WorkerSupportsCancellation = true;
                                            bgw_DownloadQuery[i].RunWorkerAsync(loadingThreads[i]);
                                        }
                                    }
                                }
                            }
                            else if (radRadioButton_NoneContinuedUrl.CheckState == CheckState.Checked)
                            {

                                var URLList = radTextBoxControl_Url.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); ;
                                if (URLList.Length > 0)
                                {
                                    BindSettings();

                                    //預設核心數(不可小於3)
                                    var ThreadCore = 16;

                                    if (URLList.Length > 0)
                                    {
                                        var ListCountMod = URLList.Length % (ThreadCore - 1); //算出餘數 
                                        var ListCount = (URLList.Length - ListCountMod) / (ThreadCore - 1);//平均每個Thread下載的URL,第16個拿來下載餘數

                                        DownloadNovelURLList = new List<(int ThreadSerial, List<string>)>();

                                        List<string> downloadURLList = new List<string>();
                                        var threadNum = 1;
                                        for (var index = 0; index < (URLList.Length - ListCountMod); index++)
                                        {
                                            if ((index) == ListCount * threadNum)
                                            {
                                                DownloadNovelURLList.Add((threadNum, downloadURLList.ToList()));
                                                downloadURLList = new List<string>();
                                                threadNum++;
                                            }
                                            downloadURLList.Add(URLList[index]);
                                        }
                                        DownloadNovelURLList.Add((threadNum, downloadURLList.ToList())); //第15個Thread
                                        downloadURLList = new List<string>();
                                        for (var i = ListCount * (ThreadCore - 1); i < URLList.Length; i++)
                                        {
                                            downloadURLList.Add(URLList[i]);
                                        }
                                        DownloadNovelURLList.Add((threadNum + 1, downloadURLList.ToList())); //第16個Thread


                                        DownloadNovelTextList = new List<(int ThreadSearial, bool DownloadFinish, List<StringBuilder> DownloadTextList)>();
                                        //初始化
                                        for (int it = 1; it <= (ThreadCore); it++)
                                        {
                                            DownloadNovelTextList.Add((it, false, new List<StringBuilder>(8192)));
                                        }

                                        //鎖定所有控制項
                                        ControlEnabledStatus(nameof(RadTextBoxControl), false);
                                        ControlEnabledStatus(nameof(RadButton), false);
                                        ControlEnabledStatus(nameof(RadRadioButton), false);
                                        radButton_Download_Cancel.Enabled = true;

                                        ResetProgressBarValueAndPermeter();
                                        Cursor = Cursors.WaitCursor;
                                        List<LoadingThread> loadingThreads = new List<LoadingThread>()
                                        {
                                            LoadingThread.Thread1,
                                            LoadingThread.Thread2,
                                            LoadingThread.Thread3,
                                            LoadingThread.Thread4,
                                            LoadingThread.Thread5,
                                            LoadingThread.Thread6,
                                            LoadingThread.Thread7,
                                            LoadingThread.Thread8,
                                            LoadingThread.Thread9,
                                            LoadingThread.Thread10,
                                            LoadingThread.Thread11,
                                            LoadingThread.Thread12,
                                            LoadingThread.Thread13,
                                            LoadingThread.Thread14,
                                            LoadingThread.Thread15,
                                            LoadingThread.Thread16
                                        };
                                        bgw_DownloadQuery = new BackgroundWorker[loadingThreads.Count()];
                                        for (int i = 0; i < loadingThreads.Count(); i++)
                                        {
                                            bgw_DownloadQuery[i] = new BackgroundWorker();
                                            bgw_DownloadQuery[i].WorkerReportsProgress = true;
                                            bgw_DownloadQuery[i].DoWork += new DoWorkEventHandler(Bgw_Download_Dowork);
                                            bgw_DownloadQuery[i].ProgressChanged += new ProgressChangedEventHandler(Bgw_Download_ProgressChanged);
                                            bgw_DownloadQuery[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_Download_RunWorkerCompleted);
                                            bgw_DownloadQuery[i].WorkerSupportsCancellation = true;
                                            bgw_DownloadQuery[i].RunWorkerAsync(loadingThreads[i]);
                                        }
                                    }
                                }
                            }
                            break;
                    }
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
        /// 重置Prograss Bar 相關參數
        /// </summary>
        private void ResetProgressBarValueAndPermeter()
        {
            progressBarValue = 0;
            radProgressBar_Download.Value1 = 0;
            radProgressBar_Download.ProgressBarElement.Text = "0%";
            IsShowAlert = false;
            radLabel_Main_Status.Text = "準備進行下載...";
        }

        private void Bgw_Download_Dowork(object sender, DoWorkEventArgs e)
        {
            try
            {
                NovelDownloadProcess((LoadingThread)e.Argument);
                if (((BackgroundWorker)sender).CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                ((BackgroundWorker)sender).ReportProgress(progressBarValue, (LoadingThread)e.Argument);
                e.Result = (LoadingThread)e.Argument;
            }
            catch
            {
                foreach (BackgroundWorker item in bgw_DownloadQuery)
                {
                    item.CancelAsync();
                }
                ((BackgroundWorker)sender).ReportProgress(progressBarValue, LoadingThread.ExceptionError);
                throw;
            }
        }

        private void Bgw_Download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (e.UserState is LoadingThread loadingStatus)
                {
                    if (loadingStatus != LoadingThread.ExceptionError)
                    {
                        radProgressBar_Download.Value1 = e.ProgressPercentage;
                        radProgressBar_Download.ProgressBarElement.Text = e.ProgressPercentage + "%";
                    }
                    else
                    {
                        _utility.radMsgboxFont();
                        if (!IsShowAlert)
                        {
                            ControlEnabledStatus(nameof(RadTextBoxControl), true);
                            ControlEnabledStatus(nameof(RadButton), true);
                            ControlEnabledStatus(nameof(RadRadioButton), true);

                            radLabel_Main_Status.Text = "下載出現錯誤，請檢查網址是否皆正確!";
                            IsShowAlert = true;
                            RadMessageBox.Show("下載出現錯誤，請檢查網址是否皆正確!", "系統提示", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _utility.radMsgboxFont();
            }
        }

        private void Bgw_Download_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!e.Cancelled)
                {
                    if (e.Error == null)
                    {
                        MappingData(e.Result);
                        if (bgw_DownloadQuery.Any(x => x.IsBusy) == false)
                        {
                            //_desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"健保IC卡一次讀取全部資料\r\n總共執行{_soapFunc.TimeDifferent(ReadDTStart, ReadDTEnd, true, "健保IC卡一次讀取")}", "執行時間", 5, AlertScreenPosition.BottomRight);
                            if (bgw_DownloadQuery.Any(x => x.CancellationPending == true))
                            {
                                radLabel_Main_Status.Text = "下載失敗! 尚有資料未完成下載，請重新下載!";
                                Cursor = Cursors.Default;
                            }
                            else
                            {


                                if (DownloadNovelTextList.Any(x => x.DownloadFinish))
                                {
                                    radProgressBar_Download.Value1 = 100;
                                    radProgressBar_Download.ProgressBarElement.Text = "100%";
                                    //下載全部完成
                                    decimal PageCount = 0M;
                                    if (decimal.TryParse(radTextBoxControl_PageStart.Text, out decimal pageStart))
                                    {
                                        if (decimal.TryParse(radTextBoxControl_PageEnd.Text, out decimal pageEnd))
                                        {
                                            PageCount = pageEnd - pageStart;
                                        }
                                    }
                                    var AllTextList = string.Empty;
                                    if (!string.IsNullOrWhiteSpace(radTextBoxControl_PageStart.Text) && !string.IsNullOrWhiteSpace(radTextBoxControl_PageEnd.Text))
                                    {
                                        AllTextList += NovelName_GLOBLE + $"  第1章~第{PageCount}章" + Environment.NewLine + Environment.NewLine;
                                    }
                                    else
                                    {
                                        AllTextList += NovelName_GLOBLE + Environment.NewLine + Environment.NewLine;
                                    }
                                    foreach (var item in DownloadNovelTextList.OrderBy(x=>x.ThreadSearial))
                                    {
                                        foreach (var strList in item.DownloadTextList)
                                        {
                                            AllTextList += RegexHtmlElement(strList?.ToString());
                                        }
                                    }

                                    var IsOutputTextFile = _utility.TXT_WriteStringArray(radTextBoxControl_SaveFilePath.Text, radTextBoxControl_SaveFileName.Text, AllTextList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None), IsDeleteFileWhenTargetFileExist, true);
                                    if (IsOutputTextFile)
                                    {
                                        radLabel_Main_Status.Text = "下載完成! 已經輸出成TXT檔案!";
                                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"{NovelName_GLOBLE}\n下載成功!\nTxT輸出至\n{radTextBoxControl_SaveFilePath.Text + radTextBoxControl_SaveFileName.Text}", "TXT產生成功", 12, AlertScreenPosition.BottomRight);
                                    }
                                    else
                                    {
                                        radLabel_Main_Status.Text = "下載完成! 但輸出TXT檔案失敗!";
                                    }
                                }
                                else
                                {
                                    radLabel_Main_Status.Text = "下載未全部完成!";
                                }

                                //radLabel_Main_Status.Text = "下載完成! 已經輸出成TXT檔案!";
                            }
                            //鎖定所有控制項
                            ControlEnabledStatus(nameof(RadTextBoxControl), true);
                            ControlEnabledStatus(nameof(RadButton), true);
                            ControlEnabledStatus(nameof(RadRadioButton), true);
                            NovelName_GLOBLE = string.Empty;

                        }
                    }
                }
                else
                {
                    //_desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"健保IC卡一次讀取\r\n總共執行{_soapFunc.TimeDifferent(ReadDTStart, ReadDTEnd, true, "健保IC卡一次讀取")}", "讀取時間", 5, AlertScreenPosition.BottomRight);
                    radLabel_Main_Status.Text = "下載失敗! 尚有資料未完成下載，請重新下載!";
                    Cursor = Cursors.Default;
                }
            }
            catch
            {
                throw;
            }
        }
        private void MappingData(object _loadingThread)
        {
            LoadingThread loadingThread = LoadingThread.ExceptionError;
            try
            {
                if (_loadingThread is LoadingThread LT)
                {
                    loadingThread = LT;
                }
                if (loadingThread != LoadingThread.ExceptionError)
                {
                    var temp = DownloadNovelTextList.Where(x => x.ThreadSearial == loadingThread.ToNumberValue()).FirstOrDefault();
                    DownloadNovelTextList.Remove(temp);
                    temp.DownloadFinish = true;
                    DownloadNovelTextList.Add(temp);

                    switch (loadingThread)
                    {
                        case LoadingThread.Thread1:
                        case LoadingThread.Thread2:
                        case LoadingThread.Thread3:
                        case LoadingThread.Thread4:
                        case LoadingThread.Thread5:
                        case LoadingThread.Thread6:
                        case LoadingThread.Thread7:
                        case LoadingThread.Thread8:
                        case LoadingThread.Thread9:
                        case LoadingThread.Thread10:
                        case LoadingThread.Thread11:
                        case LoadingThread.Thread12:
                        case LoadingThread.Thread13:
                        case LoadingThread.Thread14:
                        case LoadingThread.Thread15:
                            progressBarValue += 6;
                            break;
                        case LoadingThread.Thread16:
                            progressBarValue += 4;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private void NovelDownloadProcess(LoadingThread loadingThread)
        {
            try
            {
                switch (loadingThread)
                {
                    case LoadingThread.Thread1:
                    case LoadingThread.Thread2:
                    case LoadingThread.Thread3:
                    case LoadingThread.Thread4:
                    case LoadingThread.Thread5:
                    case LoadingThread.Thread6:
                    case LoadingThread.Thread7:
                    case LoadingThread.Thread8:
                    case LoadingThread.Thread9:
                    case LoadingThread.Thread10:
                    case LoadingThread.Thread11:
                    case LoadingThread.Thread12:
                    case LoadingThread.Thread13:
                    case LoadingThread.Thread14:
                    case LoadingThread.Thread15:
                    case LoadingThread.Thread16:
                        if (DownloadNovelURLList.Any(x => x.ThreadSerial == loadingThread.ToNumberValue()))
                        {
                            var DownloadListTuple = DownloadNovelURLList.Where(x => x.ThreadSerial == loadingThread.ToNumberValue()).FirstOrDefault();

                            foreach (var item in DownloadListTuple.DownloadUrl)
                            {
                                Thread.Sleep(_utility.RandomNext(300, 500));
                                try
                                {
                                    HttpWebRequest request = WebRequest.Create(item) as HttpWebRequest;
                                    if (request != null)
                                    {
                                        request.Method = "GET";
                                        request.ContentType = "text/html; charset=UTF-8";
                                        //request.Accept = "application/json";
                                        request.Timeout = AdvanceSettings.DownloadWaitingTimeOutSeconds;
                                        using (WebResponse response = request.GetResponse())
                                        {
                                            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                            {
                                                var resultdata = sr.ReadToEnd();
                                                if (!string.IsNullOrWhiteSpace(resultdata))
                                                {
                                                    DownloadNovelTextList.Where(x => x.ThreadSearial == loadingThread.ToNumberValue()).FirstOrDefault().DownloadTextList.Add(new StringBuilder(8192).Append(resultdata));
                                                }

                                            }
                                        }

                                    }

                                }
                                catch
                                {
                                    throw;
                                }

                            }


                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw;
            }

        }


        #region Task 




        #endregion
        private string RegexHtmlElement(string HTML)
        {
            try
            {
                int indexOfTitleStart = -1, indexOfTitleEnd = -1;
                int indexOfContentStart = -1, indexOfContentEnd = -1;
                int indexOfNovelNameStart = -1, indexOfNovelNameEnd = -1;
                string NovelName = "", Title = "", Content = "";
                if (!string.IsNullOrWhiteSpace(HTML))
                {
                    var SearchStartPosition = 0;
                    for (int TS = 0; TS < Settings.Title_Start_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Title_Start, SearchStartPosition);
                    }
                    if (SearchStartPosition == -1)
                    {
                        return string.Empty;
                    }
                    indexOfTitleStart = SearchStartPosition;

                    SearchStartPosition = 0;
                    for (int TS = 0; TS < Settings.Title_End_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Title_End, SearchStartPosition);
                    }
                    if (SearchStartPosition == -1)
                    {
                        return string.Empty;
                    }
                    indexOfTitleEnd = SearchStartPosition;

                    SearchStartPosition = 0;
                    for (int TS = 0; TS < Settings.Content_Start_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Content_Start, SearchStartPosition);
                    }
                    if (SearchStartPosition == -1)
                    {
                        return string.Empty;
                    }
                    indexOfContentStart = SearchStartPosition;

                    SearchStartPosition = indexOfContentStart;
                    for (int TS = 0; TS < Settings.Content_End_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Content_End, SearchStartPosition);
                    }
                    if (SearchStartPosition == -1)
                    {
                        return string.Empty;
                    }
                    indexOfContentEnd = SearchStartPosition;

                    if (string.IsNullOrWhiteSpace(NovelName_GLOBLE))
                    {
                        SearchStartPosition = 0;
                        indexOfNovelNameStart = HTML.IndexOf(Settings.NovelName_Start, SearchStartPosition);

                        SearchStartPosition = 0;
                        indexOfNovelNameEnd = HTML.IndexOf(Settings.NovelName_End, SearchStartPosition);

                    }


                    //indexOfTitleStart = HTML.IndexOf(Settings.Title_Start);
                    //indexOfTitleEnd = HTML.IndexOf(Settings.Title_End, indexOfTitleStart != -1 ? indexOfTitleStart : 0);
                    //indexOfContentStart = HTML.IndexOf(Settings.Content_Start);
                    //indexOfContentEnd = HTML.IndexOf(Settings.Content_End, indexOfContentStart != -1 ? indexOfContentStart : 0);
                    if (string.IsNullOrWhiteSpace(NovelName_GLOBLE))
                    {
                        if (indexOfNovelNameStart != -1 && indexOfNovelNameEnd != -1)
                        {
                            if (indexOfNovelNameEnd - indexOfNovelNameStart > 0)
                            {
                                NovelName = HTML.Substring(indexOfNovelNameStart + Settings.NovelName_Start.Length, (indexOfNovelNameEnd - indexOfNovelNameStart) - Settings.NovelName_Start.Length);
                            }
                            else
                            {
                                NovelName = HTML.Substring(indexOfNovelNameStart, 10);
                            }
                            Regex removeHTMLTag = new Regex(@"<[^>]+>", RegexOptions.IgnoreCase);

                            NovelName = removeHTMLTag.Replace(NovelName, @"");
                            NovelName = NovelName.Replace("《", "(");
                            NovelName = NovelName.Replace("》", ")");
                            NovelName = NovelName.Replace("（", "(");
                            NovelName = NovelName.Replace("）", ")");
                            NovelName_GLOBLE = NovelName;
                        }
                    }

                    if (indexOfTitleStart != -1 && indexOfTitleEnd != -1)
                    {
                        if (indexOfTitleEnd - indexOfTitleStart > 0)
                        {
                            Title = HTML.Substring(indexOfTitleStart + Settings.Title_Start.Length, (indexOfTitleEnd - indexOfTitleStart) - Settings.Title_Start.Length);
                        }
                        else
                        {
                            Title = HTML.Substring(indexOfTitleStart, 10);
                        }
                    }
                    if (indexOfContentStart != -1 && indexOfContentEnd != -1)
                    {
                        if (indexOfContentEnd - indexOfContentStart > 0)
                        {
                            Content = HTML.Substring(indexOfContentStart + Settings.Content_Start.Length, (indexOfContentEnd - indexOfContentStart) - Settings.Content_Start.Length);

                            List<string> NewLineList = new List<string>();
                            if (!string.IsNullOrWhiteSpace(Settings.Content_NewLine))
                            {
                                var temp = Settings.Content_NewLine.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (temp.Length > 0)
                                {
                                    NewLineList.AddRange(temp);
                                }

                            }
                            List<string> WhiteSpaceList = new List<string>();
                            if (!string.IsNullOrWhiteSpace(Settings.Content_WhiteSpace))
                            {
                                var temp = Settings.Content_WhiteSpace.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (temp.Length > 0)
                                {
                                    WhiteSpaceList.AddRange(temp);
                                }
                            }
                            foreach (var whiteSpace in WhiteSpaceList)
                            {
                                Content = Content.Replace(whiteSpace, string.Empty);
                            }
                            foreach (var newLine in NewLineList)
                            {
                                Content = Content.Replace(Settings.Content_NewLine, Environment.NewLine);
                            }
                        }
                        else
                        {
                            Content = HTML.Substring(indexOfContentStart, 10);

                        }
                    }
                }
                return Title + Environment.NewLine + Content + Environment.NewLine;
            }
            catch
            {
                throw;
            }
        }

        #region Default settings Buttons
        private void RadButton_DefaultSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is RadButton rbtn)
                {
                    var SplitName = rbtn.Name.Split('_');
                    if (SplitName.Length == 3)
                    {
                        if (LoadFromXmlData.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Any(x => x.ButtonSerialNumber.ToString() == SplitName[2]))
                        {
                            var XmlData = LoadFromXmlData.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton.Where(x => x.ButtonSerialNumber.ToString() == SplitName[2]).FirstOrDefault();
                            radRadioButton_ContinuedUrl.CheckState = CheckState.Checked;
                            radTextBoxControl_Url.Text = XmlData.ButtonUrl;
                            radTextBoxControl_PageType.Text = XmlData.PageType;
                            radTextBoxControl_Title_Start.Text = XmlData.Title_Start;
                            radTextBoxControl_Title_End.Text = XmlData.Title_End;
                            radTextBoxControl_Title_Start_SearchFlag.Text = XmlData.Title_Start_SerachFlag.ToString();
                            radTextBoxControl_Title_End_SearchFlag.Text = XmlData.Title_End_SerachFlag.ToString();
                            radTextBoxControl_Content_Start.Text = XmlData.Content_Start;
                            radTextBoxControl_Content_End.Text = XmlData.Content_End;
                            radTextBoxControl_Content_Start_SearchFlag.Text = XmlData.Content_Start_SerachFlag.ToString();
                            radTextBoxControl_Content_End_SearchFlag.Text = XmlData.Content_End_SerachFlag.ToString();
                            radTextBoxControl_Content_NewLine.Text = XmlData.Content_NewLine;
                            radTextBoxControl_Content_WhiteSpace.Text = XmlData.Content_WhiteSpace;
                            radTextBoxControl_NovelName_Start.Text = XmlData.NovelName_Start;
                            radTextBoxControl_NovelName_End.Text = XmlData.NovelName_End;
                            if (!string.IsNullOrWhiteSpace(XmlData.NovelTextFileSavePath))
                            {
                                radTextBoxControl_SaveFilePath.Text = XmlData.NovelTextFileSavePath;
                            }
                            //BindSettings();
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
        /// <summary>
        /// 綁定Settings
        /// </summary>
        private void BindSettings()
        {
            Settings.Title_Start = radTextBoxControl_Title_Start.Text;
            Settings.Title_Start_SerachFlag = int.TryParse(radTextBoxControl_Title_Start_SearchFlag.Text, out int titleStart) ? (titleStart > 0 ? titleStart : 1) : 1;
            Settings.Title_End = radTextBoxControl_Title_End.Text;
            Settings.Title_End_SerachFlag = int.TryParse(radTextBoxControl_Title_Start_SearchFlag.Text, out int titleEnd) ? (titleEnd > 0 ? titleEnd : 1) : 1;
            Settings.Content_Start = radTextBoxControl_Content_Start.Text;
            Settings.Content_Start_SerachFlag = int.TryParse(radTextBoxControl_Content_Start_SearchFlag.Text, out int contentStart) ? (contentStart > 0 ? contentStart : 1) : 1;
            Settings.Content_End = radTextBoxControl_Content_End.Text;
            Settings.Content_End_SerachFlag = int.TryParse(radTextBoxControl_Content_End_SearchFlag.Text, out int contentEnd) ? (contentEnd > 0 ? contentEnd : 1) : 1;
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
        private void ModifyXmlFile(string XMLTagName, object XMLTagValue)
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
                            File.Copy(defaultPath + "\\" + defaultFileName, defaultPath + "\\" + defaultFileName + ".BAK", true);
                            saveXmlDoc.Save(defaultPath + "\\" + defaultFileName);
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"已經舊設定檔案備份為\"{defaultFileName + ".BAK"}\".\n設定檔儲存成功!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                        }
                        else
                        {
                            saveXmlDoc.Save(defaultPath + "\\" + defaultFileName);
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"設定檔儲存成功!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                        }
                    }
                    else
                    {
                        _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, $"舊設定檔讀取失敗，設定檔案未儲存!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                    }
                }
                else
                {
                    _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, $"舊設定檔不存在，設定檔案未儲存!", "XML設定檔儲存", -1, AlertScreenPosition.BottomRight);
                }
            }
            catch
            {
                throw;
            }
        }
        private void LoadXmlFile(bool IsInitLoading = false)
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

                    var Temp = _utility.GetAllControl(this, typeof(RadButton));

                    foreach (RadButton item in Temp)
                    {
                        if (item.Name.Contains("radButton_DefaultSettings"))
                        {
                            DefaultButtonList.Add(item);
                        }
                    }

                    var xml = JsonConvert.DeserializeObject<XmlToJson>(jsonText);
                    if (xml != null)
                    {
                        LoadFromXmlData = new XmlToJson();
                        LoadFromXmlData = xml;
                        foreach (var item in xml.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton)
                        {

                            if (DefaultButtonList.Any(x => x.Name.Split('_')[2] == item.ButtonSerialNumber.ToString()))
                            {
                                var btn = DefaultButtonList.Where(x => x.Name.Split('_')[2] == item.ButtonSerialNumber.ToString()).FirstOrDefault();
                                btn.Text = item.ButtonName;
                                btn.ButtonElement.ToolTipText = item.ButtonUrl;
                            }
                        }
                        AdvanceSettings.DownloadWaitingTimeOutSeconds = xml.NovelDownloader.ADVANCE_SETTINGS.DownloadWaitingTimeOutSeconds;
                        radTextBoxControl_AdvanceSettings_DownloadWaitingSeconds.Text = AdvanceSettings.DownloadWaitingTimeOutSeconds.ToString();
                        if (!IsInitLoading)
                        {
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "設定檔讀取完畢!", "重新讀取Xml設定至網頁參數快速鍵", -1, AlertScreenPosition.BottomRight);
                        }
                    }
                }
                else
                {
                    if (IsInitLoading)
                    {
                        CreateXmlFile(IsInitLoading);
                        LoadXmlFile();
                        //List<RadButton> DefaultButtonList = new List<RadButton>();
                        //var Temp = _utility.GetAllControl(this, typeof(RadButton));
                        //foreach (RadButton item in Temp)
                        //{
                        //    if (item.Name.Contains("radButton_DefaultSettings"))
                        //    {
                        //        DefaultButtonList.Add(item);
                        //    }
                        //}lo
                        //foreach (var item in DefaultNovelXmlSettings())
                        //{

                        //    if (DefaultButtonList.Any(x => x.Name.Split('_')[2] == item.ButtonSerialNumber.ToString()))
                        //    {
                        //        var btn = DefaultButtonList.Where(x => x.Name.Split('_')[2] == item.ButtonSerialNumber.ToString()).FirstOrDefault();
                        //        btn.Text = item.ButtonName;
                        //        btn.ButtonElement.ToolTipText = item.ButtonUrl;
                        //    }
                        //}
                        //_desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "預設Xml設定檔案不存在,故先載入程式預設檔案!\n請確認檔案存在後再去\n\"網頁參數設定->右上角齒輪->重新讀取Xml設定至網頁參數快速鍵\"\n載入設定檔案.", "快捷設定檔案載入", -1, AlertScreenPosition.BottomRight);
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

                var NovelList = DefaultNovelXmlSettings();

                for (int i = 1; i < NovelList.Count + 1; i++)
                {

                    XmlElement HTML_SHORTCUT_BTN_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, nameof(XmlToJson.NovelDownloader.HTML_SHORTCUT_SETTINGS.ShortCutButton), "");
                    CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN_ELement, NovelList[i - 1]);
                }


                //var HTML_SHORTCUT_BTN1_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton1", "");
                //var HTML_SHORTCUT_BTN2_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton2", "");
                //var HTML_SHORTCUT_BTN3_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton3", "");
                //var HTML_SHORTCUT_BTN4_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton4", "");
                //var HTML_SHORTCUT_BTN5_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton5", "");
                //var HTML_SHORTCUT_BTN6_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton6", "");
                //var HTML_SHORTCUT_BTN7_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton7", "");
                //var HTML_SHORTCUT_BTN8_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton8", "");
                //var HTML_SHORTCUT_BTN9_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton9", "");
                //var HTML_SHORTCUT_BTN10_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, "ShortCutButton10", "");

                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN1_ELement, );
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN2_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN3_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN4_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN5_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN6_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN7_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN8_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN9_ELement);
                //CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN10_ELement);


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
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_Start_SerachFlag), NovelData.Title_Start_SerachFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_End), NovelData.Title_End);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Title_End_SerachFlag), NovelData.Title_End_SerachFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_Start), NovelData.Content_Start);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_Start_SerachFlag), NovelData.Content_Start_SerachFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_End), NovelData.Content_End);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_End_SerachFlag), NovelData.Content_End_SerachFlag.ToString());
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_NewLine), NovelData.Content_NewLine);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.Content_WhiteSpace), NovelData.Content_WhiteSpace);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.PageType), NovelData.PageType);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelTextFileSavePath), NovelData.NovelTextFileSavePath);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelName_Start), NovelData.NovelName_Start);
                CreateNode(xmlDoc, ButtonData, nameof(NovelData.NovelName_End), NovelData.NovelName_End);
            }
        }
        /// <summary>
        /// 預設小說網Xml格式與資料
        /// </summary>
        /// <returns></returns>
        private List<ShortCut_Button> DefaultNovelXmlSettings()
        {
            List<ShortCut_Button> NovelList = new List<ShortCut_Button>();
            ShortCut_Button rbtn1 = new ShortCut_Button()
            {
                ButtonSerialNumber = 1,
                ButtonName = "全本小說網",
                ButtonUrl = "http://big5.quanben5.com/n/",
                PageType = "html",
                NovelTextFileSavePath = "",
                Title_Start = @"<h1 class=""title1"">",
                Title_Start_SerachFlag = 1,
                Title_End = @"</h1>",
                Title_End_SerachFlag = 1,
                Content_Start = @"<div id=""content"">",
                Content_Start_SerachFlag = 1,
                Content_End = @"</div>",
                Content_End_SerachFlag = 1,
                Content_NewLine = @"</p>",
                Content_WhiteSpace = @"<p>,<!--PAGE 1-->,<!--PAGE 2-->,<!--PAGE 3-->,<!--PAGE 4-->,<!--PAGE 5-->",
                NovelName_Start = @"<span>",
                NovelName_End = @"</span>"
            };
            ShortCut_Button rbtn2 = new ShortCut_Button()
            {
                ButtonSerialNumber = 2,
                ButtonName = "全本小說網",
                ButtonUrl = "http://big5.quanben-xiaoshuo.com/n/",
                PageType = "html",
                NovelTextFileSavePath = "",
                Title_Start = @"<h1 class=""title"" itemprop=""name"">",
                Title_Start_SerachFlag = 1,
                Title_End = @"</h1>",
                Title_End_SerachFlag = 1,
                Content_Start = @"<div itemprop=""articleBody"" class=""articlebody"" id=""articlebody"" style=""font-size:16px;"">",
                Content_Start_SerachFlag = 1,
                Content_End = @"</div>",
                Content_End_SerachFlag = 1,
                Content_NewLine = @"</p>",
                Content_WhiteSpace = @"<p>,",
                NovelName_Start = @"<div class=""info"">",
                NovelName_End = @"<span itemprop=""author"">"
            };
            NovelList.Add(rbtn1);
            NovelList.Add(rbtn2);
            var str = " ";
            for (var i = NovelList.Count + 1; i <= 10; i++)
            {
                NovelList.Add(new ShortCut_Button()
                {
                    ButtonSerialNumber = i,
                    ButtonName = $"預設值{i}",
                    ButtonUrl = str,
                    PageType = "html",
                    NovelTextFileSavePath = str,
                    Title_Start = str,
                    Title_Start_SerachFlag = 1,
                    Title_End = str,
                    Title_End_SerachFlag = 1,
                    Content_Start = str,
                    Content_Start_SerachFlag = 1,
                    Content_End = str,
                    Content_End_SerachFlag = 1,
                    Content_NewLine = str,
                    Content_WhiteSpace = str,
                    NovelName_Start = str,
                    NovelName_End = str,
                });
            }
            return NovelList;
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