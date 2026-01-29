namespace Visual_Scratch.Documents
{
    partial class Properties
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonLabelName = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBoxName = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBoxDescription = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabelDescription = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBoxAuthor = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabelAuthor = new Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // kryptonLabelName
            // 
            this.kryptonLabelName.Location = new System.Drawing.Point(11, 28);
            this.kryptonLabelName.Name = "kryptonLabelName";
            this.kryptonLabelName.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabelName.TabIndex = 0;
            this.kryptonLabelName.Values.Text = "Project Name";
            // 
            // kryptonTextBoxName
            // 
            this.kryptonTextBoxName.Location = new System.Drawing.Point(11, 54);
            this.kryptonTextBoxName.Name = "kryptonTextBoxName";
            this.kryptonTextBoxName.Size = new System.Drawing.Size(217, 23);
            this.kryptonTextBoxName.TabIndex = 1;
            this.kryptonTextBoxName.TextChanged += new System.EventHandler(this.kryptonTextBoxName_TextChanged);
            // 
            // kryptonTextBoxDescription
            // 
            this.kryptonTextBoxDescription.Location = new System.Drawing.Point(11, 109);
            this.kryptonTextBoxDescription.Name = "kryptonTextBoxDescription";
            this.kryptonTextBoxDescription.Size = new System.Drawing.Size(217, 23);
            this.kryptonTextBoxDescription.TabIndex = 3;
            this.kryptonTextBoxDescription.TextChanged += new System.EventHandler(this.kryptonTextBoxDescription_TextChanged);
            // 
            // kryptonLabelDescription
            // 
            this.kryptonLabelDescription.Location = new System.Drawing.Point(11, 83);
            this.kryptonLabelDescription.Name = "kryptonLabelDescription";
            this.kryptonLabelDescription.Size = new System.Drawing.Size(114, 20);
            this.kryptonLabelDescription.TabIndex = 2;
            this.kryptonLabelDescription.Values.Text = "Project Description";
            // 
            // kryptonTextBoxAuthor
            // 
            this.kryptonTextBoxAuthor.Location = new System.Drawing.Point(11, 163);
            this.kryptonTextBoxAuthor.Name = "kryptonTextBoxAuthor";
            this.kryptonTextBoxAuthor.Size = new System.Drawing.Size(217, 23);
            this.kryptonTextBoxAuthor.TabIndex = 5;
            this.kryptonTextBoxAuthor.TextChanged += new System.EventHandler(this.kryptonTextBoxAuthor_TextChanged);
            // 
            // kryptonLabelAuthor
            // 
            this.kryptonLabelAuthor.Location = new System.Drawing.Point(11, 137);
            this.kryptonLabelAuthor.Name = "kryptonLabelAuthor";
            this.kryptonLabelAuthor.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabelAuthor.TabIndex = 4;
            this.kryptonLabelAuthor.Values.Text = "Project Author";
            // 
            // Properties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonTextBoxAuthor);
            this.Controls.Add(this.kryptonLabelAuthor);
            this.Controls.Add(this.kryptonTextBoxDescription);
            this.Controls.Add(this.kryptonLabelDescription);
            this.Controls.Add(this.kryptonTextBoxName);
            this.Controls.Add(this.kryptonLabelName);
            this.Name = "Properties";
            this.Size = new System.Drawing.Size(244, 228);
            this.Load += new System.EventHandler(this.Properties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabelName;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBoxName;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBoxDescription;
        private Krypton.Toolkit.KryptonLabel kryptonLabelDescription;
        private Krypton.Toolkit.KryptonTextBox kryptonTextBoxAuthor;
        private Krypton.Toolkit.KryptonLabel kryptonLabelAuthor;
    }
}
