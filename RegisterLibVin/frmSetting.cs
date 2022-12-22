using Credential_FolderShare;
using CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
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
            ConnectSQL.ConnectConfig();
            for (int i = 1; i < 100; i++)
            {
                cbxCOM_Card.Items.Add("COM" + i.ToString());
            }
            SerialPort port_Card = new SerialPort();
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            LoadComPort();

            LoadAllowData();

            LoadBackUp();

        }
        private void LoadComPort()
        {
            cbxCOM_Card.Text = Properties.Settings.Default.NameCOM;

        }
        private void LoadAllowData()
        {
            if (Properties.Settings.Default.CheckBoxUpdate == true)
            {
                ckbUpdate.Checked = true;
            }
            else
                ckbUpdate.Checked = false;
        }
        private void LoadBackUp()
        {
            txbPath.Texts = Properties.Settings.Default.PathBackup;
            string pcServer = Properties.Settings.Default.PCName;
            if (string.IsNullOrEmpty(pcServer))
            {
                MessageBox.Show("Chưa nhập tên máy chủ");
            }
            string pcNow = Environment.MachineName;
            if (pcNow != pcServer)
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
            lblStatus.Visible = false;
            lblTime.Visible = false;

            string pcName = Properties.Settings.Default.PCName;
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
            
        }

        private void ShowCheckBox()
        {
            if (ckbUpdate.Checked)
            {
                Properties.Settings.Default.CheckBoxUpdate = true;
                lblUpdate.Text = "Cho phép Update";
                LogHelper.LogUser("Page Setting", $"Người dùng bật cho phép ghi dữ liệu thành công", Application.StartupPath);

            }
            else
            {
                Properties.Settings.Default.CheckBoxUpdate = false;
                lblUpdate.Text = "Chưa được quyền Update";
                LogHelper.LogUser("Page Setting", $"Người dùng tắt cho phép ghi dữ liệu thành công", Application.StartupPath);

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

        

        private void btnSaveCom_Click(object sender, EventArgs e)
        {
            ShowCom();
            LogHelper.LogUser("Page Setting", $"Người dùng nhấn Save thành công: {cbxCOM_Card.Text}", Application.StartupPath);
            RJMessageBox.Show("Lưu thành công!", "Notice", MessageBoxButtons.OKCancel);
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            ShowCheckBox();

            RJMessageBox.Show("Lưu thành công!", "Notice", MessageBoxButtons.OKCancel);
        }

        private void btnBackUp_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            //txbNameBackup.Texts = "BackupVinUni";
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                string netWorkPath = "";
                bool isSuccess = false;
                rjProgressBar1.Value = 0;

                if (txbPath.Texts == String.Empty)
                {
                    MessageBox.Show("Hãy chọn đường dẫn", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                string path = Properties.Settings.Default.PathBackup;
                string nameFile = txbNameBackup.Texts;

                string strpath = $"{path}\\{nameFile}.bak";

                string str1 = $"BACKUP DATABASE VinUniver TO DISK = '{strpath}'";
                if (ConnectSQL.dbConnection.ExecuteCommand(str1))
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
                // Nếu là máy Client Backup
                if (!CheckDeviceServer())
                {
                    // Copy File trên server qua Client với folder share
                    SaveFileDialog openFileDialog = new SaveFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Thông tin đường dẫn cần lưu
                        string destinationFileName = openFileDialog.FileName;

                        //Thông tin folder share
                        string namePC = Properties.Settings.Default.PCName;
                        string nameFolderShare = Properties.Settings.Default.NameFolderShare;

                        netWorkPath = @"\\" + namePC + @"\" + nameFolderShare;
                        string username = txtUserName.Texts;
                        string password = txtPassword.Texts;
                        string fileName = nameFile + ".bak";
                        NetworkCredential credentials = new NetworkCredential(username, password);
                        CopyFile(fileName, netWorkPath, credentials, destinationFileName);
                    }
                }
                if (isSuccess)
                {
                    Display(strpath);
                    string showPath = CheckDeviceServer() ? strpath : netWorkPath;
                    MessageBox.Show($"BackUp thành công: {showPath}", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    LogHelper.LogUser("Page Setting", $"Người dùng Backup thành công dữ liệu", Application.StartupPath);

                }
                else
                {
                    MessageBox.Show($"BackUp thất bại: {strpath}", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi Backup: {ex}", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void Display(string strpath)
        {
            rjProgressBar1.Value = 100;

            lblStatus.Visible = true;
            lblTime.Visible = true;
            lblStatus.Text = $"{strpath}";

            DateTime dtime = DateTime.Now;
            lblTime.Text = dtime.ToString();
        }

        private bool CheckDeviceServer()
        {
            string pcServer = Properties.Settings.Default.PCName;
            if (string.IsNullOrEmpty(pcServer))
            {
                MessageBox.Show("Chưa chọn PC Server!","Notice",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand);
                return false;
            }
            string pc = Environment.MachineName;
            return pc == pcServer ? true : false;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            txbPath.Texts = Properties.Settings.Default.PathBackup;
            //txbNameBackup.Texts = "BackupVinUni";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        public bool CopyFile(string fileName, string networkPath, NetworkCredential credentials, string destinationPath)
        {
            byte[] fileBytes = null;

            using (new ConnectToSharedFolder(networkPath, credentials))
            {
                var fileList = Directory.GetDirectories(networkPath);

                networkPath = networkPath + @"\" + fileName;
                try
                {
                    File.Copy(networkPath, destinationPath);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetPath_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }
    }
}
