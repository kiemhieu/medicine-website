using System;
using System.Windows.Forms;
using Medical.Forms.Enums;
using Medical.Forms.EventArgs;
using Medical.Forms.Implements;
using Medical.Forms.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Forms.UI
{
    public partial class MainForm : Form
    {
        private readonly string _iconPath = Application.StartupPath + "\\Icons";
        private delegate void Method(ProgressiveUpdateArgs arg);

        private TreeMenu treeMenu;

        public IContainerProvider ViewContainer { get; set; }
        public IMessageManager MessageContainer { get; set; }
        public ViewManager ViewManager { get; set; }
        public IContainerProvider ModuleContainer { private get; set; }
        public IMenuManager TopMenu { private get; set; }
        //public IContextManager Context { private get; set; }
        public ILogManager LogManager { private get; set; }

        public MainForm()
        {
            InitializeComponent();
            ExceptionHandler.Instance.ErrorOccur += InstanceErrorOccur;
            MethodExecuter.Instance.MethodExecuteRequestEvent += new EventHandler<ActionArgs>(InstanceMethodExecuteRequestEvent);
            MethodExecuter.Instance.MethodExecuteUpdateProgressEvent += new EventHandler<ProgressiveUpdateArgs>(InstanceMethodExecuteUpdateProgressEvent);


            // Init Tree view
            treeMenu = new TreeMenu();
            treeMenu.ShowHint = DockState.DockLeft;
            treeMenu.AllowEndUserDocking = false;
            treeMenu.CloseButton = false;
            treeMenu.IsFloat = false;
            treeMenu.CloseButtonVisible = false;
            treeMenu.Show(dockingPanel);
        }

        public void CommonInitilize() {
            ProgressiveDialogWraper.Instance.Parent = this;
            this.TopMenu.CreateMenuItem(this.treeMenu.TreeViewMenu);
            this.TopMenu.MenuItemClicked += TrivMenuMenuItemClicked;
            this.TopMenu.CreateToolBar(this.MainToolBar);

            this.ViewManager = new ViewManager(this.ModuleContainer, this.dockingPanel);
            // ViewManager.OnRequestDialogEventArgs += ViewManagerOnRequestDialogEventArgs;
            // ViewManager.ViewChange += ViewManagerViewChange;
            MessageDialog.Instance.MessageContainer = this.MessageContainer;
            ExceptionHandler.Instance.Log = this.LogManager;

            logViewer.Image = System.Drawing.Image.FromFile(_iconPath + "\\info.png");
        }

        private void InstanceMethodExecuteUpdateProgressEvent(object sender, ProgressiveUpdateArgs e)
        {
            Console.WriteLine("Update progress: " + e.Value + " -" + e.Status);
            if (worker.IsBusy)
            {
                worker.ReportProgress(0, e);
            }
            else
            {
                UpdateProgressive(e);
            }
            //this.Invoke(new Method(this.UpdateProgressive), arg);
        }

        private void InstanceMethodExecuteRequestEvent(object sender, ActionArgs e) {
            Console.WriteLine("Request run method: " + e.MethodExecuter.Method.Name);
            if (e.MethodExecuter == null) return;
            this.worker.RunWorkerAsync(e.MethodExecuter);
            ProgressiveDialog.Instance.ShowProgress(this);
        }

        private void InstanceErrorOccur(object sender, System.EventArgs e)
        {
            MessageDialog.Instance.ShowMessage(this, "ERR0001", "Đã có lỗi xảy ra. Xem log để biết thêm chi tiết");
            logViewer.Image = System.Drawing.Image.FromFile(_iconPath + "\\erro_occur.png");
        }

        

        private void ViewManagerViewChange(object sender, ViewChangeEventArgs e)
        {
            switch (e.Status)
            {
                case ViewChangeStatus.Change:
                    // Show waiting dialog
                    this.Enabled = false;
                    this.toolStripStatus.Text = "Loading ...";
                    this.toolStripProgressBar.Visible = true;
                    this.toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    this.toolStripProgressBar.Maximum = 100;
                    this.toolStripProgressBar.Minimum = 0;
                    this.toolStripProgressBar.Value = 30;
                    
                    this.Update();
                    break;
                case ViewChangeStatus.Changing:
                    if (!e.IsInDialogMode)
                    {
                        // Attach UI to the view
                        // this.pnlMainPanel.Controls.Clear();
                        // pnlMainPanel.Controls.Add(this.ViewManager.CurrentView.UI);
                        // this.Text = this.ViewManager.CurrentView.Name;
                        // this.ViewManager.CurrentView.UI.Dock = DockStyle.Fill;
                        this.Update();
                        this.toolStripProgressBar.Value = 80;
                    } else {
                        // TODO Attach screen when it's needed to show in dialog
                        var viewDialog = new ViewDialog();
                        // viewDialog.AttachToView(this.ViewManager.CurrentView);
                        viewDialog.Closed += new EventHandler(ViewDialogClosed);
                        viewDialog.ShowDialog(this);
                    }
                    break;
                case ViewChangeStatus.Changed:
                    // Close waiting dialog
                    this.toolStripProgressBar.Value = 100;
                    this.Update();
                    this.toolStripStatus.Text = "Ready";
                    this.Enabled = true;
                    this.toolStripProgressBar.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void ViewDialogClosed(object sender, System.EventArgs e)
        {
            // this.ViewManager.Back();
        }

        private void ViewManagerOnRequestDialogEventArgs(object sender, RequestDialogFromEventArgs e)
        {
            switch (e.DialogMode)
            {
                case DialogMode.Message:
                    MessageDialog.Instance.ShowMessage(this, e.MessageId, e.Parameters);
                    break;
                case DialogMode.FileChooser:
                    openFileDialog.Filter = e.FileFilter;
                    openFileDialog.Multiselect = false;
                    var result = openFileDialog.ShowDialog(this);
                    if (result == DialogResult.OK) e.Result = openFileDialog.FileName;
                    break;
                case DialogMode.FolderChooser:
                    var openFileDialogResult = folderBrowserDialog.ShowDialog(this);
                    if (openFileDialogResult == DialogResult.OK) e.Result = folderBrowserDialog.SelectedPath;
                    break;
                case DialogMode.SaveFile:
                    saveFileDialog.Filter = e.FileFilter;
                    var saveFileResult = saveFileDialog.ShowDialog(this);
                    if (saveFileResult == DialogResult.OK) e.Result = saveFileDialog.FileName;
                    break;
                case DialogMode.LockScreen:
                    this.Enabled = false;
                    break;
                case DialogMode.UnlockScreen:
                    this.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Console.WriteLine("Hello");
        }

        /// <summary>
        /// Trivs the menu menu item clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MenuItemClickedEventArgs"/> instance containing the event data.</param>
        private void TrivMenuMenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            //var item = (ToolStripMenuItem) sender;
            //if (item == null) return;
            //var menuItem = (TopMenuItem) item.Tag;
            //if (menuItem == null) return;

            if (!string.IsNullOrEmpty(e.Key)) {
                this.ViewManager.showDocument(e.Key);
                return; ;
            }

            if (!string.IsNullOrEmpty(e.InvokeKey))
            {
                switch (e.InvokeKey)
                {
                    case "SysmteExit":
                        DialogResult result = MessageDialog.Instance.ShowMessage(this, "MSG0002");
                        if (result == DialogResult.Yes) Application.Exit();
                        break;;
                    default:
                        break;
                }
            }
        }

        private void LogViewerClick(object sender, System.EventArgs e)
        {
            logViewer.Image = System.Drawing.Image.FromFile(_iconPath + "\\info.png");
            var dialog = new LogViewerDialog();
            dialog.ShowDialog(this);
        }

        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Console.WriteLine(">>>> Run method");
            var a = e.Argument as Action;
            if (a != null) a.Invoke();
        }

        private void WorkerProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var arg = e.UserState as ProgressiveUpdateArgs;
            if (arg == null) return;
            UpdateProgressive(arg);
            //this.Invoke(new Method(this.UpdateProgressive), arg);
        }

        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ProcessEndWorker(e.Error);
        }

        private void ProcessEndWorker(Exception error)
        {
            ProgressiveDialog.Instance.CloseProgress();
            ProgressiveDialog.Instance.Close();

            if (error == null)
            {
                MessageDialog.Instance.ShowMessage(this, "MSG0001");
                this.toolStripProgressBar.Visible = false;
                this.toolStripStatus.Text = "Action performed successfully";
            }
            else
            {
                ExceptionHandler.Instance.HandlerException(error);
                //MessageDialog.Instance.ShowMessage(this, "ERR0001", error.Message);
                this.toolStripProgressBar.Visible = false;
                this.toolStripStatus.Text = "Error: " + error.Message;
                logViewer.Image = System.Drawing.Image.FromFile(_iconPath + "\\erro_occur.png");
            }
        }

        public void UpdateProgressive(ProgressiveUpdateArgs arg)
        {
            switch (arg.Mode)
            {
                case ProgressUpdateMode.Reset:
                    if (this.worker.IsBusy) ProgressiveDialog.Instance.Initialize(0, arg.Maximum);
                    this.toolStripProgressBar.Maximum = arg.Maximum;
                    this.toolStripProgressBar.Value = 0;
                    this.toolStripStatus.Text = string.Empty;
                    this.toolStripProgressBar.Visible = true;
                    break;
                case ProgressUpdateMode.Update:
                    if (arg.Value != 0 && !String.IsNullOrEmpty(arg.Status))
                    {
                        if (this.worker.IsBusy) ProgressiveDialog.Instance.UpdateProgress(arg.Status, arg.Value);
                        this.toolStripStatus.Text = arg.Status;
                        this.toolStripProgressBar.Value = arg.Value;
                    }
                    else if (arg.Value != 0)
                    {
                        if (this.worker.IsBusy) ProgressiveDialog.Instance.UpdateProgress(arg.Value);
                        this.toolStripProgressBar.Value = arg.Value;
                    }
                    else if (!String.IsNullOrEmpty(arg.Status))
                    {
                        if (this.worker.IsBusy) ProgressiveDialog.Instance.UpdateStatus(arg.Status);
                        this.toolStripStatus.Text = arg.Status;
                    }
                    break;
                case ProgressUpdateMode.AddProgress:
                    if (arg.Value != 0 && !String.IsNullOrEmpty(arg.Status))
                    {
                        if (this.worker.IsBusy) ProgressiveDialog.Instance.AddProgress(arg.Status, arg.Value);
                        this.toolStripStatus.Text = arg.Status;
                        this.toolStripProgressBar.Value += arg.Value;
                    }
                    else if (arg.Value != 0)
                    {
                        if (this.worker.IsBusy) ProgressiveDialog.Instance.AddProgress(arg.Value);
                        this.toolStripProgressBar.Value += arg.Value;
                    }
                    break;
                case ProgressUpdateMode.Finish:
                    this.toolStripStatus.Text = "Ready";
                    this.toolStripProgressBar.Value = this.toolStripProgressBar.Maximum;
                    this.toolStripProgressBar.Visible = false; 
                    break;
                default:
                    break;
            }
        }

        private void MainForm_Shown(object sender, System.EventArgs e) {
            Login login = new Login();
            login.ShowDialog(this);
        }
    }
}
