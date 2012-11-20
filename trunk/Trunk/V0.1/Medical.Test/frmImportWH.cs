using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Repositories;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Test
{
    public partial class frmImportWH : DockContent
    {
        private ClinicRepository repClinic;
        private MedicineRepository repMedicine;
        
        public frmImportWH()
        {
            repClinic = new ClinicRepository();
            repMedicine = new MedicineRepository();
            InitializeComponent();
            repClinic = new ClinicRepository();
            FillToComboboxClinic(0);
            dateImport.Value = DateTime.Now.Date;
            try
            {
                bindingSource3.DataSource = repMedicine.GetAll();
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }
        private void  FillToComboboxClinic(int clinicId)
        {
            if (clinicId > 0)
            {
                bindingSource2.DataSource = repClinic.GetById(clinicId);

            }
            else bindingSource2.DataSource = repClinic.GetAll();
        }
    }
}
