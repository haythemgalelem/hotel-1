using BusinessEntity.Model;
using BusinessOperator;
using Client.CommonForms;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.ProgramForms
{
    public partial class FormEditOperator : FormDlgBase
    {
        #region 属性

        public string operateType = "add";
        public Operator currentOperator = null;

        #endregion
        #region 初始化
        public FormEditOperator()
        {
            InitializeComponent();
            InitThisEvent();
        }

        private void InitThisEvent()
        {
           //窗体加载
            this.Load += FormEditOperator_Load;
            //当用户名失去焦点
            this.txtOperateName.LostFocus += txtOperateName_LostFocus;
        }

        void txtOperateName_LostFocus(object sender, EventArgs e)
        {
            this.txtOperateCode.Text = ChinessSpell.GetChineseSpell(this.txtOperateName.Text);
        }

        void FormEditOperator_Load(object sender, EventArgs e)
        {
            if (this.operateType == "modify")
            {
                this.Text = "修改用户";
                this.txtOperateName.Text = this.currentOperator.OperateName;
                this.txtOperateCode.Text = this.currentOperator.OperateCode;
                this.txtPwd.Enabled = false;
                this.txtConfirm.Enabled = false;
                this.chkStatus.Checked = this.currentOperator.StateBool;
            }
            else
            {
                this.Text = "添加新用户";
            }
        }
        #endregion

        public override bool FormDlgBaseSave()
        {
            if (SetValue() == true)
            {
                ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                    {
                        new OperatorOperate().Add(this.currentOperator);
                    }
                    else if (this.operateType == "modify")
                    {
                        new OperatorOperate().Update(this.currentOperator);
                    }
                });

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SetValue()
        {
            if (this.currentOperator == null)
            {
                this.currentOperator = new Operator();
            }

            if (this.txtOperateCode.Text.Trim() == "")
            {
                Program.MsgBoxError("请输入登录名");
                return false;
            }

            if (this.txtOperateName.Text.Trim() == "")
            {
                Program.MsgBoxError("请输入用户名");
                return false;
            }

            if (this.operateType == "add")
            {
                if (this.txtPwd.Text.Trim() == "")
                {
                    Program.MsgBoxError("请输入密码");
                    return false;
                }

                if (this.txtPwd.Text.Trim() != this.txtConfirm.Text.Trim())
                {
                    Program.MsgBoxError("密码不一致");
                    return false;
                }
            }

            if (this.operateType == "add")
            {
                this.currentOperator.OperateID_ = Guid.NewGuid().ToString();
            }
            this.currentOperator.OperateName = this.txtOperateName.Text.Trim();
            this.currentOperator.OperateCode = this.txtOperateCode.Text.Trim();
            this.currentOperator.Passwords = Cryptography.GetSaltedHash(this.txtPwd.Text.Trim());
            this.currentOperator.StateBool = this.chkStatus.Checked;

            this.currentOperator.OperatorID_ = Program.currentOperate.OperateID_;
            this.currentOperator.OperateTime = DateTime.Now;

            return true;
        }
    }
}
