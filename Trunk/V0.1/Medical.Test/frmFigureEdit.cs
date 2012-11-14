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
        }
    }
}
