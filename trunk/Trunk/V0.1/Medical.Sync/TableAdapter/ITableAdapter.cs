using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Medical.Sync.TableAdapter
{
    public interface ITableAdapter
    {
        SqlDataAdapter BuildAdapter(SqlConnection connection);

    }
}
