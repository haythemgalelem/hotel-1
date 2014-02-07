using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Client.CommonForms;
using Client.ProgramForms;
using BusinessEntity.Model;
using BusinessOperator;

namespace Client.ProgramForms
{
    public partial class FormEditCheckin : FormDlgBase
    {
        #region 属性
        public Checkin currentCheckin = null;
        public string operateType = "add";
        #endregion
        #region 初始化
        public FormEditCheckin()
        {
            InitializeComponent();

            //窗体加载
            this.Load += UCCheckin_Load;
            //弹出菜单
            this.gdRoom.MouseClick += gdRoom_MouseClick;
            //菜单添加
            this.menuAddRoom.Click +=menuAddRoom_Click;
            //菜单删除
            this.menuDelRoom.Click +=menuDelRoom_Click;
        }

        void UCCheckin_Load(object sender, EventArgs e)
        {
            if (operateType == "add")
            {
                currentCheckin = new Checkin();
            }
            InitData();

            if (this.operateType == "modify")
            {
                SetControlByModel();
            }
        }


        void menuDelRoom_Click(object sender, EventArgs e)
        {
            List<Checkin2Room> willDel = this.currentCheckin.arr_Rooms.FindAll(delegate(Checkin2Room r)
            {
                if (r.Choose)
                    return true;
                else
                    return false;
            });

            willDel.ForEach(delegate(Checkin2Room room)
            {
                //标志为删除
                room.WillDel = true;
            });

            this.gdRoom.DataSource = this.currentCheckin.arr_Rooms.FindAll(delegate(Checkin2Room room)
            {
                if (room.WillDel == false)
                    return true;
                else
                    return false;
            });
            this.gdRoom.RefreshDataSource();

        }

        void menuAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                FormSelectRoom form = new FormSelectRoom();
                form.type = "checkin";

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    Room room = form.arr_Select[0];

                    Checkin2Room chkRoom = new Checkin2Room();
                    #region 封装chkRoom
                    //房间类型
                    chkRoom.RoomTypeName = form.RoomTypeName;
                    //房间号
                    chkRoom.RoomCode = form.RoomCode;
                    //RoomID
                    chkRoom.RoomID = room.RoomID;
                    //开房类型
                    chkRoom.CheckinType = form.CheckinType;
                    //原单价
                    chkRoom.OriginalPrice = form.OriginalPrice;
                    //总共价格
                    chkRoom.TotalPrice = form.TotalPrice;
                    //折扣
                    chkRoom.Discount = form.Discount;
                    //折后单价
                    chkRoom.DiscountPrice = form.DiscountPrice;
                    //时间数量（多少天/多少小时)
                    chkRoom.TimeCount = form.TimeCount;
                    //退房时间
                    chkRoom.CheckoutTime = form.OutTime;
                    #endregion
                    if (currentCheckin.arr_Rooms == null) currentCheckin.arr_Rooms = new List<Checkin2Room>();
                    this.currentCheckin.arr_Rooms.Add(chkRoom);

                    //重新计算总价
                    CountTotalPrice();
                }
                //绑定数据源
                this.gdRoom.DataSource = this.currentCheckin.arr_Rooms.FindAll(delegate(Checkin2Room room)
                {
                    if (room.WillDel == false)
                        return true;
                    else
                        return false;
                });
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

        public void InitData()
        {
            //证件类型
            this.searchCarType.BindList("证件类型");
            //来自区域
            this.searchFromArea.BindList("地区国家");
            //来源
            this.searchFrom.BindList("客人来源");
            //客人类型
            this.searchCustomerType.BindList("客人类型");


        }

        /// <summary>
        /// 保存这张入住单
        /// </summary>
        /// <returns></returns>
        public override bool FormDlgBaseSave()
        {
            try
            {
                if (SetValue())
                {
                    bool result = false;

                    ThreadExcute(()=> 
                    {
                        if (operateType == "add")
                        {
                            result = new CheckinOperator().Add(currentCheckin);
                        }
                        else if (operateType == "modify")
                        {
                            result = new CheckinOperator().Update(currentCheckin);
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
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
                return false;
            }
        }

        private bool SetValue()
        {
            if (this.txtCheckinCode.Text.Trim() == "")
            {
                Program.MsgBoxError("入住单号不能为空");
                return false;
            }

            if (this.txtName.Text.Trim() == "")
            {
                Program.MsgBoxError("主客姓名不能为空");
                return false;
            }

            if (this.searchCarType.EditValue == null)
            {
                Program.MsgBoxError("必须选择一个证件类型");
                return false;
            }

            if (this.txtCarNum.Text.Trim() == "")
            {
                Program.MsgBoxError("证件号码不能为空");
                return false;
            }

            if (searchFromArea.EditValue == null)
            {
                Program.MsgBoxError("必须选择一个来自区域");
                return false;
            }

            if (searchFrom.EditValue == null)
            {
                Program.MsgBoxError("必须选择一个来源");
                return false;
            }

            if (searchCustomerType.EditValue == null)
            {
                Program.MsgBoxError("必须选择客人类型");
                return false;
            }

            if (this.txtName.Text.Trim() == "")
            {
                Program.MsgBoxError("主客姓名不能为空");
                return false;
            }

            this.currentCheckin.CheckinID = Guid.NewGuid().ToString();
            this.currentCheckin.CheckinCode = txtCheckinCode.Text.Trim();

            #region 填充主客资料
            currentCheckin.Customer.Name        = this.txtName.Text.Trim();
            currentCheckin.Customer.CarType     = ((Guid)this.searchCarType.EditValue).ToString();
            currentCheckin.Customer.CarNum      = this.txtCarNum.Text.Trim();
            currentCheckin.Customer.BirthDay    = this.datetxtBirthDay.DateTime;
            currentCheckin.Customer.Sex         = this.cmbSex.Text;
            currentCheckin.Customer.FromArea    = ((Guid)this.searchFromArea.EditValue).ToString();
            currentCheckin.Customer.From        = ((Guid)this.searchFrom.EditValue).ToString();
            currentCheckin.Customer.CustomerType = ((Guid)this.searchCustomerType.EditValue).ToString();
            currentCheckin.Customer.ShengShi    = this.txtShengShi.Text.Trim();
            currentCheckin.Customer.Address     = this.txtAddress.Text.Trim();
            currentCheckin.Customer.ImportantInfo = this.txtImportantInfo.Text.Trim();
            currentCheckin.Customer.Note        = this.txtNote.Text.Trim();

            currentCheckin.Customer.CustomerID = Guid.NewGuid().ToString();
            currentCheckin.CustomerID = currentCheckin.Customer.CustomerID;
            #endregion

            //设置房间ID
            currentCheckin.arr_Rooms.ForEach(delegate(Checkin2Room room)
            {
                room.Checkin2RoomID = Guid.NewGuid().ToString();
                room.CheckinID = currentCheckin.CheckinID;
            });
            //生成财务单
            currentCheckin.Finance.CheckinFinanceID = Guid.NewGuid().ToString();
            currentCheckin.Finance.CheckinID = currentCheckin.CheckinID;
            currentCheckin.Finance.CheckinFinanceCode = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString();
            currentCheckin.Finance.Status = "未结";
            currentCheckin.Finance.Money = CountTotalPrice();
            currentCheckin.Finance.IsOutBill = chkOutBill.Checked ? 1 : 0;
            currentCheckin.Finance.CheckinFinanceCode = this.txtCheckinFinanceCode.Text.Trim();

            return true;
        }


        private decimal CountTotalPrice()
        {
            decimal totalPrice = new decimal();

            this.currentCheckin.arr_Rooms.ForEach(delegate(Checkin2Room room)
            {
                totalPrice += Convert.ToDecimal(room.TotalPrice);
            });

            this.labTotalPrice.Text = "*应收" + totalPrice + "/共 + " + this.currentCheckin.arr_Rooms.Count + "间";
            return totalPrice;
        }


        private void SetControlByModel()
        {
            ThreadExcute(() =>
            {
                this.currentCheckin.arr_Rooms = new Checkin2RoomOperator().GetRooms(this.currentCheckin);
                this.currentCheckin.Customer = new CustomerOperator().GetModel(this.currentCheckin.CustomerID);
                this.currentCheckin.Finance = new CheckinFinanceOperator().GetModel(this.currentCheckin.CheckinID);
            });

            this.txtName.Text = this.currentCheckin.Customer.Name ;       
            this.searchCarType.EditValue = this.currentCheckin.Customer.CarType;     
            this.txtCarNum.Text = this.currentCheckin.Customer.CarNum;
            this.datetxtBirthDay.DateTime = Convert.ToDateTime(this.currentCheckin.Customer.BirthDay); 
            this.cmbSex.EditValue = this.currentCheckin.Customer.Sex;        
            this.searchFromArea.EditValue = this.currentCheckin.Customer.FromArea;   
            this.searchFrom.EditValue = this.currentCheckin.Customer.From;        
            this.searchCustomerType.EditValue = this.currentCheckin.Customer.CustomerType;
            this.txtShengShi.Text = this.currentCheckin.Customer.ShengShi; 
            this.txtAddress.Text = this.currentCheckin.Customer.Address;

            this.gdRoom.DataSource = this.currentCheckin.arr_Rooms;
            this.gdRoom.RefreshDataSource();

            this.txtCheckinFinanceCode.Text = this.currentCheckin.Finance.CheckinFinanceCode;
            this.txtCheckinFinanceCode.Enabled = false;
            this.chkOutBill.Checked = this.currentCheckin.Finance.IsOutBill == 1 ? true : false;
            this.chkOutBill.Enabled = false;
        }
    }
}
