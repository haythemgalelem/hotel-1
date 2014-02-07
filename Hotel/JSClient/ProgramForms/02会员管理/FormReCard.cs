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

namespace Client.ProgramForms
{
    public partial class FormReCard : FormDlgBase
    {
        public string operateType = "add";
        public Member currentMember = null;

        public FormReCard()
        {
            InitializeComponent();

            this.Load += FormReCard_Load;
        }

        void FormReCard_Load(object sender, EventArgs e)
        {
            if (operateType == "add")
            {
                this.txtMemberCarID.Text = this.currentMember.MemberCardID;
                this.txtMemberName.Text = this.currentMember.MemberName;
                this.txtMemberType.Text = this.currentMember.CardTypeName;
                this.txtTel.Text = this.currentMember.MobileTel;
            }
        }

        public override bool FormDlgBaseSave()
        {
            if (SetValue() == true)
            {
                bool result = ThreadExcute(() =>
                {
                    new MemberOperator().Update(this.currentMember);
                });

                if (result == true)
                {
                    Program.MsgBoxInfo("保存成功");
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SetValue()
        {
            if (this.txtNewCardID.Text.Trim() == "")
            {
                Program.MsgBoxInfo("请输入新的卡号");
                return false;
            }

            if (this.txtDayCount.Text.Trim() == "")
            {
                Program.MsgBoxInfo("请输入时间长度");
                return false;
            }

            this.currentMember.MemberCardID = this.txtNewCardID.Text.Trim();
            return true;
        }
    }
}
