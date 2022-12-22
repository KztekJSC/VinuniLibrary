using Futech.Tools;
using System;
using System.Data;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmQuanLyUser : Form
    {

        private string[] TypeLooking = new string[]
        {
            "FullName","UserName"
        };
        public frmQuanLyUser()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
        }

        private void frmEventBook_Load(object sender, EventArgs e)
        {
            GetDataToDGV();

            cbbType1.Items.Add("FullName");
            cbbType1.Items.Add("UserName");
        }

        private void GetDataToDGV()
        {
            string getData = "select tblUser.FullName,UserName,Password,AccessPermission,IsLock from tblUser where AccessPermission = 'Admin' or AccessPermission = 'User'";
            DataTable dt = ConnectSQL.dbConnection.FillData(getData);

            dgvBookSV.DataSource = dt;
        }

        private void txbtimkiem__TextChanged(object sender, EventArgs e)
        {
            if (cbbType1.Texts.Trim() == TypeLooking[0])
            {
                string str1 = " select tblUser.FullName,UserName,Password,AccessPermission,IsLock from tblUser where FullName like '%" + txbtimkiem.Texts+ "%' and (AccessPermission = 'Admin' or AccessPermission = 'User')";
                DataTable dt = ConnectSQL.dbConnection.FillData(str1.ToString());
                dgvBookSV.DataSource = dt;
            }
            if (cbbType1.Texts.Trim() == TypeLooking[1])
            {
                string str1 = " select tblUser.FullName,UserName,Password,AccessPermission,IsLock from tblUser where UserName like '%" + txbtimkiem.Texts + "%' and (AccessPermission = 'Admin' or AccessPermission = 'User')";
                DataTable dt = ConnectSQL.dbConnection.FillData(str1.ToString());
                dgvBookSV.DataSource = dt;

            }
            if (txbtimkiem.Text == "")
            {
                
            }
        }

        private void dgvBookSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvBookSV.CurrentRow.Index;
            txbFullName.Texts = dgvBookSV.Rows[i].Cells[0].Value.ToString();
            txbUserName.Texts = dgvBookSV.Rows[i].Cells[1].Value.ToString();
            txbPass.Texts = dgvBookSV.Rows[i].Cells[2].Value.ToString();
            txbQuyen.Texts = dgvBookSV.Rows[i].Cells[3].Value.ToString();
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
            }
            else
            {
                MessageBox.Show("Tài khoản chưa bị khóa hoặc tài khoản không tồn tại", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
