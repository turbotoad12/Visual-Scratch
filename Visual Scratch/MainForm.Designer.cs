namespace Visual_Scratch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.kryptonRibbon1 = new Krypton.Ribbon.KryptonRibbon();
            this.kryptonRibbonTabProject = new Krypton.Ribbon.KryptonRibbonTab();
            this.RibbonGroupProject = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.kryptonRibbonGroupButton1 = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton2 = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonDockingManager1 = new Krypton.Docking.KryptonDockingManager();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonDockableWorkspace1 = new Krypton.Docking.KryptonDockableWorkspace();
            this.kryptonRibbonTabPublish = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonTabHome = new Krypton.Ribbon.KryptonRibbonTab();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonRibbon1
            // 
            this.kryptonRibbon1.Name = "kryptonRibbon1";
            this.kryptonRibbon1.RibbonFileAppButton.AppButtonImage = ((System.Drawing.Image)(resources.GetObject("kryptonRibbon1.RibbonFileAppButton.AppButtonImage")));
            this.kryptonRibbon1.RibbonFileAppButton.FormCloseBoxVisible = true;
            this.kryptonRibbon1.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] {
            this.kryptonRibbonTabProject,
            this.kryptonRibbonTabHome,
            this.kryptonRibbonTabPublish});
            this.kryptonRibbon1.SelectedTab = this.kryptonRibbonTabHome;
            this.kryptonRibbon1.Size = new System.Drawing.Size(800, 115);
            this.kryptonRibbon1.TabIndex = 0;
            // 
            // kryptonRibbonTabProject
            // 
            this.kryptonRibbonTabProject.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.RibbonGroupProject});
            this.kryptonRibbonTabProject.Text = "Project";
            // 
            // RibbonGroupProject
            // 
            this.RibbonGroupProject.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1});
            this.RibbonGroupProject.TextLine1 = "Project";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.kryptonRibbonGroupButton1,
            this.kryptonRibbonGroupButton2});
            // 
            // kryptonRibbonGroupButton1
            // 
            this.kryptonRibbonGroupButton1.ImageLarge = global::Visual_Scratch.Properties.Resources.Document_Create_48x48;
            this.kryptonRibbonGroupButton1.ImageSmall = null;
            this.kryptonRibbonGroupButton1.TextLine1 = "New";
            this.kryptonRibbonGroupButton1.ToolTipValues.Description = "This will create a window that you can use to create a Visual Scratch project.";
            this.kryptonRibbonGroupButton1.ToolTipValues.EnableToolTips = true;
            this.kryptonRibbonGroupButton1.ToolTipValues.Heading = "Create A Project";
            this.kryptonRibbonGroupButton1.Click += new System.EventHandler(this.kryptonRibbonGroupButton1_Click);
            // 
            // kryptonRibbonGroupButton2
            // 
            this.kryptonRibbonGroupButton2.ImageLarge = global::Visual_Scratch.Properties.Resources.Document_Open_48x48;
            this.kryptonRibbonGroupButton2.TextLine1 = "Open";
            this.kryptonRibbonGroupButton2.ToolTipValues.Description = "Opens a window where you can load a Visual Scratch Project.";
            this.kryptonRibbonGroupButton2.ToolTipValues.EnableToolTips = true;
            this.kryptonRibbonGroupButton2.ToolTipValues.Heading = "Open A Project";
            this.kryptonRibbonGroupButton2.Click += new System.EventHandler(this.kryptonRibbonGroupButton2_Click);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonManager1.ToolkitStrings.MessageBoxStrings.LessDetails = "L&ess Details...";
            this.kryptonManager1.ToolkitStrings.MessageBoxStrings.MoreDetails = "&More Details...";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonDockableWorkspace1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 115);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 335);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonDockableWorkspace1
            // 
            this.kryptonDockableWorkspace1.ActivePage = null;
            this.kryptonDockableWorkspace1.CompactFlags = ((Krypton.Workspace.CompactFlags)(((Krypton.Workspace.CompactFlags.RemoveEmptyCells | Krypton.Workspace.CompactFlags.RemoveEmptySequences) 
            | Krypton.Workspace.CompactFlags.PromoteLeafs)));
            this.kryptonDockableWorkspace1.ContainerBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this.kryptonDockableWorkspace1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDockableWorkspace1.Location = new System.Drawing.Point(0, 0);
            this.kryptonDockableWorkspace1.Name = "kryptonDockableWorkspace1";
            // 
            // 
            // 
            this.kryptonDockableWorkspace1.Root.UniqueName = "f2ee19ac1ffa44db9ecd3503d04168c6";
            this.kryptonDockableWorkspace1.SeparatorStyle = Krypton.Toolkit.SeparatorStyle.LowProfile;
            this.kryptonDockableWorkspace1.ShowMaximizeButton = false;
            this.kryptonDockableWorkspace1.Size = new System.Drawing.Size(800, 335);
            this.kryptonDockableWorkspace1.SplitterWidth = 5;
            this.kryptonDockableWorkspace1.TabIndex = 0;
            this.kryptonDockableWorkspace1.TabStop = true;
            // 
            // kryptonRibbonTabPublish
            // 
            this.kryptonRibbonTabPublish.KeyTip = "P";
            this.kryptonRibbonTabPublish.Text = "Publish";
            this.kryptonRibbonTabPublish.Visible = false;
            // 
            // kryptonRibbonTabHome
            // 
            this.kryptonRibbonTabHome.Text = "Home";
            this.kryptonRibbonTabHome.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonRibbon1);
            this.FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "MainForm";
            this.Text = "Visual Scratch";
            this.TextExtra = "v0.0.0";
            this.TitleStyle = Krypton.Toolkit.KryptonFormTitleStyle.Modern;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonRibbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableWorkspace1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Ribbon.KryptonRibbon kryptonRibbon1;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Docking.KryptonDockingManager kryptonDockingManager1;
        private Krypton.Ribbon.KryptonRibbonGroup RibbonGroupProject;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Docking.KryptonDockableWorkspace kryptonDockableWorkspace1;
        private Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton2;
        public Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTabProject;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTabPublish;
        private Krypton.Ribbon.KryptonRibbonTab kryptonRibbonTabHome;
    }
}