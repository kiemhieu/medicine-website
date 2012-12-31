using System;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Data.Repositories;
using System.Windows.Forms;

namespace Medical.Warehouse
{
    public partial class frmWHPageHistory : DockContent
    {
        public frmWHPageHistory()
        {
            InitializeComponent();
            dpkFromDate.Value = DateTime.Now.Date;
            dpkToDate.Value = DateTime.Now.Date;
            InitGrid();
        }

        private void InitGrid()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            // add column thuoc                       

            var clId = new DataGridViewTextBoxColumn { HeaderText = "Id", DataPropertyName = "Id", Name = "Id" };
            clId.Visible = false;
            grd.Columns.Add(clId);

            var clType = new DataGridViewTextBoxColumn { HeaderText = "Nhập/Xuất kho", DataPropertyName = "TypeName", Name = "TypeName" };
            grd.Columns.Add(clType);

            var clmInStock = new DataGridViewTextBoxColumn { HeaderText = "Ngày nhập/xuất", DataPropertyName = "Date", Name = "Date" };
            clmInStock.ReadOnly = true;
            clmInStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmInStock);

            var clmNo = new DataGridViewTextBoxColumn { HeaderText = "Mã chứng từ", DataPropertyName = "No", Name = "No" };
            clmNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmNo);

            var clmDeliverer = new DataGridViewTextBoxColumn { HeaderText = "Người giao", DataPropertyName = "Deliverer", Name = "Deliverer" };
            clmDeliverer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmDeliverer);

            var clmNote = new DataGridViewTextBoxColumn { HeaderText = "Chú thích", DataPropertyName = "Note", Name = "Note" };
            clmNote.ReadOnly = true;
            clmNote.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grd.Columns.Add(clmNote);
        }

        private void grd_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int id = int.Parse(grd.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            string type = grd.Rows[e.RowIndex].Cells["TypeName"].Value.ToString();
            if (type.Equals("Nhập kho", StringComparison.OrdinalIgnoreCase))
            {
                frmImportDetail frmImportDetail = new frmImportDetail(id);
                frmImportDetail.StartPosition = FormStartPosition.CenterParent;
                frmImportDetail.ShowDialog();
            }
            else
            {
                frmExportDetail frmExportDetail = new frmExportDetail(id);
                frmExportDetail.StartPosition = FormStartPosition.CenterParent;
                frmExportDetail.ShowDialog();
                if (frmExportDetail.Status)
                {
                    LoadData();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            WareHousePaperRepository whPaperRepository = new WareHousePaperRepository();
            int type = cbTypeWHPage.Text.Equals("Nhập kho", StringComparison.OrdinalIgnoreCase) ? 0 : (cbTypeWHPage.Text.Equals("Xuất kho", StringComparison.OrdinalIgnoreCase) ? 1 : -1);
            grd.DataSource = whPaperRepository.Search(type, dpkFromDate.Value, dpkToDate.Value);
        }
    }
}
