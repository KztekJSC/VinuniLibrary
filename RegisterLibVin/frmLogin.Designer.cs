namespace RegisterLibVin
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.picFullname = new System.Windows.Forms.PictureBox();
            this.picPass = new System.Windows.Forms.PictureBox();
            this.picAcount = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picHide = new System.Windows.Forms.PictureBox();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.btnExit = new CustomControls.RJControls.RJButton();
            this.togbtnLogin = new CustomControls.RJControls.RJButton();
            this.btnLogin = new CustomControls.RJControls.RJButton();
            this.togbtnRegister = new CustomControls.RJControls.RJButton();
            this.txbPass = new CustomControls.RJControls.RJTextBox();
            this.txbAcount = new CustomControls.RJControls.RJTextBox();
            this.txbPass2 = new CustomControls.RJControls.RJTextBox();
            this.txbFullName = new CustomControls.RJControls.RJTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picFullname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.checkBox1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.checkBox1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Image = global::RegisterLibVin.Properties.Resources._unchecked;
            this.checkBox1.Location = new System.Drawing.Point(34, 299);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(153, 30);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "  Remember Password";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.chkChecked);
            // 
            // picFullname
            // 
            this.picFullname.BackColor = System.Drawing.Color.Transparent;
            this.picFullname.Image = ((System.Drawing.Image)(resources.GetObject("picFullname.Image")));
            this.picFullname.Location = new System.Drawing.Point(55, 215);
            this.picFullname.Name = "picFullname";
            this.picFullname.Size = new System.Drawing.Size(18, 18);
            this.picFullname.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFullname.TabIndex = 11;
            this.picFullname.TabStop = false;
            this.picFullname.Visible = false;
            // 
            // picPass
            // 
            this.picPass.BackColor = System.Drawing.Color.Transparent;
            this.picPass.Image = ((System.Drawing.Image)(resources.GetObject("picPass.Image")));
            this.picPass.Location = new System.Drawing.Point(54, 254);
            this.picPass.Name = "picPass";
            this.picPass.Size = new System.Drawing.Size(18, 18);
            this.picPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPass.TabIndex = 11;
            this.picPass.TabStop = false;
            // 
            // picAcount
            // 
            this.picAcount.BackColor = System.Drawing.Color.Transparent;
            this.picAcount.Image = ((System.Drawing.Image)(resources.GetObject("picAcount.Image")));
            this.picAcount.Location = new System.Drawing.Point(55, 215);
            this.picAcount.Name = "picAcount";
            this.picAcount.Size = new System.Drawing.Size(18, 18);
            this.picAcount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAcount.TabIndex = 11;
            this.picAcount.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // picHide
            // 
            this.picHide.BackColor = System.Drawing.Color.Transparent;
            this.picHide.Image = ((System.Drawing.Image)(resources.GetObject("picHide.Image")));
            this.picHide.Location = new System.Drawing.Point(284, 257);
            this.picHide.Name = "picHide";
            this.picHide.Size = new System.Drawing.Size(18, 18);
            this.picHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHide.TabIndex = 11;
            this.picHide.TabStop = false;
            this.picHide.Click += new System.EventHandler(this.picHide_Click);
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Transparent;
            this.picShow.Image = ((System.Drawing.Image)(resources.GetObject("picShow.Image")));
            this.picShow.Location = new System.Drawing.Point(284, 257);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(18, 18);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShow.TabIndex = 11;
            this.picShow.TabStop = false;
            this.picShow.Click += new System.EventHandler(this.picShow_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(86)))));
            this.btnExit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(86)))));
            this.btnExit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExit.BorderRadius = 15;
            this.btnExit.BorderSize = 0;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(77, 425);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(225, 40);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // togbtnLogin
            // 
            this.togbtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(86)))));
            this.togbtnLogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(86)))));
            this.togbtnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.togbtnLogin.BorderRadius = 20;
            this.togbtnLogin.BorderSize = 0;
            this.togbtnLogin.FlatAppearance.BorderSize = 0;
            this.togbtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.togbtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.togbtnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.togbtnLogin.ForeColor = System.Drawing.Color.White;
            this.togbtnLogin.Location = new System.Drawing.Point(81, 12);
            this.togbtnLogin.Name = "togbtnLogin";
            this.togbtnLogin.Size = new System.Drawing.Size(111, 40);
            this.togbtnLogin.TabIndex = 6;
            this.togbtnLogin.Text = "Login";
            this.togbtnLogin.TextColor = System.Drawing.Color.White;
            this.togbtnLogin.UseVisualStyleBackColor = false;
            this.togbtnLogin.Click += new System.EventHandler(this.togbtnLogin_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(86)))));
            this.btnLogin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(86)))));
            this.btnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogin.BorderRadius = 20;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(77, 379);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(225, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // togbtnRegister
            // 
            this.togbtnRegister.BackColor = System.Drawing.Color.White;
            this.togbtnRegister.BackgroundColor = System.Drawing.Color.White;
            this.togbtnRegister.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.togbtnRegister.BorderRadius = 20;
            this.togbtnRegister.BorderSize = 1;
            this.togbtnRegister.FlatAppearance.BorderSize = 0;
            this.togbtnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.togbtnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.togbtnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.togbtnRegister.ForeColor = System.Drawing.Color.Black;
            this.togbtnRegister.Location = new System.Drawing.Point(137, 12);
            this.togbtnRegister.Name = "togbtnRegister";
            this.togbtnRegister.Size = new System.Drawing.Size(165, 40);
            this.togbtnRegister.TabIndex = 6;
            this.togbtnRegister.Text = "             Register";
            this.togbtnRegister.TextColor = System.Drawing.Color.Black;
            this.togbtnRegister.UseVisualStyleBackColor = false;
            this.togbtnRegister.Click += new System.EventHandler(this.togbtnRegister_Click);
            // 
            // txbPass
            // 
            this.txbPass.BackColor = System.Drawing.SystemColors.Window;
            this.txbPass.BorderColor = System.Drawing.Color.Gray;
            this.txbPass.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbPass.BorderRadius = 0;
            this.txbPass.BorderSize = 1;
            this.txbPass.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass.ForeColor = System.Drawing.Color.Gray;
            this.txbPass.Location = new System.Drawing.Point(79, 245);
            this.txbPass.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass.Multiline = false;
            this.txbPass.Name = "txbPass";
            this.txbPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPass.PasswordChar = false;
            this.txbPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPass.PlaceholderText = "";
            this.txbPass.Size = new System.Drawing.Size(223, 32);
            this.txbPass.TabIndex = 3;
            this.txbPass.Texts = "Password";
            this.txbPass.UnderlinedStyle = true;
            this.txbPass.Enter += new System.EventHandler(this.txbPass_Enter);
            this.txbPass.Leave += new System.EventHandler(this.txbPass_Leave);
            // 
            // txbAcount
            // 
            this.txbAcount.BackColor = System.Drawing.SystemColors.Window;
            this.txbAcount.BorderColor = System.Drawing.Color.Gray;
            this.txbAcount.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbAcount.BorderRadius = 0;
            this.txbAcount.BorderSize = 1;
            this.txbAcount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAcount.ForeColor = System.Drawing.Color.Gray;
            this.txbAcount.Location = new System.Drawing.Point(79, 206);
            this.txbAcount.Margin = new System.Windows.Forms.Padding(4);
            this.txbAcount.Multiline = false;
            this.txbAcount.Name = "txbAcount";
            this.txbAcount.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbAcount.PasswordChar = false;
            this.txbAcount.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbAcount.PlaceholderText = "";
            this.txbAcount.Size = new System.Drawing.Size(223, 32);
            this.txbAcount.TabIndex = 2;
            this.txbAcount.Texts = "Username";
            this.txbAcount.UnderlinedStyle = true;
            this.txbAcount._TextChanged += new System.EventHandler(this.txbAcount__TextChanged);
            this.txbAcount.Enter += new System.EventHandler(this.txbAcount_Enter);
            this.txbAcount.Leave += new System.EventHandler(this.txbAcount_Leave);
            // 
            // txbPass2
            // 
            this.txbPass2.BackColor = System.Drawing.SystemColors.Window;
            this.txbPass2.BorderColor = System.Drawing.Color.Gray;
            this.txbPass2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbPass2.BorderRadius = 0;
            this.txbPass2.BorderSize = 1;
            this.txbPass2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass2.ForeColor = System.Drawing.Color.Gray;
            this.txbPass2.Location = new System.Drawing.Point(77, 284);
            this.txbPass2.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass2.Multiline = false;
            this.txbPass2.Name = "txbPass2";
            this.txbPass2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPass2.PasswordChar = false;
            this.txbPass2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPass2.PlaceholderText = "";
            this.txbPass2.Size = new System.Drawing.Size(223, 32);
            this.txbPass2.TabIndex = 4;
            this.txbPass2.Texts = "Confirm password";
            this.txbPass2.UnderlinedStyle = true;
            this.txbPass2.Visible = false;
            this.txbPass2.Enter += new System.EventHandler(this.txbPass2_Enter);
            this.txbPass2.Leave += new System.EventHandler(this.txbPass2_Leave);
            // 
            // txbFullName
            // 
            this.txbFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txbFullName.BorderColor = System.Drawing.Color.Gray;
            this.txbFullName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbFullName.BorderRadius = 0;
            this.txbFullName.BorderSize = 1;
            this.txbFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFullName.ForeColor = System.Drawing.Color.Gray;
            this.txbFullName.Location = new System.Drawing.Point(79, 324);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txbFullName.Multiline = false;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbFullName.PasswordChar = false;
            this.txbFullName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbFullName.PlaceholderText = "";
            this.txbFullName.Size = new System.Drawing.Size(223, 32);
            this.txbFullName.TabIndex = 1;
            this.txbFullName.Texts = "Full Name";
            this.txbFullName.UnderlinedStyle = true;
            this.txbFullName.Visible = false;
            this.txbFullName.Enter += new System.EventHandler(this.txbFullName_Enter);
            this.txbFullName.Leave += new System.EventHandler(this.txbFullName_Leave);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(370, 504);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.picFullname);
            this.Controls.Add(this.picPass);
            this.Controls.Add(this.picAcount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.togbtnLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.togbtnRegister);
            this.Controls.Add(this.picHide);
            this.Controls.Add(this.picShow);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.txbAcount);
            this.Controls.Add(this.txbPass2);
            this.Controls.Add(this.txbFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Library";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picFullname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.RJControls.RJButton btnLogin;
        private CustomControls.RJControls.RJButton btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txbAcount;
        private CustomControls.RJControls.RJTextBox txbPass;
        private CustomControls.RJControls.RJButton togbtnLogin;
        private CustomControls.RJControls.RJButton togbtnRegister;
        private System.Windows.Forms.PictureBox picAcount;
        private System.Windows.Forms.PictureBox picPass;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.CheckBox checkBox1;
        private CustomControls.RJControls.RJTextBox txbPass2;
        private CustomControls.RJControls.RJTextBox txbFullName;
        private System.Windows.Forms.PictureBox picFullname;
        private System.Windows.Forms.PictureBox picHide;
    }
}