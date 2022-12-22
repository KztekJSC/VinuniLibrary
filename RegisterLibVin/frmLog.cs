using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace RegisterLibVin
{
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }
        private string[] TypeLooking = new string[]
        {
            "DateTime","UserName","Page","Description","PCName"
        };
        private void frmLog_Load(object sender, EventArgs e)
        {
            string str = "SELECT [Date],[UserName],[Page],[Description],[PCName] FROM tblLog";
            DataTable dtLog = ConnectSQL.dbConnection.FillData(str);

            dgvLog.DataSource = dtLog;

            for (int i = 0; i < TypeLooking.Length; i++)
            {
                cbbType1.Items.Add(TypeLooking[i]);
            }
            cbbType1.SelectedIndex = 3;

            lblCount.Visible = false;

            txbTimKiem.Texts = Mifare.NameLooking();
        }

        private void cbbType1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType1.Texts.Trim() == TypeLooking[0])
            {
                dtpFrom.Visible = true;
                dtpTo.Visible = true;
                lblFrom.Visible = true;
                lblTo.Visible = true;
                txbTimKiem.Visible = false;
            }
            else
            {
                dtpFrom.Visible = false;
                dtpTo.Visible = false;
                lblFrom.Visible = false;
                lblTo.Visible = false;
                txbTimKiem.Visible = true ;

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"SELECT [Date],[UserName],[Page],[Description],[PCName] FROM [VinUniver].[dbo].[tblLog] ");

            if (cbbType1.Texts.Trim() == TypeLooking[0])
            {
                if (dtpFrom.Value > dtpTo.Value)
                {
                    MessageBox.Show("Thời gian không hợp lệ", "Mời nhập lại", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    sb.Append($"where tblLog.Date between '{dtpFrom.Value}' and '{dtpTo.Value}'");
                }
            }
            if (cbbType1.Texts.Trim() == TypeLooking[1])
            {
                sb.Append("where tblLog.UserName like '%" + txbTimKiem.Texts + "%' ");

            }
            if (cbbType1.Texts.Trim() == TypeLooking[2])
            {
                sb.Append("where tblLog.Page like '%" + txbTimKiem.Texts + "%' ");

            }
            if (cbbType1.Texts.Trim() == TypeLooking[3])
            {
                sb.Append("where tblLog.Description like '%" + txbTimKiem.Texts + "%' ");

            }
            if (cbbType1.Texts.Trim() == TypeLooking[4])
            {
                sb.Append($"where tblLog.PCName like '%" + txbTimKiem.Texts + "%' ");
            }

            DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());

            lblCount.Visible = true;
            lblCount.Text = dt.Rows.Count.ToString() + " kết quả";
            dgvLog.DataSource = dt;

        }

        private void txbTimKiem_Enter(object sender, EventArgs e)
        {
            if (txbTimKiem.Texts == Mifare.NameLooking())
            {
                txbTimKiem.Texts = "";
                txbTimKiem.ForeColor = Color.Black;
            }
        }
    }
}
