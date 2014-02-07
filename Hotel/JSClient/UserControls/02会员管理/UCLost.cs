using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BusinessOperator;

namespace Client.UserControls._02会员管理
{
    public partial class UCLost : UserControlBase, IUserControl
    {
        private List<BusinessEntity.Model.Lost> arr_Lost = null;

        public UCLost()
        {
            InitializeComponent();
        }

        #region 实现接口
        public void Init()
        {
            InitData();
        }

        public void Refresh()
        {

            InitData();
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

        private void InitData()
        {
            bool result = ThreadExcute(() =>
            {
                this.arr_Lost = new LostOperator().GetList();
            });

            if (result == true)
            {
                this.gdLost.DataSource = this.arr_Lost;
                this.gdLost.RefreshDataSource();
            }
        }

        #endregion
    }
}
