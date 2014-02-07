using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraEditors;
using System.Threading;
using System.Runtime.InteropServices; 
namespace Client.Controls
{
    public partial class SearchLookupEditBase : SearchLookUpEdit
    {
        public SearchLookupEditBase()
        {
            InitializeComponent();
        }

        public SearchLookupEditBase(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        /// <summary>
        /// 重载创建组件
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Properties.NullText = "";
        }

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
    }
}
