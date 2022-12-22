using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NXT.Utilities;
using Futech.Tools;
using System.IO;
using GeneralTool;
using Microsoft.Win32;

namespace TestReader_VinUni
{
    public partial class frmReadCard : Form
    {
        #region Khai báo biến đơn
        private string Data;

        private string ServerConfigPath = $"{Application.StartupPath}\\SQLConn.xml";

        byte Header = 0x01;
        public byte[] EventData { get; set; }

        public byte[] Mathe;
        private string maThe;
        public byte[] ReadData;

        bool SaveKeyA = false;

        bool xuLyCardOut = false;

        bool isGetOutData = false;
        bool isError = false;
        public string KeyRead = "";
        bool Long16ByteReadLan1 = false;
        bool Long16ByteReadLan2 = false;

        bool Long16ByteWriteLan1 = false;
        bool Long16ByteWriteLan2 = false;

        string ByteExam = "";
        string TextBoxExam = "";

        int checkcount = 0;


        List<byte> byteAddLan1 = new List<byte>();
        List<byte> byteAddLan2 = new List<byte>();
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
        // Hàm tính 2 byte cuối CRC-H và CRC-L theo chuẩn CRC16
        public static byte[] ComputeCrc(byte[] data)
        {
            ushort crc = 0xFFFF;

            foreach (byte datum in data)
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ datum) & 0xFF]);

            return BitConverter.GetBytes(crc);
        }
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

        //Futech.Tools.MDB dbConnection = new MDB("103.127.207.247", "VinUniver", "SQl Server Authentication", "sa", "Kztek@123456");
        private bool IsStartupItem()
        {
            // The path to the key where Windows looks for startup applications
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rkApp.GetValue("KZTEK_TOOL_CARD") == null)
                // The value doesn't exist, the application is not set to run at startup
                return false;
            else
                // The value exists, the application is set to run at startup
                return true;
        }

        public frmReadCard()
        {
            InitializeComponent();

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (!IsStartupItem())
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("KZTEK_TOOL_CARD", Application.ExecutablePath.ToString());

            //try
            //{
            //    dbConnection.OpenMDB();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Lỗi không kết nối được với dữ liệu. Vui lòng kiểm tra lại!\r\n{ex.Message}");
            //}

            for (int i = 1; i < 100; i++)
            {
                cbxCOM_QR.Items.Add("COM" + i.ToString());
                cbxCOM_Card.Items.Add("COM" + i.ToString());
                cbxCOM_Output.Items.Add("COM" + i.ToString());
            }

            //cbxCOM_QR.SelectedIndex = 0;
            //cbxCOM_Card.SelectedIndex = 3;
            //cbxCOM_Output.SelectedIndex = 2;
            cbxCOM_QR.Text = Properties.Settings.Default.QR_Port;
            cbxCOM_Card.Text = Properties.Settings.Default.Card_Port;
            cbxCOM_Output.Text = Properties.Settings.Default.OutPut_Port;
        }
        SerialPort port_QR = new SerialPort();
        SerialPort port_Card = new SerialPort();
        SerialPort port_Output = new SerialPort();
        private void Form1_Load(object sender, EventArgs e)
        {
            ClosePort();
            timerStartup.Enabled = true;

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

            picTrue.Visible = false;
            picFalse.Visible = false;


            #endregion
        }
        //private bool SaveServerConfigs()
        //{
        //    List<SQLConn> sqlconnlist = new List<SQLConn>();
        //    SQLConn cn1 = new SQLConn()
        //    {
        //        DBType = String.Empty,
        //        SQLAuthentication = "SQl Server Authentication",
        //        SQLDatabase = "VinUniver",
        //        SQLDatabaseEx = "MPARKING",
        //        SQLPassword = CryptorEngine.Encrypt("Kztek@123456", true),
        //        SQLServerName = "LibraryVin",
        //        SQLUserName = "sa",
        //        DatabaseIp = "103.127.207.247",
        //    };
        //    sqlconnlist.Add(cn1);
        //    FileXML.WriteXML<SQLConn>(ServerConfigPath, sqlconnlist);
        //    return true;
        //}
        private void btnStart_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.QR_Port = cbxCOM_QR.Text;
            Properties.Settings.Default.Card_Port = cbxCOM_Card.Text;
            Properties.Settings.Default.OutPut_Port = cbxCOM_Output.Text;
            Properties.Settings.Default.Save();
            ClosePort();
            OpenPort_QR();
            OpenPort_Card();
            OpenPort_Output();
            WriteScanBytes();
        }

        private void WriteScanBytes()
        {
            if (port_Card.IsOpen)
            {
                while (port_Card.BytesToRead > 0)
                {
                    //port_Card.ReadByte();
                    //continue;
                }
                isReadScan = true;
                List<byte> byteScan = RequestScanBytes();            //RequestScanBytes();
                port_Card.Write(byteScan.ToArray(), 0, byteScan.Count);
                lblDevice.Visible = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ClosePort();
        }

        private void SetText(string text)
        {
            if (lstReceivedMessage.InvokeRequired)
            {
                lstReceivedMessage.Invoke(new MethodInvoker(delegate { SetText(text); }));
                return;
            }
            if (lstReceivedMessage.Items.Count > 100) lstReceivedMessage.Items.Clear();
            lstReceivedMessage.Items.Add(DateTime.Now.ToString("HH:mm:ss") + ": " + text);
            lstReceivedMessage.Items.Add("- - -");
            lstReceivedMessage.SelectedIndex = lstReceivedMessage.Items.Count - 1;
        }

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
                SetText("portName: " + ex.ToString());

                if (port.IsOpen)
                {
                    port.Close();
                }
                throw;
            }
        }

        private void OpenPort_QR()
        {

            try
            {
                this.OpenPort(port_QR, Properties.Settings.Default.QR_Port, 9600, -1);
                this.port_QR.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived_QR);
                if (port_QR.IsOpen)
                    SetText("QR Reader connected ");
                else
                    SetText("QR Reader disconnected ");
            }
            catch (Exception ex)
            {
                SetText("QR: " + ex.ToString());
            }
        }

        private void OpenPort_Card()
        {

            try
            {
                this.OpenPort(port_Card, Properties.Settings.Default.Card_Port, 19200, -1);
                this.port_Card.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived_Card);
                if (port_Card.IsOpen)
                    SetText("Card Reader connected ");
                else
                    SetText("Card Reader disconnected ");
            }
            catch (Exception ex)
            {
                SetText("Card: " + ex.ToString());
            }
        }

        private void OpenPort_Output()
        {

            try
            {
                this.OpenPort(port_Output, Properties.Settings.Default.OutPut_Port, 9600, -1);
                this.port_Output.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived_Output);
                if (port_Output.IsOpen)
                    SetText("Output device connected ");
                else
                    SetText("Output device disconnected ");
            }
            catch (Exception ex)
            {
                SetText("Output: " + ex.ToString());
            }
        }

        private void ClosePort()
        {
            this.port_QR.DataReceived -= new SerialDataReceivedEventHandler(this.serialPort_DataReceived_QR);
            if (this.port_QR.IsOpen)
                this.port_QR.Close();

            this.port_Card.DataReceived -= new SerialDataReceivedEventHandler(this.serialPort_DataReceived_Card);
            if (this.port_Card.IsOpen)
                this.port_Card.Close();

            this.port_Output.DataReceived -= new SerialDataReceivedEventHandler(this.serialPort_DataReceived_Output);
            if (this.port_Output.IsOpen)
                this.port_Output.Close();
        }

        private void serialPort_DataReceived_QR(object sender, SerialDataReceivedEventArgs e)
        {
            string result;
            try
            {
                System.Threading.Thread.Sleep(300);
                string reply = "";
                while (this.port_QR.BytesToRead > 0)
                {
                    char tmp = Convert.ToChar(this.port_QR.ReadByte());
                    reply += tmp;
                }
                result = reply;
                if (port_Output.IsOpen)
                {
                    port_Output.Write(result);
                }

            }
            catch (Exception ex)
            {
                result = "";
            }

            SetText("QR: " + result);
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


        string ticketCode = "";

        int tong = 0;
        int quetthe = 0;
        int xulycardout = 0;
        int writecardid = 0;
        int readcardid = 0;
        int writeselect = 0;
        int readselect = 0;
        int writesavekey = 0;
        int readsavekey = 0;
        int writeauthen = 0;
        int readauthen = 0;
        int writeRead = 0;
        int readread1 = 0;
        int creatWriteData = 0;
        bool Nhay1Lan = false;

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

                    if (isbtnHalt)
                    {
                        HaltButton();
                        return;
                    }
                    if (!isWriteRequest && !isbtnHalt && !xuLyCardOut)
                    {
                        QuetThe();
                        Nhay1Lan = true;
                    }
                    bool ad = isWriteRequest;

                    if (!isbtnHalt && Nhay1Lan)
                    {
                        if (!ProcessCard(Em_Key.keyB, Em_Sector.sector1, Em_Block.block0, "2", false))
                        {
                            Halt(true);
                            return;
                        }
                        try
                        {
                            string a = GetText(txbMSV.Text);
                            ticketCode = a.Trim();   // Trim ko thể cắt kí tự -> hàm checkEndtext \0
                            if (ticketCode != "")
                            {
                                SetText("TicketCode: " + ticketCode);

                                // Đẩy dữ liệu ra Output
                                if (port_Output.IsOpen)
                                {
                                    port_Output.Write(ticketCode);
                                }

                            }
                            ticketCode = "";
                            isGetOutData = false;
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                        }

                    }
                    //if (!isError && Nhay1Lan)
                    //{
                    //    Nhay1Lan = false;
                    //    var CardID = Guid.NewGuid();
                    //    string cardNumber = maThe;
                    //    string cardNo = "No1";
                    //    string cardKey = KeyRead;
                    //    DateTime datetime = DateTime.Now;
                    //    string studentName = "";
                    //    string studentCode = txbMSV.Text;
                    //    string cardID = "";
                    //    string StudentID = "";
                    //    string Khoa = "";
                    //    string gmail = "";
                    //    string phone = "";
                    //    string other = "";
                    //    bool isDelete = false;
                    //    string ID = Guid.NewGuid().ToString();
                    //    string IDCardEvent = Guid.NewGuid().ToString();


                    //    // Bang tblcard
                    //    string getData = "use VinUniver; select * from tblCard where CardNumber = '" + cardNumber + "'";
                    //    DataTable dt = dbConnection.FillData(getData);
                    //    if (dt != null && dt.Rows.Count > 0)
                    //    {
                    //    }
                    //    else
                    //    {
                    //        string strCard = $"use VinUniver; insert into tblCard values ('{CardID}', '{cardNo}', '{cardNumber}', '{cardKey}','{isDelete}')";
                    //        dbConnection.ExecuteCommand(strCard);
                    //    }

                    //    // Bảng tblCardEvent

                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append("select * from tblRegister inner join tblStudent ");
                    //    sb.Append("on tblRegister.StudentID = tblStudent.StudentID ");
                    //    sb.Append("where tblRegister.CardNumber = '" + cardNumber + "' and tblRegister.IsDelete = '0'");

                    //    DataTable dtCardEvent = dbConnection.FillData(sb.ToString());
                    //    if (dtCardEvent != null && dtCardEvent.Rows.Count > 0)
                    //    {
                    //        DataRowView drv = dtCardEvent.DefaultView[0];

                    //        cardID = drv["CardID"].ToString();
                    //        StudentID = drv["StudentID"].ToString();
                    //        studentName = drv["StudentName"].ToString();
                    //        studentCode = drv["StudentCode"].ToString();
                    //        Khoa = drv["Khoa"].ToString();
                    //        gmail = drv["Gmail"].ToString();
                    //        phone = drv["PhoneNumber"].ToString();
                    //        other = drv["Other"].ToString();

                    //    }
                    //    string strEvent = $"use VinUniver; insert into tblCardEvent values ('{IDCardEvent}', '{cardNumber}', '{datetime}', '{studentName}', '{studentCode}', '{cardID}','{StudentID}','{isDelete}')";
                    //    dbConnection.ExecuteCommand(strEvent);
                    //    txbHoTen.Invoke(new Action(() =>
                    //    {
                    //        txbHoTen.Text = studentName;
                    //        txbKhoa.Text = Khoa;
                    //        txbGmail.Text = gmail;
                    //        txbPhone.Text = phone;
                    //        txbOther.Text = other;
                    //    }));


                    //}
                    Halt(true);
                    // Cho nut nhan Halt
                }
                //if (txbMSV.Text != "")
                //{
                //    ticketCode = txbMSV.Text.Trim();   // Trim ko thể cắt kí tự -> dùng \0
                //    //ticketCode dữ liệu cần gửi đi
                //    if (ticketCode != "")
                //    {
                //        SetText("TicketCode: " + ticketCode);

                //        // Đẩy dữ liệu ra Output
                //        if (port_Output.IsOpen)
                //        {
                //            port_Output.Write(ticketCode);
                //        }
                //    }
                //    ticketCode = "";
                //    isGetOutData = false;
                //}


                return;

            }
            catch (Exception ex)
            {
                SetText("Card data error: " + ex.ToString());
            }

            //SetText("Card: " + result);
            //SetText("Length: " + result.Length);
        }

        private void ClearText()
        {
            txbCardID.Text = "";
            txbHoTen.Text = "";
            txbMSV.Text = "";
            txbKhoa.Text = "";
            txbGmail.Text = "";
            txbPhone.Text = "";
            txbOther.Text = "";
            lblQuetThe.Text = "";
        }

        private bool ProcessCard(Em_Key typeKey, Em_Sector sector, Em_Block block, string textData, bool isContinue)
        {
            //if (!Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Request))
            //{
            //    return false;
            //}
            //if (!Function(typeKey, sector, block, textData, isContinue, Em_Fuction.CardId))
            //{
            //    return false;
            //}
            //if (!Function(typeKey, sector, block, textData, isContinue, Em_Fuction.SaveKey))
            //{
            //    return false;
            //}
            //if (!Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Select))
            //{
            //    return false;
            //}
            //if (!Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Authen))
            //{
            //    return false;
            //}
            //if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Read))
            //{
            //    if (Long16ByteReadLan1)
            //    {
            //        Read(Em_Block.block1, textData, isContinue);

            //        if (Long16ByteReadLan2)
            //        {
            //            Read(Em_Block.block2, textData, isContinue);
            //        }
            //    }
            //    //Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Halt);
            //    return true;
            //}
            //return true;
            if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Request))
            {
                if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.CardId))
                {
                    if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.SaveKey))
                    {
                        if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Select))
                        {
                            if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Authen))
                            {
                                if (Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Read))
                                {
                                    if (Long16ByteReadLan1)
                                    {
                                        Read(Em_Block.block1, textData, isContinue);

                                        if (Long16ByteReadLan2)
                                        {
                                            Read(Em_Block.block2, textData, isContinue);
                                        }
                                    }
                                    //Function(typeKey, sector, block, textData, isContinue, Em_Fuction.Halt);
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;

        }

        private bool Function(Em_Key typeKey, Em_Sector sector, Em_Block block, string textData, bool isContinue, Em_Fuction fuction)
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

                case Em_Fuction.Read:
                    return Read(block, textData, isContinue);

                case Em_Fuction.Halt:
                    return Halt(isContinue);
            }
            return false;
        }



        private void serialPort_DataReceived_Output(object sender, SerialDataReceivedEventArgs e)
        {
            string result;
            try
            {
                System.Threading.Thread.Sleep(300);
                string reply = "";
                while (this.port_Output.BytesToRead > 0)
                {
                    char tmp = Convert.ToChar(this.port_Output.ReadByte());
                    reply += tmp;
                }
                result = reply;
                if (port_QR.IsOpen)
                {
                    port_QR.Write(result);
                }
            }
            catch (Exception ex)
            {
                result = "";
            }

            SetText("Output: " + result);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePort();
        }

        // Hàm so sánh 2 byte trùng nhau 

        private void ClearMemory()
        {
            while (port_Card.BytesToRead > 0)
            {
                port_Card.ReadByte();
            }
        }


        private void btnHalt_Click(object sender, EventArgs e)
        {

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
                isbtnRead = false;
                isbtnDelete = false;
                isError = false;

                checkcount = 0;
                tong = 0;
            }
            return result;
        }

        private bool Read(Em_Block block, string textData, bool isContinue)
        {
            bool result = false;
            if (isWriteRead)
            {
                WriteRead(block);
            }
            // Bắt đầu đọc lệnh Read
            if (isReadRead)
            {
                // Neu Auto/ Neu Write/ Neu Data/ Neu Key
                result = ReadRead(textData, isContinue);
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

        private bool Select()
        {
            bool result = false;
            if (isWriteSelect)
            {
                writeselect++;
                WriteSelect();
            }
            // Bắt đầu đọc lệnh Select
            if (isReadSelect)
            {
                result = ReadSelect();
            }
            return result;
        }

        private bool CardID()
        {
            bool result = false;
            if (isWriteCardID == true && isReadHalt == false)
            {
                writecardid++;
                WriteCardID();
            }
            // Bắt đầu đọc byte CardID
            if (isReadCardID)
            {
                readcardid++;
                result = ReadCardID();
            }
            return result;
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
                writesavekey++;
                if (!WriteSaveKey(typeKey, sector))
                {
                    return false;
                }
            }
            // Bắt đầu đọc lệnh SaveKey 
            if (isReadSaveKey)
            {
                readsavekey++;
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
            try
            {
                GeneralTool.LogHelper.Logger_SystemInfor("start Halt", Application.StartupPath);

                bool result = false;
                int a = 0;
                timer1.Enabled = true;
                while (port_Card.BytesToRead <= 6)
                {
                    a++;
                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("Halt false", Application.StartupPath);

                        result = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("Halt true", Application.StartupPath);

                timer1.Enabled = false;
                timeOut = 0;

                //lblHalt11.Invoke(new Action(() =>
                //{
                //    lblHalt11.Text = a.ToString();
                //}));
                //if (port_Card.BytesToRead <= 6) return;
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

                    lblQuetThe.Invoke(new Action(() =>
                    {
                        isGetOutData = true;
                        if (isbtnRead)
                        {
                            m++;
                            lblQuetThe.Text = "Đọc hoàn tất";
                        }
                        else if (isbtnWrite)
                        {
                            lblQuetThe.Text = "Ghi hoàn tất";
                        }

                        lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);
                        lblQuetThe.ForeColor = Color.Green;
                    }));
                    result = true;

                }
                else
                {
                    lblQuetThe.Invoke(new Action(() =>
                    {
                        lblQuetThe.Text = "Finish";
                        lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        lblQuetThe.ForeColor = Color.Red;
                    }));
                }
                isReadHalt = false;
                //xuLyCardOut = true;
                ClearMemory();
                GeneralTool.LogHelper.Logger_SystemInfor("end Halt", Application.StartupPath);

                return result;
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("error Halt", Application.StartupPath);

                //MessageBox.Show("Error Halt");
                return false;
            }

        }

        private void WriteHalt()
        {
            ClearMemory();

            List<byte> bytes = isWriteHaltBytes();
            WriteBytes(bytes);
            isReadHalt = true;
            isWriteHalt = false;
        }
        int count = 0;
        private bool isReadWriteKey;
        private bool isbtnRead;
        private string strHoTen;
        private string strMSV;
        private string strKhoa;
        private string strGmail;
        private string strPhone;
        private string strOther;
        private bool ByteLong;

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
            return;
        }
        private bool ReadRead(string textLocation, bool isContinue)
        {
            try
            {
                GeneralTool.LogHelper.Logger_SystemInfor("start Read", Application.StartupPath);

                bool result = false;
                
                timer1.Enabled = true;
                while (port_Card.BytesToRead <= 6)
                {
                    GeneralTool.LogHelper.Logger_SystemInfor("startWhile Read", Application.StartupPath);

                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("while false Read", Application.StartupPath);

                        result = false;
                        break;
                    }
                    else
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("while continue Read", Application.StartupPath);

                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("while end Read", Application.StartupPath);

                timer1.Enabled = false;
                timeOut = 0;
               
                List<byte> buffer = new List<byte>();

                for (int i = 0; i < 7; i++)
                {
                    buffer.Add((byte)port_Card.ReadByte());
                }


                byte[] dataRead = buffer.ToArray();
                GeneralTool.LogHelper.Logger_SystemInfor("1 Read", Application.StartupPath);

                if (compareTwoByte(dataRead, errorRead))
                {
                    GeneralTool.LogHelper.Logger_SystemInfor("SosangError Read", Application.StartupPath);

                    lblQuetThe.Invoke((Action)(() =>
                    {
                        lblQuetThe.Text = "Lỗi đọc byte";
                        lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        lblQuetThe.ForeColor = Color.Red;
                    }));
                    // Loi nhay vao Halt

                    isWriteHalt = true;

                    isError = true;
                    ticketCode = "";
                    result = false;
                }
                else
                {
                    int a = 0;
                    GeneralTool.LogHelper.Logger_SystemInfor("Start While Bien Read", Application.StartupPath);

                    while (port_Card.BytesToRead < 15)
                    {
                        a++;
                        if (a == 50)
                        {
                            GeneralTool.LogHelper.Logger_SystemInfor($"true While Bien Read : a = '{a}'", Application.StartupPath);

                            result = false;
                            break;
                        }
                        else
                        {
                            GeneralTool.LogHelper.Logger_SystemInfor($"continue while bien Read : a = '{a}'", Application.StartupPath);

                            continue;
                        }
                    }
                    a = 0;
                    GeneralTool.LogHelper.Logger_SystemInfor($"End while bien Read : a = '{a}'", Application.StartupPath);


                    //while (port_Card.BytesToRead < 15)
                    //{
                    //    continue;
                    //}

                    //GeneralTool.LogHelper.Logger_SystemInfor("Sosanhsuccesful Read", Application.StartupPath);

                    //timer2.Enabled = true;

                    //while (port_Card.BytesToRead < 15)
                    //{
                    //    GeneralTool.LogHelper.Logger_SystemInfor($"stratwhile2 Read : isTimer2: '{timer2.Enabled}',timeOut2:'{timeOut2}'", Application.StartupPath);

                    //    if (inTimeOut2)
                    //    {
                    //        GeneralTool.LogHelper.Logger_SystemInfor($"while false2 Read,isTimer2: '{timer2.Enabled}',timeOut2:'{timeOut2}'", Application.StartupPath);

                    //        result = false;
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        GeneralTool.LogHelper.Logger_SystemInfor($"while continue2 Read: isTimer2: '{timer2.Enabled}',timeOut2:'{timeOut2}' ", Application.StartupPath);

                    //        // Dừng ở đây
                    //        continue;
                    //    }
                    //}

                    ////timer2.Enabled = false;
                    //timeOut2 = 0;
                    //GeneralTool.LogHelper.Logger_SystemInfor($"while end 2 Read, isTimer: '{timer2.Enabled}',timeOut : '{timeOut2}'", Application.StartupPath);


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
                                TextBoxExam = TextBoxExam + FromHexString(ByteExam);

                                txbMSV.Tag = FromHexString(ByteExam);

                                if (CheckEndText(TextBoxExam))
                                {
                                    isWriteRequest = isContinue;
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
                                    isWriteRequest = isContinue;
                                }
                                else
                                {
                                    //log
                                    //MessageBox.Show("Dữ liệu đang >= 3 block");
                                }
                            }
                            else
                            {
                                ByteExam = ByteArrayToString(DataRead);
                                TextBoxExam = FromHexString(ByteExam);
                                if (CheckEndText(TextBoxExam))
                                {
                                    isWriteRequest = isContinue;
                                }
                                else
                                {
                                    isWriteRead = true;
                                    Long16ByteReadLan1 = true;
                                }

                            }
                            txbMSV.Invoke((Action)(() =>
                            {
                                txbMSV.Text = TextBoxExam;
                            }));
                            
                            result = true;

                        }
                        else
                        {
                            //MessageBox.Show("Không true cũng không false", "Read");
                            lblQuetThe.Invoke(new Action(() =>
                            {
                                lblQuetThe.Text = "Exception! - Read";
                            }));
                            isWriteHalt = true;
                            isError = true;
                            ticketCode = "";
                        }

                    }
                    else
                    {
                        result = false;
                    }
                }
                ClearMemory();
                GeneralTool.LogHelper.Logger_SystemInfor("end Read", Application.StartupPath);
                isWriteData = true;
                isReadRead = false;

                return result;
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("error Read", Application.StartupPath);

                //MessageBox.Show("Error Read");
                return false;
            }


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
        private bool ReadAuthenticate()
        {
            try
            {
                GeneralTool.LogHelper.Logger_SystemInfor("start Authen", Application.StartupPath);

                bool result = false;
                int a = 0;
                timer1.Enabled = true;

                while (port_Card.BytesToRead <= 6)
                {
                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("Authen false", Application.StartupPath);

                        result = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("Authen true", Application.StartupPath);

                timer1.Enabled = false;
                timeOut = 0;


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

                    isWriteRead = true;

                }
                else
                {
                    DisplayFalseAuthen();
                    isWriteHalt = true;     // Nếu false nhảy vào Halt
                    isError = true;
                    ticketCode = "";
                }


                isReadAuthen = false;
                //xuLyCardOut = true;
                GeneralTool.LogHelper.Logger_SystemInfor("End Authen", Application.StartupPath);

                return result;
                ClearMemory();
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("Error Authen", Application.StartupPath);

                //MessageBox.Show("Error Authen");
                return false;
            }

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
        private string GetText(string textCount)
        {
            // Hàm đếm số lượng của chuỗi string 
            int kitu, i, l;
            kitu = i = 0;
            string newText = "";
            int count = 0;
            while (i < textCount.Length)
            {
                if (textCount[i] == '\0')
                {
                    break;
                }
                i++;
            }
            return textCount.Substring(0, i);
        }
        private bool ReadSaveKey()
        {
            GeneralTool.LogHelper.Logger_SystemInfor("start SaveKey", Application.StartupPath);

            bool result = false;
            try
            {
                int a = 0;
                int delay = 0;
                timer1.Enabled = true;
                while (port_Card.BytesToRead <= 6)
                {
                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("SaveKey false", Application.StartupPath);
                        result = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("SaveKey true", Application.StartupPath);
                timer1.Enabled = false;
                timeOut = 0;

                //lblSaveKey11.Invoke(new Action(() =>
                //{
                //    lblSaveKey11.Text = a.ToString();

                //}));
                //if (port_Card.BytesToRead <= 6) return;
                lblQuetThe.Invoke(new Action(() =>
                {
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
                        picTrue.Visible = true;

                        isWriteSelect = true;    // Nếu true tiếp tục 
                        result = true;
                    }
                    else
                    {
                        picFalse.Visible = true;
                        lblQuetThe.Text = "Lỗi không thể Save Key\nThẻ đã được ghi dữ liệu";
                        lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        lblQuetThe.ForeColor = Color.Red;
                        isWriteHalt = true;     // Nếu false nhảy vào Halt quẹt lại 
                        isError = true;
                        ticketCode = "";

                    }
                }));
                ClearMemory();
                isReadSaveKey = false;

                //xuLyCardOut = true;
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("Error - SaveKey", Application.StartupPath);

                //MessageBox.Show("error" + ex.Message);
                return false;
            }
            GeneralTool.LogHelper.Logger_SystemInfor("End SaveKey", Application.StartupPath);

            return result;
        }
        private bool WriteSaveKey(Em_Key typeKey, Em_Sector sector)
        {
            ClearMemory();
            List<byte> bytes = WriteSaveKeyBytes(typeKey, sector);
            if (bytes == null)
            {
                return false;
            }
            else
            {

                WriteBytes(bytes);
                isWriteSaveKey = false;
                isReadSaveKey = true;
                return true;
            }
            // xuLyCardOut = true;
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
            string textPresentKey = "";
            // Lấy key từ mã thẻ quẹt 
            string cardNumber = maThe;
            string key = "FF FF FF FF FF FF";

            //string str = $"select tblRegister.CardNumber, tblRegister.IsDelete, tblCard.CardKey from tblRegister inner join tblCard on tblRegister.CardNumber = tblCard.CardNumber where tblRegister.CardNumber = '{cardNumber}' and tblRegister.IsDelete = '0'";
            //DataTable dtNew = dbConnection.FillData(str);
            //// Nếu mà đã đăng ký và chưa bị hủy 
            //if (dtNew != null && dtNew.Rows.Count > 0)
            //{
            //    DataRowView drv = dtNew.DefaultView[0];
            //    key = drv["Cardkey"].ToString();
            //    isReadSaveKey = true;

            textPresentKey = key;
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
            //}
            //else
            //{
            //    // Thẻ chưa được đăng ký
            //    //Halt(true);
            //    lblThongbao.Invoke(new Action(() =>
            //    {
            //        lblThongbao.Text = "Thẻ chưa được đăng ký";
            //        lblThongbao.ForeColor = Color.Red;

            //    }));
            //    return null;
            //}

        }
        private bool ReadSelect()
        {
            try
            {
                GeneralTool.LogHelper.Logger_SystemInfor("start Select", Application.StartupPath);

                bool result = false;
                int a = 0;
                timer1.Enabled = true;
                while (port_Card.BytesToRead <= 6)
                {
                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("Select false", Application.StartupPath);
                        result = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("Select true", Application.StartupPath);
                timer1.Enabled = false;
                timeOut = 0;
                //lblSelect11.Invoke(new Action(() =>
                //{
                //    lblSelect11.Text = a.ToString();

                //}));
                //if (port_Card.BytesToRead <= 6) return;
                byte[] buffer = new byte[7];
                int index = 0;
                while (port_Card.BytesToRead > 0)
                {
                    buffer[index] = (Byte)port_Card.ReadByte();
                    index++;
                    if (index == buffer.Length) break;
                }
                lblQuetThe.Invoke(new Action(() =>
                {
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
                }));
                ClearMemory();
                isReadSelect = false;
                GeneralTool.LogHelper.Logger_SystemInfor("End Select", Application.StartupPath);

                return result;
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("Error Select", Application.StartupPath);
                //MessageBox.Show("Error Select");
                return false;
            }

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
        byte[] textAdd = new byte[16];
        private bool NewCard;
        private bool isbtnDelete;

        private void DisplayFalseAuthen()
        {
            //lblAuthen.Text = "Key chưa đúng";
            //lblAuthen.ForeColor = Color.Red;
            //lblAuthen.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            picFalse.Invoke(new Action(() =>
            {
                picFalse.Visible = true;
                picTrue.Visible = false;
            }));



            //lblShow.Text = "Thẻ đã được ghi dữ liệu";
            //lblShow.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
            //lblShow.ForeColor = Color.Red;
            lblDevice.Invoke(new Action(() =>
            {
                lblQuetThe.Text = "Thẻ không hợp lệ - Key chưa đúng";
                lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                lblQuetThe.ForeColor = Color.Red;
            }));
        }

        private void DisplaySuccessAuthen()
        {
            picTrue.Invoke(new Action(() =>
            {
                picTrue.Visible = true;
                picFalse.Visible = false;
            }));

            //lblAuthen.Text = "Key đúng";
            //lblAuthen.ForeColor = Color.Green;
            //lblAuthen.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
        }


        private void DisplayFalseSelect()
        {
            lblQuetThe.Invoke(new Action(() =>
            {
                lblQuetThe.Text = "Lỗi không thể Select";
                lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                lblQuetThe.ForeColor = Color.Red;
            }));

        }

        private void DisplaySuccessSelect()
        {
            // ko can hien thi
        }
        private bool ReadCardID()
        {
            try
            {
                GeneralTool.LogHelper.Logger_SystemInfor("Start CardID", Application.StartupPath);

                /* Check nhận đủ > 6 byte mới tiếp tục
                 * Lấy 7 byte trong serialPort -> Check có phải trùng 7 byte erorr không
                 * Nếu không trùng check số byte trong serialPort nếu chưa đủ 3 byte thì tiếp tục đọc 
                 * Nếu đủ 3 byte thì check xem có trùng vs byte successfulCardID không (so sánh 4 byte đầu)
                 * Nếu successfulCardID -> Lấy 4 byte tên thẻ ra hiển thị lên 
                 */
                bool result = false;

                timer1.Enabled = true;
                while (port_Card.BytesToRead <= 6)
                {
                    GeneralTool.LogHelper.Logger_SystemInfor("StartWhile CardID", Application.StartupPath);

                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("while false CardID", Application.StartupPath);

                        result = false;
                        break;
                    }
                    else
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("while continue CardID", Application.StartupPath);
                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("while end CardID", Application.StartupPath);

                timer1.Enabled = false;
                timeOut = 0;
               
                List<byte> buffer = new List<byte>();
                for (int i = 0; i < 7; i++)
                {
                    buffer.Add((byte)port_Card.ReadByte());
                }

                byte[] dataCardID = buffer.ToArray();
                GeneralTool.LogHelper.Logger_SystemInfor("1 CardID", Application.StartupPath);

                if (compareTwoByte(dataCardID, errorCardID))
                {
                    GeneralTool.LogHelper.Logger_SystemInfor("SosanhError CardID", Application.StartupPath);

                    lblQuetThe.Invoke(new Action(() =>
                    {
                        lblQuetThe.Text = "Lỗi không thể tìm thấy mã thẻ! - CardID";
                        lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        lblQuetThe.ForeColor = Color.Red;
                    }));
                    isWriteHalt = true;
                    isReadCardID = false;
                    isError = true;
                }
                else
                {
                    GeneralTool.LogHelper.Logger_SystemInfor("SosanhSuccesFul CardID", Application.StartupPath);

                    int a = 0;
                    while (port_Card.BytesToRead < 3)
                    {
                        a++;
                        if(a == 50)
                        {
                            result = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    //timer2.Enabled = true;
                    
                    //while (port_Card.BytesToRead < 3)
                    //{
                    //    GeneralTool.LogHelper.Logger_SystemInfor($"startWhile2 CardID - isTimer = '{timer2.Enabled}'", Application.StartupPath);

                    //    if (inTimeOut2)
                    //    {
                    //        GeneralTool.LogHelper.Logger_SystemInfor("while false2 CardID", Application.StartupPath);

                    //        return false;
                    //    }
                    //    else
                    //    {
                    //        GeneralTool.LogHelper.Logger_SystemInfor($"while continue2 CardID - isTimer = '{timer2.Enabled}", Application.StartupPath);
                    //        continue;
                    //    }
                    //}
                    //GeneralTool.LogHelper.Logger_SystemInfor("while end2 CardID", Application.StartupPath);

                    //timer2.Enabled = false;
                    //timeOut2 = 0;

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
                            txbCardID.Invoke(new Action(() =>
                            {
                                List<byte> response = new List<byte>();
                                for (int i = 4; i < 8; i++)
                                {
                                    response.Add(buffer[i]);
                                }
                                nameCard = response.ToArray(); // ToArray() chuyển từ List sang mảng  
                                txbCardID.Text = ByteArrayToString(nameCard);
                                Mathe = nameCard;
                                maThe = ByteArrayToString(nameCard);  // string cardName
                            }));
                            result = true;
                        }
                        else
                        {
                            lblQuetThe.Invoke(new Action(() =>
                            {
                                lblQuetThe.Text = "Exception! - CardID";
                            }));

                            //MessageBox.Show("Không true cũng không false", "CardID");
                            isWriteHalt = true;
                            isError = true;

                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
                ClearMemory();
                isReadCardID = false;
                isWriteSaveKey = true;
                GeneralTool.LogHelper.Logger_SystemInfor("End CardID", Application.StartupPath);

                return result;
                //xuLyCardOut = true;
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("Error CardiD", Application.StartupPath);

                //MessageBox.Show("Loi CardID");
                return false;
            }
            
        }
        int timeOut = 0;
        int timeOut2 = 0;
        bool inTimeOut;
        bool inTimeOut2;
        private bool ShowRequestData()
        {
            GeneralTool.LogHelper.Logger_SystemInfor("STart ShowRequestData", Application.StartupPath);

            bool result = false;
            try
            {
                int a = 0;
                timer1.Enabled = true;
                while (port_Card.BytesToRead <= 6)
                {
                    if (inTimeOut)
                    {
                        GeneralTool.LogHelper.Logger_SystemInfor("ShowRequestData false", Application.StartupPath);
                        result = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                GeneralTool.LogHelper.Logger_SystemInfor("ShowRequestData true", Application.StartupPath);
                timer1.Enabled = false;
                timeOut = 0;
                List<byte> buffer = new List<byte>();
                for (int i = 0; i < 7; i++)
                {
                    buffer.Add((byte)port_Card.ReadByte());
                }

                byte[] dataCardID = buffer.ToArray();
                if (compareTwoByte(dataCardID, errorRequest))
                {
                    lblQuetThe.Invoke(new Action(() =>
                    {
                        lblQuetThe.Text = "Khong the tim thay the! - Request";
                        lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                        lblQuetThe.ForeColor = Color.Red;
                    }));

                    //--Gui lenh halt de ket thuc
                    //--hien tbao yeu cau quet the lai
                    isWriteHalt = true;
                    isReadRequest = false;
                    isError = true;
                }
                else
                {
                    timer1.Enabled = true;

                    while (port_Card.BytesToRead < 1)
                    {
                        if (inTimeOut)
                        {
                            GeneralTool.LogHelper.Logger_SystemInfor("ShowRequestData false", Application.StartupPath);
                            result = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    timer1.Enabled = false;
                    timeOut = 0;
                    if (port_Card.BytesToRead == 1)
                    {
                        buffer.Add((byte)port_Card.ReadByte());
                        dataCardID = buffer.ToArray();


                        if (compareTwoByte(dataCardID, successfulRequest))
                        {
                            lblQuetThe.Invoke(new Action(() =>
                            {
                                //lblQuetThe.Text = "Request đã nhận thẻ";
                                lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                                lblQuetThe.ForeColor = Color.Green;
                            }));

                            result = true;
                            isReadRequest = false;
                            isWriteCardID = true;
                        }
                        else
                        {
                            lblQuetThe.Invoke(new Action(() =>
                            {
                                lblQuetThe.Text = "Lỗi thao tác - Kiểm tra lại thẻ - Request";
                                lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                                lblQuetThe.ForeColor = Color.Red;
                            }));

                            isWriteHalt = true;
                            isError = true;

                        }
                    }
                }
                ClearMemory();
            }
            catch (Exception ex)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("Errror", Application.StartupPath);

                //MessageBox.Show("error" + ex.Message);
            }

            GeneralTool.LogHelper.Logger_SystemInfor("End ShowRequestData", Application.StartupPath);
            return result;

        }
        private bool QuetThe()
        {
            bool result = false;
            //if (port_Card.BytesToRead <= 6) return;
            timer1.Enabled = true;
            while (port_Card.BytesToRead <= 6)
            {
                if (inTimeOut)
                {
                    GeneralTool.LogHelper.Logger_SystemInfor("QuetThe False", Application.StartupPath);
                    result = false;
                    break;
                }
                else
                    continue;
            }
            GeneralTool.LogHelper.Logger_SystemInfor("QuetThe True", Application.StartupPath);
            timer1.Enabled = false;
            timeOut = 0;

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
            lblQuetThe.Invoke((Action)(() =>
            {
                if (compareTwoByte(bufferData1, answerCardIn))
                {
                    lblQuetThe.Text = "Đã nhận thẻ";
                    lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    lblQuetThe.ForeColor = Color.Green;
                    isWriteRequest = true;
                    ClearText();
                    result = true;

                }
                else if (compareTwoByte(bufferData1, answerCardOut))
                {
                    lblQuetThe.Text = "Chưa nhận thẻ";
                    lblQuetThe.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    lblQuetThe.ForeColor = Color.Red;
                    result = false;
                }
                else
                {
                    //MessageBox.Show("Không true cũng không false check quet the");
                    result = false;
                }
            }));
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

            lblQuetThe.Invoke(new Action(() =>
            {
                if (Mathe == null)
                {
                    //MessageBox.Show("Chưa có mã thẻ người ơi");
                    isWriteHalt = true;
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        bytes2.Add(Mathe[i]);
                    }
                }
            }));

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

        private void btnHalt_Click_1(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbCardID.Text = "";
            txbHoTen.Text = "";
            txbMSV.Text = "";
            txbKhoa.Text = "";
            txbGmail.Text = "";
            txbPhone.Text = "";
            txbOther.Text = "";
            lblQuetThe.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GeneralTool.LogHelper.Logger_SystemInfor($"Start Timer: '{timeOut}'", Application.StartupPath);

            if (timeOut <= 100)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("TimeOut : '"+timeOut+"'", Application.StartupPath);

                timeOut += 10;
            }
            else
            {
                GeneralTool.LogHelper.Logger_SystemInfor("TimeOut True", Application.StartupPath);

                inTimeOut = true;
                timer1.Enabled = false;
                timeOut = 0;
            }
        }

        private void frmReadCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
            Environment.Exit(0);
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            GeneralTool.LogHelper.Logger_SystemInfor($"Start Timer : '{timeOut2}'", Application.StartupPath);

            if (timeOut2 <= 100)
            {
                GeneralTool.LogHelper.Logger_SystemInfor("TimeOut : '" + timeOut2 + "'", Application.StartupPath);

                timeOut2 += 10;
            }
            else
            {
                GeneralTool.LogHelper.Logger_SystemInfor("TimeOut True", Application.StartupPath);

                inTimeOut2 = true;
                timer2.Enabled = false;
                timeOut2 = 0;
            }
        }

        private void timerStartup_Tick(object sender, EventArgs e)
        {
            OpenPort_QR();
            OpenPort_Card();
            OpenPort_Output();
            WriteScanBytes();
            if(port_Card.IsOpen && port_QR.IsOpen && port_Output.IsOpen)
            {
                timerStartup.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        //private void timerStartup_Tick(object sender, EventArgs e)
        //{
        //    //GeneralTool.LogHelper.Logger_SystemInfor($"Start TimerStartUp: '{timeOut}'", Application.StartupPath);

        //    //OpenPort_QR();
        //    //OpenPort_Card();
        //    //OpenPort_Output();
        //    //WriteScanBytes();
        //    //if (port_Card.IsOpen && port_QR.IsOpen && port_Output.IsOpen)
        //    //{
        //    //    timerStartup.Enabled = false;
        //    //    GeneralTool.LogHelper.Logger_SystemInfor($"Stop TimerStartUp: '{timeOut}'", Application.StartupPath);
        //    //}
        //}
    }
}
