using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.WareHouses {
    public partial class WareHouseIOHistory : DockContent {
        public WareHouseIOHistory() {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, System.EventArgs e) {
            WareHouseImport dialog = new WareHouseImport();
            dialog.ShowDialog(this);
        }

    }
}
