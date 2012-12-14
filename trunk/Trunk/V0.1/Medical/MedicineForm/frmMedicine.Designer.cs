﻿namespace Medical.MedicineForm
{
    partial class FrmMedicine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedicine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cboType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnInsert = new System.Windows.Forms.ToolStripButton();
            this.lblID = new System.Windows.Forms.Label();
            this.grd = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeMedicineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tradeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bdsDefine = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsMedicines = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDefine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboType,
            this.toolStripSeparator1,
            this.tsbtnDelete,
            this.tsbtnEdit,
            this.tsbtnInsert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(838, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.DropDownWidth = 120;
            this.cboType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDelete.Image")));
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(49, 22);
            this.tsbtnDelete.Text = "Xóa";
            this.tsbtnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEdit.Image")));
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(53, 22);
            this.tsbtnEdit.Text = "Sửa";
            this.tsbtnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tsbtnInsert
            // 
            this.tsbtnInsert.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnInsert.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInsert.Image")));
            this.tsbtnInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInsert.Name = "tsbtnInsert";
            this.tsbtnInsert.Size = new System.Drawing.Size(87, 22);
            this.tsbtnInsert.Text = "Thêm mới";
            this.tsbtnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(596, 17);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 16);
            this.lblID.TabIndex = 7;
            this.lblID.Visible = false;
            // 
            // grd
            // 
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.AllowUserToResizeColumns = false;
            this.grd.AllowUserToResizeRows = false;
            this.grd.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.typeMedicineDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.tradeNameDataGridViewTextBoxColumn,
            this.contentStringDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1});
            this.grd.DataSource = this.bdsMedicines;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle4;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grd.HighlightSelectedColumnHeaders = false;
            this.grd.Location = new System.Drawing.Point(0, 25);
            this.grd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowHeadersVisible = false;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd.Size = new System.Drawing.Size(838, 464);
            this.grd.TabIndex = 8;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "STT";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 50;
            // 
            // typeMedicineDataGridViewTextBoxColumn
            // 
            this.typeMedicineDataGridViewTextBoxColumn.DataPropertyName = "TypeMedicine";
            this.typeMedicineDataGridViewTextBoxColumn.HeaderText = "Loại";
            this.typeMedicineDataGridViewTextBoxColumn.Name = "typeMedicineDataGridViewTextBoxColumn";
            this.typeMedicineDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeMedicineDataGridViewTextBoxColumn.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Thuốc";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // tradeNameDataGridViewTextBoxColumn
            // 
            this.tradeNameDataGridViewTextBoxColumn.DataPropertyName = "TradeName";
            this.tradeNameDataGridViewTextBoxColumn.HeaderText = "Tên thương mại";
            this.tradeNameDataGridViewTextBoxColumn.Name = "tradeNameDataGridViewTextBoxColumn";
            this.tradeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tradeNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // contentStringDataGridViewTextBoxColumn
            // 
            this.contentStringDataGridViewTextBoxColumn.DataPropertyName = "ContentString";
            this.contentStringDataGridViewTextBoxColumn.HeaderText = "Hàm lượng";
            this.contentStringDataGridViewTextBoxColumn.Name = "contentStringDataGridViewTextBoxColumn";
            this.contentStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.DataSource = this.bdsDefine;
            this.unitDataGridViewTextBoxColumn.DisplayMember = "Name";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Đơn vị";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            this.unitDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unitDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.unitDataGridViewTextBoxColumn.ValueMember = "Id";
            // 
            // bdsDefine
            // 
            this.bdsDefine.DataSource = typeof(Medical.Data.Entities.Define);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bdsMedicines
            // 
            this.bdsMedicines.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // FrmMedicine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 489);
            this.ControlBox = false;
            this.Controls.Add(this.grd);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMedicine";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Danh mục thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMedicine_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDefine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnInsert;
        private System.Windows.Forms.ToolStripButton tsbtnEdit;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.Label lblID;
        private DevComponents.DotNetBar.Controls.DataGridViewX grd;
        private System.Windows.Forms.BindingSource bdsMedicines;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripComboBox cboType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bdsDefine;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeMedicineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tradeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

    }
}

