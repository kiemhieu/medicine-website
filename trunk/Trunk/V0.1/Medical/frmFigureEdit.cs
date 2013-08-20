using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using Medical.Forms.Implements;
using Medical.Forms.UI;

namespace Medical
{
    public partial class FrmFigureEdit : Form
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

        public FrmFigureEdit()
        {

            InitializeComponent();
            if (IdFigureEdit <= 0)
            {
                CleanItems();
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

        private void BtnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                var result = MessageDialog.Instance.ShowMessage(this, "Q011");
                if (result == DialogResult.No) return;

                if (_figure.Id == 0)
                {
                    figureRepository.Insert(_figure);
                    return;
                }
                    
                figureRepository.Update(_figure);
            }
            catch (Exception ex)
            {
                // MessageDialog.Instance.ShowMessage(this, "ERR0002", ex.Message);
                ExceptionHandler.Instance.HandlerException(ex);
            }
            finally
            {
                this.Close();
            }
        }

        private void BtnCancleClick(object sender, EventArgs e)
        {
            FrmFigureEdit.IdFigureEdit = -1;
            this.Close();
        }

        private void CleanItems()
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

        private void GrdDetailCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var figureDetail = (FigureDetail)this.bdsFigureDetail.Current;

            if (figureDetail == null) return;

            //if (e.ColumnIndex == 2 || e.ColumnIndex == 3) figureDetail.Calculate();
            //figureDetail.Validate();
            if (CheckDuplicate(figureDetail.MedicineId)) figureDetail.AddError("MedicineId", "Thuốc đã tồn tại");
        }

        private void BdsFigureDetailListChanged(object sender, ListChangedEventArgs e)
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

        private void GrdDetailDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void FrmFigureEditActivated(object sender, EventArgs e)
        {

        }
    }
}
