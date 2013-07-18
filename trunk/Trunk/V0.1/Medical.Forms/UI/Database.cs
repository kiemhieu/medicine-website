using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical.Forms.UI
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }

        private void DatabaseLoad(object sender, System.EventArgs e)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            // Get the conectionStrings section.
            ConnectionStringsSection csSection = config.ConnectionStrings;
            ConnectionStringSettings connection = csSection.ConnectionStrings["MedicalContext"];
            connection.
        }
    }
}
