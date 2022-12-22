using Futech.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmQLSV : Form
    {

        public frmQLSV()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str = "select * from tblQLSV";
                    DataTable dt = ConnectSQL.dbConnection.FillData(str);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Có dữ liệu thêm Excell2 chỉ thêm những MSV mới
                        DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Dữ liệu chỉ thêm MSV mới", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if(result == DialogResult.Yes)
                        {
                            //ConnectSQL.dbConnection.ExecuteCommand("delete from tblQLSV");
                            ExcelReport.ImportExcel2(openFileDialog.FileName, dgvQLSV);
                            MessageBox.Show("ImPort thành công", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                            SaveNewSQL2();
                        }
                    }
                    else
                    {
                        // Chưa có dữ liệu thì thêm Excell thêm mới
                        DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            ExcelReport.ImportExcel(openFileDialog.FileName, dgvQLSV);
                            MessageBox.Show("ImPort thành công", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                            SaveNewSQL();
                        }
                        
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ImPort lỗi!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        

        private void SaveNewSQL()
        {
            try
            {
                //ConnectSQL.dbConnection.ExecuteCommand("delete from tblQLSV");
                string StudentID = ""; //Guid.NewGuid().ToString();
                for (int i = 0; i <= dgvQLSV.Rows.Count - 1; i++)
                {
                    StudentID = Guid.NewGuid().ToString();
                    string stt = dgvQLSV.Rows[i].Cells["STT"].Value.ToString();
                    string hoDem = dgvQLSV.Rows[i].Cells["Last Name"].Value.ToString();
                    string ten = dgvQLSV.Rows[i].Cells["First Name"].Value.ToString();
                    string email = dgvQLSV.Rows[i].Cells["Email"].Value.ToString();
                    string msv = dgvQLSV.Rows[i].Cells["Identifier Value"].Value.ToString();
                    string phone = dgvQLSV.Rows[i].Cells["Phone Number"].Value.ToString();
                    string cardID = dgvQLSV.Rows[i].Cells["User Id"].Value.ToString();
                    string note = dgvQLSV.Rows[i].Cells["User Groups"].Value.ToString();
                    //string str = $"insert into tblQLSV values(N'" + dgvQLSV.Rows[i].Cells["STT"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Họ đệm"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Tên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Email"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Mã sinh viên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Số điện thoại"].Value + "',N'" + dgvQLSV.Rows[i].Cells["ID Card"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Ghi chú"].Value + "','0','0','" + StudentID + "')";

                    //string stt = dgvQLSV.Rows[i].Cells[0].Value.ToString();
                    //string hoDem = dgvQLSV.Rows[i].Cells[1].Value.ToString();
                    //string ten = dgvQLSV.Rows[i].Cells[2].Value.ToString();
                    //string email = dgvQLSV.Rows[i].Cells[3].Value.ToString();
                    //string msv = dgvQLSV.Rows[i].Cells[4].ToString();
                    //string phone = dgvQLSV.Rows[i].Cells[5].ToString();
                    //string cardID = dgvQLSV.Rows[i].Cells[6].ToString();
                    //string note = dgvQLSV.Rows[i].Cells[7].ToString();
                    string str = $"insert into tblQLSV values(N'{stt}',N'{hoDem}',N'{ten}',N'{email}',N'{msv}',N'{phone}',N'{cardID}',N'{note}','0','0', '{StudentID}')";

                    ConnectSQL.dbConnection.ExecuteCommand(str);
                }
                LoadDGV();
                //MessageBox.Show("Đã lưu dữ liệu","Import",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi lưu dữ liệu","SaveNewSQL",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private void SaveNewSQL2()
        {
            try
            {
                ConnectSQL.dbConnection.ExecuteCommand("delete from tblQLSV");
                string StudentID = ""; //Guid.NewGuid().ToString();
                for (int i = 0; i <= dgvQLSV.Rows.Count - 1; i++)
                {
                    StudentID = Guid.NewGuid().ToString();
                    string stt = dgvQLSV.Rows[i].Cells["STT"].Value.ToString();
                    string hoDem = dgvQLSV.Rows[i].Cells["Surname"].Value.ToString();
                    string ten = dgvQLSV.Rows[i].Cells["Name"].Value.ToString();
                    string email = dgvQLSV.Rows[i].Cells["Email"].Value.ToString();
                    string msv = dgvQLSV.Rows[i].Cells["StudentCode"].Value.ToString();
                    //string str = $"insert into tblQLSV values(N'" + dgvQLSV.Rows[i].Cells["STT"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Họ đệm"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Tên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Email"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Mã sinh viên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Số điện thoại"].Value + "',N'" + dgvQLSV.Rows[i].Cells["ID Card"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Ghi chú"].Value + "','0','0','" + StudentID + "')";
                    string str = $"insert into tblQLSV values(N'" + dgvQLSV.Rows[i].Cells["STT"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Surname"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Name"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Email"].Value + "',N'" + dgvQLSV.Rows[i].Cells["StudentCode"].Value + "',N'" + dgvQLSV.Rows[i].Cells["PhoneNumber"].Value + "',N'" + dgvQLSV.Rows[i].Cells["CardID"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Note"].Value + "','0','0','" + StudentID + "')";

                    ConnectSQL.dbConnection.ExecuteCommand(str);
                }
                LoadDGV();
                MessageBox.Show("Đã lưu dữ liệu", "Import", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("loi roi");
            }
        }
        private void LoadDGV()
        {
            string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[StudentID] FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0'";
            DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = index;
                index++;
            }
            dgvQLSV.DataSource = dt;
            //for (int i = 0; i <= dgvQLSV.Rows.Count-2; i++)
            //{
            //    bool a = (bool)dgvQLSV.Rows[i].Cells["IsDelete"].Value;
            //    if(a == true)
            //    {
            //        dgvQLSV.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}
            if (dgvQLSV.Rows.Count > 0)
            {
                dgvQLSV.CurrentCell = dgvQLSV.Rows[0].Cells[0];
                //dgvQLSV_CellContentClick(null, null);
            }
        }
        bool isExport = false;
        private void btnExport_Click(object sender, EventArgs e)
        {
            isExport = true;
            DataTable dt = (DataTable)dgvQLSV.DataSource;
            dt.Columns.Remove("StudentID");
            dt.Columns.Remove("IsDelete");


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "ExportExcel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //ExportExcel(saveFileDialog.FileName);
                    ExcelReport.ExportExcel2(saveFileDialog.FileName, dt, "Bảng sinh viên", "Quản lý sinh viên");
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OKCancel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Khong thanh cong");
                }
            }
            isExport = false;
        }
        bool isDaXoa = false;
        string studentCodeMSV = "";
        private void dgvQLSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvQLSV.CurrentRow.Index;
            txbCardID.Texts = dgvQLSV.Rows[i].Cells[6].Value.ToString();
            txbHoDem.Texts = dgvQLSV.Rows[i].Cells[1].Value.ToString();
            txbTen.Texts = dgvQLSV.Rows[i].Cells[2].Value.ToString();
            txbEmail.Texts = dgvQLSV.Rows[i].Cells[3].Value.ToString();
            txbMSV.Texts = dgvQLSV.Rows[i].Cells[4].Value.ToString();
            txbPhone.Texts = dgvQLSV.Rows[i].Cells[5].Value.ToString();
            txbNote.Texts = dgvQLSV.Rows[i].Cells[7].Value.ToString();
            string Notifi = dgvQLSV.Rows[i].Cells[8].Value.ToString();
            txbStudentID.Texts = dgvQLSV.Rows[i].Cells[9].Value.ToString();
            studentCodeMSV = txbMSV.Texts;
            if (Notifi == "True")
            {
                txbIsDelete.Texts = "Dữ liệu đã xóa";
                txbIsDelete.ForeColor = Color.Red;
                isDaXoa = true;
            }
            else
            {

                txbIsDelete.Texts = "Dữ liệu đang ghi";
                txbIsDelete.ForeColor = Color.Black;
                isDaXoa = false;
            }
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            string str = "select * from tblQLSV";
            DataTable dt = ConnectSQL.dbConnection.FillData(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                LoadDGV();
            }

            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                btnDeleteRemove.Visible = true;
                btnSua.Enabled = true;
            }
            else
            {
                btnDeleteRemove.Visible = false;
                btnSua.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmAddSV f = new frmAddSV();
            f.ShowDialog();


            if (f.DialogResult == DialogResult.OK)
            {
                LoadDGV();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Không được sửa MSSV
            // 
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                if (string.IsNullOrEmpty(txbMSV.Texts))
                {
                    MessageBox.Show("Hãy chọn dữ liệu muốn sửa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                if (isDaXoa)
                {
                    MessageBox.Show("Dữ liệu này đã xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    int stt = 1;
                    string StudentID = Guid.NewGuid().ToString();
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append($"update tblQLSV ");
                    sb1.Append($"set STT = '{stt}',Surname = N'{txbHoDem.Texts}',Name = N'{txbTen.Texts}',Email = N'{txbEmail.Texts}',StudentCode = '{txbMSV.Texts}',");
                    sb1.Append($"PhoneNumber = '{txbPhone.Texts}',CardID = '{txbCardID.Texts}',Note = N'{txbNote.Texts}',IsRegister = '0',IsDelete = '0',StudentID = '{StudentID}' ");
                    sb1.Append($"where StudentID = '{txbStudentID.Texts}'");

                    DialogResult result = MessageBox.Show("Xác nhận muốn sửa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        ConnectSQL.dbConnection.ExecuteCommand(sb1.ToString());
                        LoadDGV();
                    }
                }
            }
            else
            {
                MessageBox.Show("Admin mới được phép sửa dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }


        }

        private void txbMSV__TextChanged(object sender, EventArgs e)
        {
            

        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSV.Texts))
            {
                MessageBox.Show("Hãy chọn dữ liệu muốn khôi phục", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            string str = $"select * from tblQLSV where StudentCode = '{studentCodeMSV}' and IsDelete = '0'";
            DataTable dt = ConnectSQL.dbConnection.FillData(str);
            if(dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("Thông tin sinh viên này đã có dữ liệu mới","không thể khôi phục");
            }
            else
            {
                string StudentID = Guid.NewGuid().ToString();
                StringBuilder sb1 = new StringBuilder();
                sb1.Append($"update tblQLSV set IsDelete = '0' ");
                sb1.Append($"where StudentID = '{txbStudentID.Texts}'");

                DialogResult result = MessageBox.Show("Xác nhận muốn khôi phục dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    ConnectSQL.dbConnection.ExecuteCommand(sb1.ToString());
                    LoadDGV();
                }
            }
        }

       
        private void txbTimKiem__TextChanged(object sender, EventArgs e)
        {
            if (ckbIsDelete.GetItemChecked(0) && ckbIsDelete.GetItemChecked(1))
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where StudentCode like '%" + txbTimKiem.Texts + "%'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                dgvQLSV.DataSource = dt;
            }
            else if (ckbIsDelete.GetItemChecked(0))
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0' and  StudentCode like '%" + txbTimKiem.Texts + "%'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                dgvQLSV.DataSource = dt;
            }
            else if (ckbIsDelete.GetItemChecked(1))
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '1' and  StudentCode like '%" + txbTimKiem.Texts + "%'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                dgvQLSV.DataSource = dt;
            }
            else
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where StudentCode like '%" + txbTimKiem.Texts + "%'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                dgvQLSV.DataSource = dt;
            }
        }

        private void ckbIsDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ckbIsDelete.GetItemChecked(0) && ckbIsDelete.GetItemChecked(1))
            {
                LoadDGV();
            }
            else if (ckbIsDelete.GetItemChecked(0))
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                dgvQLSV.DataSource = dt;
            }
            else if (ckbIsDelete.GetItemChecked(1))
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '1'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                dgvQLSV.DataSource = dt;
            }
            else
            {
                LoadDGV();
            }
        }

        private void dgvQLSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!isExport)
            {
                if (dgvQLSV != null && dgvQLSV.Rows.Count > 0)
                {
                    for (int i = 0; i <= dgvQLSV.Rows.Count - 2; i++)
                    {
                        string isDeleteStr = dgvQLSV.Rows[i].Cells["IsDelete"]?.Value?.ToString() ?? "";
                        bool isDelete = isDeleteStr == "1" || isDeleteStr.ToLower() == "true";
                        if (isDelete == true)
                        {
                            dgvQLSV.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
            
            
        }

        private void btnDeleteRemove_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                if (string.IsNullOrEmpty(txbStudentID.Texts))
                {
                    MessageBox.Show("Hãy chọn dữ liệu để xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                //string creat = $"select * from tblQLSV where StudentCode = '{txbMSV.Texts}' and IsDelete = '0'";
                //DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                if (isDaXoa == false)
                {
                    string str = $"update tblQLSV set IsDelete = '1' where StudentID = '{txbStudentID.Texts}'";
                    DialogResult result = MessageBox.Show("Xác nhận xóa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        ConnectSQL.dbConnection.ExecuteCommand(str);
                        LoadDGV();
                    }

                }
                else
                {
                    MessageBox.Show("Thẻ đã xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Admin mới được phép sửa dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //btnXoa.Enabled = false;
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            frmListDelete f = new frmListDelete();
            f.ShowDialog();

            if(f.DialogResult == DialogResult.Cancel)
            {
                LoadDGV();
            }
        }
    }
}
