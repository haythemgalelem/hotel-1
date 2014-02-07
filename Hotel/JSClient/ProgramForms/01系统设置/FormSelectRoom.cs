using BusinessEntity.Model;
using BusinessEntity.Other;
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
    public partial class FormSelectRoom : FormDlgBase
    {
        private List<Building> arr_Building = null;
        private List<Room> arr_Room = null;
        private List<RoomTreeModel> arr_Tree = null;
        public List<Room> arr_Select = null;
        public List<Room> selectedRoom = null;

        public string type = "reserve";

        public string CheckinType { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime OutTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int TimeCount { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomCode { get; set; }

        public FormSelectRoom()
        {
            InitializeComponent();

            //窗体加载
            this.Load += FormSelectRoom_Load;
            //选择不同的房间
            this.treeBuilding.FocusedNodeChanged += treeBuilding_FocusedNodeChanged;
            //折扣离开焦点计算折后价格
            this.txtDiscount.LostFocus += txtDiscount_LostFocus;
            //选择不同的开房方式
            this.cmbCheckinType.EditValueChanged += cmbCheckinType_EditValueChanged;
            //输入小时，改变预离时间
            this.txtHour.TextChanged += txtHour_TextChanged;
            //折扣率回车
            this.txtDiscount.KeyDown += txtDiscount_KeyDown;
        }

        void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Count();
            }
        }

        void treeBuilding_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                Count();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void txtHour_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Count();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void cmbCheckinType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Count();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        void txtDiscount_LostFocus(object sender, EventArgs e)
        {
            try
            {
                Count();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        public override bool FormDlgBaseSave()
        {
            this.arr_Select = new List<Room>();

            RoomTreeModel treeModel = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode);

            this.arr_Select.Add(this.arr_Room.Find(delegate(Room r) {
                if (treeModel.NodeID == r.RoomID)
                    return true;
                else
                    return false;
            }));

            bool result = true;
            //检查只能选择空房
            this.arr_Select.ForEach(delegate(Room room)
            {
                if (room.Status != "空房")
                {
                    Program.MsgBoxError("只能选择空房");
                    result = false;
                }
            });

            if (result == false) return false;

            if (this.arr_Select.Count <= 0)
            {
                Program.MsgBoxError("请选择房间");
                return false;
            }
            else
            {
                if (this.type == "checkin")
                {
                    this.CheckinType = this.cmbCheckinType.Text;
                    this.OriginalPrice = Convert.ToDecimal(this.txtOriginalPrice.Text.Trim());
                    this.Discount = Convert.ToInt32(this.txtDiscount.Text.Trim());
                    this.DiscountPrice = Convert.ToDecimal(this.txtDiscountPrice.Text.Trim());
                    this.TotalPrice = Convert.ToDecimal(this.labDiscountPrice.Text.Trim());
                    this.TimeCount = Convert.ToInt32(this.txtHour.Text.Trim());

                    this.RoomTypeName = this.arr_Select[0].RoomTypeName;
                    this.RoomCode = this.arr_Select[0].RoomNo;

                    if (this.cmbCheckinType.Text == "记天")
                    {
                        this.OutTime = DateTime.Now.AddDays(Convert.ToInt32(this.txtHour.Text.Trim()));
                    }
                    else if (this.cmbCheckinType.Text == "钟点房")
                    {
                        this.OutTime = DateTime.Now.AddHours(Convert.ToInt32(this.txtHour.Text.Trim()));
                    }
                }

                return true;
            }
        }

        void FormSelectRoom_Load(object sender, EventArgs e)
        {
            if (this.type != "checkin")
            {
                this.Width = 200;
            }

            try
            {
                InitData();
                BindData();

                if (selectedRoom != null && selectedRoom.Count > 0)
                {
                    foreach (Room r in selectedRoom)
                    {
                        arr_Tree.Find(delegate(RoomTreeModel model)
                        {
                            if (model.NodeID == r.RoomID)
                                return true;
                            else
                                return false;
                        }).Choose = true;
                    }
                }

                this.treeBuilding.RefreshDataSource();
                this.treeBuilding.ShowEditor();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }

            //List<RoomTreeModel> lll = new List<RoomTreeModel>();
            //RoomTreeModel m = new RoomTreeModel();
            //m.NodeName = "kkk";
            //m.Choose = true;
            //lll.Add(m);
            //this.treeBuilding.DataSource = lll;
            //this.treeBuilding.RefreshDataSource();

            //DataSet dataSet = new DataSet();
            //dataSet.ReadXml("C:\\Users\\Public\\Documents\\DevExpress 2011.1 Demos\\Components\\WinForms\\XtraTreeList\\CS\\TreeListTutorials\\bin\\Debug\\..\\..\\..\\..\\..\\..\\Data\\Departments.xml");
            //treeBuilding.DataSource = dataSet.Tables[0].DefaultView;
            //treeBuilding.PopulateColumns();
            //treeBuilding.BestFitColumns();
            //treeBuilding.ExpandAll();
        }

        private void BindData()
        {
            //--------------------绑定树形控件--------------------
            this.arr_Tree = new List<RoomTreeModel>();

            RoomTreeModel node = new RoomTreeModel();
            RoomTreeModel firstNode = new RoomTreeModel();
            firstNode.NodeID = Guid.NewGuid().ToString();
            firstNode.NodeName = "新世纪酒店管理系统";
            firstNode.Type = "First";
            firstNode.Father = null;
            this.arr_Tree.Add(firstNode);

            //楼跟层
            if (this.arr_Building != null && this.arr_Building.Count > 0)
            {
                foreach (Building b in this.arr_Building)
                {
                    node = new RoomTreeModel();
                    node.NodeID = b.BuildingID;
                    node.NodeName = b.Name;
                    node.Type = b.Type;
                    if (b.Type == "Building")
                    {
                        node.Father = firstNode.NodeID;
                    }
                    else
                    {
                        node.Father = b.Father;
                    }
                    this.arr_Tree.Add(node);
                }
            }
            //房间
            if (this.arr_Room != null && this.arr_Room.Count > 0)
            {
                foreach (Room r in arr_Room)
                {
                    RoomTreeModel roomNode = new RoomTreeModel();
                    roomNode.NodeID = r.RoomID;
                    roomNode.NodeName = r.RoomNo + "(" + r.Status + ")";
                    roomNode.Father = r.FloorID;
                    roomNode.Type = "Room";
                    this.arr_Tree.Add(roomNode);
                }
            }

            this.treeBuilding.KeyFieldName = "NodeID";
            this.treeBuilding.ParentFieldName = "Father";
            this.treeBuilding.DataSource = this.arr_Tree;
            this.treeBuilding.ExpandAll();
            this.treeBuilding.FocusedNode = this.treeBuilding.Nodes.FirstNode;
            this.treeBuilding.RefreshDataSource();
            //--------------------
        }

        private void InitData()
        {
            bool result = ThreadExcute(() =>
            {
                this.arr_Building = new BuildingOperator().GetList();
                this.arr_Room = new RoomOperator().GetList();
            });
        }

        private void Count()
        {
            RoomTreeModel treeModel = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode);
            Room room = this.arr_Room.Find(delegate(Room r)
            {
                if (treeModel.NodeID == r.RoomID)
                    return true;
                else
                    return false;
            });

            if (room == null) return;

            room.RoomTypeModel = new RoomTypeOperator().GetModel(room.RoomType);
            if (this.cmbCheckinType.Text == "记天")
            {
                this.txtOriginalPrice.Text = room.RoomTypeModel.Price.ToString();
                this.labOriginalPrice.Text = "实际价格(天)";
                this.gfaf.Text = "折后价格(天)";
                this.labTimeUnit.Text = "天";
            }
            else if (this.cmbCheckinType.Text == "钟点房")
            {
                this.txtOriginalPrice.Text = room.RoomTypeModel.HourRoomPrice.ToString();
                this.labOriginalPrice.Text = "实际价格(时)";
                this.gfaf.Text = "折后价格(时)";
                this.labTimeUnit.Text = "时";
            }

            //根据折扣率算出折后价格
            this.txtDiscountPrice.Text = ((Convert.ToDecimal(this.txtOriginalPrice.Text.Trim())) * ((Convert.ToDecimal(this.txtDiscount.Text.Trim())) / 100)).ToString();
            //根据预离时间算出总共的钱
            this.labDiscountPrice.Text = (Convert.ToDecimal(this.txtDiscountPrice.Text.Trim()) * (Convert.ToDecimal(this.txtHour.Text.Trim()))).ToString();
        }
    }
}
