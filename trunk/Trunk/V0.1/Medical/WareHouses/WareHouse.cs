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
using Medical.Data.Repositories;

namespace Medical.WareHouses {
    public partial class WareHouse : Form {

        private IClinicRepository clinicRepo = new ClinicRepository();
        private IUserRepository userRepo = new UserRepository();
        private IMedicineRepository medicineRepo = new MedicineRepository();

        public WareHouse() {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            // Init Clinic combobox
            var clinic = this.clinicRepo.GetAll();
            clinic.Insert(0, new Clinic() { Id = 0, Name = "Tất cả" });
            this.bdsClinic.DataSource = clinic;
            this.cboClinic.SelectedValue = AppContext.CurrentClinic.Id;

            // Init AutoCompleteSource
            var medicinesName = medicineRepo.GetMedicinesName();
            var completeSource = new AutoCompleteStringCollection();
            completeSource.AddRange(medicinesName.ToArray());
            txtMedicine.AutoCompleteCustomSource = completeSource;
        }

        private void WareHouse_Load(object sender, EventArgs e)
        {

        }
    }
}
