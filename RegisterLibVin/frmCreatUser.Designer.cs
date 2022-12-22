namespace RegisterLibVin
{
    partial class frmCreatUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreatUser));
            this.label2 = new System.Windows.Forms.Label();
            this.cbbQuyen = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.btnCreat = new CustomControls.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbPass = new CustomControls.RJControls.RJTextBox();
            this.txbUserName = new CustomControls.RJControls.RJTextBox();
            this.txbFullName = new CustomControls.RJControls.RJTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 30);
            this.label2.TabIndex = 173;
            this.label2.Text = "Creat Account";
            // 
            // cbbQuyen
            // 
            this.cbbQuyen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbQuyen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbQuyen.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.cbbQuyen.BorderSize = 2;
            this.cbbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbQuyen.ForeColor = System.Drawing.Color.DimGray;
            this.cbbQuyen.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbQuyen.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbQuyen.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbQuyen.Location = new System.Drawing.Point(551, 179);
            this.cbbQuyen.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbQuyen.Name = "cbbQuyen";
            this.cbbQuyen.Padding = new System.Windows.Forms.Padding(2);
            this.cbbQuyen.Size = new System.Drawing.Size(200, 30);
            this.cbbQuyen.TabIndex = 4;
            this.cbbQuyen.Texts = "";
            // 
            // btnCreat
            // 
            this.btnCreat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreat.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCreat.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.btnCreat.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreat.BorderRadius = 10;
            this.btnCreat.BorderSize = 0;
            this.btnCreat.FlatAppearance.BorderSize = 0;
            this.btnCreat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreat.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreat.ForeColor = System.Drawing.Color.White;
            this.btnCreat.Image = ((System.Drawing.Image)(resources.GetObject("btnCreat.Image")));
            this.btnCreat.Location = new System.Drawing.Point(248, 223);
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size(98, 40);
            this.btnCreat.TabIndex = 5;
            this.btnCreat.Text = "  Register";
            this.btnCreat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreat.TextColor = System.Drawing.Color.White;
            this.btnCreat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreat.UseVisualStyleBackColor = false;
            this.btnCreat.Click += new System.EventHandler(this.btnCreat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 170;
            this.pictureBox1.TabStop = false;
            // 
            // txbPass
            // 
            this.txbPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbPass.BackColor = System.Drawing.SystemColors.Window;
            this.txbPass.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txbPass.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbPass.BorderRadius = 5;
            this.txbPass.BorderSize = 2;
            this.txbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbPass.Location = new System.Drawing.Point(551, 117);
            this.txbPass.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass.Multiline = false;
            this.txbPass.Name = "txbPass";
            this.txbPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPass.PasswordChar = true;
            this.txbPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPass.PlaceholderText = "";
            this.txbPass.Size = new System.Drawing.Size(198, 31);
            this.txbPass.TabIndex = 3;
            this.txbPass.Texts = "";
            this.txbPass.UnderlinedStyle = false;
            // 
            // txbUserName
            // 
            this.txbUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txbUserName.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txbUserName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbUserName.BorderRadius = 5;
            this.txbUserName.BorderSize = 2;
            this.txbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbUserName.Location = new System.Drawing.Point(248, 178);
            this.txbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserName.Multiline = false;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbUserName.PasswordChar = false;
            this.txbUserName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbUserName.PlaceholderText = "";
            this.txbUserName.Size = new System.Drawing.Size(198, 31);
            this.txbUserName.TabIndex = 2;
            this.txbUserName.Texts = "";
            this.txbUserName.UnderlinedStyle = false;
            // 
            // txbFullName
            // 
            this.txbFullName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txbFullName.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txbFullName.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbFullName.BorderRadius = 5;
            this.txbFullName.BorderSize = 2;
            this.txbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbFullName.Location = new System.Drawing.Point(248, 117);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txbFullName.Multiline = false;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbFullName.PasswordChar = false;
            this.txbFullName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbFullName.PlaceholderText = "";
            this.txbFullName.Size = new System.Drawing.Size(198, 31);
            this.txbFullName.TabIndex = 1;
            this.txbFullName.Texts = "";
            this.txbFullName.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(548, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 163;
            this.label6.Text = "AccessPermission";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(548, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 164;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 165;
            this.label4.Text = "UserName";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(251, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 166;
            this.label3.Text = "FullName";
            // 
            // frmCreatUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 316);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbQuyen);
            this.Controls.Add(this.btnCreat);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.txbFullName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreatUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creat Account";
            this.Load += new System.EventHandler(this.frmCreatUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private UC_Combobox.RJComboBox cbbQuyen;
        private CustomControls.RJControls.RJButton btnCreat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txbPass;
        private CustomControls.RJControls.RJTextBox txbUserName;
        private CustomControls.RJControls.RJTextBox txbFullName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}