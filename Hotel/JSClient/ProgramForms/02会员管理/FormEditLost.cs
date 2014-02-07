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
    public partial class FormEditLost : FormDlgBase
    {
        public Member currentMember = null;
        public Lost currentLost = null;
        public string operateType = "add";

        public FormEditLost()
        {
            InitializeComponent();

            //窗体加载
            this.Load += FormEditLost_Load;
        }

        void FormEditLost_Load(object sender, EventArgs e)
        {
            if (operateType == "add")
            {
                this.txtMemberCarID.Text = this.currentMember.MemberCardID;
                this.txtMemberName.Text = this.currentMember.MemberName;
                this.txtMemberType.Text = this.currentMember.CardTypeName;
                this.txtTel.Text = this.currentMember.MobileTel;

                this.txtOperator.Text = Program.currentOperate.OperateName;
                this.dateOperateTime.DateTime = DateTime.Now;
            }
            else if (operateType == "modify")
            {
                if (this.currentLost.Status == "已补卡")
                {
                    this.txtNote.Enabled        = false;
                    this.dateOperateTime.Enabled= false;
                    this.txtOperator.Enabled    = false;
                    this.txtReason.Enabled      = false;
                    this.dateLostTime.Enabled   = false;
                    this.cmbStatus.Enabled      = false;

                    this.txtNote.Text               = currentLost.Note;
                    this.dateOperateTime.DateTime   = Convert.ToDateTime(currentLost.OperateTime);
                    this.txtOperator.Text           = currentLost.OperatorName;
                    this.txtReason.Text             = currentLost.Reason;
                    this.dateLostTime.DateTime      = Convert.ToDateTime(currentLost.LostTime);
                    this.cmbStatus.Text             = currentLost.Status;
                }
            }
        }

        public override bool FormDlgBaseSave()
        {
            if (SetValue())
            {
                bool result = ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                    {
                        new LostOperator().Add(currentLost);
                        this.currentMember.Status = "挂失";
                    }
                    else if (this.operateType == "modify")
                    {
                        new LostOperator().Update(this.currentLost);
                    }
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
            if (this.currentLost == null)
            {
                this.currentLost = new Lost();
                this.currentLost.LostID = Guid.NewGuid().ToString();
            }

            if (this.dateLostTime.DateTime == null)
            {
                Program.MsgBoxError("请输入丢失时间");
                return false;
            }         

            currentLost.MemberID = this.currentMember.MemberID;
            currentLost.Reason = this.txtReason.Text.Trim();
            currentLost.Note = this.txtNote.Text.Trim();
            currentLost.Operator = Program.currentOperate.OperateID_;
            currentLost.OperateTime = DateTime.Now;
            currentLost.Status = this.cmbStatus.Text;
            currentLost.LostTime = this.dateLostTime.DateTime;

            return true;
        }
    }
}
