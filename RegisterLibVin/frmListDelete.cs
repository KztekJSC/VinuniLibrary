using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace RegisterLibVin
{
    public partial class frmListDelete : Form
    {
        //public SendMessage send;
        public frmListDelete()
        {
            InitializeComponent();
        }
        //public frmListDelete(SendMessage sender)
        //{
        //    InitializeComponent();
        //    this.send = sender;
        //}
        private void frmListDelete_Load(object sender, EventArgs e)
        {
            string str = "select * from tblQLSV where IsDelete = '1'";
            DataTable dt = ConnectSQL.dbConnection.FillData(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvListDelete.Visible = true;
                pictureBox1.Visible = false;
                LoadDGV();
            }
            else
            {
                dgvListDelete.Visible = false;
                pictureBox1.Visible = true;
            }
        }
        private void LoadDGV()
        {
            string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[StudentID] FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '1'";
            DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = index;
                index++;
            }
            dgvListDelete.DataSource = dt;
            
            if (dgvListDelete.Rows.Count > 0)
            {
                //dgvListDelete.CurrentCell = dgvListDelete.Rows[0].Cells[0];
                //dgvListDelete_CellContentClick(null, null);
            }
        }

        private void btnDeleteRemove_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                //if (string.IsNullOrEmpty(txbStudentID.Texts))
                //{
                //    MessageBox.Show("Mời chọn tài khoản trước khi xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //    return;
                //}
                btnDeleteRemove.Enabled = true;

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bỏ dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string insertCMD = "Delete from tblQLSV where ";

                    List<string> insertCMDs = new List<string>();
                    List<string> ListMSV = new List<string>();
                    //string[] ListMSV = new string[1000];

                    string[] insertCMD_array = new string[1000];
                    int j = 0, i = 1;
                    List<string> test = new List<string>();

                    foreach (DataGridViewRow row in dgvListDelete.SelectedRows)
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
                                
                                // Thêm msv vào list để lưu vào Log
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

                                // Thêm msv vào list để lưu vào Log
                                string msv1 = row.Cells["StudentCode"].Value.ToString();
                                ListMSV.Add(msv1);
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
                        // Ghi thêm vào Log
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
                //btnDeleteRemove.Enabled = false;
            }
        }

        private void dgvListDelete_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvListDelete.CurrentRow.Index;
            txbMSV.Texts = dgvListDelete.Rows[i].Cells[4].Value.ToString();
            txbEmail.Texts = dgvListDelete.Rows[i].Cells[3].Value.ToString();
            string Notifi = dgvListDelete.Rows[i].Cells[8].Value.ToString();
            txbStudentID.Texts = dgvListDelete.Rows[i].Cells[9].Value.ToString();
        }
        private List<SinhVien> ClassSV()
        {
            List<SinhVien> DSSV = new List<SinhVien>();
            string str1 = "select * from tblQLSV where IsDelete = '0'";
            DataTable dt1 = ConnectSQL.dbConnection.FillData(str1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    SinhVien sv = new SinhVien();
                    sv.MSV = dt1.Rows[i]["StudentCode"].ToString();
                    sv.Email = dt1.Rows[i]["Email"].ToString();
                    DSSV.Add(sv);
                }
            }
            return DSSV;
        }
        
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            DialogResult rlt = MessageBox.Show("Bạn có muốn khôi phục lại dữ liệu sinh viên không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rlt == DialogResult.Yes)
            {
                // Lấy danh sách gồm MSV, Email từ DB 
                List<SinhVien> DSSV = ClassSV(); 
                // Bắt đâù update 
                string insertCMD = "update tblQLSV set IsDelete = '0' where ";

                List<string> insertCMDs = new List<string>();

                string[] insertCMD_array = new string[1000];
                int j = 0, i = 1;
                //List<string> msvQLSV = new List<string>();
                List<string> ListMSV = new List<string>();
                bool isHaveData = false;
                int countTrung = 0;
                foreach (DataGridViewRow row in dgvListDelete.SelectedRows)
                {
                    string msv = "";
                    string email = "";
                    if (!row.IsNewRow)
                    {
                        msv = row.Cells["StudentCode"].Value.ToString();
                        email = row.Cells["Email"].Value.ToString();
                        // Dữ liệu trùng là dữ liệu có MSV trùng và # rỗng
                        // Nếu MSV trùng = rỗng thì check Email trùng mới gọi là trùng
                        // Nếu trùng trả về True
                        if (CheckTrung(msv, email, DSSV))
                        {
                            countTrung++;
                            continue;
                        }
                        else
                        {
                            isHaveData = true;
                            // Ghép câu truy vấn 
                            if (i <= (j + 1) * 1000)
                            {
                                if (i % 1000 == 0)
                                {
                                    int x = 0;
                                }
                                string id = row.Cells["StudentID"].Value.ToString();
                                string strID = $"StudentID = '{id}'";
                                insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = strID;

                                msv = row.Cells["StudentCode"].Value.ToString();
                                ListMSV.Add(msv);
                            }
                            else
                            {
                                insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array));
                                insertCMD_array = new string[1000];
                                j++;
                                string id = row.Cells["StudentID"].Value.ToString();
                                string strID = $"StudentID = '{id}'";
                                insertCMD_array[0] = strID;

                                msv = row.Cells["StudentCode"].Value.ToString();
                                ListMSV.Add(msv);

                            }
                        }
                        i++;
                    }


                }
                
                if (isHaveData == false)
                {
                    if (countTrung != 0)
                    {
                        MessageBox.Show($"Tất cả {countTrung} dữ liệu trùng","Không thể Restore", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    return;
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
                    // Ghi thêm vào Log
                    if (Mifare.InsertLog1000(ListMSV, "2"))
                    {
                        MessageBox.Show("Khôi phục dữ liệu thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (countTrung != 0)
                        {
                            MessageBox.Show($"Phát hiện {countTrung} dữ liệu đã có trong hệ thống", "Dữ liệu trùng sẽ không thể Restore!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
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


            ///////////////////////
            //if (string.IsNullOrEmpty(txbStudentID.Texts))
            //{
            //    MessageBox.Show("Hãy chọn dữ liệu muốn khôi phục", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //string str = $"select * from tblQLSV where StudentCode = '{txbMSV.Texts}' and Email = '{txbEmail.Texts}' and IsDelete = '0'";
            //DataTable dt = ConnectSQL.dbConnection.FillData(str);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    MessageBox.Show("Thông tin sinh viên này đã có dữ liệu mới", "không thể khôi phục");
            //}
            //else
            //{
            //    string StudentID = Guid.NewGuid().ToString();
            //    StringBuilder sb1 = new StringBuilder();
            //    sb1.Append($"update tblQLSV set IsDelete = '0' ");
            //    sb1.Append($"where StudentID = '{txbStudentID.Texts}'");

            //    DialogResult result = MessageBox.Show("Xác nhận muốn khôi phục dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (result == DialogResult.Yes)
            //    {
            //        ConnectSQL.dbConnection.ExecuteCommand(sb1.ToString());
            //        LoadDGV();
            //    }
            //}
        }

        private static bool CheckTrung(string msv,string email, List<SinhVien> DSSV)
        {
            foreach (SinhVien sv in DSSV)
            {
                if (msv == sv.MSV)
                {
                    if(msv != "")
                    {
                        return true;
                    }
                    else   // Nếu trùng nhau = "" thì check thêm Email trùng mới gọi là trùng
                    {
                        if(email == sv.Email)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        


        private void frmListDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                chk.Image = Properties.Resources._checked;
                dgvListDelete.SelectAll();
            }

            else
                chk.Image = Properties.Resources._unchecked;
        }
    }
}
