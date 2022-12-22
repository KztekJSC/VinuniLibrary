using Futech.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using OfficeOpenXml.Style;
using DocumentFormat.OpenXml.Drawing;

namespace RegisterLibVin
{
    public partial class frmManager : Form
    {

        private string[] TypeLooking = new string[]
        {
            "First Name","Identifier Value","Email","Phone Number","Account","Date Time"
        };
        public frmManager()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmManager_Load(object sender, EventArgs e)
        {
            string str = "select count (*) from tblRegister where IsDelete = '0'";
            DataTable count = ConnectSQL.dbConnection.FillData(str);
            if(count != null)
            {
                rjButton1.Text = "  "+ count.Rows[0][0].ToString();
            }
            //string getData = "select tblRegister.CardNumber,tblRegister.StudentName,tblStudent.StudentCode,Khoa,Gmail,PhoneNumber,Other,tblRegister.DateTime,UserFullName,tblRegister.IsDelete\r\nfrom tblRegister\r\ninner join tblStudent on tblRegister.StudentID = tblStudent.StudentID";
            //DataTable dt = ConnectSQL.dbConnection.FillData(getData);
            StringBuilder sb = new StringBuilder();
            sb.Append($"select '{dgvDataSV.RowCount++}',tblQLSV.Surname,Name,Email,StudentCode,PhoneNumber,tblQLSV.CardID , tblRegister.DateTime,UserFullName, tblQLSV.Note, tblRegister.IsDelete ");
            sb.Append($"from tblQLSV inner join tblRegister on tblQLSV.StudentID = tblRegister.StudentID");

            DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = index;
                index++;
            }
            dgvDataSV.DataSource = dt;
            //CreatDGV();

            for (int i = 0; i < TypeLooking.Length; i++)
            {
                cbbType1.Items.Add(TypeLooking[i]);
            }

            cbbType1.SelectedIndex = 1;

            if (dgvDataSV != null && dgvDataSV.Rows.Count > 0)
            {
                for (int i = 0; i <= dgvDataSV.Rows.Count - 2; i++)
                {
                    bool a = (bool)dgvDataSV.Rows[i].Cells["IsDelete"].Value;
                    if (a == false)
                    {
                        dgvDataSV.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
            }
            lblCount.Visible = false;

            txbTimKiem.Texts = Mifare.NameLooking();
        }
        bool delete = false;

        private void ckbIsDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ckbIsDelete.GetItemChecked(0) && ckbIsDelete.GetItemChecked(1))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"select '1',tblQLSV.Surname,Name,Email,StudentCode,PhoneNumber,tblQLSV.CardID , tblRegister.DateTime,UserFullName, tblQLSV.Note, tblRegister.IsDelete ");
                sb.Append($"from tblQLSV inner join tblRegister on tblQLSV.StudentID = tblRegister.StudentID ");
                DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());
                dgvDataSV.DataSource = dt;
            }
            else if (ckbIsDelete.GetItemChecked(0))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"select '1',tblQLSV.Surname,Name,Email,StudentCode,PhoneNumber,tblQLSV.CardID , tblRegister.DateTime,UserFullName, tblQLSV.Note, tblRegister.IsDelete ");
                sb.Append($"from tblQLSV inner join tblRegister on tblQLSV.StudentID = tblRegister.StudentID ");
                sb.Append($"where tblRegister.IsDelete = '0'");
                DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());
                dgvDataSV.DataSource = dt;
            }
            else if (ckbIsDelete.GetItemChecked(1))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"select '1',tblQLSV.Surname,Name,Email,StudentCode,PhoneNumber,tblQLSV.CardID , tblRegister.DateTime,UserFullName, tblQLSV.Note, tblRegister.IsDelete ");
                sb.Append($"from tblQLSV inner join tblRegister on tblQLSV.StudentID = tblRegister.StudentID ");
                sb.Append($"where tblRegister.IsDelete = '1'");
                DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());
                dgvDataSV.DataSource = dt;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"select '1',tblQLSV.Surname,Name,Email,StudentCode,PhoneNumber,tblQLSV.CardID , tblRegister.DateTime,UserFullName, tblQLSV.Note, tblRegister.IsDelete ");
                sb.Append($"from tblQLSV inner join tblRegister on tblQLSV.StudentID = tblRegister.StudentID ");
                DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());
                dgvDataSV.DataSource = dt;
            }

        }

        private void txbTimKiem__TextChanged(object sender, EventArgs e)
        {
            
        }
       

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvDataSV.DataSource;
            dt.Columns.Remove("IsDelete");
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "ExportExcel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string Name = Properties.Settings.Default.FullName;
                    ExcelReport.ExportExcel(saveFileDialog.FileName, dt, "Bảng sinh viên", "Quản lý sinh viên đăng ký");
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OKCancel);
                    LogHelper.LogUser("Page Registered List", $"Người dùng Export Excel thành công", Application.StartupPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Khong thanh cong");
                }
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append($"select '1',tblQLSV.Surname,Name,Email,StudentCode,PhoneNumber,tblQLSV.CardID , tblRegister.DateTime,UserFullName, tblQLSV.Note, tblRegister.IsDelete ");
            sb.Append($"from tblQLSV inner join tblRegister on tblQLSV.StudentID = tblRegister.StudentID ");

            if (cbbType1.Texts.Trim() == TypeLooking[0])
            {
                sb.Append("where tblQLSV.Name like '%" + txbTimKiem.Texts + "%' ");
            }
            if (cbbType1.Texts.Trim() == TypeLooking[1])
            {
                sb.Append("where tblQLSV.StudentCode like '%" + txbTimKiem.Texts + "%' ");

            }
            if (cbbType1.Texts.Trim() == TypeLooking[2])
            {
                sb.Append("where tblRegister.Email like '%" + txbTimKiem.Texts + "%' ");

            }
            if (cbbType1.Texts.Trim() == TypeLooking[3])
            {
                sb.Append($"where tblRegister.PhoneNumber like '%" + txbTimKiem.Texts + "%' ");

            }
            if (cbbType1.Texts.Trim() == TypeLooking[4])
            {
                sb.Append("where tblRegister.UserFullName like '%" + txbTimKiem.Texts + "%' ");
            }
            if (cbbType1.Texts.Trim() == TypeLooking[5])
            {
                if(dtpFrom.Value > dtpTo.Value)
                {
                    MessageBox.Show("Thời gian không hợp lệ", "Mời nhập lại", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                sb.Append($"where tblRegister.DateTime between '{dtpFrom.Value}' and '{dtpTo.Value}'");

            }
            if (ckbIsDelete.GetItemChecked(0) && ckbIsDelete.GetItemChecked(1))
            {

            }
            else if (ckbIsDelete.GetItemChecked(0))
            {
                delete = false;
                sb.Append("and tblRegister.IsDelete = '" + delete + "'");

            }
            else if (ckbIsDelete.GetItemChecked(1))
            {
                delete = true;
                sb.Append("and tblRegister.IsDelete = '" + delete + "'");
            }

            DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());

            lblCount.Visible = true;
            lblCount.Text = Mifare.Sort_STT(dt);
            dgvDataSV.DataSource = dt;
            
            LogHelper.LogUser("Page Registered List", $"Người tìm kiếm với nội dung {txbTimKiem.Texts}", Application.StartupPath);




        }




        private void cbbType1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType1.Texts.Trim() == TypeLooking[5])
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
                txbTimKiem.Visible = true;

            }
        }

        private void cbbType1_Load(object sender, EventArgs e)
        {

        }

        private void cbbType1_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void cbbType1_Click(object sender, EventArgs e)
        {

        }

        private void cbbType1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbbType1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void cbbType1_Load_1(object sender, EventArgs e)
        {

        }

        private void txbTimKiem_Enter(object sender, EventArgs e)
        {
            if (txbTimKiem.Texts == Mifare.NameLooking())
            {
                txbTimKiem.Texts = "";
                txbTimKiem.ForeColor = Color.Black;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
