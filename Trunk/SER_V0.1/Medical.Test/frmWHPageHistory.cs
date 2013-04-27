using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Test
{
    public partial class frmWHPageHistory : DockContent
    {
        public frmWHPageHistory()
        {
            InitializeComponent();
            dateTuNgay.Value = DateTime.Now.Date;
            dateDenNgay.Value = DateTime.Now.Date;
        }
    }
}
