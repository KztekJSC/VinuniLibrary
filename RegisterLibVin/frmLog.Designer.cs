namespace RegisterLibVin
{
    partial class frmLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Page = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.dtpFrom = new CustomControls.RJControls.RJDatePicker();
            this.dtpTo = new CustomControls.RJControls.RJDatePicker();
            this.btnTimKiem = new CustomControls.RJControls.RJButton();
            this.txbTimKiem = new CustomControls.RJControls.RJTextBox();
            this.cbbType1 = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 479);
            this.panel1.TabIndex = 174;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvLog);
            this.panel2.Location = new System.Drawing.Point(12, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 457);
            this.panel2.TabIndex = 1;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.UserName,
            this.Page,
            this.Description,
            this.PCName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(1033, 457);
            this.dgvLog.TabIndex = 161;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "DateTime";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 200;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "UserName";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Page
            // 
            this.Page.DataPropertyName = "Page";
            this.Page.HeaderText = "Page";
            this.Page.Name = "Page";
            this.Page.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // PCName
            // 
            this.PCName.DataPropertyName = "PCName";
            this.PCName.HeaderText = "PC Name";
            this.PCName.Name = "PCName";
            this.PCName.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCount);
            this.panel3.Controls.Add(this.dtpFrom);
            this.panel3.Controls.Add(this.dtpTo);
            this.panel3.Controls.Add(this.btnTimKiem);
            this.panel3.Controls.Add(this.txbTimKiem);
            this.panel3.Controls.Add(this.cbbType1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblTo);
            this.panel3.Controls.Add(this.lblFrom);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1057, 209);
            this.panel3.TabIndex = 175;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(12, 150);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 17);
            this.lblCount.TabIndex = 184;
            this.lblCount.Text = "Count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Visible = false;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFrom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpFrom.BorderSize = 0;
            this.dtpFrom.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(272, 113);
            this.dtpFrom.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 35);
            this.dtpFrom.SkinColor = System.Drawing.Color.Olive;
            this.dtpFrom.TabIndex = 182;
            this.dtpFrom.TextColor = System.Drawing.Color.White;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpTo.BorderSize = 0;
            this.dtpTo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(532, 113);
            this.dtpTo.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 35);
            this.dtpTo.SkinColor = System.Drawing.Color.Olive;
            this.dtpTo.TabIndex = 183;
            this.dtpTo.TextColor = System.Drawing.Color.White;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.BorderSize = 2;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(760, 150);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(106, 50);
            this.btnTimKiem.TabIndex = 181;
            this.btnTimKiem.Text = " Tìm kiếm";
            this.btnTimKiem.TextColor = System.Drawing.Color.Black;
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txbTimKiem
            // 
            this.txbTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTimKiem.BackColor = System.Drawing.SystemColors.Window;
            this.txbTimKiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txbTimKiem.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txbTimKiem.BorderRadius = 5;
            this.txbTimKiem.BorderSize = 2;
            this.txbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txbTimKiem.Location = new System.Drawing.Point(14, 169);
            this.txbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txbTimKiem.Multiline = false;
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txbTimKiem.PasswordChar = false;
            this.txbTimKiem.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txbTimKiem.PlaceholderText = "";
            this.txbTimKiem.Size = new System.Drawing.Size(718, 31);
            this.txbTimKiem.TabIndex = 180;
            this.txbTimKiem.Texts = "";
            this.txbTimKiem.UnderlinedStyle = false;
            this.txbTimKiem.Enter += new System.EventHandler(this.txbTimKiem_Enter);
            // 
            // cbbType1
            // 
            this.cbbType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbbType1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbbType1.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.cbbType1.BorderSize = 1;
            this.cbbType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbbType1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cbbType1.IconColor = System.Drawing.Color.DarkSlateGray;
            this.cbbType1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(116)))), ((int)(((byte)(197)))));
            this.cbbType1.ListTextColor = System.Drawing.Color.White;
            this.cbbType1.Location = new System.Drawing.Point(14, 113);
            this.cbbType1.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbType1.Name = "cbbType1";
            this.cbbType1.Padding = new System.Windows.Forms.Padding(1);
            this.cbbType1.Size = new System.Drawing.Size(200, 30);
            this.cbbType1.TabIndex = 179;
            this.cbbType1.Texts = "";
            this.cbbType1.OnSelectedIndexChanged += new System.EventHandler(this.cbbType1_OnSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 32);
            this.label1.TabIndex = 175;
            this.label1.Text = "Log File";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(505, 118);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 21);
            this.lblTo.TabIndex = 176;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(221, 118);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(52, 21);
            this.lblFrom.TabIndex = 177;
            this.lblFrom.Text = "From:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 178;
            this.label2.Text = "Search by:";
            // 
            // frmLog
            // 
            this.AcceptButton = this.btnTimKiem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmLog";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.RJControls.RJDatePicker dtpFrom;
        private CustomControls.RJControls.RJDatePicker dtpTo;
        private CustomControls.RJControls.RJButton btnTimKiem;
        private CustomControls.RJControls.RJTextBox txbTimKiem;
        private UC_Combobox.RJComboBox cbbType1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Page;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCName;
    }
}