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
        private readonly IVMedicineDeliverRepository _vMedicineRepo = new VMedicineDeliverRepository();
        private readonly IMedicineDeliveryRepository _medicineDeliveryRepo = new MedicineDeliveryRepository();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliverList"/> class.
        /// </summary>
        public DeliverList()
        {
            InitializeComponent();
            Initialize();
            this.Activated += new EventHandler(DeliverListActivated);
        }

        private void DeliverListActivated(object sender, EventArgs e)
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
            // cboStatus.DataSource = new List<Item>(new Item[] { new Item(0, "Tất cả"), new Item(1, "Chưa phát thuốc"), new Item(2, "Đã phát thuốc") });
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        private void UpdateGrid()
        {
            var type = cboType.Checked ? 2 : 1;
            this.UpdateGrid(this.cboDate.Value.Date, type);
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="type">The type.</param>
        private void UpdateGrid(DateTime date, int type)
        {
            var list = _vMedicineRepo.Get(date, type);
            //for (var i = 0; i < list.Count; i++)
            //{
            //    list[i].No = i + 1;
            //}
            this.bdsDeliver.DataSource = list;
            this.bdsDeliver.ResetBindings(true);
            this.dataGridViewX1.Refresh();
            this.dataGridViewX1.ResetBindings();
        }

        private void CboDateValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void CboStatusSelectedValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();

        }

        private void BtnDeliverClick(object sender, EventArgs e)
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

        private void DeliverListActivated1(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
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

        private void DataGridViewX1DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            if (null == gridView) return;
            foreach (DataGridViewRow r in gridView.Rows)
            {
                gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }
        }

        private void DataGridViewX1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bdsDeliver.Current == null)
            {
                var dr = MessageBox.Show("Bạn phải chọn đơn thuốc cần phát?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
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

        private void DataGridViewX1DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void CboTypeCheckValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void DataGridViewX1RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            gridView.Rows[e.RowIndex].Selected = true;

            // e.RowIndex
            e.ContextMenuStrip = ctxMenu;
            // ctxMenu.Show();
        }

        private void MnuDeleteDeliverClick(object sender, EventArgs e)
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
