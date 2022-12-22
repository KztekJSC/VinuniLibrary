namespace RegisterLibVin
{
    partial class frmAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDangKy = new CustomControls.RJControls.RJButton();
            this.txbPass2 = new CustomControls.RJControls.RJTextBox();
            this.txbPass = new CustomControls.RJControls.RJTextBox();
            this.txbAcount = new CustomControls.RJControls.RJTextBox();
            this.txbFullName = new CustomControls.RJControls.RJTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tgbtnCheckDefault = new CustomControls.RJControls.RJToggleButton();
            this.btnSaveExcel = new CustomControls.RJControls.RJButton();
            this.cbbColumnEnd = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.cbbRowEnd = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.cbbColumnStart = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.cbbRowHeader = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.cbbRowStart = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblkey = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSaveKey = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnSave = new CustomControls.RJControls.RJButton();
            this.btnPathBackup = new CustomControls.RJControls.RJButton();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblPCName = new System.Windows.Forms.Label();
            this.txbFolderShare = new CustomControls.RJControls.RJTextBox();
            this.txbPath = new CustomControls.RJControls.RJTextBox();
            this.txbNamePC = new CustomControls.RJControls.RJTextBox();
            this.btnTimKiem = new CustomControls.RJControls.RJButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Đăng ký Admin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDangKy);
            this.panel1.Controls.Add(this.txbPass2);
            this.panel1.Controls.Add(this.txbPass);
            this.panel1.Controls.Add(this.txbAcount);
            this.panel1.Controls.Add(this.txbFullName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 268);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(128, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Comfirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(179, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "UserName";
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDangKy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDangKy.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDangKy.BorderRadius = 0;
            this.btnDangKy.BorderSize = 0;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(514, 117);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(84, 70);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.TextColor = System.Drawing.Color.White;
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txbPass2
            // 
            this.txbPass2.BackColor = System.Drawing.SystemColors.Window;
            this.txbPass2.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.txbPass2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbPass2.BorderRadius = 5;
            this.txbPass2.BorderSize = 2;
            this.txbPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbPass2.Location = new System.Drawing.Point(257, 156);
            this.txbPass2.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass2.Multiline = false;
            this.txbPass2.Name = "txbPass2";
            this.txbPass2.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPass2.PasswordChar = true;
            this.txbPass2.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPass2.PlaceholderText = "";
            this.txbPass2.Size = new System.Drawing.Size(250, 31);
            this.txbPass2.TabIndex = 4;
            this.txbPass2.Texts = "";
            this.txbPass2.UnderlinedStyle = false;
            // 
            // txbPass
            // 
            this.txbPass.BackColor = System.Drawing.SystemColors.Window;
            this.txbPass.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.txbPass.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbPass.BorderRadius = 5;
            this.txbPass.BorderSize = 2;
            this.txbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbPass.Location = new System.Drawing.Point(257, 117);
            this.txbPass.Margin = new System.Windows.Forms.Padding(4);
            this.txbPass.Multiline = false;
            this.txbPass.Name = "txbPass";
            this.txbPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPass.PasswordChar = true;
            this.txbPass.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPass.PlaceholderText = "";
            this.txbPass.Size = new System.Drawing.Size(250, 31);
            this.txbPass.TabIndex = 3;
            this.txbPass.Texts = "";
            this.txbPass.UnderlinedStyle = false;
            // 
            // txbAcount
            // 
            this.txbAcount.BackColor = System.Drawing.SystemColors.Window;
            this.txbAcount.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.txbAcount.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbAcount.BorderRadius = 5;
            this.txbAcount.BorderSize = 2;
            this.txbAcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAcount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbAcount.Location = new System.Drawing.Point(257, 78);
            this.txbAcount.Margin = new System.Windows.Forms.Padding(4);
            this.txbAcount.Multiline = false;
            this.txbAcount.Name = "txbAcount";
            this.txbAcount.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbAcount.PasswordChar = false;
            this.txbAcount.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbAcount.PlaceholderText = "";
            this.txbAcount.Size = new System.Drawing.Size(250, 31);
            this.txbAcount.TabIndex = 2;
            this.txbAcount.Texts = "";
            this.txbAcount.UnderlinedStyle = false;
            // 
            // txbFullName
            // 
            this.txbFullName.BackColor = System.Drawing.SystemColors.Window;
            this.txbFullName.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.txbFullName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbFullName.BorderRadius = 5;
            this.txbFullName.BorderSize = 2;
            this.txbFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbFullName.Location = new System.Drawing.Point(257, 39);
            this.txbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.txbFullName.Multiline = false;
            this.txbFullName.Name = "txbFullName";
            this.txbFullName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbFullName.PasswordChar = false;
            this.txbFullName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbFullName.PlaceholderText = "";
            this.txbFullName.Size = new System.Drawing.Size(250, 31);
            this.txbFullName.TabIndex = 1;
            this.txbFullName.Texts = "";
            this.txbFullName.UnderlinedStyle = false;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(762, 71);
            this.panel4.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 54);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(762, 54);
            this.panel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(284, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Đăng ký tài khoản Admin";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.tgbtnCheckDefault);
            this.tabPage2.Controls.Add(this.btnSaveExcel);
            this.tabPage2.Controls.Add(this.cbbColumnEnd);
            this.tabPage2.Controls.Add(this.cbbRowEnd);
            this.tabPage2.Controls.Add(this.cbbColumnStart);
            this.tabPage2.Controls.Add(this.cbbRowHeader);
            this.tabPage2.Controls.Add(this.cbbRowStart);
            this.tabPage2.ImageIndex = 2;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import Excel";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(580, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "Custom";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(692, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Default";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(386, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "ColumnEnd";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "RowEnd";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(386, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "ColumnStart";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(52, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "RowHeader";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(59, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "RowStart";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(762, 57);
            this.panel5.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(306, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Excel import settings";
            // 
            // tgbtnCheckDefault
            // 
            this.tgbtnCheckDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tgbtnCheckDefault.AutoSize = true;
            this.tgbtnCheckDefault.Location = new System.Drawing.Point(641, 88);
            this.tgbtnCheckDefault.MinimumSize = new System.Drawing.Size(45, 22);
            this.tgbtnCheckDefault.Name = "tgbtnCheckDefault";
            this.tgbtnCheckDefault.OffBackColor = System.Drawing.Color.Gray;
            this.tgbtnCheckDefault.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.tgbtnCheckDefault.OnBackColor = System.Drawing.Color.Chocolate;
            this.tgbtnCheckDefault.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.tgbtnCheckDefault.Size = new System.Drawing.Size(45, 22);
            this.tgbtnCheckDefault.TabIndex = 16;
            this.tgbtnCheckDefault.UseVisualStyleBackColor = true;
            this.tgbtnCheckDefault.CheckedChanged += new System.EventHandler(this.tgbtnCheckDefault_CheckedChanged);
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.btnSaveExcel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.btnSaveExcel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSaveExcel.BorderRadius = 0;
            this.btnSaveExcel.BorderSize = 0;
            this.btnSaveExcel.FlatAppearance.BorderSize = 0;
            this.btnSaveExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveExcel.ForeColor = System.Drawing.Color.White;
            this.btnSaveExcel.Location = new System.Drawing.Point(606, 318);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(80, 45);
            this.btnSaveExcel.TabIndex = 14;
            this.btnSaveExcel.Text = "Save";
            this.btnSaveExcel.TextColor = System.Drawing.Color.White;
            this.btnSaveExcel.UseVisualStyleBackColor = false;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // cbbColumnEnd
            // 
            this.cbbColumnEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbColumnEnd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbColumnEnd.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbColumnEnd.BorderSize = 1;
            this.cbbColumnEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbColumnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbColumnEnd.ForeColor = System.Drawing.Color.DimGray;
            this.cbbColumnEnd.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbColumnEnd.Items.AddRange(new object[] {
            "ColumnEnd",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbbColumnEnd.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbColumnEnd.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbColumnEnd.Location = new System.Drawing.Point(486, 264);
            this.cbbColumnEnd.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbColumnEnd.Name = "cbbColumnEnd";
            this.cbbColumnEnd.Padding = new System.Windows.Forms.Padding(1);
            this.cbbColumnEnd.Size = new System.Drawing.Size(200, 30);
            this.cbbColumnEnd.TabIndex = 13;
            this.cbbColumnEnd.Texts = "";
            // 
            // cbbRowEnd
            // 
            this.cbbRowEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbRowEnd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbRowEnd.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbRowEnd.BorderSize = 1;
            this.cbbRowEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbRowEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbRowEnd.ForeColor = System.Drawing.Color.DimGray;
            this.cbbRowEnd.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbRowEnd.Items.AddRange(new object[] {
            "RowEnd",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbbRowEnd.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbRowEnd.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbRowEnd.Location = new System.Drawing.Point(152, 264);
            this.cbbRowEnd.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbRowEnd.Name = "cbbRowEnd";
            this.cbbRowEnd.Padding = new System.Windows.Forms.Padding(1);
            this.cbbRowEnd.Size = new System.Drawing.Size(200, 30);
            this.cbbRowEnd.TabIndex = 13;
            this.cbbRowEnd.Texts = "";
            // 
            // cbbColumnStart
            // 
            this.cbbColumnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbColumnStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbColumnStart.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbColumnStart.BorderSize = 1;
            this.cbbColumnStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbColumnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbColumnStart.ForeColor = System.Drawing.Color.DimGray;
            this.cbbColumnStart.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbColumnStart.Items.AddRange(new object[] {
            "ColumnStart",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbbColumnStart.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbColumnStart.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbColumnStart.Location = new System.Drawing.Point(486, 214);
            this.cbbColumnStart.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbColumnStart.Name = "cbbColumnStart";
            this.cbbColumnStart.Padding = new System.Windows.Forms.Padding(1);
            this.cbbColumnStart.Size = new System.Drawing.Size(200, 30);
            this.cbbColumnStart.TabIndex = 13;
            this.cbbColumnStart.Texts = "";
            // 
            // cbbRowHeader
            // 
            this.cbbRowHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbRowHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbRowHeader.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbRowHeader.BorderSize = 1;
            this.cbbRowHeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbRowHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbRowHeader.ForeColor = System.Drawing.Color.DimGray;
            this.cbbRowHeader.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbRowHeader.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbbRowHeader.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbRowHeader.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbRowHeader.Location = new System.Drawing.Point(152, 127);
            this.cbbRowHeader.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbRowHeader.Name = "cbbRowHeader";
            this.cbbRowHeader.Padding = new System.Windows.Forms.Padding(1);
            this.cbbRowHeader.Size = new System.Drawing.Size(200, 30);
            this.cbbRowHeader.TabIndex = 13;
            this.cbbRowHeader.Texts = "";
            // 
            // cbbRowStart
            // 
            this.cbbRowStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbRowStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbRowStart.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbRowStart.BorderSize = 1;
            this.cbbRowStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbRowStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbRowStart.ForeColor = System.Drawing.Color.DimGray;
            this.cbbRowStart.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbRowStart.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbbRowStart.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbRowStart.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbRowStart.Location = new System.Drawing.Point(152, 214);
            this.cbbRowStart.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbRowStart.Name = "cbbRowStart";
            this.cbbRowStart.Padding = new System.Windows.Forms.Padding(1);
            this.cbbRowStart.Size = new System.Drawing.Size(200, 30);
            this.cbbRowStart.TabIndex = 13;
            this.cbbRowStart.Texts = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.txbKey);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.btnSaveKey);
            this.tabPage3.Controls.Add(this.iconButton1);
            this.tabPage3.ImageKey = "key_30px.png";
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 399);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Quản lý Key";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblkey, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 361);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 35);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // lblkey
            // 
            this.lblkey.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblkey.AutoSize = true;
            this.lblkey.Location = new System.Drawing.Point(3, 11);
            this.lblkey.Name = "lblkey";
            this.lblkey.Size = new System.Drawing.Size(25, 13);
            this.lblkey.TabIndex = 0;
            this.lblkey.Text = "Key";
            this.lblkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(305, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 25);
            this.label14.TabIndex = 22;
            this.label14.Text = "Key management";
            // 
            // txbKey
            // 
            this.txbKey.Location = new System.Drawing.Point(251, 148);
            this.txbKey.Multiline = true;
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(257, 30);
            this.txbKey.TabIndex = 18;
            this.txbKey.Text = "FF FF FF FF FF FF";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(200, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 21);
            this.label15.TabIndex = 21;
            this.label15.Text = "Key";
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.btnSaveKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveKey.ForeColor = System.Drawing.Color.White;
            this.btnSaveKey.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnSaveKey.IconColor = System.Drawing.Color.White;
            this.btnSaveKey.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSaveKey.IconSize = 30;
            this.btnSaveKey.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSaveKey.Location = new System.Drawing.Point(251, 203);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(119, 45);
            this.btnSaveKey.TabIndex = 19;
            this.btnSaveKey.Text = "Write Key";
            this.btnSaveKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveKey.UseVisualStyleBackColor = false;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(44)))));
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.HourglassEnd;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.iconButton1.Location = new System.Drawing.Point(415, 203);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(93, 45);
            this.iconButton1.TabIndex = 20;
            this.iconButton1.Text = "Load";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnSave);
            this.tabPage4.Controls.Add(this.btnPathBackup);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.lblPCName);
            this.tabPage4.Controls.Add(this.txbFolderShare);
            this.tabPage4.Controls.Add(this.txbPath);
            this.tabPage4.Controls.Add(this.txbNamePC);
            this.tabPage4.Controls.Add(this.btnTimKiem);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 399);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Chọn máy chủ";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderSize = 2;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(345, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 50);
            this.btnSave.TabIndex = 163;
            this.btnSave.Text = "Save PC Server";
            this.btnSave.TextColor = System.Drawing.Color.Black;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPathBackup
            // 
            this.btnPathBackup.AutoSize = true;
            this.btnPathBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPathBackup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPathBackup.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnPathBackup.BorderRadius = 10;
            this.btnPathBackup.BorderSize = 2;
            this.btnPathBackup.FlatAppearance.BorderSize = 0;
            this.btnPathBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPathBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathBackup.ForeColor = System.Drawing.Color.Black;
            this.btnPathBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnPathBackup.Image")));
            this.btnPathBackup.Location = new System.Drawing.Point(568, 176);
            this.btnPathBackup.Name = "btnPathBackup";
            this.btnPathBackup.Size = new System.Drawing.Size(160, 50);
            this.btnPathBackup.TabIndex = 163;
            this.btnPathBackup.Text = "Get Path backup";
            this.btnPathBackup.TextColor = System.Drawing.Color.Black;
            this.btnPathBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPathBackup.UseVisualStyleBackColor = false;
            this.btnPathBackup.Click += new System.EventHandler(this.btnPathBackup_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(16, 275);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(227, 21);
            this.label18.TabIndex = 162;
            this.label18.Text = "NameFolderShare máy Server";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(110, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 21);
            this.label17.TabIndex = 162;
            this.label17.Text = "Path máy Server";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(76, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 21);
            this.label16.TabIndex = 162;
            this.label16.Text = "PC Name máy Server";
            // 
            // lblPCName
            // 
            this.lblPCName.AutoSize = true;
            this.lblPCName.Location = new System.Drawing.Point(6, 377);
            this.lblPCName.Name = "lblPCName";
            this.lblPCName.Size = new System.Drawing.Size(49, 13);
            this.lblPCName.TabIndex = 162;
            this.lblPCName.Text = "NamePC";
            // 
            // txbFolderShare
            // 
            this.txbFolderShare.BackColor = System.Drawing.SystemColors.Window;
            this.txbFolderShare.BorderColor = System.Drawing.Color.DarkBlue;
            this.txbFolderShare.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbFolderShare.BorderRadius = 0;
            this.txbFolderShare.BorderSize = 2;
            this.txbFolderShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFolderShare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbFolderShare.Location = new System.Drawing.Point(250, 265);
            this.txbFolderShare.Margin = new System.Windows.Forms.Padding(4);
            this.txbFolderShare.Multiline = false;
            this.txbFolderShare.Name = "txbFolderShare";
            this.txbFolderShare.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbFolderShare.PasswordChar = false;
            this.txbFolderShare.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbFolderShare.PlaceholderText = "";
            this.txbFolderShare.Size = new System.Drawing.Size(297, 31);
            this.txbFolderShare.TabIndex = 161;
            this.txbFolderShare.Texts = "";
            this.txbFolderShare.UnderlinedStyle = true;
            // 
            // txbPath
            // 
            this.txbPath.BackColor = System.Drawing.SystemColors.Window;
            this.txbPath.BorderColor = System.Drawing.Color.DarkBlue;
            this.txbPath.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbPath.BorderRadius = 0;
            this.txbPath.BorderSize = 2;
            this.txbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbPath.Location = new System.Drawing.Point(250, 180);
            this.txbPath.Margin = new System.Windows.Forms.Padding(4);
            this.txbPath.Multiline = false;
            this.txbPath.Name = "txbPath";
            this.txbPath.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbPath.PasswordChar = false;
            this.txbPath.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbPath.PlaceholderText = "";
            this.txbPath.Size = new System.Drawing.Size(297, 31);
            this.txbPath.TabIndex = 161;
            this.txbPath.Texts = "";
            this.txbPath.UnderlinedStyle = true;
            // 
            // txbNamePC
            // 
            this.txbNamePC.BackColor = System.Drawing.SystemColors.Window;
            this.txbNamePC.BorderColor = System.Drawing.Color.DarkBlue;
            this.txbNamePC.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txbNamePC.BorderRadius = 0;
            this.txbNamePC.BorderSize = 2;
            this.txbNamePC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNamePC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txbNamePC.Location = new System.Drawing.Point(250, 90);
            this.txbNamePC.Margin = new System.Windows.Forms.Padding(4);
            this.txbNamePC.Multiline = false;
            this.txbNamePC.Name = "txbNamePC";
            this.txbNamePC.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbNamePC.PasswordChar = false;
            this.txbNamePC.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbNamePC.PlaceholderText = "";
            this.txbNamePC.Size = new System.Drawing.Size(297, 31);
            this.txbNamePC.TabIndex = 161;
            this.txbNamePC.Texts = "";
            this.txbNamePC.UnderlinedStyle = true;
            this.txbNamePC._TextChanged += new System.EventHandler(this.txbNamePC__TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 2;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(568, 86);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(160, 50);
            this.btnTimKiem.TabIndex = 160;
            this.btnTimKiem.Text = "Get PCName";
            this.btnTimKiem.TextColor = System.Drawing.Color.Black;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sdfsf.png");
            this.imageList1.Images.SetKeyName(1, "key_30px.png");
            this.imageList1.Images.SetKeyName(2, "maintenance_30px.png");
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config Admin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJButton btnDangKy;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txbPass2;
        private CustomControls.RJControls.RJTextBox txbPass;
        private CustomControls.RJControls.RJTextBox txbAcount;
        private CustomControls.RJControls.RJTextBox txbFullName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private UC_Combobox.RJComboBox cbbColumnEnd;
        private System.Windows.Forms.Label label11;
        private UC_Combobox.RJComboBox cbbRowEnd;
        private UC_Combobox.RJComboBox cbbColumnStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private UC_Combobox.RJComboBox cbbRowStart;
        private System.Windows.Forms.Label label8;
        private CustomControls.RJControls.RJButton btnSaveExcel;
        private UC_Combobox.RJComboBox cbbRowHeader;
        private System.Windows.Forms.Label label12;
        private CustomControls.RJControls.RJToggleButton tgbtnCheckDefault;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.Label label15;
        private FontAwesome.Sharp.IconButton btnSaveKey;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblkey;
        private System.Windows.Forms.TabPage tabPage4;
        private CustomControls.RJControls.RJTextBox txbNamePC;
        private CustomControls.RJControls.RJButton btnTimKiem;
        private System.Windows.Forms.Label lblPCName;
        private CustomControls.RJControls.RJButton btnPathBackup;
        private CustomControls.RJControls.RJTextBox txbPath;
        private CustomControls.RJControls.RJButton btnSave;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private CustomControls.RJControls.RJTextBox txbFolderShare;
    }
}