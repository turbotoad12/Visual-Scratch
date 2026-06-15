namespace Visual_Scratch.Forms.Project
{
    partial class New
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
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonHeaderGroup1 = new Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBox2 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox3 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBox4 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(12, 153);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(285, 23);
            this.kryptonTextBox1.TabIndex = 1;
            this.kryptonTextBox1.Text = "ScratchProject";
            this.kryptonTextBox1.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.CollapseTarget = Krypton.Toolkit.HeaderGroupCollapsedTarget.CollapsedToSecondary;
            this.kryptonHeaderGroup1.GroupBorderStyle = Krypton.Toolkit.PaletteBorderStyle.ButtonNavigatorOverflow;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(12, 12);
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(345, 116);
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.LongText.MultiLine = Krypton.Toolkit.InheritBool.True;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.TopLeft;
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.ShortText.MultiLine = Krypton.Toolkit.InheritBool.True;
            this.kryptonHeaderGroup1.TabIndex = 3;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Create a Project";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = global::Visual_Scratch.Properties.Resources.Visual_Scratch_Logo_32x32;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Descriptionhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh";
            this.kryptonHeaderGroup1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonHeaderGroup1_Paint);
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(0, -1);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(345, 81);
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "Choose a name, author, and description, then select your .sb3 file. Visual Scratc" +
    "h will set up everything you need so you can open, edit, and manage your Scratch" +
    " project in a streamlined workspace.";
            this.kryptonRichTextBox1.TextChanged += new System.EventHandler(this.kryptonRichTextBox1_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(112, 134);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Project Name";
            this.kryptonLabel1.Click += new System.EventHandler(this.kryptonLabel1_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(99, 179);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(110, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Project Discription";
            this.kryptonLabel2.Click += new System.EventHandler(this.kryptonLabel2_Click);
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Location = new System.Drawing.Point(12, 198);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(285, 23);
            this.kryptonTextBox2.TabIndex = 6;
            this.kryptonTextBox2.Text = "A cool scratch project.";
            this.kryptonTextBox2.TextChanged += new System.EventHandler(this.kryptonTextBox2_TextChanged);
            // 
            // kryptonTextBox3
            // 
            this.kryptonTextBox3.Location = new System.Drawing.Point(12, 243);
            this.kryptonTextBox3.Name = "kryptonTextBox3";
            this.kryptonTextBox3.Size = new System.Drawing.Size(285, 23);
            this.kryptonTextBox3.TabIndex = 8;
            this.kryptonTextBox3.Text = "User";
            this.kryptonTextBox3.TextChanged += new System.EventHandler(this.kryptonTextBox3_TextChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(137, 270);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(35, 20);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Path";
            // 
            // kryptonTextBox4
            // 
            this.kryptonTextBox4.Location = new System.Drawing.Point(12, 289);
            this.kryptonTextBox4.Name = "kryptonTextBox4";
            this.kryptonTextBox4.Size = new System.Drawing.Size(285, 23);
            this.kryptonTextBox4.TabIndex = 10;
            this.kryptonTextBox4.Text = "kryptonTextBox4";
            this.kryptonTextBox4.TextChanged += new System.EventHandler(this.kryptonTextBox4_TextChanged);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(303, 289);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(54, 23);
            this.kryptonButton1.TabIndex = 12;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Browse";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(110, 224);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel3.TabIndex = 13;
            this.kryptonLabel3.Values.Text = "Project Author";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonButton2.Location = new System.Drawing.Point(171, 374);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton2.TabIndex = 14;
            this.kryptonButton2.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton2.Values.Text = "OK";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonButton3.Location = new System.Drawing.Point(267, 374);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton3.TabIndex = 15;
            this.kryptonButton3.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton3.Values.Text = "Cancel";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 411);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonTextBox4);
            this.Controls.Add(this.kryptonTextBox3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonTextBox2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.kryptonTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New";
            this.Text = " New Project";
            this.Load += new System.EventHandler(this.New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        /// <summary>
        /// Name Textbox
        /// </summary>
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        /// <summary>
        /// Discription Textbox
        /// </summary>
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
        /// <summary>
        /// Author TextBox
        /// </summary>
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        /// <summary>
        /// Path TextBox
        /// </summary>
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox4;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
    }
}