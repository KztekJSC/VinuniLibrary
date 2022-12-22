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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpenLock = new CustomControls.RJControls.RJButton();
            this.btnLock = new CustomControls.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txbPass = new CustomControls.RJControls.RJTextBox();
            this.txbQuyen = new CustomControls.RJControls.RJTextBox();
            this.txbUserName = new CustomControls.RJControls.RJTextBox();
            this.txbFullName = new CustomControls.RJControls.RJTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvBookSV = new System.Windows.Forms.DataGridView();
            this.txbtimkiem = new CustomControls.RJControls.RJTextBox();
            this.cbbType1 = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookSV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(497, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Quản lý tài khoản";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnOpenLock);
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txbPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbQuyen);
            this.panel1.Controls.Add(this.txbUserName);
            this.panel1.Controls.Add(this.txbFullName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 319);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(752, 235);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpenLock
            // 
            this.btnOpenLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenLock.BackColor = System.Drawing.Color.DarkGreen;
            this.btnOpenLock.BackgroundColor = System.Drawing.Color.DarkGreen;
            this.btnOpenLock.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpenLock.BorderRadius = 10;
            this.btnOpenLock.BorderSize = 0;
            this.btnOpenLock.FlatAppearance.BorderSize = 0;
            this.btnOpenLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLock.ForeColor = System.Drawing.Color.White;
            this.btnOpenLock.Location = new System.Drawing.Point(478, 230);
            this.btnOpenLock.Name = "btnOpenLock";
            this.btnOpenLock.Size = new System.Drawing.Size(111, 40);
            this.btnOpenLock.TabIndex = 27;
            this.btnOpenLock.Text = "Mở tài khoản";
            this.btnOpenLock.TextColor = System.Drawing.Color.White;
            this.btnOpenLock.UseVisualStyleBackColor = false;
            this.btnOpenLock.Click += new System.EventHandler(this.btnOpenLock_Click);
            // 
            // btnLock
            // 
            this.btnLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLock.BackColor = System.Drawing.Color.DarkRed;
            this.btnLock.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btnLock.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLock.BorderRadius = 10;
            this.btnLock.BorderSize = 0;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.ForeColor = System.Drawing.Color.White;
            this.btnLock.Location = new System.Drawing.Point(781, 230);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(111, 40);
            this.btnLock.TabIndex = 27;
            this.btnLock.Text = "Khóa tài khoản";
            this.btnLock.TextColor = System.Drawing.Color.White;
            this.btnLock.UseVisualStyleBackColor = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(193, 114);
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
            this.txbPass.Location = new System.Drawing.Point(694, 124);
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
            this.txbQuyen.Location = new System.Drawing.Point(694, 185);
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
            this.txbUserName.Location = new System.Drawing.Point(391, 185);
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
            this.txbFullName.Location = new System.Drawing.Point(391, 124);
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
            this.label6.Location = new System.Drawing.Point(691, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Quyền quản trị";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(691, 103);
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
            this.label4.Location = new System.Drawing.Point(394, 168);
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
            this.label3.Location = new System.Drawing.Point(394, 103);
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
            this.panel2.Location = new System.Drawing.Point(0, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1043, 292);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txbtimkiem);
            this.panel3.Controls.Add(this.cbbType1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1043, 73);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dgvBookSV);
            this.panel4.Location = new System.Drawing.Point(12, 79);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1019, 201);
            this.panel4.TabIndex = 1;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // dgvBookSV
            // 
            this.dgvBookSV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.IsLock});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookSV.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookSV.Location = new System.Drawing.Point(0, 0);
            this.dgvBookSV.Name = "dgvBookSV";
            this.dgvBookSV.ReadOnly = true;
            this.dgvBookSV.RowHeadersVisible = false;
            this.dgvBookSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookSV.Size = new System.Drawing.Size(1019, 201);
            this.dgvBookSV.TabIndex = 20;
            this.dgvBookSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookSV_CellContentClick);
            // 
            // txbtimkiem
            // 
            this.txbtimkiem.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbtimkiem.BackColor = System.Drawing.SystemColors.Window;
            this.txbtimkiem.BorderColor = System.Drawing.Color.MidnightBlue;
            this.txbtimkiem.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbtimkiem.BorderRadius = 5;
            this.txbtimkiem.BorderSize = 2;
            this.txbtimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbtimkiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tìm kiếm theo";
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
            this.AccessPermission.HeaderText = "Quyền quản trị";
            this.AccessPermission.Name = "AccessPermission";
            this.AccessPermission.ReadOnly = true;
            this.AccessPermission.Width = 200;
            // 
            // IsLock
            // 
            this.IsLock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsLock.DataPropertyName = "IsLock";
            this.IsLock.HeaderText = "Khóa tài khoản";
            this.IsLock.Name = "IsLock";
            this.IsLock.ReadOnly = true;
            this.IsLock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 17);
            this.label7.TabIndex = 151;
            this.label7.Text = "Nhập thông tin tìm kiếm";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // frmQuanLyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmQuanLyUser";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmEventBook_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookSV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessPermission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLock;
        private System.Windows.Forms.Label label7;
    }
}