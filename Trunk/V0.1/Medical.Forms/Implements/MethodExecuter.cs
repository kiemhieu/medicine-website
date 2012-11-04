using System;
using Medical.Forms.Enums;
using Medical.Forms.EventArgs;

namespace Medical.Forms.Implements
{
    public class MethodExecuter
    {

        public event EventHandler<ActionArgs> MethodExecuteRequestEvent;
        public event EventHandler<ProgressiveUpdateArgs> MethodExecuteUpdateProgressEvent;

        public void Execute(Action action)
        {
            if (MethodExecuteRequestEvent == null) return;
            var args = new ActionArgs(action);
            MethodExecuteRequestEvent(this, args);
        }

        public void ResetProgress(int maximum, string status)
        {
            var args = new ProgressiveUpdateArgs() { Maximum = maximum, Status = status, Mode = ProgressUpdateMode.Reset };
            if (MethodExecuteUpdateProgressEvent == null) return;
            MethodExecuteUpdateProgressEvent(this, args);
        }

        public void UpdateProgress(int value, string status, ProgressUpdateMode mode)
        {
            var args = new ProgressiveUpdateArgs() { Value = value, Status = status, Mode = mode };
            if (MethodExecuteUpdateProgressEvent == null) return;
            MethodExecuteUpdateProgressEvent(this, args);
        }

        public void UpdateProgress(int value, ProgressUpdateMode mode)
        {
            var args = new ProgressiveUpdateArgs() { Value = value, Mode = mode };
            if (MethodExecuteUpdateProgressEvent == null) return;
            MethodExecuteUpdateProgressEvent(this, args);
        }

        public void UpdateProgress(string status)
        {
            var args = new ProgressiveUpdateArgs() { Status = status, Mode = ProgressUpdateMode.Update };
            if (MethodExecuteUpdateProgressEvent == null) return;
            MethodExecuteUpdateProgressEvent(this, args);
        }

        public void Finish()
        {
            var args = new ProgressiveUpdateArgs() { Mode = ProgressUpdateMode.Finish };
            if (MethodExecuteUpdateProgressEvent == null) return;
            MethodExecuteUpdateProgressEvent(this, args);
        }

        private static MethodExecuter _instance;
        public static MethodExecuter Instance
        {
            get { return _instance ?? (_instance = new MethodExecuter()); }
        }
    }
}
