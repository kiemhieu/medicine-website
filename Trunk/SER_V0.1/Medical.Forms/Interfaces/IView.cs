using System;
using Medical.Forms.Enums;
using Medical.Forms.EventArgs;
using Medical.Forms.UI;

namespace Medical.Forms.Interfaces
{
    public interface IView
    {
        string Name { get; }
        object Parameters { get; set; }
        object Result { get; set; }
        ViewModes ViewModes { get; set; }
        UiBase UI { get; set; }
        Boolean IsCanGoBack { get; set; }
        Boolean IsCanMove { get; set; }
        bool IsInDialog { get; set; }

        event EventHandler<UIViewEventArgs> ViewActionRequestEvent;
        event EventHandler<RequestDialogFromEventArgs> RequestOnShowingDialog;
        event EventHandler<System.EventArgs> RequestClose;

        void Activate();
        void DeActivated();
        void RefreshData();
        void Lock();
        void UnLock();
        bool Validate();

        void Show(ShowModes showMode);
        void MoveToView(string key, Object parameter);
        void TranferToView(string key, Object parameter);
        void GoBack();




    }
}
