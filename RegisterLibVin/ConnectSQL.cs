using ConnectionConfig;
using Futech.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterLibVin
{
    public static class ConnectSQL
    {

        public static Futech.Tools.MDB dbConnection;// = new MDB(SQLServerName, SQLDatabaseName, SQLAuthentication, SQLUserName, SQLPassword);


        private static string sQLServerName = "";
        private static string sQLDatabaseName = "";
        private static string sQLUserName = "";
        private static string sQLPassword = "";
        private static string sQLAuthentication = "";
        private static string sQLDatabaseNameEx = "";


        public static string SQLServerName { get => sQLServerName; set => sQLServerName = value; }
        public static string SQLDatabaseName { get => sQLDatabaseName; set => sQLDatabaseName = value; }
        public static string SQLUserName { get => sQLUserName; set => sQLUserName = value; }
        public static string SQLPassword { get => sQLPassword; set => sQLPassword = value; }
        public static string SQLAuthentication { get => sQLAuthentication; set => sQLAuthentication = value; }
        public static string SQLDatabaseNameEx { get => sQLDatabaseNameEx; set => sQLDatabaseNameEx = value; }

        
        public static void ConnectConfig()
        {
            CacheLayer.ClearAll();
            SQLConn[] sqls = null;

            
            if (File.Exists(Application.StartupPath + @"\SQLConn.xml"))
            {
                string sqlPath = Application.StartupPath + @"\SQLConn.xml";
                FileXML.ReadXMLSQLConn(sqlPath, ref sqls);
                if (sqls != null && sqls.Length > 0)
                {
                    if (sqls[0].SQLDatabase == String.Empty)
                    {
                        MessageBox.Show("Bad database configs!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show(sqlPath);
                        return;
                    }
                    var usingdb = sqls[0];
                    ConnectSQL.SQLServerName = usingdb.SQLServerName;
                    ConnectSQL.SQLDatabaseName = usingdb.SQLDatabase;
                    ConnectSQL.SQLUserName = usingdb.SQLUserName;
                    ConnectSQL.SQLPassword = usingdb.SQLPassword;
                    ConnectSQL.SQLAuthentication = usingdb.SQLAuthentication;
                    dbConnection = new MDB(ConnectSQL.SQLServerName, ConnectSQL.SQLDatabaseName, ConnectSQL.SQLAuthentication, ConnectSQL.SQLUserName, ConnectSQL.SQLPassword);
                    // Mở kết nối
                    if (!dbConnection.OpenMDB())
                    {
                        MessageBox.Show("Chưa mở kết nối", "ConnectionConfig", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi chưa cấu hình ConnectionConfig hoặc cấu hình sai","",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                }
            }
        }

    }
}
