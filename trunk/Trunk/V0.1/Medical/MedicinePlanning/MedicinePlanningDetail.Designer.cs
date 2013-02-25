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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.bdsPlanning = new System.Windows.Forms.BindingSource(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtMonth = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cboClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsClinic = new System.Windows.Forms.BindingSource(this.components);
            this.grdPlanning = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastMonthUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentMonthUsageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsPlanningDetail = new System.Windows.Forms.BindingSource(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsStatus = new System.Windows.Forms.BindingSource(this.components);
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtYear = new DevComponents.Editors.IntegerInput();
            this.txtApprovedDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cboPerson = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClinic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanning)).BeginInit();
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
            this.labelX1.Location = new System.Drawing.Point(5, 6);
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
            this.txtDate.IsPopupCalendarOpen = false;
            this.txtDate.Location = new System.Drawing.Point(71, 3);
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
            this.txtDate.Size = new System.Drawing.Size(110, 20);
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
            this.labelX2.Location = new System.Drawing.Point(545, 6);
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
            this.txtMonth.Location = new System.Drawing.Point(585, 3);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ShowUpDown = true;
            this.txtMonth.Size = new System.Drawing.Size(60, 20);
            this.txtMonth.TabIndex = 3;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(234, 6);
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
            this.cboClinic.FormattingEnabled = true;
            this.cboClinic.ItemHeight = 14;
            this.cboClinic.Location = new System.Drawing.Point(298, 3);
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
            this.grdPlanning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlanning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.planIdDataGridViewTextBoxColumn,
            this.medicineIdDataGridViewTextBoxColumn,
            this.inStockDataGridViewTextBoxColumn,
            this.lastMonthUsageDataGridViewTextBoxColumn,
            this.currentMonthUsageDataGridViewTextBoxColumn,
            this.requiredDataGridViewTextBoxColumn,
            this.unitPriceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.medicineDataGridViewTextBoxColumn,
            this.unitNameDataGridViewTextBoxColumn,
            this.remainingDataGridViewTextBoxColumn,
            this.medicineNameDataGridViewTextBoxColumn});
            this.grdPlanning.DataSource = this.bdsPlanningDetail;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPlanning.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPlanning.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.grdPlanning.Location = new System.Drawing.Point(0, 72);
            this.grdPlanning.Name = "grdPlanning";
            this.grdPlanning.Size = new System.Drawing.Size(799, 340);
            this.grdPlanning.TabIndex = 8;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // planIdDataGridViewTextBoxColumn
            // 
            this.planIdDataGridViewTextBoxColumn.DataPropertyName = "PlanId";
            this.planIdDataGridViewTextBoxColumn.HeaderText = "PlanId";
            this.planIdDataGridViewTextBoxColumn.Name = "planIdDataGridViewTextBoxColumn";
            // 
            // medicineIdDataGridViewTextBoxColumn
            // 
            this.medicineIdDataGridViewTextBoxColumn.DataPropertyName = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn.HeaderText = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn.Name = "medicineIdDataGridViewTextBoxColumn";
            // 
            // inStockDataGridViewTextBoxColumn
            // 
            this.inStockDataGridViewTextBoxColumn.DataPropertyName = "InStock";
            this.inStockDataGridViewTextBoxColumn.HeaderText = "InStock";
            this.inStockDataGridViewTextBoxColumn.Name = "inStockDataGridViewTextBoxColumn";
            // 
            // lastMonthUsageDataGridViewTextBoxColumn
            // 
            this.lastMonthUsageDataGridViewTextBoxColumn.DataPropertyName = "LastMonthUsage";
            this.lastMonthUsageDataGridViewTextBoxColumn.HeaderText = "LastMonthUsage";
            this.lastMonthUsageDataGridViewTextBoxColumn.Name = "lastMonthUsageDataGridViewTextBoxColumn";
            // 
            // currentMonthUsageDataGridViewTextBoxColumn
            // 
            this.currentMonthUsageDataGridViewTextBoxColumn.DataPropertyName = "CurrentMonthUsage";
            this.currentMonthUsageDataGridViewTextBoxColumn.HeaderText = "CurrentMonthUsage";
            this.currentMonthUsageDataGridViewTextBoxColumn.Name = "currentMonthUsageDataGridViewTextBoxColumn";
            // 
            // requiredDataGridViewTextBoxColumn
            // 
            this.requiredDataGridViewTextBoxColumn.DataPropertyName = "Required";
            this.requiredDataGridViewTextBoxColumn.HeaderText = "Required";
            this.requiredDataGridViewTextBoxColumn.Name = "requiredDataGridViewTextBoxColumn";
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            // 
            // medicineDataGridViewTextBoxColumn
            // 
            this.medicineDataGridViewTextBoxColumn.DataPropertyName = "Medicine";
            this.medicineDataGridViewTextBoxColumn.HeaderText = "Medicine";
            this.medicineDataGridViewTextBoxColumn.Name = "medicineDataGridViewTextBoxColumn";
            // 
            // unitNameDataGridViewTextBoxColumn
            // 
            this.unitNameDataGridViewTextBoxColumn.DataPropertyName = "UnitName";
            this.unitNameDataGridViewTextBoxColumn.HeaderText = "UnitName";
            this.unitNameDataGridViewTextBoxColumn.Name = "unitNameDataGridViewTextBoxColumn";
            // 
            // remainingDataGridViewTextBoxColumn
            // 
            this.remainingDataGridViewTextBoxColumn.DataPropertyName = "Remaining";
            this.remainingDataGridViewTextBoxColumn.HeaderText = "Remaining";
            this.remainingDataGridViewTextBoxColumn.Name = "remainingDataGridViewTextBoxColumn";
            this.remainingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // medicineNameDataGridViewTextBoxColumn
            // 
            this.medicineNameDataGridViewTextBoxColumn.DataPropertyName = "MedicineName";
            this.medicineNameDataGridViewTextBoxColumn.HeaderText = "MedicineName";
            this.medicineNameDataGridViewTextBoxColumn.Name = "medicineNameDataGridViewTextBoxColumn";
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
            this.labelX5.Location = new System.Drawing.Point(5, 29);
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
            this.txtNote.Location = new System.Drawing.Point(71, 26);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(433, 20);
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
            this.labelX6.Location = new System.Drawing.Point(5, 52);
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
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 14;
            this.cboStatus.Location = new System.Drawing.Point(71, 49);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(110, 20);
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
            this.labelX7.Location = new System.Drawing.Point(234, 52);
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
            this.labelX8.Location = new System.Drawing.Point(523, 52);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(58, 15);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "Ngày duyệt";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(682, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(26, 15);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Năm";
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
            this.txtYear.Location = new System.Drawing.Point(712, 3);
            this.txtYear.Name = "txtYear";
            this.txtYear.ShowUpDown = true;
            this.txtYear.Size = new System.Drawing.Size(81, 20);
            this.txtYear.TabIndex = 5;
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
            this.txtApprovedDate.IsPopupCalendarOpen = false;
            this.txtApprovedDate.Location = new System.Drawing.Point(585, 49);
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
            this.panelEx1.Controls.Add(this.cboPerson);
            this.panelEx1.Controls.Add(this.txtDate);
            this.panelEx1.Controls.Add(this.txtApprovedDate);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.txtMonth);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.labelX3);
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
            this.panelEx1.Size = new System.Drawing.Size(799, 72);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 17;
            this.panelEx1.ThemeAware = true;
            // 
            // cboPerson
            // 
            this.cboPerson.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPlanning, "ApproveId", true));
            this.cboPerson.DataSource = this.bdsEmployee;
            this.cboPerson.DisplayMember = "Name";
            this.cboPerson.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPerson.FormattingEnabled = true;
            this.cboPerson.ItemHeight = 14;
            this.cboPerson.Location = new System.Drawing.Point(298, 49);
            this.cboPerson.Name = "cboPerson";
            this.cboPerson.Size = new System.Drawing.Size(159, 20);
            this.cboPerson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPerson.TabIndex = 17;
            this.cboPerson.ValueMember = "Id";
            // 
            // bdsEmployee
            // 
            this.bdsEmployee.DataSource = typeof(Medical.Data.Entities.User);
            // 
            // panelEx2
            // 
            this.panelEx2.AutoSize = true;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.buttonX2);
            this.panelEx2.Controls.Add(this.buttonX1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 412);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(799, 32);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 18;
            this.panelEx2.ThemeAware = true;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Image = global::Medical.Properties.Resources.accept;
            this.buttonX2.Location = new System.Drawing.Point(645, 6);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "Ghi lại";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Image = global::Medical.Properties.Resources.cancel;
            this.buttonX1.Location = new System.Drawing.Point(724, 6);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "Bỏ qua";
            // 
            // MedicinePlanningDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 444);
            this.Controls.Add(this.grdPlanning);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Name = "MedicinePlanningDetail";
            this.Text = "MedicinePlanningDetail";
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClinic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPlanning)).EndInit();
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
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput txtYear;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtApprovedDate;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bdsPlanning;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastMonthUsageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentMonthUsageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remainingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bdsPlanningDetail;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPerson;
        private System.Windows.Forms.BindingSource bdsEmployee;
        private System.Windows.Forms.BindingSource bdsClinic;
        private System.Windows.Forms.BindingSource bdsStatus;
    }
}