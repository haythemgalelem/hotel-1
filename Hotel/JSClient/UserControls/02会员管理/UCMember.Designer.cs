namespace Client.UserControls
{
    partial class UCMember
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gdMember = new DevExpress.XtraGrid.GridControl();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRecharge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLost = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReCard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCancelCard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKeepCard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.gvMember = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnCharge = new DevExpress.XtraBars.BarButtonItem();
            this.btnLost = new DevExpress.XtraBars.BarButtonItem();
            this.btnReCard = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancelCard = new DevExpress.XtraBars.BarButtonItem();
            this.btnKeepCard = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.btnPwd = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.充值 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.gdMember)).BeginInit();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gdMember
            // 
            this.gdMember.ContextMenuStrip = this.menu;
            this.gdMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdMember.Location = new System.Drawing.Point(0, 31);
            this.gdMember.MainView = this.gvMember;
            this.gdMember.Name = "gdMember";
            this.gdMember.Size = new System.Drawing.Size(1045, 397);
            this.gdMember.TabIndex = 0;
            this.gdMember.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMember});
            this.gdMember.Click += new System.EventHandler(this.gdMember_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRecharge,
            this.menuLost,
            this.menuReCard,
            this.menuCancelCard,
            this.menuKeepCard,
            this.menuPrize,
            this.menuPwd});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(153, 180);
            // 
            // menuRecharge
            // 
            this.menuRecharge.Name = "menuRecharge";
            this.menuRecharge.Size = new System.Drawing.Size(152, 22);
            this.menuRecharge.Text = "充值";
            // 
            // menuLost
            // 
            this.menuLost.Name = "menuLost";
            this.menuLost.Size = new System.Drawing.Size(152, 22);
            this.menuLost.Text = "挂失";
            // 
            // menuReCard
            // 
            this.menuReCard.Name = "menuReCard";
            this.menuReCard.Size = new System.Drawing.Size(152, 22);
            this.menuReCard.Text = "补卡";
            // 
            // menuCancelCard
            // 
            this.menuCancelCard.Name = "menuCancelCard";
            this.menuCancelCard.Size = new System.Drawing.Size(152, 22);
            this.menuCancelCard.Text = "注销";
            // 
            // menuKeepCard
            // 
            this.menuKeepCard.Name = "menuKeepCard";
            this.menuKeepCard.Size = new System.Drawing.Size(152, 22);
            this.menuKeepCard.Text = "续卡";
            // 
            // menuPrize
            // 
            this.menuPrize.Name = "menuPrize";
            this.menuPrize.Size = new System.Drawing.Size(152, 22);
            this.menuPrize.Text = "积分兑换";
            // 
            // menuPwd
            // 
            this.menuPwd.Name = "menuPwd";
            this.menuPwd.Size = new System.Drawing.Size(152, 22);
            this.menuPwd.Text = "设置密码";
            // 
            // gvMember
            // 
            this.gvMember.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gvMember.GridControl = this.gdMember;
            this.gvMember.Name = "gvMember";
            this.gvMember.OptionsView.ColumnAutoWidth = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "选择";
            this.gridColumn1.FieldName = "Choose";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "会员卡号";
            this.gridColumn2.FieldName = "MemberCardID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "会员名";
            this.gridColumn3.FieldName = "MemberName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "会员类型";
            this.gridColumn4.FieldName = "CardTypeName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "身份证号";
            this.gridColumn5.FieldName = "IDCard";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "性别";
            this.gridColumn6.FieldName = "Sex";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "可用";
            this.gridColumn7.FieldName = "AvailableChk";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "状态";
            this.gridColumn8.FieldName = "Status";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "注册时间";
            this.gridColumn9.FieldName = "RegTime";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "积分";
            this.gridColumn10.FieldName = "Score";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "消费次数";
            this.gridColumn11.FieldName = "Times";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "折扣";
            this.gridColumn12.FieldName = "Discount";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 11;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "余额";
            this.gridColumn13.FieldName = "Balance";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("充值", new System.Guid("b8e9b658-ebc1-4fd1-8a46-99cd9075f976"))});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.btnCharge,
            this.btnLost,
            this.btnReCard,
            this.btnCancelCard,
            this.btnKeepCard,
            this.barButtonItem15,
            this.btnPwd,
            this.充值,
            this.barButtonItem17});
            this.barManager1.MaxItemId = 18;
            // 
            // bar2
            // 
            this.bar2.BarName = "bar1";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCharge),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLost),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancelCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKeepCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem15),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPwd)});
            this.bar2.Text = "bar1";
            // 
            // btnCharge
            // 
            this.btnCharge.Caption = "充值";
            this.btnCharge.Id = 9;
            this.btnCharge.Name = "btnCharge";
            // 
            // btnLost
            // 
            this.btnLost.Caption = "挂失";
            this.btnLost.Id = 10;
            this.btnLost.Name = "btnLost";
            // 
            // btnReCard
            // 
            this.btnReCard.Caption = "补卡";
            this.btnReCard.Id = 11;
            this.btnReCard.Name = "btnReCard";
            // 
            // btnCancelCard
            // 
            this.btnCancelCard.Caption = "注销";
            this.btnCancelCard.Id = 12;
            this.btnCancelCard.Name = "btnCancelCard";
            // 
            // btnKeepCard
            // 
            this.btnKeepCard.Caption = "续卡";
            this.btnKeepCard.Id = 13;
            this.btnKeepCard.Name = "btnKeepCard";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "积分兑换";
            this.barButtonItem15.Id = 14;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // btnPwd
            // 
            this.btnPwd.Caption = "设置密码";
            this.btnPwd.Id = 15;
            this.btnPwd.Name = "btnPwd";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1045, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            this.barDockControlBottom.Size = new System.Drawing.Size(1045, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 397);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1045, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 397);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "充值";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "挂失";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "补卡";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "注销";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "续卡";
            this.barButtonItem5.Id = 4;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "积分兑换";
            this.barButtonItem6.Id = 5;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "设置密码";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "充值";
            this.barButtonItem8.Id = 7;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 8;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // 充值
            // 
            this.充值.Caption = "充值";
            this.充值.CategoryGuid = new System.Guid("b8e9b658-ebc1-4fd1-8a46-99cd9075f976");
            this.充值.Id = 16;
            this.充值.Name = "充值";
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "fff";
            this.barButtonItem17.Id = 17;
            this.barButtonItem17.Name = "barButtonItem17";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // UCMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdMember);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Hasbtn_Add = true;
            this.Hasbtn_Delete = true;
            this.Hasbtn_Modify = true;
            this.Hasbtn_Refresh = true;
            this.Name = "UCMember";
            this.Size = new System.Drawing.Size(1045, 428);
            ((System.ComponentModel.ISupportInitialize)(this.gdMember)).EndInit();
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdMember;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMember;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnCharge;
        private DevExpress.XtraBars.BarButtonItem btnLost;
        private DevExpress.XtraBars.BarButtonItem btnReCard;
        private DevExpress.XtraBars.BarButtonItem btnCancelCard;
        private DevExpress.XtraBars.BarButtonItem btnKeepCard;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem btnPwd;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem 充值;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuRecharge;
        private System.Windows.Forms.ToolStripMenuItem menuLost;
        private System.Windows.Forms.ToolStripMenuItem menuReCard;
        private System.Windows.Forms.ToolStripMenuItem menuCancelCard;
        private System.Windows.Forms.ToolStripMenuItem menuKeepCard;
        private System.Windows.Forms.ToolStripMenuItem menuPrize;
        private System.Windows.Forms.ToolStripMenuItem menuPwd;
    }
}
