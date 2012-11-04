using System;
using Medical.Forms.Enums;
using Medical.Forms.EventArgs;
using Medical.Forms.Interfaces;
using Medical.Forms.UI;

namespace Medical.Forms.Implements
{
    public class ViewBase : IView
    {
        // Event Handler
        public event EventHandler<UIViewEventArgs> ViewActionRequestEvent;
        public event EventHandler<RequestDialogFromEventArgs> RequestOnShowingDialog;
        public event EventHandler<System.EventArgs> RequestClose;


        public bool IsInDialog { get; set; }
        public bool IsCanMove { get; set; }
        public object Parameters { get; set; }
        public object Result { get; set; }
        public ViewModes ViewModes { get; set; }

        private UiBase _ui;
        public UiBase UI
        {
            get { return _ui; }
            set
            {
                _ui = value;
                _ui.RequestActionFromUiEvent += UiRequestActionFromUiEvent;
                _ui.RequestActionToViewEvent += UiRequestActionToViewEvent;
            }
        }

        public virtual string Name
        {
            get { return "View Name"; }
        }

        private void UiRequestActionFromUiEvent(object sender, UIViewEventArgs e)
        {
            ApplicationMode.Out("Request form UI, event=" + e.EventType);
            switch (e.EventType)
            {
                case UIViewEventType.RequestMove:
                    MoveToView(e.ViewId, e.ViewParameter);
                    break;
                case UIViewEventType.RequestTranfer:
                    this.IsInDialog = false;
                    TranferToView(e.ViewId, e.ViewParameter);
                    break;
                case UIViewEventType.RequestTranferInDialog:
                    this.IsInDialog = true;
                    TranferToViewInDialog(e.ViewId, e.ViewParameter);
                    break;
                case UIViewEventType.RequestBack:
                    GoBack();
                    break;
                case UIViewEventType.RequestShowMessage:
                    e.Result = FireRequestMessageEvent(new RequestDialogFromEventArgs() { DialogMode = DialogMode.Message, MessageId = e.MessageId, Parameters = e.MessageParam });
                    break;
                case UIViewEventType.RequestExecuteAction:
                    break;
                case UIViewEventType.RequestOpenSelectFile:
                    e.Result = FireRequestMessageEvent(new RequestDialogFromEventArgs() { DialogMode = DialogMode.FileChooser, FileFilter = e.FileFilter});
                    break;
                case UIViewEventType.RequestOpenSelectFolder:
                    e.Result = FireRequestMessageEvent(new RequestDialogFromEventArgs() { DialogMode = DialogMode.FolderChooser });
                    break;
                case UIViewEventType.RequestOpenSaveFile:
                    e.Result = FireRequestMessageEvent(new RequestDialogFromEventArgs() { DialogMode = DialogMode.SaveFile, FileFilter = e.FileFilter });
                    break;
                case UIViewEventType.LockScreen:
                    e.Result = FireRequestMessageEvent(new RequestDialogFromEventArgs() { DialogMode = DialogMode.LockScreen });
                    break;
                case UIViewEventType.UnLockScreen:
                    e.Result = FireRequestMessageEvent(new RequestDialogFromEventArgs() { DialogMode = DialogMode.UnlockScreen });
                    break;
                case UIViewEventType.Close:
                    Close();
                    break;
                default:
                    break;
            }
        }

        public bool IsCanGoBack { get; set; }

        public void Lock()
        {
            FireEvent(new UIViewEventArgs() { EventType = UIViewEventType.LockScreen });
        }

        public void UnLock()
        {
            FireEvent(new UIViewEventArgs() { EventType = UIViewEventType.UnLockScreen });
        }

        public bool Validate()
        {
            return IsCanMove;
        }

        public void Show(ShowModes showMode)
        {

        }

        public void MoveToView(string key, object parameter)
        {
            FireEvent(new UIViewEventArgs()
                          {
                              EventType = UIViewEventType.RequestMove,
                              ViewId = key,
                              ViewParameter = parameter
                          });
        }

        public void TranferToView(string key, object parameter)
        {
            FireEvent(new UIViewEventArgs()
                          {
                              EventType = UIViewEventType.RequestTranfer,
                              ViewId = key,
                              ViewParameter = parameter
                          });
        }

        public object TranferToViewInDialog(string key, object parameter)
        {
            return FireEvent(new UIViewEventArgs()
                                 {
                                     EventType = UIViewEventType.RequestTranferInDialog,
                                     ViewId = key,
                                     ViewParameter = parameter
                                 });
        }

        public void GoBack()
        {
            FireEvent(new UIViewEventArgs() { EventType = UIViewEventType.RequestBack });
        }

        private object FireEvent(UIViewEventArgs eventArgs)
        {
            if (ViewActionRequestEvent == null) return null;
            ViewActionRequestEvent(this, eventArgs);
            return eventArgs.Result;
        }

        private object FireRequestMessageEvent(RequestDialogFromEventArgs eventArgs)
        {
            if (RequestOnShowingDialog == null) return null;
            RequestOnShowingDialog(this, eventArgs);
            return eventArgs.Result;
        }

        private void Close()
        {
            if (RequestClose == null) return;
            RequestClose(this, System.EventArgs.Empty);
        }

        public virtual void Activate() { }
        public virtual void DeActivated() { }
        public virtual void RefreshData() { }
        protected virtual void UiRequestActionToViewEvent(object sender, UIToViewEventArgs e) { }
    }
}
