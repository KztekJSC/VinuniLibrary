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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
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
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txbFullName.Texts != "" && txbAcount.Texts != "" && txbPass2.Texts != "" && txbPass.Texts != "")
            {
                if (txbPass.Texts == txbPass2.Texts)
                {
                    //Kiểm tra tài khoản đã tồn tại chưa
                    string check = $"select * from tblUser where UserName = '{txbFullName.Texts}'";
                    DataTable dt = ConnectSQL.dbConnection.FillData(check);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        RJMessageBox.Show("Tài khoản đã tồn tại", "Notice", MessageBoxButtons.OKCancel);
                    }
                    else
                    {
                        DialogResult result = RJMessageBox.Show("Xác nhận đăng ký tài khoản Admin", "Register", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string quyen = "Admin";
                            string query = $"insert into tblUser values (NEWID(),N'{txbFullName.Texts}','{Filter(txbAcount.Texts)}','{Filter(txbPass.Texts)}','{quyen}', '0')";
                            ConnectSQL.dbConnection.ExecuteCommand(query);

                            RJMessageBox.Show("Đăng ký thành công!", "Notice", MessageBoxButtons.OKCancel);
                        }
                    }
                }
                else
                {
                    RJMessageBox.Show("Mật khẩu chưa trùng khớp", "Notice", MessageBoxButtons.OKCancel);
                }
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            int rowHeader = Properties.Settings.Default.RowHeader;
            int rowStart = Properties.Settings.Default.RowStart;
            int rowEnd = Properties.Settings.Default.RowEnd;
            int columnStart = Properties.Settings.Default.ColumnStart;
            int columnEnd = Properties.Settings.Default.ColumnEnd;

            tgbtnCheckDefault.Checked = Properties.Settings.Default.DefaultImport == true ? true : false;

            cbbRowHeader.Texts = rowHeader.ToString();

            cbbRowStart.Texts = rowStart.ToString();
            // Nếu = -1 là cấu hình default -> sẽ lấy giá trị đầu tiên của combobox , nếu không lấy giá trị text
            cbbRowEnd.Texts = rowEnd == -1 ? cbbRowEnd.Items[0].ToString() : rowEnd.ToString();

            cbbColumnStart.Texts = columnStart == -1 ? cbbColumnStart.Items[0].ToString() : columnStart.ToString();

            cbbColumnEnd.Texts = columnEnd == -1 ? cbbColumnEnd.Items[0].ToString() : columnEnd.ToString();

            GetKeySettings();
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            if (tgbtnCheckDefault.Checked == true)   // Default
            {
                Properties.Settings.Default.DefaultImport = true;
            }
            else
                Properties.Settings.Default.DefaultImport = false;

            Properties.Settings.Default.RowHeader = int.Parse(cbbRowHeader.Texts);

            Properties.Settings.Default.RowStart = int.Parse(cbbRowStart.Texts);

            Properties.Settings.Default.RowEnd = (cbbRowEnd.SelectedIndex == 0) ? -1 : int.Parse(cbbRowEnd.Texts);

            Properties.Settings.Default.ColumnStart = (cbbColumnStart.SelectedIndex == 0) ? -1 : int.Parse(cbbColumnStart.Texts);

            Properties.Settings.Default.ColumnEnd = (cbbColumnEnd.SelectedIndex == 0) ? -1 : int.Parse(cbbColumnEnd.Texts);

            Properties.Settings.Default.Save();

            MessageBox.Show("Lưu thành công","Excel", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tgbtnCheckDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (tgbtnCheckDefault.Checked)
            {
                
                cbbRowHeader.Texts = "2";
                cbbRowStart.Texts = "3";
                cbbRowEnd.SelectedIndex = 0;
                cbbColumnStart.SelectedIndex = 0;
                cbbColumnEnd.SelectedIndex = 0;

                cbbRowHeader.Enabled = false;
                cbbRowStart.Enabled = false;
                cbbRowEnd.Enabled = false;
                cbbColumnStart.Enabled = false;
                cbbColumnEnd.Enabled = false;

            }
            else
            {

                cbbRowHeader.Enabled = true;
                cbbRowStart.Enabled = true;
                cbbRowEnd.Enabled = true;
                cbbColumnStart.Enabled = true;
                cbbColumnEnd.Enabled = true;
            }
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin")
            {
                DialogResult result = RJMessageBox.Show("Bạn có muốn thay đổi Key không?", "Notice!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    SaveKeySettings();
                    GetKeySettings();
                }
            }
            else
            {
                MessageBox.Show("Không được quyền thay đổi key", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void GetKeySettings()
        {
            lblkey.Text = Properties.Settings.Default.Key;
        }
        public void SaveKeySettings()
        {
            Properties.Settings.Default.Key = txbKey.Text;

            Properties.Settings.Default.Save();
        }
    }
}
