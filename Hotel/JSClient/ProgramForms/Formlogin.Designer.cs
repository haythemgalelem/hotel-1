namespace Client.ProgramForms
{
    partial class Formlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formlogin));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_PassWord = new DevExpress.XtraEditors.TextEdit();
            this.panelBar_Login = new DevExpress.XtraEditors.PanelControl();
            this.progBar_Login = new DevExpress.XtraEditors.ProgressBarControl();
            this.lb_Notice = new DevExpress.XtraEditors.LabelControl();
            this.txt_UserName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.lbl_login = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar_Login)).BeginInit();
            this.panelBar_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progBar_Login.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Location = new System.Drawing.Point(44, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl2.Location = new System.Drawing.Point(44, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "密   码：";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(107, 63);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txt_PassWord.Size = new System.Drawing.Size(191, 21);
            this.txt_PassWord.TabIndex = 2;
            // 
            // panelBar_Login
            // 
            this.panelBar_Login.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelBar_Login.Appearance.Options.UseBackColor = true;
            this.panelBar_Login.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBar_Login.Controls.Add(this.progBar_Login);
            this.panelBar_Login.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBar_Login.Location = new System.Drawing.Point(0, 187);
            this.panelBar_Login.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelBar_Login.LookAndFeel.UseWindowsXPTheme = true;
            this.panelBar_Login.Name = "panelBar_Login";
            this.panelBar_Login.Padding = new System.Windows.Forms.Padding(10);
            this.panelBar_Login.Size = new System.Drawing.Size(346, 31);
            this.panelBar_Login.TabIndex = 19;
            this.panelBar_Login.Visible = false;
            // 
            // progBar_Login
            // 
            this.progBar_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progBar_Login.EditValue = "0";
            this.progBar_Login.Location = new System.Drawing.Point(10, 10);
            this.progBar_Login.Margin = new System.Windows.Forms.Padding(0);
            this.progBar_Login.Name = "progBar_Login";
            this.progBar_Login.Size = new System.Drawing.Size(326, 11);
            this.progBar_Login.TabIndex = 6;
            // 
            // lb_Notice
            // 
            this.lb_Notice.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lb_Notice.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.lb_Notice.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.lb_Notice.Appearance.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.lb_Notice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lb_Notice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_Notice.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_Notice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_Notice.Location = new System.Drawing.Point(0, 161);
            this.lb_Notice.Name = "lb_Notice";
            this.lb_Notice.Size = new System.Drawing.Size(346, 26);
            this.lb_Notice.TabIndex = 20;
            this.lb_Notice.Text = "加载：";
            this.lb_Notice.Visible = false;
            // 
            // txt_UserName
            // 
            this.txt_UserName.EnterMoveNextControl = true;
            this.txt_UserName.Location = new System.Drawing.Point(107, 29);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserName.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_UserName.Properties.Appearance.Options.UseFont = true;
            this.txt_UserName.Properties.Appearance.Options.UseForeColor = true;
            this.txt_UserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txt_UserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_UserName.Size = new System.Drawing.Size(191, 21);
            this.txt_UserName.TabIndex = 1;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(105, 95);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.checkEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit1.Properties.Caption = "记住密码";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 21;
            // 
            // lbl_login
            // 
            this.lbl_login.Location = new System.Drawing.Point(44, 129);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(89, 32);
            this.lbl_login.TabIndex = 24;
            this.lbl_login.Text = "     登    录      ";
            // 
            // lbl_cancel
            // 
            this.lbl_cancel.Location = new System.Drawing.Point(157, 129);
            this.lbl_cancel.Name = "lbl_cancel";
            this.lbl_cancel.Size = new System.Drawing.Size(89, 32);
            this.lbl_cancel.TabIndex = 24;
            this.lbl_cancel.Text = "     取    消     ";
            // 
            // Formlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(346, 218);
            this.Controls.Add(this.lbl_cancel);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.txt_PassWord);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lb_Notice);
            this.Controls.Add(this.panelBar_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Formlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBar_Login)).EndInit();
            this.panelBar_Login.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progBar_Login.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_PassWord;
        private DevExpress.XtraEditors.PanelControl panelBar_Login;
        private DevExpress.XtraEditors.ProgressBarControl progBar_Login;
        private DevExpress.XtraEditors.LabelControl lb_Notice;
        private DevExpress.XtraEditors.ComboBoxEdit txt_UserName;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.SimpleButton lbl_login;
        private DevExpress.XtraEditors.SimpleButton lbl_cancel;
    }
}