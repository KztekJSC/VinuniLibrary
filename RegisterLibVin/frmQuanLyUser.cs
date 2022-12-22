using Futech.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmQuanLyUser : Form
    {

        private string[] TypeLooking = new string[]
        {
            "FullName","UserName","AccessPermission"
        };
        public frmQuanLyUser()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();

            dgvBookSV.MultiSelect = true;
            //dgvBookSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void frmEventBook_Load(object sender, EventArgs e)
        {
            GetDataToDGV();

            cbbType1.Items.Add("FullName");
            cbbType1.Items.Add("UserName");
            cbbType1.Items.Add("AccessPermission");

            cbbType1.SelectedIndex = 0;

            txbtimkiem.Texts = Mifare.NameLooking();
        }

        private void GetDataToDGV()
        {
            string getData = "select tblUser.FullName,UserName,Password,AccessPermission,IsLock,IsDelete,UserID from tblUser where IsDelete = 0";
            DataTable dt = ConnectSQL.dbConnection.FillData(getData);

            dgvBookSV.DataSource = dt;

            lblCount.Visible = false;
        }

        private void txbtimkiem__TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvBookSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvBookSV.CurrentRow.Index;
            txbFullName.Texts = dgvBookSV.Rows[i].Cells["FullName"].Value.ToString();
            txbUserName.Texts = dgvBookSV.Rows[i].Cells["UserName"].Value.ToString();
            txbPass.Texts = dgvBookSV.Rows[i].Cells["Password"].Value.ToString();
            txbQuyen.Texts = dgvBookSV.Rows[i].Cells["AccessPermission"].Value.ToString();
            txbUserID.Texts = dgvBookSV.Rows[i].Cells["UserID"].Value.ToString();

            if (string.IsNullOrEmpty(txbUserID.Texts))
            {
                return;
            }
            bool isLock = (bool)dgvBookSV.Rows[i].Cells["IsLock"].Value;
            btnEdit.Visible = !isLock;
            btnLock.Visible = !isLock;
            picLock.Visible = isLock;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn khóa tài khoản này", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string str1 = $"select * from tblUser where UserName = '{txbUserName.Texts}' and IsLock = '0'";
                DataTable dt = ConnectSQL.dbConnection.FillData(str1.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    string str2 = $"update tblUser set IsLock = '1' where UserName = '{txbUserName.Texts}'";
                    ConnectSQL.dbConnection.ExecuteCommand(str2);
                    GetDataToDGV();
                    LogHelper.LogUser("Page Account Manegerment", $"Người dùng Lock thành công tài khoản: {txbFullName.Texts}", Application.StartupPath);

                }
                else
                {
                    MessageBox.Show("Tài khoản đã bị khóa hoặc tài khoản không tồn tại", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
            }
        }

        private void btnOpenLock_Click(object sender, EventArgs e)
        {
            string str1 = $"select * from tblUser where UserName = '{txbUserName.Texts}' and IsLock = '1'";
            DataTable dt = ConnectSQL.dbConnection.FillData(str1.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                string str2 = $"update tblUser set IsLock = '0' where UserName = '{txbUserName.Texts}'";
                ConnectSQL.dbConnection.ExecuteCommand(str2);
                MessageBox.Show("Mở khóa thành công!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                GetDataToDGV();
                LogHelper.LogUser("Page Account Manegerment", $"Người dùng UnLock thành công tài khoản: {txbFullName.Texts}", Application.StartupPath);
            }
            else
            {
                MessageBox.Show("Tài khoản chưa bị khóa hoặc tài khoản không tồn tại", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        

        private void btnCreatAcount_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Account Manegerment", $"Người dùng nhấn Creat", Application.StartupPath);
            frmCreatUser f = new frmCreatUser();
            f.ShowDialog();

            if(f.DialogResult == DialogResult.OK)
            {
                GetDataToDGV();
            }
        }

   

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {

                DialogResult result = MessageBox.Show("Xác nhận xóa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string insertCMD = "update tblUser set IsDelete = '1' where ";

                    List<string> insertCMDs = new List<string>();

                    string[] insertCMD_array = new string[1000];
                    int j = 0, i = 1;
                    List<string> test = new List<string>();
                    List<string> ListUser = new List<string>();
                    foreach (DataGridViewRow row in dgvBookSV.SelectedRows)
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

                                string user = row.Cells["UserName"].Value.ToString();
                                ListUser.Add(user);
                            }
                            else
                            {
                                insertCMDs.Add(insertCMD + string.Join(" or ", insertCMD_array));
                                insertCMD_array = new string[1000];
                                j++;
                                string id = row.Cells["UserID"].Value.ToString();
                                string str = $"UserID = '{id}'";
                                insertCMD_array[0] = str;

                                string user = row.Cells["UserName"].Value.ToString();
                                ListUser.Add(user);
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
                    GetDataToDGV();

                    if (isAllSuccess)
                    {
                        if (Mifare.InsertLog1000(ListUser, "6"))
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
                        LogHelper.LogUser("Page Account Managerment", $"Người dùng xóa thất bại", Application.StartupPath);
                        return;
                    }

                }
            }
            else
            {
                MessageBox.Show("Admin mới được phép sửa dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //btnXoa.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //frmEditSV f = new frmEditSV(txbCardID.Texts, txbHoDem.Texts, txbTen.Texts, txbEmail.Texts, txbMSV.Texts, txbPhone.Texts, txbNote.Texts, txbStudentID.Texts);
            //f.ShowDialog();

            //if (f.DialogResult == DialogResult.OK)
            //{
            //    LoadDGV_NotCurrentCell();
            //    //Load con trỏ hàng hiện tại
            //    if (dgvQLSV != null && dgvQLSV.Rows.Count > 0)
            //    {
            //        for (int i = 0; i <= dgvQLSV.Rows.Count - 2; i++)
            //        {
            //            //string email = txbEmail.Texts;
            //            string studentID = txbStudentID.Texts;
            //            if (studentID == dgvQLSV.Rows[i].Cells["StudentID"].Value.ToString())
            //            {
            //                dgvQLSV.CurrentCell = dgvQLSV.Rows[i].Cells[0];
            //                break;
            //            }
            //        }
            //    }
            //}
            LogHelper.LogUser("Page Account Manegerment", $"Người dùng nhấn Edit", Application.StartupPath);
            if (string.IsNullOrEmpty(txbUserID.Texts))
            {
                MessageBox.Show("Hãy chọn dữ liệu để sửa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            
            frmEditUser f = new frmEditUser(txbUserID.Texts, txbFullName.Texts, txbUserName.Texts, txbPass.Texts, txbQuyen.Texts);
            f.ShowDialog();

            if(f.DialogResult == DialogResult.OK)
            {
                GetDataToDGV();
            }
        }

        private void dgvBookSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvBookSV != null && dgvBookSV.Rows.Count > 0)
            {
                for (int i = 0; i <= dgvBookSV.Rows.Count - 2; i++)
                {
                    string Lock = dgvBookSV.Rows[i].Cells["IsLock"]?.Value?.ToString() ?? "";
                    bool isLock = bool.Parse(Lock);
                    if (isLock)
                    {
                        dgvBookSV.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                        dgvBookSV.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                        
                    }
                }
            }
        }

        private void dgvBookSV_MultiSelectChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnListDelete_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Account Manegerment", $"Người dùng nhấn Trask", Application.StartupPath);

            frmListDeleteUser f = new frmListDeleteUser();
            f.ShowDialog();

            if (f.DialogResult == DialogResult.Cancel)
            {
                GetDataToDGV();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"select tblUser.FullName,UserName,Password,AccessPermission,IsLock,IsDelete,UserID ");
            sb.Append($"from tblUser where IsDelete = '0' and ");

            if (cbbType1.Texts.Trim() == TypeLooking[0])
            {
                sb.Append("FullName like '%" + txbtimkiem.Texts + "%'");
            }
            if (cbbType1.Texts.Trim() == TypeLooking[1])
            {
                sb.Append("UserName like '%" + txbtimkiem.Texts + "%'");
            }
            if (cbbType1.Texts.Trim() == TypeLooking[2])
            {
                sb.Append("AccessPermission like '%" + txbtimkiem.Texts + "%'");
            }

            DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());

            lblCount.Visible = true;
            string result = dt.Rows.Count.ToString();
            lblCount.Text = result + " kết quả";

            dgvBookSV.DataSource = dt;
            LogHelper.LogUser("Page Account Management", $"Người dùng tìm kiếm với từ khóa: {txbtimkiem.Texts}", Application.StartupPath);
        }

        private void txbtimkiem_Enter(object sender, EventArgs e)
        {
            if (txbtimkiem.Texts == Mifare.NameLooking())
            {
                txbtimkiem.Texts = "";
                txbtimkiem.ForeColor = Color.Black;
            }
        }
    }
    
}
