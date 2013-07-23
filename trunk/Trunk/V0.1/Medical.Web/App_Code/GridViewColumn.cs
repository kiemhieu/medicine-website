using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for GridViewColumn
/// </summary>
public class GridViewColumn : DataControlField
{
	public GridViewColumn()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //protected override void CopyProperties(DataControlField newField)
    //{
    //    ((CalendarField)newField).DataField = this.DataField;
    //    ((CalendarField)newField).DataFormatString = this.DataFormatString;
    //    ((CalendarField)newField).ReadOnly = this.ReadOnly;

    //    base.CopyProperties(newField);
    //}

    public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
    {
        // Call the base method
        base.InitializeCell(cell, cellType, rowState, rowIndex);

        // Initialize the contents of the cell quitting if it is a header/footer
        if (cellType == DataControlCellType.DataCell)
            InitializeDataCell(cell, rowState);
    }

    protected virtual void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
    {

    }
}