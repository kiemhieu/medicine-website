﻿using System;
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
    public partial class ReportWareHouseIOByMonth : DockContent
    {
        public ReportWareHouseIOByMonth()
        {
            InitializeComponent();
        }

        private void ReportWareHouseIOByMonth_Load(object sender, EventArgs e)
        {
            this.dateTimeInput1.Value = DateTime.Now;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportRepository reReps = new ReportRepository();
            if (dateTimeInput1.Value.Year < 1900)
            {
                errorProvider1.SetError(dateTimeInput1, "Hãy chọn tháng xem báo cáo");
                return;
            }
            var lst = reReps.GetReportMedicineIOByMonth(AppContext.CurrentClinic.Id, dateTimeInput1.Value);
            for (var i = 0; i < lst.Count; i++)
            {
                lst[i].STT = i + 1;
            }
            DS_ReportMedicineIOByMonthBindingSource.DataSource = lst;
            this.reportViewer1.RefreshReport();
        }
    }
}
