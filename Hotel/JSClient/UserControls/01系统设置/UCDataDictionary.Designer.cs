namespace Client.UserControls
{
    partial class UCDataDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCDataDictionary));
            this.navBarControl_left = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup_dataDictionary = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem9 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem10 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem11 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem12 = new DevExpress.XtraNavBar.NavBarItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gc_dataDictionary = new DevExpress.XtraGrid.GridControl();
            this.gv_dataDictionary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_DataDictionaryType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_DataDictionaryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_DataDictionaryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_DataDictionaryDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_OperateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_OperateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem4 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_dataDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_dataDictionary)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl_left
            // 
            this.navBarControl_left.ActiveGroup = this.navBarGroup_dataDictionary;
            this.navBarControl_left.Appearance.Background.BackColor = System.Drawing.Color.Transparent;
            this.navBarControl_left.Appearance.Background.BackColor2 = System.Drawing.Color.Transparent;
            this.navBarControl_left.Appearance.Background.Options.UseBackColor = true;
            this.navBarControl_left.BackColor = System.Drawing.Color.Transparent;
            this.navBarControl_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl_left.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup_dataDictionary});
            this.navBarControl_left.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem9,
            this.navBarItem10,
            this.navBarItem11,
            this.navBarItem12,
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3,
            this.navBarItem4,
            this.navBarItem5,
            this.navBarItem6});
            this.navBarControl_left.LargeImages = this.imageList1;
            this.navBarControl_left.Location = new System.Drawing.Point(0, 0);
            this.navBarControl_left.Name = "navBarControl_left";
            this.navBarControl_left.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl_left.Size = new System.Drawing.Size(199, 622);
            this.navBarControl_left.StoreDefaultPaintStyleName = true;
            this.navBarControl_left.TabIndex = 27;
            this.navBarControl_left.Text = "navBarControl2";
            // 
            // navBarGroup_dataDictionary
            // 
            this.navBarGroup_dataDictionary.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.Appearance.Options.UseBackColor = true;
            this.navBarGroup_dataDictionary.Appearance.Options.UseTextOptions = true;
            this.navBarGroup_dataDictionary.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBarGroup_dataDictionary.AppearanceBackground.BackColor = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.AppearanceBackground.BackColor2 = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.AppearanceBackground.Options.UseBackColor = true;
            this.navBarGroup_dataDictionary.AppearanceHotTracked.BackColor = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.AppearanceHotTracked.BackColor2 = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.AppearanceHotTracked.Options.UseBackColor = true;
            this.navBarGroup_dataDictionary.AppearancePressed.BackColor = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.AppearancePressed.BackColor2 = System.Drawing.Color.Transparent;
            this.navBarGroup_dataDictionary.AppearancePressed.Options.UseBackColor = true;
            this.navBarGroup_dataDictionary.Caption = "数据类型";
            this.navBarGroup_dataDictionary.Expanded = true;
            this.navBarGroup_dataDictionary.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup_dataDictionary.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6)});
            this.navBarGroup_dataDictionary.Name = "navBarGroup_dataDictionary";
            this.navBarGroup_dataDictionary.SmallImageIndex = 6;
            // 
            // navBarItem9
            // 
            this.navBarItem9.Caption = "Inbox";
            this.navBarItem9.LargeImageIndex = 0;
            this.navBarItem9.Name = "navBarItem9";
            this.navBarItem9.SmallImageIndex = 0;
            // 
            // navBarItem10
            // 
            this.navBarItem10.Caption = "Outbox";
            this.navBarItem10.LargeImageIndex = 1;
            this.navBarItem10.Name = "navBarItem10";
            this.navBarItem10.SmallImageIndex = 1;
            // 
            // navBarItem11
            // 
            this.navBarItem11.Caption = "Sent Items";
            this.navBarItem11.Enabled = false;
            this.navBarItem11.LargeImageIndex = 2;
            this.navBarItem11.Name = "navBarItem11";
            this.navBarItem11.SmallImageIndex = 2;
            // 
            // navBarItem12
            // 
            this.navBarItem12.Caption = "Deleted Items";
            this.navBarItem12.Enabled = false;
            this.navBarItem12.LargeImageIndex = 3;
            this.navBarItem12.Name = "navBarItem12";
            this.navBarItem12.SmallImageIndex = 3;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "Gnome-Computer-32.png");
            this.imageList1.Images.SetKeyName(9, "Evince-Logo-32.png");
            this.imageList1.Images.SetKeyName(10, "Glade-3-32.png");
            this.imageList1.Images.SetKeyName(11, "Gnome-Folder-Saved-Search-48.png");
            this.imageList1.Images.SetKeyName(12, "Gnome-Insert-Image-48.png");
            this.imageList1.Images.SetKeyName(13, "Gnome-Preferences-Desktop-Accessibility-48.png");
            this.imageList1.Images.SetKeyName(14, "Gnome-System-Search-48.png");
            this.imageList1.Images.SetKeyName(15, "Gnome-Emblem-Generic-48.png");
            // 
            // gc_dataDictionary
            // 
            this.gc_dataDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_dataDictionary.Location = new System.Drawing.Point(199, 0);
            this.gc_dataDictionary.MainView = this.gv_dataDictionary;
            this.gc_dataDictionary.Name = "gc_dataDictionary";
            this.gc_dataDictionary.Size = new System.Drawing.Size(779, 622);
            this.gc_dataDictionary.TabIndex = 28;
            this.gc_dataDictionary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_dataDictionary});
            // 
            // gv_dataDictionary
            // 
            this.gv_dataDictionary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_choose,
            this.gridCol_DataDictionaryType,
            this.gridCol_DataDictionaryCode,
            this.gridCol_DataDictionaryName,
            this.gridCol_DataDictionaryDescription,
            this.gridCol_note,
            this.gridCol_OperateName,
            this.gridCol_OperateTime});
            this.gv_dataDictionary.GridControl = this.gc_dataDictionary;
            this.gv_dataDictionary.Name = "gv_dataDictionary";
            this.gv_dataDictionary.OptionsView.ColumnAutoWidth = false;
            this.gv_dataDictionary.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridCol_choose
            // 
            this.gridCol_choose.Caption = "选择";
            this.gridCol_choose.FieldName = "Choose";
            this.gridCol_choose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridCol_choose.Name = "gridCol_choose";
            this.gridCol_choose.OptionsColumn.AllowShowHide = false;
            this.gridCol_choose.Visible = true;
            this.gridCol_choose.VisibleIndex = 0;
            this.gridCol_choose.Width = 43;
            // 
            // gridCol_DataDictionaryType
            // 
            this.gridCol_DataDictionaryType.Caption = "类型";
            this.gridCol_DataDictionaryType.FieldName = "DataDictionaryType";
            this.gridCol_DataDictionaryType.Name = "gridCol_DataDictionaryType";
            this.gridCol_DataDictionaryType.OptionsColumn.AllowEdit = false;
            this.gridCol_DataDictionaryType.OptionsColumn.AllowShowHide = false;
            this.gridCol_DataDictionaryType.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_DataDictionaryType.Visible = true;
            this.gridCol_DataDictionaryType.VisibleIndex = 1;
            this.gridCol_DataDictionaryType.Width = 103;
            // 
            // gridCol_DataDictionaryCode
            // 
            this.gridCol_DataDictionaryCode.Caption = "编号";
            this.gridCol_DataDictionaryCode.FieldName = "DataDictionaryCode";
            this.gridCol_DataDictionaryCode.Name = "gridCol_DataDictionaryCode";
            this.gridCol_DataDictionaryCode.OptionsColumn.AllowEdit = false;
            this.gridCol_DataDictionaryCode.OptionsColumn.AllowShowHide = false;
            this.gridCol_DataDictionaryCode.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_DataDictionaryCode.Visible = true;
            this.gridCol_DataDictionaryCode.VisibleIndex = 2;
            // 
            // gridCol_DataDictionaryName
            // 
            this.gridCol_DataDictionaryName.Caption = "名称";
            this.gridCol_DataDictionaryName.FieldName = "DataDictionaryName";
            this.gridCol_DataDictionaryName.Name = "gridCol_DataDictionaryName";
            this.gridCol_DataDictionaryName.OptionsColumn.AllowEdit = false;
            this.gridCol_DataDictionaryName.OptionsColumn.AllowShowHide = false;
            this.gridCol_DataDictionaryName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_DataDictionaryName.Visible = true;
            this.gridCol_DataDictionaryName.VisibleIndex = 3;
            this.gridCol_DataDictionaryName.Width = 162;
            // 
            // gridCol_DataDictionaryDescription
            // 
            this.gridCol_DataDictionaryDescription.Caption = "描述";
            this.gridCol_DataDictionaryDescription.FieldName = "DataDictionaryDescription";
            this.gridCol_DataDictionaryDescription.Name = "gridCol_DataDictionaryDescription";
            this.gridCol_DataDictionaryDescription.OptionsColumn.AllowEdit = false;
            this.gridCol_DataDictionaryDescription.OptionsColumn.AllowShowHide = false;
            this.gridCol_DataDictionaryDescription.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_DataDictionaryDescription.Visible = true;
            this.gridCol_DataDictionaryDescription.VisibleIndex = 4;
            // 
            // gridCol_note
            // 
            this.gridCol_note.Caption = "备注";
            this.gridCol_note.FieldName = "Note";
            this.gridCol_note.Name = "gridCol_note";
            this.gridCol_note.OptionsColumn.AllowEdit = false;
            this.gridCol_note.OptionsColumn.AllowShowHide = false;
            this.gridCol_note.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_note.Visible = true;
            this.gridCol_note.VisibleIndex = 5;
            // 
            // gridCol_OperateName
            // 
            this.gridCol_OperateName.Caption = "操作员";
            this.gridCol_OperateName.FieldName = "OperateName";
            this.gridCol_OperateName.Name = "gridCol_OperateName";
            this.gridCol_OperateName.OptionsColumn.AllowEdit = false;
            this.gridCol_OperateName.OptionsColumn.AllowShowHide = false;
            this.gridCol_OperateName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_OperateName.Visible = true;
            this.gridCol_OperateName.VisibleIndex = 6;
            // 
            // gridCol_OperateTime
            // 
            this.gridCol_OperateTime.Caption = "操作时间";
            this.gridCol_OperateTime.DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss";
            this.gridCol_OperateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridCol_OperateTime.FieldName = "OperateTime";
            this.gridCol_OperateTime.Name = "gridCol_OperateTime";
            this.gridCol_OperateTime.OptionsColumn.AllowEdit = false;
            this.gridCol_OperateTime.OptionsColumn.AllowShowHide = false;
            this.gridCol_OperateTime.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridCol_OperateTime.Visible = true;
            this.gridCol_OperateTime.VisibleIndex = 7;
            this.gridCol_OperateTime.Width = 233;
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "客人类型";
            this.navBarItem1.LargeImageIndex = 0;
            this.navBarItem1.Name = "navBarItem1";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "客人来源";
            this.navBarItem2.LargeImageIndex = 1;
            this.navBarItem2.Name = "navBarItem2";
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "证件类型";
            this.navBarItem3.LargeImageIndex = 2;
            this.navBarItem3.Name = "navBarItem3";
            // 
            // navBarItem4
            // 
            this.navBarItem4.Caption = "地区国家";
            this.navBarItem4.LargeImageIndex = 3;
            this.navBarItem4.Name = "navBarItem4";
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "付款方式";
            this.navBarItem5.LargeImageIndex = 4;
            this.navBarItem5.Name = "navBarItem5";
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "优惠理由";
            this.navBarItem6.LargeImageIndex = 4;
            this.navBarItem6.Name = "navBarItem6";
            // 
            // UCDataDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_dataDictionary);
            this.Controls.Add(this.navBarControl_left);
            this.Hasbtn_Add = true;
            this.Hasbtn_Delete = true;
            this.Hasbtn_Modify = true;
            this.Hasbtn_Refresh = true;
            this.Name = "UCDataDictionary";
            this.Size = new System.Drawing.Size(978, 622);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_dataDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_dataDictionary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl_left;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_dataDictionary;
        private DevExpress.XtraNavBar.NavBarItem navBarItem9;
        private DevExpress.XtraNavBar.NavBarItem navBarItem10;
        private DevExpress.XtraNavBar.NavBarItem navBarItem11;
        private DevExpress.XtraNavBar.NavBarItem navBarItem12;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl gc_dataDictionary;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_dataDictionary;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_DataDictionaryType;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_DataDictionaryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_DataDictionaryName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_DataDictionaryDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_note;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_OperateName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_OperateTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_choose;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarItem navBarItem4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;


    }
}
