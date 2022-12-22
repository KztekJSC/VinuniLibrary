using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using CustomMessageBox;
using DocumentFormat.OpenXml.Bibliography;
using Futech.Tools;

namespace RegisterLibVin
{
    public partial class frmRegistCard : Form
    {

        #region Khai báo biến đơn
        byte Header = 0x01;
        string CardIDOld = "";
        public byte[] EventData { get; set; }

        public byte[] Mathe;
        private string maThe;
        public string textCardID;

        public byte[] ReadData;

        public string KeyRead = "";
        public string temCardKeyRead = "";
        public string KeyWrite = "";

        bool SaveKeyA = false;
        bool isKey;
        public bool isUpdate;

        bool Long16ByteReadLan1 = false;
        bool Long16ByteReadLan2 = false;

        bool Long16ByteWriteLan1 = false;
        bool Long16ByteWriteLan2 = false;

        bool isQuetThe = false;
        string ByteExam = "";
        string TextBoxExam = "";

        List<byte> byteAddLan1 = new List<byte>();
        List<byte> byteAddLan2 = new List<byte>();


        bool isGetOutData = false;
        bool isError = false;
        bool isAddHand = false;
        string ReadMaSV;

        #endregion
        #region Khai báo biến mảng
        private Dictionary<string, byte> SectorDefines = new Dictionary<string, byte>()
        {
            { "Sector0", 0x00},
            { "Sector1", 0x01},
            { "Sector2", 0x02},
            { "Sector3", 0x03},
            { "Sector4", 0x04},
            { "Sector5", 0x05},
            { "Sector6", 0x06},
            { "Sector7", 0x07},
            { "Sector8", 0x08},
            { "Sector9", 0x09},
            { "Sector10", 0x10},
            { "Sector11", 0x11},
            { "Sector12", 0x12},
            { "Sector13", 0x13},
            { "Sector14", 0x14},
            { "Sector15", 0x15},
        };

        private Dictionary<string, byte> KeyTypeDefines = new Dictionary<string, byte>()
        {
            {"KeyA", 0x60},
            {"KeyB", 0x61},
        };
        private Dictionary<string, byte> BlockDefines = new Dictionary<string, byte>()
        {
            {"Block0", 0x00},
            {"Block1", 0x01},
            {"Block2", 0x02},
            {"Block3", 0x03},
        };
        enum Em_Key
        {
            keyA = 0x60,
            keyB = 0x61,
        }
        enum Em_Sector
        {
            sector0 = 0x00,
            sector1 = 0x01,
            sector2 = 0x02,
            sector3 = 0x03,
            sector4 = 0x04,
            sector5 = 0x05,
            sector6 = 0x06,
            sector7 = 0x07,
            sector8 = 0x08,
            sector9 = 0x09,
        }
        enum Em_Block
        {
            block0 = 0x00,
            block1 = 0x01,
            block2 = 0x02,
            block3 = 0x03,
        }
        //private Dictionary<Em_TextData, Tuple<int, TextBox>> DATADETAIL = new Dictionary<Em_TextData, Tuple<int, TextBox>>();
        enum Em_TextData
        {
            HoTen = 1,
            MSSV = 2,
            Khoa = 3,
            Gmail = 4,
            Phone = 5,
            Other = 6,
        }
        private enum Em_Fuction
        {
            SaveKey,
            Request,
            CardId,
            Select,
            Authen,
            WriteData,
            WriteKey,
            Read,
            Halt
        }
        private enum StatusCard
        {
            TheMoi = 1,
            TheCuKeyCu = 2,
            TheCuKeyMoi = 3,
        }
        private void CalculateCRC(List<byte> bytes, out byte[] crc)
        {
            byte[] data = new byte[bytes.Count - 1];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = bytes[i + 1];
            }
            crc = ComputeCrc(data);
        }
        private static ushort[] CrcTable = {
                0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
                0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
                0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
                0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
                0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
                0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
                0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
                0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
                0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
                0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
                0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
                0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
                0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
                0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
                0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
                0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
                0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
                0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
                0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
                0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
                0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
                0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
                0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
                0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
                0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
                0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
                0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
                0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
                0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
                0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
                0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
                0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040 };

        // Hàm tính 2 byte cuối CRC-H và CRC-L theo chuẩn CRC16
        public static byte[] ComputeCrc(byte[] data)
        {
            ushort crc = 0xFFFF;

            foreach (byte datum in data)
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ datum) & 0xFF]);

            return BitConverter.GetBytes(crc);
        }
        List<byte> WriteDataTest = new List<byte> { 0x01 };
        byte[] successfulRequest = new byte[8];
        byte[] errorRequest = new byte[7];
        byte[] answerCardIn = new byte[7];
        byte[] answerCardOut = new byte[7];
        byte[] errorCardID = new byte[7];     // answerCard: Byte có thẻ
        byte[] successfulCardID = new byte[4];     // answerCard: Byte có thẻ
        byte[] successfulSelect = new byte[7];
        byte[] successfulSaveKey = new byte[7];
        byte[] successfulAuthen = new byte[7];
        byte[] successfulRead = new byte[4];     // answerCard: Byte có thẻ
        byte[] successfulWrite = new byte[7];
        byte[] errorRead = new byte[7];     // answerCard: Byte có thẻ
        byte[] byteReceiveHalt = new byte[7];     // answerCard: Byte có thẻ
        #endregion
        public frmRegistCard()
        {
            InitializeComponent();
            ConnectSQL.ConnectConfig();
            //for (int i = 1; i < 100; i++)
            //{
            //    cbxCOM_Card.Items.Add("COM" + i.ToString());
            //}

            //cbxCOM_Card.SelectedIndex = 3;
        }
        SerialPort port_Card = new SerialPort();

        private void WriteScanBytes()
        {
            if (port_Card.IsOpen)
            {
                while (port_Card.BytesToRead > 0)
                {
                    port_Card.ReadByte();
                }
                isReadScan = true;
                List<byte> byteScan = RequestScanBytes();            //RequestScanBytes();

                port_Card.Write(byteScan.ToArray(), 0, byteScan.Count);
                lblDevice.Visible = true;
            }
        }
        //private void SetText(string text)
        //{
        //    if (lstReceivedMessage.InvokeRequired)
        //    {
        //        lstReceivedMessage.Invoke(new MethodInvoker(delegate { SetText(text); }));

        //        return;
        //    }
        //    if (lstReceivedMessage.Items.Count > 100) lstReceivedMessage.Items.Clear();
        //    lstReceivedMessage.Items.Add(DateTime.Now.ToString("HH:mm:ss") + ": " + text);
        //    lstReceivedMessage.Items.Add("- - -");
        //    lstReceivedMessage.SelectedIndex = lstReceivedMessage.Items.Count - 1;
        //}
        private void OpenPort(SerialPort port, string portName, int baudRate, int timeout)
        {
            if (port == null)
            {
                port = new SerialPort();
            }
            else if (port.IsOpen)
            {
                return;
            }
            try
            {
                port.PortName = portName;
                port.BaudRate = baudRate;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                port.Parity = Parity.None;
                port.ReadBufferSize = 4096;
                port.WriteBufferSize = 4096;
                port.ReadTimeout = timeout;
                port.WriteTimeout = timeout;
                port.Encoding = Encoding.GetEncoding(0x4e4);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                //SetText("portName: " + ex.ToString());
                lblConnect.Text = "Card Reader disconnected ";
                lblConnect.ForeColor = Color.Red;
                if (port.IsOpen)
                {
                    port.Close();
                }
                throw;
            }
        }
        private void OpenPort_Card()
        {
            try
            {
                // Tên cổng COM được cấu hình trong form Setting và truyền qua NameCom
                string com = Properties.Settings.Default.NameCOM;
                this.OpenPort(port_Card, Properties.Settings.Default.NameCOM, 19200, -1);
                this.port_Card.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived_Card);
                if (port_Card.IsOpen)
                {
                    lblConnect.Text = "Card Reader connected ";
                    lblConnect.ForeColor = Color.Green;
                }
                //SetText("Card Reader connected ");
                else
                {
                    lblConnect.Text = "Card Reader disconnected ";
                    lblConnect.ForeColor = Color.Red;
                }

                //SetText("Card Reader disconnected ");
            }
            catch (Exception ex)
            {
                //SetText("Card: " + ex.ToString());
            }
        }
        private void ClosePort()
        {
            this.port_Card.DataReceived -= new SerialDataReceivedEventHandler(this.serialPort_DataReceived_Card);
            if (this.port_Card.IsOpen)
                this.port_Card.Close();
        }

        #region Bien Bool
        // Các biến ghi bytes
        bool isWriteCardID;
        bool isWriteSelect;
        bool isWriteSaveKey;
        bool isWriteAuthen;
        bool isWriteRead;
        bool isWriteData;
        bool isWriteKey;
        bool isWriteHalt;

        // Các biến đọc bytes
        bool isReadScan = false;
        bool quetThe = true;
        bool isReadSaveKey = false;
        bool isWriteRequest = false;
        bool isReadRequest = false;
        bool isReadCardID = false;
        bool isReadSelect = false;
        bool isReadAuthen = false;
        bool isReadRead = false;
        bool isReadWrite = false;
        bool isbtnWrite = false;
        bool isReadHalt = false;
        bool isbtnHalt = false;
        int vao1Lan = 0;

        string ticketCode = "";


        #endregion
        private void serialPort_DataReceived_Card(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Bắt đầu đọc lệnh Scan
                if (isReadScan)
                {
                    ReadScan();
                    return;
                }
                else
                {
                    if (!isbtnRead && !isbtnWrite && !isbtnDelete && !isbtnHalt)
                        QuetThe();

                    if (!isbtnHalt && isbtnRead)   // Nút nhấn Read
                    {

                        if (!ProcessCard(Em_Key.keyB, Em_Sector.sector1, Em_Block.block0, "1", false))
                        {
                            Halt(true);
                            return;
                        }
                        if (!ProcessCard(Em_Key.keyB, Em_Sector.sector2, Em_Block.block0, "2", false))
                        {
                            Halt(true);
                            return;
                        }
                        if (!isError)
                        {
                            CreatSQL_Read();
                            LoadDGV();
                            ShowData();
                        }
                        else
                        {
                            ShowErrorSQL();
                        }
                        Halt(true);

                    }
                    /* Khoông ghi Data vào block 3 ->  Block 3: Chứa Key
                     * Filter: Hàm lọc dấu chữ cái -> Chuyển về text không dấu 
                    */
                    if (!isbtnHalt && isbtnWrite || isbtnDelete)  // Nút nhấn Write hoặc Delete
                    {
                        if (!ProcessCard(Em_Key.keyB, Em_Sector.sector1, Em_Block.block0, Filter(txbMSV.Texts), false))
                        {
                            Halt(true);
                            isError = true;
                        }
                        if (!ProcessCard(Em_Key.keyB, Em_Sector.sector2, Em_Block.block0, Filter(txbEmail.Texts), false))
                        {
                            Halt(true);
                            isError = true;
                        }
                        // Creat SQL
                        if (!isError)
                        {
                            CreatSQL_Write();
                            LoadDGV();
                        }
                        else
                        {
                            ShowErrorSQL();
                        }
                        if (isbtnDelete)
                        {
                            txbMSV.Invoke(new Action(() =>
                            {
                                txbHoDem.Texts = "";
                                txbTen.Texts = "";
                                txbMSV.Texts = "";
                                txbEmail.Texts = "";
                                txbPhone.Texts = "";
                                txbCardID.Texts = "";
                                txbNote.Texts = "";
                            }));
                        }
                        Halt(true);
                        return;

                    }
                    // Cho nut nhan Halt
                    HaltButton();
                }
            }
            catch (Exception ex)
            {
                //SetText("Card data error: " + ex.ToString());
            }
        }
        bool isCheckDki = false;
        private bool isCheckRegisted()
        {
            if (isbtnWrite)
            {
                string str = $"select * from tblRegister where MSSV = '{txbMSV.Texts}' and IsDelete = '0'";
                DataTable dt = ConnectSQL.dbConnection.FillData(str);
                if (dt != null && dt.Rows.Count > 0)
                {
                    isCheckDki = true;
                    MessageBox.Show("Không thể đăng ký, MSV này đã được đăng ký", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return true;

                }
                else
                    return false;
            }
            else
            {
                return false;
            }

        }
        private void ShowData()
        {
            //if(isTheChuaDki == false)
            //{

            //}
            txbEmail.Invoke(new Action(() =>
            {
                string studentID = "";
                string str1 = $"select * from tblRegister where CardNumber = '{maThe}' and IsDelete = '0'";
                DataTable dt1 = ConnectSQL.dbConnection.FillData(str1);
                if(dt1 != null && dt1.Rows.Count > 0)
                {
                    DataRowView drv = dt1.DefaultView[0];
                    studentID = drv["StudentID"].ToString();
                }

                string str = $"select * from tblQLSV where StudentID = '{studentID}'";
                DataTable dt = ConnectSQL.dbConnection.FillData(str);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRowView drv = dt.DefaultView[0];
                    txbHoDem.Texts = drv["Surname"].ToString();
                    txbTen.Texts = drv["Name"].ToString();
                    txbEmail.Texts = drv["Email"].ToString();
                    txbPhone.Texts = drv["PhoneNumber"].ToString();
                    txbCardID.Texts = drv["CardID"].ToString();
                    txbNote.Texts = drv["Note"].ToString();
                }

            }));
        }
        private void CreatSQL_Write()
        {
            // Bang tblcard
            string CardID, cardNumber;
            bool isDelete;
            CreatSQL_tblCard(out CardID, out cardNumber, out isDelete);

            CreatSQL_tblQLSV();

            CreatSQL_tblRegister();
            
            
           
            
            
        }
        string StudentIDAddHand;
        private void CreatSQL_tblQLSV()
        {
            if (isbtnWrite)
            {
                if(isAddHand == true)   // Nếu là dữ liệu thêm tay
                {
                    string StudentID = Guid.NewGuid().ToString();
                    StudentIDAddHand = StudentID;
                    int stt = 11;
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"insert into tblQLSV ");
                    sb.Append($"values('{stt}',N'{txbHoDem.Texts}',N'{txbTen.Texts}',N'{txbEmail.Texts}','{txbMSV.Texts}',");
                    sb.Append($"'{txbPhone.Texts}','{txbCardID.Texts}',N'{txbNote.Texts}','1','0','{StudentID}')");

                    ConnectSQL.dbConnection.ExecuteCommand(sb.ToString());
                }
                else   // Nếu ghi dữ liệu có trong danh sách
                {
                    // Trường hợp IsRegister đã kiểm tra trước lúc ghi dữ liệu nên không cần ĐK IsRegister = 0, thêm cho chắc (nếu cần cải thiện tốc độ tính sau)
                    string str2 = $"update tblQLSV set IsRegister = '1' where StudentID = '{txbStudentID.Texts}' and IsDelete = '0' and IsRegister = '0'";
                    ConnectSQL.dbConnection.ExecuteCommand(str2);
                }
            }
            if (isbtnDelete)
            {
                string idStudent;
                string reg = $"select * from tblRegister where CardNumber = '{maThe}' and IsDelete = '0'";
                DataTable dt = ConnectSQL.dbConnection.FillData(reg);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRowView drv = dt.DefaultView[0];
                    idStudent = drv["StudentID"].ToString();

                    // Check theo 2 trường, tránh TH check theo MSV nhưng msv rỗng và có nhiều MSV rỗng
                    // Check theo 2 trường vẫn có khả năng có nhiều SV có 2 trường này rỗng -> ko phân biệt đc
                    // Nên check theo CardID (chưa thực hiện)
                    string str2 = $"update tblQLSV set IsRegister = '0' where StudentID = '{idStudent}' and IsRegister = '1'";
                    ConnectSQL.dbConnection.ExecuteCommand(str2);
                }

            }

            // Khi update đăng ký -> Bảng Register mới thay đổi
        }

       

        private void CreatSQL_tblRegister()
        {
            if (isbtnWrite)
            {
                // TH có bản ghi này rồii đã check trc khi ghi
                string CardID = Guid.NewGuid().ToString();
                DateTime datetime = DateTime.Now;
                string userFullName = Properties.Settings.Default.FullName;
                //var studentID = txbStudentID.Texts;

                string studentID = "";
                if (isAddHand)
                {
                    studentID = StudentIDAddHand;
                }
                else
                {
                    studentID = txbStudentID.Texts;
                }

                string MSV = Filter(txbMSV.Texts);
                bool isDelete = false;
                // Thêm moi bảng Register
                string strRegister = $"insert into tblRegister values ('{CardID}', '{studentID}', '{txbCardNumber.Texts}', '{MSV}', '{datetime}', N'{userFullName}', '{isDelete}')";
                ConnectSQL.dbConnection.ExecuteCommand(strRegister);
            }
            if (isbtnDelete)
            {
                // Không cần select đã có điều kiện select sau hàm CardID, Nếu có mới tiếp tục
                // Update xóa dữ liệu IsDelete thành 1 (bảng Register)
                string str2 = $" update tblRegister set IsDelete = '1' where Cardnumber = '{maThe}' and IsDelete = '0'";
                ConnectSQL.dbConnection.ExecuteCommand(str2);
            }
        }
        private void CreatSQL_tblRegisterAndtblStudent(string CardID, string cardNumber, bool isDelete)
        {
            CardID = Guid.NewGuid().ToString();
            DateTime datetime = DateTime.Now;
            string userFullName = Properties.Settings.Default.FullName;
            var studentID = Guid.NewGuid();
            string studentName = Filter(txbHoDem.Texts);
            string studentIDDB = "";
            // Check cardnumber và isdelete cho cả 2 bảng 
            string str1 = "use VinUniver; select * from tblRegister where Cardnumber = '" + cardNumber + "' and IsDelete = '0'";
            DataTable dtRegister = ConnectSQL.dbConnection.FillData(str1);

            if (dtRegister != null && dtRegister.Rows.Count > 0)
            {
                // Update xóa dữ liệu IsDelete thành 1 (bảng Register)
                string str2 = $"use VinUniver; update tblRegister set IsDelete = '1' where Cardnumber = '{cardNumber}' and IsDelete = '0'";
                ConnectSQL.dbConnection.ExecuteCommand(str2);

                // Update xóa dữ liệu IsDelete thành 1 (bảng Student)
                DataRowView drv = dtRegister.DefaultView[0];
                studentIDDB = drv["StudentID"].ToString();
                string str3 = $"use VinUniver; update tblStudent set IsDelete = '1' where StudentID = '{studentIDDB}'";
                ConnectSQL.dbConnection.ExecuteCommand(str3);

            }
            // Nếu là xóa thẻ thì không thêm
            if (!isbtnDelete)
            {
                // Thêm moi bảng Register
                string strRegister = $"use VinUniver; insert into tblRegister values ('{CardID}', '{studentID}', '{cardNumber}', '{studentName}', '{datetime}', '{userFullName}', '{isDelete}')";
                ConnectSQL.dbConnection.ExecuteCommand(strRegister);

                // Thêm moi bảng Student
                //string strStudent = $"use VinUniver; insert into tblStudent values ('{studentID}', '{studentName}', '{Filter(txbMSV.Texts)}', '{Filter(txbKhoa.Texts)}', '{Filter(txbEmail.Texts)}', '{Filter(txbPhone.Texts)}', '{Filter(txbOther.Texts)}','{isDelete}')";
                //ConnectSQL.dbConnection.ExecuteCommand(strStudent);
            }
            //lblSQL.Invoke(new Action(() =>
            //{
            //    lblSQL.Text = "Lưu dữ liệu hoàn tất";
            //    picTrueSQL.Visible = true;
            //    picFalseSQL.Visible = false;
            //}));
        }

        private void CreatSQL_tblCard(out string CardID, out string cardNumber, out bool isDelete)
        {
            CardID = Guid.NewGuid().ToString();
            string cardNo = "No1";
            string cardKey = KeyWrite;
            cardNumber = txbCardNumber.Texts;
            isDelete = false;
            string getData = "Select * from tblCard where CardNumber = '" + cardNumber + "'";
            DataTable dt = ConnectSQL.dbConnection.FillData(getData);
            if (dt != null && dt.Rows.Count > 0)
            {

            }
            else
            {
                string strCard = $"use VinUniver; insert into tblCard values ('{CardID}', '{cardNo}', '{cardNumber}', '{cardKey}','{isDelete}')";
                ConnectSQL.dbConnection.ExecuteCommand(strCard);
            }
        }

        private void ShowErrorSQL()
        {
            //lblSQL.Invoke(new Action(() =>
            //{
            //    lblSQL.Text = "Lưu dữ liệu lỗi";
            //    lblSQL.ForeColor = Color.Red;
            //    picTrueSQL.Visible = false;
            //    picFalseSQL.Visible = true;
            //}));
        }

        private void CreatSQL_Read()
        {
            var CardID = Guid.NewGuid();
            string cardNumber = txbCardNumber.Texts;
            string cardNo = "No1";
            string cardKey = KeyRead;
            DateTime datetime = DateTime.Now;
            string studentName = txbHoDem.Texts;
            string studentCode = txbMSV.Texts;
            string userFullName = "Admin";
            string cardID = "";
            string StudentID = "";
            bool isDelete = false;
            string ID = Guid.NewGuid().ToString();

            // Bang tblcard
            CreatSQL_tblCard(CardID, cardNumber, cardNo, cardKey, isDelete);
            
        }

        private void CreatSQL_tblCard(Guid CardID, string cardNumber, string cardNo, string cardKey, bool isDelete)
        {
            string getData = "use VinUniver; select * from tblCard where CardNumber = '" + cardNumber + "'";
            DataTable dt = ConnectSQL.dbConnection.FillData(getData);
            if (dt != null && dt.Rows.Count > 0)
            {
            }
            else
            {
                string strCard = $"use VinUniver; insert into tblCard values ('{CardID}', '{cardNo}', '{cardNumber}', '{cardKey}','{isDelete}')";
                ConnectSQL.dbConnection.ExecuteCommand(strCard);
            }
        }

        private bool Function(Em_Key typeKey, Em_Sector sector, Em_Block block, string textData, bool isWriteHalt, Em_Fuction fuction)
        {
            switch (fuction)
            {
                case Em_Fuction.Request:
                    return Request();

                case Em_Fuction.CardId:
                    return CardID();

                case Em_Fuction.SaveKey:
                    return SaveKey(typeKey, sector);

                case Em_Fuction.Select:
                    return Select();

                case Em_Fuction.Authen:
                    return Authenticate(typeKey, sector);

                case Em_Fuction.WriteData:
                    return WriteData(block, textData);

                case Em_Fuction.Read:
                    return Read(block, textData, isWriteHalt);

                case Em_Fuction.Halt:
                    return Halt(isWriteHalt);
            }
            return false;
        }
        private bool ProcessCard(Em_Key typeKey, Em_Sector sector, Em_Block block, string textData, bool isWriteHalt)
        {
            if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.Request))
            {
                if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.CardId))
                {
                    if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.SaveKey))
                    {
                        if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.Select))
                        {
                            if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.Authen))
                            {
                                if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.Read))
                                {
                                    if (Long16ByteReadLan1)
                                    {
                                        Read(Em_Block.block1, textData, isWriteHalt);

                                        if (Long16ByteReadLan2)
                                        {
                                            Read(Em_Block.block2, textData, isWriteHalt);
                                        }
                                    }
                                    Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.Halt);
                                    return true;
                                }
                                else if (Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.WriteData))
                                {
                                    if (Long16ByteWriteLan1)
                                    {
                                        Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.WriteData);
                                        if (Long16ByteWriteLan2)
                                        {
                                            Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.WriteData);
                                        }
                                    }
                                    Function(typeKey, sector, block, textData, isWriteHalt, Em_Fuction.Halt);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;

        }
        /* ------------------------------------------------------------------------------------------------------------------*/
        int timeOut = 0;
        bool inTimeOut;
        private bool QuetThe()
        {
            bool result = false;
            if (!CheckEnoughByte())
            {
                return false;
            }

            int k = 0;
            byte[] bufferData1 = new byte[7];

            if (port_Card.BytesToRead >= 7)
            {

                while (port_Card.BytesToRead > 0)
                {
                    if (k < bufferData1.Length)
                    {
                        bufferData1[k] = (Byte)port_Card.ReadByte();
                        k++;
                    }
                    else break;
                }
            }

            // Invoke đưa dữ liệu về luồng chính
            rjTextBox1.Invoke((Action)(() =>
            {
                if (compareTwoByte(bufferData1, answerCardIn))
                {
                    rjTextBox1.Texts = "Đã nhận thẻ";
                    rjTextBox1.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                    rjTextBox1.ForeColor = Color.Green;
                    result = true;
                }
                else if (compareTwoByte(bufferData1, answerCardOut))
                {
                    rjTextBox1.Texts = "Chưa nhận thẻ";
                    rjTextBox1.Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                    rjTextBox1.ForeColor = Color.Red;
                    //MessageBox.Show("Chuaw nhan the");
                    result = false;
                }
                else
                {
                    MessageBox.Show("Mời quẹt thẻ lại", "Swipe");
                    result = false;
                    ClearMemory();
                }
            }));
            //isQuetThe = false;
            //if (result)
            //{
            //    btnRead.Invoke(new Action(() =>
            //    {
            //        btnRead_Click(null, null);
            //    }));
            //}
            return result;
        }
        private bool CheckEnoughByte()
        {
            timerAutoHalt.Enabled = true;
            while (port_Card.BytesToRead <= 6)
            {
                if (inTimeOut)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            timerAutoHalt.Enabled = false;
            timeOut = 0;
            return true;
        }

        private bool Halt(bool isWriteHalt)
        {
            bool result = false;
            if (isWriteHalt)
            {
                isWriteSaveKey = false;


                WriteHalt();
            }
            // Bắt đầu đọc lệnh Halt
            if (isReadHalt)
            {
                result = ReadHalt();
                NewCard = false;
                isbtnWrite = false;
                isbtnRead = false;
                isbtnDelete = false;
                isWriteRequest = false;    // Khi ghi key writeRequest = true -> cho thanh false khi halt
                isError = false;
                DaDKi = false;              // Biến kiểm tra thẻ này đã đăng ký
                isCheckDki = false;         // Biến kiểm tra dữ liệu thông tin này đã đăng ký
                isStopMidWay = false;      // Biến kiểm tra có dừng giữa chừng không, nếu có là chưa đủ điều kiện ghi
                isAddHand = false;          // Biến kiểm tra Lúc ghi dữ liệu có phải thêm tay không
                //picTrueDone.Invoke(new Action(() =>
                //{
                //    picTrueDone.Visible = true;
                //    if (isError) picFalseDone.Visible = true;
                //}));

            }
            return result;
        }

        private bool Read(Em_Block block, string textData, bool isHalt)
        {
            bool result = false;
            if (isWriteRead && isbtnRead)
            {
                WriteRead(block);
            }
            // Bắt đầu đọc lệnh Read
            if (isReadRead && isbtnRead)
            {
                // Neu Auto/ Neu Write/ Neu Data/ Neu Key
                result = ReadRead(textData, isHalt);
            }
            return result;
        }

        private bool WriteData(Em_Block block, string textData)
        {
            bool result = false;
            if (isWriteData && !isbtnRead)
            {
                CreatWriteData(block, textData);
            }
            if (isReadWrite && !isbtnRead)
            {
                result = ReadWrite();
            }
            return result;
        }

        private bool Authenticate(Em_Key typeKey, Em_Sector sector)
        {
            bool result = false;
            if (isWriteAuthen)
            {
                WriteAuthenticate(typeKey, sector);
            }
            // Bắt đầu đọc lệnh Authen 
            if (isReadAuthen)
            {
                result = ReadAuthenticate();
            }
            return result;
        }
        bool DaDKi = false;
        private bool Select()
        {
            bool result = false;
            if (isWriteSelect)
            {
                WriteSelect();
            }
            // Bắt đầu đọc lệnh Select
            if (isReadSelect)
            {
                result = ReadSelect();
            }
            return result;
        }
        bool isStopMidWay;
        private bool CardID()
        {
            bool result = false;
            if (isWriteCardID == true && isReadHalt == false) // isReadHalt ??
            {
                WriteCardID();
            }
            // Bắt đầu đọc byte CardID
            if (isReadCardID)
            {
                result = ReadCardID();
            }
            // Các điều kiện check trước khi ghi / hủy dữ liệu 
            if (isbtnRead)
            {
                CheckIsRegisterRead();
            }

            if (isbtnWrite)
            {
                // Kiểm tra thẻ đăng ký hay chưa đăng ký: Chưa đky -> Trả về true
                if (!CheckIsRegistedCard())
                {
                    //result = false;
                    isStopMidWay = true;
                    return false;
                }
                // Kiểm tra dữ liệu chuẩn bị ghi vào thẻ là dữ liệu thêm tay hay dữ liệu có trong danh sách
                // True - là dữ liệu có trong danh sách
                if (!CheckDataHandOrList())
                {
                    isAddHand = true;      // Biến thêm tay = true (Nếu ko phải dữ liệu trong danh sách)
                    DialogResult dt = MessageBox.Show("Thêm vào danh sách và Tiếp tục ghi dữ liệu ?", "Thông tin này hiện chưa có trong danh sách", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if(dt == DialogResult.Yes)
                    {

                    }
                    else  // Nếu No - Cancel
                    {
                        //result = false;
                        isStopMidWay = true;
                        return false;
                    }
                }
                // Kiểm tra dữ liệu này đã đăng ký chưa
                if (!CheckIsRegistedData())
                {
                    MessageBox.Show("Dữ liệu này đã được đăng ký cho thẻ khác, Không thể đăng ký", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    //result = false;
                    isStopMidWay = true;
                    return false;
                }
            }
            if (isbtnDelete)
            {
                // Kiểm tra nếu thẻ ko có dữ liệu thì ko cần hủy đăng ký -> Halt
                if (!CheckIsRegisterCardDelete())
                {
                    result = false;
                }
            }
            

            return result;

        }
        private void CheckIsRegisterRead()
        {
            string cardNumber = maThe;

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tblRegister ");
            sb.Append("where tblRegister.CardNumber = '" + cardNumber + "' and tblRegister.IsDelete = '0'");
            DataTable dtNew = ConnectSQL.dbConnection.FillData(sb.ToString());
            if (dtNew != null && dtNew.Rows.Count > 0)
            {
                txbCheckNewCard.Invoke(new Action(() =>
                {
                    txbCheckNewCard.Texts = "Thẻ đã đăng ký";
                    txbCheckNewCard.ForeColor = Color.Green;
                }));
            }
            else
            {
                txbCheckNewCard.Invoke(new Action(() =>
                {
                    txbCheckNewCard.Texts = "Thẻ chưa đăng ký";
                    txbCheckNewCard.ForeColor = Color.Green;
                }));
            }
        }
        private bool CheckIsRegisterCardDelete()
        {
            string cardNumber = maThe;

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tblRegister ");
            sb.Append("where tblRegister.CardNumber = '" + cardNumber + "' and tblRegister.IsDelete = '0'");
            DataTable dtNew = ConnectSQL.dbConnection.FillData(sb.ToString());
            if (dtNew != null && dtNew.Rows.Count > 0)
            {
                txbCheckNewCard.Invoke(new Action(() =>
                {
                    txbCheckNewCard.Texts = "Thẻ đã đăng ký";
                    txbCheckNewCard.ForeColor = Color.Green;
                }));
                return true;
            }
            else
            {
                txbCheckNewCard.Invoke(new Action(() =>
                {
                    txbCheckNewCard.Texts = "Thẻ chưa đăng ký";
                    txbCheckNewCard.ForeColor = Color.Green;
                }));
                MessageBox.Show("Thẻ đã trống, không thể xóa", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
                isStopMidWay = true;
            }
        }
        bool isTheChuaDki = false;
        private bool CheckIsRegistedCard()
        {
            string cardNumber = maThe;

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tblRegister ");
            sb.Append("where tblRegister.CardNumber = '" + cardNumber + "' and tblRegister.IsDelete = '0'");
            DataTable dtNew = ConnectSQL.dbConnection.FillData(sb.ToString());
            if (dtNew != null && dtNew.Rows.Count > 0)
            {
                txbCheckNewCard.Invoke(new Action(() =>
                {
                    txbCheckNewCard.Texts = "Thẻ đã đăng ký";
                    txbCheckNewCard.ForeColor = Color.Green;
                }));
                
                if (isbtnWrite)
                {
                    MessageBox.Show("Thẻ này đã được đăng ký, Mời hủy đăng ký trước khi tiếp tục!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    isStopMidWay = true;
                    return false;
                }
                return true;
            }
            else
            {
                txbCheckNewCard.Invoke(new Action(() =>
                {
                    txbCheckNewCard.Texts = "Thẻ chưa đăng ký";
                    txbCheckNewCard.ForeColor = Color.Green;
                    //isTheChuaDki = true ;
                }));
                return true;
            }
            
        }
        private bool CheckDataHandOrList()
        {
            // Không cần check IsDelete vì chỉ hiển thị dữ liệu có IsDelete = 0 cho người dùng 
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tblQLSV ");
            sb.Append($"where Email = '{txbEmail.Texts}' ");
            sb.Append($"and StudentCode = '{txbMSV.Texts}' and PhoneNumber = '{txbPhone.Texts}' and Note = '{txbNote.Texts}' ");

            DataTable dtNew = ConnectSQL.dbConnection.FillData(sb.ToString());
            if (dtNew != null && dtNew.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckIsRegistedData()
        {
            // Không cần check IsDelete vì chỉ hiển thị dữ liệu có IsDelete = 0 cho người dùng 
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tblQLSV ");
            sb.Append($"where Email = '{txbEmail.Texts}' ");
            sb.Append($"and StudentCode = '{txbMSV.Texts}' and PhoneNumber = '{txbPhone.Texts}' and Note = '{txbNote.Texts}' ");
            sb.Append($"and IsRegister = '1'");

            DataTable dtNew = ConnectSQL.dbConnection.FillData(sb.ToString());
            if (dtNew != null && dtNew.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool Request()
        {
            bool result = false;
            if (isWriteRequest)
            {
                WriteRequest();
            }
            if (isReadRequest)
            {
                result = ShowRequestData();
            }
            return result;
        }

        private bool SaveKey(Em_Key typeKey, Em_Sector sector)
        {
            bool result = false;
            // Biến xác định có phải hàm ProcessKey ko 
            if (isWriteSaveKey)
            {
                WriteSaveKey(typeKey, sector);
            }
            // Bắt đầu đọc lệnh SaveKey 
            if (isReadSaveKey)
            {
                result = ReadSaveKey();
            }
            TextBoxExam = "";          // Reset text đọc từ 3 block (Môix lần vào hàm SaveKey -> đã sang sector khác)
            return result;

        }


        private void WriteRequest()
        {
            ClearMemory();
            List<byte> byteCardId = RequestRequestBytes();
            WriteBytes(byteCardId);
            isReadRequest = true;
            isWriteRequest = false;
        }
        int m = 0;
        private bool ReadHalt()
        {
            bool result = false;
            int a = 0;
            // Kiểm tra nếu sau 100ms chưa đủ byte thì Halt
            if (!CheckEnoughByte())
            {
                return false;
            }

            int k = 0;

            int CountByte1 = port_Card.BytesToRead;
            byte[] bufferData1 = new byte[7];

            while (port_Card.BytesToRead > 0)
            {
                if (k < bufferData1.Length)
                {
                    bufferData1[k] = (Byte)port_Card.ReadByte();
                    k++;
                    if (k == bufferData1.Length) break;

                }
                else break;
            }

            if (compareTwoByte(bufferData1, byteReceiveHalt))
            {

                lblDone.Invoke(new Action(() =>
                {
                    isGetOutData = true;
                    lblDone.Text = "Hoàn thành";
                    lblDone.ForeColor = Color.Black;
                    lblDone.Visible = true;
                    picTrueDone.Visible = true;
                    picFalseDone.Visible = false;

                }));
                if (isbtnHalt)
                {
                    LogHelper.LogUser("Page Card Register", $"Người dùng nhấn Reset thành công", Application.StartupPath);
                    //LogHelper.LogUser("Page Card Register", $"Người dùng đọc dữ liệu với MSV: {txbMSV.Texts} cho mã thẻ: {maThe}", Application.StartupPath);
                }
                if (isbtnWrite && !isError && !DaDKi && !isCheckDki && !isStopMidWay)
                {
                    LogHelper.LogUser("Page Card Register", $"Người dùng ghi thành công dữ liệu với MSV: {txbMSV.Texts} cho mã thẻ: {maThe}", Application.StartupPath);
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
                if (isbtnDelete && !isError && !isStopMidWay)
                {
                    LogHelper.LogUser("Page Card Register", $"Người dùng xóa thành công dữ liệu của thẻ: {maThe}", Application.StartupPath);
                    MessageBox.Show("Hủy đăng ký thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                result = true;

            }
            else
            {
                lblDone.Invoke(new Action(() =>
                {
                    isGetOutData = true;
                    lblDone.Text = "Hoàn thành";
                    lblDone.ForeColor = Color.Black;
                    lblDone.Visible = true;
                    picTrueDone.Visible = true;
                    picFalseDone.Visible = false;
                }));
            }
            isReadHalt = false;
            ClearMemory();
            return result;
        }

        private void WriteHalt()
        {
            ClearMemory();

            List<byte> bytes = isWriteHaltBytes();
            WriteBytes(bytes);
            isReadHalt = true;
            isWriteHalt = false;
        }
        private bool isbtnRead;
        private bool ReadWrite()
        {
            bool result = false;
            int a = 0;
            // Kiểm tra nếu sau 100ms chưa đủ byte thì Halt
            if (!CheckEnoughByte())
            {
                return false;
            }

            //if (port_Card.BytesToRead <= 6) return;
            byte[] buffer = new byte[7];
            int index = 0;
            bool ok = false;
            while (port_Card.BytesToRead > 0)
            {
                buffer[index] = (Byte)port_Card.ReadByte();
                index++;
                if (index > 7) break;
            }
            if (compareTwoByte(buffer, successfulWrite))
            {
                // Show successfully
                if (isbtnDelete)
                {
                    //lblReadWrite.Text = "Xóa dữ liệu thành công";
                }
                else
                {
                    //lblReadWrite.Text = "Ghi thành công";
                }

                //isWriteHalt = true;
                if (Long16ByteWriteLan1 || Long16ByteWriteLan2)
                {
                    // Text dài hơn 16 kí tự nhảy đêns hàm writedata tiếp để đọc hết
                    isWriteData = true;
                }
                else
                {
                    isWriteRequest = true;
                }

                result = true;
            }
            else
            {
                // Show error
                if (isbtnDelete)
                {
                    //lblReadWrite.Text = "Xóa dữ liệu lỗi";
                }
                else
                {
                    //lblReadWrite.Text = "Ghi lỗi";

                }
                MessageBox.Show("Không thể ghi dữ liệu - Mời quẹt thẻ lại", "WriteData", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                isWriteHalt = true;
                isError = true;
                ticketCode = "";
            }
            ClearMemory();
            isReadWrite = false;
            return result;
        }
        private void HaltButton()
        {
            if (isWriteHalt == true && isbtnHalt == true)
            {
                WriteHalt();
            }
            // Bắt đầu đọc lệnh Halt
            if (isReadHalt && isbtnHalt == true)
            {
                ReadHalt();
                isbtnHalt = false;
            }
        }
        private bool ReadRead(string textLocation, bool isHalt)
        {
            bool result = false;
            int a = 0;
            // Kiểm tra nếu sau 100ms chưa đủ byte thì Halt
            if (!CheckEnoughByte())
            {
                return false;
            }
            //if (port_Card.BytesToRead <= 6) return;
            List<byte> buffer = new List<byte>();
            //Byte[] buffer = new byte[10];

            for (int i = 0; i < 7; i++)
            {
                buffer.Add((byte)port_Card.ReadByte());
            }

            byte[] dataRead = buffer.ToArray();
            if (compareTwoByte(dataRead, errorRead))
            {
                MessageBox.Show("Lỗi thao tác - Mời quẹt thẻ lại", "Read", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                // Show error
                if (isHalt)
                {
                    isWriteHalt = true;
                }
                else
                {
                    isWriteSaveKey = true;
                }
                isError = true;
                ticketCode = "";
            }
            else
            {
                //int cot = 0;
                while (port_Card.BytesToRead < 15)
                {
                    continue;
                }
                //cot = 0;
                if (port_Card.BytesToRead == 15)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        buffer.Add((byte)port_Card.ReadByte());
                    }
                    dataRead = buffer.ToArray();
                    List<byte> fourFirstByteList = new List<byte>();
                    for (int i = 0; i <= 3; i++)
                    {
                        fourFirstByteList.Add(buffer[i]);
                    }
                    byte[] fourFirstByte = fourFirstByteList.ToArray();
                    if (compareTwoByte(fourFirstByte, successfulRead))
                    {

                        ReadData = buffer.ToArray();
                        byte[] DataRead = new byte[16];
                        List<byte> response = new List<byte>();
                        for (int i = 4; i < 20; i++)
                        {
                            response.Add(ReadData[i]);
                        }
                        DataRead = response.ToArray();              // ToArray() chuyển từ List sang mảng
                        string Tem = "";
                        string text = "";
                        //textLocation = ByteArrayToString(DataRead);


                        if (Long16ByteReadLan1)
                        {
                            Long16ByteReadLan1 = false;
                            ByteExam = ByteArrayToString(DataRead);
                            TextBoxExam = TextBoxExam + FromHexString(ByteExam);      // Hàm chuyển từ Hex sang string 

                            if (CheckEndText(TextBoxExam))
                            {
                                isWriteRequest = true;
                            }
                            else
                            {
                                isWriteRead = true;
                                Long16ByteReadLan2 = true;
                            }

                        }
                        else if (Long16ByteReadLan2)
                        {
                            Long16ByteReadLan2 = false;
                            ByteExam = ByteArrayToString(DataRead);
                            TextBoxExam = TextBoxExam + FromHexString(ByteExam);
                            if (CheckEndText(TextBoxExam))
                            {
                                isWriteRequest = true;
                            }
                            else
                            {
                                RJMessageBox.Show("Ký tự vượt quá số lượng cho phép (48)", "Read", MessageBoxButtons.OK);
                                isWriteRequest = true;
                            }
                        }
                        else
                        {
                            ByteExam = ByteArrayToString(DataRead);
                            TextBoxExam = FromHexString(ByteExam);
                            if (CheckEndText(TextBoxExam))
                            {
                                isWriteRequest = true;
                            }
                            else
                            {
                                isWriteRead = true;
                                Long16ByteReadLan1 = true;
                            }

                        }
                        txbMSV.Invoke(new Action(() =>
                        {
                            if (textLocation == "1" && isbtnRead)
                            {
                                txbMSV.Texts = TextBoxExam;
                            }
                            if (textLocation == "2" && isbtnRead)
                            {
                                txbEmail.Texts = TextBoxExam;
                            }
                            //if (textLocation == "1" && isbtnWrite)
                            //{
                            //    ReadMaSV = TextBoxExam;
                            //    isWriteData = true;
                            //}
                        }));
                        result = true;
                        // Show successfully
                        //isWriteSaveKey = true;
                        // Chuyển đổi hex sang text có dấu 
                        // Byte DataRead nhận được là byte mã hóa từ Unicode
                        //string base64 = Convert.ToBase64String(DataRead);
                        //byte[] temp2 = Convert.FromBase64String(base64);
                        //string ret = Encoding.Unicode.GetString(temp2);
                        //txbText.Text = ret;                                    
                    }
                    else
                    {
                        MessageBox.Show("Exception - Mời quẹt thẻ lại", "Read", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        isWriteHalt = true;
                        isError = true;
                        ticketCode = "";
                    }

                }
            }
            ClearMemory();
            return result;
            isReadRead = false;

            //xuLyCardOut = true;

            //rdbAuto.Invoke(new Action(() =>
            //{
            //    if (rdbAuto.Checked == true)
            //    {
            //        isWriteHalt = true;
            //    }
            //    if (rdbWriteData.Checked == true)
            //    {
            //        isWriteData = true;
            //    }
            //    else
            //    {
            //        isWriteKey = true;
            //    }

            //}));
            isWriteData = true;

        }


        private void WriteRead(Em_Block block)
        {
            ClearMemory();
            List<byte> bytes2 = isWriteReadBytes(block);
            WriteBytes(bytes2);
            isReadRead = true;
            isWriteRead = false;
            //xuLyCardOut = true;
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
        private bool ReadAuthenticate()
        {
            bool result = false;

            // Kiểm tra nếu sau 100ms chưa đủ byte thì Halt
            if (!CheckEnoughByte())
            {
                return false;
            }

            byte[] buffer = new byte[7];
            int index = 0;
            while (port_Card.BytesToRead > 0)
            {
                buffer[index] = (Byte)port_Card.ReadByte();
                index++;
                if (index == buffer.Length) break;
            }


            if (compareTwoByte(buffer, successfulAuthen))
            {
                result = true;
                DisplaySuccessAuthen();

                if (isbtnRead)
                {
                    isWriteRead = true;
                }
                if (isbtnWrite || isbtnDelete)
                {
                    isWriteData = true;       // Nếu true tiếp tục
                    //isWriteRead = true;
                }
                KeyRead = temCardKeyRead;

            }
            else
            {
                DisplayFalseAuthen();
                isWriteHalt = true;     // Nếu false nhảy vào Halt
                isError = true;
                ticketCode = "";
            }
            isReadAuthen = false;
            return result;
            ClearMemory();
        }
        private void WriteAuthenticate(Em_Key typeKey, Em_Sector sector)
        {
            ClearMemory();
            //01 00 23 02 60 00 44 A6
            List<byte> bytes = isWriteAuthenBytes(typeKey, sector);
            WriteBytes(bytes);
            isReadAuthen = true;
            isWriteAuthen = false;
            //xuLyCardOut = true;
        }
        private int CountText(string textCount)
        {
            // Hàm đếm số lượng của chuỗi string 
            string str;
            int kitu, i, l;
            kitu = i = 0;
            str = textCount;
            l = str.Length;
            while (i < l)
            {
                if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z') || str[i] >= '0' && str[i] <= '9')
                {
                    kitu++;
                }
                else if (str[i] == '\0')
                {
                    break;
                }
                else
                {
                    kitu++;
                }
                i++;
            }
            return kitu;
        }
        private bool CheckEndText(string textCount)
        {
            // Hàm đếm số lượng của chuỗi string 
            int kitu, i, l;
            kitu = i = 0;
            while (i < textCount.Length)
            {
                if (textCount[i] == '\0')
                {
                    return true; ;
                }
                i++;
            }
            return false;
        }
        private bool ReadSaveKey()
        {
            bool result = false;
            try
            {
                // Kiểm tra nếu sau 100ms vẫn chưa đủ byte thì tự Halt
                if (!CheckEnoughByte())
                {
                    return false;
                }

                //if (port_Card.BytesToRead <= 6) return;
                byte[] buffer = new byte[7];
                int index = 0;
                while (port_Card.BytesToRead > 0)
                {
                    buffer[index] = (Byte)port_Card.ReadByte();
                    index++;
                    if (index == buffer.Length) break;
                }
                if (compareTwoByte(buffer, successfulSaveKey))
                {
                    //picTrue.Visible = true;   // Tích xanh 
                    isWriteSelect = true;    // Nhảy đến lệnh tiếp 
                    result = true;
                }
                else
                {
                    picFalseDone.Visible = true;
                    MessageBox.Show("Lỗi thao tác - Mời quẹt thẻ lại", "SaveKey", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    isWriteHalt = true;     // Nếu false nhảy vào Halt quẹt lại 
                    isError = true;

                }
                ClearMemory();
                isReadSaveKey = false;

                //xuLyCardOut = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
                return false;
            }
            return result;
        }
        private void WriteSaveKey(Em_Key typeKey, Em_Sector sector)
        {
            ClearMemory();
            List<byte> bytes = WriteSaveKeyBytes(typeKey, sector);
            WriteBytes(bytes);

            isWriteSaveKey = false;
        }
        private List<byte> WriteSaveKeyBytes(Em_Key typeKey, Em_Sector sector)
        {
            //01 00 2B 08 61 01 FF FF FF FF FF FF 00 C7
            byte temp = 0x00;
            byte ctr1 = 0x2B;
            byte ctr2 = 0x08;
            List<byte> bytes = new List<byte>();
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);
            bytes.Add((byte)typeKey);
            bytes.Add((byte)sector);
            string textPresentKey = Properties.Settings.Default.Key;
            /* Truy vấn check mã thẻ và key có tồn tại trùng không
             * Nếu trùng thẻ đã đc ghi: Thẻ ghi có 2 loại: thẻ đã ghi và trùng key, thẻ đã ghi mà key bị đổi
            */
           
            // Đkien sang hàm tiếp
            isReadSaveKey = true;



            temCardKeyRead = textPresentKey;

            string[] keyValue = textPresentKey.Split(' ');
            foreach (string s in keyValue)
            {
                byte a = Convert.ToByte(s, 16);
                bytes.Add(a);
            }

            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;

        }
        private bool ReadSelect()
        {
            bool result = false;
            // Kiểm tra nếu sau 100ms chưa đủ byte thì Halt
            if (!CheckEnoughByte())
            {
                return false;
            }

            //if (port_Card.BytesToRead <= 6) return;
            byte[] buffer = new byte[7];
            int index = 0;
            while (port_Card.BytesToRead > 0)
            {
                buffer[index] = (Byte)port_Card.ReadByte();
                index++;
                if (index == buffer.Length) break;
            }
            if (compareTwoByte(buffer, successfulSelect))
            {
                DisplaySuccessSelect();
                result = true;
                isWriteAuthen = true;                     // Nếu True tiếp tục 
            }
            else
            {
                DisplayFalseSelect();
                isWriteHalt = true;                        // Nếu False nhảy vào Halt
                isError = true;
                ticketCode = "";
            }
            ClearMemory();
            isReadSelect = false;
            return result;
        }

        private void WriteSelect()
        {
            ClearMemory();
            List<byte> byteSelect = isWriteSelectBytes();
            WriteBytes(byteSelect);
            isReadSelect = true;
            isWriteSelect = false;
            //xuLyCardOut = true;
        }

        private void WriteCardID()
        {
            ClearMemory();
            List<byte> byteCardId = isWriteCardIDBytes();
            WriteBytes(byteCardId);
            isReadCardID = true;
            isWriteCardID = false;
        }

        private void WriteBytes(List<byte> byteCardId)
        {
            port_Card.Write(byteCardId.ToArray(), 0, byteCardId.Count);
        }

        /* Hàm đọc byte Scan -> Hiển thị thông tin thiết bị 
* Nếu đúng nhận 36 byte ( Byte 5 -> Byte 36 : 32 byte hiển thị thông tin thiết bị ) 
*/
        private void ReadScan()
        {
            if (port_Card.BytesToRead <= 35) return;
            int CountByte = port_Card.BytesToRead;
            byte[] bufferData = new byte[CountByte];
            int i = 0;

            lblDevice.Invoke(new Action(() =>
            {
                while (port_Card.BytesToRead > 0)
                {
                    bufferData[i] = (Byte)port_Card.ReadByte();
                    i++;
                }
                // Thông tin máy hiển thị từ byte 5 trở đi 
                List<byte> dataScan = new List<byte>();
                for (int j = 4; j < bufferData.Length; j++)
                {
                    dataScan.Add(bufferData[j]);
                }
                // Encoding: Mã hóa dạng Hex sang ASCII
                lblDevice.Text = Encoding.ASCII.GetString(dataScan.ToArray());
            }));
            ClearMemory();
            isReadScan = false;
            return;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePort();
        }
        private void CreatWriteData(Em_Block block, string textData)
        {
            ClearMemory();
            List<byte> bytes = WriteDataBytes(block, textData);
            WriteBytes(bytes);

            isReadWrite = true;
            isWriteData = false;

        }
        byte[] textAdd = new byte[16];
        private bool NewCard;
        private bool isbtnDelete;

        private List<byte> WriteDataBytes(Em_Block block, string textData)
        {
            byte temp = 0x00;
            byte ctr1 = 0x25;
            byte ctr2 = 0x11;
            // Cho
            //byte block = 0x01;   // Thay truyền hàm 
            //string texttest = txbHoTen.Text;     // Thay truyền hàm

            List<byte> bytes = new List<byte>();
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);
            if (Long16ByteWriteLan1) block = Em_Block.block1;
            if (Long16ByteWriteLan2) block = Em_Block.block2;
            bytes.Add((byte)block);
            if (isbtnDelete) textData = "";

            // Chuyển text sang mảng hex mã hóa theo Unicode -> chuyển sang text có dấu
            // Nếu mã hóa theo Ascii -> ko có dấu
            //byte[] test = Encoding.Unicode.GetBytes(txbWrite.Text);
            byte[] test = Encoding.Default.GetBytes(textData);
            // Nếu độ dài text <= 16 kí tự 
            if (Long16ByteWriteLan1)
            {
                // Quét text lần 2 
                Long16ByteWriteLan1 = false;
                if (isbtnDelete)
                {
                    Long16ByteWriteLan2 = true;
                    for (int i = 0; i < 16; i++)
                    {
                        bytes.Add(0x00);
                    }
                }
                if (isbtnWrite)
                {
                    int a = 0;
                    foreach (var item in byteAddLan1)
                    {
                        a++;
                        if (a <= 16)
                        {
                            bytes.Add(item);
                        }
                        else if (a > 16 || isbtnDelete)
                        {
                            Long16ByteWriteLan2 = true;
                            byteAddLan2.Add(item);
                        }
                    }
                    if (a > 16) ;
                    else
                    {
                        for (int i = 0; i < 16 - a; i++)
                        {
                            bytes.Add(0x00);
                        }
                        // Nếu độ dài text chỉ dừng đến lần 1 -> Sau khi add xong xóa list byteAddLan1
                        byteAddLan1.Clear();
                    }
                }
                
            }
            else if (Long16ByteWriteLan2)
            {
                // Quét text lần 3
                Long16ByteWriteLan2 = false;
                if (isbtnDelete)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        bytes.Add(0x00);
                    }
                }
                if (isbtnWrite)
                {
                    int a = 0;
                    foreach (var item in byteAddLan2)
                    {
                        a++;
                        if (a <= 16)
                        {
                            bytes.Add(item);
                        }
                    }
                    if (a > 16) MessageBox.Show("Vượt quá số kí tự cho phép (48)");
                    else
                    {
                        for (int i = 0; i < 16 - a; i++)
                        {
                            bytes.Add(0x00);
                        }
                    }
                    byteAddLan1.Clear();
                    byteAddLan2.Clear();
                }
                
            }
            else
            {
                if (isbtnDelete)
                {
                    Long16ByteWriteLan1 = true;
                    for (int i = 0; i < 16; i++)
                    {
                        bytes.Add(0x00);
                    }
                }
                if (isbtnWrite)
                {
                    // Quét lần 1 -> nếu text > 16 kí tự -> Lần ghi dữ liệu sau sẽ nhảy vào Quét lần 2
                    if (test.Length <= 16)
                    {
                        for (var i = 0; i < test.Length; i++)
                        {
                            bytes.Add(test[i]);
                        }
                        if (test.Length <= 16)
                        {
                            for (int i = 0; i < 16 - test.Length; i++)
                            {
                                bytes.Add(0x00);
                            }
                        }
                    }
                    // Nếu độ dài text > 16 kí tự 
                    // Lấy 16 byte còn lại thêm vào byte khác (byteAddLan1)
                    else
                    {
                        Long16ByteWriteLan1 = true;
                        for (var i = 0; i < test.Length; i++)
                        {
                            if (i <= 15)
                            {
                                bytes.Add(test[i]);
                            }
                            else
                            {
                                byteAddLan1.Add(test[i]);
                            }

                        }

                    }
                }
                
            }
            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;
        }
        private List<byte> WriteDataBytes1(byte block, string textData)
        {
            byte temp = 0x00;
            byte ctr1 = 0x25;
            byte ctr2 = 0x11;
            // Cho
            //byte block = 0x01;   // Thay truyền hàm 
            //string texttest = txbHoTen.Text;     // Thay truyền hàm

            List<byte> bytes = new List<byte>();
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);
            bytes.Add(block);


            // Chuyển text sang mảng hex mã hóa theo Unicode -> chuyển sang text có dấu
            // Nếu mã hóa theo Ascii -> ko có dấu
            //byte[] test = Encoding.Unicode.GetBytes(txbWrite.Text);
            byte[] test = Encoding.Default.GetBytes(textData);
            for (var i = 0; i < test.Length; i++)
            {
                bytes.Add(test[i]);
            }
            if (test.Length <= 16)
            {
                for (int i = 0; i < 16 - test.Length; i++)
                {
                    bytes.Add(0x00);
                }
            }
            else
            {
                MessageBox.Show("Đã vượt quá 16 byte data", "Không thể ghi");
            }
            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;
        }
        private void DisplayFalseAuthen()
        {
            MessageBox.Show("Key chưa đúng", "Authenticate", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void DisplaySuccessAuthen()
        {
            //lblKey.Invoke(new Action(() =>
            //{
            //    picTrueCheckKey.Visible = true;
            //    picFalseCheckkey.Visible = false;

            //    lblKey.Text = "Xác thực Key hoàn tất";
            //    lblKey.ForeColor = Color.Black;

            //}));

        }


        private void DisplayFalseSelect()
        {
            MessageBox.Show("Lỗi thao tác - Mời quẹt thẻ lại", "Select", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //lblQuetThe.Text = "Lỗi không thể Select";
            //lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            //lblQuetThe.ForeColor = Color.Red;
        }

        private void DisplaySuccessSelect()
        {
            // ko can hien thi
        }

        private bool ReadCardID()
        {
            /* Check nhận đủ > 6 byte mới tiếp tục
             * Lấy 7 byte trong serialPort -> Check có phải trùng 7 byte erorr không
             * Nếu không trùng check số byte trong serialPort nếu chưa đủ 3 byte thì tiếp tục đọc 
             * Nếu đủ 3 byte thì check xem có trùng vs byte successfulCardID không (so sánh 4 byte đầu)
             * Nếu successfulCardID -> Lấy 4 byte tên thẻ ra hiển thị lên 
             */
            bool result = false;
            // Kiểm tra nếu sau 100ms vẫn chưa đủ byte thì tự Halt
            if (!CheckEnoughByte())
            {
                return false;
            }

            //if (port_Card.BytesToRead <= 6) return;
            List<byte> buffer = new List<byte>();
            for (int i = 0; i < 7; i++)
            {
                buffer.Add((byte)port_Card.ReadByte());
            }

            byte[] dataCardID = buffer.ToArray();

            if (compareTwoByte(dataCardID, errorCardID))
            {
                //lblQuetThe.Invoke(new Action(() =>
                //{
                //    lblQuetThe.Text = "Lỗi nhận CardID";
                //    lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                //    lblQuetThe.ForeColor = Color.Red;
                //}));


                MessageBox.Show("Không thể tìm thấy mã thẻ!", "CardID!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                isReadCardID = false;
                isWriteHalt = true;
                isError = true;
            }
            else
            {
                while (port_Card.BytesToRead < 3)
                {
                    continue;
                }
                if (port_Card.BytesToRead == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        buffer.Add((byte)port_Card.ReadByte());
                    }
                    dataCardID = buffer.ToArray();
                    List<byte> fourFirstByteList = new List<byte>();
                    for (int i = 0; i <= 3; i++)
                    {
                        fourFirstByteList.Add(buffer[i]);
                    }
                    byte[] fourFirstByte = fourFirstByteList.ToArray();
                    if (compareTwoByte(fourFirstByte, successfulCardID))
                    {
                        byte[] nameCard = new byte[4];
                        txbCardNumber.Invoke(new Action(() =>
                        {
                            List<byte> response = new List<byte>();
                            for (int i = 4; i < 8; i++)
                            {
                                response.Add(buffer[i]);
                            }
                            nameCard = response.ToArray();          // ToArray() chuyển từ List sang mảng  
                            txbCardNumber.Texts = ByteArrayToString(nameCard);
                            Mathe = nameCard;                       // Mathe : 1 mảng cardNumber
                            maThe = ByteArrayToString(nameCard);    // string cardNumber
                        }));
                        result = true;
                        isReadCardID = false;
                        isWriteSaveKey = true;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi thao tác - Mời quẹt thẻ lại", "CardID");
                        isWriteHalt = true;
                        isError = true;

                    }
                }
            }
            ClearMemory();
            return result;
        }

        private bool ShowRequestData()
        {
            bool result = false;
            try
            {
                int a = 0;
                // Kiểm tra nếu sau 5s chưa đủ byte thì tự Halt
                if (!CheckEnoughByte())
                {
                    return false;
                }

                List<byte> buffer = new List<byte>();
                for (int i = 0; i < 7; i++)
                {
                    buffer.Add((byte)port_Card.ReadByte());
                }

                byte[] dataCardID = buffer.ToArray();
                if (compareTwoByte(dataCardID, errorRequest))
                {
                    //lblReadWrite.Invoke(new Action(() =>
                    //{
                    //    //lblQuetThe.Text = "Chưa nhận thẻ";
                    //}));
                    MessageBox.Show("Chưa nhận thẻ, Mời quẹt thẻ lại!", "Request", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    isReadRequest = false;
                    isWriteHalt = true;      // Nhảy đến lệnh Halt thoát   
                    isError = true;
                }
                else
                {
                    while (port_Card.BytesToRead < 1)
                    {
                        continue;
                    }
                    if (port_Card.BytesToRead == 1)
                    {
                        buffer.Add((byte)port_Card.ReadByte());
                        dataCardID = buffer.ToArray();


                        if (compareTwoByte(dataCardID, successfulRequest))
                        {
                            result = true;
                            isReadRequest = false;
                            isWriteCardID = true;
                        }
                        else
                        {
                            MessageBox.Show("Lỗi thao tác - Mời quẹt thẻ lại", "Request");
                            isWriteHalt = true;
                            isError = true;

                        }
                    }
                }
                ClearMemory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
            return result;

        }


        // Hàm so sánh 2 byte trùng nhau 
        static bool compareTwoByte(byte[] data1, byte[] data2)
        {
            if (data1.Length != data2.Length) return false;
            for (int i = 0; i < data1.Length; i++)
            {
                if (data1[i] != data2[i])
                    return false;
            }
            return true;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }


        private void ClearMemory()
        {
            while (port_Card.BytesToRead > 0)
            {
                port_Card.ReadByte();
            }
        }




        private List<byte> RequestScanBytes()
        {
            // 01 00 01 00 50 70  (Scan)
            byte temp = 0x00;
            byte ctr1 = 0x01;
            byte ctr2 = 0x00;
            List<byte> bytes = new List<byte>(); ;
            bytes.Add(0x01);
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);
            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;
        }
        private List<byte> isWriteCardIDBytes()
        {
            //isReadCardID = true;
            //01 00 21 00 90 69
            byte temp1 = 0x00;
            byte ctr11 = 0x21;
            byte ctr21 = 0x00;
            List<byte> bytes1 = new List<byte>(); ;
            bytes1.Add(Header);  // Header
            bytes1.Add(temp1);
            bytes1.Add(ctr11);
            bytes1.Add(ctr21);
            byte[] crc1;
            CalculateCRC(bytes1, out crc1);
            bytes1.Add(crc1[1]);
            bytes1.Add(crc1[0]);
            return bytes1;
        }
        private List<byte> RequestRequestBytes()
        {
            // 01 00 20 00 00 68  (request)
            byte temp = 0x00;
            byte ctr1 = 0x20;
            byte ctr2 = 0x00;
            List<byte> bytes = new List<byte>(); ;
            bytes.Add(0x01);
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);
            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;
        }
        private List<byte> isWriteSelectBytes()
        {
            //01 00 22 04 DE 33 88 7B 46 00
            // Select
            byte temp2 = 0x00;
            byte ctr12 = 0x22;
            byte ctr22 = 0x04;
            List<byte> bytes2 = new List<byte>(); ;
            bytes2.Add(0x01);  // Header
            bytes2.Add(temp2);
            bytes2.Add(ctr12);
            bytes2.Add(ctr22);

            if (Mathe == null)
            {
                MessageBox.Show("Lỗi thao tác - không tìm thấy mã thẻ", "Write Select");
                isWriteHalt = true;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    bytes2.Add(Mathe[i]);
                }
            }

            byte[] crc2;
            CalculateCRC(bytes2, out crc2);
            bytes2.Add(crc2[1]);
            bytes2.Add(crc2[0]);
            return bytes2;
        }
        private List<byte> isWriteAuthenBytes(Em_Key typeKey, Em_Sector sector)
        {
            byte temp = 0x00;
            byte ctr1 = 0x23;
            byte ctr2 = 0x02;
            //byte typeKey = KeyTypeDefines[cbbTypeKey.Text];
            //byte sector = SectorDefines[cbbSector.Text];
            //if (block == 0x01) sector = 0x00;
            //if (block == 0x02) sector = 0x01;
            List<byte> bytes = new List<byte>(); ;
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);
            bytes.Add((byte)typeKey);
            bytes.Add((byte)sector);
            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;
        }
        private List<byte> isWriteReadBytes(Em_Block block2)
        {
            byte temp2 = 0x00;
            byte ctr12 = 0x24;
            byte ctr22 = 0x01;
            //byte block2 = BlockDefines[cbbBlockRead.Text];

            List<byte> bytes2 = new List<byte>(); ;
            bytes2.Add(0x01);  // Header
            bytes2.Add(temp2);
            bytes2.Add(ctr12);
            bytes2.Add(ctr22);
            if (Long16ByteReadLan1) block2 = Em_Block.block1;
            if (Long16ByteReadLan2) block2 = Em_Block.block2;
            bytes2.Add((byte)block2);

            byte[] crc2;
            CalculateCRC(bytes2, out crc2);
            bytes2.Add(crc2[1]);
            bytes2.Add(crc2[0]);
            return bytes2;
        }
        private List<byte> isWriteHaltBytes()
        {
            //01 00 2A 00 A0 6E
            byte temp = 0x00;
            byte ctr1 = 0x2A;
            byte ctr2 = 0x00;


            List<byte> bytes = new List<byte>(); ;
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);

            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);
            return bytes;
        }


        private string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.ASCII.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }


        private void btnStart_Click_1(object sender, EventArgs e)
        {
            RJMessageBox.Show("Xin chào messenger mới đây", "Aolo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            ClosePort();
            OpenPort_Card();
            WriteScanBytes();
        }

      
        private void btnHalt_Click(object sender, EventArgs e)
        {
            isbtnHalt = true;

            ClearMemory();
            //01 00 2A 00 A0 6E
            byte temp = 0x00;
            byte ctr1 = 0x2A;
            byte ctr2 = 0x00;


            List<byte> bytes = new List<byte>(); ;
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);

            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);

            port_Card.Write(bytes.ToArray(), 0, bytes.Count);
            isReadHalt = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ClosePort();
        }

        private void frmWriteData1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
        }
        private void btnWrite_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Card Register","Người dùng nhấn WriteData", Application.StartupPath);
            if (Properties.Settings.Default.Key == "")
            {
                MessageBox.Show("Bạn chưa nhập key!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (!isUpdate)
                {
                    MessageBox.Show("Chưa được quyền đăng ký dữ liệu", "Cần admin cho phép sửa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    if (string.IsNullOrEmpty(txbEmail.Texts) && string.IsNullOrEmpty(txbMSV.Texts))
                    {
                        MessageBox.Show("Dữ liệu Email và MSV trống", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (string.IsNullOrEmpty(txbEmail.Texts))
                    {
                        DialogResult dlog = MessageBox.Show("Thông tin Email trống, bạn có muốn tiếp tục ghi dữ liệu không?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(dlog != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    else if (string.IsNullOrEmpty(txbMSV.Texts))
                    {
                        DialogResult dlog = MessageBox.Show("Thông tin MSV trống, bạn có muốn tiếp tục ghi dữ liệu không?", "Warning MSV trống, sinh viên không thể mượn trả sách!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlog != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    if (!CheckFormatEmail())
                    {
                        MessageBox.Show("Email chưa đúng định dạng", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    rjProgressBar1.Value = 0;
                    timerProcessBar.Start();
                    ClearPic();
                    isbtnWrite = true;
                    WriteRequest();   // Bắt đầu gửi dữ liệu
                    isReadRequest = true;

                }
            }
        }
        private bool CheckFormatEmail()
        {
            string str = txbEmail.Texts;
            int index = str.IndexOf('@');
            return (index == -1 ? false : true);
        }
        private string[] TypeLooking = new string[]
        {
            "Last Name","First Name","Identifier Value","Email","PhoneNumber"
        };
        private void frmWriteData_Load(object sender, EventArgs e)
        {
            //DATADETAIL.Add(Em_TextData.HoTen, Tuple.Create<int, TextBox>(1, txbText));

            //TextBox test = DATADETAIL[Em_TextData.HoTen].Item2;

            ClosePort();
            OpenPort_Card();
            WriteScanBytes();
            #region bytes anwser
            //

            //
            successfulRequest[0] = 0x01;
            successfulRequest[1] = 0x00;
            successfulRequest[2] = 0x06;
            successfulRequest[3] = 0x02;
            successfulRequest[4] = 0x04;
            successfulRequest[5] = 0x00;
            successfulRequest[6] = 0x88;
            successfulRequest[7] = 0x87;

            //
            errorRequest[0] = 0x01;
            errorRequest[1] = 0x00;
            errorRequest[2] = 0x15;
            errorRequest[3] = 0x01;
            errorRequest[4] = 0x1F;
            errorRequest[5] = 0xB8;
            errorRequest[6] = 0x51;
            //
            successfulWrite[0] = 0x01;
            successfulWrite[1] = 0x00;
            successfulWrite[2] = 0x06;
            successfulWrite[3] = 0x01;
            successfulWrite[4] = 0x00;
            successfulWrite[5] = 0xB5;
            successfulWrite[6] = 0xE1;
            // suc Read
            successfulRead[0] = 0x01;
            successfulRead[1] = 0x00;
            successfulRead[2] = 0x06;
            successfulRead[3] = 0x10;
            // byte CardID
            successfulCardID[0] = 0x01;
            successfulCardID[1] = 0x00;
            successfulCardID[2] = 0x06;
            successfulCardID[3] = 0x04;
            // byte cardID
            errorCardID[0] = 0x01;
            errorCardID[1] = 0x00;
            errorCardID[2] = 0x15;
            errorCardID[3] = 0x01;
            errorCardID[4] = 0x1F;
            errorCardID[5] = 0xB8;
            errorCardID[6] = 0x51;
            // byte ok halt
            byteReceiveHalt[0] = 0x01;
            byteReceiveHalt[1] = 0x00;
            byteReceiveHalt[2] = 0x06;
            byteReceiveHalt[3] = 0x01;
            byteReceiveHalt[4] = 0x00;
            byteReceiveHalt[5] = 0xb5;
            byteReceiveHalt[6] = 0xe1;
            //--read
            errorRead[0] = 0x01;
            errorRead[1] = 0x00;
            errorRead[2] = 0x15;
            errorRead[3] = 0x01;
            errorRead[4] = 0x1f;
            errorRead[5] = 0xb8;
            errorRead[6] = 0x51;
            //--authen
            successfulAuthen[0] = 0x01;
            successfulAuthen[1] = 0x00;
            successfulAuthen[2] = 0x06;
            successfulAuthen[3] = 0x01;
            successfulAuthen[4] = 0x00;
            successfulAuthen[5] = 0xb5;
            successfulAuthen[6] = 0xe1;

            //--save key
            successfulSaveKey[0] = 0x01;
            successfulSaveKey[1] = 0x00;
            successfulSaveKey[2] = 0x06;
            successfulSaveKey[3] = 0x01;
            successfulSaveKey[4] = 0x00;
            successfulSaveKey[5] = 0xb5;
            successfulSaveKey[6] = 0xe1;

            //-_select
            successfulSelect[0] = 0x01;  // 1
            successfulSelect[1] = 0x00;  // 0
            successfulSelect[2] = 0x06;  // 6
            successfulSelect[3] = 0x01;  // 1
            successfulSelect[4] = 0x08;  // 8
            successfulSelect[5] = 0x73;  // 115
            successfulSelect[6] = 0xe0;  // 224

            // answercard: byte thẻ vào
            answerCardIn[0] = 0x01;
            answerCardIn[1] = 0x00;
            answerCardIn[2] = 0x12;
            answerCardIn[3] = 0x01;
            answerCardIn[4] = 0x49;
            answerCardIn[5] = 0x47;
            answerCardIn[6] = 0x60;

            // answercard: byte thẻ ra
            answerCardOut[0] = 0x01;
            answerCardOut[1] = 0x00;
            answerCardOut[2] = 0x12;
            answerCardOut[3] = 0x01;
            answerCardOut[4] = 0x52;
            answerCardOut[5] = 0x4c;
            answerCardOut[6] = 0x20;

            foreach (var item in SectorDefines)
            {
                //cbbSector.Items.Add(item.Key);
            }
            foreach (var item in KeyTypeDefines)
            {
                //cbbTypeKey.Items.Add(item.Key);
            }
            foreach (var item in BlockDefines)
            {
                //cbbBlockRead.Items.Add(item.Key);
                //cbbBlockWrite.Items.Add(item.Key);
            }
            // cbbSector.SelectedIndex = 0;
            //cbbTypeKey.SelectedIndex = 1;
            //cbbBlockRead.SelectedIndex = 1;
            //cbbBlockWrite.SelectedIndex = 3;

            picTrueDone.Visible = false;
            picFalseDone.Visible = false;
            lblDone.Visible = false;

            isUpdate = Properties.Settings.Default.CheckBoxUpdate;
            if (isUpdate)
            {
                lblUpdate.Text = "Cho phép Update";
            }
            else
            {
                lblUpdate.Text = "Chưa được phép Update";
                lblUpdate.ForeColor = Color.Red;
            }
            ClearPic();
            #endregion

            LoadDGV();

            for (int i = 0; i < TypeLooking.Length; i++)
            {
                cbbType1.Items.Add(TypeLooking[i]);
            }
            cbbType1.SelectedIndex = 2;

            lblCount.Visible = false;

            txbTimKiem.Texts =  Mifare.NameLooking();
        }

        private void LoadCount()
        {
            lblTong.Invoke(new Action(() =>
            {
                string str = "select count (*) from tblQLSV where IsRegister = '1'";
                DataTable count = ConnectSQL.dbConnection.FillData(str);
                if (count != null)
                {
                    lblDKy.Text = count.Rows[0][0].ToString();
                }

                string str1 = "select count (*) from tblQLSV where IsRegister = '0'";
                DataTable count1 = ConnectSQL.dbConnection.FillData(str1);
                if (count1 != null)
                {
                    lblChuaDky.Text = count1.Rows[0][0].ToString();
                }

                string creat = "select count (*) from tblQLSV";
                DataTable dt = ConnectSQL.dbConnection.FillData(creat);
                if (dt != null)
                {
                    lblTong.Text = dt.Rows[0][0].ToString();
                }
            }));
        }

        private void LoadDGV()
        {
            string creat = "SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[IsRegister],[StudentID] FROM [VinUniver].[dbo].[tblQLSV] where IsDelete = '0'";
            DataTable dt = ConnectSQL.dbConnection.FillData(creat);
            int index = 1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = index;
                index++;
            }
            dgvSV.Invoke(new Action(() =>
            {
                dgvSV.DataSource = dt;
                lblDone.Visible = false;
                
            }));
            LoadCount();


        }
        private void ClearPic()
        {
            picTrueDone.Visible = false;
            picFalseDone.Visible = false;
        }

        private void frmWriteData_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Register Card","Người dùng nhấn Delete data", Application.StartupPath);
            isbtnDelete = true;
            if (Properties.Settings.Default.Key == "")
            {
                MessageBox.Show("Bạn chưa nhập key!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                if (!isUpdate)
                {
                    MessageBox.Show("Chưa được quyền hủy đăng ký dữ liệu", "Cần admin cho phép sửa dữ liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {

                    ClearPic();
                    isbtnDelete = true;
                    WriteRequest();
                    isReadRequest = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rjProgressBar1.Value += 5;
            if (rjProgressBar1.Value == rjProgressBar1.Maximum)
            {
                timerProcessBar.Stop();
            }
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {

        }



        private void btnRead_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Register Card", "Người dùng nhấn ReadCard", Application.StartupPath);
            if (Properties.Settings.Default.Key == "")
            {
                MessageBox.Show("Bạn chưa nhập key!", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                txbHoDem.Texts = "";
                txbTen.Texts = "";
                txbMSV.Texts = "";
                txbEmail.Texts = "";
                txbPhone.Texts = "";
                txbCardID.Texts = "";
                txbNote.Texts = "";
                ClearPic();
                rjProgressBar1.Value = 0;
                timerProcessBar.Start();
                isbtnRead = true;
                WriteRequest();
                isReadRequest = true;
            }
        }

        private void timerAutoHalt_Tick(object sender, EventArgs e)
        {
            if (timeOut <= 100)
            {
                timeOut += 10;
            }
            else
            {
                inTimeOut = true;
                timerAutoHalt.Enabled = false;
                timeOut = 0;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Excel";
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //ImportExcel(openFileDialog.FileName);
                    ExcelReport.ImportExcel(openFileDialog.FileName, dgvSV);
                    MessageBox.Show("Nhập thành công", "Thông báo", MessageBoxButtons.OKCancel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Khong thanh cong");
                }
            }
        }

        private void btnSaveSQL_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i <= dgvSV.Rows.Count - 1; i++)
                {
                    string str = "insert into tblImport values(N'" + dgvSV.Rows[i].Cells["STT"].Value + "',N'" + dgvSV.Rows[i].Cells["Họ đệm"].Value + "',N'" + dgvSV.Rows[i].Cells["Tên"].Value + "',N'" + dgvSV.Rows[i].Cells["Email"].Value + "',N'" + dgvSV.Rows[i].Cells["Mã sinh viên"].Value + "',N'" + dgvSV.Rows[i].Cells["Số điện thoại"].Value + "',N'" + dgvSV.Rows[i].Cells["ID Card"].Value + "',N'" + dgvSV.Rows[i].Cells["Ghi chú"].Value + "')";
                    ConnectSQL.dbConnection.ExecuteCommand(str);
                }
                MessageBox.Show("Lưu thành công");
            }
            catch
            {
                MessageBox.Show("loi roi");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSV.CurrentRow.Index;
            txbHoDem.Texts = dgvSV.Rows[i].Cells[1].Value.ToString();
            txbTen.Texts = dgvSV.Rows[i].Cells[2].Value.ToString();
            txbEmail.Texts = dgvSV.Rows[i].Cells[3].Value.ToString();
            txbMSV.Texts = dgvSV.Rows[i].Cells[4].Value.ToString();
            txbPhone.Texts = dgvSV.Rows[i].Cells[5].Value.ToString();
            txbCardID.Texts = dgvSV.Rows[i].Cells[6].Value.ToString();
            txbNote.Texts = dgvSV.Rows[i].Cells[7].Value.ToString();
            txbStudentID.Texts = dgvSV.Rows[i].Cells[10].Value.ToString();

        }

        private void txbTimKiem__TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbPhone__TextChanged(object sender, EventArgs e)
        {

        }

       

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i <= dgvSV.Rows.Count - 2; i++)
            {
                bool a = (bool)dgvSV.Rows[i].Cells["IsRegister"].Value;
                if (a == true)
                {
                    dgvSV.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
            }
            //int index = 1;
            //for (int i = 0; i < dgvSV.Rows.Count - 1; i++)
            //{
            //    dgvSV.Rows[i].Cells[0].Value = index;
            //    index++;
            //}
            if (isbtnRead)
            {
                if (dgvSV != null && dgvSV.Rows.Count > 0)
                {
                    for (int i = 0; i <= dgvSV.Rows.Count - 2; i++)
                    {
                        string msv = txbMSV.Texts;
                        if (msv == dgvSV.Rows[i].Cells["StudentCode"].Value.ToString())
                        {
                            dgvSV.CurrentCell = dgvSV.Rows[i].Cells[0];
                            break;
                        }
                    }
                }
            }
            
            //dgvSV.SelectedRows[2].Selected = true;
            //dgvSV.Rows[5].Selected = true;
        }

     

     

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Regis","Người dùng nhấn Search", Application.StartupPath);
            
            
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [STT],[Surname],[Name],[Email],[StudentCode],[PhoneNumber],[CardID],[Note],[IsDelete],[IsRegister],[StudentID] ");
            sb.Append("FROM [VinUniver].[dbo].[tblQLSV] ");
            sb.Append("where IsDelete = '0' ");

            if (cbbType1.Texts.Trim() == TypeLooking[0])  // lastname
            {
                sb.Append("and Surname like '%" + txbTimKiem.Texts + "%' ");
            }
            else if (cbbType1.Texts.Trim() == TypeLooking[1])  // First name
            {
                sb.Append("and Name like '%" + txbTimKiem.Texts + "%' ");
            }
            else if (cbbType1.Texts.Trim() == TypeLooking[2])  // MSV
            {
                sb.Append("and StudentCode like '%" + txbTimKiem.Texts + "%' ");
            }
            else if (cbbType1.Texts.Trim() == TypeLooking[3]) // Email
            {
                sb.Append("and Email like '%" + txbTimKiem.Texts + "%' ");
            }
            else if (cbbType1.Texts.Trim() == TypeLooking[4]) // Phone
            {
                sb.Append("and PhoneNumber like '%" + txbTimKiem.Texts + "%' ");
            }
            DataTable dt = ConnectSQL.dbConnection.FillData(sb.ToString());

            lblCount.Visible = true;
            lblCount.Text = Mifare.Sort_STT(dt);   // Xắp sếp lại STT và count

            dgvSV.DataSource = dt;

        }


        private void btnClear_Click_1(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Register Card", "Người dùng nhấn Clear", Application.StartupPath);
            txbCardNumber.Texts = "";
            txbHoDem.Texts = "";
            txbTen.Texts = "";
            txbMSV.Texts = "";
            txbEmail.Texts = "";
            txbPhone.Texts = "";
            txbCardID.Texts = "";
            txbNote.Texts = "";
            txbCheckNewCard.Texts = "";
            lblDone.Text = "";
            ClearPic();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LogHelper.LogUser("Page Register Card", "Người dùng nhấn Reset", Application.StartupPath);
            isbtnHalt = true;

            ClearMemory();
            //01 00 2A 00 A0 6E
            byte temp = 0x00;
            byte ctr1 = 0x2A;
            byte ctr2 = 0x00;


            List<byte> bytes = new List<byte>(); ;
            bytes.Add(0x01);  // Header
            bytes.Add(temp);
            bytes.Add(ctr1);
            bytes.Add(ctr2);

            byte[] crc;
            CalculateCRC(bytes, out crc);
            bytes.Add(crc[1]);
            bytes.Add(crc[0]);

            port_Card.Write(bytes.ToArray(), 0, bytes.Count);
            isReadHalt = true;
        }

        private void txbTimKiem_Enter(object sender, EventArgs e)
        {
            if (txbTimKiem.Texts == Mifare.NameLooking())
            {
                txbTimKiem.Texts = "";
                txbTimKiem.ForeColor = Color.Black;
            }
        }

        private void txbTimKiem_Leave(object sender, EventArgs e)
        {
            if (txbTimKiem.Texts == "")
            {
                txbTimKiem.Texts = "Enter search";
                txbTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txbTimKiem__TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
