﻿namespace Medical.Test
{
    partial class frmMedicinEdit
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
            this.grpMaster = new System.Windows.Forms.GroupBox();
            this.rdNTCH = new System.Windows.Forms.RadioButton();
            this.rdARV = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContentUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTradeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaThuoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnButton = new DevComponents.DotNetBar.PanelEx();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnCancle = new DevComponents.DotNetBar.ButtonX();
            this.grpMaster.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMaster
            // 
            this.grpMaster.Controls.Add(this.rdNTCH);
            this.grpMaster.Controls.Add(this.rdARV);
            this.grpMaster.Controls.Add(this.label8);
            this.grpMaster.Controls.Add(this.txtDescription);
            this.grpMaster.Controls.Add(this.label7);
            this.grpMaster.Controls.Add(this.txtUnit);
            this.grpMaster.Controls.Add(this.label6);
            this.grpMaster.Controls.Add(this.txtContentUnit);
            this.grpMaster.Controls.Add(this.label5);
            this.grpMaster.Controls.Add(this.txtTradeName);
            this.grpMaster.Controls.Add(this.label4);
            this.grpMaster.Controls.Add(this.txtContent);
            this.grpMaster.Controls.Add(this.label3);
            this.grpMaster.Controls.Add(this.txtTenThuoc);
            this.grpMaster.Controls.Add(this.label2);
            this.grpMaster.Controls.Add(this.txtMaThuoc);
            this.grpMaster.Controls.Add(this.label1);
            this.grpMaster.Location = new System.Drawing.Point(12, 12);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(848, 133);
            this.grpMaster.TabIndex = 6;
            this.grpMaster.TabStop = false;
            this.grpMaster.Text = "Thông tin thuốc";
            // 
            // rdNTCH
            // 
            this.rdNTCH.AutoSize = true;
            this.rdNTCH.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdNTCH.Location = new System.Drawing.Point(654, 101);
            this.rdNTCH.Name = "rdNTCH";
            this.rdNTCH.Size = new System.Drawing.Size(114, 17);
            this.rdNTCH.TabIndex = 8;
            this.rdNTCH.TabStop = true;
            this.rdNTCH.Text = "Nhiễm trùng cơ hội";
            this.rdNTCH.UseVisualStyleBackColor = true;
            // 
            // rdARV
            // 
            this.rdARV.AutoSize = true;
            this.rdARV.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rdARV.Location = new System.Drawing.Point(563, 100);
            this.rdARV.Name = "rdARV";
            this.rdARV.Size = new System.Drawing.Size(45, 17);
            this.rdARV.TabIndex = 7;
            this.rdARV.TabStop = true;
            this.rdARV.Text = "ARV";
            this.rdARV.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(470, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Nhóm thuốc";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(122, 98);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(225, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.Location = new System.Drawing.Point(17, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Diễn giải";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(563, 72);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 6;
            this.txtUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnit_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(470, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Đơn vị";
            // 
            // txtContentUnit
            // 
            this.txtContentUnit.Location = new System.Drawing.Point(563, 46);
            this.txtContentUnit.Name = "txtContentUnit";
            this.txtContentUnit.Size = new System.Drawing.Size(100, 20);
            this.txtContentUnit.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(470, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hàm lượng";
            // 
            // txtTradeName
            // 
            this.txtTradeName.Location = new System.Drawing.Point(122, 72);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(225, 20);
            this.txtTradeName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(17, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hãng sản xuất";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(563, 20);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(235, 20);
            this.txtContent.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.Location = new System.Drawing.Point(470, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thành phần";
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(122, 46);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(225, 20);
            this.txtTenThuoc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(17, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên thuốc";
            // 
            // txtMaThuoc
            // 
            this.txtMaThuoc.Location = new System.Drawing.Point(122, 20);
            this.txtMaThuoc.Name = "txtMaThuoc";
            this.txtMaThuoc.Size = new System.Drawing.Size(100, 20);
            this.txtMaThuoc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thuốc";
            // 
            // pnButton
            // 
            this.pnButton.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnButton.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnButton.Controls.Add(this.btnCancle);
            this.pnButton.Controls.Add(this.btnUpdate);
            this.pnButton.Location = new System.Drawing.Point(12, 149);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(847, 49);
            this.pnButton.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnButton.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnButton.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnButton.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnButton.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnButton.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnButton.Style.GradientAngle = 90;
            this.pnButton.TabIndex = 7;
            this.pnButton.Text = "panelEx1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnUpdate.Location = new System.Drawing.Point(302, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnCancle.Location = new System.Drawing.Point(495, 14);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "Hủy";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmMedicinEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 208);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.grpMaster);
            this.Name = "frmMedicinEdit";
            this.Text = "frmMedicinEdit";
            this.grpMaster.ResumeLayout(false);
            this.grpMaster.PerformLayout();
            this.pnButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaster;
        private System.Windows.Forms.RadioButton rdNTCH;
        private System.Windows.Forms.RadioButton rdARV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContentUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTradeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaThuoc;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.PanelEx pnButton;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnCancle;
    }
}