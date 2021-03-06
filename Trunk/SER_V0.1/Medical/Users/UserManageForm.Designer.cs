﻿namespace Medical.Users
{
    partial class UserManageForm
    {
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
            this.grdUser = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bdgUser = new System.Windows.Forms.BindingSource(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtPatientName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnRegister = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClinicId = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.Active = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.CrearedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdUser
            // 
            this.grdUser.AllowUserToAddRows = false;
            this.grdUser.AllowUserToDeleteRows = false;
            this.grdUser.AllowUserToResizeRows = false;
            this.grdUser.AutoGenerateColumns = false;
            this.grdUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.ClinicId,
            this.Active,
            this.CrearedUser,
            this.CreatedDate});
            this.grdUser.DataSource = this.bdgUser;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdUser.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUser.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.grdUser.HighlightSelectedColumnHeaders = false;
            this.grdUser.Location = new System.Drawing.Point(5, 0);
            this.grdUser.MultiSelect = false;
            this.grdUser.Name = "grdUser";
            this.grdUser.ReadOnly = true;
            this.grdUser.RowHeadersVisible = false;
            this.grdUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUser.Size = new System.Drawing.Size(646, 385);
            this.grdUser.TabIndex = 0;
            this.grdUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPatient_CellDoubleClick);
            // 
            // bdgUser
            // 
            this.bdgUser.DataSource = typeof(Medical.Data.Entities.User);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(10, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 15);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
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
            this.txtPatientName.Location = new System.Drawing.Point(63, 3);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(128, 20);
            this.txtPatientName.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.cboClinic);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 27);
            this.panel1.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Image = global::Medical.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(534, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 21);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Image = global::Medical.Properties.Resources.edit;
            this.btnEdit.Location = new System.Drawing.Point(482, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(46, 21);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegister.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRegister.Image = global::Medical.Properties.Resources.add;
            this.btnRegister.Location = new System.Drawing.Point(396, 3);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(80, 21);
            this.btnRegister.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Thêm mới";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Image = global::Medical.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(628, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.grdUser);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 27);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.panelEx1.Size = new System.Drawing.Size(656, 390);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            this.panelEx1.Text = "panelEx1";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // ClinicId
            // 
            this.ClinicId.DataPropertyName = "ClinicId";
            this.ClinicId.DropDownHeight = 106;
            this.ClinicId.DropDownWidth = 121;
            this.ClinicId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClinicId.HeaderText = "ClinicId";
            this.ClinicId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClinicId.ItemHeight = 15;
            this.ClinicId.Name = "ClinicId";
            this.ClinicId.ReadOnly = true;
            this.ClinicId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // Active
            // 
            this.Active.Checked = true;
            this.Active.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Active.CheckValue = "N";
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // CrearedUser
            // 
            this.CrearedUser.DataPropertyName = "CrearedUser";
            this.CrearedUser.HeaderText = "CrearedUser";
            this.CrearedUser.Name = "CrearedUser";
            this.CrearedUser.ReadOnly = true;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "CreatedDate";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            // 
            // cboClinic
            // 
            this.cboClinic.DisplayMember = "Name";
            this.cboClinic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboClinic.Enabled = false;
            this.cboClinic.FocusCuesEnabled = false;
            this.cboClinic.FormattingEnabled = true;
            this.cboClinic.ItemHeight = 14;
            this.cboClinic.Location = new System.Drawing.Point(197, 3);
            this.cboClinic.Name = "cboClinic";
            this.cboClinic.Size = new System.Drawing.Size(193, 20);
            this.cboClinic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboClinic.TabIndex = 11;
            this.cboClinic.ValueMember = "Id";
            // 
            // UserManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 417);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách người sử dụng";
            this.Shown += new System.EventHandler(this.PatientBrowseForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX grdUser;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientName;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn crearedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bdgUser;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnRegister;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn ClinicId;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrearedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboClinic;
    }
}