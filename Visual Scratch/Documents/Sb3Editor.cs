using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace Visual_Scratch
{
    public partial class Sb3Editor : UserControl
    {
        public string Sb3FilePath { get; set; }
        private bool _isProjectLoaded = false;

        public Sb3Editor(string sb3FilePath)
        {
            InitializeComponent();
            Sb3FilePath = sb3FilePath;
        }

        public static async Task LoadSb3IntoTurboWarpAsync(WebView2 webView, string sb3Path)
        {
            if (webView?.CoreWebView2 == null)
            {
                throw new InvalidOperationException("WebView2 is not initialized");
            }

            if (!File.Exists(sb3Path))
            {
                throw new FileNotFoundException("SB3 file not found", sb3Path);
            }

            try
            {
                byte[] sb3Bytes = File.ReadAllBytes(sb3Path);
                string base64 = Convert.ToBase64String(sb3Bytes);
                string js = $@"
                    (async () => {{
                        const base64 = '{base64}';
                        const binary = atob(base64);
                        const array = new Uint8Array(binary.length);
                        for (let i = 0; i < binary.length; i++) {{
                            array[i] = binary.charCodeAt(i);
                        }}
                        const blob = new Blob([array], {{ type: 'application/x.scratch.sb3' }});
                        const project = await blob.arrayBuffer();
                        await window.vm.loadProject(project);
                    }})();
                ";
                await webView.CoreWebView2.ExecuteScriptAsync(js);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to load SB3 project: {ex.Message}", ex);
            }
        }

        private async void Sb3Editor_Load(object sender, EventArgs e)
        {
            try
            {
                await webView21.EnsureCoreWebView2Async(null);
                
                webView21.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView21.CoreWebView2.Navigate("https://editor.scratchbox.dev/editor.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Scratch editor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (_isProjectLoaded || !e.IsSuccess)
            {
                return;
            }

            try
            {
                _isProjectLoaded = true;
                await LoadSb3IntoTurboWarpAsync(webView21, Sb3FilePath);
            }
            catch (Exception ex)
            {
                _isProjectLoaded = false;
                MessageBox.Show($"Failed to load project: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (webView21?.CoreWebView2 != null)
                {
                    webView21.CoreWebView2.NavigationCompleted -= CoreWebView2_NavigationCompleted;
                }
                
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
