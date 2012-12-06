using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Repositories;

namespace Medical.MedicineDeliver
{
    public partial class DeliverList : Form
    {
        private IClinicRepository _clinicRepo = new ClinicRepository();


        public DeliverList()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            
        }
    }
}
