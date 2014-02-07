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
    public partial class FormEditMemberType : FormDlgBase
    {
        #region 初始化

        public string operateType = "add";
        public MemberType currentMemberType = null;

        public FormEditMemberType()
        {
            InitializeComponent();

            //窗体加载
            this.Load += FormEditMemberType_Load;
        }

        void FormEditMemberType_Load(object sender, EventArgs e)
        {
            if (this.operateType == "add")
            {

            }
            else if (this.operateType == "modify")
            {
                this.txtTypeName.Text = currentMemberType.TypeName;
                this.txtScoreIncrease.Text = currentMemberType.ScoreIncrease;
                this.txtNote.Text = currentMemberType.Note;
                this.txtBaseDiscount.Text = (currentMemberType.BaseDiscount * 100).ToString() + "%";
            }
        }

        public override bool FormDlgBaseSave()
        {
            if (SetValue())
            {
                if (this.operateType == "add")
                {
                    this.currentMemberType.MemberTypeID = Guid.NewGuid().ToString();
                }

                bool result = ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                        new MemberTypeOperator().Save(currentMemberType);
                    else if (this.operateType == "modify")
                        new MemberTypeOperator().Update(currentMemberType);
                });

                if (result == true)
                {
                    Program.MsgBoxInfo("保存成功");
                    this.Close();
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool SetValue()
        {
            if (this.currentMemberType == null) this.currentMemberType = new MemberType();

            if (this.txtTypeName.Text.Trim() == "")
            {
                Program.MsgBoxError("请输入名称");
                return false;
            }

            if (this.txtBaseDiscount.Text.Trim() == "")
            {
                Program.MsgBoxError("请输入基础折扣");
                return false;
            }

            if (this.txtScoreIncrease.Text.Trim() == "")
            {
                Program.MsgBoxError("请输入积分增长");
                return false;
            }

            currentMemberType.TypeName = this.txtTypeName.Text.Trim();
            string discountStr = this.txtBaseDiscount.Text.Trim();
            discountStr = discountStr.Remove(discountStr.Length -1, 1);
            double discount = Convert.ToDouble(discountStr);
            discount = discount / 100;

            currentMemberType.BaseDiscount = Convert.ToDecimal(discount);
            currentMemberType.ScoreIncrease = this.txtScoreIncrease.Text.Trim();
            currentMemberType.Note = this.txtNote.Text.Trim();

            return true;
        }

        #endregion
    }
}
