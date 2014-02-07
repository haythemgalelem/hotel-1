namespace Client.Controls
{
    partial class ToolbarPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolbarPanel));
            this.imglist_Main = new System.Windows.Forms.ImageList(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barBtn_add = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_delete = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_modify = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_download = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_refresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // imglist_Main
            // 
            this.imglist_Main.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist_Main.ImageStream")));
            this.imglist_Main.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist_Main.Images.SetKeyName(0, "Add.png");
            this.imglist_Main.Images.SetKeyName(1, "Modify.png");
            this.imglist_Main.Images.SetKeyName(2, "Close.png");
            this.imglist_Main.Images.SetKeyName(3, "");
            this.imglist_Main.Images.SetKeyName(4, "down.png");
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imglist_Main;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtn_add,
            this.barBtn_delete,
            this.barBtn_modify,
            this.barBtn_download,
            this.barBtn_refresh});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_add),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_delete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_modify),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_download),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_refresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // barBtn_add
            // 
            this.barBtn_add.Caption = "新增";
            this.barBtn_add.Id = 0;
            this.barBtn_add.ImageIndex = 0;
            this.barBtn_add.Name = "barBtn_add";
            this.barBtn_add.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtn_delete
            // 
            this.barBtn_delete.Caption = "删除";
            this.barBtn_delete.Id = 1;
            this.barBtn_delete.ImageIndex = 2;
            this.barBtn_delete.Name = "barBtn_delete";
            this.barBtn_delete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtn_modify
            // 
            this.barBtn_modify.Caption = "修改";
            this.barBtn_modify.Id = 2;
            this.barBtn_modify.ImageIndex = 1;
            this.barBtn_modify.Name = "barBtn_modify";
            this.barBtn_modify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtn_download
            // 
            this.barBtn_download.Caption = "下载";
            this.barBtn_download.Id = 3;
            this.barBtn_download.ImageIndex = 4;
            this.barBtn_download.Name = "barBtn_download";
            this.barBtn_download.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtn_refresh
            // 
            this.barBtn_refresh.Caption = "刷新";
            this.barBtn_refresh.Id = 4;
            this.barBtn_refresh.ImageIndex = 3;
            this.barBtn_refresh.Name = "barBtn_refresh";
            this.barBtn_refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(601, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 28);
            this.barDockControlBottom.Size = new System.Drawing.Size(601, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(601, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // ToolbarPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ToolbarPanel";
            this.Size = new System.Drawing.Size(601, 28);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ImageList imglist_Main;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        public DevExpress.XtraBars.BarButtonItem barBtn_add;
        public DevExpress.XtraBars.BarButtonItem barBtn_delete;
        public DevExpress.XtraBars.BarButtonItem barBtn_modify;
        public DevExpress.XtraBars.BarButtonItem barBtn_download;
        public DevExpress.XtraBars.BarButtonItem barBtn_refresh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
