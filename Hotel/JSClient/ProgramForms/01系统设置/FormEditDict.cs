using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Client.CommonForms;
using BusinessEntity.Model;
using BusinessOperator;
using Common;

namespace Client.ProgramForms
{
    public partial class FormEditDict : FormDlgBase
    {
        #region 初始化
        public FormEditDict()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //窗体加载
            this.Load += new System.EventHandler(this.FormEditDict_Load);
            //双击编号
            this.txt_DataDictionaryCode.DoubleClick += txt_DataDictionaryCode_DoubleClick;
        }

        void txt_DataDictionaryCode_DoubleClick(object sender, EventArgs e)
        {
            this.txt_DataDictionaryCode.Text =
                ChinessSpell.GetChineseSpell(this.cmb_DataDictionaryType.Text) +
                DateTime.Now.ToShortTimeString();
        }


        #endregion

        #region 属性
        public string DataDictionaryType = "部门设置";
        public string operateType = "add";//操作类型
        public DataDictionary CurrentDataDictionary = null;
        #endregion 

        #region 方法
        /// <summary>
        /// 重写保存
        /// </summary>
        /// <returns></returns>
        public override bool FormDlgBaseSave()
        {
            DataDictionary model = new DataDictionary();
            if (this.txt_DataDictionaryCode.Text.Trim() == "")
            {
                Program.MsgBoxInfo("编号不能为空！");
                return false;
            }
            if (this.txt_DataDictionaryName.Text.Trim() == "")
            {
                Program.MsgBoxInfo("名称不能为空！");
                return false;
            }
            //model.DataDictionaryID = this.CurrentDataDictionary.DataDictionaryID;
            model.DataDictionaryCode = this.txt_DataDictionaryCode.Text.Trim();
            model.DataDictionaryType = this.cmb_DataDictionaryType.Text.Trim();
            model.DataDictionaryName = this.txt_DataDictionaryName.Text.Trim();
            model.DataDictionaryDescription = this.txt_DataDictionaryDescription.Text.Trim();
            model.Note = this.txt_note.Text.Trim();
            //model.OperateName = Program.currentOperate.EmployeeName;
            model.OperateTime = DateTime.Now;
            //model.OperateID = Program.currentOperate.OperateID_;

            object result =  new BusinessOperator.DataDictionaryOperator().DataDictionary_Operate(model, operateType);
            if (result != null)
            {
                Program.MsgBoxInfo("保存成功!");
                this.CurrentDataDictionary = model;
                if (this.operateType == "add")
                {
                    this.CurrentDataDictionary.DataDictionaryID= (Guid)result;
                }
            }
            else
            {
                Program.MsgBoxError("保存失败!");
                return false;
            }
            return true;
        }
        #endregion

        #region 事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEditDict_Load(object sender, EventArgs e)
        {
            try
            {
                if (operateType == "add")
                    this.Text = "新增数据字典";
                else
                    this.Text = "编辑数据字典";
                this.cmb_DataDictionaryType.Text = this.DataDictionaryType;
                this.txt_DataDictionaryCode.Text = this.CurrentDataDictionary.DataDictionaryCode;
                this.txt_DataDictionaryName.Text = this.CurrentDataDictionary.DataDictionaryName;
                this.txt_DataDictionaryDescription.Text = this.CurrentDataDictionary.DataDictionaryDescription;
                this.txt_note.Text = this.CurrentDataDictionary.Note;

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        #endregion
    }
}
