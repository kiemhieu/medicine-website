namespace Medical.Test
{
    partial class frmWareHouseDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.grd = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinicIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinicNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.badVolumnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crearedUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonX1);
            this.panel2.Controls.Add(this.buttonX2);
            this.panel2.Controls.Add(this.buttonX3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 33);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonX1.Location = new System.Drawing.Point(381, 5);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 5;
            this.buttonX1.Text = "Xóa";
            this.buttonX1.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonX2.Location = new System.Drawing.Point(265, 5);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "Sửa";
            this.buttonX2.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Font = new System.Drawing.Font("Arial", 8.25F);
            this.buttonX3.Location = new System.Drawing.Point(142, 5);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(75, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 3;
            this.buttonX3.Text = "Thêm mới";
            this.buttonX3.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.AllowUserToOrderColumns = true;
            this.grd.AutoGenerateColumns = false;
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.clinicIdDataGridViewTextBoxColumn,
            this.clinicNameDataGridViewTextBoxColumn,
            this.medicineNameDataGridViewTextBoxColumn,
            this.medicineIdDataGridViewTextBoxColumn,
            this.lotNoDataGridViewTextBoxColumn,
            this.expiredDateDataGridViewTextBoxColumn,
            this.volumnDataGridViewTextBoxColumn,
            this.badVolumnDataGridViewTextBoxColumn,
            this.unitPriceDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.crearedUserDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.lastUpdatedUserDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn});
            this.grd.DataSource = this.bindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle2;
            this.grd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grd.Location = new System.Drawing.Point(12, 51);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(619, 375);
            this.grd.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // clinicIdDataGridViewTextBoxColumn
            // 
            this.clinicIdDataGridViewTextBoxColumn.DataPropertyName = "ClinicId";
            this.clinicIdDataGridViewTextBoxColumn.HeaderText = "ClinicId";
            this.clinicIdDataGridViewTextBoxColumn.Name = "clinicIdDataGridViewTextBoxColumn";
            this.clinicIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // clinicNameDataGridViewTextBoxColumn
            // 
            this.clinicNameDataGridViewTextBoxColumn.DataPropertyName = "ClinicName";
            this.clinicNameDataGridViewTextBoxColumn.HeaderText = "ClinicName";
            this.clinicNameDataGridViewTextBoxColumn.Name = "clinicNameDataGridViewTextBoxColumn";
            this.clinicNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // medicineNameDataGridViewTextBoxColumn
            // 
            this.medicineNameDataGridViewTextBoxColumn.DataPropertyName = "MedicineName";
            this.medicineNameDataGridViewTextBoxColumn.HeaderText = "MedicineName";
            this.medicineNameDataGridViewTextBoxColumn.Name = "medicineNameDataGridViewTextBoxColumn";
            this.medicineNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // medicineIdDataGridViewTextBoxColumn
            // 
            this.medicineIdDataGridViewTextBoxColumn.DataPropertyName = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn.HeaderText = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn.Name = "medicineIdDataGridViewTextBoxColumn";
            this.medicineIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            // 
            // expiredDateDataGridViewTextBoxColumn
            // 
            this.expiredDateDataGridViewTextBoxColumn.DataPropertyName = "ExpiredDate";
            this.expiredDateDataGridViewTextBoxColumn.HeaderText = "ExpiredDate";
            this.expiredDateDataGridViewTextBoxColumn.Name = "expiredDateDataGridViewTextBoxColumn";
            // 
            // volumnDataGridViewTextBoxColumn
            // 
            this.volumnDataGridViewTextBoxColumn.DataPropertyName = "Volumn";
            this.volumnDataGridViewTextBoxColumn.HeaderText = "Volumn";
            this.volumnDataGridViewTextBoxColumn.Name = "volumnDataGridViewTextBoxColumn";
            // 
            // badVolumnDataGridViewTextBoxColumn
            // 
            this.badVolumnDataGridViewTextBoxColumn.DataPropertyName = "BadVolumn";
            this.badVolumnDataGridViewTextBoxColumn.HeaderText = "BadVolumn";
            this.badVolumnDataGridViewTextBoxColumn.Name = "badVolumnDataGridViewTextBoxColumn";
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // crearedUserDataGridViewTextBoxColumn
            // 
            this.crearedUserDataGridViewTextBoxColumn.DataPropertyName = "CrearedUser";
            this.crearedUserDataGridViewTextBoxColumn.HeaderText = "CrearedUser";
            this.crearedUserDataGridViewTextBoxColumn.Name = "crearedUserDataGridViewTextBoxColumn";
            this.crearedUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdatedUserDataGridViewTextBoxColumn
            // 
            this.lastUpdatedUserDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedUser";
            this.lastUpdatedUserDataGridViewTextBoxColumn.HeaderText = "LastUpdatedUser";
            this.lastUpdatedUserDataGridViewTextBoxColumn.Name = "lastUpdatedUserDataGridViewTextBoxColumn";
            this.lastUpdatedUserDataGridViewTextBoxColumn.Visible = false;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.Visible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Medical.Data.Entities.WareHouseDetail);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(540, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 7;
            this.lblID.Visible = false;
            // 
            // frmWareHouseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmWareHouseDetail";
            this.Text = "frmWareHouseDetail";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX grd;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinicIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinicNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicineIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiredDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn badVolumnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn crearedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblID;
    }
}