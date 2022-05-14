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
using Telerik.WinControls.UI;

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
        /// 參數設定
        /// </summary>
        private NovelSettings Settings = new NovelSettings();
        /// <summary>
        /// 下載Text檔案List
        /// </summary>
        private List<(int ThreadSearial, bool DownloadFinish, List<StringBuilder>)> DownloadNovelTextList = new List<(int ThreadSearial, bool DownloadFinish, List<StringBuilder>)>();
        /// <summary>
        /// 下載URL List
        /// </summary>
        private List<(int ThreadSerial, List<string>)> DownloadNovelURLList = new List<(int ThreadSerial, List<string>)>();
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

                LoadXmlFile();
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
                var FilePath = !string.IsNullOrWhiteSpace(NovelName) ?
                    Directory.GetCurrentDirectory() + DateTime.Now.ToString("yyyyMMdd_HHmmss") + NovelName + ".txt" :
                    Directory.GetCurrentDirectory() + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_Novel.txt";
                if (ExecuteFilePath.Length > FileName.Length)
                {
                    FilePath = !string.IsNullOrWhiteSpace(NovelName) ?
                        ExecuteFilePath.Substring(0, ExecuteFilePath.Length - FileName.Length) + DateTime.Now.ToString("yyyyMMdd_HHmmss") + NovelName + ".txt" :
                        ExecuteFilePath.Substring(0, ExecuteFilePath.Length - FileName.Length) + DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_Novel.txt";
                }
                radTextBoxControl_SaveFilePath.Text = FilePath;
            }
            catch
            {
                throw;
            }
        }
        private void UI_Settings()
        {

            if(radPageView_Main.ViewElement is RadPageViewStripElement radPageViewStripElement)
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

            radTextBoxControl_PreviewText.Multiline = true;
            radTextBoxControl_PreviewText.AcceptsReturn = true;
            radTextBoxControl_PreviewText.AcceptsTab = true;

            #region RadTextBoxControl MaxLength
            radTextBoxControl_PageType.TextBoxElement.MaxLength = 5;
            radTextBoxControl_Title_Start_SearchFlag.MaxLength = 3;
            radTextBoxControl_Title_End_SearchFlag.MaxLength = 3;
            radTextBoxControl_Content_Start_SearchFlag.MaxLength = 3;
            radTextBoxControl_Content_End_SearchFlag.MaxLength = 3;
            #endregion



            radTextBoxControl_TESTINPUT.Multiline = true;
            radTextBoxControl_TESTINPUT.AcceptsReturn = true;
            radTextBoxControl_TESTINPUT.AcceptsTab = true;
            radTextBoxControl_TESTINPUT.VerticalScroll.Enabled = true;


        }

        private void RadMenuItem_Utility_Init()
        {
            try
            {
                RadMenuItem item0 = new RadMenuItem
                {
                    Name = "ReloadXmlFile",
                    Text = "重新讀取Xml設定至快速鍵",
                    Font = _utility.SetFontSize()
                };
                item0.Click += (sender ,e)=>
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

        private void UI_Register  ()
        {
            radTextBoxControl_Title_Start_SearchFlag.TextChanging += (sender , e) =>
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

            radButton_Download.Click += RadButton_Download_Click;
            radButton_PreviewDownload.Click += RadButton_Download_Click;

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

        private void RadButton_PreviewDownload_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(radTextBoxControl_PreviewUrl.Text))
                {
                    RadMessageBox.Show("\"單頁網址\"，不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
            }
            catch
            {
                throw;
            }
        }

        private void RadButton_Download_Click(object sender, EventArgs e)
        {
            try
            {
                if(sender is RadButton rbtn)
                {
                    //檢測網頁參數是否填入
                    if (string.IsNullOrWhiteSpace(radTextBoxControl_Title_Start.Text) ||
                        string.IsNullOrWhiteSpace(radTextBoxControl_Title_End.Text) ||
                        string.IsNullOrWhiteSpace(radTextBoxControl_Content_Start.Text) ||
                        string.IsNullOrWhiteSpace(radTextBoxControl_Content_End.Text))
                    {
                        if(DialogResult.Cancel == RadMessageBox.Show($"檢測到\n" + 
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Title_Start.Text) ? "標題文字起始標籤, " : string.Empty) + Environment.NewLine +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Title_End.Text) ? "標題文字結束標籤, " : string.Empty) + Environment.NewLine +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Content_Start.Text) ? "內容文字起始標籤, " : string.Empty) + Environment.NewLine +
                            (string.IsNullOrWhiteSpace(radTextBoxControl_Content_End.Text) ? "內容文字結束標籤" : string.Empty) + " 為空，是否繼續下載?" , "網頁參數缺失", MessageBoxButtons.OKCancel, RadMessageIcon.Question))
                        {
                            return;
                        }
                    }
                    //檢測檔案路徑是否合法
                    if (!string.IsNullOrWhiteSpace(radTextBoxControl_Title_End_SearchFlag.Text))
                    {
                        Regex regex = new Regex(@"^([a-zA-Z]:\\)?[^\/\:\*\?\""\<\>\|\,]*$");
                        Match m = regex.Match(radTextBoxControl_Title_End_SearchFlag.Text);
                        if (!m.Success)
                        {
                            RadMessageBox.Show("非法的檔案儲存路徑，請重新選擇或輸入！","檔案儲存路徑檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            return;
                        }
                        regex = new Regex(@"^[^\/\:\*\?\""\<\>\|\,]+$");
                        m = regex.Match(radTextBoxControl_Title_End_SearchFlag.Text);
                        if (!m.Success)
                        {
                            RadMessageBox.Show("請勿在檔名中包含\\ / : * ？ \" < > |等字元，請重新輸入有效檔名！", "檔案儲存路徑檢測", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                            return;
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



                            HttpWebRequest request = WebRequest.Create(radTextBoxControl_PreviewUrl.Text) as HttpWebRequest;
                            if (request != null)
                            {
                                request.Method = "GET";
                                request.ContentType = "text/html; charset=UTF-8";
                                //request.Accept = "application/json";
                                request.Timeout = 30000;


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
                                        }

                                    }
                                }

                            }




                            break;
                        case nameof(radButton_Download):
                            if (string.IsNullOrWhiteSpace(radTextBoxControl_Url.Text))
                            {
                                RadMessageBox.Show("\"小說下載網址\"，不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                                return;
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
                                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"共{PageCount + 1}章.", "小說章節總數", -1, AlertScreenPosition.BottomRight);
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
                                    radTextBoxControl_Url.Text = urlStr;
                                    BindSettings();

                                    var URLList = radTextBoxControl_Url.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                                    if (URLList.Length > 0)
                                    {
                                        var ListCountMod = URLList.Length % 15; //算出餘數 
                                        var ListCount = (URLList.Length - ListCountMod) / 15;//平均每個Thread下載的URL,第16個拿來下載餘數

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
                                        for (var i = ListCount * 15; i < URLList.Length; i++)
                                        {
                                            downloadURLList.Add(URLList[i]);
                                        }
                                        DownloadNovelURLList.Add((threadNum + 1, downloadURLList.ToList())); //第16個Thread



                                        var ss = "";
                                    }




                                    radTextBoxControl_PreviewText.Text = RegexHtmlElement(radTextBoxControl_TESTINPUT.Text);

                                    //HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;
                                    //if (request != null)
                                    //{
                                    //    request.Method = "GET";
                                    //    request.ContentType = "text/html; charset=UTF-8";
                                    //    //request.Accept = "application/json";
                                    //    request.Timeout = 30000;



                                    //    //using (Stream reqStream = request.GetRequestStream())
                                    //    //{
                                    //    //    reqStream.Write(byteArray, 0, byteArray.Length);
                                    //    //}



                                    //    using (WebResponse response = request.GetResponse())
                                    //    {
                                    //        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                    //        {
                                    //            var resultdata = sr.ReadToEnd();
                                    //            if (!string.IsNullOrWhiteSpace(resultdata))
                                    //            {

                                    //                radTextBoxControl_PreviewText.Text = RegexHtmlElement(resultdata);
                                    //                //radTextBoxControl_PreviewText.Text = StripHTML(resultdata);
                                    //                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "TXT轉換成功!", "小說下載轉換", -1, AlertScreenPosition.BottomRight);
                                    //            }

                                    //        }
                                    //    }

                                    //}


                                }
                            }
                            else if (radRadioButton_NoneContinuedUrl.CheckState == CheckState.Checked)
                            {
                                var URLList = radTextBoxControl_Url.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); ;
                                if (URLList.Length > 0)
                                {

                                    BindSettings();

                                    var ListCountMod = URLList.Length % 15; //算出餘數 
                                    var ListCount = (URLList.Length - ListCountMod) / 15;//平均每個Thread下載的URL,第16個拿來下載餘數


                                    List<string> downloadURLList = new List<string>();
                                    var threadNum = 1;
                                    for (var index = 0; index < URLList.Length; index++)
                                    {
                                        if ((index + 1) == ListCount * threadNum)
                                        {
                                            threadNum++;
                                            DownloadNovelURLList.Add((threadNum, downloadURLList.ToList()));
                                            downloadURLList = new List<string>();
                                        }
                                        downloadURLList.Add(URLList[index]);
                                    }





                                    //bgw_DownloadUIControl = new BackgroundWorker();
                                    //bgw_DownloadUIControl.WorkerReportsProgress = true;
                                    //bgw_DownloadUIControl.DoWork += new DoWorkEventHandler(Bgw_Download_Dowork);
                                    //bgw_DownloadUIControl.ProgressChanged += new ProgressChangedEventHandler(Bgw_Download_ProgressChanged);
                                    //bgw_DownloadUIControl.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_Download_RunWorkerCompleted);
                                    //bgw_DownloadUIControl.WorkerSupportsCancellation = true;
                                    //bgw_DownloadUIControl.RunWorkerAsync();


                                    //InitDownloadTask(URLList);



                                    //List<LoadingThread> loadingThreads = new List<LoadingThread>()
                                    //{
                                    //    LoadingThread.Thread1,
                                    //    LoadingThread.Thread2,
                                    //    LoadingThread.Thread3,
                                    //    LoadingThread.Thread4,
                                    //    LoadingThread.Thread5,
                                    //    LoadingThread.Thread6,
                                    //    LoadingThread.Thread7,
                                    //    LoadingThread.Thread8,
                                    //    LoadingThread.Thread9,
                                    //    LoadingThread.Thread10,
                                    //    LoadingThread.Thread11,
                                    //    LoadingThread.Thread12,
                                    //    LoadingThread.Thread13,
                                    //    LoadingThread.Thread14,
                                    //    LoadingThread.Thread15,
                                    //    LoadingThread.Thread16
                                    //};
                                    //bgw_DownloadQuery = new BackgroundWorker[loadingThreads.Count()];
                                    //for (int i = 0; i < loadingThreads.Count(); i++)
                                    //{
                                    //    bgw_DownloadQuery[i] = new BackgroundWorker();
                                    //    bgw_DownloadQuery[i].WorkerReportsProgress = true;
                                    //    bgw_DownloadQuery[i].DoWork += new DoWorkEventHandler(Bgw_Download_Dowork);
                                    //    bgw_DownloadQuery[i].ProgressChanged += new ProgressChangedEventHandler(Bgw_Download_ProgressChanged);
                                    //    bgw_DownloadQuery[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(Bgw_Download_RunWorkerCompleted);
                                    //    bgw_DownloadQuery[i].WorkerSupportsCancellation = true;
                                    //    bgw_DownloadQuery[i].RunWorkerAsync(loadingThreads[i]);
                                    //}


                                    //HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;
                                    //if (request != null)
                                    //{
                                    //    request.Method = "GET";
                                    //    request.ContentType = "text/html; charset=UTF-8";
                                    //    //request.Accept = "application/json";
                                    //    request.Timeout = 30000;
                                    //    using (WebResponse response = request.GetResponse())
                                    //    {
                                    //        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                    //        {
                                    //            var resultdata = sr.ReadToEnd();
                                    //            if (!string.IsNullOrWhiteSpace(resultdata))
                                    //            {

                                    //                radTextBoxControl_PreviewText.Text = RegexHtmlElement(resultdata);
                                    //                //radTextBoxControl_PreviewText.Text = StripHTML(resultdata);
                                    //                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "TXT轉換成功!", "小說下載轉換", -1, AlertScreenPosition.BottomRight);
                                    //            }

                                    //        }
                                    //    }

                                    //}
                                    //radTextBoxControl_PreviewText.Text = RegexHtmlElement(radTextBoxControl_TESTINPUT.Text);
                                }


                            }

                            break;

                    }


                    
                }



                

                //if (!DownloadUrlList.Any())
                //{
                //    RadMessageBox.Show("無下載網址!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                //    return;
                //}
                //else
                //{
                //    var urlStr = "";
                //    foreach(var item in DownloadUrlList)
                //    {
                //        urlStr += item + Environment.NewLine;
                //    }
                    
                //    BindSettings();

                //    radTextBoxControl_PreviewText.Text = RegexHtmlElement(radTextBoxControl_TESTINPUT.Text);

                //    //HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;
                //    //if (request != null)
                //    //{
                //    //    request.Method = "GET";
                //    //    request.ContentType = "text/html; charset=UTF-8";
                //    //    //request.Accept = "application/json";
                //    //    request.Timeout = 30000;



                //    //    //using (Stream reqStream = request.GetRequestStream())
                //    //    //{
                //    //    //    reqStream.Write(byteArray, 0, byteArray.Length);
                //    //    //}

                        
                        
                //    //    using (WebResponse response = request.GetResponse())
                //    //    {
                //    //        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                //    //        {
                //    //            var resultdata = sr.ReadToEnd();
                //    //            if (!string.IsNullOrWhiteSpace(resultdata))
                //    //            {

                //    //                radTextBoxControl_PreviewText.Text = RegexHtmlElement(resultdata);
                //    //                //radTextBoxControl_PreviewText.Text = StripHTML(resultdata);
                //    //                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "TXT轉換成功!", "小說下載轉換", -1, AlertScreenPosition.BottomRight);
                //    //            }
                                
                //    //        }
                //    //    }
                        
                //    //}


                //}

            }
            catch
            {
                throw;
            }
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
                if(e.UserState is LoadingThread loadingStatus)
                {
                    if(loadingStatus != LoadingThread.ExceptionError)
                    {
                        radProgressBar_Download.Value1 = e.ProgressPercentage;
                        radProgressBar_Download.ProgressBarElement.Text = e.ProgressPercentage + "%";
                    }
                    else
                    {
                        _utility.radMsgboxFont();
                        if (!IsShowAlert)
                        {
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
                                radProgressBar_Download.Value1 = 100;
                                radLabel_Main_Status.Text = "下載完成! 已經輸出成TXT檔案!";
                                Cursor = Cursors.Default;
                            }
                            
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
                if(loadingThread != LoadingThread.ExceptionError)
                {
                    switch (loadingThread)
                    {
                        case LoadingThread.Thread1:
                            break;
                        case LoadingThread.Thread2:
                            break;
                        case LoadingThread.Thread3:
                            break;
                        case LoadingThread.Thread4:
                            break;
                        case LoadingThread.Thread5:
                            break;
                        case LoadingThread.Thread6:
                            break;
                        case LoadingThread.Thread7:
                            break;
                        case LoadingThread.Thread8:
                            break;
                        case LoadingThread.Thread9:
                            break;
                        case LoadingThread.Thread10:
                            break;
                        case LoadingThread.Thread11:
                            break;
                        case LoadingThread.Thread12:
                            break;
                        case LoadingThread.Thread13:
                            break;
                        case LoadingThread.Thread14:
                            break;
                        case LoadingThread.Thread15:
                            break;
                        case LoadingThread.Thread16:
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
            switch (loadingThread)
            {
                case LoadingThread.Thread1:
                    //HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;
                    //if (request != null)
                    //{
                    //    request.Method = "GET";
                    //    request.ContentType = "text/html; charset=UTF-8";
                    //    //request.Accept = "application/json";
                    //    request.Timeout = 30000;
                    //    using (WebResponse response = request.GetResponse())
                    //    {
                    //        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    //        {
                    //            var resultdata = sr.ReadToEnd();
                    //            if (!string.IsNullOrWhiteSpace(resultdata))
                    //            {

                    //                radTextBoxControl_PreviewText.Text = RegexHtmlElement(resultdata);
                    //                //radTextBoxControl_PreviewText.Text = StripHTML(resultdata);
                    //                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "TXT轉換成功!", "小說下載轉換", -1, AlertScreenPosition.BottomRight);
                    //            }

                    //        }
                    //    }

                    //}
                    //radTextBoxControl_PreviewText.Text = RegexHtmlElement(radTextBoxControl_TESTINPUT.Text);
                    break;
                case LoadingThread.Thread2:
                    break;
                case LoadingThread.Thread3:
                    break;
                case LoadingThread.Thread4:
                    break;
                case LoadingThread.Thread5:
                    break;
                case LoadingThread.Thread6:
                    break;
                case LoadingThread.Thread7:
                    break;
                case LoadingThread.Thread8:
                    break;
                case LoadingThread.Thread9:
                    break;
                case LoadingThread.Thread10:
                    break;
                case LoadingThread.Thread11:
                    break;
                case LoadingThread.Thread12:
                    break;
                case LoadingThread.Thread13:
                    break;
                case LoadingThread.Thread14:
                    break;
                case LoadingThread.Thread15:
                    break;
                case LoadingThread.Thread16:
                    break;
                default:
                    break;
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
                string Title = "", Content = "";
                if (!string.IsNullOrWhiteSpace(HTML))
                {
                    var SearchStartPosition = 0;
                    for (int TS = 0; TS < Settings.Title_Start_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Title_Start, SearchStartPosition);
                    }
                    indexOfTitleStart = SearchStartPosition;

                    SearchStartPosition = 0;
                    for (int TS = 0; TS < Settings.Title_End_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Title_End, SearchStartPosition);
                    }
                    indexOfTitleEnd = SearchStartPosition;

                    SearchStartPosition = 0;
                    for (int TS = 0; TS < Settings.Content_Start_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Content_Start, SearchStartPosition);
                    }
                    indexOfContentStart = SearchStartPosition;

                    SearchStartPosition = indexOfContentStart;
                    for (int TS = 0; TS < Settings.Content_End_SerachFlag; TS++)
                    {
                        SearchStartPosition = HTML.IndexOf(Settings.Content_End, SearchStartPosition);
                    }
                    indexOfContentEnd = SearchStartPosition;


                    //indexOfTitleStart = HTML.IndexOf(Settings.Title_Start);
                    //indexOfTitleEnd = HTML.IndexOf(Settings.Title_End, indexOfTitleStart != -1 ? indexOfTitleStart : 0);
                    //indexOfContentStart = HTML.IndexOf(Settings.Content_Start);
                    //indexOfContentEnd = HTML.IndexOf(Settings.Content_End, indexOfContentStart != -1 ? indexOfContentStart : 0);

                    if(indexOfTitleStart != -1 && indexOfTitleEnd != -1)
                    {
                        if(indexOfTitleEnd - indexOfTitleStart > 0)
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
                            Content = HTML.Substring(indexOfContentStart + Settings.Content_Start.Length, (indexOfContentEnd - indexOfContentStart)- Settings.Content_Start.Length);

                            List<string> NewLineList = new List<string>();
                            if (!string.IsNullOrWhiteSpace(Settings.Content_NewLine))
                            {
                                var temp = Settings.Content_NewLine.Split(',');
                                if(temp.Length > 0)
                                {
                                    NewLineList.AddRange(temp);
                                }
                                
                            }
                            List<string> WhiteSpaceList = new List<string>();
                            if (!string.IsNullOrWhiteSpace(Settings.Content_WhiteSpace))
                            {
                                var temp = Settings.Content_WhiteSpace.Split(',');
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
                if(sender is RadButton rbtn)
                {
                    var SplitName = rbtn.Name.Split('_');
                    if(SplitName.Length == 3)
                    {
                        if (LoadFromXmlData.HTML_SHORTCUT_SETTINGS.ShortCutButton.Any(x=>x.ButtonSerialNumber.ToString() == SplitName[2]))
                        {
                            var XmlData = LoadFromXmlData.HTML_SHORTCUT_SETTINGS.ShortCutButton.Where(x => x.ButtonSerialNumber.ToString() == SplitName[2]).FirstOrDefault();
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
        }

        #region XML 
        private void LoadXmlFile()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                var defaultPath = Environment.CurrentDirectory;
                var defaultFileName = "NovelDownload_Settings.xml";
                if (File.Exists(defaultPath + "\\"+ defaultFileName))
                {
                    xmlDoc.Load(defaultPath + "\\" + defaultFileName);
                    XmlNode SHORTCUT_SETTINGS_Node = xmlDoc.SelectSingleNode($"//HTML_SHORTCUT_SETTINGS");
                    string jsonText = JsonConvert.SerializeXmlNode(SHORTCUT_SETTINGS_Node);


                    List<RadButton> DefaultButtonList = new List<RadButton>();

                    var Temp = _utility.GetAllControl(this, typeof(RadButton));

                    foreach(RadButton item in Temp)
                    {
                        if (item.Name.Contains("radButton_DefaultSettings"))
                        {
                            DefaultButtonList.Add(item);
                        }
                    }
                    //radButton_DefaultSettings


                    var xml = JsonConvert.DeserializeObject<XmlToJson>(jsonText);
                    if(xml != null)
                    {
                        LoadFromXmlData = new XmlToJson();
                        LoadFromXmlData = xml;
                        foreach (var item in xml.HTML_SHORTCUT_SETTINGS.ShortCutButton)
                        {
                            
                            if(DefaultButtonList.Any(x=>x.Name.Split('_')[2] == item.ButtonSerialNumber.ToString()))
                            {
                                var btn = DefaultButtonList.Where(x => x.Name.Split('_')[2] == item.ButtonSerialNumber.ToString()).FirstOrDefault();
                                btn.Text = item.ButtonName;
                                btn.ButtonElement.ToolTipText = item.ButtonUrl;
                            }
                        }
                    }
                }
                else
                {
                    RadMessageBox.Show($"預設設定檔案不存在!\n\n檔案路徑:\n{defaultPath + "\\" + defaultFileName}\n\n請確認檔案後再進行快捷鍵設定檔載入!", "Xml設定檔案載入檢測", MessageBoxButtons.OKCancel, RadMessageIcon.Exclamation);
                }
            }
            catch
            {
                throw;
            }
        }
        private void CreateXmlFile()
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

                var HTML_FLAG_Element = CreateNode(xmlDoc, Root, "HTML_FLAG_SETTINGS", "");

                var HTML_SHORTCUT_Element = CreateNode(xmlDoc, Root, "HTML_SHORTCUT_SETTINGS", "");



                var NovelList = DefaultNovelXmlSettings();

                for(int i = 1;i < NovelList.Count + 1; i++)
                {
                   
                    XmlElement HTML_SHORTCUT_BTN_ELement = CreateNode(xmlDoc, HTML_SHORTCUT_Element, $"ShortCutButton", "");
                    CreateButtonSettings(xmlDoc, HTML_SHORTCUT_BTN_ELement, NovelList[i-1]);
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
                    if(DialogResult.Yes == RadMessageBox.Show("NovelDownload_Settings.xml 設定檔存在，是否覆蓋?", "檔案覆蓋詢問",MessageBoxButtons.YesNo, RadMessageIcon.Question))
                    {
                        xmlDoc.Save(defaultPath + "\\" + defaultFileName);
                    }
                }
                else
                {
                    xmlDoc.Save(defaultPath + "\\" + defaultFileName);
                }
                _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"xml產生成功!\n\n路徑:\n{defaultPath + "\\" + defaultFileName}", "XML產出", -1, AlertScreenPosition.BottomRight);
               
            }
            catch
            {
                throw;
            }
        }
        private void CreateButtonSettings(XmlDocument xmlDoc,XmlElement ButtonData, ShortCut_Button NovelData)
        {
            if(NovelData != null)
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
                Content_Start = @"<div itemprop=""articleBody"" class=""articlebody"" id=""articlebody"" style=""font - size:16px; "">",
                Content_Start_SerachFlag = 1,
                Content_End = @"</div>",
                Content_End_SerachFlag = 1,
                Content_NewLine = @"</p>",
                Content_WhiteSpace = @"<p>,",
            };
            NovelList.Add(rbtn1);
            NovelList.Add(rbtn2);
            var str = " ";
            for(var i= NovelList.Count+1; i <= 10; i++)
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
