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
    public partial class FormEditRoom : FormDlgBase
    {
        public Room currentRoom = null;
        public string operateType = "add";
        public string father = "";
        public string buildingName = "";
        public string layerName = "";

        private List<RoomType> arr_RoomType = null;

        public FormEditRoom()
        {
            InitializeComponent();
            this.Load += FormEditRoom_Load;
        }

        void FormEditRoom_Load(object sender, EventArgs e)
        {
            this.txtBuilding.Text = this.buildingName;
            this.txtLayer.Text = this.layerName;

            if (this.operateType == "modify")
            {
                this.txtRoomNo.Text = this.currentRoom.RoomNo;
                this.cmbStatus.EditValue = this.currentRoom.Status;
                this.txtPhone.Text = this.currentRoom.Phone;
                this.cmbBedNum.EditValue = this.currentRoom.BedNum;
                this.searchRoomType.EditValue = this.currentRoom.RoomType;
                this.txtDescription.Text = this.currentRoom.Description;
                this.txtNote.Text = this.currentRoom.Note;
            }

            ThreadExcute(() =>
            {
                this.arr_RoomType = new RoomTypeOperator().GetList();
            });
            this.searchRoomType.Properties.ValueMember = "ID";
            this.searchRoomType.Properties.DisplayMember = "Name";
            this.searchRoomType.Properties.DataSource = this.arr_RoomType;
        }

        public override bool FormDlgBaseSave()
        {
            if (SetValue())
            {
                bool result = ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                    {
                        new RoomOperator().Add(this.currentRoom);
                    }
                    else if (this.operateType == "modify")
                    {
                        new RoomOperator().Update(this.currentRoom);
                    }
                });

                if (result == true)
                {
                    Program.MsgBoxInfo("保存成功");
                    return true;
                }
                else
                {
                    Program.MsgBoxInfo("保存失败");
                    return false;
                }
            }

            return false;
        }

        private bool SetValue()
        {
            if (this.currentRoom == null) this.currentRoom = new Room();

            if (this.txtRoomNo.Text.Trim() == "")
            {
                Program.MsgBoxError("房间号不能为空");
                return false;
            }

            if (operateType == "add")
            {
                this.currentRoom.RoomID = Guid.NewGuid().ToString();
                currentRoom.FloorID = father;
                currentRoom.IsDel = 0;
            }

            currentRoom.RoomType = (string)this.searchRoomType.EditValue;
            currentRoom.RoomNo = this.txtRoomNo.Text.Trim();
            currentRoom.Phone = this.txtPhone.Text.Trim();
            currentRoom.IsOwnUse = this.chkIsOwnUse.Checked == true ? 1:0;
            currentRoom.Status = this.cmbStatus.Text;
            currentRoom.BedNum = Convert.ToInt32(this.cmbBedNum.Text);
            currentRoom.Description = this.txtDescription.Text.Trim();
            currentRoom.Note = this.txtNote.Text.Trim();

            return true;
        }
    }
}
