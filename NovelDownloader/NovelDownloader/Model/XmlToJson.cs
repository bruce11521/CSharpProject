using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader.Model
{
    /// <summary>
    /// XML 轉換 JSON MODEL
    /// </summary>
    public class XmlToJson
    {
        public SUB NovelDownloader { get; set; }
        //public Advance_Settings ADVANCE_SETTINGS { get; set; }
        //public Html_Shortcut_Settings HTML_SHORTCUT_SETTINGS { get; set; }
        //public XmlToJson()
        //{
        //    NovelDownloader = new SUB
        //    {
        //        ADVANCE_SETTINGS = new Advance_Settings()
        //        {
        //            DownloadWaitingTimeOutSeconds = 30000,
        //            UnusualWordCountCheck = 200
        //        },
        //        HTML_SHORTCUT_SETTINGS = new Html_Shortcut_Settings()
        //        {
        //            ShortCutButton = new List<ShortcutButton>()
        //        {
        //            new ShortcutButton()
        //            {
        //                ButtonSerialNumber = 1,
        //                ButtonName = "Default1",
        //                NovelName_Start_SearchFlag = 1,
        //                Title_Start_SearchFlag = 1,
        //                Content_Start_SearchFlag = 1,
        //            }
        //        }
        //        }
        //    };

        //}
    }
    public class SUB
    {
        /// <summary>
        /// 進階設定
        /// </summary>
        public Advance_Settings ADVANCE_SETTINGS { get; set; }
        /// <summary>
        /// 快捷鍵設定MODEL
        /// </summary>
        public Html_Shortcut_Settings HTML_SHORTCUT_SETTINGS { get; set; }
    }

    public class Advance_Settings : AdvanceSettings
    {
        //public AdvanceSettings Advance_Setting { get; set; }
    }
    /// <summary>
    /// 快捷鍵設定MODEL
    /// </summary>
    public class Html_Shortcut_Settings
    {
        public List<ShortcutButton> ShortCutButton { get; set; }
    }
    /// <summary>
    /// 繼承快捷MODEL
    /// </summary>
    public class ShortcutButton : ShortCut_Button
    {

    }

    

}