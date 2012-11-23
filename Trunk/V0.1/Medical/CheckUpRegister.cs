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

namespace Medical {
    public partial class CheckUpRegister : Form
    {
        private Patient patient;
        private List<Figure> figureList;
        private IFigureRepository figureRepo = new FigureRepository();

        public CheckUpRegister(Patient patient) {
            InitializeComponent();

            this.patient = patient;
            var figures = figureRepo.GetAll();
            this.cboFigure.DataSource = figures;
        }

        
    }
}
