using BusinessEntity.Model;
using BusinessOperator;
using Client.CommonForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.UserControls._02会员管理
{
    public partial class FormCharge : FormDlgBase
    {

        public Member currentMember = null;

        public FormCharge()
        {
            InitializeComponent();
        }

        public override bool FormDlgBaseSave()
        {
            if (this.textBox1.Text.Trim() == "") 
            {
                Program.MsgBoxError("请输入充值金额");
                return false;
            }

            double money = Convert.ToDouble(this.textBox1.Text.Trim());
            bool result = ThreadExcute(() => { new MemberOperator().Charge(currentMember, money); });

            if (result == true) 
            {
                Program.MsgBoxInfo("成功充值" + money + "元");
                
            }

            return true;
        }
    }
}
