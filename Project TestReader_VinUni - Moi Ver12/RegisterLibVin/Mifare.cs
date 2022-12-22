using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLibVin
{
    internal class Mifare
    {
        // Tool tính 2 byte cuối 
        // Hàm tính 2 byte cuối CRC-H và CRC-L theo chuẩn CRC16
        public static void CalculateCRC(List<byte> bytes, out byte[] crc)
        {
            byte[] data = new byte[bytes.Count - 1];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = bytes[i + 1];
            }
            crc = ComputeCrc(data);
        }
        public static ushort[] CrcTable = {
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
        public static byte[] ComputeCrc(byte[] data)
        {
            ushort crc = 0xFFFF;

            foreach (byte datum in data)
                crc = (ushort)((crc >> 8) ^ CrcTable[(crc ^ datum) & 0xFF]);

            return BitConverter.GetBytes(crc);
        }
        // Các byte ghi 

        public static List<byte> RequestScanBytes()
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


        // các byte nhận so sánh 
        public static byte[] QuetThe_In()
        {
            byte[] answerCardIn = new byte[7];
            answerCardIn[0] = 0x01;
            answerCardIn[1] = 0x00;
            answerCardIn[2] = 0x12;
            answerCardIn[3] = 0x01;
            answerCardIn[4] = 0x49;
            answerCardIn[5] = 0x47;
            answerCardIn[6] = 0x60;
            return answerCardIn;
        }
        public static byte[] QuetThe_Out()
        {
            byte[] answerCardOut = new byte[7];
            answerCardOut[0] = 0x01;
            answerCardOut[1] = 0x00;
            answerCardOut[2] = 0x12;
            answerCardOut[3] = 0x01;
            answerCardOut[4] = 0x52;
            answerCardOut[5] = 0x4c;
            answerCardOut[6] = 0x20;
            return answerCardOut;
        }
        public static byte[] CardID_OK()
        {
            byte[] successfulCardID = new byte[4];     // answerCard: Byte có thẻ
            successfulCardID[0] = 0x01;
            successfulCardID[1] = 0x00;
            successfulCardID[2] = 0x06;
            successfulCardID[3] = 0x04;
            return successfulCardID;
        }
        public static byte[] CardID_Error()
        {
            byte[] errorCardID = new byte[7];     // answerCard: Byte có thẻ
            errorCardID[0] = 0x01;
            errorCardID[1] = 0x00;
            errorCardID[2] = 0x15;
            errorCardID[3] = 0x01;
            errorCardID[4] = 0x1F;
            errorCardID[5] = 0xB8;
            errorCardID[6] = 0x51;
            return errorCardID;
        }
        public static byte[] Select_OK()
        {
            byte[] successfulSelect = new byte[7];
            successfulSelect[0] = 0x01;  // 1
            successfulSelect[1] = 0x00;  // 0
            successfulSelect[2] = 0x06;  // 6
            successfulSelect[3] = 0x01;  // 1
            successfulSelect[4] = 0x08;  // 8
            successfulSelect[5] = 0x73;  // 115
            successfulSelect[6] = 0xe0;  // 224
            return successfulSelect;
        }
        public static byte[] SaveKey_OK()
        {
            byte[] successfulSaveKey = new byte[7];
            successfulSaveKey[0] = 0x01;
            successfulSaveKey[1] = 0x00;
            successfulSaveKey[2] = 0x06;
            successfulSaveKey[3] = 0x01;
            successfulSaveKey[4] = 0x00;
            successfulSaveKey[5] = 0xb5;
            successfulSaveKey[6] = 0xe1;
            return successfulSaveKey;
        }
        public static byte[] Authen_OK()
        {
            byte[] successfulAuthen = new byte[7];
            successfulAuthen[0] = 0x01;
            successfulAuthen[1] = 0x00;
            successfulAuthen[2] = 0x06;
            successfulAuthen[3] = 0x01;
            successfulAuthen[4] = 0x00;
            successfulAuthen[5] = 0xb5;
            successfulAuthen[6] = 0xe1;
            return successfulAuthen;
        }
        public static byte[] Write_OK()
        {
            byte[] successfulWrite = new byte[7];
            successfulWrite[0] = 0x01;
            successfulWrite[1] = 0x00;
            successfulWrite[2] = 0x06;
            successfulWrite[3] = 0x01;
            successfulWrite[4] = 0x00;
            successfulWrite[5] = 0xB5;
            successfulWrite[6] = 0xE1;
            return successfulWrite;
        }
        public static byte[] Read_OK()
        {
            byte[] successfulRead = new byte[4];
            successfulRead[0] = 0x01;
            successfulRead[1] = 0x00;
            successfulRead[2] = 0x06;
            successfulRead[3] = 0x10;
            return successfulRead;
        }
        public static byte[] Read_Error()
        {
            byte[] errorRead = new byte[7];     // answerCard: Byte có thẻ
            errorRead[0] = 0x01;
            errorRead[1] = 0x00;
            errorRead[2] = 0x15;
            errorRead[3] = 0x01;
            errorRead[4] = 0x1f;
            errorRead[5] = 0xb8;
            errorRead[6] = 0x51;
            return errorRead;
        }
        public static byte[] Halt_OK()
        {
            byte[] byteReceiveHalt = new byte[7];     // answerCard: Byte có thẻ
            byteReceiveHalt[0] = 0x01;
            byteReceiveHalt[1] = 0x00;
            byteReceiveHalt[2] = 0x06;
            byteReceiveHalt[3] = 0x01;
            byteReceiveHalt[4] = 0x00;
            byteReceiveHalt[5] = 0xb5;
            byteReceiveHalt[6] = 0xe1;
            return byteReceiveHalt;
        }

    }
}
