using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.WareHouses {
    public partial class WareHouseIOHistory : DockContent
    {

        private IWareHouseIORepository warehouseIORepo = new WareHouseIORepository();
        public WareHouseIOHistory() {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, System.EventArgs e) {
            WareHouseImport dialog = new WareHouseImport();
            dialog.ShowDialog(this);
        }

        private void btnSearch_Click(object sender, System.EventArgs e) {
            warehouseIORepo.GetAll(txtFrom.ValueObject, txtTo.ValueObject, )
        }

        private void dateTimeInput2_Click(object sender, System.EventArgs e) {

        }

    }
}
