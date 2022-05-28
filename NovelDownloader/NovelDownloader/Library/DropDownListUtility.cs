using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace NovelDownloader.Library
{

    public class DropDownModel
    {
        public string DISPLAYTEXT { get; set; }
        public string VALUE { get; set; }
        public string CONTENT { get; set; }
    }

    /// <summary>
    /// 元件控制共用Service
    /// </summary>
    public class DropDownListUtility
    {
        /// <summary>
        /// 設定按鈕可點選(enabled)
        /// </summary>
        /// <param name="btns"></param>
        public void OpenButton(params RadControl[] btns)
        {
            foreach (RadControl item in btns)
            {
                item.Enabled = true;
            }
        }

        /// <summary>
        /// 設定按鈕不可點選(disabled)
        /// </summary>
        /// <param name="btns"></param>
        public void CloseButton(params RadControl[] btns)
        {
            foreach (RadControl item in btns)
            {
                item.Enabled = false;
            }
        }

        /// <summary>
        /// 下拉選單設定
        /// </summary>
        /// <param name="modelList">List資料</param>
        /// <param name="ddl">下拉選單元件</param>
        public void DropDownListSet(List<DropDownModel> modelList, RadDropDownList ddl)
        {
            DropDownListSet(modelList, ddl, false, false);
        }

        /// <summary>
        /// 下拉選單設定
        /// </summary>
        /// <param name="modelList">List資料</param>
        /// <param name="ddl">下拉選單元件</param>
        /// <param name="autoCompleteFlag">是否Auto-Complete</param>
        public void DropDownListSet(List<DropDownModel> modelList, RadDropDownList ddl, bool autoCompleteFlag)
        {
            DropDownListSet(modelList, ddl, autoCompleteFlag, false);
        }

        /// <summary>
        /// 下拉選單設定
        /// </summary>
        /// <param name="modelList">List資料</param>
        /// <param name="ddl">下拉選單元件</param>
        /// <param name="autoCompleteFlag">是否Auto-Complete</param>
        /// <param name="selectEmpty">預設選擇空值</param>
        public void DropDownListSet(List<DropDownModel> modelList, RadDropDownList ddl, bool autoCompleteFlag, bool selectEmpty)
        {
            DropDownListSet(modelList, ddl, false, false, false);
        }

        /// <summary>
        /// 下拉選單設定
        /// </summary>
        /// <param name="modelList">List資料</param>
        /// <param name="ddl">下拉選單元件</param>
        /// <param name="autoCompleteFlag">是否Auto-Complete +FontSize 13f</param>
        /// <param name="selectEmpty">預設選擇空值</param>
        /// <param name="insertEmptyData">modelList是否塞入空值</param>
        public void DropDownListSet(List<DropDownModel> modelList, RadDropDownList ddl, bool autoCompleteFlag, bool selectEmpty, bool insertEmptyData, int DropDownItemCount = 10, RadDropDownStyle DropDownStyle = RadDropDownStyle.DropDown)
        {
            if (insertEmptyData)
            {
                modelList.Insert(0, new DropDownModel { DISPLAYTEXT = "", VALUE = "" });
            }
            ddl.DisplayMember = "DISPLAYTEXT";
            ddl.ValueMember = "VALUE";
            ddl.DataSource = modelList;
            //DropDownList From Arrow Button
            ddl.DropDownListElement.DropDownStyle = DropDownStyle;
            ddl.DropDownListElement.DropDownSizingMode = SizingMode.UpDown;
            ddl.DropDownListElement.ListElement.ItemHeight = 25;
            ddl.DropDownListElement.DefaultItemsCountInDropDown = DropDownItemCount;       //預設下拉選單數量
                                                                                           //ddl.DropDownListElement.DropDownHeight = DropDownItemCount * (ddl.Font.Height + 8);       //下拉選單高
            ddl.DropDownListElement.ListElement.VisualItemFormatting += ListElemet_VisulItemFormatting;  //按鈕下拉選單

            if (autoCompleteFlag)
            {
                ddl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //ddl.DropDownSizingMode = SizingMode.UpDown;

                ddl.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.ItemHeight = 25;

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DefaultItemsCountInDropDown = DropDownItemCount;

                //ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownHeight = DropDownItemCount * (ddl.Font.Height + 8);

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.DropDownSizingMode = SizingMode.UpDown;

                ddl.DropDownListElement.AutoCompleteSuggest.DropDownList.VisualItemFormatting += ListElemet_VisulItemFormatting;    //自動完成下拉

            }
            if (selectEmpty)
            {
                ddl.SelectedValue = "";

            }
        }
        private void ListElemet_VisulItemFormatting(object sender, VisualItemFormattingEventArgs e)
        {
            e.VisualItem.Font = new Font(FontsProxy.Fonts[0], 12f);
            e.VisualItem.ToolTipText = e.VisualItem.Text;
            if (e.VisualItem.Selected)
            {
                e.VisualItem.NumberOfColors = 1;
                e.VisualItem.BackColor = Color.Yellow;
                e.VisualItem.BorderColor = Color.Blue;
            }
            else
            {
                e.VisualItem.ResetValue(LightVisualElement.NumberOfColorsProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                e.VisualItem.ResetValue(LightVisualElement.BorderColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            }

        }


        /// <summary>
        /// 轉換yn為是否
        /// </summary>
        /// <param name="yn"></param>
        /// <returns></returns>
        public string YNToChinese(string yn)
        {
            if (yn.ToUpper() == "Y")
            {
                return "是";
            }
            else if (yn.ToUpper() == "N")
            {
                return "否";
            }
            return "資料錯誤";
        }

        /// <summary>
        /// 控制TextBox KeyPress事件僅能輸入數字
        /// </summary>
        /// <param name="e"></param>
        public void controlTextBoxInputNumberOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 轉換OBJ TO String
        /// </summary>
        /// <param name="obj"></param>
        public string getString(object obj)
        {
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
    }

}
