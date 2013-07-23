using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Medical.Synchronization;

public class SearchExpander
{
    public SearchExpander(string columnname, string display)
    {
        this.ColumnName = columnname;
        this.Display = display;
    }

    public string ColumnName { get; set; }

    public string Display { get; set; }
}