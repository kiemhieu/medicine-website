using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical.WareHouseMonthlyReport {
    public partial class WareHouseMonthlyReportDetail : Form {
        public WareHouseMonthlyReportDetail() {
            InitializeComponent();
        }

        private void WareHouseMonthlyReportDetail_Load(object sender, EventArgs e) {

            this.reportViewer1.RefreshReport();
        }
    }
}
