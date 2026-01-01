using Krypton.Docking;
using Krypton.Navigator;
using Krypton.Ribbon;
using Krypton.Toolkit;
using Krypton.Workspace;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Visual_Scratch.Documents;

namespace Visual_Scratch
{
    public partial class MainForm : KryptonForm
    {

        public MainForm()
        {
            InitializeComponent();
        }
        private KryptonPage NewSb3Editor(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            KryptonPage page = NewPage(name, 0, new Sb3Editor(path));

            // Document pages cannot be docked or auto hidden
            page.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);

            return page;
        }
        private KryptonPage NewHomePage()
        {
            KryptonPage page = NewPage("Home", 0, new Home());

            // Document pages cannot be docked or auto hidden
            page.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);

            return page;
        }

        private KryptonPage NewPage(string name, int image, Control content, Size? autoHiddenSizeHint = null)
        {
            // Create new page with title and image
            var p = new KryptonPage
            {
                Text = name,
                TextTitle = name,
                TextDescription = name
            };

            // Add the control for display inside the page
            content.Dock = DockStyle.Fill;
            p.Controls.Add(content);

            if (autoHiddenSizeHint.HasValue)
            {
                p.AutoHiddenSlideSize = autoHiddenSizeHint.Value;
            }
            return p;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup docking functionality
            KryptonDockingWorkspace w = kryptonDockingManager1.ManageWorkspace(kryptonDockableWorkspace1);
            kryptonDockingManager1.ManageControl(kryptonPanel1, w);
            kryptonDockingManager1.ManageFloating(this);

            // How to add document:  kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { NewDocument(), NewDocument() });
            // just if you need to show someone doucment: kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { NewDocument("C:/Users/jones/Downloads/Project.sb3") });
            kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { NewHomePage() });
        }
        // Create a project
        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            // open new form (New.cs)
            var newform = new Forms.Project.New();
            var result = newform.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Open project here.
            }

        }
    }
}
