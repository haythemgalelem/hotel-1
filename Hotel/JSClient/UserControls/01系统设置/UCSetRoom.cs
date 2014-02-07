using BusinessEntity.Model;
using BusinessEntity.Other;
using BusinessOperator;
using Client.ProgramForms;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCSetRoom : UserControlBase, IUserControl
    {
        #region 属性

        //楼层信息
        private List<Building> arr_Building = null;
        //房间信息
        private List<Room> arr_Room = null;
        //树结构数据
        private List<RoomTreeModel> arr_Tree = null;
        //将要删除的数据
        private List<RoomTreeModel> arr_WillDel = null;
        //绑定到表格中的数据
        private List<Room> arr_DataSource = null;
        

        #endregion

        public UCSetRoom()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.treeBuilding.MouseClick += treeBuilding_MouseClick;
            //----------------------------
            //菜单添加
            this.menuAdd.Click += menuAdd_Click;
            //菜单修改
            this.menuModify.Click += menuModify_Click;
            //菜单删除
            this.menuDel.Click += menuDel_Click;
            //----------------------------
            this.treeBuilding.FocusedNodeChanged += treeBuilding_FocusedNodeChanged;
        }

        void treeBuilding_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            RoomTreeModel model = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(e.Node);
            if (model == null) return;
            if (arr_DataSource == null) this.arr_DataSource = new List<Room>();
            this.arr_DataSource.Clear();

            this.arr_DataSource = this.arr_Room.FindAll(delegate(Room r)
            {
                if (r.FloorID == model.NodeID)
                    return true;
                else
                    return false;
            });

            foreach (Room rm in this.arr_DataSource)
            {
                RoomTreeModel mmm = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(e.Node.ParentNode);
                rm.BuildingName = mmm.NodeName;
                rm.LayerName = model.NodeName;
            }

            this.gdRoom.DataSource = this.arr_DataSource;
            this.gdRoom.RefreshDataSource();
        }

        void treeBuilding_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.menu.Show(e.Location);
            }
        }

        void menuDel_Click(object sender, EventArgs e)
        {
            RoomTreeModel model = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode);

            if (model == null)
            {
                Program.MsgBoxError("请选中要操作的数据");
                return;
            }

            if (model.Type == "First")
            {
                Program.MsgBoxError("这种操作太危险了，请考虑……");
                return;
            }

            arr_WillDel = new List<RoomTreeModel>();

            Del(this.treeBuilding.FocusedNode);

            List<RoomTreeModel> builds = arr_WillDel.FindAll(delegate(RoomTreeModel mfind)
            {
                if (mfind.Type == "Building" || mfind.Type == "Layer")
                {
                    return true;
                }
                else
                    return false;
            });

            List<RoomTreeModel> rooms = arr_WillDel.FindAll(delegate(RoomTreeModel mfind)
            {
                if (mfind.Type == "Room")
                {
                    return true;
                }
                else
                    return false;
            });

            bool result = ThreadExcute(() =>
            {
                //这里要做一个事务
                new BuildingOperator().Del(builds, rooms);
            });

            if (result == true)
            {
                Program.MsgBoxInfo("删除成功");
                return;
            }
            else
            {
                Program.MsgBoxError("删除失败");
                return;
            }
        }


        void menuModify_Click(object sender, EventArgs e)
        {
            RoomTreeModel model = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode);

            if (model == null)
            {
                Program.MsgBoxError("请选中要操作的数据");
                return;
            }

            if (model.Type == "First")
            {
                Program.MsgBoxError("此处不能修改");
                return;
            }
            else if (model.Type == "Building" || model.Type == "Layer")
            {
                Building b = (Building)Modify(model);
                if (b == null) return;
                int index = this.arr_Building.FindIndex(delegate(Building bb) 
                {
                    if (bb.BuildingID == model.NodeID)
                        return true;
                    else
                        return false;
                });
                this.arr_Building[index] = b;
            }
            else if (model.Type == "Room")
            {
                Room b = (Room)Modify(model);
                if (b == null) return;

                int index = this.arr_Room.FindIndex(delegate(Room bb)
                {
                    if (bb.RoomID == model.NodeID)
                        return true;
                    else
                        return false;
                });
                this.arr_Room[index] = b;
            }

            BindData();
        }

        void menuAdd_Click(object sender, EventArgs e)
        {
            RoomTreeModel model = (RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode);

            if (model == null)
            {
                Program.MsgBoxError("请选中要操作的数据");
                return;
            }

            if (model.Type != "Layer")
            {
                Building newBuilding = (Building)Add(model);
                if (newBuilding == null) return;
                this.arr_Building.Add(newBuilding);
            }
            else
            {
                Room newRoom = (Room)Add(model);
                if (newRoom == null) return;
                this.arr_Room.Add(newRoom);
            }
        
            BindData();
        }

        #region 实现接口
        public void Init()
        {
            InitData();
            BindData();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            throw new NotImplementedException();
        }

        public void Up()
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void Search()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Check()
        {
            throw new NotImplementedException();
        }

        public void SetModify()
        {
            throw new NotImplementedException();
        }

        public void SetAdd()
        {
            throw new NotImplementedException();
        }

        public void SetDelete()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void PreSave()
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 方法

        /// <summary>
        /// 将数据绑定到控件
        /// </summary>
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
                    roomNode.NodeName = r.RoomNo;
                    roomNode.Father = r.FloorID;
                    roomNode.Type = "Room";
                    this.arr_Tree.Add(roomNode);
                }
            }

            this.treeBuilding.KeyFieldName = "NodeID";
            this.treeBuilding.ParentFieldName = "Father";
            this.treeBuilding.DataSource = this.arr_Tree;
            this.treeBuilding.OptionsBehavior.Editable = false;
            this.treeBuilding.ExpandAll();
            this.treeBuilding.FocusedNode = this.treeBuilding.Nodes.FirstNode;
            this.treeBuilding.RefreshDataSource();
            //--------------------

        }

        /// <summary>
        /// 将数据从数据库中取出
        /// </summary>
        private void InitData()
        {
            bool result = ThreadExcute(() =>
            {
                this.arr_Building = new BuildingOperator().GetList();
                this.arr_Room = new RoomOperator().GetList();
            });

        }
        #endregion


        private object Add(RoomTreeModel model)
        {
            if (model.Type == "First")
            {
                FormEditBuilding form = new FormEditBuilding();
                form.operateType = "add";
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    return form.currentBuilding;
                }
                else
                    return null;
            }
            else if (model.Type == "Building")
            {
                FromEditLayer form = new FromEditLayer();
                form.operateType = "add";
                form.father = model.NodeID;
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    return form.currentLayer;
                }
                else
                {
                    return null;
                }
            }
            else if (model.Type == "Layer")
            {

                FormEditRoom form = new FormEditRoom();
                form.father = model.NodeID;
                form.operateType = "add";
                form.buildingName = ((RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode.ParentNode)).NodeName;
                form.layerName = model.NodeName;
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    return form.currentRoom;
                }
            }
            else
            {
                Program.MsgBoxError("此处不能添加任何东西");
                return null;
            }

            return null;
        }

        public object Modify(RoomTreeModel model)
        {
            if (model.Type == "First")
            {
                Program.MsgBoxError("此处不能编辑");
                return null;
            }
            else if (model.Type== "Building") 
            {
                FormEditBuilding form = new FormEditBuilding();
                form.operateType = "modify";
                form.currentBuilding = this.arr_Building.Find(delegate(Building b)
                {
                    if (b.BuildingID == model.NodeID)
                        return true;
                    else
                        return false;
                });

                if (form.ShowDialog() == DialogResult.Yes)
                {
                    return form.currentBuilding;
                }
                else
                    return null;
            }
            else if (model.Type == "Layer")
            {
                FromEditLayer form = new FromEditLayer();
                form.operateType = "modify";
                form.currentLayer = this.arr_Building.Find(delegate(Building b)
                {
                    if (b.BuildingID == model.NodeID)
                        return true;
                    else
                        return false;
                });
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    return form.currentLayer;
                }
                else
                    return null;
            }
            else if (model.Type == "Room")
            {
                FormEditRoom form = new FormEditRoom();
                form.operateType = "modify";
                form.buildingName = ((RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode.ParentNode.ParentNode)).NodeName;
                form.layerName = ((RoomTreeModel)this.treeBuilding.GetDataRecordByNode(this.treeBuilding.FocusedNode.ParentNode)).NodeName;
                form.currentRoom = this.arr_Room.Find(delegate(Room r)
                {
                    if (r.RoomID == model.NodeID)
                        return true;
                    else
                        return false;
                });
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    return form.currentRoom;
                }
                else
                    return null;
            }

            return null;
        }


        private void Del(TreeListNode node)
        {
            if (node.HasChildren)
            {
                TreeListNodes children = node.Nodes;
                foreach (TreeListNode n in children)
                {
                    Del(n);
                }               
            }
            this.arr_WillDel.Add((RoomTreeModel)treeBuilding.GetDataRecordByNode(node));
        }
    }
}
