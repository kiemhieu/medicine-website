namespace Medical.WareHouseIE
{
    partial class WareHouseImport {
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnRemove = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtClinic = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtRecipient = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txtOriginalNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bdsWareHouse = new System.Windows.Forms.BindingSource(this.components);
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtPhone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtDeliverer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dateImport = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.grd = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bdsMeidcine = new System.Windows.Forms.BindingSource(this.components);
            this.bdsWareHouseIODetail = new System.Windows.Forms.BindingSource(this.components);
            this.cboMedicine = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expireDateDataGridViewTextBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWareHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMeidcine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWareHouseIODetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.AutoSize = true;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnRemove);
            this.panelEx1.Controls.Add(this.btnSave);
            this.panelEx1.Controls.Add(this.txtClinic);
            this.panelEx1.Controls.Add(this.txtRecipient);
            this.panelEx1.Controls.Add(this.labelX9);
            this.panelEx1.Controls.Add(this.labelX8);
            this.panelEx1.Controls.Add(this.txtOriginalNo);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.txtNote);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.txtAddress);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtPhone);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.txtDeliverer);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.txtNo);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.dateImport);
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(864, 517);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            this.panelEx1.ThemeAware = true;
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Image = global::Medical.Properties.Resources.cancel;
            this.btnRemove.Location = new System.Drawing.Point(655, 75);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(64, 23);
            this.btnRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemove.TabIndex = 22;
            this.btnRemove.Text = "Hủy";
            this.btnRemove.ThemeAware = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Medical.Properties.Resources.add;
            this.btnSave.Location = new System.Drawing.Point(729, 75);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Thêm mới";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtClinic
            // 
            this.txtClinic.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtClinic.Border.Class = "TextBoxBorder";
            this.txtClinic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClinic.ForeColor = System.Drawing.Color.Black;
            this.txtClinic.Location = new System.Drawing.Point(502, 2);
            this.txtClinic.Name = "txtClinic";
            this.txtClinic.ReadOnly = true;
            this.txtClinic.Size = new System.Drawing.Size(314, 20);
            this.txtClinic.TabIndex = 18;
            // 
            // txtRecipient
            // 
            this.txtRecipient.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRecipient.Border.Class = "TextBoxBorder";
            this.txtRecipient.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRecipient.ForeColor = System.Drawing.Color.Black;
            this.txtRecipient.Location = new System.Drawing.Point(87, 48);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(130, 20);
            this.txtRecipient.TabIndex = 17;
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(3, 51);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(79, 15);
            this.labelX9.TabIndex = 16;
            this.labelX9.Text = "Người lập phiếu";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(461, 5);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(22, 15);
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "Kho";
            // 
            // txtOriginalNo
            // 
            this.txtOriginalNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtOriginalNo.Border.Class = "TextBoxBorder";
            this.txtOriginalNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOriginalNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "AttachmentNo", true));
            this.txtOriginalNo.ForeColor = System.Drawing.Color.Black;
            this.txtOriginalNo.Location = new System.Drawing.Point(87, 71);
            this.txtOriginalNo.Name = "txtOriginalNo";
            this.txtOriginalNo.Size = new System.Drawing.Size(130, 20);
            this.txtOriginalNo.TabIndex = 13;
            // 
            // bdsWareHouse
            // 
            this.bdsWareHouse.DataSource = typeof(Medical.Data.Entities.WareHouseIO);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(3, 75);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(82, 15);
            this.labelX7.TabIndex = 12;
            this.labelX7.Text = "Số chứng từ gốc";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "Note", true));
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.Location = new System.Drawing.Point(301, 50);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(515, 20);
            this.txtNote.TabIndex = 11;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(242, 53);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(57, 15);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "Lý do nhập";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAddress.Border.Class = "TextBoxBorder";
            this.txtAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "Address", true));
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.Location = new System.Drawing.Point(502, 25);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(315, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(461, 28);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(36, 15);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "Địa chỉ";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPhone.Border.Class = "TextBoxBorder";
            this.txtPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "Phone", true));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.Location = new System.Drawing.Point(301, 25);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(130, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(242, 28);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(28, 15);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Số đt";
            // 
            // txtDeliverer
            // 
            this.txtDeliverer.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDeliverer.Border.Class = "TextBoxBorder";
            this.txtDeliverer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDeliverer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "Person", true));
            this.txtDeliverer.ForeColor = System.Drawing.Color.Black;
            this.txtDeliverer.Location = new System.Drawing.Point(87, 25);
            this.txtDeliverer.Name = "txtDeliverer";
            this.txtDeliverer.Size = new System.Drawing.Size(130, 20);
            this.txtDeliverer.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(3, 28);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(55, 15);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Người giao";
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNo.Border.Class = "TextBoxBorder";
            this.txtNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "No", true));
            this.txtNo.ForeColor = System.Drawing.Color.Black;
            this.txtNo.Location = new System.Drawing.Point(301, 2);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(130, 20);
            this.txtNo.TabIndex = 3;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(242, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(46, 15);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Số phiếu";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(28, 15);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Ngày";
            // 
            // dateImport
            // 
            // 
            // 
            // 
            this.dateImport.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateImport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateImport.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateImport.ButtonDropDown.Visible = true;
            this.dateImport.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bdsWareHouse, "Date", true));
            this.dateImport.IsPopupCalendarOpen = false;
            this.dateImport.Location = new System.Drawing.Point(87, 2);
            // 
            // 
            // 
            this.dateImport.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateImport.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateImport.MonthCalendar.BackgroundStyle.Class = "";
            this.dateImport.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateImport.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateImport.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateImport.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dateImport.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateImport.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateImport.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateImport.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateImport.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateImport.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateImport.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateImport.MonthCalendar.TodayButtonVisible = true;
            this.dateImport.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateImport.Name = "dateImport";
            this.dateImport.Size = new System.Drawing.Size(130, 20);
            this.dateImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateImport.TabIndex = 0;
            // 
            // grd
            // 
            this.grd.AutoGenerateColumns = false;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cboMedicine,
            this.lotNoDataGridViewTextBoxColumn,
            this.UnitName,
            this.expireDateDataGridViewTextBoxColumn,
            this.Qty,
            this.UnitPrice,
            this.Amount,
            this.MedicineId,
            this.Unit});
            this.grd.DataSource = this.bdsWareHouseIODetail;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle1;
            this.grd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.grd.Location = new System.Drawing.Point(0, 116);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(864, 411);
            this.grd.TabIndex = 2;
            this.grd.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CellEndEdit);
            this.grd.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grd_DataError);
            // 
            // bdsMeidcine
            // 
            this.bdsMeidcine.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // bdsWareHouseIODetail
            // 
            this.bdsWareHouseIODetail.DataSource = typeof(Medical.Data.Entities.WareHouseIODetail);
            // 
            // cboMedicine
            // 
            this.cboMedicine.DataSource = this.bdsMeidcine;
            this.cboMedicine.DisplayMember = "Name";
            this.cboMedicine.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cboMedicine.HeaderText = "Tên thuốc";
            this.cboMedicine.Name = "cboMedicine";
            this.cboMedicine.ValueMember = "Id";
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "Số lô";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            // 
            // UnitName
            // 
            this.UnitName.HeaderText = "Đơn vị";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // expireDateDataGridViewTextBoxColumn
            // 
            // 
            // 
            // 
            this.expireDateDataGridViewTextBoxColumn.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.expireDateDataGridViewTextBoxColumn.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.expireDateDataGridViewTextBoxColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.expireDateDataGridViewTextBoxColumn.BackgroundStyle.TextColor = System.Drawing.Color.Black;
            this.expireDateDataGridViewTextBoxColumn.DataPropertyName = "ExpireDate";
            this.expireDateDataGridViewTextBoxColumn.HeaderText = "Ngày hết hạn";
            this.expireDateDataGridViewTextBoxColumn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.Class = "";
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.DisplayMonth = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.expireDateDataGridViewTextBoxColumn.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.expireDateDataGridViewTextBoxColumn.Name = "expireDateDataGridViewTextBoxColumn";
            this.expireDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "Số lượng";
            this.Qty.Name = "Qty";
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            this.UnitPrice.HeaderText = "Giá thuốc";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Thành tiền";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // MedicineId
            // 
            this.MedicineId.DataPropertyName = "MedicineId";
            this.MedicineId.HeaderText = "MedicineId";
            this.MedicineId.Name = "MedicineId";
            this.MedicineId.Visible = false;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.Visible = false;
            // 
            // WareHouseImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 517);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WareHouseImport";
            this.Text = "Nhập kho";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWareHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMeidcine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWareHouseIODetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOriginalNo;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAddress;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPhone;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDeliverer;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNo;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateImport;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.BindingSource bdsWareHouseIODetail;
        private System.Windows.Forms.BindingSource bdsWareHouse;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRecipient;
        private DevComponents.DotNetBar.Controls.TextBoxX txtClinic;
        private DevComponents.DotNetBar.ButtonX btnRemove;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.BindingSource bdsMeidcine;
        private DevComponents.DotNetBar.Controls.DataGridViewX grd;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboMedicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn expireDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;

    }
}