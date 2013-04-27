using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Forms.UI
{
    public partial class TreeMenu : DockContent
    {
        public TreeMenu()
        {
            InitializeComponent();
        }

        public TreeView TreeViewMenu
        {
            get { return this.treeView1; }
        }
    }
}
