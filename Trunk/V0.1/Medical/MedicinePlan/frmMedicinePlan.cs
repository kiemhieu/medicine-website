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
    public partial class frmMedicinePlan : DockContent
    {
        private ClinicRepository repClinic;
        private MedicinePlanRepository repMedicinePlan;
        private MedicinePlanDetailRepository repMedicinePlanDetail;
        private WareHouseRepository repwh;
        public frmMedicinePlan()
        {

            repClinic = new ClinicRepository();
            repwh = new WareHouseRepository();
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

            cbClinic.DataSource = repClinic.GetAll();

            cboYear.SelectedItem = DateTime.Now.Year;
            cboMonth.SelectedItem = DateTime.Now.Month;
            cbClinic.SelectedValue = AppContext.CurrentClinic.Id;
        }

        private void BindGridViewData()
        {
            int clinicId = 0;
            int year = 0;
            int month = 0;

            if (cbClinic.SelectedValue != null && cboYear.SelectedItem != null && cboMonth.SelectedItem != null && int.TryParse(cbClinic.SelectedValue.ToString(), out clinicId) && int.TryParse(cboYear.SelectedItem.ToString(), out year) && int.TryParse(cboMonth.SelectedItem.ToString(), out month))
            {
                grd.DataSource = repwh.GetByPlan(clinicId, year, month);
            }
            else
            {
                grd.DataSource = new List<MedicinePlanDetail>();
            }
        }

        private WareHouseIO GetWareHousePaperEntity()
        {
            WareHouseIO whIo = new WareHouseIO();
            whIo.Id = 0;
            //whIo.Type = 0;
            return whIo;
        }

        private WareHouseIODetail GetWareHousePaperDetailEntity(int GridIndex)
        {
            if (GridIndex < 0) return new WareHouseIODetail();

            WareHouseIODetail whIoDetail = new WareHouseIODetail();
            whIoDetail.Id = 0;
            whIoDetail.Amount = int.Parse(grd.Rows[0].Cells["Amount"].Value.ToString());
            //whIoDetail.Volumn = int.Parse(grd.Rows[0].Cells["Volumn"].Value.ToString());
            whIoDetail.LotNo = grd.Rows[0].Cells["LotNo"].Value.ToString();
            whIoDetail.MedicineId = int.Parse(grd.Rows[0].Cells["MedicineId"].Value.ToString());
            //whIoDetail.Note = grd.Rows[0].Cells["Note"].Value.ToString();
            return whIoDetail;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data to MedicinePlan
                Medical.Data.Entities.MedicinePlan medicinePlan = new Medical.Data.Entities.MedicinePlan();
                medicinePlan.Year = int.Parse(cboYear.SelectedItem.ToString());
                medicinePlan.Month = int.Parse(cboMonth.SelectedItem.ToString());
                medicinePlan.Status = Constants.Status_Wait;
                medicinePlan.Date = DateTime.Now;
                medicinePlan.Note = txtNote.Text;
                medicinePlan.ClinicId = int.Parse(cbClinic.SelectedValue.ToString());
                repMedicinePlan.Insert(medicinePlan);

                //Insert data to MedicinePlanDetail
                foreach (DataGridViewRow row in grd.Rows)
                {
                    if (ValidateRowData(row))
                    {
                        MedicinePlanDetail item = new MedicinePlanDetail();
                        item.PlanId = medicinePlan.Id;
                        item.MedicineId = int.Parse(row.Cells["MedicineId"].Value.ToString());
                        item.InStock = int.Parse(row.Cells["InStock"].Value.ToString());
                        item.LastMonthUsage = int.Parse(row.Cells["LastMonthUsage"].Value.ToString());
                        item.CurrentMonthUsage = int.Parse(row.Cells["CurrentMonthUsage"].Value.ToString());
                        item.Required = int.Parse(row.Cells["Required"].Value.ToString());
                        repMedicinePlanDetail.Insert(item);
                    }
                }

                MessageBox.Show("Tạo kế hoạch thành công!");
                grd.DataSource = new List<MedicinePlanDetail>();
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidateRowData(DataGridViewRow row)
        {
            int required = 0;
            if (row.Cells["Required"].Value == null || !int.TryParse(row.Cells["Required"].Value.ToString(), out required))
            {
                row.Cells["Required"].Style.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grd.DataSource = null;
        }
        
        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }

        private void cboMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }

        private void cbClinic_SelectedValueChanged(object sender, EventArgs e)
        {
            BindGridViewData();
        }
    }
}
