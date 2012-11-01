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
    public partial class MDITabbed : Form
    {
        private int childCount = 1;

        public MDITabbed()
        {
            InitializeComponent();

            DockPanel dockPanel = new DockPanel();
            dockPanel.Dock = DockStyle.Fill;
            dockPanel.BackColor = Color.Beige;
            Controls.Add(dockPanel);
            dockPanel.BringToFront();

            Form1 form = new Form1();
            form.Show(dockPanel);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage("hello");
            //tabPage.
            Form1 form1 = new Form1();
            form1.MdiParent = this;
            //form1.
            form1.Show();
        }

        public DockContent Create(string name, DockState showHint, Color backColour)
        {
            DockContent content1 = new DockContent();
            content1.Name = name;
            content1.TabText = name;
            content1.Text = name;
            content1.ShowHint = showHint;
            content1.BackColor = backColour;
            return content1;
        }
    }
}
