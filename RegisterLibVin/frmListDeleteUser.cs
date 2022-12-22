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
    public partial class frmListDeleteUser : Form
    {
        public frmListDeleteUser()
        {
            InitializeComponent();
        }

        private void frmListDeleteUser_Load(object sender, EventArgs e)
        {
            string str = "select * from tblUser where IsDelete = '1'";
            DataTable dt = ConnectSQL.dbConnection.FillData(str);
            if (dt != null && dt.Rows.Count > 0)
            {
                dgvListDeleteUser.Visible = true;
                pictureBox1.Visible = false;
                ckbSelectAll.Visible = true;
                LoadDGV();
            }
            else
            {
                dgvListDeleteUser.Visible = false;
                pictureBox1.Visible = true;
                ckbSelectAll.Visible = false;
            }
        }
        private void LoadDGV()
        {
            string creat = "SELECT [FullName],[UserName],[Password],[AccessPermission],[IsLock],[UserID] FROM [VinUniver].[dbo].[tblUser] where IsDelete = '1'";
            DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            dgvListDeleteUser.DataSource = dt;
        }

        private void dgvListDeleteUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvListDeleteUser.CurrentRow.Index;
            txbUserID.Texts = dgvListDeleteUser.Rows[i].Cells["UserID"].Value.ToString();
        }

        private void btnDeleteRemove_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                //if (string.IsNullOrEmpty(txbUserID.Texts))
                //{
                //    MessageBox.Show("Mời chọn tài khoản trước khi xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //    return;
                //}
                btnDeleteRemove.Enabled = true;

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bỏ dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string insertCMD = "Delete from tblUser where ";
                    List<string> ListAccount = new List<string>();
                    List<string> insertCMDs = new List<string>();

                    string[] insertCMD_array = new string[1000];
                    int j = 0, i = 1;
                    List<string> test = new List<string>();

                    foreach (DataGridViewRow row in dgvListDeleteUser.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (i <= (j + 1) * 1000)
                            {
                                if (i % 1000 == 0)
                                {
                                    int x = 0;
                                }
                                string id = row.Cells["UserID"].Value.ToString();
                                string str = $"UserID = '{id}'";
                                insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = str;

                                string fullName = row.Cells["FullName"].Value.ToString();
                                ListAccount.Add(fullName);
                            }
                            else
                            {
                                insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array));
                                insertCMD_array = new string[1000];
                                j++;
                                string id = row.Cells["UserID"].Value.ToString();
                                string str = $"UserID = '{id}'";
                                insertCMD_array[0] = str;

                                string fullName = row.Cells["FullName"].Value.ToString();
                                ListAccount.Add(fullName);
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
                        if (Mifare.InsertLog1000(ListAccount, "3"))
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
                //btnDeleteRemove.Enabled = false;
            }
        }
        private List<string> ListUser()
        {
            List<string> List = new List<string>();
            string str1 = "select * from tblUser where IsDelete = '0'";
            DataTable dt1 = ConnectSQL.dbConnection.FillData(str1);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string userName = dt1.Rows[i]["UserName"].ToString();
                    List.Add(userName);
                }
            }
            return List;
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            DialogResult rlt = MessageBox.Show("Bạn có muốn khôi phục lại dữ liệu sinh viên không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rlt == DialogResult.Yes)
            {
                // Lấy danh sách gồm MSV, Email từ DB 
                List<string> ListUserName = ListUser();
                // Bắt đâù update 
                string insertCMD = "update tblUser set IsDelete = '0' where ";

                List<string> insertCMDs = new List<string>();

                string[] insertCMD_array = new string[1000];
                int j = 0, i = 1;
                //List<string> msvQLSV = new List<string>();
                List<string> ListName = new List<string>();
                bool isHaveData = false;
                int countTrung = 0;
                foreach (DataGridViewRow row in dgvListDeleteUser.SelectedRows)
                {
                    string user = "";
                    string name = "";
                    if (!row.IsNewRow)
                    {
                        user = row.Cells["UserName"].Value.ToString();
                        // Dữ liệu trùng là dữ liệu có MSV trùng và # rỗng
                        // Nếu MSV trùng = rỗng thì check Email trùng mới gọi là trùng
                        // Nếu trùng trả về True
                        if (CheckTrung(user, ListUserName))
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
                                string id = row.Cells["UserID"].Value.ToString();
                                string strID = $"UserID = '{id}'";
                                insertCMD_array[i % 1000 == 0 ? 1000 - 1 : i % 1000 - 1] = strID;

                                name = row.Cells["FullName"].Value.ToString();
                                ListName.Add(name);
                            }
                            else
                            {
                                insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array));
                                insertCMD_array = new string[1000];
                                j++;
                                string id = row.Cells["UserID"].Value.ToString();
                                string strID = $"UserID = '{id}'";
                                insertCMD_array[0] = strID;

                                name = row.Cells["FullName"].Value.ToString();
                                ListName.Add(name);

                            }
                        }
                        i++;
                    }


                }

                if (isHaveData == false)
                {
                    if (countTrung != 0)
                    {
                        MessageBox.Show($"Tất cả {countTrung} dữ liệu trùng", "Không thể Restore", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
                    if (Mifare.InsertLog1000(ListName, "4"))
                    {
                        MessageBox.Show("Khôi phục dữ liệu thành công!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (countTrung != 0)
                        {
                            MessageBox.Show($"Phát hiện {countTrung} Account đã có trong hệ thống", "Dữ liệu trùng sẽ không thể Restore!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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










            //if (string.IsNullOrEmpty(txbUserID.Texts))
            //{
            //    MessageBox.Show("Hãy chọn dữ liệu muốn khôi phục", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //string str = $"update tblUser set IsDelete = '0' where UserID = '{txbUserID.Texts}'";
            //DialogResult result = MessageBox.Show("Xác nhận muốn khôi phục dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (result == DialogResult.Yes)
            //{
            //    if (ConnectSQL.dbConnection.ExecuteCommand(str))
            //    {
            //        LoadDGV();
            //        MessageBox.Show("Khôi phục thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //        this.DialogResult = DialogResult.Cancel;
            //    }
            //}
        }
        private static bool CheckTrung(string user, List<string> ListUser)
        {
            foreach (var User in ListUser)
            {
                if (user == User)
                {
                    return true;
                }
            }
            return false;
        }
        private void frmListDeleteUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked)
            {
                chk.Image = Properties.Resources._checked;
                dgvListDeleteUser.SelectAll();
            }

            else
                chk.Image = Properties.Resources._unchecked;
        }
    }
}
