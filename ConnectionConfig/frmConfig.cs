using Futech.Tools;
using RegisterLibVin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectionConfig
{
    public partial class frmConfig : Form
    {
        private string ServerConfigPath = $"{Application.StartupPath}\\SQLConn.xml";

        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string sqlServerName = txbServerName.Text;
            string sqlDatabaseName = txbDatabaseName.Text;
            string sqlAuthentication = cbbAuthentication.Text;
            string sqlUserName = txbUserName.Text;
            string sqlPassword = txbPass.Text;
            Futech.Tools.MDB dbConnection = new MDB(sqlServerName, sqlDatabaseName, sqlAuthentication, sqlUserName, sqlPassword);
            
            if (dbConnection.OpenMDB())
            {
                picTrueDone.Visible = true;
                picFalseDone.Visible = false;
            }
            else
            {
                picTrueDone.Visible = false;
                picFalseDone.Visible = true;
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picTrueDone.Visible = false;
            picFalseDone.Visible = false;

            //txbServerName.Text = "103.127.207.247";
            //txbDatabaseName.Text = "VinUniver";
            //txbUserName.Text = "sa";
            //txbPass.Text = "Kztek@123456";
            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (SaveConfig())
            {
                MessageBox.Show("Lưu thiết lập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Lưu thiết lập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private bool SaveConfig()
        {
            List<SQLConn> sqlconnlist = new List<SQLConn>();

            SQLConn cn1 = new SQLConn()
            {
                SQLAuthentication = cbbAuthentication.Text,
                SQLDatabase = txbDatabaseName.Text,
                SQLPassword = txbPass.Text,
                SQLServerName = txbServerName.Text,
                SQLUserName = txbUserName.Text,
                //DatabaseIp = txbServerName.Text,
            };
            sqlconnlist.Add(cn1);
            FileXML.WriteXML<SQLConn>(ServerConfigPath, sqlconnlist);
            return true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
