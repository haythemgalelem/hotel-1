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
    public partial class UCCheckin : UserControlBase, IUserControl
    {
        private List<Checkin> arr_Checkin = null;

        public UCCheckin()
        {
            InitializeComponent();
        }

        
        #region 实现接口
        public void Init()
        {
            InitData();
        }

        public void Add()
        {
            FormEditCheckin form = new FormEditCheckin();
            form.operateType = "add";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                Refresh();
            }
        }

        public void Refresh()
        {
            InitData();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            int index = this.gvCheckin.GetFocusedDataSourceRowIndex();
            if (index < 0)
            {
                Program.MsgBoxError("请选中数据行");
                return;
            }
            FormEditCheckin form = new FormEditCheckin();
            form.currentCheckin = this.arr_Checkin[index];
            form.operateType = "modify";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                Refresh();
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
                this.arr_Checkin = new CheckinOperator().GetList();
            });

            if (result == true)
            {
                this.gdCheckin.DataSource = this.arr_Checkin;
                this.gdCheckin.RefreshDataSource();
            }
        }
        #endregion
    }
}
