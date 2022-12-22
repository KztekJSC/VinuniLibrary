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
    public partial class frmListDelete : Form
    {
        public frmListDelete()
        {
            InitializeComponent();
        }

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
                dgvListDelete.CurrentCell = dgvListDelete.Rows[0].Cells[0];
                //dgvListDelete_CellContentClick(null, null);
            }
        }

        private void btnDeleteRemove_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                btnDeleteRemove.Enabled = true;
                if (string.IsNullOrEmpty(txbStudentID.Texts))
                {
                    MessageBox.Show("Hãy chọn dữ liệu muốn xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bỏ dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string str = $"delete from tblQLSV where StudentID = '{txbStudentID.Texts}'";
                    ConnectSQL.dbConnection.ExecuteCommand(str);
                    LoadDGV();
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

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbStudentID.Texts))
            {
                MessageBox.Show("Hãy chọn dữ liệu muốn khôi phục", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            string str = $"select * from tblQLSV where StudentCode = '{txbMSV.Texts}' and Email = '{txbEmail.Texts}' and IsDelete = '0'";
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

        

        private void frmListDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
