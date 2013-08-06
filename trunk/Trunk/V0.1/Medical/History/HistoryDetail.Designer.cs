namespace Medical.History {
    partial class HistoryDetail {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryDetail));
            this.cboFigure = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsPrescription = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.medicineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolumnPerDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsPrescriptionDetail = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxX12 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescriptionDetail)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboFigure
            // 
            this.cboFigure.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsPrescription, "FigureId", true));
            this.cboFigure.DisplayMember = "Name";
            this.cboFigure.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFigure.Enabled = false;
            this.cboFigure.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFigure.FormattingEnabled = true;
            this.cboFigure.ItemHeight = 15;
            this.cboFigure.Location = new System.Drawing.Point(393, 43);
            this.cboFigure.Name = "cboFigure";
            this.cboFigure.Size = new System.Drawing.Size(200, 21);
            this.cboFigure.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboFigure.TabIndex = 3;
            this.cboFigure.ValueMember = "Id";
            // 
            // bdsPrescription
            // 
            this.bdsPrescription.DataSource = typeof(Medical.Data.Entities.Prescription);
            // 
            // textBoxX3
            // 
            this.textBoxX3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPrescription, "RecheckDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "dd/MM/yyyy"));
            this.textBoxX3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX3.ForeColor = System.Drawing.Color.Black;
            this.textBoxX3.Location = new System.Drawing.Point(393, 14);
            this.textBoxX3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.ReadOnly = true;
            this.textBoxX3.Size = new System.Drawing.Size(200, 21);
            this.textBoxX3.TabIndex = 1;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(319, 45);
            this.labelX3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(48, 16);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX3.TabIndex = 39;
            this.labelX3.Text = "Phác đồ ";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(319, 16);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(67, 16);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX4.TabIndex = 44;
            this.labelX4.Text = "Hẹn tái khám";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.medicineNameDataGridViewTextBoxColumn,
            this.TradeName,
            this.UnitName,
            this.VolumnPerDay,
            this.dayDataGridViewTextBoxColumn,
            this.Amount});
            this.dataGridViewX1.DataSource = this.bdsPrescriptionDetail;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(6, 236);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            this.dataGridViewX1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewX1.Size = new System.Drawing.Size(635, 229);
            this.dataGridViewX1.TabIndex = 5;
            this.dataGridViewX1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewX1DataBindingComplete);
            // 
            // medicineNameDataGridViewTextBoxColumn
            // 
            this.medicineNameDataGridViewTextBoxColumn.DataPropertyName = "MedicineName";
            this.medicineNameDataGridViewTextBoxColumn.HeaderText = "Tên biệt dược";
            this.medicineNameDataGridViewTextBoxColumn.Name = "medicineNameDataGridViewTextBoxColumn";
            this.medicineNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.medicineNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // TradeName
            // 
            this.TradeName.DataPropertyName = "TradeName";
            this.TradeName.HeaderText = "Hoạt chất";
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitName";
            this.UnitName.HeaderText = "Đơn vị";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            // 
            // VolumnPerDay
            // 
            this.VolumnPerDay.DataPropertyName = "VolumnPerDay";
            this.VolumnPerDay.HeaderText = "Liều lượng";
            this.VolumnPerDay.Name = "VolumnPerDay";
            this.VolumnPerDay.ReadOnly = true;
            this.VolumnPerDay.Width = 80;
            // 
            // dayDataGridViewTextBoxColumn
            // 
            this.dayDataGridViewTextBoxColumn.DataPropertyName = "Day";
            this.dayDataGridViewTextBoxColumn.HeaderText = "Số ngày";
            this.dayDataGridViewTextBoxColumn.Name = "dayDataGridViewTextBoxColumn";
            this.dayDataGridViewTextBoxColumn.ReadOnly = true;
            this.dayDataGridViewTextBoxColumn.Width = 80;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Số lượng";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // bdsPrescriptionDetail
            // 
            this.bdsPrescriptionDetail.DataSource = typeof(Medical.Data.Entities.PrescriptionDetail);
            // 
            // textBoxX12
            // 
            this.textBoxX12.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX12.Border.Class = "TextBoxBorder";
            this.textBoxX12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPrescription, "Note", true));
            this.textBoxX12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX12.ForeColor = System.Drawing.Color.Black;
            this.textBoxX12.Location = new System.Drawing.Point(6, 94);
            this.textBoxX12.Multiline = true;
            this.textBoxX12.Name = "textBoxX12";
            this.textBoxX12.ReadOnly = true;
            this.textBoxX12.Size = new System.Drawing.Size(635, 136);
            this.textBoxX12.TabIndex = 4;
            this.textBoxX12.Text = "-xin chao\r\n-benh ngay cang kho";
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.Class = "";
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX11.Location = new System.Drawing.Point(6, 72);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(60, 16);
            this.labelX11.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX11.TabIndex = 40;
            this.labelX11.Text = "Tình trạng ";
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPrescription, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "dd/MM/yyyy"));
            this.textBoxX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(70, 14);
            this.textBoxX1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.ReadOnly = true;
            this.textBoxX1.Size = new System.Drawing.Size(200, 21);
            this.textBoxX1.TabIndex = 0;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(6, 16);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(57, 16);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX2.TabIndex = 37;
            this.labelX2.Text = "Ngày khám";
            // 
            // textBoxX4
            // 
            this.textBoxX4.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsPrescription, "DoctorName", true));
            this.textBoxX4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxX4.ForeColor = System.Drawing.Color.Black;
            this.textBoxX4.Location = new System.Drawing.Point(70, 43);
            this.textBoxX4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.ReadOnly = true;
            this.textBoxX4.Size = new System.Drawing.Size(200, 21);
            this.textBoxX4.TabIndex = 2;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(6, 45);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(31, 16);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.labelX1.TabIndex = 35;
            this.labelX1.Text = "Bác sĩ";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnDelete);
            this.panelEx1.Controls.Add(this.btnClose);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 471);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(648, 43);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 47;
            this.panelEx1.ThemeAware = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Image = global::Medical.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(395, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 24);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Image = global::Medical.Properties.Resources.accept;
            this.btnClose.Location = new System.Drawing.Point(521, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 24);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng lại";
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // panelEx2
            // 
            this.panelEx2.AutoSize = true;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.textBoxX12);
            this.panelEx2.Controls.Add(this.cboFigure);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.textBoxX3);
            this.panelEx2.Controls.Add(this.textBoxX4);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.textBoxX1);
            this.panelEx2.Controls.Add(this.dataGridViewX1);
            this.panelEx2.Controls.Add(this.labelX11);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(648, 471);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 48;
            this.panelEx2.ThemeAware = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // HistoryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 514);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistoryDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết";
            this.Load += new System.EventHandler(this.HistoryDetailLoad);
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPrescriptionDetail)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cboFigure;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX12;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.BindingSource bdsPrescription;
        private System.Windows.Forms.BindingSource bdsPrescriptionDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumnPerDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}