using Newtonsoft.Json;
using NovelDownloader.Library;
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
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NovelDownloader
{
    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        private NovelUtility _utility = new NovelUtility();
        private DesktopAlertUtil _desktopAlert = new DesktopAlertUtil();

        private List<string> DownloadUrlList = new List<string>();
        public Main()
        {
            try
            {
                InitializeComponent();
                _utility.radMsgboxFont();
                _utility.SetControlFont(this);

                this.Text = "NovelDownloader " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                this.Font = _utility.SetFontSize(12);

                radLabel_Version.Text = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion; ;

                UI_Settings();
                UI_Register();

                radTextBoxControl_Url.Text = "http://big5.quanben5.com/n/moriduoshe/";
                radTextBoxControl_PageStart.Text = "6806";
                radTextBoxControl_PageEnd.Text = "6806";
                radTextBoxControl_PageType.Text = "html";
                radRadioButton_ContinuedUrl.CheckState = CheckState.Checked;
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

            radTextBoxControl_PreviewText.Multiline = true;
            radTextBoxControl_PreviewText.AcceptsReturn = true;
            radTextBoxControl_PreviewText.AcceptsTab = true;

            radTextBoxControl_PageType.TextBoxElement.MaxLength = 5;
        }
        private void UI_Register  ()
        {
            radButton_Download.Click += RadButton_Download_Click;
        }

        private void RadButton_Download_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(radTextBoxControl_Url.Text))
                {
                    RadMessageBox.Show("\"小說下載網址\"，不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }
                if(radRadioButton_ContinuedUrl.CheckState == CheckState.Unchecked &&
                   radRadioButton_NoneContinuedUrl.CheckState == CheckState.Unchecked)
                {
                    RadMessageBox.Show("未選擇網址相關參數!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    //_desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Warning, "未選擇網址相關參數!", "網址相關參數缺失", -1, AlertScreenPosition.BottomRight);
                    return;
                }
                if(radRadioButton_ContinuedUrl.CheckState == CheckState.Checked)
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
                    else if(string.IsNullOrWhiteSpace(radTextBoxControl_PageType.Text))
                    {
                        RadMessageBox.Show("\"副檔名\"，參數不可為空!", "網址相關參數缺失", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        return;
                    }
                }

                decimal PageCount = 0M;
                if( decimal.TryParse(radTextBoxControl_PageStart.Text, out decimal pageStart))
                {
                    if (decimal.TryParse(radTextBoxControl_PageEnd.Text, out decimal pageEnd))
                    {
                        PageCount = pageEnd - pageStart;
                        if (PageCount >= 0)
                        {
                            for (decimal index = pageStart; index <= pageEnd; index++)
                            {
                                DownloadUrlList.Add(radTextBoxControl_Url.Text + index + "." + radTextBoxControl_PageType.Text);
                            }
                            _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, $"共{PageCount}章.", "小說章節總數", -1, AlertScreenPosition.BottomRight);
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
                    foreach(var item in DownloadUrlList)
                    {
                        urlStr += item + Environment.NewLine;
                    }
                    
                    radTextBoxControl_PreviewText.Text = urlStr;


                    HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;
                    if (request != null)
                    {
                        request.Method = "GET";
                        request.ContentType = "text/html; charset=UTF-8";
                        //request.Accept = "application/json";
                        request.Timeout = 30000;

                        

                        //using (Stream reqStream = request.GetRequestStream())
                        //{
                        //    reqStream.Write(byteArray, 0, byteArray.Length);
                        //}

                        using (WebResponse response = request.GetResponse())
                        {
                            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                            {
                                var resultdata = sr.ReadToEnd();
                                if (!string.IsNullOrWhiteSpace(resultdata))
                                {
                                    radTextBoxControl_PreviewText.Text = StripHTML(resultdata);
                                    _desktopAlert.ShowAlert_Custom(DesktopAlertUtil.Alert.Success, "TXT轉換成功!", "小說下載轉換", -1, AlertScreenPosition.BottomRight);
                                }
                                
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

        private static string StripHTML(string stringHTML)
        {
            try
            {
                string[] arryReg =
                {
                    @"<script[^>]*?>.*?</script>",
                    @"<(\/\s*)?!?((\w :)?\w )(\w (\s*=?\s*(([""'])(\\[",
                    @"'tbnr]|[^\7])*?\7|\w )|.{0})|\s)*?(\/\s*)?>", @"([\r\n])[\s] ",
                    @"&(quot|#34);", @"&(amp|#38);", @"&(lt|#60);", @"&(gt|#62);",
                    @"&(nbsp|#160);", @"&(iexcl|#161);", @"&(cent|#162);", @"&(pound|#163);",
                    @"&(copy|#169);", @"&#(\d );", @"-->", @"<!--.*\n"
                };
                string[] aryRep =
                {
                    "", "", "", "\"", "&", "<", ">", "  ", "\xa1", //chr(161),
                    "\xa2", //chr(162),
                    "\xa3", //chr(163),
                    "\xa9", //chr(169),
                    "", "\r\n", ""
                };

                string newReg = arryReg[0];
                string strOutPut = stringHTML;
                Regex regex = new Regex(arryReg[0], RegexOptions.IgnoreCase);
                for (int i = 0; i < arryReg.Length; i++)
                {
                    regex = new Regex(arryReg[i], RegexOptions.IgnoreCase);
                    strOutPut = regex.Replace(strOutPut, aryRep[i]);
                    
                }
                strOutPut.Replace("<", "");
                strOutPut.Replace(">", "");
                strOutPut.Replace("\r\n", "");
                return strOutPut;

            }
            catch
            {
                throw;
            }
        }
    }
}
