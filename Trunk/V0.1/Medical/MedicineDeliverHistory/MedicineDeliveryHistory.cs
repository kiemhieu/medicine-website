using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        private void cboDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();

        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            this.bdsDeliver.EndEdit();
            var selectedItem = (VMedicineDeliverList) this.bdsDeliver.Current;
            var deliveryDetail = new MedicineDeliverHistory.DeliveryDetail (selectedItem.Id);
            deliveryDetail.ShowDialog();
            UpdateGrid();
        }

        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            this.bdsDeliver.EndEdit();
            var selectedItem = (VMedicineDeliverList)this.bdsDeliver.Current;
            var deliveryDetail = new MedicineDeliverHistory.DeliveryDetail(selectedItem.Id);
            deliveryDetail.ShowDialog();
            UpdateGrid();
        }
    }
}
