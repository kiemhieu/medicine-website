using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;
using Medical.Forms.UI;

namespace Medical.MedicineDeliver
{
    public partial class DeliverList : DockContent
    {
        private IClinicRepository _clinicRepo = new ClinicRepository();
        private IVMedicineDeliverRepository vMedicineRepo = new VMedicineDeliverRepository();
        private IMedicineDeliveryRepository _medicineDeliveryRepo = new MedicineDeliveryRepository();
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
            cboClinic.DataSource = new List<Medical.Data.Entities.Clinic> { AppContext.CurrentClinic};
            cboDate.Value = DateTime.Today;
            cboStatus.DataSource = new List<Item>(new Item[] { new Item(0, "Tất cả"), new Item(1, "Chưa phát thuốc"), new Item(2, "Đã phát thuốc") });
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
            var list = vMedicineRepo.Get(date, type);
            for (var i = 0; i < list.Count; i++)
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
            if (bdsDeliver.Current == null)
            {
                DialogResult dr = MessageBox.Show("Bạn phải chọn đơn thuốc cần phát?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            this.bdsDeliver.EndEdit();
            var selectedItem = (VMedicineDeliverList)this.bdsDeliver.Current;
            if (selectedItem == null)
            {
                MessageBox.Show(this, "Chưa chọn bệnh nhân phát thuốc.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var deliveryRegister = new DeliveryRegister(selectedItem.Id);
            deliveryRegister.ShowDialog();
            UpdateGrid();
        }

        private void DeliverList_Activated_1(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (bdsDeliver.Current == null)
            {
                DialogResult dr = MessageBox.Show("Bạn phải chọn đơn thuốc cần phát?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            VMedicineDeliverList _medicineDelivery = (VMedicineDeliverList)bdsDeliver.Current;
            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q003", "bản ghi cấp thuốc này");
            if (dialogResult == DialogResult.No) return;
            this._medicineDeliveryRepo.Delete(_medicineDelivery.DeliverId.Value);
            this.DialogResult = DialogResult.OK;

            bdsDeliver.Clear();
            UpdateGrid();
            
        }
    }
}
