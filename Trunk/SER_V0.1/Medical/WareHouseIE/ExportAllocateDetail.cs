using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;

namespace Medical.WareHouseIE
{
    public partial class ExportAllocateDetail : Form
    {
        private readonly WareHouseDetailRepository repwhDetail = new WareHouseDetailRepository();
        public List<WareHouseDetail> ListWareHouseDetail;
        public bool Flag;
        public ExportAllocateDetail(int wareHouseId, int medicineId, int export, List<WareHouseDetail> listWareHouseDetail, bool flag)
        {
            InitializeComponent();
            if (flag)
                bdsWareHouseDetail.DataSource = listWareHouseDetail;
            else
                bdsWareHouseDetail.DataSource = repwhDetail.GetMeicineExport(wareHouseId, medicineId, export);

            txtAllocatedQty.Text = txtQty.Text = export.ToString();
        }

        private void Initialize()
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtNotAllocatedQty.Text) == 0)
            {
                ListWareHouseDetail = bdsWareHouseDetail.DataSource as List<WareHouseDetail>;
                //if (ListWareHouseDetail == null)
                //    ListWareHouseDetail = new List<WareHouseDetail>();

                //foreach (WareHouseDetail item in bdsWareHouseDetail)
                //{
                //    ListWareHouseDetail.Add(item);
                //}

                Flag = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Số lượng thuốc chọn không bằng số cần xuất. Vui lòng chọn lại");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Flag = false;
            this.Close();
        }

        private void grd_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int qty = 0;
            int export = 0;
            if (grd.Columns[e.ColumnIndex].Name == "ExportVolumn")
            {
                if (int.TryParse(grd.Rows[e.RowIndex].Cells["ExportVolumn"].Value.ToString(), out export))
                {
                    qty = int.Parse(grd.Rows[e.RowIndex].Cells["CurrentVolumn"].Value.ToString());
                    if (export > qty) grd.Rows[e.RowIndex].Cells["ExportVolumn"].Value = qty;
                    if (export < 0) grd.Rows[e.RowIndex].Cells["ExportVolumn"].Value = 0;
                    CalculateQty();
                }
            }
        }

        private void CalculateQty()
        {
            int qty = 0;

            foreach (WareHouseDetail item in bdsWareHouseDetail)
            {
                qty += item.ExportVolumn;
            }

            txtAllocatedQty.Text = qty.ToString();
            txtNotAllocatedQty.Text = (int.Parse(txtQty.Text) - qty).ToString();
        }

        private void ExportAllocateDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ListWareHouseDetail == null || ListWareHouseDetail.Count == 0)
                Flag = false;
        }
    }
}
