using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Client.CommonForms
{
    ///<summary> 
    ///模块编号：CF0002
    ///作用：用户输入字符串的窗体
    ///作者：phq
    ///编写日期：2011-11-03
    ///</summary> 
    public partial class FormLock : FormBase
    {
        public FormLock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 已经输入的字符串
        /// </summary>
        public string StrInputed
        {
            get { return this.txt_InputStr.Text.Trim(); }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.txt_InputStr.Text.Trim() != "")
                {
                    //核对密码：
                    //string passWord = new Common.Cryptography().GetSaltedHash(this.txt_InputStr.Text.Trim());
                    //if (passWord != Program.CurrentEmployee.PW)
                    //{
                    //    e.Cancel = true;
                    //}
                }
                else
                {
                    Program.MsgBoxWarn("请输入密码！");
                    e.Cancel = true;
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {

        }
    }
}