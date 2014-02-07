using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Client.ProgramForms;
using BusinessEntity.Model;
using BusinessOperator;

namespace Client.UserControls
{
    ///<summary> 
    ///模块编号：UC0101
    ///作用：基础字典
    ///作者：phq
    ///编写日期：2013-4-9
    ///</summary> 
    public partial class UCDataDictionary : UserControlBase, IUserControl
    {
        #region 初始化
        public UCDataDictionary()
        {
            InitializeComponent();
            InitEvent(); 
        }
        public void InitEvent()
        {
            
            //选择类型
            this.navBarControl_left.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl_left_LinkClicked);
            //双击行
            this.gv_dataDictionary.DoubleClick += new System.EventHandler(this.gv_dataDictionary_DoubleClick);
            //勾选
            this.gv_dataDictionary.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_dataDictionary_CellValueChanging);
            
        }
       
        #endregion

        #region 属性
        private string DataDictionaryType = "部门设置";
        private List<DataDictionary> arr_DataSource = new List<DataDictionary>();
        #endregion

        #region 接口实现
        public void Init()
        {
            this.BindData();
        }
        public void Add()
        {
            try
            {
                FormEditDict form = new FormEditDict();
                form.DataDictionaryType = this.DataDictionaryType;
                form.operateType = "add";
                form.CurrentDataDictionary = new DataDictionary();
                //form.CurrentDataDictionary.State = true;
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    this.arr_DataSource.Add(form.CurrentDataDictionary);
                    this.gc_dataDictionary.RefreshDataSource();
                    Program.lastLoadDataDictionaryTime = new DateTime();
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete()
        {
            try
            {
                List<DataDictionary> list_choose = new List<DataDictionary>();
                foreach (DataDictionary dict in this.arr_DataSource)
                {
                    if (dict.Choose)
                    {
                        list_choose.Add(dict);
                    }
                }
                if (list_choose.Count == 0)
                {
                    Program.MsgBoxInfo("请选中数据行！");
                    return;
                }
                if (Program.MsgBoxYesNo("您确定要删除吗?") == DialogResult.Yes)
                {
                    object rows = 0;
                    bool isSuccessRun = false;//是否有成功执行过
                    foreach (DataDictionary dict in list_choose)
                    {
                        rows = new BusinessOperator.DataDictionaryOperator().DataDictionary_Operate(dict, "delete");
                        if ((int)rows > 0)
                        {
                            this.arr_DataSource.Remove(dict);
                            isSuccessRun = true;
                        }
                    }
                    if (isSuccessRun)
                    {
                        Program.MsgBoxInfo("删除成功！");
                        this.gc_dataDictionary.RefreshDataSource();
                        Program.lastLoadDataDictionaryTime = new DateTime();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        /// <summary>
        /// 编辑修改
        /// </summary>
        public void Modify()
        {
            try
            {
                if (this.gv_dataDictionary.GetFocusedDataSourceRowIndex() < 0)
                {
                    Program.MsgBoxInfo("请选中数据行!");
                    return;
                }
                FormEditDict form = new FormEditDict();
                form.CurrentDataDictionary = this.arr_DataSource[this.gv_dataDictionary.GetFocusedDataSourceRowIndex()];
                form.DataDictionaryType = this.DataDictionaryType;
                form.operateType = "update";
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    for (int i = 0; i < this.arr_DataSource.Count; i++)
                    {
                        if (this.arr_DataSource[i].DataDictionaryID == form.CurrentDataDictionary.DataDictionaryID)
                        {
                            this.arr_DataSource[i] = form.CurrentDataDictionary;
                            break;
                        }
                    }
                    this.gc_dataDictionary.RefreshDataSource();
                    Program.lastLoadDataDictionaryTime = new DateTime();
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        public void Up()
        {

        }
        public void Down()
        {

        }
        public void Search()
        {

        }
        public void Refresh()
        {
            this.BindData();
        }
        public void Save()
        {

        }
        public void Check()
        {
        }
        public void SetModify()
        {
        }
        public void SetAdd()
        {
        }
        public void SetDelete()
        {
        }
        public void Clear()
        {

        }
        public void PreSave()
        {

        }
        public void LoadData()
        {
        }
        #endregion

        #region 方法
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {            
            bool result = ThreadExcute(() =>
            {
                this.arr_DataSource = new DataDictionaryOperator().GetDataDictionaryList(this.DataDictionaryType);

            }, true);
            if (result)
            {
                this.gc_dataDictionary.DataSource = this.arr_DataSource;
                this.gc_dataDictionary.RefreshDataSource();
            }           

        }
       
        #endregion 

        #region 事件
        /// <summary>
        /// 选择类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarControl_left_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                this.DataDictionaryType = e.Link.Caption;
                foreach(DevExpress.XtraNavBar.NavBarItem item in this.navBarControl_left.Items)
                {
                    item.Appearance.ForeColor = System.Drawing.Color.Black;
                    item.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
                }
                e.Link.Item.Appearance.ForeColor = System.Drawing.Color.Red;
                e.Link.Item.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                this.BindData();
            }
            catch(Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_dataDictionary_DoubleClick(object sender, EventArgs e)
        {
            this.Modify();
        }
        
        /// <summary>
        /// 勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_dataDictionary_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0 && e.Column.FieldName == "Choose")
                {
                    this.arr_DataSource[this.gv_dataDictionary.GetFocusedDataSourceRowIndex()].Choose = Convert.ToBoolean(e.Value);
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        #endregion   
    }
}
