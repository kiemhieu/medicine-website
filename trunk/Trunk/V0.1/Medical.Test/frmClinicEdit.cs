using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Entities;
using Medical.Data.Repositories;

namespace Medical.Test
{
    public partial class frmClinicEdit : Form
    {
        private ClinicRepository clinicRepository = new ClinicRepository();
        public static int IdClinicEdit;
        public frmClinicEdit()
        {
            InitializeComponent();
            if (IdClinicEdit <= 0)
            {
                cleanItems();
                ReadOnlyItems(false);

            }
            else
            {
                //Medicine medicine = medicineRepository.GetById(IdMedicineEdit);
                FillToItemByID();
                ReadOnlyItems(false);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn cập nhật không?", "Cập nhật", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                Clinic ent = FillToEntity();
                if (ent.Id == 0) clinicRepository.Insert(ent);
                else clinicRepository.Update(ent);

                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            IdClinicEdit = -1;
            this.Close();
        }

        private void cleanItems()
        {
            this.txtName.Text = "";
            this.txtAddress.Text = "";
            this.txtDescription.Text = "";
        }
        private void ReadOnlyItems(bool isTrue)
        {
            this.txtName.ReadOnly = isTrue;
            this.txtAddress.ReadOnly = isTrue;
            this.txtDescription.ReadOnly = isTrue;
        }
        private Clinic FillToEntity()
        {
            Clinic ent;
            if (IdClinicEdit <= 0)
            {
                ent = new Clinic();

            }
            else
            {
                ent = clinicRepository.GetById(IdClinicEdit);
            }

            ent.Name = txtName.Text.Trim();
            ent.Address = txtAddress.Text.Trim();
            ent.Description = txtDescription.Text.Trim();
            ent.LastSyncTime = DateTime.Now.Date;
            ent.Type = rdPK.Checked==true? 1:0;
            return ent;
        }


        private void FillToItemByID()
        {
            if (IdClinicEdit <= 0)
                return;
            Clinic ent = clinicRepository.GetById(IdClinicEdit);

            this.txtName.Text = ent.Name;
            this.txtAddress.Text = ent.Address;
            this.txtDescription.Text = ent.Description;
            this.rdPK.Checked = ent.Type == 1 ? true : false;
            this.rdTT.Checked = ent.Type == 0 ? true : false;

        }
    }
}
