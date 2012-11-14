namespace Medical.Test
{
    partial class frmFigureEdit
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
            this.pnItems = new DevComponents.DotNetBar.PanelEx();
            this.pnButton = new DevComponents.DotNetBar.PanelEx();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnCancle = new DevComponents.DotNetBar.ButtonX();
            this.txtFigureName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFigureName = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnItems.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnItems
            // 
            this.pnItems.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnItems.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnItems.Controls.Add(this.textBoxX1);
            this.pnItems.Controls.Add(this.labelX1);
            this.pnItems.Controls.Add(this.lblFigureName);
            this.pnItems.Controls.Add(this.txtFigureName);
            this.pnItems.Location = new System.Drawing.Point(12, 12);
            this.pnItems.Name = "pnItems";
            this.pnItems.Size = new System.Drawing.Size(530, 95);
            this.pnItems.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnItems.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnItems.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnItems.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnItems.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnItems.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnItems.Style.GradientAngle = 90;
            this.pnItems.TabIndex = 0;
            // 
            // pnButton
            // 
            this.pnButton.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnButton.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnButton.Controls.Add(this.btnCancle);
            this.pnButton.Controls.Add(this.btnUpdate);
            this.pnButton.Location = new System.Drawing.Point(13, 115);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(528, 37);
            this.pnButton.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnButton.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnButton.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnButton.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnButton.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnButton.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnButton.Style.GradientAngle = 90;
            this.pnButton.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnUpdate.Location = new System.Drawing.Point(137, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập nhật";
            // 
            // btnCancle
            // 
            this.btnCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancle.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnCancle.Location = new System.Drawing.Point(264, 3);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "Hủy";
            // 
            // txtFigureName
            // 
            // 
            // 
            // 
            this.txtFigureName.Border.Class = "TextBoxBorder";
            this.txtFigureName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFigureName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtFigureName.Location = new System.Drawing.Point(110, 14);
            this.txtFigureName.Name = "txtFigureName";
            this.txtFigureName.Size = new System.Drawing.Size(170, 20);
            this.txtFigureName.TabIndex = 0;
            // 
            // lblFigureName
            // 
            // 
            // 
            // 
            this.lblFigureName.BackgroundStyle.Class = "";
            this.lblFigureName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFigureName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.lblFigureName.Location = new System.Drawing.Point(19, 15);
            this.lblFigureName.Name = "lblFigureName";
            this.lblFigureName.Size = new System.Drawing.Size(75, 23);
            this.lblFigureName.TabIndex = 1;
            this.lblFigureName.Text = "Tên phác đồ";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.labelX1.Location = new System.Drawing.Point(19, 44);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Ghi chú";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(110, 44);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(403, 48);
            this.textBoxX1.TabIndex = 3;
            // 
            // frmFigureEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 164);
            this.Controls.Add(this.pnButton);
            this.Controls.Add(this.pnItems);
            this.Name = "frmFigureEdit";
            this.Text = "frmFigureEdit";
            this.pnItems.ResumeLayout(false);
            this.pnButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnItems;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFigureName;
        private DevComponents.DotNetBar.PanelEx pnButton;
        private DevComponents.DotNetBar.ButtonX btnCancle;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.LabelX lblFigureName;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}