using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GeneralTool;
namespace TestReader_VinUni
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogHelper.Logger_SystemInfor("APPLICATION START", Application.StartupPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            bool createdNew;

            Mutex m = new Mutex(true, "KzIScale", out createdNew);

            if (!createdNew)
            {
                // myApp is already running...
                MessageBox.Show("Application is already running!", "Multiple Instances");
                return;
            }


            Application.Run(new frmReadCard());
        }
    }
}
