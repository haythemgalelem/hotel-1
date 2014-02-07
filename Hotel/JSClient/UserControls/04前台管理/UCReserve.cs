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
    public partial class UCReserve : UserControlBase, IUserControl
    {

        private List<Reserve> arr_Reserve = null;

        public UCReserve()
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
            FormEditReserve form = new FormEditReserve();
            form.operateType = "add";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_Reserve.Add(form.currentReserve);
                this.gdServe.RefreshDataSource();
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            int index = this.gvServe.GetFocusedDataSourceRowIndex();
            if (index < 0) 
            {
                Program.MsgBoxError("请选中数据行");
                return ;
            }
            FormEditReserve form = new FormEditReserve();
            form.currentReserve = this.arr_Reserve[index];
            form.operateType = "modify";

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_Reserve[index] = form.currentReserve;
                this.gdServe.RefreshDataSource();
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

        public void Refresh()
        {
            InitData();
        }

        #endregion

        #region　方法

        private void InitData()
        {
            bool result = ThreadExcute(() =>
            {
                this.arr_Reserve = new ReserveOperator().GetList();
            });

            if (result == true && this.arr_Reserve.Count > 0)
            {
                this.gdServe.DataSource = this.arr_Reserve;
                this.gdServe.RefreshDataSource();
            }
        }

        #endregion
    }
}
