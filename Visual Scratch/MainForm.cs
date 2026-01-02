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
using Visual_Scratch.Core;
using Visual_Scratch.Documents;

namespace Visual_Scratch
{
    public partial class MainForm : KryptonForm
    {
        private KryptonPage homepage = null;
        private Project currentProject = null;
        private bool isProjectLoaded = false;
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
        private void State_Project()
        {
            // Remove all documents
            // Remove all documents
            foreach (KryptonPage page in kryptonDockableWorkspace1.AllPages())
            {
                kryptonDockableWorkspace1.ClosePage(page);
            }

            // Show/Hide ribbon tabs
            kryptonRibbonTabHome.Visible = true;
            kryptonRibbonTabProject.Visible = false;
            kryptonRibbonTabPublish.Visible = true;

            // Configure ribbon for project state
            kryptonRibbon1.SelectedTab = kryptonRibbonTabHome;
        }
        private void State_Home()
        {
            // Remove all documents
            foreach (KryptonPage page in kryptonDockableWorkspace1.AllPages())
            {
                kryptonDockableWorkspace1.ClosePage(page);
            }
            // Add homepage
            kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { homepage });
            // Show/Hide ribbon tabs
            kryptonRibbonTabHome.Visible = true;
            kryptonRibbonTabProject.Visible = false;
            kryptonRibbonTabPublish.Visible = false;
            // Configure ribbon for home state
            kryptonRibbon1.SelectedTab = kryptonRibbonTabHome;
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
            homepage = NewHomePage();
            kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { homepage });
        }
        private void LoadProject(Core.Project project)
        {
            if (project != null)
            {
                // Open the main project file (assumed to be .sb3 for now)
                if (File.Exists(project.Sb3Path))
                {
                    currentProject = project;
                    var sb3Page = NewSb3Editor(project.Sb3Path);
                    State_Project();
                    kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { sb3Page });
                    isProjectLoaded = true;
                }
                else
                {
                    KryptonMessageBox.Show("Main project file not found", "Error");
                    State_Home();
                }
            }
            else
            {
                KryptonMessageBox.Show("Failed to load project: ", "Error");
            }
        }
        // Create a project
        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            // open new form (New.cs)
            var newform = new Forms.Project.New();
            var result = newform.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadProject(newform.project);
            }

        }
        // Open an existing project
        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            // open file dialog to select .vsproj file
            KryptonOpenFileDialog openFileDialog = new KryptonOpenFileDialog();
            openFileDialog.Filter = "Visual Scratch Project (*.vsproj)|*.vsproj";
            openFileDialog.Title = "Open Visual Scratch Project";
            openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Visual Scratch", "Projects");
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadProject(Core.Project.LoadFromFile(openFileDialog.FileName));
            }
        }
        // Open Game Editor
        private void kryptonRibbonGroupButtonGameEditor_Click(object sender, EventArgs e)
        {
            if (isProjectLoaded)
            {
                var sb3Page = NewSb3Editor(currentProject.Sb3Path);
                State_Project();
                kryptonDockingManager1.AddToWorkspace(@"Workspace", new[] { sb3Page });
            }
            else
            {
                KryptonMessageBox.Show("No project is loaded. Please load a project first.", "Error");
            }
        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }
        // Run project in Scratch Everywhere!
        private void kryptonRibbonGroupButtonPublishRun_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        // Run Packaging Wizard
        private void kryptonRibbonGroupButtonPublishPackage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
