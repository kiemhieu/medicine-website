using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.Entities;
using Medical.Data.Repositories;
using Medical.Forms.Enums;

namespace Medical.MedicinePlanning
{
    public partial class MedicinePlanningDetail : Form
    {
        private IClinicRepository clinicRepo = new ClinicRepository();
        private IUserRepository userRepo = new UserRepository();
        private IMedicinePlanRepository planingRepo = new MedicinePlanRepository();
        private IMedicinePlanDetailRepository planingDetail = new MedicinePlanDetailRepository();
        
        private ViewModes mode;
        private int planningId;
        private Medical.Data.Entities.MedicinePlan medicinePlan;
        private List<Medical.Data.Entities.MedicinePlanDetail> medicinePlanDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedicinePlanningDetail"/> class.
        /// </summary>
        public MedicinePlanningDetail()
        {
            InitializeComponent();
            this.mode = ViewModes.Add;
            this.medicinePlan = new Data.Entities.MedicinePlan();
            this.medicinePlanDetails = new List<MedicinePlanDetail>();
        }

        public MedicinePlanningDetail(int medicinePlanId) : this()
        {
            this.mode = ViewModes.Update;
            
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {

        }
    }
}
