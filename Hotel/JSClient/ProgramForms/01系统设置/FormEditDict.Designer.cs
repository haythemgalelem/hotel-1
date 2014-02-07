namespace Client.ProgramForms
{
    partial class FormEditDict
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
            this.cmb_DataDictionaryType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_note = new DevExpress.XtraEditors.MemoEdit();
            this.txt_DataDictionaryDescription = new DevExpress.XtraEditors.TextEdit();
            this.txt_DataDictionaryName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_DataDictionaryCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).BeginInit();
            this.panelControl100000.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataDictionaryType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DataDictionaryDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DataDictionaryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DataDictionaryCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl100000.Controls.Add(this.cmb_DataDictionaryType);
            this.panelControl100000.Controls.Add(this.txt_note);
            this.panelControl100000.Controls.Add(this.txt_DataDictionaryDescription);
            this.panelControl100000.Controls.Add(this.txt_DataDictionaryName);
            this.panelControl100000.Controls.Add(this.labelControl4);
            this.panelControl100000.Controls.Add(this.txt_DataDictionaryCode);
            this.panelControl100000.Controls.Add(this.labelControl3);
            this.panelControl100000.Controls.Add(this.labelControl2);
            this.panelControl100000.Controls.Add(this.labelControl5);
            this.panelControl100000.Controls.Add(this.labelControl1);
            this.panelControl100000.Size = new System.Drawing.Size(440, 228);
            // 
            // cmb_DataDictionaryType
            // 
            this.cmb_DataDictionaryType.EditValue = "部门设置";
            this.cmb_DataDictionaryType.Location = new System.Drawing.Point(73, 20);
            this.cmb_DataDictionaryType.Name = "cmb_DataDictionaryType";
            this.cmb_DataDictionaryType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_DataDictionaryType.Properties.Items.AddRange(new object[] {
            "部门设置",
            "职务设置",
            "行业门类",
            "企业划分",
            "企业用地类型",
            "公文类型"});
            this.cmb_DataDictionaryType.Properties.ReadOnly = true;
            this.cmb_DataDictionaryType.Size = new System.Drawing.Size(141, 21);
            this.cmb_DataDictionaryType.TabIndex = 26;
            // 
            // txt_note
            // 
            this.txt_note.Location = new System.Drawing.Point(73, 101);
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(328, 112);
            this.txt_note.TabIndex = 24;
            // 
            // txt_DataDictionaryDescription
            // 
            this.txt_DataDictionaryDescription.Location = new System.Drawing.Point(73, 74);
            this.txt_DataDictionaryDescription.Name = "txt_DataDictionaryDescription";
            this.txt_DataDictionaryDescription.Size = new System.Drawing.Size(328, 21);
            this.txt_DataDictionaryDescription.TabIndex = 23;
            // 
            // txt_DataDictionaryName
            // 
            this.txt_DataDictionaryName.Location = new System.Drawing.Point(73, 47);
            this.txt_DataDictionaryName.Name = "txt_DataDictionaryName";
            this.txt_DataDictionaryName.Size = new System.Drawing.Size(141, 21);
            this.txt_DataDictionaryName.TabIndex = 21;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 101);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "备注";
            // 
            // txt_DataDictionaryCode
            // 
            this.txt_DataDictionaryCode.Location = new System.Drawing.Point(274, 20);
            this.txt_DataDictionaryCode.Name = "txt_DataDictionaryCode";
            this.txt_DataDictionaryCode.Size = new System.Drawing.Size(127, 21);
            this.txt_DataDictionaryCode.TabIndex = 22;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(36, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "描述";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.Location = new System.Drawing.Point(36, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "名称";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl5.Location = new System.Drawing.Point(36, 20);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "类型";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Location = new System.Drawing.Point(237, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "编号";
            // 
            // FormEditDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 271);
            this.Name = "FormEditDict";
            this.Text = "编辑字典数据";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).EndInit();
            this.panelControl100000.ResumeLayout(false);
            this.panelControl100000.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataDictionaryType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DataDictionaryDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DataDictionaryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_DataDictionaryCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmb_DataDictionaryType;
        private DevExpress.XtraEditors.MemoEdit txt_note;
        private DevExpress.XtraEditors.TextEdit txt_DataDictionaryDescription;
        private DevExpress.XtraEditors.TextEdit txt_DataDictionaryName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_DataDictionaryCode;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}