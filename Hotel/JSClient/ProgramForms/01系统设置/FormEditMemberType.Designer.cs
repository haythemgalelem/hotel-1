namespace Client.ProgramForms
{
    partial class FormEditMemberType
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTypeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBaseDiscount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtScoreIncrease = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).BeginInit();
            this.panelControl100000.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseDiscount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScoreIncrease.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl100000.Controls.Add(this.txtNote);
            this.panelControl100000.Controls.Add(this.labelControl4);
            this.panelControl100000.Controls.Add(this.txtScoreIncrease);
            this.panelControl100000.Controls.Add(this.labelControl3);
            this.panelControl100000.Controls.Add(this.txtBaseDiscount);
            this.panelControl100000.Controls.Add(this.labelControl2);
            this.panelControl100000.Controls.Add(this.txtTypeName);
            this.panelControl100000.Controls.Add(this.labelControl1);
            this.panelControl100000.Size = new System.Drawing.Size(373, 167);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "类型名称";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(60, 12);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(100, 21);
            this.txtTypeName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(200, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "基础折扣";
            // 
            // txtBaseDiscount
            // 
            this.txtBaseDiscount.EditValue = "100%";
            this.txtBaseDiscount.Location = new System.Drawing.Point(254, 12);
            this.txtBaseDiscount.Name = "txtBaseDiscount";
            this.txtBaseDiscount.Size = new System.Drawing.Size(100, 21);
            this.txtBaseDiscount.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "积分增长";
            // 
            // txtScoreIncrease
            // 
            this.txtScoreIncrease.EditValue = "0";
            this.txtScoreIncrease.Location = new System.Drawing.Point(60, 39);
            this.txtScoreIncrease.Name = "txtScoreIncrease";
            this.txtScoreIncrease.Size = new System.Drawing.Size(100, 21);
            this.txtScoreIncrease.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(30, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "备注";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(60, 67);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(294, 91);
            this.txtNote.TabIndex = 2;
            // 
            // FormEditMemberType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 210);
            this.Name = "FormEditMemberType";
            this.Text = "FormEditMemberType";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).EndInit();
            this.panelControl100000.ResumeLayout(false);
            this.panelControl100000.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBaseDiscount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScoreIncrease.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtScoreIncrease;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtBaseDiscount;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTypeName;
    }
}