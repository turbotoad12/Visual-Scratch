using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private static async Task WaitForVmAsync(WebView2 webView, int timeoutMs = 10000, int pollMs = 200)
        {
            if (webView?.CoreWebView2 == null)
            {
                throw new InvalidOperationException("WebView2 is not initialized");
            }

            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                var ready = await webView.CoreWebView2.ExecuteScriptAsync("!!window.vm");
                if (string.Equals(ready, "true", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
                await Task.Delay(pollMs);
            }

            throw new TimeoutException("Scratch/TurboWarp VM not ready");
        }

        private static async Task WaitForDefaultProjectAsync(WebView2 webView, int timeoutMs = 10000, int pollMs = 200)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                // Wait until the built-in default project finishes loading (stage present)
                var ready = await webView.CoreWebView2.ExecuteScriptAsync(
                    "(() => {\n" +
                    "  if (!window.vm || !window.vm.runtime) return 'no';\n" +
                    "  const targets = window.vm.runtime.targets || [];\n" +
                    "  return targets.length > 0 ? 'yes' : 'no';\n" +
                    "})();");

                if (string.Equals(ready, "\"yes\"", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                await Task.Delay(pollMs);
            }

            throw new TimeoutException("Scratch default project did not finish loading");
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
                await WaitForVmAsync(webView);
                await WaitForDefaultProjectAsync(webView);

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
                webView21.CreationProperties = new CoreWebView2CreationProperties
                {
                    UserDataFolder = GetUserDataFolder()
                };

                await webView21.EnsureCoreWebView2Async(null);

                webView21.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
                webView21.CoreWebView2.DownloadStarting += CoreWebView2_DownloadStarting;
                webView21.CoreWebView2.Navigate("https://editor.scratchbox.dev/editor.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize Scratch editor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CoreWebView2_DownloadStarting(object sender, CoreWebView2DownloadStartingEventArgs e)
        {
            try
            {
                var targetPath = Sb3FilePath;
                if (string.IsNullOrWhiteSpace(targetPath))
                {
                    var defaultDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Visual Scratch", "Projects");
                    Directory.CreateDirectory(defaultDir);
                    targetPath = Path.Combine(defaultDir, "project.sb3");
                }

                var dir = Path.GetDirectoryName(targetPath);
                if (!string.IsNullOrEmpty(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                e.ResultFilePath = targetPath;
                e.Handled = true;
            }
            catch
            {
                // If anything goes wrong, let the default download UI handle it.
            }
        }

        private static string GetUserDataFolder()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Visual Scratch",
                "WebView2");

            Directory.CreateDirectory(path);
            return path;
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
                    webView21.CoreWebView2.DownloadStarting -= CoreWebView2_DownloadStarting;
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
