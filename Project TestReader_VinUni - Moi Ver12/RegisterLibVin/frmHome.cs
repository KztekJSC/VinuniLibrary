using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmHome : Form
    {
        bool sidebarExpand = true;
        private Form formCon;
        public frmHome()
        {
            InitializeComponent();
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
            Application.Exit();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            lblHome.Text = "Home";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            label3.Text = "Home";
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
            OpenCon(new frmRegistCard());
            lblHome.Text = btnWriteNew.Text.Trim();
        }


        private void btnManger_Click(object sender, EventArgs e)
        {
            rjDropdownMenu1.Show(btnManger, btnManger.Width - 25, 0);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                OpenCon(new frmSetting());
                lblHome.Text = btnSetting.Text.Trim();
            }
            if (access == "User")
            {
                MessageBox.Show("Admin mới được quyền truy cập", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            else if (Properties.Settings.Default.AccessPermission == "User".Trim())
            {
                nameType = " User: ";
                btnAdmin.Visible = false;
            }
            else
            {
                nameType = " SuperAdmin: ";
                btnAdmin.Visible = true;
            }

            lbl_name.Text = nameType + Properties.Settings.Default.FullName;
            lbl_name.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);

            label1.Text = nameType + " " + Properties.Settings.Default.FullName;
            label1.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
            //lbl_name.ForeColor = Color.Green;
        }

        private void rjDropdownMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void MitemDanhSachDKi_Click(object sender, EventArgs e)
        {
            OpenCon(new frmQLSV());
            lblHome.Text = btnManger.Text.Trim();
        }

        private void MitemQuanLyTK_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                OpenCon(new frmQuanLyUser());
                lblHome.Text = btnManger.Text.Trim();
            }
            if (access == "User")
            {
                MessageBox.Show("Admin mới được quyền truy cập", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MitemQuanLySV_Click(object sender, EventArgs e)
        {
            OpenCon(new frmManager());
            lblHome.Text = btnManger.Text.Trim();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
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
    }
}
