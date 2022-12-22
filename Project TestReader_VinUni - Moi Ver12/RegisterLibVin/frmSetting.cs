using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
            for (int i = 1; i < 100; i++)
            {
                cbxCOM_Card.Items.Add("COM" + i.ToString());
            }
            SerialPort port_Card = new SerialPort();
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CheckBoxUpdate == true)
            {
                ckbUpdate.Checked = true;
            }
            else
                ckbUpdate.Checked = false;
            cbxCOM_Card.Text = Properties.Settings.Default.NameCOM;
        }

        
        private int CountText(string textCount)
        {
            string str;
            int kitu, i, l;
            kitu = i = 0;
            str = textCount;
            l = str.Length;
            while (i < l)
            {
                if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z') || str[i] >= '0' && str[i] <= '9')
                {
                    kitu++;
                }
                else
                {
                    kitu++;
                }
                i++;
            }
            return kitu;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
        }

       
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            ShowCom();
            ShowCheckBox();
            RJMessageBox.Show("Lưu thành công!", "Notice", MessageBoxButtons.OKCancel);
        }

        private void ShowCheckBox()
        {
            if (ckbUpdate.Checked)
            {
                Properties.Settings.Default.CheckBoxUpdate = true;
                lblUpdate.Text = "Cho phép Update";
            }
            else
            {
                Properties.Settings.Default.CheckBoxUpdate = false;
                lblUpdate.Text = "Chưa được quyền Update";
            }
            Properties.Settings.Default.Save();
        }

        private void ShowCom()
        {
            if (cbxCOM_Card.Text != "")
            {
                Properties.Settings.Default.NameCOM = cbxCOM_Card.Text;
                Properties.Settings.Default.Save();
                lblCom.Text = Properties.Settings.Default.NameCOM;
                //lblCom.ForeColor = Color.Green;
            }
            else
            {
                RJMessageBox.Show("Mời chọn cổng COM!", "Notice", MessageBoxButtons.OKCancel);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
