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
        
        public frmImportWH()
        {

            InitializeComponent();
            repClinic = new ClinicRepository();
            FillToComboboxClinic(0);
            dateImport.Value = DateTime.Now.Date;
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
