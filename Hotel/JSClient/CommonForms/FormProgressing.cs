using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace Client.CommonForms
{
    ///<summary> 
    ///ģ���ţ�CF0004
    ///���ã�ϵͳ������ʾ���� 
    ///���ߣ�phq
    ///��д���ڣ�2011-11-03
    ///</summary> 
    public partial class FormProgressing : FormBase
    {
        public FormProgressing()
        {
            InitializeComponent();
        }

        public bool NeedClose = false;

        private void timer_Operate_Tick(object sender, EventArgs e)
        {
            if (NeedClose)
            {
                timer_Operate.Stop();
                this.Close();
            }
        }

        private void FormProgressing_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.NeedClose = false;
        }

        private void FormProgressing_Load(object sender, EventArgs e)
        {
            this.timer_Operate.Start();
        }
    }
}