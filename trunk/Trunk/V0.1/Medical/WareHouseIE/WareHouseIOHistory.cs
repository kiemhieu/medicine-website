using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using System;
using Medical.Data.Entities;
using System.Collections.Generic;

namespace Medical.WareHouseIE
{
    public partial class WareHouseIOHistory : DockContent
    {
        private readonly WareHouseIORepository repwhIo = new WareHouseIORepository();
        private readonly ClinicRepository repClinic = new ClinicRepository();
        public WareHouseIOHistory()
        {
            InitializeComponent();
            BindClinic();
        }

        private void btnImport_Click(object sender, System.EventArgs e)
        {
            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(txtFrom.Text))
                from = DateTime.Parse(txtFrom.Text);
            if (!string.IsNullOrEmpty(txtTo.Text))
                to = DateTime.Parse(txtTo.Text);
            int clinicId = int.Parse(cboClinic.SelectedValue.ToString());
            bdsWareHouseIO.DataSource = repwhIo.Search("0", clinicId, from, to);
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(txtFrom.Text))
                from = DateTime.Parse(txtFrom.Text);
            if (!string.IsNullOrEmpty(txtTo.Text))
                to = DateTime.Parse(txtTo.Text);
            int clinicId = int.Parse(cboClinic.SelectedValue.ToString());
            bdsWareHouseIO.DataSource = repwhIo.Search(string.Empty, clinicId, from, to);
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            DateTime from = DateTime.MinValue;
            DateTime to = DateTime.MaxValue;
            if (!string.IsNullOrEmpty(txtFrom.Text))
                from = DateTime.Parse(txtFrom.Text);
            if (!string.IsNullOrEmpty(txtTo.Text))
                to = DateTime.Parse(txtTo.Text);
            int clinicId = int.Parse(cboClinic.SelectedValue.ToString());
            bdsWareHouseIO.DataSource = repwhIo.Search("1", clinicId, from, to);
        }

        private void BindClinic()
        {
            bdsClinic.DataSource = repClinic.GetAll();
        }        

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var list = bdsWareHouseIO.DataSource as List<WareHouseIO>;
            WareHouseIEDetail frm = new WareHouseIEDetail(list[e.RowIndex].Id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
