using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public partial class frmReport : Form
    {
        string[] TypeMonth = new string[]
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };
        
        string[] TypeYear = new string[]
        {
            
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
        };
        private Dictionary<string, int> MonthList = new Dictionary<string, int>()
        {
            {"January",1},
            {"February",2},
            {"March",3},
            {"April",4},
            {"May",5},
            {"June",6},
            {"July",7},
            {"August",8},
            {"September",9},
            {"October",10},
            {"November",11},
            {"December",12},

        };
        public frmReport()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(!isbtnMonth && !isbtnYear && !isbtnPeriod)
            {
                MessageBox.Show("Hãy chọn loại Report","Notice",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }
            if (isbtnPeriod)
            {
                if(dtpTo.Value < dtpFrom.Value)
                {
                    MessageBox.Show("Định dạng thời gian không đúng", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("STT");
            dtReport.Columns.Add("Người thực hiện");
            dtReport.Columns.Add("Tổng số thẻ");
            dtReport.Columns.Add("Ghi chú");

            string STT = "";
            string fullName = "";
            string count = "";
            string Note = "";
            int totalCount = 0;
            // Lấy List danh sách người ghi dữ liệu 
            string creat = "Select distinct UserFullName from tblRegister where IsDelete = '0'";
            DataTable dtName = ConnectSQL.dbConnection.FillData(creat);
            if(dtName != null && dtName.Rows.Count > 0)
            {
                int a = 0;
                for (int i = 0; i < dtName.Rows.Count; i++)
                {
                    List<string> ListRow = new List<string>();

                    fullName = dtName.Rows[i][0].ToString();
                    a++;
                    STT = a.ToString();

                    //ListFullName.Add(dtName.Rows[i][0].ToString());
                    string str = "";
                    if (isbtnMonth)
                    {
                        int month = MonthList[cbbMonth.Texts];
                        str = $" SELECT count(UserFullName) from tblRegister WHERE datepart(month, DateTime) = {month} and UserFullName = '{fullName}' and IsDelete = '0'";
                    }
                    if (isbtnYear)
                    {
                        int year = int.Parse(cbbYear2.Texts);
                        str = $" SELECT count(UserFullName) from tblRegister WHERE datepart(year, DateTime) = {year} and UserFullName = '{fullName}' and IsDelete = '0'";
                    }
                    if (isbtnPeriod)
                    {
                        str = $" SELECT count(UserFullName) from tblRegister WHERE tblRegister.DateTime between '{dtpFrom.Value}' and '{dtpTo.Value}' and UserFullName = '{fullName}' and IsDelete = '0'";
                    }
                    DataTable dt = ConnectSQL.dbConnection.FillData(str);
                    if( dt != null && dt.Rows.Count > 0)
                    {
                        count = dt.Rows[0][0].ToString();
                    }
                    ListRow.Add(STT);
                    ListRow.Add(fullName);
                    ListRow.Add(count);
                    ListRow.Add(Note);
                    totalCount = totalCount + int.Parse(count);

                    dtReport.Rows.Add(ListRow.ToArray());
                }
                
            }
            else
            {
                MessageBox.Show("Chưa có danh sách người ghi dữ liệu","Notice",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "ExportExcel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int month = 0;
                    int year = 0;
                    DateTime dateTimeMonth = DateTime.Now;
                    DateTime dateTimeMonth2 = DateTime.Now;

                    string tiltle1 = "";
                    string tiltle2 = "";
                    string type = "";
                    if (isbtnMonth)
                    {
                        month = MonthList[cbbMonth.Texts];
                        year = int.Parse(cbbYear1.Texts);
                        dateTimeMonth = new DateTime(year, month, 26);
                        tiltle1 = "tháng";
                        tiltle2 = $"BÁO CÁO ĐỊNH KỲ THÁNG: {month}/{year}";
                        type = "1";
                    }
                    if (isbtnYear)
                    {
                        year = int.Parse(cbbYear2.Texts);
                        dateTimeMonth = new DateTime(year, 1, 26);
                        tiltle1 = "năm";
                        tiltle2 = $"BÁO CÁO ĐỊNH KỲ NĂM: {year}";
                        type = "2";
                    }
                    if (isbtnPeriod)
                    {
                        
                        string a = dtpFrom.Value.ToString("dd/MM/yyyy");
                        string b = dtpTo.Value.ToString("dd/MM/yyyy");
                        tiltle1 = "khoảng thời gian";
                        tiltle2 = $"BÁO CÁO ĐỊNH KỲ KHOẢNG THỜI GIAN";
                        type = "3";
                        dateTimeMonth = dtpFrom.Value;
                        dateTimeMonth2 = dtpTo.Value;
                    }
                    string Name = Properties.Settings.Default.FullName;
                    ExcelReport.ReportExcel(saveFileDialog.FileName, dtReport, $"{tiltle1}", $"{tiltle2}", dateTimeMonth,dateTimeMonth2, totalCount, type);
                    isbtnMonth = false;
                    isbtnYear = false;
                    isbtnPeriod = false;
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OKCancel);
                    LogHelper.LogUser("Page Registered List", $"Người dùng Export Excel thành công", Application.StartupPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Khong thanh cong");
                }
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            cbbYear1.Visible = false;
            cbbMonth.Visible = false;
            lblYear1.Visible = false;
            lblMonth.Visible = false;

            cbbYear2.Visible = false;
            lblYear2.Visible = false;

            dtpFrom.Visible = false;
            dtpTo.Visible = false;
            lblFrom.Visible = false;
            lblTo.Visible = false;

            for (int i = 0; i < TypeMonth.Length; i++)
            {
                cbbMonth.Items.Add(TypeMonth[i]);
                

            }
            int yearNow = int.Parse(DateTime.Now.Year.ToString());

            for (int i = 2022; i < yearNow + 10; i++)
            {
                cbbYear1.Items.Add(i);
                cbbYear2.Items.Add(i);
            }
            cbbMonth.SelectedIndex = 0;
            cbbYear1.SelectedIndex = 0;
            cbbYear2.SelectedIndex = 0;

        }

        private void cbbMonth_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool isbtnMonth = false;
        bool isbtnYear = false;
        bool isbtnPeriod = false;
        private void btnMonth_Click(object sender, EventArgs e)
        {
            isbtnMonth = true;
            isbtnYear = false;
            isbtnPeriod = false;

            lblReport.Text = "Report By Month";

            cbbYear1.Visible = true;
            cbbMonth.Visible = true;
            lblYear1.Visible = true;
            lblMonth.Visible = true;

            cbbYear2.Visible = false;
            lblYear2.Visible = false;

            dtpFrom.Visible = false;
            dtpTo.Visible = false;
            lblFrom.Visible = false;
            lblTo.Visible = false;
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            isbtnYear = true;
            isbtnMonth = false;
            isbtnPeriod = false;

            lblReport.Text = "Report By Year";

            cbbYear1.Visible = false;
            cbbMonth.Visible = false;
            lblYear1.Visible = false;
            lblMonth.Visible = false;

            cbbYear2.Visible = true;
            lblYear2.Visible = true;

            dtpFrom.Visible = false;
            dtpTo.Visible = false;
            lblFrom.Visible = false;
            lblTo.Visible = false;
        }

        private void btnPeriod_Click(object sender, EventArgs e)
        {
            isbtnPeriod = true;
            isbtnMonth = false;
            isbtnYear = false;

            lblReport.Text = "Report By Period";

            cbbYear1.Visible = false;
            cbbMonth.Visible = false;
            lblYear1.Visible = false;
            lblMonth.Visible = false;

            cbbYear2.Visible = false;
            lblYear2.Visible = false;

            dtpFrom.Visible = true;
            dtpTo.Visible = true;
            lblFrom.Visible = true;
            lblTo.Visible = true;
        }

        private void lblReport_Click(object sender, EventArgs e)
        {

        }

        private void cbbYear1_Load(object sender, EventArgs e)
        {

        }

        private void cbbMonth_Load_1(object sender, EventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
