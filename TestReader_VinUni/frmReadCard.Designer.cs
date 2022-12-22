
namespace TestReader_VinUni
{
    partial class frmReadCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadCard));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxCOM_QR = new System.Windows.Forms.ComboBox();
            this.cbxCOM_Card = new System.Windows.Forms.ComboBox();
            this.cbxCOM_Output = new System.Windows.Forms.ComboBox();
            this.lstReceivedMessage = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblQuetThe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbOther = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPhone = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txbHoTen = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbGmail = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txbCardID = new System.Windows.Forms.TextBox();
            this.txbKhoa = new System.Windows.Forms.TextBox();
            this.txbMSV = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHalt = new System.Windows.Forms.Button();
            this.picTrue = new System.Windows.Forms.PictureBox();
            this.picFalse = new System.Windows.Forms.PictureBox();
            this.lblStatusCard = new System.Windows.Forms.Label();
            this.lblThongbao = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerStartup = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFalse)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "QR Reader:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Card Reader:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output:";
            // 
            // cbxCOM_QR
            // 
            this.cbxCOM_QR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCOM_QR.FormattingEnabled = true;
            this.cbxCOM_QR.Location = new System.Drawing.Point(107, 15);
            this.cbxCOM_QR.Name = "cbxCOM_QR";
            this.cbxCOM_QR.Size = new System.Drawing.Size(121, 23);
            this.cbxCOM_QR.TabIndex = 3;
            // 
            // cbxCOM_Card
            // 
            this.cbxCOM_Card.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCOM_Card.FormattingEnabled = true;
            this.cbxCOM_Card.Location = new System.Drawing.Point(107, 50);
            this.cbxCOM_Card.Name = "cbxCOM_Card";
            this.cbxCOM_Card.Size = new System.Drawing.Size(121, 23);
            this.cbxCOM_Card.TabIndex = 4;
            // 
            // cbxCOM_Output
            // 
            this.cbxCOM_Output.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCOM_Output.FormattingEnabled = true;
            this.cbxCOM_Output.Location = new System.Drawing.Point(107, 90);
            this.cbxCOM_Output.Name = "cbxCOM_Output";
            this.cbxCOM_Output.Size = new System.Drawing.Size(121, 23);
            this.cbxCOM_Output.TabIndex = 5;
            // 
            // lstReceivedMessage
            // 
            this.lstReceivedMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReceivedMessage.FormattingEnabled = true;
            this.lstReceivedMessage.HorizontalScrollbar = true;
            this.lstReceivedMessage.ItemHeight = 15;
            this.lstReceivedMessage.Location = new System.Drawing.Point(12, 135);
            this.lstReceivedMessage.Name = "lstReceivedMessage";
            this.lstReceivedMessage.Size = new System.Drawing.Size(327, 214);
            this.lstReceivedMessage.TabIndex = 36;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(255, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(84, 23);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(255, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(84, 23);
            this.btnStop.TabIndex = 38;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(12, 352);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(74, 15);
            this.lblDevice.TabIndex = 53;
            this.lblDevice.Text = "NameDevice";
            // 
            // lblQuetThe
            // 
            this.lblQuetThe.AutoSize = true;
            this.lblQuetThe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.lblQuetThe.ForeColor = System.Drawing.Color.White;
            this.lblQuetThe.Location = new System.Drawing.Point(281, 369);
            this.lblQuetThe.Name = "lblQuetThe";
            this.lblQuetThe.Size = new System.Drawing.Size(75, 15);
            this.lblQuetThe.TabIndex = 57;
            this.lblQuetThe.Text = "Mời quẹt thẻ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(392, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 305);
            this.panel1.TabIndex = 117;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbOther);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbPhone);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txbHoTen);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txbGmail);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txbCardID);
            this.groupBox2.Controls.Add(this.txbKhoa);
            this.groupBox2.Controls.Add(this.txbMSV);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 305);
            this.groupBox2.TabIndex = 112;
            this.groupBox2.TabStop = false;
            // 
            // txbOther
            // 
            this.txbOther.Location = new System.Drawing.Point(93, 277);
            this.txbOther.Name = "txbOther";
            this.txbOther.Size = new System.Drawing.Size(205, 23);
            this.txbOther.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 14);
            this.label4.TabIndex = 70;
            this.label4.Text = "Card ID";
            // 
            // txbPhone
            // 
            this.txbPhone.Location = new System.Drawing.Point(93, 237);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Size = new System.Drawing.Size(205, 23);
            this.txbPhone.TabIndex = 4;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(40, 237);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 14);
            this.label22.TabIndex = 70;
            this.label22.Text = "Phone";
            // 
            // txbHoTen
            // 
            this.txbHoTen.Location = new System.Drawing.Point(93, 65);
            this.txbHoTen.Name = "txbHoTen";
            this.txbHoTen.Size = new System.Drawing.Size(205, 23);
            this.txbHoTen.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(23, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 14);
            this.label18.TabIndex = 70;
            this.label18.Text = "Full Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 14);
            this.label5.TabIndex = 70;
            this.label5.Text = "Other";
            // 
            // txbGmail
            // 
            this.txbGmail.Location = new System.Drawing.Point(93, 194);
            this.txbGmail.Name = "txbGmail";
            this.txbGmail.Size = new System.Drawing.Size(205, 23);
            this.txbGmail.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(43, 194);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 14);
            this.label21.TabIndex = 70;
            this.label21.Text = "Gmail";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(43, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 14);
            this.label19.TabIndex = 70;
            this.label19.Text = "MSSV";
            // 
            // txbCardID
            // 
            this.txbCardID.BackColor = System.Drawing.Color.White;
            this.txbCardID.Enabled = false;
            this.txbCardID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCardID.ForeColor = System.Drawing.Color.Black;
            this.txbCardID.Location = new System.Drawing.Point(93, 20);
            this.txbCardID.Name = "txbCardID";
            this.txbCardID.ReadOnly = true;
            this.txbCardID.Size = new System.Drawing.Size(205, 23);
            this.txbCardID.TabIndex = 75;
            // 
            // txbKhoa
            // 
            this.txbKhoa.Location = new System.Drawing.Point(93, 151);
            this.txbKhoa.Name = "txbKhoa";
            this.txbKhoa.Size = new System.Drawing.Size(205, 23);
            this.txbKhoa.TabIndex = 2;
            // 
            // txbMSV
            // 
            this.txbMSV.Location = new System.Drawing.Point(93, 108);
            this.txbMSV.Name = "txbMSV";
            this.txbMSV.Size = new System.Drawing.Size(205, 23);
            this.txbMSV.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(45, 151);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 14);
            this.label20.TabIndex = 70;
            this.label20.Text = "Khóa";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Silver;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(904, 296);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 35);
            this.btnClear.TabIndex = 114;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHalt
            // 
            this.btnHalt.BackColor = System.Drawing.Color.Gray;
            this.btnHalt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHalt.ForeColor = System.Drawing.Color.White;
            this.btnHalt.Location = new System.Drawing.Point(810, 296);
            this.btnHalt.Name = "btnHalt";
            this.btnHalt.Size = new System.Drawing.Size(88, 35);
            this.btnHalt.TabIndex = 115;
            this.btnHalt.Text = "Reset";
            this.btnHalt.UseVisualStyleBackColor = false;
            this.btnHalt.Click += new System.EventHandler(this.btnHalt_Click_1);
            // 
            // picTrue
            // 
            this.picTrue.Image = ((System.Drawing.Image)(resources.GetObject("picTrue.Image")));
            this.picTrue.Location = new System.Drawing.Point(810, 47);
            this.picTrue.Name = "picTrue";
            this.picTrue.Size = new System.Drawing.Size(30, 44);
            this.picTrue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrue.TabIndex = 118;
            this.picTrue.TabStop = false;
            // 
            // picFalse
            // 
            this.picFalse.Image = ((System.Drawing.Image)(resources.GetObject("picFalse.Image")));
            this.picFalse.Location = new System.Drawing.Point(810, 47);
            this.picFalse.Name = "picFalse";
            this.picFalse.Size = new System.Drawing.Size(30, 44);
            this.picFalse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFalse.TabIndex = 119;
            this.picFalse.TabStop = false;
            // 
            // lblStatusCard
            // 
            this.lblStatusCard.AutoSize = true;
            this.lblStatusCard.Location = new System.Drawing.Point(824, 121);
            this.lblStatusCard.Name = "lblStatusCard";
            this.lblStatusCard.Size = new System.Drawing.Size(67, 15);
            this.lblStatusCard.TabIndex = 53;
            this.lblStatusCard.Text = "Status Card";
            // 
            // lblThongbao
            // 
            this.lblThongbao.AutoSize = true;
            this.lblThongbao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(73)))), ((int)(((byte)(85)))));
            this.lblThongbao.ForeColor = System.Drawing.Color.White;
            this.lblThongbao.Location = new System.Drawing.Point(281, 398);
            this.lblThongbao.Name = "lblThongbao";
            this.lblThongbao.Size = new System.Drawing.Size(75, 15);
            this.lblThongbao.TabIndex = 57;
            this.lblThongbao.Text = "Mời quẹt thẻ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerStartup
            // 
            this.timerStartup.Interval = 10000;
            this.timerStartup.Tick += new System.EventHandler(this.timerStartup_Tick);
            // 
            // frmReadCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 514);
            this.Controls.Add(this.picTrue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnHalt);
            this.Controls.Add(this.lblStatusCard);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.lblThongbao);
            this.Controls.Add(this.lblQuetThe);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lstReceivedMessage);
            this.Controls.Add(this.cbxCOM_Output);
            this.Controls.Add(this.cbxCOM_Card);
            this.Controls.Add(this.cbxCOM_QR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picFalse);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReadCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Reader - VinUni";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReadCard_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFalse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxCOM_QR;
        private System.Windows.Forms.ComboBox cbxCOM_Card;
        private System.Windows.Forms.ComboBox cbxCOM_Output;
        private System.Windows.Forms.ListBox lstReceivedMessage;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblQuetThe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbOther;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbPhone;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txbHoTen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbGmail;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txbCardID;
        private System.Windows.Forms.TextBox txbKhoa;
        private System.Windows.Forms.TextBox txbMSV;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHalt;
        private System.Windows.Forms.PictureBox picTrue;
        private System.Windows.Forms.PictureBox picFalse;
        private System.Windows.Forms.Label lblStatusCard;
        private System.Windows.Forms.Label lblThongbao;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerStartup;
    }
}

