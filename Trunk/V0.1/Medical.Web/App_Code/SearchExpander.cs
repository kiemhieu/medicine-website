using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Medical.Synchronization;

public class SearchExpander
{
    /// <summary>
    /// Constructor 1 - default
    /// </summary>
    /// <param name="columnname"></param>
    /// <param name="display"></param>
    /// <param name="type"></param>
    public SearchExpander(string columnname, string display, Type type)
    {
        this.BeenSearch = true;
        this.ColumnName = columnname;
        this.Display = display;
        this.Type = type;
        this.Refference = null;
        this.HasDetail = false;
        this.DisplayRefferenceColumn = "Name"; 
    }

    public SearchExpander(bool beensearch, string columnname, string display, Type type)
    {
        this.BeenSearch = beensearch;
        this.ColumnName = columnname;
        this.Display = display;
        this.Type = type;
        this.Refference = null;
        this.HasDetail = false;
        this.DisplayRefferenceColumn = "Name";
    }

    /// <summary>
    /// Constructor 1 - has detail items
    /// </summary>
    /// <param name="columnname"></param>
    /// <param name="display"></param>
    /// <param name="type"></param>
    public SearchExpander(string columnname, string display, Type type, bool hasdetail)
    {
        this.BeenSearch = true;
        this.ColumnName = columnname;
        this.Display = display;
        this.Type = type;
        this.Refference = null;
        this.HasDetail = hasdetail;
        this.DisplayRefferenceColumn = "Name";
    }

    /// <summary>
    /// Constructor 1 - has refference column
    /// </summary>
    /// <param name="columnname"></param>
    /// <param name="display"></param>
    /// <param name="type"></param>
    public SearchExpander(string columnname, string display, Type type, string refferencecolumn, Type refference)
    {
        this.BeenSearch = true;
        this.ColumnName = columnname;
        this.Display = display;
        this.Type = type;
        this.RefferenceColumn = refferencecolumn;
        this.Refference = refference;
        this.HasDetail = false;
        this.DisplayRefferenceColumn = "Name";
    }

    /// <summary>
    /// Constructor 1 - has refference column
    /// </summary>
    /// <param name="columnname"></param>
    /// <param name="display"></param>
    /// <param name="type"></param>
    public SearchExpander(string columnname, string display, Type type, string refferencecolumn, string displayrefferencecolumn, Type refference)
    {
        this.BeenSearch = true;
        this.ColumnName = columnname;
        this.Display = display;
        this.Type = type;
        this.RefferenceColumn = refferencecolumn;
        this.Refference = refference;
        this.HasDetail = false;
        this.DisplayRefferenceColumn = displayrefferencecolumn;
    }

    public bool BeenSearch { get; set; }

    public string ColumnName { get; set; }

    public string Display { get; set; }

    public Type Refference { get; set; }

    public string RefferenceColumn { get; set; }

    public string DisplayRefferenceColumn { get; set; }

    public Type Type { get; set; }

    public bool HasDetail { get; set; }
}