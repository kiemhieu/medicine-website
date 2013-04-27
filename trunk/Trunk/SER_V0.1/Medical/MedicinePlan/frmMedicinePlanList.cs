using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data;
using Medical.Data.Entities;
using DevComponents.DotNetBar.Controls;
using Medical.Common;

namespace Medical.MedicinePlan
{
    public partial class frmMedicinePlanList : DockContent
    {
        private ClinicRepository repClinic;
        private MedicinePlanRepository repMedicinePlan;
        private MedicinePlanDetailRepository repMedicinePlanDetail;
        public frmMedicinePlanList()
        {

            repClinic = new ClinicRepository();
            repMedicinePlan = new MedicinePlanRepository();
            repMedicinePlanDetail = new MedicinePlanDetailRepository();
            InitializeComponent();

            try
            {
                InitGrid();
                BindData();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void InitGrid()
        {
            var clPlanId = new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Name = "Id" };
            clPlanId.Visible = false;
            grd.Columns.Add(clPlanId);

            var clClinicId = new DataGridViewTextBoxColumn { HeaderText = "Mã phòng khám", DataPropertyName = "ClinicId", Name = "ClinicId" };
            clClinicId.Visible = false;
            grd.Columns.Add(clClinicId);

            var clClinicName = new DataGridViewTextBoxColumn { HeaderText = "Phòng khám", DataPropertyName = "ClinicName", Name = "ClinicName" };
            clClinicName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clClinicName.ReadOnly = true;
            grd.Columns.Add(clClinicName);

            var clMedicineName = new DataGridViewTextBoxColumn { HeaderText = "Năm", DataPropertyName = "Year", Name = "Year" };
            clMedicineName.ReadOnly = true;
            grd.Columns.Add(clMedicineName);

            var clInStock = new DataGridViewTextBoxColumn { HeaderText = "Tháng", DataPropertyName = "Month", Name = "Month" };
            clInStock.ReadOnly = true;
            grd.Columns.Add(clInStock);

            var clLastMonthUsage = new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = "Status", Name = "Status" };
            clLastMonthUsage.ReadOnly = true;
            grd.Columns.Add(clLastMonthUsage);

            var clCurrentMonthUsage = new DataGridViewTextBoxColumn { HeaderText = "Chú ý", DataPropertyName = "Note", Name = "Note" };
            clCurrentMonthUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clCurrentMonthUsage.ReadOnly = true;
            grd.Columns.Add(clCurrentMonthUsage);
        }

        private void BindData()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboMonth.Items.Add(i);
            }

            for (int j = 2012; j <= 2015; j++)
            {
                cboYear.Items.Add(j);
            }

            var listClinic = repClinic.GetAll();
            cbClinic.DataSource = listClinic;

            cboYear.SelectedItem = DateTime.Now.Year;
            cboMonth.SelectedItem = DateTime.Now.Month;
            cboStatus.Items.Add(Constants.Status_Wait);
            cboStatus.Items.Add(Constants.Status_Approped);
            cboStatus.Items.Add(Constants.Status_Reject);

            int index = 0;
            foreach (var clinic in listClinic)
            {
                if (clinic.Name.Equals(AppContext.CurrentClinic.Name, StringComparison.OrdinalIgnoreCase))
                {
                    cbClinic.SelectedIndex = index;
                    break;
                }

                index++;
            }
        }

        private void BindGridViewData()
        {
            int clinicId = 0;
            int year = 0;
            int month = 0;
            string status = string.Empty;
            if (cbClinic.SelectedValue != null)
                int.TryParse(cbClinic.SelectedValue.ToString(), out clinicId);
            if (cboYear.SelectedItem != null)
                int.TryParse(cboYear.SelectedItem.ToString(), out year);
            if (cboMonth.SelectedItem != null)
                int.TryParse(cboMonth.SelectedItem.ToString(), out month);

            if (cboStatus.SelectedItem != null)
            {
                status = cboStatus.SelectedItem.ToString();
            }

            grd.DataSource = repMedicinePlan.FilterPlan(year, month, clinicId, status);
        }

        private void cbClinic_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int planId = int.Parse(grd.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmMedicinePlanDetail frmedit = new frmMedicinePlanDetail(planId);
                frmedit.StartPosition = FormStartPosition.CenterScreen;
                frmedit.ShowDialog();
                if (frmedit.Status != Constants.Status_Delete && !string.IsNullOrEmpty(frmedit.Status))
                    grd.Rows[e.RowIndex].Cells["Status"].Value = frmedit.Status;
                else
                    BindGridViewData();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
