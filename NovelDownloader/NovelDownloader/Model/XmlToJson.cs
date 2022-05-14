using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader.Model
{
    public class XmlToJson
    {
        public Html_Flag_Settings HTML_FLAG_SETTINGS { get; set; }
        public Html_Shortcut_Settings HTML_SHORTCUT_SETTINGS { get; set; }
    }
    public class Html_Flag_Settings
    {

    }
    public class Html_Shortcut_Settings
    {
        public List<ShortcutButton> ShortCutButton { get; set; }
    }
    public class ShortcutButton : ShortCut_Button
    {

    }
}
