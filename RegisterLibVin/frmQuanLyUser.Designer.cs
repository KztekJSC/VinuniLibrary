namespace RegisterLibVin
{
    partial class frmQuanLyUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListDelete = new CustomControls.RJControls.RJButton();
            this.picLock = new System.Windows.Forms.PictureBox();
            this.btnEdit = new CustomControls.RJControls.RJButton();
            this.btnCreatAcount = new CustomControls.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbPass = new CustomControls.RJControls.RJTextBox();
            this.txbQuyen = new CustomControls.RJControls.RJTextBox();
            this.txbUserID = new CustomControls.RJControls.RJTextBox();
            this.txbUserName = new CustomControls.RJControls.RJTextBox();
            this.txbFullName = new CustomControls.RJControls.RJTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvBookSV = new System.Windows.Forms.DataGridView();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new CustomControls.RJControls.RJButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnDelete = new CustomControls.RJControls.RJButton();
            this.txbtimkiem = new CustomControls.RJControls.RJTextBox();
            this.btnLock = new CustomControls.RJControls.RJButton();
            this.btnOpenLock = new CustomControls.RJControls.RJButton();
            this.cbbType1 = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookSV)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(637, -33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Account Management";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnListDelete);
            this.panel1.Controls.Add(this.picLock);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnCreatAcount);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txbPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbQuyen);
            this.panel1.Controls.Add(this.txbUserID);
            this.panel1.Controls.Add(this.txbUserName);
            this.panel1.Controls.Add(this.txbFullName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 213);
            this.panel1.TabIndex = 19;
            // 
            // btnListDelete
            // 
            this.btnListDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnListDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListDelete.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnListDelete.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnListDelete.BorderRadius = 5;
            this.btnListDelete.BorderSize = 2;
            this.btnListDelete.FlatAppearance.BorderSize = 0;
            this.btnListDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListDelete.ForeColor = System.Drawing.Color.Black;
            this.btnListDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnListDelete.Image")));
            this.btnListDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListDelete.Location = new System.Drawing.Point(1269, 16);
            this.btnListDelete.Name = "btnListDelete";
            this.btnListDelete.Size = new System.Drawing.Size(89, 64);
            this.btnListDelete.TabIndex = 152;
            this.btnListDelete.Text = " Trask";
            this.btnListDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListDelete.TextColor = System.Drawing.Color.Black;
            this.btnListDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListDelete.UseVisualStyleBackColor = false;
            this.btnListDelete.Click += new System.EventHandler(this.btnListDelete_Click);
            // 
            // picLock
            // 
            this.picLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLock.Image = ((System.Drawing.Image)(resources.GetObject("picLock.Image")));
            this.picLock.Location = new System.Drawing.Point(456, 180);
            this.picLock.Name = "picLock";
            this.picLock.Size = new System.Drawing.Size(30, 27);
            this.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLock.TabIndex = 28;
            this.picLock.TabStop = false;
            this.picLock.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.BackColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.btnEdit.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.BorderSize = 0;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(875, 167);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(111, 40);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreatAcount
            // 
            this.btnCreatAcount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreatAcount.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCreatAcount.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.btnCreatAcount.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCreatAcount.BorderRadius = 10;
            this.btnCreatAcount.BorderSize = 0;
            this.btnCreatAcount.FlatAppearance.BorderSize = 0;
            this.btnCreatAcount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatAcount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatAcount.ForeColor = System.Drawing.Color.White;
            this.btnCreatAcount.Location = new System.Drawing.Point(572, 167);
            this.btnCreatAcount.Name = "btnCreatAcount";
            this.btnCreatAcount.Size = new System.Drawing.Size(111, 40);
            this.btnCreatAcount.TabIndex = 27;
            this.btnCreatAcount.Text = "Creat Acount";
            this.btnCreatAcount.TextColor = System.Drawing.Color.White;
            this.btnCreatAcount.UseVisualStyleBackColor = false;
            this.btnCreatAcount.Click += new System.EventHandler(this.btnCreatAcount_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(287, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
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
            this.txbPass.Location = new System.Drawing.Point(788, 61);
            this.txbPass.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass.Multiline = false;
            this.txbPass.Name = "txbPass";
            this.txbPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPass.PasswordChar = false;
            this.txbPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPass.PlaceholderText = "";
            this.txbPass.Size = new System.Drawing.Size(198, 31);
            this.txbPass.TabIndex = 22;
            this.txbPass.Texts = "";
            this.txbPass.UnderlinedStyle = false;
            // 
            // txbQuyen
            // 
            this.txbQuyen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbQuyen.BackColor = System.Drawing.SystemColors.Window;
            this.txbQuyen.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txbQuyen.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbQuyen.BorderRadius = 5;
            this.txbQuyen.BorderSize = 2;
            this.txbQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbQuyen.Location = new System.Drawing.Point(788, 122);
            this.txbQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.txbQuyen.Multiline = false;
            this.txbQuyen.Name = "txbQuyen";
            this.txbQuyen.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbQuyen.PasswordChar = false;
            this.txbQuyen.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbQuyen.PlaceholderText = "";
            this.txbQuyen.Size = new System.Drawing.Size(198, 31);
            this.txbQuyen.TabIndex = 23;
            this.txbQuyen.Texts = "";
            this.txbQuyen.UnderlinedStyle = false;
            // 
            // txbUserID
            // 
            this.txbUserID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txbUserID.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txbUserID.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbUserID.BorderRadius = 5;
            this.txbUserID.BorderSize = 2;
            this.txbUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbUserID.Location = new System.Drawing.Point(1005, 167);
            this.txbUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserID.Multiline = false;
            this.txbUserID.Name = "txbUserID";
            this.txbUserID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbUserID.PasswordChar = false;
            this.txbUserID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbUserID.PlaceholderText = "";
            this.txbUserID.Size = new System.Drawing.Size(111, 31);
            this.txbUserID.TabIndex = 24;
            this.txbUserID.Texts = "";
            this.txbUserID.UnderlinedStyle = false;
            this.txbUserID.Visible = false;
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
            this.txbUserName.Location = new System.Drawing.Point(485, 122);
            this.txbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserName.Multiline = false;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbUserName.PasswordChar = false;
            this.txbUserName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbUserName.PlaceholderText = "";
            this.txbUserName.Size = new System.Drawing.Size(198, 31);
            this.txbUserName.TabIndex = 24;
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
            this.txbFullName.Location = new System.Drawing.Point(485, 61);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txbFullName.Multiline = false;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbFullName.PasswordChar = false;
            this.txbFullName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbFullName.PlaceholderText = "";
            this.txbFullName.Size = new System.Drawing.Size(198, 31);
            this.txbFullName.TabIndex = 25;
            this.txbFullName.Texts = "";
            this.txbFullName.UnderlinedStyle = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(785, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "AccessPermission";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(785, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(488, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "UserName";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(488, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "FullName";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 536);
            this.panel2.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dgvBookSV);
            this.panel4.Location = new System.Drawing.Point(12, 79);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1346, 445);
            this.panel4.TabIndex = 1;
            // 
            // dgvBookSV
            // 
            this.dgvBookSV.AllowUserToAddRows = false;
            this.dgvBookSV.AllowUserToDeleteRows = false;
            this.dgvBookSV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBookSV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookSV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullName,
            this.UserName,
            this.Password,
            this.AccessPermission,
            this.IsLock,
            this.IsDelete,
            this.UserID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookSV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookSV.Location = new System.Drawing.Point(0, 0);
            this.dgvBookSV.Name = "dgvBookSV";
            this.dgvBookSV.ReadOnly = true;
            this.dgvBookSV.RowHeadersVisible = false;
            this.dgvBookSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookSV.Size = new System.Drawing.Size(1346, 445);
            this.dgvBookSV.TabIndex = 20;
            this.dgvBookSV.MultiSelectChanged += new System.EventHandler(this.dgvBookSV_MultiSelectChanged);
            this.dgvBookSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookSV_CellContentClick);
            this.dgvBookSV.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBookSV_DataBindingComplete);
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
            // IsDelete
            // 
            this.IsDelete.DataPropertyName = "IsDelete";
            this.IsDelete.HeaderText = "Deleted";
            this.IsDelete.Name = "IsDelete";
            this.IsDelete.ReadOnly = true;
            this.IsDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IsDelete.Visible = false;
            // 
            // UserID
            // 
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.lblCount);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.txbtimkiem);
            this.panel3.Controls.Add(this.btnLock);
            this.panel3.Controls.Add(this.btnOpenLock);
            this.panel3.Controls.Add(this.cbbType1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1370, 73);
            this.panel3.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTimKiem.AutoSize = true;
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 2;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(538, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 48);
            this.btnTimKiem.TabIndex = 160;
            this.btnTimKiem.Text = "  Search";
            this.btnTimKiem.TextColor = System.Drawing.Color.Black;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(234, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 17);
            this.lblCount.TabIndex = 152;
            this.lblCount.Text = "Count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(1312, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 50);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbtimkiem.BackColor = System.Drawing.SystemColors.Window;
            this.txbtimkiem.BorderColor = System.Drawing.Color.MidnightBlue;
            this.txbtimkiem.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txbtimkiem.BorderRadius = 5;
            this.txbtimkiem.BorderSize = 2;
            this.txbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtimkiem.ForeColor = System.Drawing.Color.Gray;
            this.txbtimkiem.Location = new System.Drawing.Point(232, 28);
            this.txbtimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.txbtimkiem.Multiline = false;
            this.txbtimkiem.Name = "txbtimkiem";
            this.txbtimkiem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbtimkiem.PasswordChar = false;
            this.txbtimkiem.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbtimkiem.PlaceholderText = "";
            this.txbtimkiem.Size = new System.Drawing.Size(299, 31);
            this.txbtimkiem.TabIndex = 25;
            this.txbtimkiem.Texts = "";
            this.txbtimkiem.UnderlinedStyle = false;
            this.txbtimkiem._TextChanged += new System.EventHandler(this.txbtimkiem__TextChanged);
            this.txbtimkiem.Enter += new System.EventHandler(this.txbtimkiem_Enter);
            // 
            // btnLock
            // 
            this.btnLock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLock.BackColor = System.Drawing.Color.DarkRed;
            this.btnLock.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnLock.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLock.BorderRadius = 10;
            this.btnLock.BorderSize = 0;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLock.ForeColor = System.Drawing.Color.White;
            this.btnLock.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.Image")));
            this.btnLock.Location = new System.Drawing.Point(1224, 18);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(71, 50);
            this.btnLock.TabIndex = 27;
            this.btnLock.Text = "  Lock";
            this.btnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLock.TextColor = System.Drawing.Color.White;
            this.btnLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLock.UseVisualStyleBackColor = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnOpenLock
            // 
            this.btnOpenLock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOpenLock.BackColor = System.Drawing.Color.DarkGreen;
            this.btnOpenLock.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.btnOpenLock.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpenLock.BorderRadius = 10;
            this.btnOpenLock.BorderSize = 0;
            this.btnOpenLock.FlatAppearance.BorderSize = 0;
            this.btnOpenLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLock.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLock.ForeColor = System.Drawing.Color.White;
            this.btnOpenLock.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLock.Image")));
            this.btnOpenLock.Location = new System.Drawing.Point(1131, 18);
            this.btnOpenLock.Name = "btnOpenLock";
            this.btnOpenLock.Size = new System.Drawing.Size(87, 50);
            this.btnOpenLock.TabIndex = 27;
            this.btnOpenLock.Text = "  Unlock";
            this.btnOpenLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenLock.TextColor = System.Drawing.Color.White;
            this.btnOpenLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenLock.UseVisualStyleBackColor = false;
            this.btnOpenLock.Click += new System.EventHandler(this.btnOpenLock_Click);
            // 
            // cbbType1
            // 
            this.cbbType1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbType1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbbType1.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.cbbType1.BorderSize = 1;
            this.cbbType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbType1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cbbType1.IconColor = System.Drawing.Color.DarkSlateGray;
            this.cbbType1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.cbbType1.ListTextColor = System.Drawing.Color.White;
            this.cbbType1.Location = new System.Drawing.Point(12, 28);
            this.cbbType1.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbType1.Name = "cbbType1";
            this.cbbType1.Padding = new System.Windows.Forms.Padding(1);
            this.cbbType1.Size = new System.Drawing.Size(200, 30);
            this.cbbType1.TabIndex = 24;
            this.cbbType1.Texts = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Search by :";
            // 
            // frmQuanLyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmQuanLyUser";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmEventBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookSV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RJButton btnLock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJTextBox txbPass;
        private CustomControls.RJControls.RJTextBox txbQuyen;
        private CustomControls.RJControls.RJTextBox txbUserName;
        private CustomControls.RJControls.RJTextBox txbFullName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJButton btnOpenLock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvBookSV;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.RJControls.RJTextBox txbtimkiem;
        private UC_Combobox.RJComboBox cbbType1;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJButton btnCreatAcount;
        private CustomControls.RJControls.RJButton btnEdit;
        private CustomControls.RJControls.RJTextBox txbUserID;
        private CustomControls.RJControls.RJButton btnDelete;
        private System.Windows.Forms.PictureBox picLock;
        private CustomControls.RJControls.RJButton btnListDelete;
        private System.Windows.Forms.Label lblCount;
        private CustomControls.RJControls.RJButton btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessPermission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLock;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    }
}