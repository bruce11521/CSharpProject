
using NovelDownloader.CoreBase.Help;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NovelDownloader.Library
{
    /// <summary>
    /// 訊息提示
    /// </summary>
    public class DesktopAlertUtil
    {
        /// <summary>
        /// 自訂底色
        /// </summary>
        public Color BackGroupColor = Color.Transparent;

        /// <summary>
        /// 自訂位置
        /// </summary>
        public AlertScreenPosition ASP { get; set; }

        /// <summary>
        /// 錯誤的底色
        /// </summary>
        private Color ErrorColor = Color.PaleVioletRed;
        /// <summary>
        /// 警告的底色
        /// </summary>
        private Color WarningColor = Color.LightYellow;
        /// <summary>
        /// 成功的底色
        /// </summary>
        private Color SuccessColor = Color.LightBlue;

        /// <summary>
        /// Alert Type
        /// CodeGroup = SexCode
        /// </summary>
        public enum Alert
        {
            /// <summary>
            /// 錯誤
            /// 明顯出現，且需人工關閉
            /// 底色紅
            /// </summary>
            [Display(Name = "錯誤")]
            Error = 99, // 後面數字為自動關閉時的秒數，可是警告不會自動關閉

            /// <summary>
            /// 成功
            /// 小小出現3秒，程式自動關閉
            /// 底色藍
            /// </summary>
            [Display(Name = "成功")]
            Success = 3, // 後面數字為自動關閉時的秒數

            /// <summary>
            /// 警告
            /// 出現時間稍久6秒，程式自動關閉
            /// 底色黃
            /// </summary>
            [Display(Name = "警告")]
            Warning = 6, // 後面數字為自動關閉時的秒數
        }

        /// <summary>
        /// 顯示錯誤訊息
        /// </summary>
        /// <param name="Content">內容</param>
        public void ShowError(string Content)
        {
            ShowAlert(Alert.Error, Content, string.Empty);
        }

        /// <summary>
        /// 顯示錯誤訊息
        /// </summary>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowError(string Content, string Title)
        {
            ShowAlert(Alert.Error, Content, Title);
        }

        /// <summary>
        /// 顯示成功訊息
        /// </summary>
        /// <param name="Content">內容</param>
        public void ShowSuccess(string Content)
        {
            ShowAlert(Alert.Success, Content, string.Empty);
        }

        /// <summary>
        /// 顯示成功訊息
        /// </summary>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowSuccess(string Content, string Title)
        {
            ShowAlert(Alert.Success, Content, Title);
        }

        /// <summary>
        /// 顯示警告訊息
        /// </summary>
        /// <param name="Content">內容</param>
        public void ShowWarning(string Content)
        {
            ShowAlert(Alert.Warning, Content, string.Empty);
        }

        /// <summary>
        /// 顯示警告訊息
        /// </summary>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowWarning(string Content, string Title)
        {
            ShowAlert(Alert.Warning, Content, Title);
        }

        /// <summary>
        /// 顯示Alert
        /// </summary>
        /// <param name="alertType">Alert類別</param>
        /// <param name="Content">內容</param>
        public void ShowAlert(Alert alertType, string Content)
        {
            ShowAlert(alertType, Content, string.Empty);
        }

        /// <summary>
        /// 顯示Alert
        /// </summary>
        /// <param name="alertType">Alert類別</param>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        public void ShowAlert(Alert alertType, string Content, string Title)
        {
            // TODO 下次是不是要補一下圖示
            Font ContentFont = new Font("微軟正黑體", 12f, FontStyle.Regular);
            Font CaptionFont = new Font("微軟正黑體", 16f, FontStyle.Bold);
            RadDesktopAlert radDesktopAlert = new RadDesktopAlert();
            DesktopAlertPopup alertpopup = radDesktopAlert.Popup;

            #region 通用排版樣式
            // 提示框上的三點是否要繪制
            radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.ShouldPaint = false;
            // 是否自動關閉
            radDesktopAlert.AutoClose = alertType != Alert.Error; // Error 不自動關閉
            // 自動關閉的秒數
            radDesktopAlert.AutoCloseDelay = alertType.ToNumberValue();
            radDesktopAlert.Popup.AlertElement.BorderDashStyle = DashStyle.Dot;
            radDesktopAlert.Popup.AlertElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;//.OuterInnerBorders;
            // 底色是否要漸層
            radDesktopAlert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
            // 標題文字
            radDesktopAlert.CaptionText = Title;
            // 內文
            radDesktopAlert.ContentText = Content;
            // 風格樣式
            //radDesktopAlert.ThemeName = "FluentDatk";

            // 自動尺吋
            radDesktopAlert.AutoSize = true;
            // 關閉鈕
            radDesktopAlert.ShowCloseButton = alertType != Alert.Success;  // Success會一閃而過，就不需要關閉鈕了
            // 選項鈕
            radDesktopAlert.ShowOptionsButton = false;
            // 釘選鈕
            radDesktopAlert.ShowPinButton = false;
            // 內文字型
            radDesktopAlert.Popup.AlertElement.ContentElement.Font = ContentFont;
            // 標題字型
            radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = CaptionFont;

            // 跳出提示的位置
            //radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
            // 跳出提示下方的一排按鈕排版空間
            //radDesktopAlert.Popup.AlertElement.ButtonsPanel 
            // 內文相關設定
            //radDesktopAlert.Popup.AlertElement.ContentElement
            // 標題相關設定
            //radDesktopAlert.Popup.AlertElement.CaptionElement
            #endregion 通用排版樣式

            switch (alertType)
            {
                case Alert.Error:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = ErrorColor;
                    //radDesktopAlert.Popup.AlertElement.ContentImage = RadMessageIcon.Info;
                    // Properties.Resources.envelope
                    break;

                case Alert.Success:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                    if (alertpopup != null)
                    {
                        // 取得呼叫的應用程式位置
                        var apps = Application.OpenForms;
                        var app = apps.Count > 0 ? apps[apps.Count - 1] : null;

                        // app.InvokeRequired 為True時，代表跨執行緒執行
                        // 應用程式所在作用的螢幕
                        var ActiveScreen = (app == null || app.InvokeRequired) ? Screen.PrimaryScreen : Screen.FromControl(app);
                        var screenWidth = ActiveScreen.Bounds.Width;
                        var screenHeight = ActiveScreen.Bounds.Height;
                        // 多螢幕下，將執行設定為視窗的那個螢幕
                        DesktopAlertManager.Instance.SetActiveScreen(ActiveScreen);

                        // TODO 想找找是不是能放畫面正中間，多個訊息好像會重疊
                        // 目前先暫時這樣子，不會太明顯的歪…
                        // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                        alertpopup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
                    }
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = SuccessColor;
                    break;

                case Alert.Warning:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = WarningColor;
                    break;
            }

            #region 使用者自訂項目
            // 當有指定底色時，使用指定的底色
            if (BackGroupColor != Color.Transparent)
            {
                radDesktopAlert.Popup.AlertElement.BackColor = BackGroupColor;
            }

            // 當有指定出現位置時，使用指定位置
            if (ASP != AlertScreenPosition.Manual)
            {
                radDesktopAlert.ScreenPosition = ASP;
            }
            #endregion 使用者自訂項目

            radDesktopAlert.Show();
        }

        /// <summary>
        /// 客製化顯示Alert
        /// </summary>
        /// <param name="alertType">Alert類別</param>
        /// <param name="Content">內容</param>
        /// <param name="Title">標題</param>
        /// <param name="AlertSecond">顯示秒數(-1為使用預設)</param>
        /// <param name="CustomScreenPosition">傳入AlertScreenPosition Type則指定位置，否則使用預設</param>
        /// <param name="ScreenPositionLocation">如果CustomScreenPosition = AlertScreenPosition.Manual，則使用傳入座標</param>
        /// <param name="ShowMessageOnScreenCenter">是否顯示在螢幕中間(目前已知多個訊息會導致訊息重疊)(預設False，會覆寫顯示位置設定)</param>
        public void ShowAlert_Custom(Alert alertType, string Content, string Title, int AlertSecond = -1, object CustomScreenPosition = null, Point ScreenPositionLocation = new Point(), bool ShowMessageOnScreenCenter = false)
        {
            // TODO 下次是不是要補一下圖示
            Font ContentFont = new Font("微軟正黑體", 12f, FontStyle.Regular);
            Font CaptionFont = new Font("微軟正黑體", 16f, FontStyle.Bold);
            RadDesktopAlert radDesktopAlert = new RadDesktopAlert();
            DesktopAlertPopup alertpopup = radDesktopAlert.Popup;

            // 取得呼叫的應用程式位置
            var apps = Application.OpenForms;
            var app = apps.Count > 0 ? apps[apps.Count - 1] : null;

            // app.InvokeRequired 為True時，代表跨執行緒執行
            // 應用程式所在作用的螢幕
            var ActiveScreen = (app == null || app.InvokeRequired) ? Screen.PrimaryScreen : Screen.FromControl(app);
            var screenWidth = ActiveScreen.Bounds.Width;
            var screenHeight = ActiveScreen.Bounds.Height;
            // 多螢幕下，將執行設定為視窗的那個螢幕
            DesktopAlertManager.Instance.SetActiveScreen(ActiveScreen);

            #region 通用排版樣式
            // 提示框上的三點是否要繪制
            radDesktopAlert.Popup.AlertElement.CaptionElement.CaptionGrip.ShouldPaint = false;
            // 是否自動關閉
            radDesktopAlert.AutoClose = alertType != Alert.Error; // Error 不自動關閉
            // 自動關閉的秒數
            radDesktopAlert.AutoCloseDelay = AlertSecond != -1 ? AlertSecond : alertType.ToNumberValue();
            radDesktopAlert.Popup.AlertElement.BorderDashStyle = DashStyle.Dot;
            radDesktopAlert.Popup.AlertElement.BorderBoxStyle = BorderBoxStyle.SingleBorder;//.OuterInnerBorders;
            // 底色是否要漸層
            radDesktopAlert.Popup.AlertElement.GradientStyle = GradientStyles.Solid;
            // 標題文字
            radDesktopAlert.CaptionText = Title;
            // 內文
            radDesktopAlert.ContentText = Content;
            // 風格樣式
            //radDesktopAlert.ThemeName = "FluentDatk";

            // 自動尺吋
            radDesktopAlert.AutoSize = true;
            // 關閉鈕
            radDesktopAlert.ShowCloseButton = alertType != Alert.Success;  // Success會一閃而過，就不需要關閉鈕了
            // 選項鈕
            radDesktopAlert.ShowOptionsButton = false;
            // 釘選鈕
            radDesktopAlert.ShowPinButton = false;
            // 內文字型
            radDesktopAlert.Popup.AlertElement.ContentElement.Font = ContentFont;
            // 標題字型
            radDesktopAlert.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = CaptionFont;

            // 跳出提示的位置
            //radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
            // 跳出提示下方的一排按鈕排版空間
            //radDesktopAlert.Popup.AlertElement.ButtonsPanel 
            // 內文相關設定
            //radDesktopAlert.Popup.AlertElement.ContentElement
            // 標題相關設定
            //radDesktopAlert.Popup.AlertElement.CaptionElement
            #endregion 通用排版樣式

            switch (alertType)
            {
                case Alert.Error:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = ErrorColor;
                    //radDesktopAlert.Popup.AlertElement.ContentImage = RadMessageIcon.Info;
                    // Properties.Resources.envelope
                    break;

                case Alert.Success:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                    if (alertpopup != null)
                    {
                        // TODO 想找找是不是能放畫面正中間，多個訊息好像會重疊
                        // 目前先暫時這樣子，不會太明顯的歪…
                        // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                        alertpopup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
                    }
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = SuccessColor;
                    break;

                case Alert.Warning:
                    // 跳出提示的位置
                    radDesktopAlert.ScreenPosition = AlertScreenPosition.BottomRight;
                    // 提示框的底色
                    radDesktopAlert.Popup.AlertElement.BackColor = WarningColor;
                    break;
            }

            #region 使用者自訂項目
            // 當有指定底色時，使用指定的底色
            if (BackGroupColor != Color.Transparent)
            {
                radDesktopAlert.Popup.AlertElement.BackColor = BackGroupColor;
            }

            // 當有指定出現位置時，使用指定位置
            if (CustomScreenPosition != null && CustomScreenPosition is AlertScreenPosition)
            {
                if ((AlertScreenPosition)CustomScreenPosition == AlertScreenPosition.Manual)
                {
                    if (ScreenPositionLocation != null)
                    {
                        alertpopup.Location = ScreenPositionLocation;
                    }
                }
                radDesktopAlert.ScreenPosition = (AlertScreenPosition)CustomScreenPosition;
            }
            //訊息是否顯示在螢幕中間
            if (ShowMessageOnScreenCenter)
            {
                radDesktopAlert.ScreenPosition = AlertScreenPosition.Manual;
                // 公式：多螢幕的偏移 + 所在螢幕的一半 - 訊息框的大概尺吋(暫時抓不到會多少，先以大概的數字來取)
                alertpopup.Location = new Point(ActiveScreen.Bounds.X + ((int)(screenWidth / 2)) - 160, ActiveScreen.Bounds.Y + ((int)(screenHeight / 2)) - 80);
            }

            #endregion 使用者自訂項目

            radDesktopAlert.Show();
        }

    }
}
