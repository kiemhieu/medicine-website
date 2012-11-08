using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Test
{
    public partial class MDITabbed : DevComponents.DotNetBar.Office2007Form
    {
        private int childCount = 1;
        private Form1 form3;
        private frmMedicine frmMed;
        public MDITabbed()
        {
            
            InitializeComponent();

            DockPanel dockPanel = new DockPanel();
            dockPanel.Dock = DockStyle.Fill;
            dockPanel.BackColor = Color.Beige;
            Controls.Add(dockPanel);
            //dockPanel.AllowEndUserNestedDocking = false;
            dockPanel.AllowEndUserDocking = false;
            dockPanel.BringToFront();

            Form1 form = new Form1();
            //form.AllowEndUserDocking = false;
            //form.WindowState = FormWindowState.Maximized;
            form.MinimizeBox = false;
            form.Show(dockPanel);

            form3 = new Form1();
            form3.Text = "Form 3";
            //form.AllowEndUserDocking = false;
            //form.WindowState = FormWindowState.Maximized;
            form3.MinimizeBox = false;
            form3.Show(dockPanel);
            form3.Select();


             frmMed = new frmMedicine();
            frmMed.Text = "Medicine";
            //form.AllowEndUserDocking = false;
            //form.WindowState = FormWindowState.Maximized;
            frmMed.MinimizeBox = false;
            frmMed.Show(dockPanel);
            frmMed.Select();

            Form1 form2 = new Form1(); ;
            form2.ShowHint = DockState.DockLeft;
            form2.AllowEndUserDocking = false;
            form2.CloseButton = false;
            form2.IsFloat = false;
            form2.CloseButtonVisible = false;
            form2.Show(dockPanel);
            dockPanel.Select();
            //form2.Select();
            //MessageBox.Show(dockPanel.Panes.Count.ToString());
        }

        void dockPanel_DockChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void MDITabbed_Shown(object sender, EventArgs e)
        {
            form3.Activate();
        }

        private void danhMụcThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMed.Activate();
        }
    }
}
