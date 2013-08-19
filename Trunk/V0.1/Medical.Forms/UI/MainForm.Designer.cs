namespace Medical.Forms.UI
{
    partial class MainForm
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSync = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.logViewer = new System.Windows.Forms.ToolStripSplitButton();
            this.txtLoggedIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtClinic = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.dockingPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuChecking = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.mnuHelp});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(900, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.mnuLogout,
            this.toolStripSeparator1,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileToolStripMenuItem.Text = "Tệp tin";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Image = global::Medical.Forms.Properties.Resources.login;
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(132, 22);
            this.mnuLogin.Text = "Đăng nhập";
            // 
            // mnuLogout
            // 
            this.mnuLogout.Image = global::Medical.Forms.Properties.Resources.logout;
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(132, 22);
            this.mnuLogout.Text = "Đăng xuất";
            this.mnuLogout.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::Medical.Forms.Properties.Resources.stop;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(132, 22);
            this.mnuExit.Text = "Thoát";
            this.mnuExit.Click += new System.EventHandler(this.ThoatToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSync,
            this.mnuChangePassword,
            this.toolStripSeparator2,
            this.mnuChecking,
            this.mnuServer});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.editToolStripMenuItem.Text = "Hệ thống";
            // 
            // mnuSync
            // 
            this.mnuSync.Image = global::Medical.Forms.Properties.Resources.sync;
            this.mnuSync.Name = "mnuSync";
            this.mnuSync.Size = new System.Drawing.Size(206, 22);
            this.mnuSync.Text = "Đồng bộ hóa dữ liệu";
            this.mnuSync.Click += new System.EventHandler(this.DongBoHoaDuLieuToolStripMenuItemClick);
            // 
            // mnuChangePassword
            // 
            this.mnuChangePassword.Image = global::Medical.Forms.Properties.Resources.user_chat;
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Size = new System.Drawing.Size(206, 22);
            this.mnuChangePassword.Text = "Đổi mật khẩu";
            this.mnuChangePassword.Click += new System.EventHandler(this.DoiMatKhauToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // mnuServer
            // 
            this.mnuServer.Image = global::Medical.Forms.Properties.Resources.computer_retro;
            this.mnuServer.Name = "mnuServer";
            this.mnuServer.Size = new System.Drawing.Size(206, 22);
            this.mnuServer.Text = "Máy chủ";
            this.mnuServer.Click += new System.EventHandler(this.MnuServerClick);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(64, 20);
            this.mnuHelp.Text = "Trợ giúp";
            this.mnuHelp.Click += new System.EventHandler(this.MnuHelpClick);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewer,
            this.txtLoggedIn,
            this.txtClinic,
            this.toolStripSplitButton1,
            this.toolStripProgressBar,
            this.toolStripStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 581);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(900, 26);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // logViewer
            // 
            this.logViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logViewer.Name = "logViewer";
            this.logViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.logViewer.Size = new System.Drawing.Size(16, 24);
            this.logViewer.Text = "toolStripSplitButton1";
            this.logViewer.Click += new System.EventHandler(this.LogViewerClick);
            // 
            // txtLoggedIn
            // 
            this.txtLoggedIn.AutoSize = false;
            this.txtLoggedIn.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtLoggedIn.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.txtLoggedIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoggedIn.Name = "txtLoggedIn";
            this.txtLoggedIn.Size = new System.Drawing.Size(150, 21);
            this.txtLoggedIn.Text = "----";
            // 
            // txtClinic
            // 
            this.txtClinic.AutoSize = false;
            this.txtClinic.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtClinic.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.txtClinic.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClinic.Name = "txtClinic";
            this.txtClinic.Size = new System.Drawing.Size(200, 21);
            this.txtClinic.Text = "---";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.AutoSize = false;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 20);
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.AutoToolTip = true;
            this.toolStripStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(38, 21);
            this.toolStripStatus.Text = "Ready";
            this.toolStripStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkerDoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WorkerProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WorkerRunWorkerCompleted);
            // 
            // dockingPanel
            // 
            this.dockingPanel.AllowEndUserDocking = false;
            this.dockingPanel.AllowEndUserNestedDocking = false;
            this.dockingPanel.BackgroundImage = global::Medical.Forms.Properties.Resources.logo_hanoiPAC;
            this.dockingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dockingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockingPanel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockingPanel.Location = new System.Drawing.Point(0, 24);
            this.dockingPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dockingPanel.Name = "dockingPanel";
            this.dockingPanel.ShowDocumentIcon = true;
            this.dockingPanel.Size = new System.Drawing.Size(900, 557);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockingPanel.Skin = dockPanelSkin1;
            this.dockingPanel.TabIndex = 4;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = global::Medical.Forms.Properties.Resources.info;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // mnuChecking
            // 
            this.mnuChecking.Name = "mnuChecking";
            this.mnuChecking.Size = new System.Drawing.Size(206, 22);
            this.mnuChecking.Text = "Kiểm tra kết nối máy chủ";
            this.mnuChecking.Click += new System.EventHandler(this.MnuCheckingClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 607);
            this.Controls.Add(this.dockingPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuSync;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockingPanel;
        private System.Windows.Forms.ToolStripSplitButton logViewer;
        private System.Windows.Forms.ToolStripStatusLabel txtLoggedIn;
        private System.Windows.Forms.ToolStripStatusLabel txtClinic;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuServer;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem mnuChecking;
    }
}