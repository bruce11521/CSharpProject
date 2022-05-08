using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace NovelDownloader.Library
{
    public sealed class FontsProxy
    {
        private FontsProxy() { }

        private PrivateFontCollection CreateFonts()
        {
            ////載入自訂字型ttf檔
            ////PrivateFontCollection 的AddFontFile()可把ttf檔直接讀入使用

            string FontsFolderPath = Application.StartupPath + "\\Fonts";
            string ResourceFolderPath = Application.StartupPath + "\\Resources";
            if (!Directory.Exists(FontsFolderPath))
            {//檔案夾是否存在?
                if (Directory.Exists(ResourceFolderPath))
                {
                    Directory.CreateDirectory(FontsFolderPath);
                    string FontSourceFileName = "\\YaHeiConsolasHybrid.ttf";
                    if (File.Exists(ResourceFolderPath + FontSourceFileName))
                    {
                        File.Copy(ResourceFolderPath + FontSourceFileName, FontsFolderPath + FontSourceFileName, true);
                    }
                    else
                    {
                        ShowDesktopAlert("字體設定", "找不到字體檔案，使用預設字體(微軟正黑體)來顯示!", 3);
                        //Telerik.WinControls.RadMessageBox.Show("找不到字體檔案，使用預設字體(微軟正黑體)來顯示!", "系統提示", MessageBoxButtons.OK, Telerik.WinControls.RadMessageIcon.Exclamation);
                        return new PrivateFontCollection();
                    }
                }
                else
                {
                    ShowDesktopAlert("字體設定", "找不到字體檔案資料夾，使用預設字體(微軟正黑體)來顯示!", 3);
                    //Telerik.WinControls.RadMessageBox.Show("找不到字體檔案資料夾，使用預設字體(微軟正黑體)來顯示!", "系統提示", MessageBoxButtons.OK, Telerik.WinControls.RadMessageIcon.Exclamation);
                    return new PrivateFontCollection();
                }
            }
            var result = new PrivateFontCollection();
            //result.AddFontFile(Application.StartupPath + "\\Fonts\\NotoSansMonoCJKtc-Regular.otf");
            result.AddFontFile(Application.StartupPath + "\\Fonts\\YaHeiConsolasHybrid.ttf");
            return result;

            //載入到Memory 
            //var result = new PrivateFontCollection();
            //var bytes = Properties.Resource.YaHeiConsolasHybrid;
            //System.IntPtr pointer = Marshal.AllocCoTaskMem(bytes.Length);
            //Marshal.Copy(bytes, 0, pointer, bytes.Length);
            //result.AddMemoryFont(pointer, bytes.Length);
            //return result;
        }

        /// <summary>
        /// 右下角顯示警告提示
        /// </summary>
        /// <param name="Title">標題</param>
        /// <param name="Content">內容</param>
        /// <param name="CloseDelayTime">自動消失秒數(預設6秒)</param>
        /// <param name="ScreenDisplayPosition">提示顯示位置(Enum AlertScreenPosition)</param>
        /// <param name="PopupLocation">提示位置手動設定(new Point())</param>
        private void ShowDesktopAlert(string Title, string Content, int CloseDelayTime = 6, AlertScreenPosition ScreenDisplayPosition = AlertScreenPosition.BottomRight, Point PopupLocation = new Point())
        {
            try
            {
                Font LabelFont = new Font("微軟正黑體", 12f, FontStyle.Regular);
                Font DesktopAlertTextBtnFont = new Font("微軟正黑體", 16f, FontStyle.Bold);

                RadDesktopAlert radDesktopAlert = new RadDesktopAlert();
                radDesktopAlert.ScreenPosition = ScreenDisplayPosition;
                if (ScreenDisplayPosition == AlertScreenPosition.Manual)
                {
                    DesktopAlertPopup alertpopup = radDesktopAlert.Popup as DesktopAlertPopup;
                    if (alertpopup != null)
                    {
                        alertpopup.Location = PopupLocation;
                    }
                }
                radDesktopAlert.AutoClose = true;
                radDesktopAlert.AutoCloseDelay = CloseDelayTime;
                radDesktopAlert.CaptionText = Title;
                radDesktopAlert.ContentText = Content;
                //radDesktopAlert.ThemeName = "FluentDatk";
                radDesktopAlert.AutoSize = true;
                //radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                radDesktopAlert.ShowCloseButton = true;
                radDesktopAlert.ShowOptionsButton = false;
                radDesktopAlert.ShowPinButton = false;
                radDesktopAlert.Popup.AlertElement.ContentElement.Font = LabelFont;
                radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = DesktopAlertTextBtnFont;
                radDesktopAlert.Show();
            }
            catch
            {
                throw;
            }

        }

        private static PrivateFontCollection _fontsCollection;

        public static FontFamily[] Fonts
        {
            get
            {
                if (_fontsCollection == null)
                {
                    _fontsCollection = new FontsProxy().CreateFonts();
                }
                if (_fontsCollection.Families.Count() == 0)
                {
                    FontFamily[] DefaultFonts = new FontFamily[] { new FontFamily("微軟正黑體") };
                    return DefaultFonts;
                    //_fontsCollection.Families = new FontFamily("微軟正黑體");
                }

                return _fontsCollection.Families;
            }
        }
    }
}
