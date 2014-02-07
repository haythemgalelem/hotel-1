namespace Client.CommonForms
{
    partial class FormLock
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
            this.btn_Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lb_Notice = new DevExpress.XtraEditors.LabelControl();
            this.txt_InputStr = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_InputStr.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Confirm.Location = new System.Drawing.Point(237, 42);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(19, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(160, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "窗口已锁定,输入用户密码解锁";
            // 
            // lb_Notice
            // 
            this.lb_Notice.Location = new System.Drawing.Point(19, 47);
            this.lb_Notice.Name = "lb_Notice";
            this.lb_Notice.Size = new System.Drawing.Size(72, 14);
            this.lb_Notice.TabIndex = 2;
            this.lb_Notice.Text = "请输入密码：";
            // 
            // txt_InputStr
            // 
            this.txt_InputStr.Location = new System.Drawing.Point(106, 44);
            this.txt_InputStr.Name = "txt_InputStr";
            this.txt_InputStr.Properties.PasswordChar = '*';
            this.txt_InputStr.Size = new System.Drawing.Size(124, 21);
            this.txt_InputStr.TabIndex = 1;
            // 
            // FormLock
            // 
            this.AcceptButton = this.btn_Confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 101);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lb_Notice);
            this.Controls.Add(this.txt_InputStr);
            this.Controls.Add(this.btn_Confirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 130);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 129);
            this.Name = "FormLock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提示：";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLock_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_InputStr.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Confirm;
        private DevExpress.XtraEditors.TextEdit txt_InputStr;
        private DevExpress.XtraEditors.LabelControl lb_Notice;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}