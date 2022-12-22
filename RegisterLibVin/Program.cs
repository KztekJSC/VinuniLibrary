using RegisterLibVin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_LibVinUni
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
            // Thêm Log

            //if (new frmLogin().ShowDialog() == DialogResult.OK)
            //{
            //    //if (new frmLoading().ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new frmHome());

            //    }
            //}
            Application.Run(new frmLogin());
        }
    }
}
