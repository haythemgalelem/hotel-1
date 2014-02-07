using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using BusinessEntity.Model;
namespace Client.CommonForms
{
    ///<summary> 
    ///模块编号： 
    ///作用：公共对话框类型窗体
    ///作者：phq
    ///编写日期：2013-4-9
    ///</summary> 
    public partial class FormDlgBase : DevExpress.XtraEditors.XtraForm
    {
        #region 初始化
        public FormDlgBase()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        public void InitEvent()
        {
            //关闭窗体
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDlgBase_FormClosed);
            //确定
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
        }
        #endregion
        #region 方法
        public virtual bool FormDlgBaseSave()
        {
            return true;
        }
        #endregion


        #region 事件
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDlgBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.FormDlgBaseSave())
                    this.DialogResult = DialogResult.Yes;

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
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
    }
}