using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Medical.Synchronization;

public class SearchExpander
{
    public SearchExpander(string columnname, string display, Type type)
    {
        this.ColumnName = columnname;
        this.Display = display;
        this.Type = type;
        this.Refference = null;
    }

    public string ColumnName { get; set; }

    public string Display { get; set; }

    public Type Refference { get; set; }

    public string RefferenceColumn { get; set; }

    public Type Type { get; set; }
}