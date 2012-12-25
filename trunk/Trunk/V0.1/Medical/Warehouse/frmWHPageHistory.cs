using System;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;

namespace Medical.Warehouse
{
    public partial class frmWHPageHistory : DockContent
    {
        public frmWHPageHistory()
        {
            InitializeComponent();
            dpkFromDate.Value = DateTime.Now.Date;
            dpkToDate.Value = DateTime.Now.Date;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            WareHousePaperRepository whPaperRepository = new WareHousePaperRepository();
            int type = cbTypeWHPage.Text.Equals("Nhập kho", StringComparison.OrdinalIgnoreCase) ? 0 : (cbTypeWHPage.Text.Equals("Xuất kho", StringComparison.OrdinalIgnoreCase) ? 1 : -1);
            grd.DataSource = whPaperRepository.Search(type, dpkFromDate.Value, dpkToDate.Value);
        }
    }
}
