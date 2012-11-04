using System;
using System.Windows.Forms;
using Medical.Forms.Interfaces;

namespace Medical.Forms.UI
{
    public partial class ViewDialog : Form
    {
        public ViewDialog()
        {
            InitializeComponent();
        }

        public void AttachToView(IView view)
        {
            view.RequestClose += new EventHandler<System.EventArgs>(ViewRequestClose);
            this.pnlContent.Controls.Clear();
            this.pnlContent.Controls.Add(view.UI);
            this.Height = view.UI.MinimumSize.Height == 0 ? 200 : view.UI.MinimumSize.Height;
            this.Width = view.UI.MinimumSize.Width == 0 ? 300 : view.UI.MinimumSize.Width;
            view.UI.Dock = DockStyle.Fill;
            this.Text = view.Name;
            this.Update();
        }

        void ViewRequestClose(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
