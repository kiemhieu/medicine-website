namespace Medical
{
    partial class FrmFigureEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtGhiChu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bdsFigure = new System.Windows.Forms.BindingSource(this.components);
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblFigureName = new DevComponents.DotNetBar.LabelX();
            this.txtFigureName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancle = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.grdDetail = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.medicineIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bdsMedicine = new System.Windows.Forms.BindingSource(this.components);
            this.volumnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsFigureDetail = new System.Windows.Forms.BindingSource(this.components);
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bdsFigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsFigureDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGhiChu.Border.Class = "TextBoxBorder";
            this.txtGhiChu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGhiChu.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsFigure, "Description", true));
            this.txtGhiChu.ForeColor = System.Drawing.Color.Black;
            this.txtGhiChu.Location = new System.Drawing.Point(80, 38);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(380, 20);
            this.txtGhiChu.TabIndex = 7;
            // 
            // bdsFigure
            // 
            this.bdsFigure.DataSource = typeof(Medical.Data.Entities.Figure);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.labelX1.Location = new System.Drawing.Point(10, 41);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(40, 15);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "Ghi chú";
            // 
            // lblFigureName
            // 
            this.lblFigureName.AutoSize = true;
            // 
            // 
            // 
            this.lblFigureName.BackgroundStyle.Class = "";
            this.lblFigureName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFigureName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblFigureName.Location = new System.Drawing.Point(10, 15);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(64, 15);
            this.lblFigureName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblFigureName.TabIndex = 5;
            this.lblFigureName.Text = "Tên phác đồ";
            // 
            // txtFigureName
            // 
            this.txtFigureName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFigureName.Border.Class = "TextBoxBorder";
            this.txtFigureName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFigureName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsFigure, "Name", true));
            this.txtFigureName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtFigureName.ForeColor = System.Drawing.Color.Black;
            this.txtFigureName.Location = new System.Drawing.Point(80, 12);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(170, 20);
            this.txtFigureName.TabIndex = 4;
            // 
            // btnCancle
            // 
            this.btnCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnCancle.Image = global::Medical.Properties.Resources.cancel;
            this.btnCancle.Location = new System.Drawing.Point(340, 333);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(120, 23);
            this.btnCancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "Bỏ qua";
            this.btnCancle.Click += new System.EventHandler(this.BtnCancleClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnUpdate.Image = global::Medical.Properties.Resources.accept;
            this.btnUpdate.Location = new System.Drawing.Point(214, 333);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(120, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
            // 
            // grdDetail
            // 
            this.grdDetail.AllowUserToDeleteRows = false;
            this.grdDetail.AllowUserToResizeColumns = false;
            this.grdDetail.AllowUserToResizeRows = false;
            this.grdDetail.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medicineIdDataGridViewTextBoxColumn1,
            this.volumnDataGridViewTextBoxColumn});
            this.grdDetail.DataSource = this.bdsFigureDetail;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.grdDetail.Location = new System.Drawing.Point(6, 65);
            this.grdDetail.MultiSelect = false;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetail.Size = new System.Drawing.Size(454, 257);
            this.grdDetail.TabIndex = 9;
            this.grdDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdDetailCellEndEdit);
            this.grdDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GrdDetailDataBindingComplete);
            // 
            // medicineIdDataGridViewTextBoxColumn1
            // 
            this.medicineIdDataGridViewTextBoxColumn1.DataPropertyName = "MedicineId";
            this.medicineIdDataGridViewTextBoxColumn1.DataSource = this.bdsMedicine;
            this.medicineIdDataGridViewTextBoxColumn1.DisplayMember = "Name";
            this.medicineIdDataGridViewTextBoxColumn1.HeaderText = "Thuốc";
            this.medicineIdDataGridViewTextBoxColumn1.Name = "medicineIdDataGridViewTextBoxColumn1";
            this.medicineIdDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.medicineIdDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.medicineIdDataGridViewTextBoxColumn1.ValueMember = "Id";
            this.medicineIdDataGridViewTextBoxColumn1.Width = 200;
            // 
            // bdsMedicine
            // 
            this.bdsMedicine.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // volumnDataGridViewTextBoxColumn
            // 
            this.volumnDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.volumnDataGridViewTextBoxColumn.DataPropertyName = "Volumn";
            this.volumnDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.volumnDataGridViewTextBoxColumn.Name = "volumnDataGridViewTextBoxColumn";
            // 
            // bdsFigureDetail
            // 
            this.bdsFigureDetail.DataSource = typeof(Medical.Data.Entities.FigureDetail);
            this.bdsFigureDetail.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.BdsFigureDetailListChanged);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // FrmFigureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 368);
            this.ControlBox = false;
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblFigureName);
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.txtFigureName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmFigureEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập nhật phác đồ";
            this.Activated += new System.EventHandler(this.FrmFigureEditActivated);
            ((System.ComponentModel.ISupportInitialize)(this.bdsFigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsFigureDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtGhiChu;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblFigureName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFigureName;
        private DevComponents.DotNetBar.ButtonX btnCancle;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.Controls.DataGridViewX grdDetail;
        private System.Windows.Forms.BindingSource bdsFigureDetail;
        private System.Windows.Forms.BindingSource bdsMedicine;
        private System.Windows.Forms.BindingSource bdsFigure;
        private System.Windows.Forms.DataGridViewComboBoxColumn medicineIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumnDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.StyleManager styleManager1;

    }
}