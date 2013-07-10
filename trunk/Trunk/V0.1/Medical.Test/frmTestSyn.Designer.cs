namespace Medical.Test
{
    partial class frmTestSyn
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
            this.btnSendAll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendAll
            // 
            this.btnSendAll.Location = new System.Drawing.Point(23, 12);
            this.btnSendAll.Name = "btnSendAll";
            this.btnSendAll.Size = new System.Drawing.Size(75, 23);
            this.btnSendAll.TabIndex = 0;
            this.btnSendAll.Text = "Send all";
            this.btnSendAll.UseVisualStyleBackColor = true;
            this.btnSendAll.Click += new System.EventHandler(this.btnSendAll_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reiceve all";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmTestSyn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 48);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSendAll);
            this.Name = "frmTestSyn";
            this.Text = "frmTestSyn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendAll;
        private System.Windows.Forms.Button button2;

    }
}