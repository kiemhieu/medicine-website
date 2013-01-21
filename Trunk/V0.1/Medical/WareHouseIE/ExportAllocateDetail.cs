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

        public ExportAllocateDetail(int wareHouseId, int medicineId, int export)
        {
            InitializeComponent();
            bdsVWareHouseDetail.DataSource = repwhDetail.GetMeicineExport(wareHouseId, medicineId);
        }

        private void Initialize()
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
