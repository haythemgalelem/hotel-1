using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Client.UserControls;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using Client.CommonForms;
using System.IO;
using Client.UserControls._02会员管理;



namespace Client.ProgramForms
{
    public partial class FormMain : FormBase,IUserControl
    {
        #region 初始化
        public FormMain()
        {
            InitializeComponent();
            InitEvent();
        }
        #endregion

        #region InitEvent 初始化事件
        /// <summary>
        /// 初始化按钮事件和窗体事件！
        /// </summary>
        private void InitEvent()
        {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.nbarc_Main.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.nbarc_Main_GroupExpanded);
            this.nbarc_Main.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbarc_Main_LinkClicked);
            this.nbarc_Main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nbarc_Main_MouseClick);
            this.barmrg_MainForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barmrg_MainForm_ItemClick);//单击菜单项

            this.btn_ReLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ReLogin_ItemClick);//注销
            this.barbtn_Grider.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Gider_ItemClick);//点击导航条
            this.barbtn_Lock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Lock_ItemClick);   //锁定
            this.barbtn_Cancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Cancel_ItemClick);//退出
            this.barbtn_Add.ItemClick +=new DevExpress.XtraBars.ItemClickEventHandler(barbtn_Add_ItemClick);//新增
            this.barbtn_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barbtn_Delete_ItemClick);//删除
            this.barbtn_Modify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barbtn_Modify_ItemClick); //修改
            this.barbtn_Check.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barbtn_Check_ItemClick);//审核
            this.barBtn_Clear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_Clear_ItemClick);//清空数据
            this.barbtn_refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barbtn_refresh_ItemClick); //刷新
            this.barbtn_up.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barbtn_up_ItemClick); //上移
            this.barbtn_down.ItemClick+= new DevExpress.XtraBars.ItemClickEventHandler(barbtn_down_ItemClick);//下移动
            this.barbtn_Search.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Search_ItemClick); //查询
            this.barbtn_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Save_ItemClick);//保存提交
            this.barBtn_PreSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_PreSave_ItemClick);//预保存
            this.barBtn_LoadData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_LoadData_ItemClick);//加载数据
            this.barbtn_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Close_ItemClick);//关闭
            this.barbtn_ChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_ChangePassword_ItemClick);//修改密码
            this.barbtn_Caculate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Caculate_ItemClick);//计算器
            this.barbtn_txtBook.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_txtBook_ItemClick);//记事本
            this.barbtn_Used1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_Used_ItemClick);//刚用过
            this.btn_SystemMessage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SystemMessage_ItemDoubleClick);//系统消息
            this.btn_LookSysMsg.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LookSysMsg_ItemClick);//停止滚动
            this.tabc_Main.CloseButtonClick += new System.EventHandler(this.tabc_Main_CloseButtonClick);//关闭tabc页面
            this.tabc_Main.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabc_Main_SelectedPageChanged);//切换不同页面
            this.barckb_UsedUserContorls.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barckb_UsedUserContorls_CheckedChanged);//曾经使用过的组件
            this.barbtn_CloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtn_CloseAll_ItemClick);//全部关闭
            this.timer_Msg.Tick += new System.EventHandler(this.timer_Msg_Tick);//消息时钟
            this.timer_Go.Tick += new System.EventHandler(this.timer_Go_Tick);
        }
        #endregion

        #region 属性
        private IUserControl CurrentUserControl = null;
        private DevExpress.XtraNavBar.NavBarGroup CurrentGroup = null;
        #endregion
        
        #region 方法
        public void Init(){
            this.CurrentGroup = this.navBarGroup1;
            LoadConfig();//加载配置
           // InitRole();//初始化角色

            this.RefreshNewTabPage();//刷新新tabpage
            this.lb_User.Text = "用户：测试用户"; 
            this.lb_Department.Text = "部门：测试部门";
            this.lb_Time.Text = "登录时间:" + DateTime.Now.ToString();
            this.timer_Msg.Enabled = true;
            this.timer_Go.Enabled = true;
            this.Refresh();          
        }
        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            try
            {               
                //***//
                //****设置是否显示曾经使用过的组件界面****//
                string showUsedControl = Program.m_UserConfig.AppConfig.GetKeyValue("ShowUsedControl");
                if (showUsedControl != "")
                {
                    this.newTabPage.PageVisible = Convert.ToBoolean(showUsedControl);
                    this.barckb_UsedUserContorls.Checked = Convert.ToBoolean(showUsedControl);
                }
                else
                {
                    Program.m_UserConfig.AppConfig.SetKeyValue("ShowUsedControl", "true");
                }
                //***//
            }
            catch (Exception e)
            {
                Program.MsgBoxError(e);
            }
        }
        /// <summary>
        /// 刷新曾经使用过的组件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshNewTabPage()
        {

            for (int i = Program.m_UserConfig.AppConfig.UsedUserControls.Count; i > 0; i--)
            {
                //int k = Program.m_UserConfig.AppConfig.UsedUserControls.Count - i + 1;
                //DevExpress.XtraEditors.SimpleButton btn = (DevExpress.XtraEditors.SimpleButton)this.panel_userUsed.Controls["btn_UsedUserControl" + k.ToString()];
                // //DevExpress.XtraEditors.SimpleButton btn = (DevExpress.XtraEditors.SimpleButton)this.newTabPage.Controls["btn_UsedUserControl" + k.ToString()];
                //btn.Text = Program.m_UserConfig.AppConfig.UsedUserControls[i - 1].Value;
                //btn.Tag = Program.m_UserConfig.AppConfig.UsedUserControls[i - 1].Key;
                //btn.Visible = true;
               // lb_UsedControl.Visible = true;
                //bool hasAuthority = false;
                //for (int j = 0; j < Program.CurrentEmployee.Authority.Count; j++)
                //{
                //    if (btn.Tag.ToString() == Program.CurrentEmployee.Authority[j].FID)
                //    {
                //        hasAuthority = true;
                //        break;
                //    }
                //}
                //if (!hasAuthority)
                //{
                //    btn.Text = btn.Text + "(无权限)";
                //    btn.Enabled = false;
                //}
                //else
                //{
                    //btn.Enabled = true;
                //}
            }
        }
        /// <summary>
        /// 设置系统皮肤
        /// </summary>
        /// <param name="skinName">皮肤名称</param>
        private void ChangeSkinName(string skinName)
        {
            try
            {
                Program.dflook_All.LookAndFeel.SetSkinStyle(skinName);
                //Program.m_UserConfig.AppConfig.SetKeyValue("SkinName", skinName);//保存
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 选择不同的用户界面
        /// </summary>
        /// <param name="tagname"></param>
        private void ChangeTabPage(DevExpress.XtraNavBar.NavBarItemLink link)
        {
            Program.m_UserConfig.AppConfig.AddUsedUserControls(link.Item.Tag.ToString(), link.Caption);//添加用户曾经用过的节点
            bool hasOpened = false;
            for (int i = 0; i < this.tabc_Main.TabPages.Count; i++)
            {
                if (this.tabc_Main.TabPages[i].Tag == link)
                {
                    this.tabc_Main.SelectedTabPage = this.tabc_Main.TabPages[i];
                    hasOpened = true;
                    break;
                }
            }
            if (!hasOpened)
            {
                this.OpenPage(link);
            }

            DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.SelectedTabPage;
            //设置按钮的可见
            SetBtnVisible(page);
            //判断界面是否需要初始化
            if (page.Controls.Count > 0)
            {
                this.CurrentUserControl = (IUserControl)page.Controls[0];
                if (page.Controls[0].GetType().BaseType == typeof(UserControlBase))
                {
                    if (((UserControlBase)page.Controls[0]).NeedInit && !hasOpened)
                    {
                        Application.DoEvents();
                        ((IUserControl)page.Controls[0]).Init();
                    }
                    ((UserControlBase)page.Controls[0]).MyAuthority.InitAuthorityList(link.Item.Tag.ToString());
                }
            }
        }
        /// <summary>
        /// 设置按钮是否可见
        /// </summary>
        /// <param name="page">当前选中的页面</param>
        private void SetBtnVisible(DevExpress.XtraTab.XtraTabPage page)
        {
            if (page == null)
            {
                this.barbtn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Modify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Check.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                this.barBtn_Clear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barBtn_PreSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barBtn_LoadData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (page.Controls.Count > 0 && page != newTabPage)
            {
                if (page.Controls[0].GetType().BaseType == typeof(UserControlBase))
                {
                    UserControlBase control = (UserControlBase)page.Controls[0];
                    this.CurrentUserControl = (IUserControl)page.Controls[0];
                    if (control.Hasbtn_Add)
                    {
                        this.barbtn_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //if (!control.MyAuthority.HasAddLimits)
                        //{
                        //    this.barbtn_Add.Enabled = false;
                        //}
                        //if (control.IsAdd)
                        //{
                        //    this.barbtn_Add.Checked = true;
                        //}
                    }
                    else
                    {
                        this.barbtn_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Delete)
                    {
                        this.barbtn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //if (control.IsDelete)
                        //{
                        //    this.barbtn_Delete.Checked = true;
                        //}
                    }
                    else
                    {
                        this.barbtn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Modify)
                    {
                        this.barbtn_Modify.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        //if (control.IsModify)
                        //{
                        //    this.barbtn_Modify.Checked = true;
                        //}
                    }
                    else
                    {
                        this.barbtn_Modify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Down)
                    {
                        this.barbtn_down.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barbtn_down.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Up)
                    {
                        this.barbtn_up.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barbtn_up.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Refresh)
                    {
                        this.barbtn_refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barbtn_refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Search)
                    {
                        this.barbtn_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barbtn_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Save)
                    {
                        this.barbtn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barbtn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    if (control.Hasbtn_Check)
                    {
                        this.barbtn_Check.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barbtn_Check.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (control.Hasbtn_Clear)
                    {
                        this.barBtn_Clear.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barBtn_Clear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (control.Hasbtn_PreSave)
                    {
                        this.barBtn_PreSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barBtn_PreSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }

                    if (control.Hasbtn_LoadData)
                    {
                        this.barBtn_LoadData.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        this.barBtn_LoadData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
            }
            else
            {
                this.barbtn_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Modify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Search.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barbtn_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barBtn_Clear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barBtn_PreSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.barBtn_LoadData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        /// <summary>
        /// 重新登入
        /// </summary>
        private void ReLongin()
        {
            try
            {
                Formlogin form = new Formlogin();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.CloseTabPage(true);
                    this.Init();
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 关闭选项卡
        /// </summary>
        /// <param name="closeall">是否全部关闭</param>
        private void CloseTabPage(bool closeall)
        {
            try
            {
                if (!closeall)
                {
                    if (this.tabc_Main.SelectedTabPage != null)
                    {
                        int selectedTabPageIndex = this.tabc_Main.SelectedTabPageIndex;
                        DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.SelectedTabPage;
                        if (page != newTabPage)
                        {
                            this.tabc_Main.TabPages.Remove(this.tabc_Main.SelectedTabPage);
                            page.Dispose();
                            System.GC.Collect();
                        }
                        else if (page == newTabPage)
                        {
                            //page.PageVisible = false;
                            //this.barckb_UsedUserContorls.Checked = false;
                        }
                        if (this.tabc_Main.TabPages.Count > 1)
                        {
                            this.tabc_Main.SelectedTabPageIndex = selectedTabPageIndex;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.tabc_Main.TabPages.Count; i++)
                    {
                        DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.TabPages[i];
                        if (page != newTabPage)
                        {
                            this.tabc_Main.TabPages.Remove(this.tabc_Main.SelectedTabPage);
                            page.Dispose();
                            System.GC.Collect();
                            i--;
                        }
                        else
                        {
                           // this.barckb_UsedUserContorls.Checked = false;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 添加一个Page并返回他
        /// </summary>
        /// <returns>page</returns>
        public DevExpress.XtraTab.XtraTabPage AddPage()
        {
            DevExpress.XtraTab.XtraTabPage page = new DevExpress.XtraTab.XtraTabPage();
            if (this.tabc_Main.TabPages.Count > 0)
            {
                this.tabc_Main.TabPages.Insert(1, page);
            }
            else
            {
                this.tabc_Main.TabPages.Insert(0, page);
            }
            this.tabc_Main.SelectedTabPage = page;
            return page;
        }
        #endregion

        #region 接口实现
        public void Add(){

        }
        public void Delete(){
 
        }
        public void Modify(){

        }
        public void Up()
        {

         }
        public void Down()
        {

        }
        public void Search(){

        }
        public void Refresh()
        {
        }
        public void Save(){

        }
        public void Check()
        {
        }
        public void SetModify(){
        }
        public void SetAdd(){
        }
        public void SetDelete(){
        }
        public void Clear(){

        }
        public void PreSave(){

        }
        public void LoadData(){
        }
        #endregion       

        #region 页面跳转方法
        /// <summary>
        /// 页面跳转的方法
        /// </summary>
        /// <param name="p_PageName">页面的描述名称</param>
        /// <param name="link"></param>
        /// <summary/>
        private void OpenPage(DevExpress.XtraNavBar.NavBarItemLink link)
        {
            try
            {
                DevExpress.XtraTab.XtraTabPage page = new DevExpress.XtraTab.XtraTabPage();
                if (this.tabc_Main.TabPages.Count > 0)
                {
                    this.tabc_Main.TabPages.Insert(1, page);
                }
                else
                {
                    this.tabc_Main.TabPages.Insert(0, page);
                }
               
                              
                page.Text = link.Caption;
                page.Tag = link;
                this.tabc_Main.SelectedTabPage = page;
                switch (link.Item.Tag.ToString())
                {
                    #region 06系统设置

                    case "0101"://数据字典
                        UCDataDictionary ucDataDictionary = new UCDataDictionary();
                        ucDataDictionary.Dock = DockStyle.Fill;
                        page.Controls.Add(ucDataDictionary);
                        break;
                    case "0102"://用户
                        UCOperator ucOperator = new UCOperator();
                        ucOperator.Dock = DockStyle.Fill;
                        page.Controls.Add(ucOperator);
                        break;
                    case "0103"://房间类型
                        UCRoomType ucRoomType = new UCRoomType();
                        ucRoomType.Dock = DockStyle.Fill;
                        page.Controls.Add(ucRoomType);
                        break;       
                    case "0104"://会员类型
                        UCMemberType ucMemberType = new UCMemberType();
                        ucMemberType.Dock = DockStyle.Fill;
                        page.Controls.Add(ucMemberType);
                        break;
                    case "0105"://房间设置
                        UCSetRoom ucSetRoom = new UCSetRoom();
                        ucSetRoom.Dock = DockStyle.Fill;
                        page.Controls.Add(ucSetRoom);
                        break;
                    #endregion
                    #region 会员管理
                    case "0201":
                        UCMember ucMember = new UCMember();
                        ucMember.Dock = DockStyle.Fill;
                        page.Controls.Add(ucMember);
                        break;
                    case "0202":
                        UCLost ucLost = new UCLost();
                        ucLost.Dock = DockStyle.Fill;
                        page.Controls.Add(ucLost);
                        break;
                    #endregion
                    #region 客户管理
                    case "0301":
                        UCCustomer ucCustomer = new UCCustomer();
                        ucCustomer.Dock = DockStyle.Fill;
                        page.Controls.Add(ucCustomer);
                        break;
                    #endregion
                    #region 前台管理
                    case "0401"://预订管理
                        UCReserve ucReserve = new UCReserve();
                        ucReserve.Dock = DockStyle.Fill;
                        page.Controls.Add(ucReserve);
                        break;
                    case "0402"://入住管理
                        UCCheckin ucCheckin = new UCCheckin();
                        ucCheckin.Dock = DockStyle.Fill;
                        page.Controls.Add(ucCheckin);
                        break;
                    #endregion
                    default:
                        break;

                }
               Program.m_UserConfig.AppConfig.AddUsedUserControls(link.Item.Tag.ToString(), link.Caption);//添加用户曾经用过的节点
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

        }
        #endregion

        #region 事件

        /// <summary>
        /// 展开功能面板事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nbarc_Main_GroupExpanded(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            if (this.CurrentGroup != null)
            {
                if (this.CurrentGroup != e.Group)
                {
                    CurrentGroup.Expanded = false;
                }
            }
            CurrentGroup = e.Group;
        }
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();
                DevExpress.FOSOYO.LookAndFeelSettings.Save("FOSOYO.ini");//保存皮肤风格
                Program.SaveConfig();//保存配置
                if (!Program.IsReStart)
                {
                    System.Environment.Exit(System.Environment.ExitCode);
                }
                else
                {
                    Application.Restart();
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 窗口关闭前事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Program.MsgBoxYesNo("请确定您的所有操作已经保存。是否继续退出？") != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
                //关闭缓存,对缓存数据进行写入操作
                
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 皮肤改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barmrg_MainForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Hint == "设置系统皮肤")
                {
                    this.ChangeSkinName(e.Item.Caption);
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        
        /// <summary>
        /// 鼠标点击导航栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nbarc_Main_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DevExpress.XtraNavBar.ViewInfo.NavBarViewInfo v = nbarc_Main.View.CreateViewInfo(nbarc_Main);
                DevExpress.XtraNavBar.NavBarHitInfo h = v.CalcHitInfo(e.Location);
                if (h.Group != null && h.InGroupCaption && !h.InGroupButton)
                {
                    h.Group.Expanded = !h.Group.Expanded;
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

       
 

        /// <summary>
        /// 动态导航栏按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nbarc_Main_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                ChangeTabPage(e.Link);
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 加载窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Init();

            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }


        /// <summary>
        /// 关闭全部窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_CloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CloseTabPage(true);
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }


        #region 工具栏事件

        /// <summary>
        /// 关闭  按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CloseTabPage(false);
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 保存  按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.CurrentUserControl != null)
                {
                    this.CurrentUserControl.Save();
                }

            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 按键键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control && !e.Handled)
                {
                    barbtn_Save_ItemClick(sender, null);
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 退出 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 模块公用方法，刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.CurrentUserControl != null)
                {
                    this.CurrentUserControl.Refresh();
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 模块公用方法，上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_up_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.CurrentUserControl != null)
                {
                    this.CurrentUserControl.Up();
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 模块公用方法，下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_down_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.CurrentUserControl != null)
                {
                    this.CurrentUserControl.Down();
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }


        /// <summary>
        /// 模块公用方法，查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.CurrentUserControl != null)
                {
                    //Program.Form_Search.lb_Name.Text = "查询表格：" + this.tabc_Main.SelectedTabPage.Text.Trim();
                    this.CurrentUserControl.Search();
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        } 

        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Lock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FormLock fl = new FormLock();
                fl.ShowDialog();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 导航条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Gider_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (this.group_Grider.Width != 0)
                {
                    this.group_Grider.Width = 0;
                }
                else
                {
                    this.group_Grider.Width = 230;
                }
                this.Refresh();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 点击上方快捷按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Used_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DevExpress.XtraNavBar.NavBarItemLink Link = (DevExpress.XtraNavBar.NavBarItemLink)e.Item.Tag;
                //this.nbarc_Main.SelectedLink = Link;
                this.ChangeTabPage(Link);
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }



        /// <summary>
        /// 控制是否显示曾经使用过的窗口（窗口-1）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barckb_UsedUserContorls_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Program.m_UserConfig.AppConfig.SetKeyValue("ShowUsedControl", this.barckb_UsedUserContorls.Checked.ToString());
                this.newTabPage.PageVisible = this.barckb_UsedUserContorls.Checked;
                if (this.newTabPage.PageVisible == true)
                {
                    this.tabc_Main.SelectedTabPage = newTabPage;
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 控制是否显示常用长途配载组件窗口（窗口-2）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnckb_LongDistance_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //Program.m_UserConfig.AppConfig.SetKeyValue("ShowLongDistanceControl", this.barckb_LongDistance.Checked.ToString());
                //this.LongDistanceTabPage.PageVisible = this.barckb_LongDistance.Checked;
                //if (this.LongDistanceTabPage.PageVisible == true)
                //{
                //    this.tabc_Main.SelectedTabPage = LongDistanceTabPage;
                //}
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }


        /// <summary>
        /// 计算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Caculate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 计事本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_txtBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe");
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 注销（重新登录）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ReLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Program.IsReStart = true;
                this.ReLongin();
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
            finally
            {
                Program.IsReStart = false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_ChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //FormPasswordMrg form = new FormPasswordMrg();
                //if (form.ShowDialog() == DialogResult.OK)
                //{

                //}
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        #endregion

        #region 滚动消息栏事件

        /// <summary>
        /// timer事件,获取系统消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Msg_Tick(object sender, EventArgs e)
        {
            try
            {
                this.btn_SystemMessage.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.btn_SystemMessage.Caption = "系统消息：系统测试消息...[点击查看详细]";
                //int lastno = Program.m_UserConfig.SysMessage.getMaxID();
                //List<BusinessEntity.Messages> tempmsg = new BusinessOperator.MessagesOperator().GetShowMessages(lastno);
                //for (int i = 0; i < tempmsg.Count; i++)
                //{
                //    Program.m_UserConfig.SysMessage.AddNewMessage(tempmsg[i]);

                //}
                //if (tempmsg.Count > 0)
                //{
                //    this.btn_SystemMessage.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //    if (Program.m_UserConfig.SysMessage.NodeList[0].Content.Length > 40)
                //    {
                //        this.btn_SystemMessage.Caption = "系统消息： " + Program.m_UserConfig.SysMessage.NodeList[0].Content.Substring(0, 40) + "...[点击查看详细]";
                //    }
                //    else
                //    {
                //        this.btn_SystemMessage.Caption = "系统消息： " + Program.m_UserConfig.SysMessage.NodeList[0].Content;
                //    }
                //}
            }
            catch (Exception ee)
            {
                timer_Msg.Stop();
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 状态栏按钮，查看系统消息记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LookSysMsg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (btn_LookSysMsg.Tag.ToString() == "1")
                {
                    this.timer_Go.Start();
                    btn_LookSysMsg.Tag = "0";
                }
                else
                {
                    this.timer_Go.Stop();
                    btn_LookSysMsg.Tag = "1";
                }
                //FormShowSysMessage form = new FormShowSysMessage();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //}
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 状态栏按钮，查看系统消息记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SystemMessage_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //FormShowSysMessage form = new FormShowSysMessage();
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //}
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 左下角滚动 及时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Go_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.btn_SystemMessage.Visibility == DevExpress.XtraBars.BarItemVisibility.Always)
                {
                    this.bar_StaticRight.Caption += " ";
                }
                if (this.bar_StaticRight.Caption.Length > 300)
                {
                    this.bar_StaticRight.Caption = "";
                }

                this.lb_Time.Text = "时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm"); 
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }



        /// <summary>
        /// 右键菜单关闭标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_CloseAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabc_Main.SelectedTabPage != null)
                {
                    int selectedTabPageNO = 0;
                    if (sender == this.toolStripMenuItem_CloseAll)
                    {
                        CloseTabPage(true);
                    }
                    else if (sender == this.toolStripMenuItem_CloseLeft)
                    {

                        for (int i = this.tabc_Main.TabPages.Count - 1; i > 0; i--)
                        {

                            DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.TabPages[i];
                            if (page == this.tabc_Main.SelectedTabPage)
                            {
                                selectedTabPageNO = i;//先记录当前选择的TabPage位置
                                break;
                            }
                        }
                        for (int i = selectedTabPageNO - 1; i > -1; i--)//移除左边边标签
                        {
                            DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.TabPages[i];
                            if (page == newTabPage)
                            {
                                page.PageVisible = false;
                                this.barckb_UsedUserContorls.Checked = false;
                            }
                            else
                            {

                                this.tabc_Main.TabPages.Remove(this.tabc_Main.TabPages[i]);
                                page.Dispose();
                                System.GC.Collect();



                            }

                        }
                        this.tabc_Main.SelectedTabPageIndex = 0;


                    }
                    else if (sender == this.toolStripMenuItem_CloseRight)
                    {
                        for (int i = 0; i < this.tabc_Main.TabPages.Count; i++)
                        {

                            DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.TabPages[i];
                            if (page == this.tabc_Main.SelectedTabPage)
                            {
                                selectedTabPageNO = i;//先记录当前选择的TabPage位置
                                break;
                            }
                        }
                        for (int i = this.tabc_Main.TabPages.Count - 1; i > selectedTabPageNO; i--)//移除右边标签
                        {
                            DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.TabPages[i];
                            if (page == newTabPage)
                            {
                                page.PageVisible = false;
                                this.barckb_UsedUserContorls.Checked = false;
                            }                           
                            else
                            {

                                this.tabc_Main.TabPages.Remove(this.tabc_Main.TabPages[i]);
                                page.Dispose();
                                System.GC.Collect();


                            }

                        }
                        this.tabc_Main.SelectedTabPageIndex = selectedTabPageNO;

                    }
                    else if (sender == this.toolStripMenuItem_Close)
                    {
                        DevExpress.XtraTab.XtraTabPage page = this.tabc_Main.SelectedTabPage;
                        if (page != newTabPage )
                        {
                            this.tabc_Main.TabPages.Remove(this.tabc_Main.SelectedTabPage);
                            page.Dispose();
                            System.GC.Collect();
                        }
                        else if (page == newTabPage)
                        {
                            page.PageVisible = false;
                            this.barckb_UsedUserContorls.Checked = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Program.MsgBoxError(ex);
            }
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CurrentUserControl.Add();


            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CurrentUserControl.Delete();


            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Modify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CurrentUserControl.Modify();


            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 审核数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barbtn_Check_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                this.CurrentUserControl.Check();

            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
      
        /// <summary>
        /// 清除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtn_Clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CurrentUserControl.Clear();


            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 预保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtn_PreSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CurrentUserControl.PreSave();


            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }

        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtn_LoadData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.CurrentUserControl.LoadData();


            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }


        #endregion 

        /// <summary>
        /// 关闭当前选择的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabc_Main_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.CloseTabPage(false);
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 选择不同的页面时发生事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabc_Main_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                this.SetBtnVisible(this.tabc_Main.SelectedTabPage);
                if (this.tabc_Main.SelectedTabPage != null)
                {
                    if (this.tabc_Main.SelectedTabPage == newTabPage)
                    {
                        RefreshNewTabPage();
                        this.CurrentUserControl = null;
                    }
                    else
                    {
                        if (this.tabc_Main.SelectedTabPage.Tag != null)
                        {
                            NavBarItemLink link = (NavBarItemLink)this.tabc_Main.SelectedTabPage.Tag;
                            this.nbarc_Main.SelectedLink = link;
                            this.nbarc_Main.SelectedLink.Group.Expanded = true;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }
        }
        /// <summary>
        /// 点击曾经使用按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UsedUserControl1_Click(object sender, EventArgs e)
        {
            try
            {
               
                string tag = ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString();
                foreach (DevExpress.XtraNavBar.NavBarItem item in this.nbarc_Main.Items)
                {
                    if (item.Tag.ToString()== tag)
                    {
                        this.ChangeTabPage(item.Links[0]);
                        break;
                    }
                } 
            }
            catch (Exception ee)
            {
                Program.MsgBoxError(ee);
            }

        }

        private void tabc_Main_DoubleClick(object sender, EventArgs e)
        {
            this.CloseTabPage(false);
        }

        private void tabc_Main_Click(object sender, EventArgs e)
        {

        }

        private void barbtn_Search_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void nbarc_Main_Click(object sender, EventArgs e)
        {

        }     
 
    }

        #endregion

}