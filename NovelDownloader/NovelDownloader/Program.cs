using NovelDownloader.Library;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NovelDownloader
{
    static class Program
    {
        static private NovelUtility _utility = new NovelUtility();
        static private DesktopAlertUtil _desktopAlertUtil = new DesktopAlertUtil();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                Show(exception);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception exception = e.Exception;

            Show(exception);
        }

        private static void Show(Exception exception)
        {
            //string VersionNumber = $"{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}"; //版本號
            var VersionNumber = $"{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}";
            try
            {

                //#region 讀取記錄檔
                //string[] str = Process.GetCurrentProcess().MainModule.FileName.Split('\\');
                //string filePath = str.Where(item => item != str[str.Length - 1]).Aggregate("", (current, item) => current + (item + '\\'));
                //var logFilePath = filePath + ConfigurationManager.AppSettings["NOVEL_LOG"];
                //string[] txtList = new string[] { };
                //if (File.Exists(logFilePath))
                //{
                //    txtList = _utility.TXT_ReadStringArray(logFilePath);
                //    foreach (string item in txtList)
                //    {
                //        DisplayInfo += item + Environment.NewLine;
                //    }
                //}
                //#endregion

                string[] str = Process.GetCurrentProcess().MainModule.FileName.Split('\\');
                string filePath = str.Where(item => item != str[str.Length - 1]).Aggregate("", (current, item) => current + (item + '\\'));
                _utility.TXT_WriteString(filePath, ConfigurationManager.AppSettings["NOVEL_LOG"], ($"{DateTime.Now:yyyy/MM/dd HH:mm:ss} ,Version:{VersionNumber}" + "\n\n[原始錯誤之擲出]\nMessage:" + exception.Message + "\n\nStackTrace:" + exception.StackTrace + Environment.NewLine + Environment.NewLine), false, true);


                RadMessageBox.Show($"程式發生錯誤，已將錯誤日誌建立在程式目錄下。　　　　　　　　　　　　　　　　　　\n錯誤日誌路徑:\n{filePath}\\NOVEL_LOG.txt", $"[{VersionNumber}]錯誤", MessageBoxButtons.OK, RadMessageIcon.Error, $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} Version:{VersionNumber}\r\n" + "Message:" + exception.Message + "\n\nStackTrace:" + exception.StackTrace);

            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}