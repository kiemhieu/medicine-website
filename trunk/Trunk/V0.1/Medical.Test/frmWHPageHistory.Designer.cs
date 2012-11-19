namespace Medical.Test
{
    partial class frmWHPageHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateDenNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTuNgay = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbTypeWHPage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbItemNhap = new DevComponents.Editors.ComboItem();
            this.cbItemXuat = new DevComponents.Editors.ComboItem();
            this.grd = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinicNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinicIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delivererDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crearedUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateDenNgay);
            this.groupBox1.Controls.Add(this.dateTuNgay);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.cbTypeWHPage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tra cứu lịch sử nhập xuất kho";
            // 
            // dateDenNgay
            // 
            // 
            // 
            // 
            this.dateDenNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateDenNgay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateDenNgay.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateDenNgay.ButtonDropDown.Visible = true;
            this.dateDenNgay.IsPopupCalendarOpen = false;
            this.dateDenNgay.Location = new System.Drawing.Point(557, 16);
            // 
            // 
            // 
            this.dateDenNgay.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateDenNgay.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateDenNgay.MonthCalendar.BackgroundStyle.Class = "";
            this.dateDenNgay.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateDenNgay.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateDenNgay.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateDenNgay.MonthCalendar.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            this.dateDenNgay.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateDenNgay.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateDenNgay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateDenNgay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateDenNgay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateDenNgay.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateDenNgay.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateDenNgay.MonthCalendar.TodayButtonVisible = true;
            this.dateDenNgay.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(107, 20);
            this.dateDenNgay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateDenNgay.TabIndex = 3;
            // 
            // dateTuNgay
            // 
            // 
            // 
            // 
            this.dateTuNgay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTuNgay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTuNgay.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTuNgay.ButtonDropDown.Visible = true;
            this.dateTuNgay.IsPopupCalendarOpen = false;
            this.dateTuNgay.Location = new System.Drawing.Point(333, 16);
            // 
            // 
            // 
            this.dateTuNgay.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTuNgay.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTuNgay.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTuNgay.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTuNgay.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTuNgay.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTuNgay.MonthCalendar.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            this.dateTuNgay.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTuNgay.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTuNgay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTuNgay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTuNgay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTuNgay.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTuNgay.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTuNgay.MonthCalendar.TodayButtonVisible = true;
            this.dateTuNgay.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(107, 20);
            this.dateTuNgay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTuNgay.TabIndex = 3;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(495, 16);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Đến ngày";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(281, 16);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Từ ngày";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(6, 16);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(82, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Nhập/ Xuất kho";
            // 
            // cbTypeWHPage
            // 
            this.cbTypeWHPage.DisplayMember = "Text";
            this.cbTypeWHPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTypeWHPage.FormattingEnabled = true;
            this.cbTypeWHPage.ItemHeight = 14;
            this.cbTypeWHPage.Items.AddRange(new object[] {
            this.cbItemNhap,
            this.cbItemXuat});
            this.cbTypeWHPage.Location = new System.Drawing.Point(94, 16);
            this.cbTypeWHPage.Name = "cbTypeWHPage";
            this.cbTypeWHPage.Size = new System.Drawing.Size(131, 20);
            this.cbTypeWHPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbTypeWHPage.TabIndex = 0;
            // 
            // cbItemNhap
            // 
            this.cbItemNhap.Text = "Nhập kho";
            // 
            // cbItemXuat
            // 
            this.cbItemXuat.Text = "Xuất kho";
            // 
            // grd
            // 
            this.grd.AutoGenerateColumns = false;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.clinicNameDataGridViewTextBoxColumn,
            this.clinicIdDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.noDataGridViewTextBoxColumn,
            this.recipientDataGridViewTextBoxColumn,
            this.delivererDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.crearedUserDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.lastUpdatedUserDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn});
            this.grd.DataSource = this.bindingSource1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle1;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grd.Location = new System.Drawing.Point(0, 45);
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.Size = new System.Drawing.Size(751, 301);
            this.grd.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Medical.Data.Entities.WareHousePaper);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // clinicNameDataGridViewTextBoxColumn
            // 
            this.clinicNameDataGridViewTextBoxColumn.DataPropertyName = "ClinicName";
            this.clinicNameDataGridViewTextBoxColumn.HeaderText = "Tên kho";
            this.clinicNameDataGridViewTextBoxColumn.Name = "clinicNameDataGridViewTextBoxColumn";
            this.clinicNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clinicIdDataGridViewTextBoxColumn
            // 
            this.clinicIdDataGridViewTextBoxColumn.DataPropertyName = "ClinicId";
            this.clinicIdDataGridViewTextBoxColumn.HeaderText = "ClinicId";
            this.clinicIdDataGridViewTextBoxColumn.Name = "clinicIdDataGridViewTextBoxColumn";
            this.clinicIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.clinicIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Nhập/Xuất kho";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Ngày nhập xuất";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "Mã chứng từ";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // recipientDataGridViewTextBoxColumn
            // 
            this.recipientDataGridViewTextBoxColumn.DataPropertyName = "Recipient";
            this.recipientDataGridViewTextBoxColumn.HeaderText = "Người nhập xuất";
            this.recipientDataGridViewTextBoxColumn.Name = "recipientDataGridViewTextBoxColumn";
            this.recipientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // delivererDataGridViewTextBoxColumn
            // 
            this.delivererDataGridViewTextBoxColumn.DataPropertyName = "Deliverer";
            this.delivererDataGridViewTextBoxColumn.HeaderText = "Người giao";
            this.delivererDataGridViewTextBoxColumn.Name = "delivererDataGridViewTextBoxColumn";
            this.delivererDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "chú thích";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // crearedUserDataGridViewTextBoxColumn
            // 
            this.crearedUserDataGridViewTextBoxColumn.DataPropertyName = "CrearedUser";
            this.crearedUserDataGridViewTextBoxColumn.HeaderText = "CrearedUser";
            this.crearedUserDataGridViewTextBoxColumn.Name = "crearedUserDataGridViewTextBoxColumn";
            this.crearedUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.crearedUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdatedUserDataGridViewTextBoxColumn
            // 
            this.lastUpdatedUserDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedUser";
            this.lastUpdatedUserDataGridViewTextBoxColumn.HeaderText = "LastUpdatedUser";
            this.lastUpdatedUserDataGridViewTextBoxColumn.Name = "lastUpdatedUserDataGridViewTextBoxColumn";
            this.lastUpdatedUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmWHPageHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 346);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmWHPageHistory";
            this.Text = "Lịch sử xuất nhập kho";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbTypeWHPage;
        private DevComponents.Editors.ComboItem cbItemNhap;
        private DevComponents.Editors.ComboItem cbItemXuat;
        private DevComponents.DotNetBar.Controls.DataGridViewX grd;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateDenNgay;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTuNgay;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinicNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinicIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delivererDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crearedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
    }
}