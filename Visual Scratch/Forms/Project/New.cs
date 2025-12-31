using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using System.IO;

namespace Visual_Scratch.Forms.Project
{
    public partial class New : KryptonForm
    {
        public New()
        {
            InitializeComponent();
        }

        private void New_Load(object sender, EventArgs e)
        {
            // Set default project path to Documents/Visual Scratch/Projects
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string defaultProjectPath = System.IO.Path.Combine(documentsPath, "Visual Scratch", "Projects");
            // Then set the textbox text to that path
            kryptonTextBox4.Text = Path.Combine(defaultProjectPath, "ScratchProject");
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

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Core.Project.CreateProject(kryptonTextBox4.Text, kryptonTextBox1.Text, kryptonTextBox3.Text, kryptonTextBox2.Text);

            this.Close();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
