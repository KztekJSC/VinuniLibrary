using Futech.Tools;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Xml.Serialization;
using static RegisterLibVin.frmQLSV;

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
                    dataTable.Columns.Add(excelWorksheet.Cells[rowHeader, i].Value.ToString());
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
                dgv.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
        }
        // 

        //1 -Sd tuple
        //2-Dinh nghia 1 class co 2 bien tra ve

        class KQ
        {
            public DataTable dt { get; set; }
            public int MyProperty { get; set; }
        }
        //--out, ref

        /// <summary>
        /// Import update dữ liệu có MSV mới
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dgv"></param>
        /// <param name="dssv">Danh sach SV da dang ky</param>
        public static  DataTable ImportExcel2(string path, DataGridView dgv, List<SinhVien> dssv, out DataTable dtNewData)
        {
            //x = 5;
            ConnectSQL.ConnectConfig();
            DataTable dtOld = (DataTable)dgv.DataSource;
            //string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[StudentID], '0' as IsRed FROM [VinUniver].[dbo].[tblQLSV]";
            //DataTable dtOld = ConnectSQL.dbConnection.FillData(creat);

            DataTable dtRed = new DataTable();
            dtRed.Columns.Add("STT");
            dtRed.Columns.Add("Surname");
            dtRed.Columns.Add("Name");
            dtRed.Columns.Add("Email");
            dtRed.Columns.Add("StudentCode");
            dtRed.Columns.Add("PhoneNumber");
            dtRed.Columns.Add("CardID");
            dtRed.Columns.Add("Note");
            dtRed.Columns.Add("IsDelete");
            dtRed.Columns.Add("StudentId");
            dtRed.Columns.Add("IsRed");

            DataTable dtAdd = new DataTable();
            dtAdd.Columns.Add("STT");
            dtAdd.Columns.Add("Surname");
            dtAdd.Columns.Add("Name");
            dtAdd.Columns.Add("Email");
            dtAdd.Columns.Add("StudentCode");
            dtAdd.Columns.Add("PhoneNumber");
            dtAdd.Columns.Add("CardID");
            dtAdd.Columns.Add("Note");
            dtAdd.Columns.Add("IsDelete");
            dtAdd.Columns.Add("StudentId");
            dtAdd.Columns.Add("IsRed");

            

            bool isNull = false;
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                // Thêm License cho lớp ExcelPackage của nhà phát hành
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];

                bool isDefault = Properties.Settings.Default.DefaultImport;   // Kiểm tra là mặc định hay tinh chỉnh (default/ custom)
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


                // Thêm dữ liệu thân
                for (int i = rowStart; i <= rowEnd; i++)
                {
                    List<string> listRows = new List<string>();
                    List<string> listRowsRed = new List<string>();


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
                    dtAdd.Rows.Add(listRows.ToArray());
                    // Check duwx lieu trung
                    bool isRed = false;
                    if (excelWorksheet.Cells[i, 5].Value != null)
                    {
                        var MSV = excelWorksheet.Cells[i, 5].Value.ToString();
                        foreach (SinhVien sv in dssv)
                        {
                            if (MSV == sv.MSV)
                            {
                                listRowsRed = listRows;
                                dtRed.Rows.Add(listRowsRed.ToArray());
                                dtRed.Rows[dtRed.Rows.Count - 1]["IsRed"] = "1";

                                dtOld.Rows[dtOld.Rows.Count - 1]["IsRed"] = "1";
                                dtAdd.Rows[dtAdd.Rows.Count - 1]["IsRed"] = "1";

                                dtAdd.Rows.Remove(dtAdd.Rows[dtAdd.Rows.Count - 1]);
                                isRed = true;
                                break;
                            }
                        }
                        if (isRed == false)
                        {
                            // Cập nhật lại dssv - code chỉ cập nhật trong hàm Import này - trước khi import tiếp cần update lại dssv trước khi đổ vào đây
                            SinhVien newSv = new SinhVien();
                            // Khoi tao thong tin
                            newSv.MSV = dtOld.Rows[dtOld.Rows.Count - 1]["StudentCode"].ToString();
                            dssv.Add(newSv);
                        }
                    }
                    else
                    {
                        if (excelWorksheet.Cells[i, 4].Value != null)
                        {
                            string email = excelWorksheet.Cells[i, 4].Value.ToString();
                            foreach (SinhVien sv in dssv)
                            {
                                if (email == sv.Email)
                                {
                                    listRowsRed = listRows;
                                    dtRed.Rows.Add(listRowsRed.ToArray());
                                    dtRed.Rows[dtRed.Rows.Count - 1]["IsRed"] = "1";

                                    dtOld.Rows[dtOld.Rows.Count - 1]["IsRed"] = "1";
                                    dtAdd.Rows[dtAdd.Rows.Count - 1]["IsRed"] = "1";

                                    dtAdd.Rows.Remove(dtAdd.Rows[dtAdd.Rows.Count - 1]);
                                    isRed = true;
                                    break;
                                }
                            }
                            if (isRed == false)
                            {
                                SinhVien newSv = new SinhVien();
                                // Khoi tao thong tin
                                newSv.Email = dtOld.Rows[dtOld.Rows.Count - 1]["Email"].ToString();
                                dssv.Add(newSv);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Phát hiện có dữ liệu Email và Mã sinh viên trống", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            SinhVien newSv = new SinhVien();
                            // Khoi tao thong tin
                            newSv.Email = dtOld.Rows[dtOld.Rows.Count - 1]["Email"].ToString();
                            dssv.Add(newSv);
                        }
                    }
                }
                dgv.DataSource = dtOld;
                dtNewData = dtAdd;
                return dtRed;
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

            // Tạo chú thích Người Report
            Microsoft.Office.Interop.Excel.Range Note = oSheet.get_Range("A2", "E2");   // A1 - J1: 10 cột 
            string name = Properties.Settings.Default.FullName;

            Note.MergeCells = true;

            Note.Value2 = "Người tạo Report: " + name;

            Note.Font.Bold = true;

            Note.Font.Name = "Times New Roman";

            Note.Font.Size = "13";

            Note.Interior.ColorIndex = 20;

            Note.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo chú thích Thời gian
            Microsoft.Office.Interop.Excel.Range Time = oSheet.get_Range("F2", "J2");   // A1 - J1: 10 cột 

            DateTime time = new DateTime();
            time = DateTime.Now;

            Time.MergeCells = true;

            Time.Value2 = "Thời gian: " + time;

            Time.Font.Bold = true;

            Time.Font.Name = "Times New Roman";

            Time.Font.Size = "13";

            Time.Interior.ColorIndex = 20;

            Time.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

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
            ////////////////////////////////////////////
            


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

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count-3];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count-3; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 3;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count-3;

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
        //private string FormatDate(int TypeDate)
        //{
        //    string year = DateTime.Now.Year.ToString();
        //    switch (TypeDate)
        //    {
        //        case 1:
        //            return $"1/1/{year} - 31/1/{year}";
        //    }
        //}
        public static void ReportExcel(string path, DataTable dataTable, string sheetName, string title, DateTime dateTime,DateTime dateTime2 , int totalCount, string type)
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");   // A1 - J1: 10 cột 

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo chú thích loại thời gian 
            Microsoft.Office.Interop.Excel.Range Note = oSheet.get_Range("A2","F2");   // A1 - J1: 10 cột 

            // Lấy mốc đầu và cuối của tháng
            int month = dateTime.Month;
            int year = dateTime.Year;
            DateTime dateFirst = DateTime.Now;
            DateTime dateLast = DateTime.Now;
            if (type == "1")
            {
                dateFirst = GetFistDayInMonth(year, month);
                dateLast = GetLastDayInMonth(year, month);
            }
            if(type == "2")
            {
                dateFirst = GetFistDayInMonth(year, 1);
                dateLast = GetLastDayInMonth(year, 12);
            }
            if(type == "3")
            {
                dateFirst = dateTime;
                dateLast = dateTime2;
            }
            string dateTimeFirst = dateTimeFirst = dateFirst.ToString("dd/MM/yyyy");
            string dateTimeLast = dateTimeLast = dateLast.ToString("dd/MM/yyyy");


            Note.MergeCells = true;

            Note.Value2 = $"({dateTimeFirst} - {dateTimeLast})";

            Note.Font.Bold = true;

            Note.Font.Name = "Times New Roman";

            Note.Font.Size = "13";

            //Note.Interior.ColorIndex = 20;   // Màu

            Note.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tên tiêu đề
            Microsoft.Office.Interop.Excel.Range Time = oSheet.get_Range("A3", "F3");   // A1 - J1: 10 cột 

            DateTime time = new DateTime();
            time = DateTime.Now;

            Time.MergeCells = true;

            Time.Value2 = "THỐNG KÊ SỐ THẺ ĐÃ GHI DỮ LIỆU";

            Time.Font.Bold = true;

            Time.Font.Name = "Times New Roman";

            Time.Font.Size = "13";

            Time.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tên Tổng

            int count = dataTable.Rows.Count + 6;
            string Ccount = "C" + count;

            Microsoft.Office.Interop.Excel.Range NameTotal = oSheet.get_Range(Ccount, Ccount);   // A1 - J1: 10 cột 

            NameTotal.MergeCells = true;

            NameTotal.Value2 = "Tổng:";

            NameTotal.Font.Bold = true;

            NameTotal.Font.Name = "Times New Roman";

            NameTotal.Font.Size = "13";

            NameTotal.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            // Tạo tổng cuối hàng

            string Dcount = "D" + count;

            Microsoft.Office.Interop.Excel.Range Total = oSheet.get_Range(Dcount, Dcount);   // A1 - J1: 10 cột 

            Total.MergeCells = true;

            Total.Value2 = totalCount.ToString();

            Total.Font.Bold = true;

            Total.Font.Name = "Times New Roman";

            Total.Font.Size = "13";

            Total.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo chú thích Thời gian Report
            string RowReport = (dataTable.Rows.Count + 8).ToString();
            string CellFirst = "A" + RowReport;
            string CellLast = "C" + RowReport;

            Microsoft.Office.Interop.Excel.Range TimeReport = oSheet.get_Range(CellFirst, CellLast);   // A1 - J1: 10 cột 

            DateTime timeRP = DateTime.Now;
            string TimeRP = timeRP.ToString("dd/MM/yyyy HH:mm:ss");

            TimeReport.MergeCells = true;

            TimeReport.Value2 = "Thời gian tạo báo cáo: " + TimeRP;

            //TimeReport.Font.Bold = true;

            TimeReport.Font.Name = "Times New Roman";

            TimeReport.Font.Size = "13";

            TimeReport.Interior.ColorIndex = 20;

            TimeReport.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;

            // Tạo chú thích Người Report
            string CellFirstName = "D" + RowReport;
            string CellLastName = "F" + RowReport;

            Microsoft.Office.Interop.Excel.Range Reporter = oSheet.get_Range(CellFirstName, CellLastName);   // A1 - J1: 10 cột 
            string name = Properties.Settings.Default.FullName;

            Reporter.MergeCells = true;

            Reporter.Value2 = "Người tạo báo cáo: " + name;

            Reporter.Font.Bold = true;

            Reporter.Font.Name = "Times New Roman";

            Reporter.Font.Size = "13";

            Reporter.Interior.ColorIndex = 20;

            Reporter.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // PHẦN NỘI DUNG BẢNG
            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("B5", "B5");

            cl1.Value2 = "STT";

            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C5", "C5");

            cl3.Value2 = "Người thực hiện";
            cl3.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D5", "D5");

            cl4.Value2 = "Tổng số thẻ";

            cl4.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E5", "E5");

            cl5.Value2 = "Ghi chú";

            cl5.ColumnWidth = 50;

            ////////////////////////////////////////////

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("B5", "E5");

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

            int rowStart = 6;

            int columnStart = 2;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd+1];

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
        // Trả về ngày đầu tiên của tháng
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);
            return aDateTime;
        }
        // Trả về ngày cuối cùng của tháng.
        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);

            // Cộng thêm 1 tháng và trừ đi một ngày.
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);
            return retDateTime;
        }
    }
}
