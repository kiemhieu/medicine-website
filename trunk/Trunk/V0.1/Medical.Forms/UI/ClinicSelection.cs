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
using Medical.Data;

namespace Medical.Forms.UI
{
    public partial class ClinicSelection : Form
    {
        private Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /// <summary>
        /// Initializes a new instance of the <see cref="ClinicSelection"/> class.
        /// </summary>
        public ClinicSelection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BTNs the close click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnCloseClick(object sender, System.EventArgs e)
        {
            int id = Convert.ToInt32(comboBoxEx1.SelectedValue);
            _config.AppSettings.Settings["ID"].Value = id.ToString();
            _config.AppSettings.Settings["FirstRun"].Value = "False";
            _config.Save();
            ConfigurationManager.RefreshSection("appSettings");

            int clinicId = Int32.Parse(ConfigurationSettings.AppSettings.Get("ID"));
            AppContext.CurrentClinicId = clinicId;

            this.Close();
        }

        /// <summary>
        /// Clinics the selection load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ClinicSelectionLoad(object sender, System.EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["MedicalContext"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Clinic", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            comboBoxEx1.DataSource = dt;
            comboBoxEx1.DisplayMember = "Name";
            comboBoxEx1.ValueMember = "Id";
        }

        private void ComboBoxEx1SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }
    }
}
