namespace Medical.MedicinePlan
{
    partial class frmMedicinePlanList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cboMonth = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboYear = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbClinic = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.grd = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboStatus);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.cbClinic);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // cboStatus
            // 
            this.cboStatus.DisplayMember = "Id";
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 15;
            this.cboStatus.Location = new System.Drawing.Point(693, 20);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(89, 21);
            this.cboStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboStatus.TabIndex = 11;
            this.cboStatus.ValueMember = "Id";
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(626, 20);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(57, 23);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "Trạng thái";
            // 
            // cboMonth
            // 
            this.cboMonth.DisplayMember = "Id";
            this.cboMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.ItemHeight = 15;
            this.cboMonth.Location = new System.Drawing.Point(535, 20);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(75, 21);
            this.cboMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMonth.TabIndex = 9;
            this.cboMonth.ValueMember = "Id";
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // cboYear
            // 
            this.cboYear.DisplayMember = "Id";
            this.cboYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.ItemHeight = 15;
            this.cboYear.Location = new System.Drawing.Point(368, 20);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(90, 21);
            this.cboYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboYear.TabIndex = 8;
            this.cboYear.ValueMember = "Id";
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(481, 20);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(57, 23);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Tháng";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(324, 20);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "Năm";
            // 
            // cbClinic
            // 
            this.cbClinic.DisplayMember = "Name";
            this.cbClinic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClinic.FormattingEnabled = true;
            this.cbClinic.ItemHeight = 15;
            this.cbClinic.Location = new System.Drawing.Point(115, 20);
            this.cbClinic.Name = "cbClinic";
            this.cbClinic.Size = new System.Drawing.Size(192, 21);
            this.cbClinic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbClinic.TabIndex = 3;
            this.cbClinic.ValueMember = "Id";
            this.cbClinic.SelectedIndexChanged += new System.EventHandler(this.cbClinic_SelectedIndexChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(33, 20);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "Phòng khám";
            // 
            // grd
            // 
            this.grd.AllowUserToOrderColumns = true;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle1;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.grd.Location = new System.Drawing.Point(0, 62);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(816, 333);
            this.grd.TabIndex = 1;
            this.grd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CellDoubleClick);
            this.grd.AutoGenerateColumns = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 10);
            this.panel1.TabIndex = 2;
            // 
            // frmMedicinePlanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 395);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMedicinePlanList";
            this.Text = "Danh sách kế hoạch";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbClinic;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.DataGridViewX grd;
        private DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn clinicNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboMonth;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboYear;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboStatus;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}