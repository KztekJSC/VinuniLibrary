using System.Data.SqlClient;
using System.Diagnostics;
using CarPOSv2;
using CryptorEngines;
using CarPOSv2.Databases;
using CarPOSv2.ToolHelper;
using FileXMLs;
using SQLConns;

namespace CarPOSv2.Forms.SystemForms
{
    public partial class FrmLoading : Form
    {
        #region: Private Properties
        private readonly ProgressBarWithText _progressBarWithText;
        private SQLConn[]? _sqlConnections;
        #endregion: End Private Properties

        #region: Form
        public FrmLoading()
        {
            InitializeComponent();
            _progressBarWithText = new ProgressBarWithText();

            _progressBarWithText.Maximum = 14;
            _progressBarWithText.Minimum = 0;
            _progressBarWithText.Value = 0;
            _progressBarWithText.Dock = DockStyle.Bottom;

            Controls.Add(_progressBarWithText);
            Controls.SetChildIndex(_progressBarWithText, 0);
            Controls.SetChildIndex(txtProgressDetail, 1);
        }

        private async void frmLoading_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            await Task.Run(() =>
            {
                try
                {
                    if (File.Exists(Application.StartupPath + "\\SQLConn.xml"))
                    {
                        FileXML.ReadXMLSQLConn(Application.StartupPath + "\\SQLConn.xml", ref _sqlConnections);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message);
                }
                ConnectToSqlServer();
                //Check Database Connection
                if (!IsConnectSuccess())
                {
                    var isContinue = MessageBox.Show(@"Kết Nối Đến Máy Chủ Thất Bại, Bạn Có Muốn Tiếp Tục?", @"Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (isContinue == DialogResult.Yes)
                    {
                        var p = new Process();
                        var path = Application.StartupPath + "ConnectionConfig.exe";
                        p.StartInfo.FileName = path;
                        p.Start();
                        Invoke(Close);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblPrivilege.LoadPrivilegeData(StaticPool.Privileges);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Phân Quyền Truy Cập..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                TblVehicleType.LoadVehicleTypeCollection(StaticPool.VehicleTypes);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Phân Hạng Xe..."; });


                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblRentType.LoadRentType(StaticPool.RentTypes);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Hình Thức Thuê..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                StaticPool.CurrentShiftSetting = tblShift.LoadShiftData();
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Ca Làm Việc..."; });


                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                TblUSer.LoadDataUser(StaticPool.Users);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Người Dùng..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblYard.LoadYardData(StaticPool.Yards);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Sân Tập..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblVehicle.LoadDataVehicle(StaticPool.Vehicles);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Phương Tiện..."; });


                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblTeacher.LoadTeacherData(StaticPool.Teachers);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Giáo Viên..."; });


                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblTeacher_Vehicle.LoadTeacherVehicleData(StaticPool.TeacherVehicles);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Giáo Viên - Phương Tiện..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblPrinterConfig.LoadPrinterConfigData(StaticPool.PrinterConfigs);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Máy In..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblHoliday.LoadHolidayConfig(StaticPool.HolidayConfigs);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Ngày Lễ..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblEvent.GetVehicleInvalidTime(StaticPool.VehicleInvalidTimes);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Thời Gian Đã Thuê Xe..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblTariff.LoadTariffData(StaticPool.Tariffs);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Thời Gian Đã Thuê Xe..."; });

                MultipleThreadTool.InvokeControl(_progressBarWithText, UpdateCurrentProgressStatus);
                tblExamDay.LoadExamDays(StaticPool.ExamDays);
                MultipleThreadTool.InvokeControl(txtProgressDetail, () => { txtProgressDetail.Text = @"Tải Thông Tin Ngày Thi..."; });

                tblEventNumber.CheckNewDay();
                DialogResult = DialogResult.OK;
            });
        }
        #endregion: End Form

        #region: Internal Func
        private void UpdateCurrentProgressStatus()
        {
            _progressBarWithText.Value++;
        }

        private void ConnectToSqlServer()
        {
            if (_sqlConnections is { Length: > 0 })
            {
                var cbSqlServerName = _sqlConnections[0].SQLServerName;
                var cbSqlDatabaseName = _sqlConnections[0].SQLDatabase;
                var cbSqlAuthentication = _sqlConnections[0].SQLAuthentication;
                var txtSqlUserName = _sqlConnections[0].SQLUserName;
                var txtSqlPassword = CryptorEngine.Decrypt(_sqlConnections[0].SQLPassword, true);
                StaticPool.Mdb = new Mdb(cbSqlServerName, cbSqlDatabaseName, cbSqlAuthentication, txtSqlUserName, txtSqlPassword);
            }
            else
            {
                var result = MessageBox.Show(@"Cant Find SQL Connection Setting, Do You Want To Open SQL Connection Config", @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result != DialogResult.Yes) return;
                var p = new Process();
                const string path = @"./ConnectionConfig.exe";
                p.StartInfo.FileName = path;
                p.Start();
                Application.Exit();
            }
        }

        private bool IsConnectSuccess()
        {
            var connection = new SqlConnection(GetConnectStr(_sqlConnections![0].SQLServerName, "master", _sqlConnections[0].SQLAuthentication, _sqlConnections[0].SQLUserName, CryptorEngine.Decrypt(_sqlConnections[0].SQLPassword, true)));
            try
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT name from sys.databases";
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
                GC.Collect();
            }
        }

        private static string GetConnectStr(string serverName, string databaseName, string authentication, string username, string password)
        {
            return authentication == "Window Authentication"
                ? $"data source={serverName};initial Catalog ={databaseName}; Integrated Security=True"
                : $"data source={serverName};initial Catalog ={databaseName}; user id ={username};password={password}";
        }
        #endregion: End Internal Func
    }
}
