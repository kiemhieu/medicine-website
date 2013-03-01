namespace Medical.MedicinePlanning {
    partial class MedicinePlanningDetail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.bdsPlanning = new System.Windows.Forms.BindingSource(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtMonth = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsClinic = new System.Windows.Forms.BindingSource(this.components);
            this.grdPlanning = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.medicineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bdsMedicine = new System.Windows.Forms.BindingSource(this.components);
            this.inStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastMonthUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentMonthUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsPlanningDetail = new System.Windows.Forms.BindingSource(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsStatus = new System.Windows.Forms.BindingSource(this.components);
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtYear = new DevComponents.Editors.IntegerInput();
            this.txtApprovedDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cboPerson = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClinic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanningDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApprovedDate)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployee)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(326, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(28, 15);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Ngày";
            // 
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtDate.ButtonDropDown.Visible = true;
            this.txtDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdsPlanning, "Date", true));
            this.txtDate.Enabled = false;
            this.txtDate.IsPopupCalendarOpen = false;
            this.txtDate.Location = new System.Drawing.Point(388, 27);
            // 
            // 
            // 
            this.txtDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtDate.MonthCalendar.BackgroundStyle.Class = "";
            this.txtDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.txtDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.txtDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.txtDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.MonthCalendar.TodayButtonVisible = true;
            this.txtDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(120, 20);
            this.txtDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtDate.TabIndex = 1;
            // 
            // bdsPlanning
            // 
            this.bdsPlanning.DataSource = typeof(Medical.Data.Entities.MedicinePlan);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(6, 9);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(34, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tháng";
            // 
            // txtMonth
            // 
            // 
            // 
            // 
            this.txtMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMonth.DataBindings.Add(new System.Windows.Forms.Binding("ValueObject", this.bdsPlanning, "Month", true));
            this.txtMonth.Location = new System.Drawing.Point(74, 6);
            this.txtMonth.MaxValue = 12;
            this.txtMonth.MinValue = 1;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ShowUpDown = true;
            this.txtMonth.Size = new System.Drawing.Size(60, 20);
            this.txtMonth.TabIndex = 3;
            this.txtMonth.Value = 1;
            this.txtMonth.ValueChanged += new System.EventHandler(this.txtMonth_ValueChanged);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(326, 7);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(52, 15);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Trung tâm";
            // 
            // cboClinic
            // 
            this.cboClinic.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPlanning, "ClinicId", true));
            this.cboClinic.DataSource = this.bdsClinic;
            this.cboClinic.DisplayMember = "Name";
            this.cboClinic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClinic.Enabled = false;
            this.cboClinic.FormattingEnabled = true;
            this.cboClinic.ItemHeight = 14;
            this.cboClinic.Location = new System.Drawing.Point(388, 4);
            this.cboClinic.Name = "cboClinic";
            this.cboClinic.Size = new System.Drawing.Size(206, 20);
            this.cboClinic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboClinic.TabIndex = 7;
            this.cboClinic.ValueMember = "Id";
            // 
            // bdsClinic
            // 
            this.bdsClinic.DataSource = typeof(Medical.Data.Entities.Clinic);
            // 
            // grdPlanning
            // 
            this.grdPlanning.AllowUserToAddRows = false;
            this.grdPlanning.AllowUserToDeleteRows = false;
            this.grdPlanning.AllowUserToResizeColumns = false;
            this.grdPlanning.AllowUserToResizeRows = false;
            this.grdPlanning.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPlanning.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPlanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medicineIdDataGridViewTextBoxColumn,
            this.inStockDataGridViewTextBoxColumn,
            this.lastMonthUsageDataGridViewTextBoxColumn,
            this.currentMonthUsageDataGridViewTextBoxColumn,
            this.requiredDataGridViewTextBoxColumn});
            this.grdPlanning.DataSource = this.bdsPlanningDetail;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPlanning.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlanning.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.grdPlanning.HighlightSelectedColumnHeaders = false;
            this.grdPlanning.Location = new System.Drawing.Point(0, 100);
            this.grdPlanning.MultiSelect = false;
            this.grdPlanning.Name = "grdPlanning";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPlanning.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPlanning.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdPlanning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPlanning.Size = new System.Drawing.Size(813, 404);
            this.grdPlanning.TabIndex = 8;
            this.grdPlanning.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdPlanning_DataBindingComplete);
            this.grdPlanning.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grdPlanning_RowsAdded);
            // 
            // medicineIdDataGridViewTextBoxColumn
            // 
            this.medicineIdDataGridViewTextBoxColumn.DataPropertyName = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn.DataSource = this.bdsMedicine;
            this.medicineIdDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.medicineIdDataGridViewTextBoxColumn.HeaderText = "Thuốc";
            this.medicineIdDataGridViewTextBoxColumn.Name = "medicineIdDataGridViewTextBoxColumn";
            this.medicineIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.medicineIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.medicineIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.medicineIdDataGridViewTextBoxColumn.ValueMember = "Id";
            this.medicineIdDataGridViewTextBoxColumn.Width = 200;
            // 
            // bdsMedicine
            // 
            this.bdsMedicine.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // inStockDataGridViewTextBoxColumn
            // 
            this.inStockDataGridViewTextBoxColumn.DataPropertyName = "InStock";
            this.inStockDataGridViewTextBoxColumn.HeaderText = "Trong kho";
            this.inStockDataGridViewTextBoxColumn.Name = "inStockDataGridViewTextBoxColumn";
            this.inStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.inStockDataGridViewTextBoxColumn.Width = 120;
            // 
            // lastMonthUsageDataGridViewTextBoxColumn
            // 
            this.lastMonthUsageDataGridViewTextBoxColumn.DataPropertyName = "LastMonthUsage";
            this.lastMonthUsageDataGridViewTextBoxColumn.HeaderText = "Lượng dùng tháng trước";
            this.lastMonthUsageDataGridViewTextBoxColumn.Name = "lastMonthUsageDataGridViewTextBoxColumn";
            this.lastMonthUsageDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastMonthUsageDataGridViewTextBoxColumn.Width = 150;
            // 
            // currentMonthUsageDataGridViewTextBoxColumn
            // 
            this.currentMonthUsageDataGridViewTextBoxColumn.DataPropertyName = "CurrentMonthUsage";
            this.currentMonthUsageDataGridViewTextBoxColumn.HeaderText = "Lượng dùng tháng này";
            this.currentMonthUsageDataGridViewTextBoxColumn.Name = "currentMonthUsageDataGridViewTextBoxColumn";
            this.currentMonthUsageDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentMonthUsageDataGridViewTextBoxColumn.Width = 150;
            // 
            // requiredDataGridViewTextBoxColumn
            // 
            this.requiredDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.requiredDataGridViewTextBoxColumn.DataPropertyName = "Required";
            this.requiredDataGridViewTextBoxColumn.HeaderText = "Dự trù";
            this.requiredDataGridViewTextBoxColumn.Name = "requiredDataGridViewTextBoxColumn";
            // 
            // bdsPlanningDetail
            // 
            this.bdsPlanningDetail.DataSource = typeof(Medical.Data.Entities.MedicinePlanDetail);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(326, 80);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(40, 15);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Ghi chú";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPlanning, "Note", true));
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.Location = new System.Drawing.Point(388, 77);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(331, 20);
            this.txtNote.TabIndex = 10;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(6, 80);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(52, 15);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            this.cboStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPlanning, "Status", true));
            this.cboStatus.DataSource = this.bdsStatus;
            this.cboStatus.DisplayMember = "Name";
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.Enabled = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 14;
            this.cboStatus.Location = new System.Drawing.Point(74, 77);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(159, 20);
            this.cboStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboStatus.TabIndex = 12;
            this.cboStatus.ValueMember = "Value";
            // 
            // bdsStatus
            // 
            this.bdsStatus.DataSource = typeof(Medical.Data.EntitiyExtend.Item);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(6, 56);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(61, 15);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "Người duyệt";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(326, 56);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(58, 15);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "Ngày duyệt";
            // 
            // txtYear
            // 
            // 
            // 
            // 
            this.txtYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtYear.DataBindings.Add(new System.Windows.Forms.Binding("ValueObject", this.bdsPlanning, "Year", true));
            this.txtYear.Location = new System.Drawing.Point(140, 6);
            this.txtYear.MaxValue = 2050;
            this.txtYear.MinValue = 1900;
            this.txtYear.Name = "txtYear";
            this.txtYear.ShowUpDown = true;
            this.txtYear.Size = new System.Drawing.Size(93, 20);
            this.txtYear.TabIndex = 5;
            this.txtYear.Value = 1900;
            this.txtYear.ValueChanged += new System.EventHandler(this.txtYear_ValueChanged);
            // 
            // txtApprovedDate
            // 
            // 
            // 
            // 
            this.txtApprovedDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtApprovedDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApprovedDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtApprovedDate.ButtonDropDown.Visible = true;
            this.txtApprovedDate.DataBindings.Add(new System.Windows.Forms.Binding("ValueObject", this.bdsPlanning, "ApproveDate", true));
            this.txtApprovedDate.Enabled = false;
            this.txtApprovedDate.IsPopupCalendarOpen = false;
            this.txtApprovedDate.Location = new System.Drawing.Point(388, 53);
            // 
            // 
            // 
            this.txtApprovedDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtApprovedDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtApprovedDate.MonthCalendar.BackgroundStyle.Class = "";
            this.txtApprovedDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApprovedDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.txtApprovedDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApprovedDate.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.txtApprovedDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtApprovedDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtApprovedDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtApprovedDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtApprovedDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtApprovedDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.txtApprovedDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApprovedDate.MonthCalendar.TodayButtonVisible = true;
            this.txtApprovedDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtApprovedDate.Name = "txtApprovedDate";
            this.txtApprovedDate.Size = new System.Drawing.Size(120, 20);
            this.txtApprovedDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtApprovedDate.TabIndex = 16;
            // 
            // panelEx1
            // 
            this.panelEx1.AutoSize = true;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.comboBoxEx1);
            this.panelEx1.Controls.Add(this.labelX9);
            this.panelEx1.Controls.Add(this.cboPerson);
            this.panelEx1.Controls.Add(this.txtDate);
            this.panelEx1.Controls.Add(this.txtApprovedDate);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.txtMonth);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.cboStatus);
            this.panelEx1.Controls.Add(this.txtYear);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.txtNote);
            this.panelEx1.Controls.Add(this.cboClinic);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(813, 100);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 17;
            this.panelEx1.ThemeAware = true;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPlanning, "ApproveId", true));
            this.comboBoxEx1.DataSource = this.bdsEmployee;
            this.comboBoxEx1.DisplayMember = "Name";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.Enabled = false;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 14;
            this.comboBoxEx1.Location = new System.Drawing.Point(74, 29);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(159, 20);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 19;
            this.comboBoxEx1.ValueMember = "Id";
            // 
            // bdsEmployee
            // 
            this.bdsEmployee.DataSource = typeof(Medical.Data.Entities.User);
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(6, 32);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(49, 15);
            this.labelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX9.TabIndex = 18;
            this.labelX9.Text = "Người lập";
            // 
            // cboPerson
            // 
            this.cboPerson.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPlanning, "ApproveId", true));
            this.cboPerson.DataSource = this.bdsEmployee;
            this.cboPerson.DisplayMember = "Name";
            this.cboPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPerson.Enabled = false;
            this.cboPerson.FormattingEnabled = true;
            this.cboPerson.ItemHeight = 14;
            this.cboPerson.Location = new System.Drawing.Point(74, 53);
            this.cboPerson.Name = "cboPerson";
            this.cboPerson.Size = new System.Drawing.Size(159, 20);
            this.cboPerson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPerson.TabIndex = 17;
            this.cboPerson.ValueMember = "Id";
            // 
            // panelEx2
            // 
            this.panelEx2.AutoSize = true;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.Controls.Add(this.btnClose);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 504);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panelEx2.Size = new System.Drawing.Size(813, 48);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 18;
            this.panelEx2.ThemeAware = true;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Medical.Properties.Resources.accept;
            this.btnSave.Location = new System.Drawing.Point(638, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Ghi lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Image = global::Medical.Properties.Resources.cancel;
            this.btnClose.Location = new System.Drawing.Point(724, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Bỏ qua";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MedicinePlanningDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 552);
            this.Controls.Add(this.grdPlanning);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "MedicinePlanningDetail";
            this.Text = "MedicinePlanningDetail";
            this.Load += new System.EventHandler(this.MedicinePlanningDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClinic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanningDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApprovedDate)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsEmployee)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtDate;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IntegerInput txtMonth;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboClinic;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdPlanning;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboStatus;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.Editors.IntegerInput txtYear;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtApprovedDate;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private System.Windows.Forms.BindingSource bdsPlanning;
        private System.Windows.Forms.BindingSource bdsPlanningDetail;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPerson;
        private System.Windows.Forms.BindingSource bdsEmployee;
        private System.Windows.Forms.BindingSource bdsClinic;
        private System.Windows.Forms.BindingSource bdsStatus;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX9;
        private System.Windows.Forms.BindingSource bdsMedicine;
        private System.Windows.Forms.DataGridViewComboBoxColumn medicineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastMonthUsageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentMonthUsageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredDataGridViewTextBoxColumn;
    }
}