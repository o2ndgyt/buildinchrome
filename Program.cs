using CefSharp;
using System;
using System.Windows.Forms;

namespace BuildinChrome
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cef.EnableHighDPISupport();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (fn.LoadConfigs())
                Application.Run(new Form1());
        }

    }
}
