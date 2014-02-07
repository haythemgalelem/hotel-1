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
    public partial class FormEditReserve : FormDlgBase
    {
        #region 属性
        public Reserve currentReserve = null;
        public string operateType = "add";
        #endregion
        #region 初始化

        public FormEditReserve()
        {
            InitializeComponent();
            InitThisEvent();
        }

        private void InitThisEvent()
        {
            //初始化
            this.Load += FormEditReserve_Load;
            //右键菜单添加或删除房间
            this.gdRoom.MouseClick += gdRoom_MouseClick;
            //添加房间
            this.menuAddRoom.Click += menuAddRoom_Click;
            //删除房间
            this.menuDelRoom.Click += menuDelRoom_Click;
        }

        void FormEditReserve_Load(object sender, EventArgs e)
        {
            if (this.operateType == "modify")
            {
                this.txtReserveCode.Enabled         = false;
                this.txtReserveCode.Text            = this.currentReserve.ReserveCode;

                this.txtName.Text                   = this.currentReserve.Name;
                this.txtTel.Text                    = this.currentReserve.Tel;
                this.dateKeep.DateTime              = Convert.ToDateTime(this.currentReserve.KeepTime);
                DateTime time = new DateTime();
                time = time.AddHours(this.dateKeep.DateTime.Hour);
                time = time.AddMinutes(this.dateKeep.DateTime.Minute);
                this.dateKeep_time.Time = time;
                this.cmbStatus.EditValue            = this.currentReserve.Status;
                this.txtNote.Text                   = this.currentReserve.Note;

                //初始化房间
                if (this.currentReserve.arr_Rooms == null)
                {
                    ThreadExcute(() =>
                    {
                        currentReserve.arr_Rooms = new ReserveOperator().GetRooms(currentReserve);
                    });

                }

                this.gdRoom.DataSource = currentReserve.arr_Rooms;
                this.gdRoom.RefreshDataSource();
            }
            else if (this.operateType == "add")
            {
                this.currentReserve = new Reserve();
                this.currentReserve.arr_Rooms = new List<Room>();

                
            }

            this.cmbStatus.Enabled = false;
        }

        void menuDelRoom_Click(object sender, EventArgs e)
        {
            List<Room> willDel = this.currentReserve.arr_Rooms.FindAll(delegate(Room r)
            {
                if (r.Choose)
                    return true;
                else
                    return false;
            });

            ThreadExcute(() =>
            {
                willDel.ForEach(delegate(Room room)
                {
                    room.Status = "空房";
                    new RoomOperator().Update(room);
                    this.currentReserve.arr_Rooms.Remove(room);
                });
            });
            

            this.gdRoom.RefreshDataSource();
        }

        void menuAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                FormSelectRoom form = new FormSelectRoom();
                form.selectedRoom = currentReserve.arr_Rooms;

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    this.currentReserve.arr_Rooms = new List<Room>();
                    this.currentReserve.arr_Rooms.AddRange(form.arr_Select);
                    this.currentReserve.arr_Rooms.ForEach(delegate(Room room)
                    {
                        room.Status = "预订";
                    });
                }
                this.gdRoom.DataSource = this.currentReserve.arr_Rooms;
                this.gdRoom.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void gdRoom_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.menu.Show();
            }
        }
        #endregion
        #region 方法
        public override bool FormDlgBaseSave()
        {
            if (SetValue())
            {
                bool result = ThreadExcute(() =>
                {
                    if (this.operateType == "add")
                    {
                        new ReserveOperator().Add(currentReserve);
                    }
                    else if (this.operateType == "modify")
                    {
                        new ReserveOperator().Update(currentReserve);
                    }
                });

                if (result == true)
                {
                    Program.MsgBoxInfo("保存成功");
                    return true;
                }
                else
                {
                    Program.MsgBoxError("保存失败");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool SetValue()
        {
            if (this.currentReserve == null) this.currentReserve = new Reserve();

            if (this.operateType == "add") this.currentReserve.ReserveID = Guid.NewGuid().ToString();

            if (this.txtReserveCode.Text.Trim() == "")
            {
                Program.MsgBoxError("预订单号不能为空，可双击生成");
                return false;
            }

            if (this.txtName.Text.Trim() == "")
            {
                Program.MsgBoxError("预订人不能为空");
                return false;
            }

            if (this.dateKeep.Text.Trim() == "")
            {
                Program.MsgBoxError("保留时间不能为空");
                return false;
            }

            DateTime keep = this.dateKeep.DateTime.Date;
            keep = keep.AddHours(this.dateKeep_time.Time.Hour);
            keep = keep.AddMinutes(this.dateKeep_time.Time.Minute);

            this.currentReserve.ReserveCode = this.txtReserveCode.Text.Trim();
            
            this.currentReserve.Name = this.txtName.Text.Trim();
            this.currentReserve.Tel = this.txtTel.Text.Trim();
            this.currentReserve.KeepTime = keep;
            this.currentReserve.Status = (string)this.cmbStatus.EditValue;
            this.currentReserve.Note = this.txtNote.Text.Trim();

            return true;
        }
        #endregion
    }
}
