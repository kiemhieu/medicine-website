namespace Medical {
    partial class CheckUpRegister {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.txtStatus = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bdsPrescription = new System.Windows.Forms.BindingSource(this.components);
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.bdsMedicine = new System.Windows.Forms.BindingSource(this.components);
            this.bdsPrescriptionDetail = new System.Windows.Forms.BindingSource(this.components);
            this.labelX14 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.txtDoctor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cboFigure = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.volumnPerDayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCheckDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtReCheckDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnDeleteMedicine = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.errPro = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescriptionDetail)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReCheckDate)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errPro)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX13
            // 
            this.labelX13.AutoSize = true;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.Class = "";
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(235, 13);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(73, 16);
            this.labelX13.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX13.TabIndex = 28;
            this.labelX13.Text = "Hẹn tái khám";
            // 
            // labelX12
            // 
            this.labelX12.AutoSize = true;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.Class = "";
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(14, 192);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(86, 16);
            this.labelX12.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX12.TabIndex = 26;
            this.labelX12.Text = "Phác đồ điều trị";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtStatus.Border.Class = "TextBoxBorder";
            this.txtStatus.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPrescription, "Note", true));
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.Location = new System.Drawing.Point(106, 36);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(676, 150);
            this.txtStatus.TabIndex = 31;
            this.txtStatus.Text = "-xin chao\r\n-benh ngay cang kho";
            // 
            // bdsPrescription
            // 
            this.bdsPrescription.DataSource = typeof(Medical.Data.Entities.Prescription);
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(14, 36);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(87, 16);
            this.labelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX11.TabIndex = 30;
            this.labelX11.Text = "Tình trạng bệnh";
            // 
            // bdsMedicine
            // 
            this.bdsMedicine.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // bdsPrescriptionDetail
            // 
            this.bdsPrescriptionDetail.DataSource = typeof(Medical.Data.Entities.PrescriptionDetail);
            this.bdsPrescriptionDetail.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bdsPrescriptionDetail_ListChanged);
            // 
            // labelX14
            // 
            this.labelX14.AutoSize = true;
            // 
            // 
            // 
            this.labelX14.BackgroundStyle.Class = "";
            this.labelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX14.Location = new System.Drawing.Point(14, 215);
            this.labelX14.Name = "labelX14";
            this.labelX14.Size = new System.Drawing.Size(58, 16);
            this.labelX14.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX14.TabIndex = 32;
            this.labelX14.Text = "Đơn thuốc";
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.Class = "";
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(538, 13);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(36, 16);
            this.labelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX10.TabIndex = 34;
            this.labelX10.Text = "Bác sĩ";
            // 
            // txtDoctor
            // 
            this.txtDoctor.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDoctor.Border.Class = "TextBoxBorder";
            this.txtDoctor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDoctor.ButtonCustom.Image = global::Medical.Properties.Resources.doctor;
            this.txtDoctor.ForeColor = System.Drawing.Color.Black;
            this.txtDoctor.Location = new System.Drawing.Point(582, 11);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.ReadOnly = true;
            this.txtDoctor.Size = new System.Drawing.Size(200, 21);
            this.txtDoctor.TabIndex = 35;
            this.txtDoctor.WatermarkImage = global::Medical.Properties.Resources.doctor;
            // 
            // cboFigure
            // 
            this.cboFigure.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPrescription, "FigureId", true));
            this.cboFigure.DisplayMember = "Name";
            this.cboFigure.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFigure.FormattingEnabled = true;
            this.cboFigure.ItemHeight = 15;
            this.cboFigure.Location = new System.Drawing.Point(106, 190);
            this.cboFigure.Name = "cboFigure";
            this.cboFigure.Size = new System.Drawing.Size(200, 21);
            this.cboFigure.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboFigure.TabIndex = 36;
            this.cboFigure.ValueMember = "Id";
            this.cboFigure.SelectedIndexChanged += new System.EventHandler(this.cboFigure_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(14, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(63, 16);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX1.TabIndex = 39;
            this.labelX1.Text = "Ngày khám";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewX1);
            this.panel1.Controls.Add(this.txtCheckDate);
            this.panel1.Controls.Add(this.txtReCheckDate);
            this.panel1.Controls.Add(this.btnDeleteMedicine);
            this.panel1.Controls.Add(this.labelX10);
            this.panel1.Controls.Add(this.buttonX3);
            this.panel1.Controls.Add(this.txtDoctor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 409);
            this.panel1.TabIndex = 41;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.medicineIdDataGridViewTextBoxColumn,
            this.volumnPerDayDataGridViewTextBoxColumn,
            this.dayDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridViewX1.DataSource = this.bdsPrescriptionDetail;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(106, 215);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(676, 188);
            this.dataGridViewX1.TabIndex = 43;
            this.dataGridViewX1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewX1_CellBeginEdit);
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.noDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.noDataGridViewTextBoxColumn.HeaderText = "Stt";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 30;
            // 
            // medicineIdDataGridViewTextBoxColumn
            // 
            this.medicineIdDataGridViewTextBoxColumn.DataPropertyName = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn.DataSource = this.bdsMedicine;
            this.medicineIdDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.medicineIdDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.medicineIdDataGridViewTextBoxColumn.HeaderText = "Thuốc";
            this.medicineIdDataGridViewTextBoxColumn.Name = "medicineIdDataGridViewTextBoxColumn";
            this.medicineIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.medicineIdDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.medicineIdDataGridViewTextBoxColumn.ValueMember = "Id";
            this.medicineIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // volumnPerDayDataGridViewTextBoxColumn
            // 
            this.volumnPerDayDataGridViewTextBoxColumn.DataPropertyName = "VolumnPerDay";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.volumnPerDayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.volumnPerDayDataGridViewTextBoxColumn.HeaderText = "Hệ số";
            this.volumnPerDayDataGridViewTextBoxColumn.Name = "volumnPerDayDataGridViewTextBoxColumn";
            this.volumnPerDayDataGridViewTextBoxColumn.Width = 70;
            // 
            // dayDataGridViewTextBoxColumn
            // 
            this.dayDataGridViewTextBoxColumn.DataPropertyName = "Day";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dayDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dayDataGridViewTextBoxColumn.HeaderText = "Ngày";
            this.dayDataGridViewTextBoxColumn.Name = "dayDataGridViewTextBoxColumn";
            this.dayDataGridViewTextBoxColumn.Width = 70;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.amountDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Ghi chú";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // txtCheckDate
            // 
            // 
            // 
            // 
            this.txtCheckDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCheckDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCheckDate.ButtonDropDown.Image = global::Medical.Properties.Resources.calendar_blue_01;
            this.txtCheckDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtCheckDate.ButtonDropDown.Visible = true;
            this.txtCheckDate.CustomFormat = "dd/MM/yyyy";
            this.txtCheckDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdsPrescription, "Date", true));
            this.txtCheckDate.Enabled = false;
            this.txtCheckDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtCheckDate.IsInputReadOnly = true;
            this.txtCheckDate.IsPopupCalendarOpen = false;
            this.txtCheckDate.Location = new System.Drawing.Point(106, 11);
            // 
            // 
            // 
            this.txtCheckDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtCheckDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtCheckDate.MonthCalendar.BackgroundStyle.Class = "";
            this.txtCheckDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCheckDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.txtCheckDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCheckDate.MonthCalendar.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            this.txtCheckDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtCheckDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtCheckDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtCheckDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtCheckDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtCheckDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.txtCheckDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCheckDate.MonthCalendar.TodayButtonVisible = true;
            this.txtCheckDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtCheckDate.Name = "txtCheckDate";
            this.txtCheckDate.Size = new System.Drawing.Size(110, 21);
            this.txtCheckDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtCheckDate.TabIndex = 42;
            // 
            // txtReCheckDate
            // 
            // 
            // 
            // 
            this.txtReCheckDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtReCheckDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReCheckDate.ButtonDropDown.Image = global::Medical.Properties.Resources.calendar_blue_01;
            this.txtReCheckDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtReCheckDate.ButtonDropDown.Visible = true;
            this.txtReCheckDate.CustomFormat = "dd/MM/yyyy";
            this.txtReCheckDate.DataBindings.Add(new System.Windows.Forms.Binding("ValueObject", this.bdsPrescription, "RecheckDate", true));
            this.txtReCheckDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtReCheckDate.IsPopupCalendarOpen = false;
            this.txtReCheckDate.Location = new System.Drawing.Point(314, 11);
            // 
            // 
            // 
            this.txtReCheckDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtReCheckDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.txtReCheckDate.MonthCalendar.BackgroundStyle.Class = "";
            this.txtReCheckDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReCheckDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.txtReCheckDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReCheckDate.MonthCalendar.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            this.txtReCheckDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.txtReCheckDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.txtReCheckDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.txtReCheckDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.txtReCheckDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.txtReCheckDate.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.txtReCheckDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtReCheckDate.MonthCalendar.TodayButtonVisible = true;
            this.txtReCheckDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.txtReCheckDate.Name = "txtReCheckDate";
            this.txtReCheckDate.Size = new System.Drawing.Size(110, 21);
            this.txtReCheckDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtReCheckDate.TabIndex = 41;
            this.txtReCheckDate.ValueObjectChanged += new System.EventHandler(this.txtReCheckDate_ValueObjectChanged);
            // 
            // btnDeleteMedicine
            // 
            this.btnDeleteMedicine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteMedicine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteMedicine.Image = global::Medical.Properties.Resources.remove;
            this.btnDeleteMedicine.Location = new System.Drawing.Point(735, 191);
            this.btnDeleteMedicine.Name = "btnDeleteMedicine";
            this.btnDeleteMedicine.Size = new System.Drawing.Size(20, 20);
            this.btnDeleteMedicine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteMedicine.TabIndex = 40;
            this.btnDeleteMedicine.Click += new System.EventHandler(this.btnDeleteMedicine_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Image = global::Medical.Properties.Resources.add;
            this.buttonX3.Location = new System.Drawing.Point(761, 191);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(20, 20);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 60);
            this.panel2.TabIndex = 42;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = global::Medical.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(695, 15);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 30);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Medical.Properties.Resources.accept;
            this.btnSave.Location = new System.Drawing.Point(602, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 30);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Ghi lại";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errPro
            // 
            this.errPro.ContainerControl = this;
            // 
            // CheckUpRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 469);
            this.ControlBox = false;
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cboFigure);
            this.Controls.Add(this.labelX14);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.labelX11);
            this.Controls.Add(this.labelX13);
            this.Controls.Add(this.labelX12);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CheckUpRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lập đơn thuốc";
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescriptionDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCheckDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReCheckDate)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errPro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.Controls.TextBoxX txtStatus;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX14;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDoctor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboFigure;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bdsPrescription;
        private System.Windows.Forms.BindingSource bdsPrescriptionDetail;
        private DevComponents.DotNetBar.ButtonX btnDeleteMedicine;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtCheckDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtReCheckDate;
        private System.Windows.Forms.BindingSource bdsMedicine;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn medicineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumnPerDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ErrorProvider errPro;
    }
}