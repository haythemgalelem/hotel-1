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

namespace Client.ProgramForms._02会员管理
{
    public partial class FormSetPwd : FormDlgBase
    {
        public Member currentMember = null;

        public FormSetPwd()
        {
            InitializeComponent();
        }

        public override bool FormDlgBaseSave()
        {
            if (this.txtPwd.Text.Trim() == "")
            {
                Program.MsgBoxInfo("请输入密码");
                return false;
            }

            if (this.txtConfirmPwd.Text.Trim() == "")
            {
                Program.MsgBoxInfo("请确认密码");
                return false;
            }

            if (this.txtPwd.Text.Trim() != this.txtConfirmPwd.Text.Trim())
            {
                Program.MsgBoxInfo("两次密码不一致");
                return false;
            }

            currentMember.Pwd = this.txtPwd.Text.Trim();

            bool result = ThreadExcute(() =>
            {
                new MemberOperator().Update(currentMember);
            });

            if (result == true)
            {
                Program.MsgBoxInfo("密码设置成功");
                return true;
            }

            return false;
        }
    }
}
