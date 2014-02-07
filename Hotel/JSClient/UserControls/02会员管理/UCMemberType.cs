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
    public partial class UCMemberType : UserControlBase, IUserControl
    {
        #region 初始化

        private List<MemberType> arr_MemberType = null;

        public UCMemberType()
        {
            InitializeComponent();

            //窗体加载
            this.Load += UCMemberType_Load;
            //双击修改
            this.gdMemberType.DoubleClick += gdMemberType_DoubleClick;
        }

        void gdMemberType_DoubleClick(object sender, EventArgs e)
        {
            Modify();
        }

        void UCMemberType_Load(object sender, EventArgs e)
        {
            
        }
        #endregion
        #region 实现接口
        public void Init()
        {
            InitData();
        }

        public void Add()
        {
            FormEditMemberType form = new FormEditMemberType();
            form.operateType = "add";
            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_MemberType.Add(form.currentMemberType);
                this.gdMemberType.RefreshDataSource();
            }
        }

        public void Delete()
        {
            this.gridView1.FocusedColumn = null;
            List<MemberType> willDel = new List<MemberType>();
            StringBuilder buf = new StringBuilder();

            foreach(MemberType m in arr_MemberType) 
            {
                if (m.Choose) 
                {
                    willDel.Add(m);
                    buf.AppendLine(m.TypeName);
                }
            }

            if (Program.MsgBoxYesNo("你是否要删除以下项目：\n" + buf.ToString()) == DialogResult.Yes)
            {

                bool result = ThreadExcute(() =>
                {
                    new MemberTypeOperator().Del(willDel);
                });

                if (result == true)
                {
                    Program.MsgBoxInfo("删除成功");

                    foreach (MemberType t in willDel)
                    {
                        this.arr_MemberType.Remove(t);
                    }

                    this.gdMemberType.RefreshDataSource();
                }
            }
        }

        public void Modify()
        {
            int index = this.gridView1.GetFocusedDataSourceRowIndex();
            if (index < 0) 
            {
                Program.MsgBoxInfo("请选中数据行");
                return;
            }

            FormEditMemberType form = new FormEditMemberType();
            form.operateType = "modify";
            form.currentMemberType = this.arr_MemberType[index];

            if (form.ShowDialog() == DialogResult.Yes)
            {
                this.arr_MemberType[index] = form.currentMemberType;
                this.gdMemberType.RefreshDataSource();
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
            bool result = ThreadExcute(() =>
            {
                this.arr_MemberType = new MemberTypeOperator().GetList();
            });

            if (result == true)
            {
                this.gdMemberType.DataSource = this.arr_MemberType;
                this.gdMemberType.RefreshDataSource();
            }
        }
        #endregion
    }
}
