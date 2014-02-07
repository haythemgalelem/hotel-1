namespace Client.CommonForms
{
    partial class FormDlgBase
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
            this.panelControl100000 = new DevExpress.XtraEditors.PanelControl();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2000000 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2000000)).BeginInit();
            this.panelControl2000000.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl100000
            // 
            this.panelControl100000.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl100000.Location = new System.Drawing.Point(0, 0);
            this.panelControl100000.Name = "panelControl100000";
            this.panelControl100000.Size = new System.Drawing.Size(593, 354);
            this.panelControl100000.TabIndex = 0;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Location = new System.Drawing.Point(388, 8);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "确定";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(479, 8);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            // 
            // panelControl2000000
            // 
            this.panelControl2000000.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2000000.Controls.Add(this.btn_cancel);
            this.panelControl2000000.Controls.Add(this.btn_ok);
            this.panelControl2000000.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2000000.Location = new System.Drawing.Point(0, 354);
            this.panelControl2000000.Name = "panelControl2000000";
            this.panelControl2000000.Size = new System.Drawing.Size(593, 43);
            this.panelControl2000000.TabIndex = 1;
            // 
            // FormDlgBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 397);
            this.Controls.Add(this.panelControl100000);
            this.Controls.Add(this.panelControl2000000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDlgBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDlgBase";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl100000)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2000000)).EndInit();
            this.panelControl2000000.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PanelControl panelControl100000;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraEditors.PanelControl panelControl2000000;
    }
}