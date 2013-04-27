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
namespace Medical.Test
{
    public partial class frmFigureEdit : Form
    {

        private FigureRepository figureRepository = new FigureRepository();
        private FigureDetailRepository figureDetailRepository = new FigureDetailRepository();
        private MedicineRepository _medicineRepo = new MedicineRepository();
        private Figure _figure;
        private List<FigureDetail> _figureDetailList;
        public static int IdFigureEdit;

        /// <summary>
        /// Initializes the specified prescription.
        /// </summary>
        /// <param name="prescription">The prescription.</param>
        private void Initialize(Figure figure)
        {
            this.bdsFigure.DataSource = figure;
            this.bdsFigureDetail.DataSource = figure.FigureDetail;

        }

        public frmFigureEdit()
        {

            InitializeComponent();
            if (IdFigureEdit <= 0)
            {
                cleanItems();
                ReadOnlyItems(false);
                var medicines = _medicineRepo.GetAll();
                medicines.Insert(0, new Medicine() { Id = 0, Name = "..." });
                this.bdsMedicine.DataSource = medicines;

                this._figure = new Figure
                {
                    Id = 0,
                    Name = "",
                    ClinicId= AppContext.CurrentClinic.Id,
                    LastUpdatedDate = DateTime.Now.Date,
                    Description = "",
                    LastUpdatedUser = AppContext.LoggedInUser.Id,
                    Version = 0
                };

                this._figureDetailList = new List<FigureDetail>();

                this._figure.FigureDetail = this._figureDetailList;
            }
            else
            {
                _figure = figureRepository.GetById(IdFigureEdit);
                FillToItemByID();
                ReadOnlyItems(false);
            }
            Initialize(_figure);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn cập nhật không?", "Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                // Figure ent = FillToEntity();
                if (_figure.Id == 0) figureRepository.Insert(_figure);
                else figureRepository.Update(_figure);

                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            frmFigureEdit.IdFigureEdit = -1;
            this.Close();
        }

        private void cleanItems()
        {
            this.txtGhiChu.Text = "";
            this.txtFigureName.Text = "";
        }
        private void ReadOnlyItems(bool isTrue)
        {
            this.txtGhiChu.ReadOnly = isTrue;
            this.txtFigureName.ReadOnly = isTrue;
        }
        private Figure FillToEntity()
        {
            Figure ent;
            if (IdFigureEdit <= 0)
            {
                ent = new Figure();

            }
            else
            {
                ent = figureRepository.GetById(IdFigureEdit);
            }

            ent.Name = txtFigureName.Text.Trim();
            ent.Description = txtGhiChu.Text.Trim();

            return ent;
        }


        private void FillToItemByID()
        {
            if (IdFigureEdit <= 0)
                return;
            Figure ent = figureRepository.GetById(IdFigureEdit);
            bdsFigure.DataSource = ent;


            var medicines = _medicineRepo.GetAll();
            medicines.Insert(0, new Medicine() { Id = 0, Name = "..." });

            bdsMedicine.DataSource = medicines;
            bdsFigureDetail.DataSource = ent.FigureDetail;
        }

        private void grdDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var figureDetail = (FigureDetail)this.bdsFigureDetail.Current;

            if (figureDetail == null) return;

            //if (e.ColumnIndex == 2 || e.ColumnIndex == 3) figureDetail.Calculate();
            //figureDetail.Validate();
            if (CheckDuplicate(figureDetail.MedicineId)) figureDetail.AddError("MedicineId", "Thuốc đã tồn tại");
        }

        private void bdsFigureDetail_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                var source = (BindingSource)sender;
                var item = source.List[e.NewIndex] as FigureDetail;
                //item.MedicineId = source.List.Count;
                //item.Day = this.Day;
            }
        }
        /// <summary>
        /// Checks the duplicate.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private bool CheckDuplicate(int id)
        {
            //var figureDetalList = (List<FigureDetail>)this.bdsFigureDetail.List;
            //if (figureDetalList == null || figureDetalList.Count == 0) return true;
            //if (figureDetalList.Count(x => x.MedicineId == id) > 1) return false;
            return true;
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

        private void frmFigureEdit_Activated(object sender, EventArgs e)
        {

        }

    }
}
