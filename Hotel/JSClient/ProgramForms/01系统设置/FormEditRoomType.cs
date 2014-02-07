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
    public partial class FormEditRoomType : FormDlgBase
    {

        public string operateType { get; set; }
        public BusinessEntity.Model.RoomType currentRoomType { get; set; }

        public FormEditRoomType()
        {
            InitializeComponent();
            InitMyEvent();
        }

        private void InitMyEvent()
        {
            this.chkAllHourRoom.CheckedChanged += chkAllHourRoom_CheckedChanged;
            this.Load += FormEditRoomType_Load;
        }

        void FormEditRoomType_Load(object sender, EventArgs e)
        {
            if (this.operateType == "add") 
            {
                this.Text = "新增房间类型";
                this.chkAllHourRoom.Checked = false;
                this.txtHourRoomPrice.Enabled = false;
            }
            else if (this.operateType == "modify")
            {
                this.txtName.Text = this.currentRoomType.Name;
                this.txtPrice.Text = this.currentRoomType.Price.ToString();
                this.chkAllHourRoom.Checked = this.currentRoomType.AllowHourRoom == 1 ? true:false;
                this.txtHourRoomPrice.Text = this.currentRoomType.HourRoomPrice.ToString();
                this.Text = "修改房间类型";
            }
        }

        void chkAllHourRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAllHourRoom.Checked)
            {
                this.txtHourRoomPrice.Enabled = true;
            }
            else
            {
                this.txtHourRoomPrice.Enabled = false;
            }
        }

        public override bool FormDlgBaseSave()
        {
            if (SetValue() == true)
            {
                ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                    {
                        new RoomTypeOperator().Add(this.currentRoomType);
                    }
                    else if (this.operateType == "modify")
                    {
                        new RoomTypeOperator().Update(this.currentRoomType);
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
            if (this.currentRoomType == null) this.currentRoomType = new BusinessEntity.Model.RoomType();

            if (this.txtName.Text.Trim() == null)
            {
                Program.MsgBoxInfo("名称不能为空");
                return false;
            }

            if (this.txtPrice.Text.Trim() == "")
            {
                Program.MsgBoxInfo("价格不能为空");
                return false;
            }

            if(this.chkAllHourRoom.Checked == true && this.txtHourRoomPrice.Text.Trim() == "") 
            {
                Program.MsgBoxInfo("钟点房价格不能为空");
                return false;
            }

            this.currentRoomType.Name = this.txtName.Text.Trim();
            this.currentRoomType.Price = Convert.ToInt32(this.txtPrice.Text.Trim());
            this.currentRoomType.AllowHourRoom = this.chkAllHourRoom.Checked == true ? 1 : 0;
            if (this.currentRoomType.AllowHourRoom == 1)
            {
                this.currentRoomType.HourRoomPrice = Convert.ToInt32(this.txtHourRoomPrice.Text.Trim());
            }
            this.currentRoomType.Note = this.txtNote.Text.Trim();
            this.currentRoomType.Description = this.txtDescription.Text.Trim();

            if (this.operateType == "add")
            {
                this.currentRoomType.ID = Guid.NewGuid().ToString();
            }

            return true;
        }
    }
}
