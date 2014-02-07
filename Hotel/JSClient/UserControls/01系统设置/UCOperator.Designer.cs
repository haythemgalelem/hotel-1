namespace Client.UserControls
{
    partial class UCOperator
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
            this.gdOperator = new DevExpress.XtraGrid.GridControl();
            this.gvOperator = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OperateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gdOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOperator)).BeginInit();
            this.SuspendLayout();
            // 
            // gdOperator
            // 
            this.gdOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdOperator.Location = new System.Drawing.Point(0, 0);
            this.gdOperator.MainView = this.gvOperator;
            this.gdOperator.Name = "gdOperator";
            this.gdOperator.Size = new System.Drawing.Size(596, 360);
            this.gdOperator.TabIndex = 0;
            this.gdOperator.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOperator});
            // 
            // gvOperator
            // 
            this.gvOperator.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.OperateTime});
            this.gvOperator.GridControl = this.gdOperator;
            this.gvOperator.Name = "gvOperator";
            this.gvOperator.OptionsView.ColumnAutoWidth = false;
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
            this.gridColumn2.Caption = "用户名";
            this.gridColumn2.FieldName = "OperateName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "登录名";
            this.gridColumn3.FieldName = "OperateCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "是否可用";
            this.gridColumn4.FieldName = "StateBool";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "备注";
            this.gridColumn5.FieldName = "Note";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "创建人";
            this.gridColumn6.FieldName = "OperatorName_Name";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // OperateTime
            // 
            this.OperateTime.Caption = "创建时间";
            this.OperateTime.FieldName = "OperateTime";
            this.OperateTime.Name = "OperateTime";
            this.OperateTime.OptionsColumn.AllowEdit = false;
            this.OperateTime.Visible = true;
            this.OperateTime.VisibleIndex = 6;
            // 
            // UCOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdOperator);
            this.Hasbtn_Add = true;
            this.Hasbtn_Delete = true;
            this.Hasbtn_Modify = true;
            this.Hasbtn_Refresh = true;
            this.Name = "UCOperator";
            this.Size = new System.Drawing.Size(596, 360);
            ((System.ComponentModel.ISupportInitialize)(this.gdOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOperator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdOperator;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOperator;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn OperateTime;
    }
}