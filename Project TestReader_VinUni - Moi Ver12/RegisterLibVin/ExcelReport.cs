using Futech.Tools;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace RegisterLibVin
{

    internal class ExcelReport
    {
        //public string columnStartImport;
        //public string columnEndImport;
        //public string rowStartImport;
        //public string rowEndImport;

        //public string ColumnStartImport { get => columnStartImport; set => columnStartImport = value; }
        //public string ColumnEndImport { get => columnEndImport; set => columnEndImport = value; }
        //public string RowStartImport { get => rowStartImport; set => rowStartImport = value; }
        //public string RowEndImport { get => rowEndImport; set => rowEndImport = value; }


        // Import Excell mới hoàn toàn
        public static void ImportExcel(string path, DataGridView dgv)
        {
            bool isNull = false;
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                // Thêm License cho lớp ExcelPackage của nhà phát hành
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();

                //int rowStart = excelWorksheet.Dimension.Start.Row;
                //int rowEnd = excelWorksheet.Dimension.End.Row; 
                //int columnStart = excelWorksheet.Dimension.Start.Column;
                //int columnEnd = excelWorksheet.Dimension.End.Column;

                //bool isDefault = Properties.Settings.Default.DefaultImport;   // Kiểm tra là mặc định hay tinh chỉnh (default/ custom)
                if (Properties.Settings.Default.RowStart == 0)
                {
                    MessageBox.Show("Mời nhập config Excel");
                }
                // Khai baó các giá trị cấu hình
                int rowHeader = Properties.Settings.Default.RowHeader;

                int rowStart = Properties.Settings.Default.RowStart;

                int rowEnd = Properties.Settings.Default.RowEnd == -1 ? excelWorksheet.Dimension.End.Row : Properties.Settings.Default.RowEnd; 
                
                int columnStart = Properties.Settings.Default.ColumnStart == -1 ? excelWorksheet.Dimension.Start.Column : Properties.Settings.Default.ColumnStart;

                int columnEnd = Properties.Settings.Default.ColumnEnd == -1 ? excelWorksheet.Dimension.End.Column : Properties.Settings.Default.ColumnEnd;

                

                // Lấy dữ liệu hàng tiêu đề (hàng 2)
                for (int i = columnStart; i <= columnEnd; i++)
                {
                    dataTable.Columns.Add(excelWorksheet.Cells[rowHeader,i].Value.ToString());
                }
                // lấy dữ liệu hàng còn lại
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    List<string> listRows = new List<string>();
                    for (int j = columnStart; j <= columnEnd; j++)
                    {
                        if (excelWorksheet.Cells[i, 1].Value == null)
                        {
                            isNull = true;
                            break;
                        }
                        if (excelWorksheet.Cells[i, j].Value != null)
                        {
                            listRows.Add(excelWorksheet.Cells[i, j].Value.ToString());
                        }
                        else
                        {
                            listRows.Add("");
                        }
                    }
                    if (isNull)
                    {
                        break;
                    }
                    dataTable.Rows.Add(listRows.ToArray());
                }
                dgv.DataSource = dataTable;
            }
        }
        // Import update dữ liệu có MSV mới
        public static void ImportExcel2(string path, DataGridView dgv)
        {
            //Futech.Tools.MDB dbConnection = new MDB("103.127.207.247", "VinUniver", "SQl Server Authentication", "sa", "Kztek@123456");
            //dbConnection.OpenMDB();
            ConnectSQL.ConnectConfig();
            DataTable dtOld = (DataTable)dgv.DataSource;

            bool isNull = false;
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                // Thêm License cho lớp ExcelPackage của nhà phát hành
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();

                bool isDefault = Properties.Settings.Default.DefaultImport;   // Kiểm tra là mặc định hay tinh chỉnh (default/ custom)
                if (Properties.Settings.Default.RowStart == 0)
                {
                    MessageBox.Show("Mời nhập config Excel");
                }
                // Khai baó các giá trị cấu hình
                int rowHeader = Properties.Settings.Default.RowHeader;

                int rowStart = Properties.Settings.Default.RowStart;

                int rowEnd = isDefault == true ? excelWorksheet.Dimension.End.Row : Properties.Settings.Default.RowEnd;

                int columnStart = isDefault == true ? excelWorksheet.Dimension.Start.Column : Properties.Settings.Default.ColumnStart;

                int columnEnd = isDefault == true ? excelWorksheet.Dimension.End.Column : Properties.Settings.Default.ColumnEnd;
                

                //for (int i = excelWorksheet.Dimension.Start.Column; i <= excelWorksheet.Dimension.End.Column; i++)
                //{
                //    dataTable.Columns.Add(excelWorksheet.Cells[2, i].Value.ToString());
                //}
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    if (excelWorksheet.Cells[i, 5].Value != null)
                    {
                        var MSV = excelWorksheet.Cells[i, 5].Value.ToString();
                        string str = $"select * from tblQLSV where StudentCode = '{MSV}'";
                        DataTable dt = ConnectSQL.dbConnection.FillData(str);
                        if(dt != null && dt.Rows.Count > 0)
                        {
                            continue;
                        }
                    }
                    List<string> listRows = new List<string>();
                    for (int j = columnStart; j <= columnEnd; j++)
                    {
                        if (excelWorksheet.Cells[i, 1].Value == null)
                        {
                            isNull = true;
                            break;
                        }
                        if (excelWorksheet.Cells[i, j].Value != null)
                        {
                            listRows.Add(excelWorksheet.Cells[i, j].Value.ToString());
                        }
                        else
                        {
                            listRows.Add("");
                        }
                    }
                    if (isNull)
                    {
                        break;
                    }
                    dtOld.Rows.Add(listRows.ToArray());
                    //string StudentID = Guid.NewGuid().ToString();
                    //string str = $"insert into tblQLSV values(N'" + dgvQLSV.Rows[i].Cells["STT"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Họ đệm"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Tên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Email"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Mã sinh viên"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Số điện thoại"].Value + "',N'" + dgvQLSV.Rows[i].Cells["ID Card"].Value + "',N'" + dgvQLSV.Rows[i].Cells["Ghi chú"].Value + "','0','0','" + StudentID + "')";
                }
                dgv.DataSource = dtOld;
            }
        }
        public static void ExportExcel(string path, DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 
            

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "J1");   // A1 - J1: 10 cột 

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "STT";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Họ đệm";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Tên";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Email";

            cl4.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Mã sinh viên";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Số điện thoại";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "ID Card";

            cl7.ColumnWidth = 13.5;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Ngày đăng kí";

            cl8.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Người đăng ký";

            cl9.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");

            cl10.Value2 = "Ghi chú";

            cl10.ColumnWidth = 13.5;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "J3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = columnStart; j <= columnEnd; j++)
                {
                    Microsoft.Office.Interop.Excel.Range c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                    int xIndex = i - rowStart ;
                    int yIndex = j - columnStart;
                    c.Value2 = arr[xIndex, yIndex].ToString();
                }
            }
            //Điền dữ liệu vào vùng đã thiết lập

            //range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //oSheet.SaveAs(@"./ExportData.xlsx");
            //oBooks.Close();
            //oExcel.Quit();
            oExcel.Columns.AutoFit();
            oExcel.ActiveWorkbook.SaveCopyAs(path);
            oExcel.ActiveWorkbook.Saved = true;

            oBooks.Close();
            oExcel.Quit();

        }


        public static void ExportExcel2(string path, DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 


            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;



            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");   // A1 - J1: 10 cột 

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A2", "A2");

            cl1.Value2 = "STT";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B2", "B2");

            cl2.Value2 = "Họ đệm";

            cl2.ColumnWidth = 40.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C2", "C2");

            cl3.Value2 = "Tên";
            cl3.ColumnWidth = 15.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D2", "D2");

            cl4.Value2 = "Email";

            cl4.ColumnWidth = 50.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E2", "E2");

            cl5.Value2 = "Mã sinh viên";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F2", "F2");

            cl6.Value2 = "Số điện thoại";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G2", "G2");

            cl7.Value2 = "ID Card";

            cl7.ColumnWidth = 20.5;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H2", "H2");

            cl8.Value2 = "Ghi chú";

            cl8.ColumnWidth = 20.5;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A2", "H2");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 3;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            for (int i = rowStart; i <= rowEnd; i++)
            {
                for (int j = columnStart; j <= columnEnd; j++)
                {
                    Microsoft.Office.Interop.Excel.Range c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
                    int xIndex = i - rowStart;
                    int yIndex = j - columnStart;
                    c.Value2 = arr[xIndex, yIndex].ToString();
                }
            }
            //Điền dữ liệu vào vùng đã thiết lập

            //range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //oSheet.SaveAs(@"./ExportData.xlsx");
            //oBooks.Close();
            //oExcel.Quit();
            oExcel.Columns.AutoFit();
            oExcel.ActiveWorkbook.SaveCopyAs(path);
            oExcel.ActiveWorkbook.Saved = true;

            oBooks.Close();
            oExcel.Quit();

        }
    }
}
