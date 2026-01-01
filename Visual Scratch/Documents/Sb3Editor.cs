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

namespace Visual_Scratch
{
    public partial class Sb3Editor : UserControl
    {
        public string Sb3FilePath { get; set; }
        public Sb3Editor(string sb3FilePath)
        {
            InitializeComponent();
            Sb3FilePath = sb3FilePath;
        }
        public static void LoadSb3IntoTurboWarp(WebView2 webView, string sb3Path)
        {
            if (!File.Exists(sb3Path))
            {
                throw new FileNotFoundException("SB3 file not found", sb3Path);
            }
            byte[] sb3Bytes = File.ReadAllBytes(sb3Path);
            string base64 = Convert.ToBase64String(sb3Bytes);
            string js = $@" (async () => {{ const base64 = '{base64}'; const binary = atob(base64); const array = new Uint8Array(binary.length); for (let i = 0; i < binary.length; i++) {{ array[i] = binary.charCodeAt(i); }} const blob = new Blob([array], {{ type: 'application/x.scratch.sb3' }}); const project = await blob.arrayBuffer(); window.vm.loadProject(project); }})(); ";
            webView.CoreWebView2.ExecuteScriptAsync(js);
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private async void Sb3Editor_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.NavigationCompleted += (s, args) =>
            {
                LoadSb3IntoTurboWarp(webView21, Sb3FilePath);
            };
            webView21.CoreWebView2.Navigate("https://editor.scratchbox.dev/editor.html");
        }
    }
}
