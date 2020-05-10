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
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            Cef.EnableHighDPISupport();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (fn.LoadConfigs())
                Application.Run(new Form1());
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
