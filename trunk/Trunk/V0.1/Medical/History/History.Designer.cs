namespace Medical.History
{
    partial class History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.patientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recheckDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.figureNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsPrescriptionHistory = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescriptionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.txtDate);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(3, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(822, 40);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            this.panelEx1.ThemeAware = true;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(4, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(27, 16);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Ngày";
            // 
            // txtDate
            // 
            // 
            // 
            // 
            this.txtDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDate.ButtonCustom.Image = global::Medical.Properties.Resources.calendar;
            this.txtDate.ButtonDropDown.Image = global::Medical.Properties.Resources.calendar;
            this.txtDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.txtDate.ButtonDropDown.Visible = true;
            this.txtDate.CustomFormat = "dd/MM/yyyy";
            this.txtDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.txtDate.IsPopupCalendarOpen = false;
            this.txtDate.Location = new System.Drawing.Point(36, 8);
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
            this.txtDate.MonthCalendar.DisplayMonth = new System.DateTime(2012, 12, 1, 0, 0, 0, 0);
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
            this.txtDate.Size = new System.Drawing.Size(110, 21);
            this.txtDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtDate.TabIndex = 0;
            this.txtDate.TextChanged += new System.EventHandler(this.TxtDateTextChanged);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientNameDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.doctorNameDataGridViewTextBoxColumn,
            this.recheckDateDataGridViewTextBoxColumn,
            this.figureNameDataGridViewTextBoxColumn,
            this.Note});
            this.dataGridViewX1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewX1.DataSource = this.bdsPrescriptionHistory;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridViewX1.HighlightSelectedColumnHeaders = false;
            this.dataGridViewX1.Location = new System.Drawing.Point(3, 40);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(822, 452);
            this.dataGridViewX1.TabIndex = 3;
            this.dataGridViewX1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewX1CellDoubleClick);
            this.dataGridViewX1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewX1DataBindingComplete);
            this.dataGridViewX1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewX1_KeyDown);
            // 
            // patientNameDataGridViewTextBoxColumn
            // 
            this.patientNameDataGridViewTextBoxColumn.DataPropertyName = "PatientName";
            this.patientNameDataGridViewTextBoxColumn.HeaderText = "Bệnh nhân";
            this.patientNameDataGridViewTextBoxColumn.Name = "patientNameDataGridViewTextBoxColumn";
            this.patientNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.patientNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            dataGridViewCellStyle2.Format = "HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.lastUpdatedDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "Thời gian";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doctorNameDataGridViewTextBoxColumn
            // 
            this.doctorNameDataGridViewTextBoxColumn.DataPropertyName = "DoctorName";
            this.doctorNameDataGridViewTextBoxColumn.HeaderText = "Bác sĩ";
            this.doctorNameDataGridViewTextBoxColumn.Name = "doctorNameDataGridViewTextBoxColumn";
            this.doctorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.doctorNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // recheckDateDataGridViewTextBoxColumn
            // 
            this.recheckDateDataGridViewTextBoxColumn.DataPropertyName = "RecheckDate";
            this.recheckDateDataGridViewTextBoxColumn.HeaderText = "Hẹn tái khám";
            this.recheckDateDataGridViewTextBoxColumn.Name = "recheckDateDataGridViewTextBoxColumn";
            this.recheckDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // figureNameDataGridViewTextBoxColumn
            // 
            this.figureNameDataGridViewTextBoxColumn.DataPropertyName = "FigureName";
            this.figureNameDataGridViewTextBoxColumn.HeaderText = "Phác đồ";
            this.figureNameDataGridViewTextBoxColumn.Name = "figureNameDataGridViewTextBoxColumn";
            this.figureNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Note
            // 
            this.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Note.DataPropertyName = "Note";
            this.Note.HeaderText = "Tình trạng ";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.btnDetail});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Medical.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.btnDelete.Size = new System.Drawing.Size(137, 22);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnDetail
            // 
            this.btnDetail.Image = global::Medical.Properties.Resources.document;
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(137, 22);
            this.btnDetail.Text = "Xem chi tiết";
            this.btnDetail.Click += new System.EventHandler(this.BtnDetailClick);
            // 
            // bdsPrescriptionHistory
            // 
            this.bdsPrescriptionHistory.DataSource = typeof(Medical.Data.Entities.Prescription);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 495);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "History";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "Nhật ký khám bệnh";
            this.Load += new System.EventHandler(this.HistoryLoad);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescriptionHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource bdsPrescriptionHistory;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput txtDate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnDelete;
        private System.Windows.Forms.ToolStripMenuItem btnDetail;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recheckDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn figureNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}