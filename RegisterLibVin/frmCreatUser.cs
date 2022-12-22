using CustomMessageBox;
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
    public partial class frmCreatUser : Form
    {
        private string[] Quyen = new string[]
        {
            "Admin","User"
        };
        public frmCreatUser()
        {
            InitializeComponent();
        }

        private void btnCreat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbUserName.Texts != "" && txbPass.Texts != "" && txbFullName.Texts != "" && cbbQuyen.Texts != "")
                {
                    //Kiểm tra tài khoản đã tồn tại chưa
                    string check = $"select * from tblUser where UserName = '{txbUserName.Texts}'";
                    DataTable dt = ConnectSQL.dbConnection.FillData(check);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        RJMessageBox.Show("Tài khoản đã tồn tại", "Notice", MessageBoxButtons.OKCancel);
                        LogHelper.LogUser("Page CreatAccount", $"Người dùng đăng ký thất bại ", Application.StartupPath);
                        return;
                    }
                    else
                    {
                        DialogResult result = RJMessageBox.Show("Xác nhận đăng ký", "Register", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string id = Guid.NewGuid().ToString();
                            string quyen = cbbQuyen.Texts;

                            string query = $"insert into tblUser values ('{id}',N'{txbFullName.Texts}','{Filter(txbUserName.Texts)}','{Filter(txbPass.Texts)}','{quyen}', '0','0')";
                            if (ConnectSQL.dbConnection.ExecuteCommand(query))
                            {
                                RJMessageBox.Show("Đăng ký thành công!", "Notice", MessageBoxButtons.OKCancel);
                                LogHelper.LogUser("Page CreatAccount", $"Người dùng đăng ký thành công Account: {txbFullName.Texts}", Application.StartupPath);
                            }

                        }
                    }
                }
                else
                {
                    RJMessageBox.Show("Mời nhập đủ thông tin", "Notice", MessageBoxButtons.OKCancel);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                LogHelper.LogUser("Page CreatAccount", $"Lỗi hệ thống: {ex}", Application.StartupPath);

            }

        }
        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        // Hàm lọc kí tự dấu thành không dấu
        public static string Filter(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }

        private void frmCreatUser_Load(object sender, EventArgs e)
        {
            cbbQuyen.Items.Add(Quyen[0]);
            cbbQuyen.Items.Add(Quyen[1]);

            cbbQuyen.SelectedIndex = 1;

        }
    }
}
