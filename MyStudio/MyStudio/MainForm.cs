using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MyStudio
{
    public partial class MainForm : Form
    {
        private List<string> ContentList = new List<string>();
        public MainForm()
        {
            try
            {
                InitializeComponent();
                radMsgboxFont();
                this.Text = "密文產生器";
                

                rtbInput.Multiline = true;
                rtbInput.AcceptsReturn = true;
                rtbInput.WordWrap = true;
                rtbInput.ScrollBars = ScrollBars.Vertical;
                
                rtbOutput.Multiline = true;
                rtbOutput.AcceptsReturn = true;
                rtbOutput.WordWrap = true;
                rtbOutput.ScrollBars = ScrollBars.Vertical;

                

                rbtnCipher.Click += rbtnCiphe_Click;
                rtbInput.PreviewKeyDown += rtbLoginUserId_KeyDown;
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message + "\r\n\r\n" + ex.StackTrace;
                RadMessageBox.Show($"MainForm()\r\n{errorMsg}", "系統提示", MessageBoxButtons.OK, RadMessageIcon.Error);
                
            }
        }
        
        private void rtbLoginUserId_KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbtnCiphe_Click(sender, e);
                    
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show("發生錯誤，請通知維護人員！", "系統提示");
            }
        }
        private void rbtnCiphe_Click(object sender, EventArgs e)
        {
            try
            {
                string CipherText = "";
                
                if (!String.IsNullOrEmpty(rtbInput.Text))
                {
                    CipherText = rtbInput.Text;
                }
                else
                {
                    rtbOutput.Text = "";
                    RadMessageBox.Show("輸入內容為空!", "系統提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                    return;
                }

                ContentList = new List<string>();
                foreach (char item in CipherText)
                {
                    ContentList.Add(getString(item));   //儲存明文字串
                }
                List<int> intList = new List<int>();    //儲存明文分解過後的Int字串
                List<int> Keytemp = new List<int>();    //金鑰字串
                List<int> result = new List<int>();     //輸出密文
                

                
                foreach (string item in ContentList)    //分解字串
                {
                    int tempInt = 0;
                    if(Convert.ToInt32(item[0]) >= 65 && 90 >= Convert.ToInt32(item[0]))    //A-Z
                    {
                        tempInt = Convert.ToInt32(item[0]) - 64;
                        intList.Add(tempInt %= 10);
                    }
                    else if (Convert.ToInt32(item[0]) >= 97 && 122 >= Convert.ToInt32(item[0]))    //a-z
                    {
                        tempInt = Convert.ToInt32(item[0]) - 96;
                        if(tempInt / 10 > 0) //二位數
                        {
                            intList.Add(tempInt / 10);
                            intList.Add(tempInt % 10);
                        }
                        else
                        {
                            intList.Add(tempInt % 10);
                        }
                    }
                    else if(Convert.ToInt32(item[0]) >= 48 && 57 >= Convert.ToInt32(item[0]))   //0-9
                    {
                        tempInt = Convert.ToInt32(item[0]) - 48;
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 41)  // !
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 42)  // *
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 43)  // +
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 45)  // -
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 47)  // /
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 64)  // @
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 94)  // ^
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 95)  // _
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 126)  // ~
                    {
                        tempInt = Convert.ToInt32(item[0]);
                        intList.Add(tempInt);
                    }
                    else if (Convert.ToInt32(item[0]) == 13 || Convert.ToInt32(item[0]) == 10)  // \r  ||  \n
                    {
                        
                    }
                    else
                    {
                        if(Convert.ToInt32(item[0]) == 32)
                        {
                            RadMessageBox.Show("欲加密的文字不可輸入空格(Space).", "系統提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        }
                        else
                        {
                            RadMessageBox.Show("請輸入\"A-Za-z0-9!*+-/@^_~\"範圍內的數字.", "系統提示", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                        }
                        rtbOutput.Text = "";
                        return;
                    }
                    
                }

                
                for(int i=0; i< intList.Count; i++) //加密金鑰
                {
                    if(i == 0)
                    {
                        Keytemp.Add(1);
                    }
                    else
                    {
                        Keytemp.Add(1 + 2*i);
                    }
                    
                }

                int ix = 0;
                foreach (int item in intList)
                {
                    result.Add((item + Keytemp[ix++]) % 10);   //明文+金鑰 取最後一位
                }

                //輸出
                string resultStr = "", resultStr2 = "";
                foreach (int item in result)
                {
                    resultStr += item + ",";
                    resultStr2 += item;
                }
                rtbOutput.Text = resultStr.Length > 1 ? "含逗號:" + resultStr.Substring(0, resultStr.Length - 1) : "含逗號:" + resultStr;
                rtbOutput.Text +=  Environment.NewLine + Environment.NewLine + "不含逗號:" + resultStr2;

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message + "\r\n\r\n" + ex.StackTrace;
                RadMessageBox.Show($"rbtnCiphe_Click()\r\n{errorMsg}", "系統提示", MessageBoxButtons.OK, RadMessageIcon.Error);
                
            }
            
        }
        
        private string getString(object obj)
        {
            return obj != null ? obj.ToString() : "";
        }

        /// <summary>
        /// RadMessageBox樣式設定
        /// </summary>
        /// <param name="size">字體大小</param>
        public void radMsgboxFont(int? FontSize = null, int? ButtonSize = null, int? DetailFontSize = null)        //radMessageBox.show樣式設定, 可傳入int設定
        {
            float fontsize = float.Parse((FontSize != null ? FontSize.Value : 13).ToString());
            float buttonsize = float.Parse((ButtonSize != null ? ButtonSize.Value : 13).ToString());
            float detailsize = float.Parse((DetailFontSize != null ? DetailFontSize.Value : 12).ToString());
            RadMessageBox.Instance.Controls["radLabel1"].Font = new Font("微軟正黑體", fontsize, FontStyle.Regular);
            RadMessageBox.Instance.Controls["radButton1"].Font = new Font("微軟正黑體", buttonsize, FontStyle.Regular);
            RadMessageBox.Instance.Controls["radButton2"].Font = new Font("微軟正黑體", buttonsize, FontStyle.Regular);
            RadMessageBox.Instance.Controls["radTextBoxDetials"].Font = new Font("微軟正黑體", detailsize, FontStyle.Regular);
            RadMessageBox.Instance.AutoScaleMode = AutoScaleMode.None;
            RadMessageBox.Instance.TopMost = true;
        }

    }
}
