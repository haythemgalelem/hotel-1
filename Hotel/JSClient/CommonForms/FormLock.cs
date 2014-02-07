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
    ///ģ���ţ�CF0002
    ///���ã��û������ַ����Ĵ���
    ///���ߣ�phq
    ///��д���ڣ�2011-11-03
    ///</summary> 
    public partial class FormLock : FormBase
    {
        public FormLock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �Ѿ�������ַ���
        /// </summary>
        public string StrInputed
        {
            get { return this.txt_InputStr.Text.Trim(); }
        }

        /// <summary>
        /// ���ڹر��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLock_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.txt_InputStr.Text.Trim() != "")
                {
                    //�˶����룺
                    //string passWord = new Common.Cryptography().GetSaltedHash(this.txt_InputStr.Text.Trim());
                    //if (passWord != Program.CurrentEmployee.PW)
                    //{
                    //    e.Cancel = true;
                    //}
                }
                else
                {
                    Program.MsgBoxWarn("���������룡");
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