namespace Client.ProgramForms
{
    partial class FormSelectRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeBuilding = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ffdsf = new DevExpress.XtraEditors.LabelControl();
            this.txtOriginalPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtHour = new DevExpress.XtraEditors.TextEdit();
            this.txtDiscountPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtDiscount = new DevExpress.XtraEditors.TextEdit();
            this.labOriginalPrice = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labTimeUnit = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gfaf = new DevExpress.XtraEditors.LabelControl();
            this.cmbCheckinType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fdsfds = new DevExpress.XtraEditors.LabelControl();
            this.labDiscountPrice = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).BeginInit();
            this.panelControl100000.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeBuilding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCheckinType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl100000
            // 
            this.panelControl100000.Controls.Add(this.panelControl2);
            this.panelControl100000.Controls.Add(this.panelControl1);
            this.panelControl100000.Size = new System.Drawing.Size(498, 320);
            // 
            // treeBuilding
            // 
            this.treeBuilding.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeBuilding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBuilding.Location = new System.Drawing.Point(2, 2);
            this.treeBuilding.Name = "treeBuilding";
            this.treeBuilding.Size = new System.Drawing.Size(195, 312);
            this.treeBuilding.TabIndex = 6;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名字";
            this.treeListColumn1.FieldName = "NodeName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 99;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeBuilding);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(199, 316);
            this.panelControl1.TabIndex = 7;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labDiscountPrice);
            this.panelControl2.Controls.Add(this.ffdsf);
            this.panelControl2.Controls.Add(this.txtOriginalPrice);
            this.panelControl2.Controls.Add(this.txtHour);
            this.panelControl2.Controls.Add(this.txtDiscountPrice);
            this.panelControl2.Controls.Add(this.txtDiscount);
            this.panelControl2.Controls.Add(this.labOriginalPrice);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.labTimeUnit);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.gfaf);
            this.panelControl2.Controls.Add(this.cmbCheckinType);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.fdsfds);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(201, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(295, 316);
            this.panelControl2.TabIndex = 8;
            // 
            // ffdsf
            // 
            this.ffdsf.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ffdsf.Location = new System.Drawing.Point(84, 160);
            this.ffdsf.Name = "ffdsf";
            this.ffdsf.Size = new System.Drawing.Size(72, 14);
            this.ffdsf.TabIndex = 5;
            this.ffdsf.Text = "预计价格共：";
            // 
            // txtOriginalPrice
            // 
            this.txtOriginalPrice.Enabled = false;
            this.txtOriginalPrice.Location = new System.Drawing.Point(84, 38);
            this.txtOriginalPrice.Name = "txtOriginalPrice";
            this.txtOriginalPrice.Size = new System.Drawing.Size(100, 21);
            this.txtOriginalPrice.TabIndex = 2;
            // 
            // txtHour
            // 
            this.txtHour.EditValue = "1";
            this.txtHour.Location = new System.Drawing.Point(84, 119);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(100, 21);
            this.txtHour.TabIndex = 2;
            // 
            // txtDiscountPrice
            // 
            this.txtDiscountPrice.Enabled = false;
            this.txtDiscountPrice.Location = new System.Drawing.Point(84, 92);
            this.txtDiscountPrice.Name = "txtDiscountPrice";
            this.txtDiscountPrice.Size = new System.Drawing.Size(100, 21);
            this.txtDiscountPrice.TabIndex = 2;
            // 
            // txtDiscount
            // 
            this.txtDiscount.EditValue = "100";
            this.txtDiscount.Location = new System.Drawing.Point(84, 65);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 21);
            this.txtDiscount.TabIndex = 2;
            // 
            // labOriginalPrice
            // 
            this.labOriginalPrice.Location = new System.Drawing.Point(8, 41);
            this.labOriginalPrice.Name = "labOriginalPrice";
            this.labOriginalPrice.Size = new System.Drawing.Size(70, 14);
            this.labOriginalPrice.TabIndex = 0;
            this.labOriginalPrice.Text = "实际价格(天)";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(190, 68);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(12, 14);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "%";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(190, 41);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(12, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "￥";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(190, 95);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(12, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "￥";
            // 
            // labTimeUnit
            // 
            this.labTimeUnit.Location = new System.Drawing.Point(190, 122);
            this.labTimeUnit.Name = "labTimeUnit";
            this.labTimeUnit.Size = new System.Drawing.Size(12, 14);
            this.labTimeUnit.TabIndex = 0;
            this.labTimeUnit.Text = "天";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 122);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "预离时间";
            // 
            // gfaf
            // 
            this.gfaf.Location = new System.Drawing.Point(8, 95);
            this.gfaf.Name = "gfaf";
            this.gfaf.Size = new System.Drawing.Size(70, 14);
            this.gfaf.TabIndex = 0;
            this.gfaf.Text = "折后价格(天)";
            // 
            // cmbCheckinType
            // 
            this.cmbCheckinType.EditValue = "记天";
            this.cmbCheckinType.Location = new System.Drawing.Point(84, 11);
            this.cmbCheckinType.Name = "cmbCheckinType";
            this.cmbCheckinType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCheckinType.Properties.Items.AddRange(new object[] {
            "记天",
            "钟点房"});
            this.cmbCheckinType.Size = new System.Drawing.Size(100, 21);
            this.cmbCheckinType.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "折扣";
            // 
            // fdsfds
            // 
            this.fdsfds.Location = new System.Drawing.Point(30, 14);
            this.fdsfds.Name = "fdsfds";
            this.fdsfds.Size = new System.Drawing.Size(48, 14);
            this.fdsfds.TabIndex = 0;
            this.fdsfds.Text = "开房方式";
            // 
            // labDiscountPrice
            // 
            this.labDiscountPrice.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labDiscountPrice.Location = new System.Drawing.Point(162, 160);
            this.labDiscountPrice.Name = "labDiscountPrice";
            this.labDiscountPrice.Size = new System.Drawing.Size(0, 14);
            this.labDiscountPrice.TabIndex = 5;
            // 
            // FormSelectRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 363);
            this.Name = "FormSelectRoom";
            this.Text = "FormSelectRoom";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).EndInit();
            this.panelControl100000.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeBuilding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginalPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCheckinType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeBuilding;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtOriginalPrice;
        private DevExpress.XtraEditors.TextEdit txtDiscountPrice;
        private DevExpress.XtraEditors.TextEdit txtDiscount;
        private DevExpress.XtraEditors.LabelControl labOriginalPrice;
        private DevExpress.XtraEditors.LabelControl gfaf;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCheckinType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl fdsfds;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtHour;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labTimeUnit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl ffdsf;
        private DevExpress.XtraEditors.LabelControl labDiscountPrice;



    }
}