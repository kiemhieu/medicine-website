using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using DevComponents.DotNetBar.Controls;
namespace Medical.Test
{
    public partial class frmFigure : DockContent
    {
        public int IdFigure;
        public static int IdMedicine = -1;
        private FigureRepository figureRepository = new FigureRepository();
        private FigureDetailRepository _figureDetailResp = new FigureDetailRepository();
        public frmFigure()
        {
            InitializeComponent();
           
            FillToGrid();

        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex == -1) return;
            lblID.Text = grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
            FillToGridDetail(int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString()));
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null)
            {
                IdFigure = 0;
            }
                
            else
            {
                IdFigure = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            }
            lblID.Text = IdFigure.ToString();

            frmFigureEdit.IdFigureEdit = IdFigure;
            frmFigureEdit frmEdit = new frmFigureEdit();
            frmEdit.ShowDialog();
            FillToGrid();
        }
        private void FillToGrid()
        {
           
            bdsFigure.DataSource = figureRepository.GetAll();
           
            bdsFigure.ResetCurrentItem();
          
            this.grd.Refresh();
            this.grd.Parent.Refresh();
            if (grd.Rows.Count == 0)
            { }
            else
            {

                grd.Rows[0].Selected = true;
                lblID.Text = grd.Rows[0].Cells["idDataGridViewTextBoxColumn"].Value.ToString();
                

            }
        }

        private bool _isSkipUpdatingFigure = false;
        private void FillToGridDetail(int figureId)
        {
            var figureDetails = this._figureDetailResp.GetByFigure(figureId);
            grdDetail.DataSource = this._figureDetailResp.GetByFigure(figureId);
            
            //foreach (var figureDetail in figureDetails)
            //{
            //    var prescriptionDetail = new PrescriptionDetail()
            //    {
            //        FigureDetailId = figureDetail.Id,
            //        MedicineId = figureDetail.MedicineId,
            //        //Medicine = figureDetail.Medicine,
            //        VolumnPerDay = figureDetail.Volumn,
            //        Day = this.Day,
            //        Amount = DefaultVolumn * figureDetail.Volumn,
            //        Version = 0
            //    };
            //    _prescriptionDetailList.Insert(0, prescriptionDetail);
            //}

            //this.bdsPrescriptionDetail.DataSource = _prescriptionDetailList;
            //// this.bdsPrescriptionDetail.EndEdit();
            //ReupdateNo();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmFigureEdit frmedit = new frmFigureEdit();
            frmFigureEdit.IdFigureEdit = 0;
            frmedit.ShowDialog();
            FillToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn phác đồ thuốc cần xóa!");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa phác đồ này không?", "Xóa phác đồ thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                figureRepository.Delete(int.Parse(lblID.Text.Trim()));
            }
            FillToGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn phác đồ cần sửa!");
                return;
            }
            frmFigureEdit.IdFigureEdit = int.Parse(lblID.Text);
            frmFigureEdit frmedit = new frmFigureEdit();
            frmedit.ShowDialog();
            FillToGrid();

        }

        private void grdDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                // TODO: Set error and warning icon and good icon follow the quantity remain on stock
                //gridView.Rows[r.Index].Cells[0].Value = global::Medical.Properties.Resources.accept;
            }
        }
    }
}
