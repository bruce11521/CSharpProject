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
        public Html_Flag_Settings HTML_FLAG_SETTINGS { get; set; }
        public Html_Shortcut_Settings HTML_SHORTCUT_SETTINGS { get; set; }
    }
    public class Html_Flag_Settings
    {

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
