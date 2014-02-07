using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BusinessEntity.Model;
using BusinessOperator;

namespace Client.UserControls
{
    public partial class UCCustomer : UserControlBase, IUserControl
    {
        #region 属性
        private List<Customer> customers = null;
        #endregion

        #region 初始化
        public UCCustomer()
        {
            InitializeComponent();
        }

        #endregion

        #region 实现接口
        public void Init()
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
                this.customers = new CustomerOperator().GetList();
            });

            if (result)
            {
                this.gdCustomer.DataSource = this.customers;
                this.gdCustomer.RefreshDataSource();
            }
        }


        #endregion
    }
}
