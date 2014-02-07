using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BusinessEntity.Model;
using Common;
using BusinessOperator;

namespace Client.ProgramForms
{
    public partial class Formlogin : FormBase
    {
        #region 初始化
        public Formlogin()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        private void InitEvent()
        {
            //登陆
            this.lbl_login.Click += new System.EventHandler(this.lbl_login_Click);
            //取消，关闭窗体
            this.lbl_cancel.Click += new System.EventHandler(this.btn_close_Click);
            //登录、取消标签字体颜色
            this.lbl_login.MouseEnter += new System.EventHandler(this.lbl_login_MouseEnter);
            this.lbl_login.MouseLeave += new System.EventHandler(this.lbl_login_MouseLeave);
            this.lbl_cancel.MouseEnter += new System.EventHandler(this.lbl_login_MouseEnter);
            this.lbl_cancel.MouseLeave += new System.EventHandler(this.lbl_login_MouseLeave);
        }
        #endregion

        #region 方法
     /// <summary>
     /// 鼠标拖动无边框窗体,通过重载消息处理实现
     /// 重写窗口过程(WndProc)，处理一些非客户区消息(WM_NCxxxx)，C#中重写窗口过程不用再调用SetWindowLong API了，
      /// 直接overide一个WndProc就可以了，不用声明api函数。
     /// </summary>
     /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {
                switch (m.Result.ToInt32())
                {
                    case 1:
                        m.Result = new IntPtr(2);
                        break;
                }
            }
        } 

        #endregion

        #region 事件
     
        /// <summary>
        /// 取消，关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Program.IsReStart)
                {
                    Application.Exit();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }

        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_login_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_PassWord.Enabled = false;
                this.lbl_login.Enabled = false;
                this.lbl_cancel.Enabled = false;
                this.panelBar_Login.Visible = true;
                this.lb_Notice.Visible = true;
                this.lb_Notice.Text = "加载：连接服务器";
                this.progBar_Login.EditValue = 10;
                this.Refresh();
                Application.DoEvents();
                this.lb_Notice.Text = "加载：验证数据";
                if (!Program.IsReStart)
                {
                    this.progBar_Login.EditValue = 20;
                }
                else
                {
                    this.progBar_Login.EditValue = 100;
                }
                this.Refresh();
                Application.DoEvents();
                if (!Program.IsReStart)
                {
                    //加载缓存
                    this.lb_Notice.Text = "加载：系统数据";
                    this.progBar_Login.EditValue = 25;
                    this.Refresh();
                    Application.DoEvents();

                    if (ThreadException != null)
                    {
                        Program.MsgBoxError(ThreadException);
                        ThreadException = null;
                    }
                    //判断登录
                    //Program.currentOperate = new Operator();
                    //Program.currentOperate.OperateID_ = "0E66D38D-CD7F-4677-A9F8-A62D4D328D75";
                    //Program.currentOperate.OperateCode = "admin";
                    //Program.currentOperate.OperateName = "系统管理员";

                    Program.currentOperate = CheckOperator(txt_UserName.Text.Trim(), Cryptography.GetSaltedHash(txt_PassWord.Text.Trim()));
                    if (Program.currentOperate == null)
                    {
                        Program.MsgBoxError("登录失败");

                    }
                    else
                    {
                        //加载配置文件
                        this.lb_Notice.Text = "加载：窗体";
                        this.progBar_Login.EditValue = 96;
                        this.Refresh();
                        Application.DoEvents();
                        Program.m_FormMain = new FormMain();
                        this.progBar_Login.EditValue = 100;
                        this.Hide();
                        Application.DoEvents();
                        Program.m_FormMain.Show();
                    }
                    //Program.currentUser = new User();
                    //Program.currentUser.UserID_ = new Guid("3E44119F-40C9-47D0-8567-43DA68F29F52");
                    //Program.currentUser.UserCode = "admin";
                    //Program.currentUser.UserName = "超级管理员";                   
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
            finally
            {
                this.lb_Notice.Visible = false;
                this.panelBar_Login.Visible = false;
                this.progBar_Login.EditValue = 0;
                this.lbl_login.Enabled = true;
                this.lbl_cancel.Enabled = true;
                this.txt_PassWord.Enabled = true;
            }
        }

        private Operator CheckOperator(string p1, string p2)
        {
            return new OperatorOperate().Vertify(p1, p2);
        }
        /// <summary>
        /// 鼠标进入改变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_login_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (sender == this.lbl_login)
                {
                    this.lbl_login.Appearance.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    this.lbl_cancel.Appearance.ForeColor = System.Drawing.Color.Yellow;
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }

        }
        /// <summary>
        /// 鼠标退出改变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_login_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.lbl_login.Appearance.ForeColor = System.Drawing.Color.PaleTurquoise;
                this.lbl_cancel.Appearance.ForeColor = System.Drawing.Color.PaleTurquoise;
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }
        #endregion

        
     

    }
}