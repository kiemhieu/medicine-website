using System.Windows.Forms;

namespace Medical.Forms.UI
{
    public class ProgressiveDialogWraper
    {
        private delegate void A(IWin32Window owner);

        private static readonly ProgressiveDialog Dialog = new ProgressiveDialog();

        public Form Parent { get; set; }
        public ProgressiveDialogWraper()
        {
        }

        private void OnShowing(IWin32Window owner)
        {
            Dialog.Show(owner);
        }

        public void ShowProgressiveDialog()
        {
            var a = new A(OnShowing);
            a.Invoke(this.Parent);
            //this.Parent.Invoke(a, this.Parent);
        }

        public void Close()
        {
            Dialog.Close();
        }

        private static ProgressiveDialogWraper _instance;
        public static ProgressiveDialogWraper Instance
        {
            get { return _instance ?? (_instance = new ProgressiveDialogWraper()); }
        }
    }
}
