using System.IO;
using System.Windows.Forms;

namespace Medical.Forms.UI
{
    public partial class LogViewerDialog : Form
    {
        private readonly string _path = Application.StartupPath + "\\Log";
        public LogViewerDialog()
        {
            InitializeComponent();
        }

        private void LogViewerDialogLoad(object sender, System.EventArgs e)
        {
            var info = new DirectoryInfo(_path);
            if (!info.Exists) return;
            FileInfo[] files = info.GetFiles("*.log");
            lsbLogFiles.DataSource = files;
            lsbLogFiles.ValueMember = "FullName";
            lsbLogFiles.DisplayMember = "Name";
        }

        private void LsbLogFilesSelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.rtbContent.Clear();
            var fileInfo = (FileInfo) lsbLogFiles.SelectedItem;
            if (!fileInfo.Exists)
            {
                rtbContent.Text = "File not found";
                return;
            }


            FileStream fileStream = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var reader = new StreamReader(fileStream))
            {
                rtbContent.Text = reader.ReadToEnd();
            }
        }
    }
}
