using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical.Forms.Common {
    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn {
        public DataGridViewDisableButtonColumn() {
            this.CellTemplate = new DataGridViewDisableButtonCell();
            // this.CellTemplate = new DataGridViewDisableButtonXCell();
        }
    }
}
