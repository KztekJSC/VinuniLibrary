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
    public partial class frmAddSV : Form
    {
        public frmAddSV()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbMSV.Texts))
            {
                MessageBox.Show("Mời nhập mã sinh viên", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (txbMSV.Texts != "")
            {
                // Tìm với MSV đó có tồn tại IsDelete = 0 ko -> Nếu có thông báo tồn tại và muốn ghi đè dữ liệu ko 
                string creat = $"select * from tblQLSV where StudentCode = '{txbMSV.Texts}' and IsDelete = '0'";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DialogResult rst = MessageBox.Show("Đã có dữ liệu có mã sinh viên này!, Bạn có muốn thay thế dữ liệu cũ không?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rst == DialogResult.Yes)
                    {
                        string creat1 = $"update tblQLSV set IsDelete = '1' where StudentCode = '{txbMSV.Texts}' and IsDelete = '0'";
                        ConnectSQL.dbConnection.ExecuteCommand(creat1);

                        string StudentID = Guid.NewGuid().ToString();
                        int stt = 11;
                        StringBuilder sb = new StringBuilder();
                        sb.Append($"insert into tblQLSV ");
                        sb.Append($"values('{stt}',N'{txbHoDem.Texts}',N'{txbTen.Texts}',N'{txbEmail.Texts}','{txbMSV.Texts}',");
                        sb.Append($"'{txbPhone.Texts}','{txbCardID.Texts}',N'{txbNote.Texts}','0','0','{StudentID}')");

                        ConnectSQL.dbConnection.ExecuteCommand(sb.ToString());
                    }
                }
                else
                {
                    string StudentID = Guid.NewGuid().ToString();
                    int stt = 11;
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"insert into tblQLSV ");
                    sb.Append($"values('{stt}',N'{txbHoDem.Texts}',N'{txbTen.Texts}',N'{txbEmail.Texts}','{txbMSV.Texts}',");
                    sb.Append($"'{txbPhone.Texts}','{txbCardID.Texts}',N'{txbNote.Texts}','0','0','{StudentID}')");

                    ConnectSQL.dbConnection.ExecuteCommand(sb.ToString());
                }

            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmAddSV_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
