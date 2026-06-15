namespace Visual_Scratch.Forms.Publish
{
    partial class Wizard
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
            this.kryptonButtonBuild = new Krypton.Toolkit.KryptonButton();
            this.kryptonComboBoxPlatforms = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonTextBoxLog = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonProgressBar1 = new Krypton.Toolkit.KryptonProgressBar();
            this.kryptonButtonCancel = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxPlatforms)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonButtonBuild
            // 
            this.kryptonButtonBuild.Location = new System.Drawing.Point(297, 413);
            this.kryptonButtonBuild.Name = "kryptonButtonBuild";
            this.kryptonButtonBuild.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonBuild.TabIndex = 0;
            this.kryptonButtonBuild.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonBuild.Values.Text = "Build";
            this.kryptonButtonBuild.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonComboBoxPlatforms
            // 
            this.kryptonComboBoxPlatforms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBoxPlatforms.DropDownWidth = 151;
            this.kryptonComboBoxPlatforms.Location = new System.Drawing.Point(12, 122);
            this.kryptonComboBoxPlatforms.Name = "kryptonComboBoxPlatforms";
            this.kryptonComboBoxPlatforms.Size = new System.Drawing.Size(151, 22);
            this.kryptonComboBoxPlatforms.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBoxPlatforms.TabIndex = 1;
            this.kryptonComboBoxPlatforms.SelectedIndexChanged += new System.EventHandler(this.kryptonComboBoxPlatforms_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 96);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Platform";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 150);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(77, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Output Path";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(12, 176);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(286, 23);
            this.kryptonTextBox1.TabIndex = 6;
            this.kryptonTextBox1.Text = "kryptonTextBox1";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(304, 176);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(83, 23);
            this.kryptonButton1.TabIndex = 7;
            this.kryptonButton1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButton1.Values.Text = "Browse";
            // 
            // kryptonTextBoxLog
            // 
            this.kryptonTextBoxLog.Location = new System.Drawing.Point(12, 215);
            this.kryptonTextBoxLog.Multiline = true;
            this.kryptonTextBoxLog.Name = "kryptonTextBoxLog";
            this.kryptonTextBoxLog.ReadOnly = true;
            this.kryptonTextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.kryptonTextBoxLog.Size = new System.Drawing.Size(375, 150);
            this.kryptonTextBoxLog.TabIndex = 12;
            // 
            // kryptonProgressBar1
            // 
            this.kryptonProgressBar1.Enabled = false;
            this.kryptonProgressBar1.Location = new System.Drawing.Point(12, 374);
            this.kryptonProgressBar1.Name = "kryptonProgressBar1";
            this.kryptonProgressBar1.Size = new System.Drawing.Size(375, 26);
            this.kryptonProgressBar1.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kryptonProgressBar1.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kryptonProgressBar1.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kryptonProgressBar1.TabIndex = 9;
            this.kryptonProgressBar1.TextBackdropColor = System.Drawing.Color.Empty;
            this.kryptonProgressBar1.TextShadowColor = System.Drawing.Color.Empty;
            this.kryptonProgressBar1.ValueBackColorStyle = Krypton.Toolkit.PaletteColorStyle.GlassTrackingSimple;
            this.kryptonProgressBar1.Values.Text = "";
            // 
            // kryptonButtonCancel
            // 
            this.kryptonButtonCancel.Location = new System.Drawing.Point(201, 413);
            this.kryptonButtonCancel.Name = "kryptonButtonCancel";
            this.kryptonButtonCancel.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonCancel.TabIndex = 11;
            this.kryptonButtonCancel.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kryptonButtonCancel.Values.Text = "Cancel";
            this.kryptonButtonCancel.Click += new System.EventHandler(this.kryptonButtonCancel_Click);
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.kryptonTextBoxLog);
            this.Controls.Add(this.kryptonButtonCancel);
            this.Controls.Add(this.kryptonProgressBar1);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.kryptonComboBoxPlatforms);
            this.Controls.Add(this.kryptonButtonBuild);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.Name = "Wizard";
            this.Text = "Publish";
            this.Load += new System.EventHandler(this.Wizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxPlatforms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonButton kryptonButtonBuild;
        private Krypton.Toolkit.KryptonComboBox kryptonComboBoxPlatforms;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonProgressBar kryptonProgressBar1;
        private Krypton.Toolkit.KryptonButton kryptonButtonCancel;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBoxLog;
    }
}