using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace Medical.Reports
{
    public partial class ReportTotalMedicineDelivery : DockContent
    {
        public ReportTotalMedicineDelivery()
        {
            InitializeComponent();
        }

        private void ReportTotalMedicineDelivery_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = DateTime.Now;

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportRepository reReps = new ReportRepository();
            if (dateTimeInput1.Value.Year < 1900) throw new Exception("Hãy chọn tháng xem báo cáo");
            var lst = reReps.GetReportTotalMedicineDeliveryByMonth(AppContext.CurrentClinic.Id, dateTimeInput1.Value);
            DS_ReportTotalMedicineDeliveryByMonthBindingSource.DataSource = lst;
            this.reportViewer1.RefreshReport();
        }
    }
}
