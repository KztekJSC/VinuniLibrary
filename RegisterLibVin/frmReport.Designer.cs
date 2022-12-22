namespace RegisterLibVin
{
    partial class frmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.lblYear1 = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblYear2 = new System.Windows.Forms.Label();
            this.dtpFrom = new CustomControls.RJControls.RJDatePicker();
            this.dtpTo = new CustomControls.RJControls.RJDatePicker();
            this.cbbMonth = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.cbbYear2 = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.cbbYear1 = new RegisterLibVin.UC_Combobox.RJComboBox();
            this.rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            this.btnExport = new CustomControls.RJControls.RJButton();
            this.btnPeriod = new CustomControls.RJControls.RJButton();
            this.btnYear = new CustomControls.RJControls.RJButton();
            this.btnMonth = new CustomControls.RJControls.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReport = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblYear1
            // 
            this.lblYear1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYear1.AutoSize = true;
            this.lblYear1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear1.Location = new System.Drawing.Point(34, 327);
            this.lblYear1.Name = "lblYear1";
            this.lblYear1.Size = new System.Drawing.Size(46, 21);
            this.lblYear1.TabIndex = 172;
            this.lblYear1.Text = "Year:";
            this.lblYear1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblMonth
            // 
            this.lblMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(17, 387);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(63, 21);
            this.lblMonth.TabIndex = 172;
            this.lblMonth.Text = "Month:";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(730, 362);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 17);
            this.lblTo.TabIndex = 175;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(728, 310);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(43, 17);
            this.lblFrom.TabIndex = 176;
            this.lblFrom.Text = "From:";
            // 
            // lblYear2
            // 
            this.lblYear2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblYear2.AutoSize = true;
            this.lblYear2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear2.Location = new System.Drawing.Point(362, 327);
            this.lblYear2.Name = "lblYear2";
            this.lblYear2.Size = new System.Drawing.Size(46, 21);
            this.lblYear2.TabIndex = 172;
            this.lblYear2.Text = "Year:";
            this.lblYear2.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpFrom.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpFrom.BorderSize = 0;
            this.dtpFrom.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(730, 327);
            this.dtpFrom.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 35);
            this.dtpFrom.SkinColor = System.Drawing.Color.Olive;
            this.dtpFrom.TabIndex = 173;
            this.dtpFrom.TextColor = System.Drawing.Color.White;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTo.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpTo.BorderSize = 0;
            this.dtpTo.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(730, 379);
            this.dtpTo.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 35);
            this.dtpTo.SkinColor = System.Drawing.Color.Olive;
            this.dtpTo.TabIndex = 174;
            this.dtpTo.TextColor = System.Drawing.Color.White;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // cbbMonth
            // 
            this.cbbMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbMonth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbMonth.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbMonth.BorderSize = 1;
            this.cbbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMonth.ForeColor = System.Drawing.Color.DimGray;
            this.cbbMonth.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbMonth.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbMonth.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbMonth.Location = new System.Drawing.Point(93, 378);
            this.cbbMonth.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbMonth.Name = "cbbMonth";
            this.cbbMonth.Padding = new System.Windows.Forms.Padding(1);
            this.cbbMonth.Size = new System.Drawing.Size(200, 30);
            this.cbbMonth.TabIndex = 171;
            this.cbbMonth.Texts = "";
            this.cbbMonth.Load += new System.EventHandler(this.cbbMonth_Load_1);
            // 
            // cbbYear2
            // 
            this.cbbYear2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbYear2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbYear2.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbYear2.BorderSize = 1;
            this.cbbYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbYear2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbYear2.ForeColor = System.Drawing.Color.DimGray;
            this.cbbYear2.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbYear2.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbYear2.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbYear2.Location = new System.Drawing.Point(414, 327);
            this.cbbYear2.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbYear2.Name = "cbbYear2";
            this.cbbYear2.Padding = new System.Windows.Forms.Padding(1);
            this.cbbYear2.Size = new System.Drawing.Size(200, 30);
            this.cbbYear2.TabIndex = 171;
            this.cbbYear2.Texts = "";
            // 
            // cbbYear1
            // 
            this.cbbYear1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbYear1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbYear1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbYear1.BorderSize = 1;
            this.cbbYear1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cbbYear1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbYear1.ForeColor = System.Drawing.Color.DimGray;
            this.cbbYear1.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.cbbYear1.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.cbbYear1.ListTextColor = System.Drawing.Color.DimGray;
            this.cbbYear1.Location = new System.Drawing.Point(93, 327);
            this.cbbYear1.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbbYear1.Name = "cbbYear1";
            this.cbbYear1.Padding = new System.Windows.Forms.Padding(1);
            this.cbbYear1.Size = new System.Drawing.Size(200, 30);
            this.cbbYear1.TabIndex = 171;
            this.cbbYear1.Texts = "";
            this.cbbYear1.Load += new System.EventHandler(this.cbbYear1_Load);
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rjTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.rjTextBox1.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.Enabled = false;
            this.rjTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjTextBox1.Location = new System.Drawing.Point(18, 197);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.Size = new System.Drawing.Size(956, 31);
            this.rjTextBox1.TabIndex = 170;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExport.BorderRadius = 10;
            this.btnExport.BorderSize = 2;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(438, 455);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(138, 50);
            this.btnExport.TabIndex = 168;
            this.btnExport.Text = " Print Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextColor = System.Drawing.Color.Black;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPeriod
            // 
            this.btnPeriod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPeriod.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPeriod.BackgroundColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPeriod.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPeriod.BorderRadius = 20;
            this.btnPeriod.BorderSize = 0;
            this.btnPeriod.FlatAppearance.BorderSize = 0;
            this.btnPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriod.ForeColor = System.Drawing.Color.White;
            this.btnPeriod.Image = ((System.Drawing.Image)(resources.GetObject("btnPeriod.Image")));
            this.btnPeriod.Location = new System.Drawing.Point(765, 70);
            this.btnPeriod.Name = "btnPeriod";
            this.btnPeriod.Size = new System.Drawing.Size(123, 120);
            this.btnPeriod.TabIndex = 0;
            this.btnPeriod.Text = "By time period";
            this.btnPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPeriod.TextColor = System.Drawing.Color.White;
            this.btnPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnPeriod.UseVisualStyleBackColor = false;
            this.btnPeriod.Click += new System.EventHandler(this.btnPeriod_Click);
            // 
            // btnYear
            // 
            this.btnYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnYear.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnYear.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.btnYear.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnYear.BorderRadius = 20;
            this.btnYear.BorderSize = 0;
            this.btnYear.FlatAppearance.BorderSize = 0;
            this.btnYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYear.ForeColor = System.Drawing.Color.White;
            this.btnYear.Image = ((System.Drawing.Image)(resources.GetObject("btnYear.Image")));
            this.btnYear.Location = new System.Drawing.Point(446, 70);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(123, 120);
            this.btnYear.TabIndex = 0;
            this.btnYear.Text = "Yearly";
            this.btnYear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnYear.TextColor = System.Drawing.Color.White;
            this.btnYear.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnYear.UseVisualStyleBackColor = false;
            this.btnYear.Click += new System.EventHandler(this.btnYear_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMonth.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnMonth.BackgroundColor = System.Drawing.Color.DarkOliveGreen;
            this.btnMonth.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnMonth.BorderRadius = 20;
            this.btnMonth.BorderSize = 0;
            this.btnMonth.FlatAppearance.BorderSize = 0;
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.ForeColor = System.Drawing.Color.White;
            this.btnMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnMonth.Image")));
            this.btnMonth.Location = new System.Drawing.Point(127, 70);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(123, 120);
            this.btnMonth.TabIndex = 0;
            this.btnMonth.Text = "Monthly";
            this.btnMonth.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMonth.TextColor = System.Drawing.Color.White;
            this.btnMonth.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnMonth.UseVisualStyleBackColor = false;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.lblReport);
            this.panel1.Location = new System.Drawing.Point(317, 235);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 34);
            this.panel1.TabIndex = 178;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblReport
            // 
            this.lblReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReport.AutoSize = true;
            this.lblReport.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(153, 9);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(70, 25);
            this.lblReport.TabIndex = 179;
            this.lblReport.Text = "Report";
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 508);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear2);
            this.Controls.Add(this.lblYear1);
            this.Controls.Add(this.cbbMonth);
            this.Controls.Add(this.cbbYear2);
            this.Controls.Add(this.cbbYear1);
            this.Controls.Add(this.rjTextBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPeriod);
            this.Controls.Add(this.btnYear);
            this.Controls.Add(this.btnMonth);
            this.Name = "frmReport";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJButton btnMonth;
        private CustomControls.RJControls.RJButton btnExport;
        private CustomControls.RJControls.RJButton btnYear;
        private CustomControls.RJControls.RJButton btnPeriod;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private UC_Combobox.RJComboBox cbbYear1;
        private UC_Combobox.RJComboBox cbbMonth;
        private UC_Combobox.RJComboBox cbbYear2;
        private System.Windows.Forms.Label lblYear1;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private CustomControls.RJControls.RJDatePicker dtpFrom;
        private CustomControls.RJControls.RJDatePicker dtpTo;
        private System.Windows.Forms.Label lblYear2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblReport;
    }
}