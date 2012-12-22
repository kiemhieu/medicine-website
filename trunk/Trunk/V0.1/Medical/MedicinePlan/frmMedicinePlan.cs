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

namespace Medical.MedicinePlan
{
    public partial class frmMedicinePlan : DockContent
    {
        private ClinicRepository repClinic;
        private DefineRepository repDefine;
        private MedicineRepository repMedicine;
        private MedicinePlanRepository repMedicinePlan;
        private MedicinePlanDetailRepository repMedicinePlanDetail;
        private WareHouseRepository repwh;
        private WareHousePaperRepository repwhPaper;
        private WareHousePaperDetailRepository repwhPaperDetail;
        public frmMedicinePlan()
        {

            repClinic = new ClinicRepository();
            repDefine = new DefineRepository();
            repMedicine = new MedicineRepository();
            repwh = new WareHouseRepository();
            repwhPaper = new WareHousePaperRepository();
            repwhPaperDetail = new WareHousePaperDetailRepository();
            repMedicinePlanDetail = new MedicinePlanDetailRepository();
            InitializeComponent();
            repClinic = new ClinicRepository();

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
        }

        private void BindGridViewData()
        {
            int clinicId = 0;
            int year = 0;
            int month = 0;

            grd.Rows.Clear();
            if (cbClinic.SelectedValue != null && cboYear.SelectedItem != null && cboMonth.SelectedItem != null && int.TryParse(cbClinic.SelectedValue.ToString(), out clinicId) && int.TryParse(cboYear.SelectedItem.ToString(), out year) && int.TryParse(cboMonth.SelectedItem.ToString(), out month))
            {
                grd.DataSource = repwh.GetByPlan(clinicId, year, month);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Insert into WareHousePaper
            try
            {
                WareHousePaper whPaper = GetWareHousePaperEntity();
                repwhPaper.Insert(whPaper);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private WareHousePaper GetWareHousePaperEntity()
        {
            WareHousePaper whPaper = new WareHousePaper();
            whPaper.Id = 0;
            whPaper.Type = 0;
            return whPaper;
        }

        private WareHousePaperDetail GetWareHousePaperDetailEntity(int GridIndex)
        {
            if (GridIndex < 0) return new WareHousePaperDetail();

            WareHousePaperDetail whPaperDetail = new WareHousePaperDetail();
            whPaperDetail.Id = 0;
            whPaperDetail.Amount = int.Parse(grd.Rows[0].Cells["Amount"].Value.ToString());
            whPaperDetail.Volumn = int.Parse(grd.Rows[0].Cells["Volumn"].Value.ToString());
            whPaperDetail.LotNo = grd.Rows[0].Cells["LotNo"].Value.ToString();
            whPaperDetail.MedicineId = int.Parse(grd.Rows[0].Cells["MedicineId"].Value.ToString());
            whPaperDetail.Note = grd.Rows[0].Cells["Note"].Value.ToString();
            return whPaperDetail;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data to WareHousePaperDetail
                foreach (DataGridViewRow row in grd.Rows)
                {
                    if (ValidateRowData(row))
                    {
                        WareHousePaperDetail item = new WareHousePaperDetail();
                        item.LotNo = row.Cells["LotNo"].Value.ToString();
                        item.MedicineId = int.Parse(row.Cells["MedicineId"].Value.ToString());
                        item.Volumn = int.Parse(row.Cells["Volumn"].Value.ToString());
                        item.Unit = int.Parse(row.Cells["Unit"].Value.ToString());
                        item.UnitPrice = int.Parse(row.Cells["UnitPrice"].Value.ToString());
                        item.Amount = int.Parse(row.Cells["Amount"].Value.ToString());
                        item.ExpireDate = DateTime.Parse(row.Cells["ExpireDate"].Value.ToString());
                        if (row.Cells["Note"].Value != null)
                            item.Note = row.Cells["Note"].Value.ToString();
                        repwhPaperDetail.Insert(item);
                    }
                }

                MessageBox.Show("Nhập kho thành công!");
                grd.Rows.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int volumn = 0;
            int unitPrice = 0;

            if (grd.Columns[e.ColumnIndex].Name == "MedicineId")
            {
                if (grd.Rows[e.RowIndex].Cells["MedicineId"].Value != null)
                {
                    var medicine = repMedicine.GetById(int.Parse(grd.Rows[e.RowIndex].Cells["MedicineId"].Value.ToString()));
                    grd.Rows[e.RowIndex].Cells["Unit"].Value = medicine.Unit;
                }
            }

            if (grd.Columns[e.ColumnIndex].Name == "Volumn" || grd.Columns[e.ColumnIndex].Name == "UnitPrice")
            {
                if (grd.Rows[e.RowIndex].Cells["Volumn"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["Volumn"].Value.ToString(), out volumn) && grd.Rows[e.RowIndex].Cells["UnitPrice"].Value != null && int.TryParse(grd.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString(), out unitPrice))
                {
                    grd.Rows[e.RowIndex].Cells["Amount"].Value = unitPrice * volumn;
                }
            }
        }

        private bool ValidateRowData(DataGridViewRow row)
        {
            int volumn = 0;
            DateTime dtExpireDate = new DateTime();
            if (row.Cells["LotNo"].Value == null || row.Cells["MedicineId"].Value == null || row.Cells["Volumn"].Value == null || !int.TryParse(row.Cells["Volumn"].Value.ToString(), out volumn)
                || row.Cells["ExpireDate"].Value == null || !DateTime.TryParse(row.Cells["ExpireDate"].Value.ToString(), out dtExpireDate) || row.Cells["Unit"].Value == null)
            {
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grd.DataSource = null;
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
