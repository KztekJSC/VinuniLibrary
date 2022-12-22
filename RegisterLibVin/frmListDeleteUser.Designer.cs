namespace RegisterLibVin
{
    partial class frmListDeleteUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListDeleteUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUserID = new CustomControls.RJControls.RJTextBox();
            this.btnDeleteRemove = new CustomControls.RJControls.RJButton();
            this.btnKhoiPhuc = new CustomControls.RJControls.RJButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListDeleteUser = new System.Windows.Forms.DataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDeleteUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckbSelectAll);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 70);
            this.panel1.TabIndex = 171;
            // 
            // ckbSelectAll
            // 
            this.ckbSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckbSelectAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbSelectAll.AutoSize = true;
            this.ckbSelectAll.FlatAppearance.BorderSize = 0;
            this.ckbSelectAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.ckbSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ckbSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ckbSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbSelectAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSelectAll.Image = global::RegisterLibVin.Properties.Resources._unchecked;
            this.ckbSelectAll.Location = new System.Drawing.Point(2, 41);
            this.ckbSelectAll.Name = "ckbSelectAll";
            this.ckbSelectAll.Size = new System.Drawing.Size(87, 30);
            this.ckbSelectAll.TabIndex = 165;
            this.ckbSelectAll.Text = "Select All";
            this.ckbSelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbSelectAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ckbSelectAll.UseVisualStyleBackColor = true;
            this.ckbSelectAll.CheckedChanged += new System.EventHandler(this.ckbSelectAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(428, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 30);
            this.label2.TabIndex = 162;
            this.label2.Text = "Deleted User List";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txbUserID);
            this.panel3.Controls.Add(this.btnDeleteRemove);
            this.panel3.Controls.Add(this.btnKhoiPhuc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 588);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1057, 100);
            this.panel3.TabIndex = 172;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(229, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 305);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 163;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(495, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 163;
            this.label3.Text = "UserID";
            this.label3.Visible = false;
            // 
            // txbUserID
            // 
            this.txbUserID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txbUserID.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.txbUserID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbUserID.BorderRadius = 15;
            this.txbUserID.BorderSize = 1;
            this.txbUserID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbUserID.Location = new System.Drawing.Point(555, 29);
            this.txbUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserID.Multiline = false;
            this.txbUserID.Name = "txbUserID";
            this.txbUserID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbUserID.PasswordChar = false;
            this.txbUserID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbUserID.PlaceholderText = "";
            this.txbUserID.Size = new System.Drawing.Size(211, 32);
            this.txbUserID.TabIndex = 161;
            this.txbUserID.Texts = "";
            this.txbUserID.UnderlinedStyle = false;
            this.txbUserID.Visible = false;
            // 
            // btnDeleteRemove
            // 
            this.btnDeleteRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDeleteRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeleteRemove.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeleteRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeleteRemove.BorderRadius = 10;
            this.btnDeleteRemove.BorderSize = 2;
            this.btnDeleteRemove.FlatAppearance.BorderSize = 0;
            this.btnDeleteRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRemove.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRemove.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRemove.Image")));
            this.btnDeleteRemove.Location = new System.Drawing.Point(12, 15);
            this.btnDeleteRemove.Name = "btnDeleteRemove";
            this.btnDeleteRemove.Size = new System.Drawing.Size(110, 64);
            this.btnDeleteRemove.TabIndex = 159;
            this.btnDeleteRemove.Text = "   Delete";
            this.btnDeleteRemove.TextColor = System.Drawing.Color.Black;
            this.btnDeleteRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteRemove.UseVisualStyleBackColor = false;
            this.btnDeleteRemove.Click += new System.EventHandler(this.btnDeleteRemove_Click);
            // 
            // btnKhoiPhuc
            // 
            this.btnKhoiPhuc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnKhoiPhuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKhoiPhuc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnKhoiPhuc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnKhoiPhuc.BorderRadius = 10;
            this.btnKhoiPhuc.BorderSize = 2;
            this.btnKhoiPhuc.FlatAppearance.BorderSize = 0;
            this.btnKhoiPhuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoiPhuc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhuc.ForeColor = System.Drawing.Color.Black;
            this.btnKhoiPhuc.Image = ((System.Drawing.Image)(resources.GetObject("btnKhoiPhuc.Image")));
            this.btnKhoiPhuc.Location = new System.Drawing.Point(935, 15);
            this.btnKhoiPhuc.Name = "btnKhoiPhuc";
            this.btnKhoiPhuc.Size = new System.Drawing.Size(110, 64);
            this.btnKhoiPhuc.TabIndex = 12;
            this.btnKhoiPhuc.Text = "   Restore";
            this.btnKhoiPhuc.TextColor = System.Drawing.Color.Black;
            this.btnKhoiPhuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhoiPhuc.UseVisualStyleBackColor = false;
            this.btnKhoiPhuc.Click += new System.EventHandler(this.btnKhoiPhuc_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.dgvListDeleteUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel2.Size = new System.Drawing.Size(1057, 518);
            this.panel2.TabIndex = 173;
            // 
            // dgvListDeleteUser
            // 
            this.dgvListDeleteUser.AllowUserToAddRows = false;
            this.dgvListDeleteUser.AllowUserToDeleteRows = false;
            this.dgvListDeleteUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListDeleteUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListDeleteUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListDeleteUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDeleteUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.UserName,
            this.Password,
            this.AccessPermission,
            this.IsLock,
            this.UserID});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListDeleteUser.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListDeleteUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListDeleteUser.Location = new System.Drawing.Point(10, 0);
            this.dgvListDeleteUser.Margin = new System.Windows.Forms.Padding(20);
            this.dgvListDeleteUser.Name = "dgvListDeleteUser";
            this.dgvListDeleteUser.ReadOnly = true;
            this.dgvListDeleteUser.RowHeadersVisible = false;
            this.dgvListDeleteUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListDeleteUser.Size = new System.Drawing.Size(1037, 518);
            this.dgvListDeleteUser.TabIndex = 164;
            this.dgvListDeleteUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListDeleteUser_CellClick);
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 200;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 200;
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 200;
            // 
            // AccessPermission
            // 
            this.AccessPermission.DataPropertyName = "AccessPermission";
            this.AccessPermission.HeaderText = "AccessPermission";
            this.AccessPermission.Name = "AccessPermission";
            this.AccessPermission.ReadOnly = true;
            this.AccessPermission.Width = 200;
            // 
            // IsLock
            // 
            this.IsLock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsLock.DataPropertyName = "IsLock";
            this.IsLock.HeaderText = "Locked";
            this.IsLock.Name = "IsLock";
            this.IsLock.ReadOnly = true;
            this.IsLock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // frmListDeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 688);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListDeleteUser";
            this.Text = "Deleted List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListDeleteUser_FormClosing);
            this.Load += new System.EventHandler(this.frmListDeleteUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDeleteUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJTextBox txbUserID;
        private CustomControls.RJControls.RJButton btnDeleteRemove;
        private CustomControls.RJControls.RJButton btnKhoiPhuc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListDeleteUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessPermission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    }
}