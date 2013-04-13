using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;
using Medical.Data.Entities;
using Medical.Data.EntitiyExtend;
using IsolationLevel = System.Transactions.IsolationLevel;
namespace Medical.Data.Repositories
{
    public class ReportRepository : RepositoryBase, IReportRepository
    {

        public List<ReportTotalMedicineDeliveryByMonth> GetReportTotalMedicineDeliveryByMonth(int clinicId, DateTime month)
        {
            var parameters = new SqlParameter[]
                                 {
                                     new SqlParameter("@ClinicId", clinicId),
                                     new SqlParameter("@Month", month.ToShortDateString())
                                 };
            var ds = this.Context.Database.SqlQuery<ReportTotalMedicineDeliveryByMonth>("sp_ReportTotalMedicineDeliveryByMonth @ClinicId, @Month",
                new SqlParameter("@ClinicId", AppContext.CurrentClinic.Id),
                new SqlParameter("@Month", month.ToShortDateString()));
            return ds.ToList();
        }

        public object GetReportTotalMedicineDeliveryByMonth()
        {
            throw new NotImplementedException();
        }
    }
}
