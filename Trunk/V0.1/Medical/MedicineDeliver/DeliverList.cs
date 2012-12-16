using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.MedicineDeliver
{
    public partial class DeliverList : DockContent
    {
        private IClinicRepository _clinicRepo = new ClinicRepository();
        private IVMedicineDeliverRepository vMedicineRepo = new VMedicineDeliverRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliverList"/> class.
        /// </summary>
        public DeliverList()
        {
            InitializeComponent();
            Initialize();
            this.Activated += new EventHandler(DeliverList_Activated);
        }

        private void DeliverList_Activated(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            cboClinic.DataSource = _clinicRepo.GetAll();
            cboDate.Value = DateTime.Today;
            cboStatus.DataSource = new List<Item>(new Item[] { new Item(0, "Tất cả"), new Item(1, "Chưa phát thuốc"), new Item(2, "Đã phát thuốc")});
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        private void UpdateGrid()
        {
            this.UpdateGrid(this.cboDate.Value.Date, Convert.ToInt32(this.cboStatus.SelectedValue));
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        private void UpdateGrid(DateTime date, int type)
        {
            this.bdsDeliver.DataSource = vMedicineRepo.Get(date, type);
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
            // var deliveryRegister = new DeliveryRegister();
            // deliveryRegister.ShowDialog();
        }
    }
}
