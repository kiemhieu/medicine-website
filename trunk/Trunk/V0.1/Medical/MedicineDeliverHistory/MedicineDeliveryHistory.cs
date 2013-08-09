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
using Medical.Data.Entities.Views;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.MedicineDeliverHistory
{
    public partial class MedicineDeliveryHistory : DockContent
    {
        private IClinicRepository _clinicRepo = new ClinicRepository();
        private IVMedicineDeliverRepository vMedicineRepo = new VMedicineDeliverRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicineDeliveryHistory"/> class.
        /// </summary>
        public MedicineDeliveryHistory()
        {
            InitializeComponent();
            Initialize();
            this.Activated += new EventHandler(DeliverListActivated);
        }

        /// <summary>
        /// Delivers the list activated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeliverListActivated(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            this.cboClinic.DataSource = _clinicRepo.GetAll();
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;
            cboDate.Value = DateTime.Today;
            // cboStatus.DataSource = new List<Item>(new Item[] {new Item(2, "Đã phát thuốc")});
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        private void UpdateGrid()
        {
            this.UpdateGrid(this.cboDate.Value.Date, 1);
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        private void UpdateGrid(DateTime date, int type)
        {
            var list = vMedicineRepo.Get(date, type);
            for (var i = 0; i < list.Count;i++ )
            {
                list[i].No = i + 1;
            }
            this.bdsDeliver.DataSource = list;
            this.bdsDeliver.ResetBindings(true);
            this.dataGridViewX1.Refresh();
            this.dataGridViewX1.ResetBindings();
        }

        /// <summary>
        /// Cboes the date value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CboDateValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Datas the grid view x1 double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1DoubleClick(object sender, EventArgs e)
        {
            this.bdsDeliver.EndEdit();
            var selectedItem = (VMedicineDeliverList)this.bdsDeliver.Current;
            var deliveryDetail = new MedicineDeliverHistory.DeliveryDetail(selectedItem.Id);
            deliveryDetail.ShowDialog();
            UpdateGrid();
        }

        /// <summary>
        /// Datas the grid view x1 data binding complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewBindingCompleteEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }
    }
}
