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

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Databases the load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DatabaseLoad(object sender, System.EventArgs e)
        {
            // Get the conectionStrings section.
            ConnectionStringsSection csSection = _config.ConnectionStrings;
            ConnectionStringSettings connection = csSection.ConnectionStrings["MedicalContext"];
            connectionObject = new DbConnectionObject(connection.ConnectionString);
            this.bdsData.DataSource = connectionObject;
        }

        /// <summary>
        /// BTNs the cancel click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCancelClick(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// BTNs the save click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnSaveClick(object sender, System.EventArgs e)
        {
            _config.ConnectionStrings.ConnectionStrings["MedicalContext"].ConnectionString = connectionObject.ToString();
            _config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            this.Close();
        }

        /// <summary>
        /// BTNs the test click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnTestClick(object sender, System.EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionObject.ToString()))
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
