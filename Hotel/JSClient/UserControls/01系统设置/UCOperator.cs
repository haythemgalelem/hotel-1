using BusinessEntity.Model;
using BusinessOperator;
using Client.ProgramForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCOperator : UserControlBase, IUserControl
    {
        #region 属性
        private List<Operator> operators = null;
        #endregion

        #region 初始化
        public UCOperator()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.gdOperator.DoubleClick += gdOperator_DoubleClick;
        }

        void gdOperator_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Modify();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        #endregion

        #region 实现接口
        public void Init()
        {
            InitData();
        }


        public void Add()
        {
            FormEditOperator form = new FormEditOperator();
            form.operateType = "add";
            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.operators.Add(form.currentOperator);
                this.gdOperator.RefreshDataSource();
            }
        }

        public void Delete()
        {
            List<Operator> willDel = new List<Operator>();
            foreach (Operator o in this.operators)
            {
                if (o.Choose == true) willDel.Add(o);
            }

            if (new OperatorOperate().Del(willDel) == true)
            {
                foreach (Operator oo in willDel)
                {
                    this.operators.Remove(oo);
                }
                this.gdOperator.RefreshDataSource();
            }
        }

        public void Modify()
        {
            int index = this.gvOperator.GetFocusedDataSourceRowIndex();
            if (index < 0)
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }

            FormEditOperator form = new FormEditOperator();
            form.operateType = "modify";
            form.currentOperator = this.operators[index];

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.operators[index] = form.currentOperator;
                this.gdOperator.RefreshDataSource();
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
        #region 方法

        private void InitData()
        {
            ThreadExcute(() =>
            {
                this.operators = new OperatorOperate().GetList();
            });
            if (this.operators != null)
            {
                this.gdOperator.DataSource = this.operators;
                this.gdOperator.RefreshDataSource();
            }
        }

        #endregion
    }
}
