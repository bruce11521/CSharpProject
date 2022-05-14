using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStudio
{
    public partial class TEST : Form
    {
        private string first = "\n您知道第六回合生命表要上路了嗎？相關保險商品將依法令規定調整，近期疫情嚴峻，" +
                "是否趁此時檢視自身的保障是否足額，我幫您做一下全家的保單檢視，順便打個資料給您參考好嗎？\r\n" +
                "我們公司有一張美元保單，110年6月宣告利率是3.3%，每年繳交1000美元，就可享有高額保障，打個資料給您參考及解說好嗎？\r\n\r\n";
        public TEST()
        {
            InitializeComponent();

            radTextBox_Result.AcceptsReturn = true;
            radTextBox_Result.AcceptsTab = true;
            radTextBox_Result.Multiline = true;
            radTextBox_Result.WordWrap = true;
            radTextBox_Result.AutoScroll = true;
            radTextBoxControl_Name.AcceptsReturn = true;
            radTextBoxControl_Name.AcceptsTab = true;
            radTextBoxControl_Name.Multiline = true;
            radTextBoxControl_Name.WordWrap = true;
            radTextBoxControl_Name.AutoScroll = true;

            radTextBoxControl_Name.VerticalScroll.Enabled = true;
            radTextBox_Result.ScrollBars = ScrollBars.Vertical;

            radButton1.Click += RadButton1_Click;

            //小名;小花;小貓;陳先生;陳小姐;
        }

        private void RadButton1_Click(object sender, EventArgs e)
        {
            radTextBox_Result.Text = combin();
        }

        private string combin()
        {
            var nameList = radTextBoxControl_Name.Text.Split(';');
            var result = "";
            foreach(var item in nameList)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    result += "哈囉，" + item.TrimStart() + first;
                }
                
            }
            return result;
        }
    }
}
