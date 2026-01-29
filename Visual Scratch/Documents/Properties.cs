using System;
using System.Windows.Forms;

namespace Visual_Scratch.Documents
{
    public partial class Properties : UserControl
    {
        private readonly Core.Project _project;
        private readonly Action<bool> _setSaved;

        public Properties(Core.Project project, Action<bool> setSaved)
        {
            InitializeComponent();

            _project = project ?? throw new ArgumentNullException(nameof(project));
            _setSaved = setSaved ?? (_ => { });

            kryptonTextBoxAuthor.Text = _project.Info?.Author ?? string.Empty;
            kryptonTextBoxDescription.Text = _project.Info?.Description ?? string.Empty;
            kryptonTextBoxName.Text = _project.Info?.Name ?? string.Empty;
        }

        private void kryptonTextBoxName_TextChanged(object sender, EventArgs e)
        {
            _setSaved(false);
            if (_project?.Info != null)
                _project.Info.Name = kryptonTextBoxName.Text;
        }

        private void kryptonTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            _setSaved(false);
            if (_project?.Info != null)
                _project.Info.Description = kryptonTextBoxDescription.Text;
        }

        private void Properties_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBoxAuthor_TextChanged(object sender, EventArgs e)
        {
            _setSaved(false);
            if (_project?.Info != null)
                _project.Info.Author = kryptonTextBoxAuthor.Text;
        }
    }
}
