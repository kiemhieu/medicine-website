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


        public DeliverList()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            cboClinic.DataSource = _clinicRepo.GetAll();
            cboDate.Value = DateTime.Today;

            cboStatus.DataSource = new List<Item>(new Item[] { new Item(1, "Tất cả"), new Item(2, "Đã phát thuốc"), new Item(3, "Chưa phát thuốc")});


        }

        private void UpdateGrid()
        {
            
        }
    }
}
