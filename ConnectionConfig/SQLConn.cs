using Futech.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLibVin
{
    public class SQLConn
    {
        public SQLConn()
        {

        }
        public SQLConn(string _servername, string DatabaseIp, string _databasename, string _user, string _pass, string _authentication, bool isDefault)
        {
            //_databaseIp = DatabaseIp;
            sqlservername = _servername;
            sqldatabase = _databasename;
            sqlusername = _user;
            sqlpassword = _pass;
            authentication = _authentication;
            isDefaultDB = isDefault;

        }

        private string _databaseIp;

        public string DatabaseIp { get => _databaseIp; set => _databaseIp = value; }



        private string sqlservername = "";
        public string SQLServerName
        {
            get { return sqlservername; }
            set { sqlservername = value; }
        }

        private string sqldatabase = "";
        public string SQLDatabase
        {
            get { return sqldatabase; }
            set { sqldatabase = value; }
        }

        private string sqlusername = "";
        public string SQLUserName
        {
            get { return sqlusername; }
            set { sqlusername = value; }
        }

        private string sqlpassword = "";
        public string SQLPassword
        {
            get { return sqlpassword; }
            set { sqlpassword = value; }
        }

        private string authentication = "";
        public string SQLAuthentication
        {
            get { return authentication; }
            set { authentication = value; }
        }
        private bool isDefaultDB;

        public bool IsDefaultDB
        {
            get { return isDefaultDB; }
            set { isDefaultDB = value; }
        }
    }
}
