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
        private Timer time;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliverList"/> class.
        /// </summary>
        public DeliverList()
        {
            InitializeComponent();
            Initialize();
            time = new Timer();
            time.Tick += TimerTick;
            time.Interval = 10000;
            this.Activated += DeliverListActivated;
            this.Deactivate += DeliverListDeactivate;
        }

        /// <summary>
        /// Delivers the list deactivate.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DeliverListDeactivate(object sender, EventArgs e)
        {
            time.Stop();
        }

        /// <summary>
        /// Timers the tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void DeliverListActivated(object sender, EventArgs e)
        {
            time.Start();
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
        /// Cboes the status selected value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CboStatusSelectedValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();

        }

        /// <summary>
        /// BTNs the deliver click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Delivers the list activated1.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
            var _medicineDelivery = (VMedicineDeliverList)bdsDeliver.Current;
            var dialogResult = MessageDialog.Instance.ShowMessage(this, "Q003", "bản ghi cấp thuốc này");
            if (dialogResult == DialogResult.No) return;
            this._medicineDeliveryRepo.Delete(_medicineDelivery.DeliverId.Value);
            this.DialogResult = DialogResult.OK;

            bdsDeliver.Clear();
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

        /// <summary>
        /// Datas the grid view x1 cell double click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Datas the grid view x1 default values needed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewRowEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        /// <summary>
        /// Cboes the type check value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CboTypeCheckValueChanged(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        /// <summary>
        /// Datas the grid view x1 row context menu strip needed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewRowContextMenuStripNeededEventArgs"/> instance containing the event data.</param>
        private void DataGridViewX1RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            var gridView = (DataGridViewX)sender;
            gridView.Rows[e.RowIndex].Selected = true;

            // e.RowIndex
            e.ContextMenuStrip = ctxMenu;
            // ctxMenu.Show();
        }

        /// <summary>
        /// Mnus the delete deliver click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
