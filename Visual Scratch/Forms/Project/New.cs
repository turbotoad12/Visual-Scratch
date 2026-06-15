using Krypton.Toolkit;
using System;
using System.IO;
using System.Windows.Forms;

namespace Visual_Scratch.Forms.Project
{
    public partial class New : KryptonForm
    {
        public Core.Project project = new Core.Project();
        public New()
        {
            InitializeComponent();
        }

        private void New_Load(object sender, EventArgs e)
        {
            // Set default project path to Documents/Visual Scratch/Projects
            string defaultProjectPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Visual Scratch", "Projects");
            // Then set the textbox text to that path
            kryptonTextBox4.Text = Path.Combine(defaultProjectPath, "Scratch Project");
        }

        private void kryptonHeaderGroup1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonRichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //browse button
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                // Initialize starting path
                if (!string.IsNullOrWhiteSpace(kryptonTextBox4.Text) && Directory.Exists(kryptonTextBox4.Text))
                {
                    dialog.SelectedPath = kryptonTextBox4.Text;
                }
                else
                {
                    dialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Visual Scratch", "Projects");
                }

                dialog.Description = "Select a folder to create the project in";

                if (dialog.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    kryptonTextBox4.Text = dialog.SelectedPath;
                }
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            project = Core.Project.CreateProject(new DirectoryInfo(kryptonTextBox4.Text), kryptonTextBox1.Text, kryptonTextBox3.Text, kryptonTextBox2.Text);

            this.Close();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
