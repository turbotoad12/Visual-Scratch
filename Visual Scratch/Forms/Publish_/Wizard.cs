using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Visual_Scratch.Platforms;

namespace Visual_Scratch.Forms.Publish
{

    public partial class Wizard : KryptonForm
    {
        public Core.Project PublishProject { get; set; }
        private CancellationTokenSource _cancellationSource = new();
        public CancellationToken CancellationToken => _cancellationSource?.Token ?? CancellationToken.None;
        private readonly System.Windows.Forms.Timer _progressTimer = new System.Windows.Forms.Timer { Interval = 50 };
        private int _progressTarget = 0;
        public Wizard()
        {
            InitializeComponent();
            _progressTimer.Tick += ProgressTimer_Tick;
        }
        private static readonly List<string> SupportedPlatforms = new()
        {
            "Nintendo 3DS"
        };
        // Build
        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (kryptonComboBoxPlatforms.SelectedItem == null)
            {
                KryptonMessageBox.Show("Please select a platform to publish to.", "Error");
                return;
            }
            if (string.IsNullOrEmpty(kryptonTextBox1.Text))
            {
                KryptonMessageBox.Show("Please select an export path.", "Error");
                return;
            }

            IPlatform platform = null;

            // Handle platform selection
            switch (kryptonComboBoxPlatforms.SelectedItem.ToString())
            {
                case "Nintendo 3DS":
                    // Configure build for Nintendo 3DS
                    platform = new Visual_Scratch.Platforms._3DS();
                    // Assign project
                    platform.Project = PublishProject;
                    var projectDir = System.IO.Path.GetDirectoryName(PublishProject?.Sb3Path);
                    var buildDir = System.IO.Path.Combine(projectDir ?? string.Empty, "build", "3DS");
                    if (string.IsNullOrEmpty(projectDir))
                    {
                        KryptonMessageBox.Show("Project path is invalid.", "Error");
                        return;
                    }
                    platform.BuildOptions = new Core.Docker.DockerBuildOptions
                    {
                        Dockerfile = new Core.Docker.DockerFile
                        {
                            Path = System.IO.Path.Combine(buildDir, "docker", "Dockerfile.3ds")
                        },
                        OutputPath = kryptonTextBox1.Text,
                        InputPath = buildDir,
                        OutputProgress = new Progress<string>(AppendLog),
                        ErrorProgress = new Progress<string>(AppendLog)
                    };

                    break;
                default:
                    KryptonMessageBox.Show("Selected platform is not supported.", "Error");
                    return;
            }

            // Start build
            try
            {
                // Enable Progress bar
                kryptonProgressBar1.Enabled = true;
                kryptonProgressBar1.Value = 0;
                var progress = new Progress<int>(v =>
                {
                    _progressTarget = Math.Min(100, Math.Max(0, v));
                    _progressTimer.Start();
                });

                kryptonTextBoxLog.Clear();

                kryptonButton1.Enabled = false;
                kryptonButtonCancel.Enabled = true;

                var inputPath = PublishProject?.Sb3Path;
                var outputPath = kryptonTextBox1.Text;

                await platform.BuildAsync(progress, CancellationToken);

                _progressTarget = 100;
                _progressTimer.Start();
                kryptonProgressBar1.Value = 100;

                KryptonMessageBox.Show("Build completed successfully!", "Success");
                this.Close();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("An error occurred during the build process:\n" + ex.Message, "Error");
            }
            finally
            {
                _progressTimer.Stop();
                kryptonButton1.Enabled = true;
                kryptonButtonCancel.Enabled = true;
            }
        }

        private void Wizard_Load(object sender, EventArgs e)
        {
            // Set Supported platforms
            foreach (var platform in SupportedPlatforms)
            {
                kryptonComboBoxPlatforms.Items.Add(platform);
            }
            // Set default export path
            kryptonTextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void kryptonComboBoxPlatforms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Cancel Button
        private void kryptonButtonCancel_Click(object sender, EventArgs e)
        {
            // Cancel the build process
            _cancellationSource?.Cancel();
            this.Close();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            int current = kryptonProgressBar1.Value;
            if (current == _progressTarget)
            {
                _progressTimer.Stop();
                return;
            }

            int step = Math.Max(1, Math.Abs(_progressTarget - current) / 5);
            if (_progressTarget > current)
            {
                kryptonProgressBar1.Value = Math.Min(100, current + step);
            }
            else
            {
                kryptonProgressBar1.Value = Math.Max(0, current - step);
            }
        }

        private void AppendLog(string line)
        {
            if (string.IsNullOrEmpty(line)) return;

            if (kryptonTextBoxLog.IsDisposed) return;

            kryptonTextBoxLog.AppendText(line + Environment.NewLine);
            kryptonTextBoxLog.SelectionStart = kryptonTextBoxLog.TextLength;
            kryptonTextBoxLog.ScrollToCaret();
        }
    }
}
