﻿namespace Medical.MedicinePlanning {
    partial class MedicinePlanning {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.CreatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsPlanning = new System.Windows.Forms.BindingSource(this.components);
            this.cboClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsClinic = new System.Windows.Forms.BindingSource(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.cboMonth = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cboYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.bdsStatus = new System.Windows.Forms.BindingSource(this.components);
            this.bdsUser = new System.Windows.Forms.BindingSource(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClinic)).BeginInit();
            this.panelEx3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dataGridViewX1);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 26);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(838, 488);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            this.panelEx2.ThemeAware = true;
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreatedUser,
            this.LastUpdatedDate,
            this.yearDataGridViewTextBoxColumn1,
            this.monthDataGridViewTextBoxColumn1,
            this.dateDataGridViewTextBoxColumn1,
            this.statusDataGridViewTextBoxColumn1,
            this.noteDataGridViewTextBoxColumn1});
            this.dataGridViewX1.DataSource = this.bdsPlanning;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.Size = new System.Drawing.Size(838, 488);
            this.dataGridViewX1.TabIndex = 2;
            // 
            // CreatedUser
            // 
            this.CreatedUser.DataPropertyName = "CreatedUser";
            this.CreatedUser.HeaderText = "Người lập";
            this.CreatedUser.Name = "CreatedUser";
            // 
            // LastUpdatedDate
            // 
            this.LastUpdatedDate.DataPropertyName = "LastUpdatedDate";
            this.LastUpdatedDate.HeaderText = "Lần sửa cuối";
            this.LastUpdatedDate.Name = "LastUpdatedDate";
            // 
            // yearDataGridViewTextBoxColumn1
            // 
            this.yearDataGridViewTextBoxColumn1.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn1.HeaderText = "Năm";
            this.yearDataGridViewTextBoxColumn1.Name = "yearDataGridViewTextBoxColumn1";
            this.yearDataGridViewTextBoxColumn1.Width = 80;
            // 
            // monthDataGridViewTextBoxColumn1
            // 
            this.monthDataGridViewTextBoxColumn1.DataPropertyName = "Month";
            this.monthDataGridViewTextBoxColumn1.HeaderText = "Tháng";
            this.monthDataGridViewTextBoxColumn1.Name = "monthDataGridViewTextBoxColumn1";
            this.monthDataGridViewTextBoxColumn1.Width = 60;
            // 
            // dateDataGridViewTextBoxColumn1
            // 
            this.dateDataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn1.HeaderText = "Ngày lập";
            this.dateDataGridViewTextBoxColumn1.Name = "dateDataGridViewTextBoxColumn1";
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "Trạng thái";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            // 
            // noteDataGridViewTextBoxColumn1
            // 
            this.noteDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noteDataGridViewTextBoxColumn1.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn1.HeaderText = "Ghi chú";
            this.noteDataGridViewTextBoxColumn1.Name = "noteDataGridViewTextBoxColumn1";
            // 
            // bdsPlanning
            // 
            this.bdsPlanning.DataSource = typeof(Medical.Data.Entities.MedicinePlan);
            // 
            // cboClinic
            // 
            this.cboClinic.DataSource = this.bdsClinic;
            this.cboClinic.DisplayMember = "Name";
            this.cboClinic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClinic.FormattingEnabled = true;
            this.cboClinic.ItemHeight = 14;
            this.cboClinic.Location = new System.Drawing.Point(61, 3);
            this.cboClinic.Name = "cboClinic";
            this.cboClinic.Size = new System.Drawing.Size(250, 20);
            this.cboClinic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboClinic.TabIndex = 1;
            this.cboClinic.ValueMember = "Id";
            // 
            // bdsClinic
            // 
            this.bdsClinic.DataSource = typeof(Medical.Data.Entities.Clinic);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(3, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(52, 15);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Trung tâm";
            // 
            // panelEx3
            // 
            this.panelEx3.AutoSize = true;
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.cboMonth);
            this.panelEx3.Controls.Add(this.labelX3);
            this.panelEx3.Controls.Add(this.cboYear);
            this.panelEx3.Controls.Add(this.labelX2);
            this.panelEx3.Controls.Add(this.buttonX1);
            this.panelEx3.Controls.Add(this.cboClinic);
            this.panelEx3.Controls.Add(this.labelX1);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(838, 26);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.ThemeAware = true;
            // 
            // cboMonth
            // 
            this.cboMonth.DisplayMember = "Text";
            this.cboMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.ItemHeight = 14;
            this.cboMonth.Location = new System.Drawing.Point(458, 3);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(68, 20);
            this.cboMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMonth.TabIndex = 6;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(420, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 15);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "Tháng";
            // 
            // cboYear
            // 
            this.cboYear.DisplayMember = "Text";
            this.cboYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.ItemHeight = 14;
            this.cboYear.Location = new System.Drawing.Point(348, 3);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(68, 20);
            this.cboYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboYear.TabIndex = 4;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(317, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(26, 15);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Năm";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Image = global::Medical.Properties.Resources.add;
            this.buttonX1.Location = new System.Drawing.Point(757, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(78, 20);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Lập dự trù";
            this.buttonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // bdsStatus
            // 
            this.bdsStatus.DataSource = typeof(Medical.Data.Entities.Define);
            // 
            // bdsUser
            // 
            this.bdsUser.DataSource = typeof(Medical.Data.Entities.User);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // MedicinePlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 514);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MedicinePlanning";
            this.Text = "Dự trù thuốc";
            this.Load += new System.EventHandler(this.MedicinePlanning_Load);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPlanning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsClinic)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboClinic;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private System.Windows.Forms.BindingSource bdsPlanning;
        private System.Windows.Forms.BindingSource bdsClinic;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.BindingSource bdsStatus;
        private System.Windows.Forms.BindingSource bdsUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboMonth;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboYear;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}