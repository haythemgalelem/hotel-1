using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraEditors;
using BusinessEntity.Model;
namespace Client.Controls
{
    public partial class DictSearchLookUpEdit : SearchLookupEditBase
    {
        #region 初始化
        public DictSearchLookUpEdit()
        {
            InitializeComponent();
           
        }
        private void Init()
        {
            try
            {
                TimeSpan ts = Program.lastLoadDataDictionaryTime - DateTime.Now;
                if (Math.Abs(ts.TotalMinutes) >= Program.UPDATE_MINUTE)//离上次加载时间超过5分钟重新获取
                {
                    bool result = ThreadExcute(() =>
                    {
                        this.BindData();

                    }, true);
                    if (result)
                    {
                        Program.lastLoadDataDictionaryTime = DateTime.Now;
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        public DictSearchLookUpEdit(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        } 
        
        #endregion

        #region 属性
      
        public List<DataDictionary> list_DataDictionary_isValid = null;
        #endregion

        #region 方法
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            Program.currentDataDicionaryList = new BusinessOperator.DataDictionaryOperator().GetDataDictionaryList("all");
        }
        /// <summary>
        /// 绑定数据 
        /// </summary>
        /// <param name="bindType"></param>
        /// <param name="gridView"></param>
        public void BindList(string bindType)
        {
            this.Init();
            list_DataDictionary_isValid = new List<DataDictionary>();
            foreach (DataDictionary dict in Program.currentDataDicionaryList)
            {
                if (dict.DataDictionaryType == bindType)
                {
                    list_DataDictionary_isValid.Add(dict);
                }
            }
            this.Properties.DataSource = list_DataDictionary_isValid;
            this.Properties.DisplayMember = "DataDictionaryName";
            this.Properties.ValueMember = "DataDictionaryID";

        }
        #endregion

      

       

       
    }
}
