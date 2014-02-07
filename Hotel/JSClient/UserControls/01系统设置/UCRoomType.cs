using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BusinessEntity.Model;
using BusinessOperator;
using Client.ProgramForms;

namespace Client.UserControls
{
    public partial class UCRoomType : UserControlBase, IUserControl
    {
        private List<RoomType> roomTypes = null;

        public UCRoomType()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.gdRoomType.DoubleClick += gdRoomType_DoubleClick;
        }

        void gdRoomType_DoubleClick(object sender, EventArgs e)
        {
            Modify();
        }

        #region 实现接口
        public void Init()
        {
            InitData();
        }

        public void Add()
        {
            FormEditRoomType form = new FormEditRoomType();
            form.operateType = "add";
            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.roomTypes.Add(form.currentRoomType);
                this.gdRoomType.RefreshDataSource();
            }
        }

        public void Delete()
        {
            List<RoomType> willDel = new List<RoomType>();
            StringBuilder buf = new StringBuilder();

            foreach (RoomType m in this.roomTypes)
            {
                if (m.Choose)
                {
                    willDel.Add(m);
                    buf.Append(m.Name + "\n");
                }
            }

            if (Program.MsgBoxYesNo("你确定要删除以下房间类型吗？\n" + buf.ToString()) == DialogResult.Yes)
            {
                if (new RoomTypeOperator().Del(willDel) == true)
                {
                    foreach (RoomType r in willDel)
                    {
                        this.roomTypes.Remove(r);
                    }

                    this.gdRoomType.RefreshDataSource();
                }
            }           
        }

        public void Refresh()
        {
            InitData();
        }

        public void Modify()
        {
            int index = this.gvRoomType.GetFocusedDataSourceRowIndex();
            if (index < 0)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }

            FormEditRoomType form = new FormEditRoomType();
            form.operateType = "modify";
            form.currentRoomType = this.roomTypes[index];

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.roomTypes[index] = form.currentRoomType;
                this.gdRoomType.RefreshDataSource();
            }
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


        private void InitData()
        {
            bool result = ThreadExcute(() =>
            {
                this.roomTypes = new RoomTypeOperator().GetList();
            });

            if (result)
            {
                this.gdRoomType.DataSource = this.roomTypes;
                this.gdRoomType.RefreshDataSource();
            }
        }


        #endregion
    }
}
