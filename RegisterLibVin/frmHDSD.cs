using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmHDSD : Form
    {
        public frmHDSD()
        {
            InitializeComponent();
        }

        private void frmHDSD_Load(object sender, EventArgs e)
        {
            picHome2.Visible = false;
            picDki.Visible = false;
            picQLSV.Visible = false;
            picQLTK.Visible = false;
            picSVdaDK.Visible = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void picHome2_Click(object sender, EventArgs e)
        {

        }

        private void btnQLAccount_Click(object sender, EventArgs e)
        {
            picHome2.Visible = false;
            picDki.Visible = false;
            picQLSV.Visible = false;
            picQLTK.Visible = true;
            picSVdaDK.Visible = false;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            picHome2.Visible = true;
            picDki.Visible = false;
            picQLSV.Visible = false;
            picQLTK.Visible = false;
            picSVdaDK.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            picHome2.Visible = false;
            picDki.Visible = true;
            picQLSV.Visible = false;
            picQLTK.Visible = false;
            picSVdaDK.Visible = false;
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            picHome2.Visible = false;
            picDki.Visible = false;
            picQLSV.Visible = true;
            picQLTK.Visible = false;
            picSVdaDK.Visible = false;
        }

        private void btnDSDki_Click(object sender, EventArgs e)
        {
            picHome2.Visible = false;
            picDki.Visible = false;
            picQLSV.Visible = false;
            picQLTK.Visible = false;
            picSVdaDK.Visible = true;
        }
    }
}
