namespace Medical.MedicineForm
{
    partial class FrmMedicinEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancle = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescription = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.bdsMedicine = new System.Windows.Forms.BindingSource(this.components);
            this.cboUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboContentUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtContent = new DevComponents.Editors.IntegerInput();
            this.txtTradeName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.rdoNTCh = new System.Windows.Forms.RadioButton();
            this.rdoArv = new System.Windows.Forms.RadioButton();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancle);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 174);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 60);
            this.panel1.TabIndex = 8;
            // 
            // btnCancle
            // 
            this.btnCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancle.Image = global::Medical.Properties.Resources.cancel;
            this.btnCancle.Location = new System.Drawing.Point(526, 15);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(87, 30);
            this.btnCancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "Bỏ qua";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::Medical.Properties.Resources.accept;
            this.btnUpdate.Location = new System.Drawing.Point(433, 15);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 30);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Ghi lại";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.cboUnit);
            this.panel2.Controls.Add(this.cboContentUnit);
            this.panel2.Controls.Add(this.txtContent);
            this.panel2.Controls.Add(this.txtTradeName);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.rdoNTCh);
            this.panel2.Controls.Add(this.rdoArv);
            this.panel2.Controls.Add(this.labelX7);
            this.panel2.Controls.Add(this.labelX6);
            this.panel2.Controls.Add(this.labelX5);
            this.panel2.Controls.Add(this.labelX3);
            this.panel2.Controls.Add(this.labelX2);
            this.panel2.Controls.Add(this.labelX1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 174);
            this.panel2.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.Border.Class = "TextBoxBorder";
            this.txtDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMedicine, "Description", true));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(113, 147);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(500, 22);
            this.txtDescription.TabIndex = 7;
            // 
            // bdsMedicine
            // 
            this.bdsMedicine.DataSource = typeof(Medical.Data.Entities.Medicine);
            // 
            // cboUnit
            // 
            this.cboUnit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsMedicine, "Unit", true));
            this.cboUnit.DisplayMember = "Name";
            this.cboUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.ItemHeight = 16;
            this.cboUnit.Location = new System.Drawing.Point(113, 120);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(80, 22);
            this.cboUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboUnit.TabIndex = 6;
            this.cboUnit.ValueMember = "Id";
            // 
            // cboContentUnit
            // 
            this.cboContentUnit.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsMedicine, "ContentUnit", true));
            this.cboContentUnit.DisplayMember = "Name";
            this.cboContentUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboContentUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContentUnit.FormattingEnabled = true;
            this.cboContentUnit.ItemHeight = 16;
            this.cboContentUnit.Location = new System.Drawing.Point(244, 93);
            this.cboContentUnit.Name = "cboContentUnit";
            this.cboContentUnit.Size = new System.Drawing.Size(80, 22);
            this.cboContentUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboContentUnit.TabIndex = 5;
            this.cboContentUnit.ValueMember = "Id";
            // 
            // txtContent
            // 
            // 
            // 
            // 
            this.txtContent.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtContent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtContent.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtContent.DataBindings.Add(new System.Windows.Forms.Binding("ValueObject", this.bdsMedicine, "Content", true));
            this.txtContent.Location = new System.Drawing.Point(114, 93);
            this.txtContent.Name = "txtContent";
            this.txtContent.ShowUpDown = true;
            this.txtContent.Size = new System.Drawing.Size(120, 22);
            this.txtContent.TabIndex = 4;
            // 
            // txtTradeName
            // 
            this.txtTradeName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTradeName.Border.Class = "TextBoxBorder";
            this.txtTradeName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTradeName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMedicine, "TradeName", true));
            this.txtTradeName.ForeColor = System.Drawing.Color.Black;
            this.txtTradeName.Location = new System.Drawing.Point(114, 65);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(250, 22);
            this.txtTradeName.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMedicine, "Name", true));
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(114, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 22);
            this.txtName.TabIndex = 2;
            // 
            // rdoNTCh
            // 
            this.rdoNTCh.AutoSize = true;
            this.rdoNTCh.Location = new System.Drawing.Point(173, 9);
            this.rdoNTCh.Name = "rdoNTCh";
            this.rdoNTCh.Size = new System.Drawing.Size(137, 20);
            this.rdoNTCh.TabIndex = 1;
            this.rdoNTCh.TabStop = true;
            this.rdoNTCh.Text = "Nhiễm trùng cơ hội";
            this.rdoNTCh.UseVisualStyleBackColor = true;
            // 
            // rdoArv
            // 
            this.rdoArv.AutoSize = true;
            this.rdoArv.Location = new System.Drawing.Point(114, 9);
            this.rdoArv.Name = "rdoArv";
            this.rdoArv.Size = new System.Drawing.Size(53, 20);
            this.rdoArv.TabIndex = 0;
            this.rdoArv.TabStop = true;
            this.rdoArv.Text = "ARV";
            this.rdoArv.UseVisualStyleBackColor = true;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(12, 150);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(53, 17);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 21;
            this.labelX7.Text = "Diễn giải";
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(12, 123);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(41, 17);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 20;
            this.labelX6.Text = "Đơn vị";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 96);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(68, 17);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "Hàm lượng";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(12, 68);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(84, 17);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 17;
            this.labelX3.Text = "Tên biệt dược";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 40);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 17);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 16;
            this.labelX2.Text = "Tên thuốc";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(27, 17);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 15;
            this.labelX1.Text = "Loại";
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // err
            // 
            this.err.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.err.ContainerControl = this;
            // 
            // FrmMedicinEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 234);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMedicinEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo thuốc mới";
            this.Load += new System.EventHandler(this.FrmMedicinEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMedicine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancle;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDescription;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboUnit;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboContentUnit;
        private DevComponents.Editors.IntegerInput txtContent;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTradeName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private System.Windows.Forms.RadioButton rdoNTCh;
        private System.Windows.Forms.RadioButton rdoArv;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.BindingSource bdsMedicine;
        private System.Windows.Forms.ErrorProvider err;
    }
}