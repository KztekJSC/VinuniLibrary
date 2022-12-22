using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RegisterLibVin
{
    public partial class frmHome : Form
    {
        bool sidebarExpand = true;
        private Form formCon;
        public frmHome()
        {
            InitializeComponent();
            // Form 
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;    // Chia màn hình thành 2 
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        private void OpenCon(Form con)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            formCon = con;
            con.TopLevel = false;
            con.FormBorderStyle = FormBorderStyle.None;
            con.Dock = DockStyle.Fill;
            pnl_body.Controls.Add(con);
            pnl_body.Tag = con;
            con.BringToFront();
            con.Show();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //sidebarTimer.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            //timer1.Start();
        }

        //private void CloseCOMConnect()
        //{
        //}

        private void lblHome_Click(object sender, EventArgs e)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            lblHome.Text = "Home";
            LogHelper.LogUser("Page Home", "Người dùng nhấn Home", Application.StartupPath);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            lblHome.Text = "Home";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            lblHome.Text = "Home";
        }




        private void sidebarTimer_Tick_1(object sender, EventArgs e)
        {
            MoveSideBar(sidebar);
            //MoveDrop(rjDropdownMenu1);
        }

        private void MoveSideBar(FlowLayoutPanel sidebar)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }
        //private void MoveDrop(RJDropdownMenu drop)
        //{
        //    if (sidebarExpand)
        //    {

        //        drop.Width -= 10;
        //        if (drop.Width == drop.MinimumSize.Width)
        //        {
        //            sidebarExpand = false;
        //            sidebarTimer.Stop();
        //        }
        //    }
        //    else
        //    {
        //        drop.Width += 10;
        //        if (drop.Width == drop.MaximumSize.Width)
        //        {
        //            sidebarExpand = true;
        //            sidebarTimer.Stop();
        //        }
        //    }
        //}

        private void btnWriteNew_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            LogHelper.LogUser("Page Home","Người dùng truy cập trang Card Register", Application.StartupPath);
            OpenCon(new frmRegistCard());
            lblHome.Text = btnWriteNew.Text.Trim();
        }


        private void btnManger_Click(object sender, EventArgs e)
        {
            rjDropdownMenu1.Show(btnManger, btnManger.Width - 25, 0);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang Setting", Application.StartupPath);
                OpenCon(new frmSetting());
                lblHome.Text = btnSetting.Text.Trim();
            }
            if (access == "User")
            {
                MessageBox.Show("Admin mới được quyền truy cập", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogHelper.LogUser("Page Home", "Người dùng truy cập thất bại trang Setting", Application.StartupPath);

            }

        }
        string nameType;
        private void frmHome_Load(object sender, EventArgs e)
        {
            rjDropdownMenu1.IsMainMenu = true;
            rjDropdownMenu1.PrimaryColor = Color.DarkOrange;

            if (Properties.Settings.Default.AccessPermission == "Admin".Trim())
            {
                nameType = " Admin: ";
                btnAdmin.Visible = false;
                btnLog.Visible = true;

            }
            else if (Properties.Settings.Default.AccessPermission == "User".Trim())
            {
                nameType = " User: ";
                btnAdmin.Visible = false;
                btnLog.Visible = false;

            }
            else
            {
                nameType = " SuperAdmin: ";
                btnAdmin.Visible = true;
                btnLog.Visible = true;

            }

            lbl_name.Text = nameType + Properties.Settings.Default.FullName;
            lbl_name.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);

            label1.Text = nameType + " " + Properties.Settings.Default.FullName;
            label1.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
        }

        private void rjDropdownMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       

        private void MitemQuanLySV_Click(object sender, EventArgs e)
        {
            

            
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang Admin", Application.StartupPath);
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
            //OpenCon(new frmAdmin());
            //lblHome.Text = btnManger.Text.Trim();
        }

        private void pnl_body_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void frmHome_Shown(object sender, EventArgs e)
        {
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Size.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
            this.Location = new Point(0, 0);
        }

        private void pnl_body_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                OpenCon(new frmQuanLyUser());
                lblHome.Text = btnManger.Text.Trim();
            }
            if (access == "User")
            {
                
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                LogHelper.LogUser("Page Home","Người dùng truy cập thành công trang Log File", Application.StartupPath);
                OpenCon(new frmLog());
                lblHome.Text = btnLog.Text.Trim();

            }
            if (access == "User")
            {
                LogHelper.LogUser("Page Home", "Người dùng truy cập thất bại trang Log File", Application.StartupPath);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            LogHelper.LogUser("Page Home","Người dùng trở về trang chủ", Application.StartupPath);
            formCon.Close();
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Do you want to exit the application?", "Notice", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                LogHelper.LogUser("Exit", "Người dùng thoát chương trình", Application.StartupPath);
                Application.Exit();
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            WindowState = FormWindowState.Minimized;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Home", "Người dùng Log out", Application.StartupPath);
            //this.DialogResult = DialogResult.OK;
            this.Owner.Show();
            this.Close();
        }

        private void MitemQLSV_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            OpenCon(new frmQLSV());
            lblHome.Text = btnManger.Text.Trim();
            LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang Student Management", Application.StartupPath);
        }
        private void MitemQuanLyTK_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang Account Management", Application.StartupPath);
                OpenCon(new frmQuanLyUser());
                lblHome.Text = btnManger.Text.Trim();
            }
            if (access == "User")
            {
                MessageBox.Show("Admin mới được quyền truy cập", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogHelper.LogUser("Page Home", "Người dùng truy cập thất bại trang Account Management", Application.StartupPath);

            }
        }
        private void MitemDSDki_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang Registered List", Application.StartupPath);
            OpenCon(new frmManager());
            lblHome.Text = btnManger.Text.Trim();
        }

        private void btnHDSD_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang User Guide", Application.StartupPath);
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang HDSD", Application.StartupPath);
            OpenCon(new frmHDSD());
            lblHome.Text = btnHDSD.Text.Trim();

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (formCon is frmQLSV)
            {
                if (((frmQLSV)formCon).isVisibleRed)
                {
                    if (MessageBox.Show("Nếu chuyển trang dữ liệu trùng lặp sẽ tự động xóa", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            LogHelper.LogUser("Page Home", "Người dùng truy cập thành công trang Report List", Application.StartupPath);
            OpenCon(new frmReport());
            lblHome.Text = btnReport.Text.Trim();
        }
    }
}
