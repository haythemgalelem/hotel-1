using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Runtime.InteropServices;

namespace Client
{
    ///<summary> 
    ///模块编号：F00003
    ///作用：用户控件基类
    ///作者：phq
    ///编写日期：2012-7-09
    ///</summary> 
    public partial class UserControlBase : DevExpress.XtraEditors.XtraUserControl
    {

        #region 属性

        private bool _Hasbtn_Add = false;
        private bool _Hasbtn_Delete = false;
        private bool _Hasbtn_Modify = false;
        private bool _Hasbtn_Search = false;
        private bool _Hasbtn_Refresh = false;
        private bool _Hasbtn_Save = false;
        private bool _Hasbtn_Check = false;
        private bool _Hasbtn_Up = false;
        private bool _Hasbtn_Down = false; 
        
        private bool _Hasbtn_PreSave = false;
        private bool _Hasbtn_LoadData = false;
        private bool _Hasbtn_Clear = false;


        private bool _NeedInit = true;
        private bool _IsModify = false;
        private bool _IsAdd = false;
        private bool _IsDelete = false;



        private static Exception _e = null;

        /// <summary>
        /// 是否有清空数据按钮
        /// </summary>
        public bool Hasbtn_Clear
        {
            get { return _Hasbtn_Clear; }
            set { _Hasbtn_Clear = value; }
        }
        /// <summary>
        /// 是否有加载数据按钮
        /// </summary>
        public bool Hasbtn_LoadData
        {
            get { return _Hasbtn_LoadData; }
            set { _Hasbtn_LoadData = value; }
        }
        /// <summary>
        /// 是否有预保存按钮
        /// </summary>
        public bool Hasbtn_PreSave
        {
            get { return _Hasbtn_PreSave; }
            set { _Hasbtn_PreSave = value; }
        }

        /// <summary>
        /// 是否有增加按钮
        /// </summary>
        public bool Hasbtn_Add
        {
            get { return _Hasbtn_Add; }
            set { _Hasbtn_Add = value; }
        }

        /// <summary>
        /// 是否有删除按钮
        /// </summary>
        public bool Hasbtn_Delete
        {
            get { return _Hasbtn_Delete; }
            set { _Hasbtn_Delete = value; }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public bool Hasbtn_Refresh
        {
            get { return _Hasbtn_Refresh; }
            set { _Hasbtn_Refresh = value; }
        }
        /// <summary>
        /// 是否有修改按钮
        /// </summary>
        public bool Hasbtn_Modify
        {
            get { return _Hasbtn_Modify; }
            set { _Hasbtn_Modify = value; }
        }
        /// <summary>
        /// 是否有上移按钮
        /// </summary>
        public bool Hasbtn_Up
        {
            get { return _Hasbtn_Up; }
            set { _Hasbtn_Up = value; }
        }
        /// <summary>
        /// 是否有下移按钮
        /// </summary>
        public bool Hasbtn_Down
        {
            get { return _Hasbtn_Down; }
            set { _Hasbtn_Down = value; }
        }
        /// <summary>
        /// 是否有查找按钮
        /// </summary>
        public bool Hasbtn_Search
        {
            get { return _Hasbtn_Search; }
            set { _Hasbtn_Search = value; }
        }

        /// <summary>
        /// 是否有保存按钮
        /// </summary>
        public bool Hasbtn_Save
        {
            get { return _Hasbtn_Save; }
            set { _Hasbtn_Save = value; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool Hasbtn_Check
        {
            get { return _Hasbtn_Check; }
            set { _Hasbtn_Check = value; }
        }
        /// <summary>
        /// 是否需要初始化
        /// </summary>
        public bool NeedInit
        {
            get { return _NeedInit; }
            set { _NeedInit = value; }
        }

        /// <summary>
        /// 是否处于修改状态
        /// </summary>
        public bool IsModify
        {
            get { return _IsModify; }
            set
            {
                if (value)
                {
                    _IsModify = value;
                    _IsAdd = !value;
                    _IsDelete = !value;
                }
            }
        }

        /// <summary>
        /// 是否处于增加状态
        /// </summary>
        public bool IsAdd
        {
            get { return _IsAdd; }
            set
            {
                if (value)
                {
                    _IsModify = !value;
                    _IsAdd = value;
                    _IsDelete = !value;
                }
            }
        }

        /// <summary>
        /// 是否处于删除状态
        /// </summary>
        public bool IsDelete
        {
            get { return _IsDelete; }
            set
            {
                if (value)
                {
                    _IsModify = !value;
                    _IsAdd = !value;
                    _IsDelete = value;
                }
            }
        }

        /// <summary>
        /// 线程中的Exception
        /// </summary>
        public static Exception ThreadException
        {
            get { return _e; }
            set
            {
                _e = value;
            }
        }

        public UserControlBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        protected virtual void ExportData()
        {

        }

        /// <summary>
        /// 导入数据
        /// </summary>
        protected virtual void InportData()
        {

        }

        private ControlsAuthority _MyAuthority = new ControlsAuthority();

        /// <summary>
        /// 权限类
        /// 包含权限列表和快捷权限查询方法
        /// </summary>
        public ControlsAuthority MyAuthority
        {
            get { return _MyAuthority; }
            set { _MyAuthority = value; }
        }



        #endregion
        #region 线程操作
        /// <summary>
        /// 线程执行函数委托
        /// </summary>
        public delegate void ThreadExcuteMethod();
        /// <summary>
        /// 线程执行方法
        /// </summary>
        /// <param name="method">方法委托</param>
        /// <param name="showError">是否显示错误信息</param>
        /// <returns></returns>
        public bool ThreadExcute(ThreadExcuteMethod method, bool showError)
        {
            //线程异常信息
            Exception threadException = null;
            //使用自动同步事件作线程间同步
            using (AutoResetEvent threadWaitEvent = new AutoResetEvent(false))
            {
                //定义线程，使用匿名Lambda匿名委托
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        //调用方法
                        method();
                    }
                    catch (Exception ex)
                    {
                        //将线程异常信息放至父线程
                        threadException = ex;
                    }
                    finally
                    {
                        //线程结束前关闭进度对话框
                        Program.Form_Progress.NeedClose = true;
                        //设置同步事件为终止状态
                        threadWaitEvent.Set();
                    }
                });
                //启动线程
                thread.Start();
                //显示进度对话框
                Program.Form_Progress.ShowDialog();
                //主线程须等待子线程执行完毕后才能继续执行
                threadWaitEvent.WaitOne();
            }
            if (threadException != null)
            {
                if (showError) Program.MsgBoxError(threadException);
                threadException = null;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 线程执行方法，显示错误信息
        /// </summary>
        /// <param name="method">方法委托</param>
        /// <returns></returns>
        public bool ThreadExcute(ThreadExcuteMethod method)
        {
            return ThreadExcute(method, true);
        }

        /// <summary>
        /// 线程执行方法，不做保护，不暂停主线程
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public void ExcuteThread(ThreadExcuteMethod method)
        {
            Thread thread = new Thread(new ThreadStart(method));
            thread.Start();
        }
        #endregion
        #region 事件


        /// <summary>
        /// 调用导出数据方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbarbtn_ExportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ExportData();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 调用导入数据方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbarbtn_InportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                InportData();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        private void UserControlBase_Load(object sender, EventArgs e)
        {

        }
        #endregion

     
    }
}
