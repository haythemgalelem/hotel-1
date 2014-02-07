using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Client.CommonForms;
using BusinessEntity.Model;
using BusinessOperator;

namespace Client.ProgramForms
{
    public partial class FormEditMember :FormDlgBase
    {
        #region 初始化

        public string operateType = "add";
        public Member currentMember = null;

        //做会员类型下拉
        private List<MemberType> arr_MemberType = null;

        public FormEditMember()
        {
            InitializeComponent();

            //窗体加载
            this.Load += FormEditMember_Load;

        }

        void FormEditMember_Load(object sender, EventArgs e)
        {
            try
            {
                bool result = ThreadExcute(() =>
                {
                    InitData();
                });

                if (result == false)
                {
                    Program.MsgBoxWarn("初始化数据失败");
                    return;
                }

                BindDataSource();

                if (this.operateType == "add")
                {

                }
                else if (this.operateType == "modify")
                {
                    SetControlValue();
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }


        private void BindDataSource()
        {
            foreach (MemberType mt in arr_MemberType)
            {
                this.cmbCarType.Properties.Items.Add(mt);
            }
        }

        private void InitData()
        {
            this.arr_MemberType = new MemberTypeOperator().GetList();

            
            //this.cmbCarType.DataBindings.Add("Dis
        }

        public override bool FormDlgBaseSave()
        {
            if (SetValue())
            {
                bool result = ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                    {
                        new MemberOperator().Add(this.currentMember);
                    }
                    else if (this.operateType == "modify")
                    {
                        new MemberOperator().Update(this.currentMember);
                    }
                });

                if (result == true)
                {
                    Program.MsgBoxInfo("保存成功");
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                    this.Close();
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
            if (currentMember == null) currentMember = new Member();

            if (this.txtMemberCarID.Text.Trim() == "")
            {
                Program.MsgBoxError("请填写卡号");
                return false;
            }

            if (this.txtMemberName.Text.Trim() == "")
            {
                Program.MsgBoxError("请填写会员名");
                return false;
            }

            if (this.cmbCarType.Text.Trim() == "")
            {
                Program.MsgBoxError("请选择会员类型");
                return false;
            }

            if (this.txtIDCard.Text.Trim() == "")
            {
                Program.MsgBoxError("请填写身份证");
                return false;
            }

            if (this.txtSex.Text.Trim() == "")
            {
                Program.MsgBoxError("请填写性别");
                return false;
            }

            if (this.cmbStatus.Text.Trim() == "")
            {
                Program.MsgBoxError("请选择状态");
                return false;
            }

            if (this.operateType == "add")
            {
                this.currentMember.MemberID = Guid.NewGuid().ToString();
            }

            currentMember.MemberCardID  = this.txtMemberCarID.Text.Trim();
            currentMember.MemberName    = this.txtMemberName.Text.Trim();
            currentMember.CardType      = ((MemberType)this.cmbCarType.SelectedItem).MemberTypeID;
            currentMember.IDCard        = this.txtIDCard.Text.Trim();
            currentMember.Sex           = this.txtSex.Text.Trim();
            currentMember.BirthDay      = this.dateBirthDay.DateTime;
            currentMember.HomeTel       = this.txtHomeTel.Text.Trim();
            currentMember.MobileTel     = this.txtMobileTel.Text.Trim();
            currentMember.Address       = this.txtAddress.Text.Trim();
            currentMember.Available     = this.chkAvailable.Checked == true ? 1 : 0;
            currentMember.RegTime       = this.dateRegTime.DateTime;
            currentMember.Score         = Convert.ToInt32(this.txtScore.Text.Trim());
            currentMember.Times         = Convert.ToInt32(this.txtScore.Text.Trim());

            string discountStr = this.txtDiscount.Text.Trim();
            discountStr = discountStr.Remove(discountStr.Length - 1, 1);
            double discount = Convert.ToDouble(discountStr);
            discount = discount / 100;

            currentMember.Discount      = Convert.ToDecimal(discount);
            currentMember.Balance       = Convert.ToDecimal(this.txtBalance.Text.Trim());
            currentMember.Status        = this.cmbStatus.EditValue.ToString();

            return true;
        }


        private void SetControlValue()
        {
            this.txtMemberCarID.Text        = currentMember.MemberCardID;
            this.txtMemberName.Text         = currentMember.MemberName  ;
            this.cmbCarType.SelectedItem = this.arr_MemberType.Find(delegate(MemberType o)
            {
                if (o.MemberTypeID == currentMember.CardType)
                    return true;
                else
                    return false;
            }); 
            this.txtIDCard.Text             = currentMember.IDCard   ;   
            this.txtSex.Text                = currentMember.Sex ;        
            this.dateBirthDay.DateTime      = Convert.ToDateTime(currentMember.BirthDay) ;   
            this.txtHomeTel.Text            = currentMember.HomeTel     ;
            this.txtMobileTel.Text          = currentMember.MobileTel   ;
            this.txtAddress.Text            = currentMember.Address     ;
            this.chkAvailable.Checked       = currentMember.Available == 1 ? true : false;
            this.dateRegTime.DateTime       = Convert.ToDateTime(currentMember.RegTime)     ;
            this.txtScore.Text              = currentMember.Score.ToString()      ;
            this.txtScore.Text              = currentMember.Times.ToString()      ;
            this.txtDiscount.Text           = currentMember.Discount.ToString()    ;
            this.txtBalance.Text            = currentMember.Balance.ToString();
            this.cmbStatus.EditValue        = currentMember.Status;
        }

        #endregion
    }
}
