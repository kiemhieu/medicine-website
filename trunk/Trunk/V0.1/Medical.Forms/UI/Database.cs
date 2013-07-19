using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Forms.Entities;

namespace Medical.Forms.UI
{
    public partial class Database : Form
    {
        private DbConnectionObject connectionObject;
        private Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public Database()
        {
            InitializeComponent();
        }

        private void DatabaseLoad(object sender, System.EventArgs e)
        {
            
            
            // Get the conectionStrings section.
            ConnectionStringsSection csSection = _config.ConnectionStrings;
            ConnectionStringSettings connection = csSection.ConnectionStrings["MedicalContext"];
            connectionObject = new DbConnectionObject(connection.ConnectionString);
            this.bdsData.DataSource = connectionObject;
           
        }

        private void BtnCancelClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BtnSaveClick(object sender, System.EventArgs e)
        {
            _config.ConnectionStrings.ConnectionStrings["MedicalContext"].ConnectionString = connectionObject.ToString();
            _config.Save();
            this.Close();
        }

        private void BtnTestClick(object sender, System.EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionObject.ToString()))
            {
                try
                {
                   connection.Open();
                    MessageBox.Show(this, "Connect to database successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Cannot connect to Database. Error: " + ex.Message);
                }
            }
        }
    }
}
