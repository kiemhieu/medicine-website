namespace Medical.Warehouse
{
    partial class frmWareHouseEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.cboMedicine = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtMinAllowed = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Controls.Add(this.cboMedicine);
            this.panel1.Controls.Add(this.txtMinAllowed);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 123);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(374, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnInsert.Location = new System.Drawing.Point(374, 16);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Thêm mới";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cboMedicine
            // 
            this.cboMedicine.DisplayMember = "Text";
            this.cboMedicine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboMedicine.FormattingEnabled = true;
            this.cboMedicine.ItemHeight = 14;
            this.cboMedicine.Location = new System.Drawing.Point(190, 16);
            this.cboMedicine.Name = "cboMedicine";
            this.cboMedicine.Size = new System.Drawing.Size(147, 20);
            this.cboMedicine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboMedicine.TabIndex = 2;
            // 
            // txtMinAllowed
            // 
            // 
            // 
            // 
            this.txtMinAllowed.Border.Class = "TextBoxBorder";
            this.txtMinAllowed.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMinAllowed.Location = new System.Drawing.Point(190, 58);
            this.txtMinAllowed.Name = "txtMinAllowed";
            this.txtMinAllowed.Size = new System.Drawing.Size(147, 20);
            this.txtMinAllowed.TabIndex = 1;
            this.txtMinAllowed.TextChanged += new System.EventHandler(this.txtMinAllowed_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên thuốc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng thuốc thấp nhất cho phép";
            // 
            // frmWareHouseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 150);
            this.Controls.Add(this.panel1);
            this.Name = "frmWareHouseEdit";
            this.Text = "Nhập loại thuốc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMinAllowed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboMedicine;
    }
}