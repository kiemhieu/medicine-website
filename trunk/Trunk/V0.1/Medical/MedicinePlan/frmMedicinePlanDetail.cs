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
    public partial class frmMedicinePlanDetail : DockContent
    {
        private ClinicRepository repClinic;
        private MedicinePlanRepository repMedicinePlan;
        private MedicinePlanDetailRepository repMedicinePlanDetail;
        public string Status;
        private int PlanId;
        private bool IsOwner;
        public frmMedicinePlanDetail(int planId)
        {
            InitializeComponent();

            repClinic = new ClinicRepository();
            repMedicinePlan = new MedicinePlanRepository();
            repMedicinePlanDetail = new MedicinePlanDetailRepository();
            IsOwner = false;
            this.PlanId = planId;
            try
            {
                BindData();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void InitGrid(bool isReadOnly)
        {
            var clId = new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Name = "Id" };
            clId.Visible = false;
            grd.Columns.Add(clId);

            var clMedicineId = new DataGridViewTextBoxColumn { HeaderText = "Mã thuốc", DataPropertyName = "MedicineId", Name = "MedicineId" };
            clMedicineId.Visible = false;
            grd.Columns.Add(clMedicineId);

            var clMedicineName = new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc", DataPropertyName = "MedicineName", Name = "MedicineName" };
            clMedicineName.ReadOnly = true;
            grd.Columns.Add(clMedicineName);

            var clInStock = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc trong kho", DataPropertyName = "InStock", Name = "InStock" };
            clInStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clInStock.ReadOnly = true;
            grd.Columns.Add(clInStock);

            var clLastMonthUsage = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc dùng tháng trước", DataPropertyName = "LastMonthUsage", Name = "LastMonthUsage" };
            clLastMonthUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clLastMonthUsage.ReadOnly = true;
            grd.Columns.Add(clLastMonthUsage);

            var clCurrentMonthUsage = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc tháng này đã dùng", DataPropertyName = "CurrentMonthUsage", Name = "CurrentMonthUsage" };
            clCurrentMonthUsage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clCurrentMonthUsage.ReadOnly = true;
            grd.Columns.Add(clCurrentMonthUsage);

            var clRequired = new DataGridViewTextBoxColumn { HeaderText = "Số thuốc mong muốn", DataPropertyName = "Required", Name = "Required" };
            clRequired.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clRequired.ReadOnly = !isReadOnly;
            grd.Columns.Add(clRequired);
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

            var item = repMedicinePlan.GetById(PlanId);

            cboStatus.Items.Add(Constants.Status_Wait);
            cboStatus.Items.Add(Constants.Status_Approped);
            cboStatus.Items.Add(Constants.Status_Reject);

            cboYear.SelectedItem = item.Year;
            cboMonth.SelectedItem = item.Month;
            cbClinic.SelectedValue = item.ClinicId;
            cboStatus.SelectedItem = item.Status;
            txtNote.Text = item.Note;

            cbClinic.Enabled = false;
            cboYear.Enabled = false;
            cboMonth.Enabled = false;

            if (item.Status != Constants.Status_Approped)
            {
                if (item.CreatedUser == AppContext.LoggedInUser.Id)
                {
                    if (item.Status != Constants.Status_Approped)
                    {
                        cboYear.Enabled = true;
                        cboMonth.Enabled = true;
                        btnDelete.Enabled = true;
                    }

                    cboStatus.Enabled = false;
                    IsOwner = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }

            InitGrid(IsOwner);
            cbClinic.DataSource = repClinic.GetAll();
            grd.DataSource = repMedicinePlanDetail.GetByPlanId(PlanId);

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Medical.Data.Entities.MedicinePlan medicinePlan = repMedicinePlan.GetById(PlanId);
                medicinePlan.Status = cboStatus.SelectedItem.ToString();
                medicinePlan.Date = DateTime.Now;
                medicinePlan.Note = txtNote.Text;

                if (IsOwner)
                {
                    medicinePlan.Year = int.Parse(cboYear.SelectedItem.ToString());
                    medicinePlan.Month = int.Parse(cboMonth.SelectedItem.ToString());

                    foreach (DataGridViewRow row in grd.Rows)
                    {
                        int id = int.Parse(row.Cells["Id"].Value.ToString());
                        MedicinePlanDetail item = repMedicinePlanDetail.GetById(id);
                        if (row.Cells["Required"].Value != null)
                            item.Required = int.Parse(row.Cells["Required"].Value.ToString());
                        else
                            item.Required = 0;

                        repMedicinePlanDetail.Update(item);
                    }
                }

                repMedicinePlan.Update(medicinePlan);

                Status = medicinePlan.Status;
                MessageBox.Show("Tạo kế hoạch thành công!");
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa kế hoạch này không?", "Xác nhận trước khi xóa", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                repMedicinePlan.Delete(PlanId);
                Status = Constants.Status_Delete;
                this.Close();
            }
        }
    }
}
