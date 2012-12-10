using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.MedicineForm
{
    public partial class FrmMedicine : DockContent
    {
        public static int IdMedicine = -1;
        private UserRepository _userRepository = new UserRepository();

        private readonly MedicineRepository _medicineRepository = new MedicineRepository();
        private readonly IDefineRepository _defineRepository = new DefineRepository();


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMedicine"/> class.
        /// </summary>
        public FrmMedicine()
        {
            InitializeComponent();
            
        }

        private void Initialize()
        {
            var items = new List<Item>(new Item[] { new Item(0, "Tất cả"), new Item(1, "ARV"), new Item(2, "NTCH") });
            this.cboType.ComboBox.DisplayMember = "Name";
            this.cboType.ComboBox.ValueMember = "Value";
            this.cboType.ComboBox.DataSource = items;
            this.cboType.ComboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);


            var units = _defineRepository.GetUnit();
            this.bdsDefine.DataSource = units;

        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FillToGrid();
        }

        /// <summary>
        /// Fills to grid.
        /// </summary>
        private void FillToGrid()
        {
            var type = Convert.ToInt32(this.cboType.ComboBox.SelectedValue);
            var medicines = _medicineRepository.Get(type);
            var index = 0;
            foreach (var item in medicines) item.No = ++index;
            this.grd.DataSource = medicines;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            frmMedicinEdit frmedit = new frmMedicinEdit();
            frmMedicinEdit.IdMedicineEdit = 0;   
            frmedit.ShowDialog();
            FillToGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn bản thuốc cần xóa!");
                return;
            }
            DialogResult dr = MessageBox.Show("Bạn có muốn xóa thuốc này không?", "Xóa thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                _medicineRepository.Delete(int.Parse(lblID.Text.Trim()));
                FillToGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if ((lblID.Text == "") || (lblID.Text == "0"))
            {
                MessageBox.Show("Bạn hãy chọn bản thuốc cần sửa!");
                return;
            }
            frmMedicinEdit.IdMedicineEdit = int.Parse(lblID.Text);
            frmMedicinEdit frmedit = new frmMedicinEdit();
            frmedit.ShowDialog();
            FillToGrid();

        }

        private void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lblID.Text = grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null ? "0" : grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString();

        }



        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            if (grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value == null)
            {
                IdMedicine = 0;
            }

            else
            {
                IdMedicine = int.Parse(grd.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
            }
            frmMedicinEdit.IdMedicineEdit = IdMedicine;
            frmMedicinEdit frmEdit = new frmMedicinEdit();
            frmEdit.ShowDialog();
            FillToGrid();
             */
        }

        private void FrmMedicine_Load(object sender, EventArgs e)
        {
            FillToGrid();
            Initialize();
        }
    }
}
