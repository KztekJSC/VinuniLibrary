using System;
using System.Text;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmEditUser : Form
    {
        private string[] QuyenQT = new string[]
        {
            "Admin","User"
        };
        public frmEditUser()
        {
            InitializeComponent();
        }
        string UserId;
        string FullName;
        string UserName;
        string Pass;
        string Quyen;
        public frmEditUser(string ID, string fullname, string username, string pass, string quyen): this()
        {
            UserId = ID;
            FullName = fullname;
            UserName = username;
            Pass = pass;
            Quyen = quyen;
        }
        private void frmEditUser_Load(object sender, EventArgs e)
        {

            cbbQuyen.Items.Add(QuyenQT[0]);
            cbbQuyen.Items.Add(QuyenQT[1]);

            txbFullName.Texts = FullName;
            txbUserName.Texts = UserName;
            txbPass.Texts = Pass;
            cbbQuyen.Texts = Quyen;
            txbUserID.Texts = UserId;
        }

        private void btnCreat_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                if (string.IsNullOrEmpty(txbUserID.Texts))
                {
                    MessageBox.Show("Thông tin tài khoản trống", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }

                StringBuilder sb1 = new StringBuilder();
                sb1.Append($"update tblUser ");
                sb1.Append($"set FullName = '{txbFullName.Texts}',UserName = '{txbUserName.Texts}',Password = '{txbPass.Texts}',AccessPermission = '{cbbQuyen.Texts}' ");
                sb1.Append($"where UserID = '{UserId}' and IsLock = '0'");

                DialogResult result = MessageBox.Show("Xác nhận muốn sửa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (ConnectSQL.dbConnection.ExecuteCommand(sb1.ToString()))
                    {
                        LogHelper.LogUser("Page Edit Account", $"Người dùng sửa thành công dữ liệu với Account: {txbFullName.Texts} ", Application.StartupPath);

                    }
                    this.DialogResult = DialogResult.OK;
                }

            }
            else
            {
                MessageBox.Show("Admin mới được phép sửa dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
    }
}
