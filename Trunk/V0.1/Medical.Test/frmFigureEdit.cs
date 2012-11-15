using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data.Repositories;
using Medical.Data.Entities;
namespace Medical.Test
{
    public partial class frmFigureEdit : Form
    {

        private FigureRepository figureRepository = new FigureRepository();
        public static int IdFigureEdit;
        public frmFigureEdit()
        {
            
            InitializeComponent();
            if (IdFigureEdit<= 0)
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
                Figure ent = FillToEntity();
                if (ent.Id == 0) figureRepository.Insert(ent);
                else figureRepository.Update(ent);

                this.Close();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            frmFigureEdit.IdFigureEdit = -1;
            this.Close(); 
        }

        private void cleanItems()
        {
            this.txtGhiChu.Text = "";
            this.txtFigureName.Text = "";
        }
        private void ReadOnlyItems(bool isTrue)
        {
            this.txtGhiChu.ReadOnly = isTrue;
            this.txtFigureName.ReadOnly = isTrue;
        }
        private Figure FillToEntity()
        {
            Figure ent;
            if (IdFigureEdit <= 0)
            {
                ent = new Figure();
                
            }
            else
            {
                ent = figureRepository.GetById(IdFigureEdit);
            }

            ent.Name = txtFigureName.Text.Trim();
            ent.Description = txtGhiChu.Text.Trim();
            return ent;
        }


        private void FillToItemByID()
        {
            if (IdFigureEdit <= 0)
                return;
            Figure ent   = figureRepository.GetById(IdFigureEdit);

            this.txtFigureName.Text = ent.Name.ToString();
            this.txtGhiChu.Text = ent.Description.ToString();
        }
    }
}
