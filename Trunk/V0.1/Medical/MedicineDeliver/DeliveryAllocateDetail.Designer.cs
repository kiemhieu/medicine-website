namespace Medical.MedicineDeliver
{
    partial class DeliveryAllocateDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allocatedQtyDataGridViewTextBoxColumn = new DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsVWareHouseDetail = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsDelivery = new System.Windows.Forms.BindingSource(this.components);
            this.bdsDefine = new System.Windows.Forms.BindingSource(this.components);
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bdsMedicine = new System.Windows.Forms.BindingSource(this.components);
            this.bdsWareHouse = new System.Windows.Forms.BindingSource(this.components);
            this.txtNotAllocatedQty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtQty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtWareHouseQty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtAllocatedQty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtWareHouseRemainQty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVWareHouseDetail)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDelivery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDefine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWareHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            this.dataGridViewX1.AllowUserToResizeColumns = false;
            this.dataGridViewX1.AllowUserToResizeRows = false;
            this.dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.lotNoDataGridViewTextBoxColumn,
            this.expiredDateDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.allocatedQtyDataGridViewTextBoxColumn,
            this.Column1});
            this.dataGridViewX1.DataSource = this.bdsVWareHouseDetail;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dataGridViewX1.HighlightSelectedColumnHeaders = false;
            this.errorProvider1.SetIconAlignment(this.dataGridViewX1, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 40);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewX1.MultiSelect = false;
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowHeadersVisible = false;
            this.dataGridViewX1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewX1.Size = new System.Drawing.Size(692, 250);
            this.dataGridViewX1.TabIndex = 1;
            this.dataGridViewX1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellEndEdit);
            this.dataGridViewX1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewX1_CellPainting);
            this.dataGridViewX1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewX1_CellValueChanged);
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.HeaderText = "STT";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
            // 
            // lotNoDataGridViewTextBoxColumn
            // 
            this.lotNoDataGridViewTextBoxColumn.DataPropertyName = "LotNo";
            this.lotNoDataGridViewTextBoxColumn.HeaderText = "Lô";
            this.lotNoDataGridViewTextBoxColumn.Name = "lotNoDataGridViewTextBoxColumn";
            this.lotNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expiredDateDataGridViewTextBoxColumn
            // 
            this.expiredDateDataGridViewTextBoxColumn.DataPropertyName = "ExpiredDate";
            this.expiredDateDataGridViewTextBoxColumn.HeaderText = "Hạn sử dụng";
            this.expiredDateDataGridViewTextBoxColumn.Name = "expiredDateDataGridViewTextBoxColumn";
            this.expiredDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Số lượng";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // allocatedQtyDataGridViewTextBoxColumn
            // 
            // 
            // 
            // 
            this.allocatedQtyDataGridViewTextBoxColumn.BackgroundStyle.Class = "DataGridViewNumericBorder";
            this.allocatedQtyDataGridViewTextBoxColumn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.allocatedQtyDataGridViewTextBoxColumn.DataPropertyName = "AllocatedQty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.allocatedQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.allocatedQtyDataGridViewTextBoxColumn.HeaderText = "Đã chọn";
            this.allocatedQtyDataGridViewTextBoxColumn.Name = "allocatedQtyDataGridViewTextBoxColumn";
            this.allocatedQtyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bdsVWareHouseDetail
            // 
            this.bdsVWareHouseDetail.DataSource = typeof(Medical.Data.Entities.Views.VWareHouseDetail);
            this.bdsVWareHouseDetail.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.bdsVWareHouseDetail_BindingComplete);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.panelEx1.Controls.Add(this.comboBoxEx2);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Controls.Add(this.txtNotAllocatedQty);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.txtQty);
            this.panelEx1.Controls.Add(this.comboBoxEx1);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(692, 40);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            this.panelEx1.ThemeAware = true;
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsDelivery, "Unit", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxEx2.DataSource = this.bdsDefine;
            this.comboBoxEx2.DisplayMember = "Name";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.ItemHeight = 14;
            this.comboBoxEx2.Location = new System.Drawing.Point(285, 10);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(83, 20);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 14;
            this.comboBoxEx2.ValueMember = "Id";
            // 
            // bdsDelivery
            // 
            this.bdsDelivery.DataSource = typeof(Medical.Data.Entities.MedicineDeliveryDetail);
            // 
            // bdsDefine
            // 
            this.bdsDefine.DataSource = typeof(Medical.Data.Entities.Define);
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(244, 13);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(35, 15);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "Đơn vị";
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsDelivery, "MedicineId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxEx1.DataSource = this.bdsMedicine;
            this.comboBoxEx1.DisplayMember = "Name";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 14;
            this.comboBoxEx1.Location = new System.Drawing.Point(45, 10);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(178, 20);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 12;
            this.comboBoxEx1.ValueMember = "Id";
            // 
            // bdsMedicine
            // 
            this.bdsMedicine.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // bdsWareHouse
            // 
            this.bdsWareHouse.DataSource = typeof(Medical.Data.Entities.WareHouse);
            // 
            // txtNotAllocatedQty
            // 
            this.txtNotAllocatedQty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtNotAllocatedQty.Border.Class = "TextBoxBorder";
            this.txtNotAllocatedQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNotAllocatedQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDelivery, "NotAllocatedQty", true));
            this.txtNotAllocatedQty.ForeColor = System.Drawing.Color.Black;
            this.txtNotAllocatedQty.Location = new System.Drawing.Point(570, 10);
            this.txtNotAllocatedQty.Name = "txtNotAllocatedQty";
            this.txtNotAllocatedQty.Size = new System.Drawing.Size(105, 20);
            this.txtNotAllocatedQty.TabIndex = 9;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(526, 13);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(37, 15);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "Còn lại";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtQty.Border.Class = "TextBoxBorder";
            this.txtQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDelivery, "Volumn", true));
            this.txtQty.ForeColor = System.Drawing.Color.Black;
            this.txtQty.Location = new System.Drawing.Point(434, 10);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(80, 20);
            this.txtQty.TabIndex = 5;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(381, 13);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(47, 15);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Cần xuất";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(8, 13);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(33, 15);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Thuốc";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.bdsWareHouse;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.bdsVWareHouseDetail;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(13, 13);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(52, 15);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Trong kho";
            // 
            // txtWareHouseQty
            // 
            this.txtWareHouseQty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtWareHouseQty.Border.Class = "TextBoxBorder";
            this.txtWareHouseQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWareHouseQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "Volumn", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtWareHouseQty.ForeColor = System.Drawing.Color.Black;
            this.txtWareHouseQty.Location = new System.Drawing.Point(71, 10);
            this.txtWareHouseQty.Name = "txtWareHouseQty";
            this.txtWareHouseQty.Size = new System.Drawing.Size(120, 20);
            this.txtWareHouseQty.TabIndex = 3;
            this.txtWareHouseQty.Text = "999,999,999";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(220, 13);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(43, 15);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Đã chọn";
            // 
            // txtAllocatedQty
            // 
            this.txtAllocatedQty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtAllocatedQty.Border.Class = "TextBoxBorder";
            this.txtAllocatedQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAllocatedQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDelivery, "AllocatedQty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAllocatedQty.ForeColor = System.Drawing.Color.Black;
            this.txtAllocatedQty.Location = new System.Drawing.Point(269, 10);
            this.txtAllocatedQty.Name = "txtAllocatedQty";
            this.txtAllocatedQty.Size = new System.Drawing.Size(120, 20);
            this.txtAllocatedQty.TabIndex = 7;
            this.txtAllocatedQty.TextChanged += new System.EventHandler(this.textBoxX4_TextChanged);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(415, 13);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(37, 15);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "Còn lại";
            // 
            // txtWareHouseRemainQty
            // 
            this.txtWareHouseRemainQty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtWareHouseRemainQty.Border.Class = "TextBoxBorder";
            this.txtWareHouseRemainQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWareHouseRemainQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsWareHouse, "RemainQty", true));
            this.txtWareHouseRemainQty.ForeColor = System.Drawing.Color.Black;
            this.txtWareHouseRemainQty.Location = new System.Drawing.Point(458, 10);
            this.txtWareHouseRemainQty.Name = "txtWareHouseRemainQty";
            this.txtWareHouseRemainQty.Size = new System.Drawing.Size(120, 20);
            this.txtWareHouseRemainQty.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Image = global::Medical.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(560, 49);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Đóng lại";
            this.btnCancel.ThemeAware = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = global::Medical.Properties.Resources.accept;
            this.btnSave.Location = new System.Drawing.Point(434, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Ghi lại";
            this.btnSave.ThemeAware = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(663, 2);
            this.label2.TabIndex = 29;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.panelEx2.Controls.Add(this.label2);
            this.panelEx2.Controls.Add(this.btnSave);
            this.panelEx2.Controls.Add(this.btnCancel);
            this.panelEx2.Controls.Add(this.txtWareHouseRemainQty);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.txtAllocatedQty);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.txtWareHouseQty);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 290);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panelEx2.Size = new System.Drawing.Size(692, 83);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 3;
            this.panelEx2.ThemeAware = true;
            // 
            // DeliveryAllocateDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 373);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeliveryAllocateDetail";
            this.Text = "DeliveryAllocateDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVWareHouseDetail)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDelivery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDefine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWareHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource bdsVWareHouseDetail;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNotAllocatedQty;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQty;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.BindingSource bdsDelivery;
        private System.Windows.Forms.BindingSource bdsWareHouse;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private System.Windows.Forms.BindingSource bdsDefine;
        private System.Windows.Forms.BindingSource bdsMedicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiredDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn allocatedQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWareHouseRemainQty;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtAllocatedQty;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtWareHouseQty;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}