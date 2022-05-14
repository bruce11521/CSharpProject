using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelDownloader.Model
{
    /// <summary>
    /// 網頁參數設定
    /// </summary>
    public class NovelSettings
    {
        /// <summary>
        /// 標題 起始 搜尋標記
        /// </summary>
        [Display(Name = "小說標題 起始標籤")]
        public string Title_Start { get; set; }
        /// <summary>
        /// 標題 起始 搜尋標記(遇到相同標記取第幾個)
        /// </summary>
        [Display(Name = "小說標題 起始標籤 指定搜尋")] 
        public int Title_Start_SerachFlag { get; set; }
        /// <summary>
        /// 標題 結束 搜尋標記
        /// </summary>
        [Display(Name = "小說標題 結束標籤")] 
        public string Title_End { get; set; }
        /// <summary>
        /// 標題 結束 搜尋標記(遇到相同標記取第幾個)
        /// </summary>
        [Display(Name = "小說標題 結束標籤 指定搜尋")] 
        public int Title_End_SerachFlag { get; set; }
        /// <summary>
        /// 內容 起始 搜尋標記
        /// </summary>
        [Display(Name = "小說內容 起始標籤")]
        public string Content_Start { get; set; }
        /// <summary>
        /// 內容 起始 搜尋標記(遇到相同標記取第幾個)
        /// </summary>
        [Display(Name = "小說內容 起始標籤 指定搜尋")] 
        public int Content_Start_SerachFlag { get; set; }
        /// <summary>
        /// 內容 結束 搜尋標記
        /// </summary>
        [Display(Name = "小說內容 結束標籤")] 
        public string Content_End { get; set; }
        /// <summary>
        /// 內容 結束 搜尋標記(遇到相同標記取第幾個)
        /// </summary>
        [Display(Name = "小說內容 結束標籤 指定搜尋")] 
        public int Content_End_SerachFlag { get; set; }
        /// <summary>
        /// 跳行字元
        /// </summary>
        [Display(Name = "跳行字元")] 
        public string Content_NewLine { get; set; }
        /// <summary>
        /// 空白字元
        /// </summary>
        [Display(Name = "空白字元")]
        public string Content_WhiteSpace { get; set; }

    }
    public class ShortCut_Button : NovelSettings
    {
        /// <summary>
        /// 快捷鍵順序
        /// </summary>
        public int ButtonSerialNumber { get; set; }
        /// <summary>
        /// 快捷按鈕名稱
        /// </summary>
        public string ButtonName { get; set; }
        /// <summary>
        /// 快捷按鈕 網址
        /// </summary>
        public string ButtonUrl { get; set; }
        /// <summary>
        /// 網頁附檔名
        /// </summary>
        public string PageType { get; set; }
        /// <summary>
        /// 小說TXT儲存地址
        /// </summary>
        public string NovelTextFileSavePath { get; set; }
    }
}
