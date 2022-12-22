using CustomMessageBox;
using Futech.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ConnectionConfig;
using System.Linq;
using System.Data.Common;
using DocumentFormat.OpenXml.Math;

namespace RegisterLibVin
{
    public partial class frmLogin : Form
    {
        private string ServerConfigPath = $"{Application.StartupPath}\\SQLConn.xml";
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public frmLogin()
        {
            InitializeComponent();
            // Load và mở kết nối đến DB
            ConnectSQL.ConnectConfig();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    
        private void chkChecked(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
                chk.Image = Properties.Resources._checked;
            else
                chk.Image = Properties.Resources._unchecked;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //txbAcount.Texts = "admin";
            //txbPass.Texts = "1";
            if(Properties.Settings.Default.Pass != "")
            {
                txbPass.Texts = Properties.Settings.Default.Pass;
                checkBox1.Checked = true;
            }
            if (Properties.Settings.Default.UserName != "")
            {
                txbAcount.Texts = Properties.Settings.Default.UserName;
                checkBox1.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRegister)
                {
                    // Nếu là đăng ký
                    if (txbAcount.Texts != "" && txbPass.Texts != "" && txbPass2.Texts != "" && txbFullName.Texts != "")
                    {
                        if (txbPass2.Texts == txbPass.Texts)
                        {
                            //Kiểm tra tài khoản đã tồn tại chưa
                            string check = $"use VinUniver; select * from tblUser where UserName = '{txbAcount.Texts}'";
                            DataTable dt = ConnectSQL.dbConnection.FillData(check);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                RJMessageBox.Show("Tài khoản đã tồn tại", "Notice", MessageBoxButtons.OKCancel);
                            }
                            else
                            {
                                DialogResult result = RJMessageBox.Show("Xác nhận đăng ký", "Register", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    string quyen = "User";
                                    string query = $"use VinUniver; insert into tblUser values (NEWID(),N'{txbFullName.Texts}','{Filter(txbAcount.Texts)}','{Filter(txbPass.Texts)}','{quyen}', '0')";
                                    ConnectSQL.dbConnection.ExecuteCommand(query);

                                    RJMessageBox.Show("Đăng ký thành công!", "Notice", MessageBoxButtons.OKCancel);
                                }
                            }
                        }
                        else
                        {
                            RJMessageBox.Show("Mật khẩu chưa trùng khớp", "Notice", MessageBoxButtons.OKCancel);
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("Mời nhập đủ thông tin", "Notice", MessageBoxButtons.OKCancel);
                    }
                }
                else   // Nếu là đăng nhập
                {
                    // Fix cứng tài khoản superAdmin
                    if(txbAcount.Texts == "spAdmin" && txbPass.Texts == "kienpino99")
                    {
                        Properties.Settings.Default.AccessPermission = "SuperAdmin";
                        Properties.Settings.Default.FullName = "SuperAdmin";
                        frmHome frm = new frmHome();
                        frm.ShowDialog();
                    }
                    else
                    {
                        string str = $"use VinUniver;select * from tblUser where UserName = '{txbAcount.Texts}' and Password = '{txbPass.Texts}'";
                        DataTable dtLogin = ConnectSQL.dbConnection.FillData(str);
                        if (dtLogin != null && dtLogin.Rows.Count > 0)
                        {
                            DataRowView drv = dtLogin.DefaultView[0];
                            string Access = drv["AccessPermission"].ToString().Trim();
                            string FullName = drv["FullName"].ToString();
                            bool Lock = bool.Parse(drv["IsLock"].ToString());
                            if (Lock == false)
                            {
                                Properties.Settings.Default.AccessPermission = Access;
                                Properties.Settings.Default.FullName = FullName;
                                if (checkBox1.Checked)
                                {
                                    Properties.Settings.Default.Pass = txbPass.Texts;
                                    Properties.Settings.Default.UserName = txbAcount.Texts;
                                }
                                else
                                {
                                    Properties.Settings.Default.Pass = "";
                                    Properties.Settings.Default.UserName = "";
                                }
                                Properties.Settings.Default.Save();
                                frmHome frm = new frmHome();
                                frm.ShowDialog();
                            }
                            else
                            {
                                // lock = 1 tài khoản bị khóa
                                RJMessageBox.Show("Tài khoản đã bị khóa", "Login Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }

                        }
                        else
                        {
                            // Sai mật khẩu hoặc tài khoản
                            string strUser = $"use VinUniver;select * from tblUser where UserName = '{txbAcount.Texts}'";
                            DataTable dtUser = ConnectSQL.dbConnection.FillData(strUser);
                            if (strUser != null && dtUser.Rows.Count > 0)
                            {
                                RJMessageBox.Show("sai mật khẩu", "Login Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                RJMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Login Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool isRegister = false;
        private void togbtnRegister_Click(object sender, EventArgs e)
        {
            
            isRegister = true;
            togbtnLogin.BorderSize = 1;
            togbtnLogin.BorderColor = Color.FromArgb(224, 224, 224);
            togbtnRegister.BorderSize = 0;
            togbtnRegister.BackColor = Color.FromArgb(33, 41, 44);
            togbtnLogin.BackColor = Color.White;
            togbtnRegister.ForeColor = Color.White;
            togbtnLogin.ForeColor = Color.Black;
            txbPass2.Visible = true;

            //checkBox1.Location = new System.Drawing.Point(33, 322);
            btnLogin.Text = "Register";
            checkBox1.Visible = false;
            txbFullName.Visible = true;
            TxbLocationForRegister();
        }

        private void togbtnLogin_Click(object sender, EventArgs e)
        {
            isRegister = false;
            togbtnLogin.BorderSize = 0;
            togbtnRegister.BackColor = Color.White;
            togbtnLogin.BackColor = Color.FromArgb(33, 41, 44);
            togbtnRegister.ForeColor = Color.Black;
            togbtnLogin.ForeColor = Color.White;
            txbPass2.Visible = false;
            //checkBox1.Location = new System.Drawing.Point(33, 298);
            btnLogin.Text = "Login";
            checkBox1.Visible = true;
            txbFullName.Visible = false;
            TxbLocationForLogin();
        }
        private void TxbLocationForRegister()
        {
            txbFullName.Location = new System.Drawing.Point(79, 206);
            txbAcount.Location = new System.Drawing.Point(79,245);
            txbPass.Location = new System.Drawing.Point(79,284);
            txbPass2.Location = new System.Drawing.Point(79,323);
            picAcount.Location = new System.Drawing.Point(54, 254);
            picPass.Location = new System.Drawing.Point(54, 292);
            picShow.Location = new System.Drawing.Point(284, 296);
            picHide.Location = new System.Drawing.Point(284, 296);
            picFullname.Visible = true;
        }
        private void TxbLocationForLogin()
        {
            txbAcount.Location = new System.Drawing.Point(79, 206);
            txbPass.Location = new System.Drawing.Point(79, 245);
            picAcount.Location = new System.Drawing.Point(54,215);
            picPass.Location = new System.Drawing.Point(54, 254);
            picShow.Location = new System.Drawing.Point(284, 257);
            picHide.Location = new System.Drawing.Point(284, 257);

            picFullname.Visible = false;
        }
        private void picShow_Click(object sender, EventArgs e)
        {
            txbPass.PasswordChar = true;
            txbPass2.PasswordChar = true;

            picShow.Visible = false;
            picHide.Visible = true;
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            txbPass.PasswordChar = false;
            txbPass2.PasswordChar = false;

            picShow.Visible = true;
            picHide.Visible = false;
        }

        private void txbAcount_Enter(object sender, EventArgs e)
        {
            if (txbAcount.Texts == "Username")
            {
                txbAcount.Texts = "";
                txbAcount.ForeColor = Color.Black;
            }
        }

        private void txbAcount_Leave(object sender, EventArgs e)
        {
            if (txbAcount.Texts == "")
            {
                txbAcount.Texts = "Username";
                txbAcount.ForeColor = Color.Gray;
            }
        }

        private void txbPass_Enter(object sender, EventArgs e)
        {
            if (txbPass.Texts == "Password")
            {
                txbPass.Texts = "";
                txbPass.ForeColor = Color.Black;
                txbPass.PasswordChar = true;
            }
        }

        private void txbPass_Leave(object sender, EventArgs e)
        {
            if (txbPass.Texts == "")
            {
                txbPass.Texts = "Password";
                txbPass.ForeColor = Color.Gray;
                txbPass.PasswordChar = false;
            }
        }

        private void txbPass2_Enter(object sender, EventArgs e)
        {
            if (txbPass2.Texts == "Confirm password")
            {
                txbPass2.Texts = "";
                txbPass2.ForeColor = Color.Black;
                txbPass2.PasswordChar = true;
            }
        }

        private void txbPass2_Leave(object sender, EventArgs e)
        {
            if (txbPass2.Texts == "")
            {
                txbPass2.Texts = "Confirm password";
                txbPass2.ForeColor = Color.Gray;
                txbPass2.PasswordChar = false;
            }
        }

        private void txbFullName_Enter(object sender, EventArgs e)
        {
            if (txbFullName.Texts == "Full Name")
            {
                txbFullName.Texts = "";
                txbFullName.ForeColor = Color.Black;
            }
        }

        private void txbFullName_Leave(object sender, EventArgs e)
        {
            if (txbFullName.Texts == "")
            {
                txbFullName.Texts = "Full Name";
                txbFullName.ForeColor = Color.Gray;
            }
        }
        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        // Hàm lọc kí tự dấu thành không dấu
        public static string Filter(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
    }
}
