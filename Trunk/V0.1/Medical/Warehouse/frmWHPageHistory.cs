using System;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Warehouse
{
    public partial class frmWHPageHistory : DockContent
    {
        public frmWHPageHistory()
        {
            InitializeComponent();
            dateTuNgay.Value = DateTime.Now.Date;
            dateDenNgay.Value = DateTime.Now.Date;
        }
    }
}
