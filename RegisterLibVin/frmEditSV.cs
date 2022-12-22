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
    public partial class frmEditSV : Form
    {
        public frmEditSV()
        {
            InitializeComponent();
        }
        string cardID;
        string hoDem;
        string ten;
        string email;
        string msv;
        string phone;
        string note;
        string studentID;

        public frmEditSV(string CardID, string HoDem, string Ten, string Email, string MSV, string Phone, string Note, string StudentID) : this()
        {
            cardID = CardID;
            hoDem = HoDem;
            ten = Ten;
            email = Email;
            msv = MSV;
            phone = Phone;
            note = Note;
            studentID = StudentID;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmEditSV_Load(object sender, EventArgs e)
        {
            txbCardID.Texts = cardID;
            txbHoDem.Texts = hoDem;
            txbTen.Texts = ten;
            txbEmail.Texts = email;
            txbMSV.Texts = msv;
            txbPhone.Texts = phone;
            txbNote.Texts = note;
            txbStudentID.Texts = studentID;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string access = Properties.Settings.Default.AccessPermission.Trim();
            if (access == "SuperAdmin" || access == "Admin")
            {
                if (string.IsNullOrEmpty(txbMSV.Texts))
                {
                    MessageBox.Show("Thông tin MSV trống", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                if (!CheckFormatEmail())
                {
                    MessageBox.Show("Định dạng Email chưa đúng", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int stt = 1;
                    string StudentID = Guid.NewGuid().ToString();
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append($"update tblQLSV ");
                    sb1.Append($"set STT = '{stt}',Surname = N'{txbHoDem.Texts}',Name = N'{txbTen.Texts}',Email = N'{txbEmail.Texts}',StudentCode = '{txbMSV.Texts}',");
                    sb1.Append($"PhoneNumber = '{txbPhone.Texts}',CardID = '{txbCardID.Texts}',Note = N'{txbNote.Texts}',IsRegister = '0',IsDelete = '0' ");
                    sb1.Append($"where StudentID = '{txbStudentID.Texts}'");

                    DialogResult result = MessageBox.Show("Xác nhận muốn sửa dữ liệu ", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        if (ConnectSQL.dbConnection.ExecuteCommand(sb1.ToString()))
                        {
                            LogHelper.LogUser("Page Edit Student", $"Người dùng sửa thành công dữ liệu với MSV: {txbMSV.Texts} ", Application.StartupPath);
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
            {
                MessageBox.Show("Admin mới được phép sửa dữ liệu", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }
        private bool CheckFormatEmail()
        {
            string str = txbEmail.Texts;
            int index = str.IndexOf('@');
            return (index == -1 ? false : true);
        }
    }
}
