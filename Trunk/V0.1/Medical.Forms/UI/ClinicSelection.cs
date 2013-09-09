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
using Medical.Data.Entities;

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
            List<Clinic> clinicList = new List<Clinic>
                                          {
                                              new Clinic() {Id = 1, Name = "TRUNG TÂM PHÒNG, CHỐNG HIV/AIDS HÀ NỘI"},
                                              new Clinic() {Id = 2, Name = "Phòng khám Gia Lâm"},
                                              new Clinic() {Id = 3, Name = "Phòng khám Long Biên"},
                                              new Clinic() {Id = 4, Name = "Phòng khám Đống Đa"},
                                              new Clinic() {Id = 5, Name = "Phòng khám Ba Đình"},
                                              new Clinic() {Id = 6, Name = "Phòng khám Thanh Xuân"},
                                              new Clinic() {Id = 7, Name = "Phòng khám Từ Liêm"},
                                              new Clinic() {Id = 8, Name = "Phòng khám Ứng Hòa"},
                                              new Clinic() {Id = 9, Name = "Phòng khám Ba Vì"},
                                              new Clinic() {Id = 10, Name = "Phòng khám Tây Hồ"},
                                              new Clinic() {Id = 11, Name = "Phòng khám Đông Anh"},
                                              new Clinic() {Id = 12, Name = "Phòng khám Hoàng Mai"},
                                              new Clinic() {Id = 13, Name = "Phòng khám HBT"},
                                              new Clinic() {Id = 14, Name = "Phòng khám Sóc Sơn"},
                                              new Clinic() {Id = 15, Name = "Phòng khám BV 09"},
                                              new Clinic() {Id = 16, Name = "Phòng khám BV Đống Đa"},
                                              new Clinic() {Id = 17, Name = "Phòng khám BV Hà Đông"},
                                              new Clinic() {Id = 18, Name = "Phòng khám BV Phổi HN"},
                                              new Clinic() {Id = 19, Name = "Phòng khám BV Sơn Tây"},
                                              new Clinic() {Id = 20, Name = "Phòng khám TT 01"},
                                              new Clinic() {Id = 21, Name = "Phòng khám TT 02"},
                                              new Clinic() {Id = 22, Name = "Phòng khám TT 03"},
                                              new Clinic() {Id = 23, Name = "Phòng khám TT 04"},
                                              new Clinic() {Id = 24, Name = "Phòng khám TT 05"},
                                              new Clinic() {Id = 25, Name = "Phòng khám TT 06"},
                                              new Clinic() {Id = 26, Name = "Phòng khám TT 08"},
                                              new Clinic() {Id = 27, Name = "Phòng khám TT SC 01"},
                                              new Clinic() {Id = 28, Name = "Phòng khám TT SC 02"},
                                              new Clinic() {Id = 29, Name = "Phòng khám TT SC TN"}
                                          };

            //String connectionString = ConfigurationManager.ConnectionStrings["MedicalContext"].ConnectionString;
            //SqlConnection connection = new SqlConnection(connectionString);
            //SqlDataAdapter adapter = new SqlDataAdapter("Select * from Clinic", connection);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            comboBoxEx1.DataSource = clinicList;
            comboBoxEx1.DisplayMember = "Name";
            comboBoxEx1.ValueMember = "Id";
        }

        private void ComboBoxEx1SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }
    }
}
