using CefSharp.WinForms;
using CefSharp;
using System.Windows.Forms;

namespace BuildinChrome
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser browser;

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        
            CefSettings cfsettings = new CefSettings() { UserAgent = fn.oConfigSetup.UserAgent, IgnoreCertificateErrors = true };

            Cef.Initialize(cfsettings);

            BrowserSettings oSet = new BrowserSettings() { ImageLoading = fn.oConfigSetup.Image == 0 ? CefState.Enabled: CefState.Disabled};


            browser = new ChromiumWebBrowser( fn.oConfigSetup.Url)
            {
                Dock = DockStyle.Fill, BrowserSettings=oSet

            };


            toolStripContainer1.ContentPanel.Controls.Add(browser);
            browser.LoadingStateChanged += OnLoadingStateChanged;
        }
        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }
        private void SetIsLoading(bool isLoading)
        {
         Text = isLoading ? "Page is loading..." : "Page loaded.";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            browser.Dispose();
        }
    }
}
