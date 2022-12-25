
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
using Color = System.Drawing.Color;
using RegisterLibVin;
using System.Windows.Interop;
using System.Windows.Media;

namespace RegisterLibVin
{
    public delegate void SendMessage(string value);

    public partial class frmQLSV : Form
    {
        private string[] TypeLooking = new string[]
        {
            "Last Name","First Name","Identifier Value","Email","PhoneNumber"
        };
        public DataTable dtRed = new DataTable();
        public frmQLSV()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
            dgvQLSV.ToggleDoubleBuffered(true);

            ToolTip tip = new ToolTip() { IsBalloon = true};
            tip.SetToolTip(picDataRedTrung, "Phát hiện dữ liệu trùng lặp, dữ liệu trùng sẽ tự động xóa");
            tip.ToolTipTitle = "Notice";
            tip.ToolTipIcon = ToolTipIcon.Warning;
        }
        //public class SV
        //{
        //    public string MSV { get; set; }
        //    public string Email { get; set; }

        //}
        private List<SinhVien> dssv = new List<SinhVien>();

        private void btnImport_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Student Management", "Nguoi dung ImportExcel", Application.StartupPath);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                
                {
                    string str = "select * from tblQLSV where IsDelete = 0";
                    DataTable dt = ConnectSQL.dbConnection.FillData(str);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        // Import Excell lần sau 
                        DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Dữ liệu sẽ lọc MSV mới", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Sau mỗi lần update Import Excell sẽ load lại List dssv để truyền vào hàm Import
                            UpdateClassSV();   // ClassSV lưu tập các MSV và Email 

                            DataTable dtNewData = new DataTable();
                            dtRed = ExcelReport.ImportExcel2(openFileDialog.FileName, dgvQLSV, dssv, out dtNewData);
                            dtSaveSQL = dtNewData;

                            LoadSTTandRed();    // Load STT và tô đỏ dữ liệu trùng

                            SaveNewSQL2();
                            LogHelper.LogUser("Page Account Management", $"Người dùng Import Excel thành công", Application.StartupPath);
                        }
                    }
                    else
                    {
                        // Import Excell lần đầu 
                        DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        
                        {
                            ExcelReport.ImportExcel(openFileDialog.FileName, dgvQLSV);
                            //MessageBox.Show("ImPort thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            SaveNewSQL();
                            LogHelper.LogUser("Page Account Management", $"Người dùng Import Excel thành công", Application.StartupPath);

                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ImPort lỗi!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    LogHelper.LogUser("Page Account Management", $"Người dùng Import Excel lỗi", Application.StartupPath);

                }
            }
        }
        private void UpdateClassSV()
        {
            string str1 = "select * from tblQLSV where IsDelete = '0'";
            DataTable dt1 = ConnectSQL.dbConnection.FillData(str1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                dssv.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    SinhVien sv = new SinhVien();
                    sv.MSV = dt1.Rows[i]["StudentCode"].ToString();
                    sv.Email = dt1.Rows[i]["Email"].ToString();
                    dssv.Add(sv);
                }
            }
        }


        private void SaveNewSQL()
        {
            try
            {
                string insertCMD = "insert into tblQLSV values";

                List<string> insertCMDs = new List<string>();

                string[] insertCMD_array = new string[1000];
                int j = 0, i = 1;
                List<string> test = new List<string>();


                for (int k = 0; k < dgvQLSV.Rows.Count; k++)
                {
                    DataGridViewRow row = dgvQLSV.Rows[k];
                    string StudentID = Guid.NewGuid().ToString();
                    string stt = dgvQLSV.Rows[k].Cells["STT"].Value.ToString();
                    string hoDem = dgvQLSV.Rows[k].Cells["Last Name"].Value.ToString();
                    string ten = dgvQLSV.Rows[k].Cells["First Name"].Value.ToString();
                    string email = dgvQLSV.Rows[k].Cells["Email"].Value.ToString();
                    string msv = dgvQLSV.Rows[k].Cells["Identifier Value"].Value.ToString();
                    string phone = dgvQLSV.Rows[k].Cells["Phone Number"].Value.ToString();
                    string cardID = dgvQLSV.Rows[k].Cells["User Id"].Value.ToString();
                    string note = dgvQLSV.Rows[k].Cells["User Groups"].Value.ToString();

                    if (i <= (j + 1) * 1000)
                    {
                        if (i % 1000 == 0)
                        {
                            int x = 0;
                        }
                        string str = $"(N'{stt}',N'{hoDem}',N'{ten}',N'{email}',N'{msv}',N'{phone}',N'{cardID}',N'{note}','0','0', '{StudentID}')";
                        insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = str;
                    }
                    else
                    {
                        insertCMDs.Add(insertCMD + string.Join(",", insertCMD_array));
                        insertCMD_array = new string[1000];
                        j++;
                        string str = $"(N'{stt}',N'{hoDem}',N'{ten}',N'{email}',N'{msv}',N'{phone}',N'{cardID}',N'{note}','0','0', '{StudentID}')";
                        insertCMD_array[0] = str;
                    }
                    i++;
                }

                if (insertCMDs.Count < j + 1)
                {
                    insertCMDs.Add(insertCMD + string.Join(",", insertCMD_array.Where(x => !string.IsNullOrEmpty(x)).ToArray()));
                }

                bool isAllSuccess = true;
                foreach (string _insertCMD in insertCMDs)
                {
                    if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                    {
                        if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                        {
                            isAllSuccess = false;
                            break;
                        }
                    }
                }
                if (isAllSuccess)
                {
                    MessageBox.Show("ImPort thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    ConnectSQL.dbConnection.ExecuteCommand("DELETE tblWaitingControlCard");
                    MessageBox.Show("Kết Nối Tới Server Không Ổn Định, Hãy Kiểm Tra Lại");
                    return;
                }


                ////KIEN
                ////ConnectSQL.dbConnection.ExecuteCommand("delete from tblQLSV");
                //string StudentID = ""; //Guid.NewGuid().ToString();
                //for (int i = 0; i <= dgvQLSV.Rows.Count - 1; i++)
                //{
                //    StudentID = Guid.NewGuid().ToString();
                //    string stt = dgvQLSV.Rows[i].Cells["STT"].Value.ToString();
                //    string hoDem = dgvQLSV.Rows[i].Cells["Last Name"].Value.ToString();
                //    string ten = dgvQLSV.Rows[i].Cells["First Name"].Value.ToString();
                //    string email = dgvQLSV.Rows[i].Cells["Email"].Value.ToString();
                //    string msv = dgvQLSV.Rows[i].Cells["Identifier Value"].Value.ToString();
                //    string phone = dgvQLSV.Rows[i].Cells["Phone Number"].Value.ToString();
                //    string cardID = dgvQLSV.Rows[i].Cells["User Id"].Value.ToString();
                //    string note = dgvQLSV.Rows[i].Cells["User Groups"].Value.ToString();
                //    //string str = $"insert into tblQLSV values(N'" + dgvQLSV.Rows[i].Cells["STT"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Họ đệm"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Tên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Email"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Mã sinh viên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Số điện thoại"].Value + "',N'" + dgvQLSV.Rows[i].Cells["ID Card"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Ghi chú"].Value + "','0','0','" + StudentID + "')";

                //    //string stt = dgvQLSV.Rows[i].Cells[0].Value.ToString();
                //    //string hoDem = dgvQLSV.Rows[i].Cells[1].Value.ToString();
                //    //string ten = dgvQLSV.Rows[i].Cells[2].Value.ToString();
                //    //string email = dgvQLSV.Rows[i].Cells[3].Value.ToString();
                //    //string msv = dgvQLSV.Rows[i].Cells[4].ToString();
                //    //string phone = dgvQLSV.Rows[i].Cells[5].ToString();
                //    //string cardID = dgvQLSV.Rows[i].Cells[6].ToString();
                //    //string note = dgvQLSV.Rows[i].Cells[7].ToString();
                //    string str = $"insert into tblQLSV values(N'{stt}',N'{hoDem}',N'{ten}',N'{email}',N'{msv}',N'{phone}',N'{cardID}',N'{note}','0','0', '{StudentID}')";

                //    ConnectSQL.dbConnection.ExecuteCommand(str);
                //}
                LoadDGV();
                //MessageBox.Show("Đã lưu dữ liệu","Import",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu", "SaveNewSQL", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        DataTable dtSaveSQL = new DataTable();
        private void SaveNewSQL2()
        {
            try
            {
                string insertCMD = "insert into tblQLSV values";

                List<string> insertCMDs = new List<string>();

                string[] insertCMD_array = new string[1000];
                int j = 0, i = 1;
                List<string> test = new List<string>();

                if(dtSaveSQL.Rows.Count == 0)
                {
                    return;
                }

                for (int k = 0; k < dtSaveSQL.Rows.Count; k++)
                {
                    //DataGridViewRow row = dtSaveSQL.Rows[k];
                    string StudentID = Guid.NewGuid().ToString();
                    string stt = dtSaveSQL.Rows[k]["STT"].ToString();
                    string hoDem = dtSaveSQL.Rows[k]["Surname"].ToString();
                    string ten = dtSaveSQL.Rows[k]["Name"].ToString();
                    string email = dtSaveSQL.Rows[k]["Email"].ToString();
                    string msv = dtSaveSQL.Rows[k]["StudentCode"].ToString();
                    string phone = dtSaveSQL.Rows[k]["PhoneNumber"].ToString();
                    string cardID = dtSaveSQL.Rows[k]["CardID"].ToString();
                    string note = dtSaveSQL.Rows[k]["Note"].ToString();

                    if (i <= (j + 1) * 1000)
                    {
                        if (i % 1000 == 0)
                        {
                            int x = 0;
                        }
                        string str = $"(N'{stt}',N'{hoDem}',N'{ten}',N'{email}',N'{msv}',N'{phone}',N'{cardID}',N'{note}','0','0', '{StudentID}')";
                        insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = str;
                    }
                    else
                    {
                        insertCMDs.Add(insertCMD + string.Join(",", insertCMD_array));
                        insertCMD_array = new string[1000];
                        j++;
                        string str = $"(N'{stt}',N'{hoDem}',N'{ten}',N'{email}',N'{msv}',N'{phone}',N'{cardID}',N'{note}','0','0', '{StudentID}')";
                        insertCMD_array[0] = str;
                    }
                    i++;
                }

                if (insertCMDs.Count < j + 1)
                {
                    insertCMDs.Add(insertCMD + string.Join(",", insertCMD_array.Where(x => !string.IsNullOrEmpty(x)).ToArray()));
                }

                bool isAllSuccess = true;
                foreach (string _insertCMD in insertCMDs)
                {
                    if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                    {
                        if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                        {
                            isAllSuccess = false;
                            break;
                        }
                    }
                }
                if (isAllSuccess)
                { 
                    MessageBox.Show("ImPort thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    ConnectSQL.dbConnection.ExecuteCommand("DELETE tblWaitingControlCard");
                    MessageBox.Show("Kết Nối Tới Server Không Ổn Định, Hãy Kiểm Tra Lại");
                    return;
                }

                //LoadDGV();
                //MessageBox.Show("Đã lưu dữ liệu","Import",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu", "SaveNewSQL2", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            //try
            //{
            //    //ConnectSQL.dbConnection.ExecuteCommand("delete from tblQLSV");

            //    for (int i = 0; i <= dtSaveSQL.Rows.Count - 1; i++)
            //    {
            //        string StudentID = Guid.NewGuid().ToString();
            //        string stt = dtSaveSQL.Rows[i]["STT"].ToString();
            //        string hoDem = dtSaveSQL.Rows[i]["Surname"].ToString();
            //        string ten = dtSaveSQL.Rows[i]["Name"].ToString();
            //        string email = dtSaveSQL.Rows[i]["Email"].ToString();
            //        string msv = dtSaveSQL.Rows[i]["StudentCode"].ToString();
            //        string phone = dtSaveSQL.Rows[i]["PhoneNumber"].ToString();
            //        string cardID = dtSaveSQL.Rows[i]["CardID"].ToString();
            //        string note = dtSaveSQL.Rows[i]["Note"].ToString();
            //        //string str = $"insert into tblQLSV values(N'" + dgvQLSV.Rows[i].Cells["STT"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Họ đệm"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Tên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Email"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Mã sinh viên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Số điện thoại"].Value + "',N'" + dgvQLSV.Rows[i].Cells["ID Card"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Ghi chú"].Value + "','0','0','" + StudentID + "')";
            //        string str = $"insert into tblQLSV values(N'" + stt + "',N'" + hoDem + "',N'" + ten + "',N'" + email + "',N'" + msv + "',N'" + phone + "',N'" + cardID + "',N'" + note + "','0','0','" + StudentID + "')";

            //        ConnectSQL.dbConnection.ExecuteCommand(str);

            //    }
            //    //LoadDGV();

            //    //MessageBox.Show("Đã lưu dữ liệu", "Import", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    MessageBox.Show("Lỗi Save SQL2");
            //}
        }
        private async void LoadDGV()
        {
            await Task.Run(new Action(() =>
            {
                string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[StudentID], '0' as IsRed FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                // Load lại STT
                int index = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = index;
                    index++;
                }
                dgvQLSV.Invoke(new Action(() =>
                {
                    dgvQLSV.DataSource = dt;
                    //if (dgvQLSV.Rows.Count > 0)
                    //{
                    //    //dgvQLSV.CurrentCell = dgvQLSV.Rows[0].Cells["STT"];
                    //}
                    dgvQLSV.RowsDefaultCellStyle.BackColor = DefaultBackColor;
                    dgvQLSV.RowsDefaultCellStyle.ForeColor = DefaultForeColor;
                    dgvQLSV.Columns["Note"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvQLSV.Columns["StudentID"].Visible = false;
                    dgvQLSV.Columns["IsRed"].Visible = false;
                }));
                isVisibleRed = false;
                isLocTrung = false;
                lblCount.Invoke(new Action(() =>
                {
                    lblCount.Visible = false;
                }));
                

                ckbDuplicate.Invoke(new Action(() =>
                {
                    ckbDuplicate.Visible = isVisibleRed;
                }));
                picDataRedTrung.Invoke(new Action(() =>
                {
                    picDataRedTrung.Visible = isVisibleRed;
                }));
            }));
        }
        private void LoadSTTandRed()
        {
            try
            {
                DataTable dts = (DataTable)dgvQLSV.DataSource;
                int index = 1;
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    dts.Rows[i][0] = index;
                    index++;

                    string isRedRow = dgvQLSV.Rows[i].Cells["IsRed"]?.Value?.ToString() ?? "";
                    if (isRedRow == "1")
                    {
                        isVisibleRed = true;
                    }
                    if (isVisibleRed)
                    {
                        ckbDuplicate.Visible = true;
                        picDataRedTrung.Visible = true;
                    }
                    else
                    {
                        ckbDuplicate.Visible = false;
                        picDataRedTrung.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi loadDGV Import2","");
            }
            
        }
        private void LoadDGV_NotCurrentCell()
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
            //if (dgvQLSV.Rows.Count > 0)
            //{
            //    dgvQLSV.CurrentCell = dgvQLSV.Rows[0].Cells[0];
            //    //dgvQLSV_CellContentClick(null, null);
            //}
        }

        bool isExport = false;
        private void btnExport_Click(object sender, EventArgs e)
        {
            isExport = true;
            DataTable dtExport = new DataTable();

            //dtExport.Columns.Add("STT");
            //dtExport.Columns.Add("Surname");
            //dtExport.Columns.Add("Name");
            //dtExport.Columns.Add("Email");
            //dtExport.Columns.Add("StudentCode");
            //dtExport.Columns.Add("PhoneNumber");
            //dtExport.Columns.Add("CardID");
            //dtExport.Columns.Add("Note");
            //dtExport.Columns.Add("IsDelete");
            //dtExport.Columns.Add("StudentId");
            //dtExport.Columns.Add("IsRed");

            dtExport = (DataTable)dgvQLSV.DataSource;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "ExportExcel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExcelReport.ExportExcel2(saveFileDialog.FileName, dtExport, "Bảng sinh viên", "Quản lý sinh viên");
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OKCancel);
                    LogHelper.LogUser("Page Account Management", $"Người dùng Export Excel thành công", Application.StartupPath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Khong thanh cong");
                }
            }
            dgvQLSV.DataSource = dtExport;
            isExport = false;
        }
        bool isDataRed = false;   // Biến xác định dữ liệu trùng lặp 
        public bool isVisibleRed = false;
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
            string Notifi = dgvQLSV.Rows[i].Cells[10].Value.ToString();
            txbStudentID.Texts = dgvQLSV.Rows[i].Cells[9].Value.ToString();
            studentCodeMSV = txbMSV.Texts;
            if (Notifi == "1")
            {
                txbIsDelete.Texts = "Dữ liệu trùng lặp";
                txbIsDelete.ForeColor = Color.Red;
                picDataRed.Visible = true;
                isDataRed = true;
            }
            else
            {

                txbIsDelete.Texts = "Dữ liệu đang ghi";
                txbIsDelete.ForeColor = Color.Black;
                picDataRed.Visible = false;
                isDataRed = false;
            }
        }


        

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            string str = "select * from tblQLSV where IsDelete = '0'";
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
                btnSua.Enabled = true;
            }
            // Add vao combobox
            for (int i = 0; i < TypeLooking.Length; i++)
            {
                cbbTypeLook.Items.Add(TypeLooking[i]);
            }
            cbbTypeLook.SelectedIndex = 2;

            txbTimKiem.Texts = Mifare.NameLooking();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Student Management", "Người dùng nhấn Add ", Application.StartupPath);
            if (isVisibleRed)
            {
                DialogResult result = MessageBox.Show("Dữ liệu trùng lặp sẽ bị xóa, Bạn có muốn tiếp tục không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    frmAddSV f = new frmAddSV(SetValue);
                    f.ShowDialog();


                    if (f.DialogResult == DialogResult.OK)
                    {
                        LoadDGV();
                       
                    }
                }
            }
            else
            {
                frmAddSV f = new frmAddSV(SetValue);
                f.ShowDialog();


                if (f.DialogResult == DialogResult.OK)
                {
                    LoadDGV();
                    
                }
            }

        }
        // Hàm truyền nhận Deletegate cho Form AddSV
        private void SetValue(string value)
        {
            this.txbStudentID.Texts = value;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (isVisibleRed)
            {
                LogHelper.LogUser("Page Student Management", "Người dùng nhấn Edit ", Application.StartupPath);
                DialogResult result = MessageBox.Show("Dữ liệu trùng lặp sẽ bị xóa, Bạn có muốn tiếp tục không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (txbCardID.Texts == "" && txbHoDem.Texts == "" && txbTen.Texts == "" && txbEmail.Texts == "" && txbMSV.Texts == "" && txbPhone.Texts == "" && txbNote.Texts == "" && txbStudentID.Texts == "")
                    {
                        MessageBox.Show("Mời chọn dữ liệu cần sửa trước", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        return;
                    }
                    frmEditSV f = new frmEditSV(txbCardID.Texts, txbHoDem.Texts, txbTen.Texts, txbEmail.Texts, txbMSV.Texts, txbPhone.Texts, txbNote.Texts, txbStudentID.Texts);
                    f.ShowDialog();

                    if (f.DialogResult == DialogResult.OK)
                    {
                        LoadDGV_NotCurrentCell();
                    }
                }

            }
            else
            {
                if (txbCardID.Texts == "" && txbHoDem.Texts == "" && txbTen.Texts == "" && txbEmail.Texts == "" && txbMSV.Texts == "" && txbPhone.Texts == "" && txbNote.Texts == "" && txbStudentID.Texts == "")
                {
                    MessageBox.Show("Mời chọn dữ liệu cần sửa trước", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }
                frmEditSV f = new frmEditSV(txbCardID.Texts, txbHoDem.Texts, txbTen.Texts, txbEmail.Texts, txbMSV.Texts, txbPhone.Texts, txbNote.Texts, txbStudentID.Texts);
                f.ShowDialog();

                if (f.DialogResult == DialogResult.OK)
                {
                    LoadDGV();

                }
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
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("Thông tin sinh viên này đã có dữ liệu mới", "không thể khôi phục");
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
            //if (ckbIsDelete.GetItemChecked(0) && ckbIsDelete.GetItemChecked(1))
            //{
            //    //dgvQLSV.DataSource
            //    string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where StudentCode like '%" + txbTimKiem.Texts + "%'";
            //    DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            //    dgvQLSV.DataSource = dt;
            //}
            //else if (ckbIsDelete.GetItemChecked(0))
            //{
            //    string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0' and  StudentCode like '%" + txbTimKiem.Texts + "%'";
            //    DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            //    dgvQLSV.DataSource = dt;
            //}
            //else if (ckbIsDelete.GetItemChecked(1))
            //{
            //    string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '1' and  StudentCode like '%" + txbTimKiem.Texts + "%'";
            //    DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            //    dgvQLSV.DataSource = dt;
            //}
            //else
            //{
            //    string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where StudentCode like '%" + txbTimKiem.Texts + "%'";
            //    DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            //    dgvQLSV.DataSource = dt;
            //}
        }

        private void ckbIsDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ckbIsDelete.GetItemChecked(0) && ckbIsDelete.GetItemChecked(1))
            //{
            //    LoadDGV();
            //}
            //else if (ckbIsDelete.GetItemChecked(0))
            //{
            //    string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0'";
            //    DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            //    dgvQLSV.DataSource = dt;
            //}
            //else if (ckbIsDelete.GetItemChecked(1))
            //{
            //    string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],StudentID FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '1'";
            //    DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            //    dgvQLSV.DataSource = dt;
            //}
            //else
            //{
            //    LoadDGV();
            //}
        }

        private void dgvQLSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            
            {
                if (!isExport)
                {
                    if (dgvQLSV != null && dgvQLSV.Rows.Count > 0)
                    {
                        
                        for (int i = 0; i <= dgvQLSV.Rows.Count - 1; i++)
                        {
                            // Trỏ hàng hiện tại đến hàng theo ID textbox 
                            string studentID = txbStudentID.Texts;
                            string STUDENTID = dgvQLSV.Rows[i].Cells["StudentID"]?.Value?.ToString() ?? "";
                            if (studentID == STUDENTID)
                            {
                                dgvQLSV.CurrentCell = dgvQLSV.Rows[i].Cells[0];
                                //break;
                            }

                            string isRedRow = dgvQLSV.Rows[i].Cells["IsRed"]?.Value?.ToString() ?? "";
                            if (isRedRow == "1")
                            {
                                dgvQLSV.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                                dgvQLSV.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDeleteRemove_Click(object sender, EventArgs e)
        {
            if (isVisibleRed)
            {
                DialogResult result11 = MessageBox.Show("Dữ liệu trùng lặp sẽ bị xóa, Bạn có muốn tiếp tục không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result11 == DialogResult.Yes)
                {
                    string access = Properties.Settings.Default.AccessPermission.Trim();
                    if (access == "SuperAdmin" || access == "Admin")
                    {
                        if (isDataRed == true)
                        {
                            MessageBox.Show("Dữ liệu sẽ tự động xóa sau khi rời trang", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(txbStudentID.Texts))
                        {
                            MessageBox.Show("Hãy chọn dữ liệu để xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            return;
                        }
                        //string creat = $"select * from tblQLSV where StudentCode = '{txbMSV.Texts}' and IsDelete = '0'";
                        //DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                        if (isDataRed == false)
                        {
                            DialogResult result = MessageBox.Show("Xác nhận xóa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                string insertCMD = "update tblQLSV set IsDelete = '1' where ";

                                List<string> insertCMDs = new List<string>();

                                string[] insertCMD_array = new string[1000];
                                int j = 0, i = 1;
                                List<string> test = new List<string>();
                                List<string> ListMSV = new List<string>();
                                foreach (DataGridViewRow row in dgvQLSV.SelectedRows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        if (i <= (j + 1) * 1000)
                                        {
                                            if (i % 1000 == 0)
                                            {
                                                int x = 0;
                                            }
                                            string id = row.Cells["StudentID"].Value.ToString();
                                            string str = $"StudentID = '{id}'";
                                            insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = str;
                                            
                                            string msv = row.Cells["StudentCode"].Value.ToString();
                                            ListMSV.Add(msv);

                                        }
                                        else
                                        {
                                            insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array));
                                            insertCMD_array = new string[1000];
                                            j++;
                                            string id = row.Cells["StudentID"].Value.ToString();
                                            string str = $"StudentID = '{id}'";
                                            insertCMD_array[0] = str;

                                            string msv = row.Cells["StudentCode"].Value.ToString();
                                            ListMSV.Add(msv);
                                        }
                                        i++;
                                        
                                    }
                                }
                                if (insertCMDs.Count < j + 1)
                                {
                                    insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array.Where(x => !string.IsNullOrEmpty(x)).ToArray()));
                                }

                                bool isAllSuccess = true;
                                foreach (string _insertCMD in insertCMDs)
                                {
                                    if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                                    {
                                        if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                                        {
                                            isAllSuccess = false;
                                            break;
                                        }
                                    }
                                }
                                LoadDGV();

                                if (isAllSuccess)
                                {
                                    if (Mifare.InsertLog1000(ListMSV, "1"))
                                    {
                                        MessageBox.Show("Delete thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lỗi save Log", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    }

                                }
                                else
                                {
                                    //ConnectSQL.dbConnection.ExecuteCommand("DELETE tblWaitingControlCard");
                                    MessageBox.Show("Kết Nối Tới Server Không Ổn Định, Hãy Kiểm Tra Lại");
                                    LogHelper.LogUser("Page Deleted Student List", $"Người dùng xóa thất bại dữ liệu", Application.StartupPath);

                                    return;
                                }

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
            }
            else
            {
                string access = Properties.Settings.Default.AccessPermission.Trim();
                if (access == "SuperAdmin" || access == "Admin")
                {
                    //if (string.IsNullOrEmpty(txbStudentID.Texts))
                    //{
                    //    MessageBox.Show("Hãy chọn dữ liệu để xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //    return;
                    //}
                    if (isDataRed == false)
                    {
                        DialogResult result = MessageBox.Show("Xác nhận xóa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            string insertCMD = "update tblQLSV set IsDelete = '1' where ";

                            List<string> insertCMDs = new List<string>();

                            string[] insertCMD_array = new string[1000];
                            int j = 0, i = 1;
                            List<string> test = new List<string>();
                            List<string> ListMSV = new List<string>();
                            foreach (DataGridViewRow row in dgvQLSV.SelectedRows)
                            {
                                if (!row.IsNewRow)
                                {
                                    if (i <= (j + 1) * 1000)
                                    {
                                        if (i % 1000 == 0)
                                        {
                                            int x = 0;
                                        }
                                        string id = row.Cells["StudentID"].Value.ToString();
                                        string str = $"StudentID = '{id}'";
                                        insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = str;

                                        string msv = row.Cells["StudentCode"].Value.ToString();
                                        ListMSV.Add(msv);
                                    }
                                    else
                                    {
                                        insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array));
                                        insertCMD_array = new string[1000];
                                        j++;
                                        string id = row.Cells["StudentID"].Value.ToString();
                                        string str = $"StudentID = '{id}'";
                                        insertCMD_array[0] = str;

                                        string msv = row.Cells["StudentCode"].Value.ToString();
                                        ListMSV.Add(msv);
                                    }
                                    i++;

                                }
                            }
                            if (insertCMDs.Count < j + 1)
                            {
                                insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array.Where(x => !string.IsNullOrEmpty(x)).ToArray()));
                            }

                            bool isAllSuccess = true;
                            foreach (string _insertCMD in insertCMDs)
                            {
                                if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                                {
                                    if (!ConnectSQL.dbConnection.ExecuteCommand(_insertCMD))
                                    {
                                        isAllSuccess = false;
                                        break;
                                    }
                                }
                            }
                            LoadDGV();

                            if (isAllSuccess)
                            {
                                if (Mifare.InsertLog1000(ListMSV, "1"))
                                {
                                    MessageBox.Show("Delete thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi save Log", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                //ConnectSQL.dbConnection.ExecuteCommand("DELETE tblWaitingControlCard");
                                MessageBox.Show("Kết Nối Tới Server Không Ổn Định, Hãy Kiểm Tra Lại");
                                return;
                            }

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
                }
            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
        private void SetValueListDelete(String value)
        {
            this.txbStudentID.Text = value;
        }
        private void btnListDelete_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Student Management", "Người dùng nhấn mở Trask", Application.StartupPath);
            if (isVisibleRed)
            {
                DialogResult result = MessageBox.Show("Dữ liệu trùng lặp sẽ bị xóa, Bạn có muốn tiếp tục không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    frmListDelete f = new frmListDelete();
                    f.ShowDialog();

                    if (f.DialogResult == DialogResult.Cancel)
                    {
                        LoadDGV();
                    }
                }
            }
            else
            {
                frmListDelete f = new frmListDelete();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Cancel)
                {
                    LoadDGV();
                }
            }
        }
        public DataTable dtNow = new DataTable();
        int n = 0;

        bool isLocTrung = false;
        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {


            //if (rjToggleButton1.Checked)
            //{
            //    isLocTrung = true;
            //    if (n == 0)
            //    {
            //        n++;
            //        dtNow.Columns.Add("STT");
            //        dtNow.Columns.Add("Surname");
            //        dtNow.Columns.Add("Name");
            //        dtNow.Columns.Add("Email");
            //        dtNow.Columns.Add("StudentCode");
            //        dtNow.Columns.Add("PhoneNumber");
            //        dtNow.Columns.Add("CardID");
            //        dtNow.Columns.Add("Note");
            //        dtNow.Columns.Add("IsDelete");
            //        dtNow.Columns.Add("StudentId");
            //        dtNow.Columns.Add("IsRed");
            //    }
            //    dtNow = (DataTable)dgvQLSV.DataSource;

            //    if (dtRed.Rows.Count > 0)
            //    {
            //        int index = 0;
            //        for (int i = 0; i < dtRed.Rows.Count; i++)
            //        {
            //            dtRed.Rows[i][0] = index;
            //            index++;
            //        }
            //    }
            //    dgvQLSV.DataSource = dtRed;

            //    dgvQLSV.RowsDefaultCellStyle.BackColor = Color.DarkRed;
            //    dgvQLSV.RowsDefaultCellStyle.ForeColor = Color.White;
            //}
            //else
            //{
            //    isLocTrung = false;
            //    dgvQLSV.RowsDefaultCellStyle.BackColor = DefaultBackColor;
            //    dgvQLSV.RowsDefaultCellStyle.ForeColor = DefaultForeColor;

            //    dgvQLSV.DataSource = dtNow;
            //}
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("STT");
            dtResult.Columns.Add("Surname");
            dtResult.Columns.Add("Name");
            dtResult.Columns.Add("Email");
            dtResult.Columns.Add("StudentCode");
            dtResult.Columns.Add("PhoneNumber");
            dtResult.Columns.Add("CardID");
            dtResult.Columns.Add("Note");
            dtResult.Columns.Add("IsDelete");
            dtResult.Columns.Add("StudentId");
            dtResult.Columns.Add("IsRed");

            //DataTable dtResult = dtRed.CreateNewDataTable();

            //string creat = $"SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[StudentID], '0' as IsRed FROM [VinUniver].[dbo].[tblQLSV] where StudentCode like '%{txbTimKiem.Texts}%' and IsDelete = 0";
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[StudentID], '0' as IsRed ");
            sb.Append("FROM [VinUniver].[dbo].[tblQLSV] ");
            sb.Append("where IsDelete = '0' ");

            if (cbbTypeLook.Texts.Trim() == TypeLooking[0])  // Last Name
            {
                sb.Append("and Surname like '%" + txbTimKiem.Texts + "%' ");
            }
            if (cbbTypeLook.Texts.Trim() == TypeLooking[1]) // First Name
            {
                sb.Append("and Name like '%" + txbTimKiem.Texts + "%' ");
            }
            if (cbbTypeLook.Texts.Trim() == TypeLooking[2])  // MSV
            {
                sb.Append("and StudentCode like '%" + txbTimKiem.Texts + "%' ");
            }
            if (cbbTypeLook.Texts.Trim() == TypeLooking[3]) // Email
            {
                sb.Append("and Email like '%" + txbTimKiem.Texts + "%' ");
            }
            if (cbbTypeLook.Texts.Trim() == TypeLooking[4]) // Phone
            {
                sb.Append("and PhoneNumber like '%" + txbTimKiem.Texts + "%' ");
            }

            DataTable dtSQL = ConnectSQL.dbConnection.FillData(sb.ToString());
            foreach (DataRow item in dtSQL.Rows)
            {
                DataRow dr = item.CloneDataRow(dtResult);
                dtResult.Rows.Add(dr);
            }

            if (isVisibleRed == true)
            {
                foreach (DataRow dataRow in dtRed.Rows)
                {
                    string studentCode = dataRow["StudentCode"].ToString();

                    if (studentCode.ToLower().Contains(txbTimKiem.Texts.ToLower()))
                    {
                        DataRow dr = dataRow.CloneDataRow(dtResult);
                        dtResult.Rows.Add(dr);
                    }
                }
            }
            lblCount.Visible = true;
            lblCount.Text = Mifare.Sort_STT(dtResult);   // Xắp sếp lại STT và trả về count 

            dgvQLSV.DataSource = dtResult;
            LogHelper.LogUser("Page Account Management", $"Người dùng tìm kiếm với nội dung: {txbTimKiem.Texts}", Application.StartupPath);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvQLSV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picDataRed_Click(object sender, EventArgs e)
        {
            
        }

        private void picDataRedTrung_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

       

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            DataTable dts = new DataTable();
            dts = (DataTable)dgvQLSV.DataSource;
           // dts = null;
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                DataRow row = dts.Rows[0];
                dts.Rows.Remove(row);
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                chk.Image = Properties.Resources._checked;
                dgvQLSV.SelectAll();
            }

            else
                chk.Image = Properties.Resources._unchecked;
        }

        private void ckbDuplicate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                chk.Image = Properties.Resources._checked;
                isLocTrung = true;
              
                dtNow = (DataTable)dgvQLSV.DataSource;
                 
                if (dtRed.Rows.Count > 0)
                {
                    int index = 0;
                    for (int i = 0; i < dtRed.Rows.Count; i++)
                    {
                        dtRed.Rows[i][0] = index;
                        index++;
                    }

                    dgvQLSV.DataSource = dtRed;

                    dgvQLSV.RowsDefaultCellStyle.BackColor = Color.DarkRed;
                    dgvQLSV.RowsDefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    //Thong bao
                }
            }
            else
            {
                chk.Image = Properties.Resources._unchecked;
                isLocTrung = false;
                if (isVisibleRed)
                {
                    dgvQLSV.RowsDefaultCellStyle.BackColor = DefaultBackColor;
                    dgvQLSV.RowsDefaultCellStyle.ForeColor = DefaultForeColor;

                    dgvQLSV.DataSource = dtNow;
                }
                else
                {
                    LoadDGV();
                }
            }
        }

        private void txbTimKiem_Enter(object sender, EventArgs e)
        {
            if (txbTimKiem.Texts == Mifare.NameLooking())
            {
                txbTimKiem.Texts = "";
                txbTimKiem.ForeColor = Color.Black;
            }
        }

        private void txbTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmQLSV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void frmQLSV_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
