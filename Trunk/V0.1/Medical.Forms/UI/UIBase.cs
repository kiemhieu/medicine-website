using System;
using System.Windows.Forms;
using Medical.Forms.Enums;
using Medical.Forms.EventArgs;

namespace Medical.Forms.UI
{
    public partial class UiBase : UserControl
    {
        public event EventHandler<UIViewEventArgs> RequestActionFromUiEvent;
        public event EventHandler<UIToViewEventArgs> RequestActionToViewEvent;
        // public event EventHandler<System.EventArgs> RequestCloseEvent;

        public UiBase()
        {
            InitializeComponent();
        }

        public void MoveTo(string viewId, Object parameter)
        {
            var args = new UIViewEventArgs()
                        {
                            EventType = UIViewEventType.RequestMove,
                            ViewId = viewId,
                            ViewParameter = parameter
                        };
            FireEvent(args);
        }

        public void TranferTo(string viewId, Object parameter)
        {
            var args = new UIViewEventArgs()
                           {
                               EventType = UIViewEventType.RequestTranfer, 
                               ViewId = viewId, 
                               ViewParameter = parameter
                           };
            FireEvent(args);
        }

        public void TranferInDialog(string viewId, Object parameter)
        {
            var args = new UIViewEventArgs()
            {
                EventType = UIViewEventType.RequestTranferInDialog,
                ViewId = viewId,
                ViewParameter = parameter
            };
            FireEvent(args);
        }

        public void Back()
        {
            var args = new UIViewEventArgs() { EventType = UIViewEventType.RequestBack};
            FireEvent(args);
        }

        public void ShowMessage(string messageId, params Object[] parameter)
        {
            var args = new UIViewEventArgs()
                           {
                               EventType = UIViewEventType.RequestShowMessage, 
                               MessageId = messageId, 
                               ViewParameter = parameter
                           };
            FireEvent(args);
        }

        protected Object DoAction(String actionKey, params Object[] parameter)
        {
            if (RequestActionToViewEvent == null) return null;
            var args = new UIToViewEventArgs(actionKey, parameter);
            RequestActionToViewEvent(this, args);
            return args.Result;
        }

        protected String SelectFile(string filter)
        {
            var args = new UIViewEventArgs()
            {
                EventType = UIViewEventType.RequestOpenSelectFile,
                FileFilter = filter
            };
            FireEvent(args);
            return (String)args.Result;
        }

        protected String SaveFile(string filter)
        {
            var args = new UIViewEventArgs()
            {
                EventType = UIViewEventType.RequestOpenSaveFile,
                FileFilter = filter
            };
            FireEvent(args);
            return (String)args.Result;
        }

        protected String SelectFolder()
        {
            var args = new UIViewEventArgs() { EventType = UIViewEventType.RequestOpenSelectFolder };
            FireEvent(args);
            return (String)args.Result;
        }

        protected void LockScreen()
        {
            var args = new UIViewEventArgs() { EventType = UIViewEventType.LockScreen};
            FireEvent(args);
        }

        protected void UnLockScreen()
        {
            var args = new UIViewEventArgs() { EventType = UIViewEventType.UnLockScreen };
            FireEvent(args);
        }

        protected void Close()
        {
            var args = new UIViewEventArgs() { EventType = UIViewEventType.Close };
            FireEvent(args);
        }

        protected Object RequestViewDoAction(string key, params Object [] parameters)
        {
            if (RequestActionToViewEvent == null) return null;
            var args = new UIToViewEventArgs(key, parameters);
            RequestActionToViewEvent(this, args);
            return args.Result;
        }

        private void FireEvent(UIViewEventArgs eventArgs)
        {
            if (RequestActionFromUiEvent == null) return;
            RequestActionFromUiEvent(this, eventArgs);
        }
    }
}
