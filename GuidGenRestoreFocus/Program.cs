using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidGen
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

            //IntPtr handle = WindowsApiImports.GetForegroundWindow();
            //MessageBox.Show(handle.ToString());

            Application.Run(new GuidGenMain());
        }
    }
}
