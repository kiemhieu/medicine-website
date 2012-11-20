namespace Medical.Test
{
    partial class frmImportWH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dateImport = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtRecipient = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNote = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMST = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.MedicineName = new DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn();
            this.LotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BadVolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealityVolumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbClinic);
            this.groupBox1.Controls.Add(this.dateImport);
            this.groupBox1.Controls.Add(this.txtRecipient);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtMST);
            this.groupBox1.Controls.Add(this.txtNo);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phiếu nhập kho";
            // 
            // cbClinic
            // 
            this.cbClinic.DataSource = this.bindingSource2;
            this.cbClinic.DisplayMember = "Name";
            this.cbClinic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClinic.FormattingEnabled = true;
            this.cbClinic.ItemHeight = 15;
            this.cbClinic.Location = new System.Drawing.Point(512, 21);
            this.cbClinic.Name = "cbClinic";
            this.cbClinic.Size = new System.Drawing.Size(192, 21);
            this.cbClinic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbClinic.TabIndex = 3;
            this.cbClinic.ValueMember = "Id";
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = typeof(Medical.Data.Entities.Clinic);
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
            this.dateImport.IsPopupCalendarOpen = false;
            this.dateImport.Location = new System.Drawing.Point(291, 22);
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
            this.dateImport.MonthCalendar.DisplayMonth = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
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
            this.dateImport.Size = new System.Drawing.Size(80, 21);
            this.dateImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateImport.TabIndex = 2;
            // 
            // txtRecipient
            // 
            // 
            // 
            // 
            this.txtRecipient.Border.Class = "TextBoxBorder";
            this.txtRecipient.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRecipient.Location = new System.Drawing.Point(93, 73);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(278, 21);
            this.txtRecipient.TabIndex = 1;
            // 
            // txtNote
            // 
            // 
            // 
            // 
            this.txtNote.Border.Class = "TextBoxBorder";
            this.txtNote.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNote.Location = new System.Drawing.Point(93, 47);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(278, 21);
            this.txtNote.TabIndex = 1;
            // 
            // txtMST
            // 
            // 
            // 
            // 
            this.txtMST.Border.Class = "";
            this.txtMST.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMST.Location = new System.Drawing.Point(512, 47);
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(100, 14);
            this.txtMST.TabIndex = 1;
            // 
            // txtNo
            // 
            // 
            // 
            // 
            this.txtNo.Border.Class = "TextBoxBorder";
            this.txtNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNo.Location = new System.Drawing.Point(93, 20);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(100, 21);
            this.txtNo.TabIndex = 1;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 73);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "Người nhận";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(431, 47);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Mã số thuế";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 47);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "Nội dung";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(431, 22);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Từ kho";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(228, 18);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(57, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Ngày lập";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Mã chứng từ";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToOrderColumns = true;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MedicineName,
            this.LotNo,
            this.TotalVolumn,
            this.BadVolumn,
            this.RealityVolumn,
            this.Unit,
            this.UnitPrice,
            this.Amount,
            this.Note});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 136);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.Size = new System.Drawing.Size(804, 259);
            this.dataGridViewX1.TabIndex = 1;
            // 
            // bindingSource3
            // 
            this.bindingSource3.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // bindingSource4
            // 
            this.bindingSource4.DataSource = typeof(Medical.Data.Entities.Clinic);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Medical.Data.Entities.WareHousePaperDetail);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 36);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(689, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(576, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            // 
            // btnInsert
            // 
            this.btnInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInsert.Location = new System.Drawing.Point(461, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Thêm mới";
            // 
            // MedicineName
            // 
            this.MedicineName.DataPropertyName = "Name";
            this.MedicineName.DataSource = this.bindingSource3;
            this.MedicineName.DisplayMember = "Name";
            this.MedicineName.DropDownHeight = 106;
            this.MedicineName.DropDownWidth = 121;
            this.MedicineName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MedicineName.HeaderText = "Thuốc";
            this.MedicineName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MedicineName.IntegralHeight = false;
            this.MedicineName.ItemHeight = 15;
            this.MedicineName.Name = "MedicineName";
            this.MedicineName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MedicineName.ValueMember = "Id";
            // 
            // LotNo
            // 
            this.LotNo.HeaderText = "Số lô";
            this.LotNo.Name = "LotNo";
            // 
            // TotalVolumn
            // 
            this.TotalVolumn.HeaderText = "Số lượng thuốc";
            this.TotalVolumn.Name = "TotalVolumn";
            // 
            // BadVolumn
            // 
            this.BadVolumn.HeaderText = "Số lượng hỏng";
            this.BadVolumn.Name = "BadVolumn";
            // 
            // RealityVolumn
            // 
            this.RealityVolumn.HeaderText = "Số lượng thực";
            this.RealityVolumn.Name = "RealityVolumn";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Đơn vị";
            this.Unit.Name = "Unit";
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Đơn giá";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Thành tiền";
            this.Amount.Name = "Amount";
            // 
            // Note
            // 
            this.Note.HeaderText = "Chú thích";
            this.Note.Name = "Note";
            // 
            // frmImportWH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 395);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmImportWH";
            this.Text = "Nhập kho";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNo;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbClinic;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateImport;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRecipient;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNote;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMST;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private System.Windows.Forms.BindingSource bindingSource3;
        private System.Windows.Forms.BindingSource bindingSource4;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn clinicNameDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn MedicineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BadVolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealityVolumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}