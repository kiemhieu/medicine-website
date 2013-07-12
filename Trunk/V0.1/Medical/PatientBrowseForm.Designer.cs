namespace Medical {
    partial class PatientBrowseForm {
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
            this.grdPatient = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdgPatient = new System.Windows.Forms.BindingSource(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPatientName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtBirthYear = new DevComponents.Editors.IntegerInput();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtCode = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthYear)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPatient
            // 
            this.grdPatient.AllowUserToAddRows = false;
            this.grdPatient.AllowUserToDeleteRows = false;
            this.grdPatient.AllowUserToResizeRows = false;
            this.grdPatient.AutoGenerateColumns = false;
            this.grdPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.birthYearDataGridViewTextBoxColumn,
            this.sexualDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn});
            this.grdPatient.DataSource = this.bdgPatient;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPatient.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.grdPatient.HighlightSelectedColumnHeaders = false;
            this.grdPatient.Location = new System.Drawing.Point(5, 0);
            this.grdPatient.MultiSelect = false;
            this.grdPatient.Name = "grdPatient";
            this.grdPatient.ReadOnly = true;
            this.grdPatient.RowHeadersVisible = false;
            this.grdPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPatient.Size = new System.Drawing.Size(646, 372);
            this.grdPatient.TabIndex = 0;
            this.grdPatient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPatient_CellDoubleClick);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Mã";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 120;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // birthYearDataGridViewTextBoxColumn
            // 
            this.birthYearDataGridViewTextBoxColumn.DataPropertyName = "BirthYear";
            this.birthYearDataGridViewTextBoxColumn.HeaderText = "Năm sinh";
            this.birthYearDataGridViewTextBoxColumn.Name = "birthYearDataGridViewTextBoxColumn";
            this.birthYearDataGridViewTextBoxColumn.ReadOnly = true;
            this.birthYearDataGridViewTextBoxColumn.Width = 80;
            // 
            // sexualDataGridViewTextBoxColumn
            // 
            this.sexualDataGridViewTextBoxColumn.DataPropertyName = "Sexual";
            this.sexualDataGridViewTextBoxColumn.HeaderText = "Giới tính";
            this.sexualDataGridViewTextBoxColumn.Name = "sexualDataGridViewTextBoxColumn";
            this.sexualDataGridViewTextBoxColumn.ReadOnly = true;
            this.sexualDataGridViewTextBoxColumn.Width = 80;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Địa chỉ";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bdgPatient
            // 
            this.bdgPatient.DataSource = typeof(Medical.Data.Entities.Patient);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(167, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 15);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Họ và tên";
            // 
            // txtPatientName
            // 
            this.txtPatientName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPatientName.Border.Class = "TextBoxBorder";
            this.txtPatientName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPatientName.ForeColor = System.Drawing.Color.Black;
            this.txtPatientName.Location = new System.Drawing.Point(220, 8);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(171, 20);
            this.txtPatientName.TabIndex = 2;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(397, 11);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(49, 15);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Năm sinh";
            // 
            // txtBirthYear
            // 
            // 
            // 
            // 
            this.txtBirthYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBirthYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBirthYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBirthYear.Location = new System.Drawing.Point(448, 8);
            this.txtBirthYear.Name = "txtBirthYear";
            this.txtBirthYear.Size = new System.Drawing.Size(69, 20);
            this.txtBirthYear.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Image = global::Medical.Properties.Resources.search_16;
            this.btnSearch.Location = new System.Drawing.Point(527, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtPatientName);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.txtBirthYear);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 40);
            this.panel1.TabIndex = 8;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.grdPatient);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 40);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelEx1.Size = new System.Drawing.Size(656, 377);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            this.panelEx1.Text = "panelEx1";
            this.panelEx1.ThemeAware = true;
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 11);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(18, 15);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Mã";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCode.Location = new System.Drawing.Point(37, 8);
            this.txtCode.MinValue = 0;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(124, 20);
            this.txtCode.TabIndex = 7;
            // 
            // PatientBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 417);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientBrowseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách bệnh nhân";
            this.Shown += new System.EventHandler(this.PatientBrowseFormShown);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirthYear)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX grdPatient;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IntegerInput txtBirthYear;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn crearedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bdgPatient;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DevComponents.Editors.IntegerInput txtCode;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}