using Medical.Forms.UI;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Forms.MockTest.Test02
{
    public partial class Test02 : DockContent
    {
        public Test02()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //this.RequestViewDoAction("DisableMove");
        }

        
    }
}
