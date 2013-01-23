using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Entities.Views;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;

namespace Medical.WareHouseIE
{
    public partial class WareHouseIEDetail : Form
    {
        private readonly WareHouseIODetailRepository repwhIODetail = new WareHouseIODetailRepository();
        public WareHouseIEDetail(int wareHouseIOId)
        {
            InitializeComponent();
            bdsWareHouseIODetail.DataSource = repwhIODetail.GetByIOId(wareHouseIOId);
        }
    }
}
