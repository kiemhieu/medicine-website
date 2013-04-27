using System.Threading;
using System.Windows.Forms;

namespace Medical.Forms.UI
{
    public partial class ProgressiveDialog : System.Windows.Forms.Form
    {
        private delegate void A();
        public ProgressiveDialog()
        {
            InitializeComponent();
        }

        public void Initialize(int min, int max)
        {
            this.progressBar1.Minimum = min;
            this.progressBar1.Maximum = max;
            this.progressBar1.Value = 0;
            this.label1.Text = string.Empty;
            this.Invoke(new A(this.Update));
        }

        private void Clear()
        {
            this.progressBar1.Value = 0;
            this.label1.Text = string.Empty;
            this.Update();
        }

        public void ShowProgress(IWin32Window owner)
        {
            Clear();
            this.ShowDialog(owner);
        }

        public void CloseProgress()
        {
            this.Close();
        }

        public void CloseProgress(int closeDelay)
        {
            Thread.Sleep(closeDelay);
            this.Close();
        }

        public void UpdateProgress(int value)
        {
            if (value > this.progressBar1.Maximum || value == -1) this.progressBar1.Value = this.progressBar1.Maximum;
            else
            {
                this.progressBar1.Value = value;
            }
            this.Update();
        }

        public void UpdateProgress(string str, int value)
        {
            this.UpdateProgress(value);
            this.UpdateStatus(str);

        }

        public void AddProgress(int value)
        {
            if (value + this.progressBar1.Value > this.progressBar1.Maximum || value == -1) this.progressBar1.Value = this.progressBar1.Maximum;
            else
            {
                this.progressBar1.Value += value;
            }
            this.Update();
        }

        public void AddProgress(string str, int value)
        {
            this.AddProgress(value);
            this.UpdateStatus(str);
        }

        public void UpdateStatus(string str)
        {
            this.label1.Text = str;
            this.Update();
        }

        private static ProgressiveDialog _instance;
        public static ProgressiveDialog Instance
        {
            get { return _instance ?? (_instance = new ProgressiveDialog()); }
        }
    }
}
