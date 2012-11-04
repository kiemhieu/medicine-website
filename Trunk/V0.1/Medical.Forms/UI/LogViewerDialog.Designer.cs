namespace Medical.Forms.UI
{
    partial class LogViewerDialog
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
            this.lsbLogFiles = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsbLogFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(200, 486);
            this.panel1.TabIndex = 0;
            // 
            // lsbLogFiles
            // 
            this.lsbLogFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbLogFiles.FormattingEnabled = true;
            this.lsbLogFiles.Location = new System.Drawing.Point(10, 10);
            this.lsbLogFiles.Margin = new System.Windows.Forms.Padding(5);
            this.lsbLogFiles.Name = "lsbLogFiles";
            this.lsbLogFiles.Size = new System.Drawing.Size(180, 466);
            this.lsbLogFiles.TabIndex = 0;
            this.lsbLogFiles.SelectedIndexChanged += new System.EventHandler(this.LsbLogFilesSelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtbContent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(566, 486);
            this.panel2.TabIndex = 1;
            // 
            // rtbContent
            // 
            this.rtbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbContent.Location = new System.Drawing.Point(10, 10);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.ReadOnly = true;
            this.rtbContent.Size = new System.Drawing.Size(546, 466);
            this.rtbContent.TabIndex = 0;
            this.rtbContent.Text = "";
            // 
            // LogViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "LogViewerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log";
            this.Load += new System.EventHandler(this.LogViewerDialogLoad);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lsbLogFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtbContent;
    }
}