using System;
using System.Text;
using Medical.Forms.Interfaces;

namespace Medical.Forms.Implements
{
    public class ExceptionHandler
    {
        public event EventHandler ErrorOccur;
        public ILogManager Log { get; set; }

        public void HandlerException(Exception ex)
        {
            var strBuilder = new StringBuilder();
            var exception = ex;
            while (exception != null)
            {
                strBuilder.Append(exception.HelpLink);
                strBuilder.AppendLine("Source: " + exception.Source);
                strBuilder.AppendLine("Stack: " + exception.StackTrace);
                strBuilder.Append("Method : " + exception.TargetSite.Name + "(");
                foreach (var parameterInfo in exception.TargetSite.GetParameters())
                {
                    strBuilder.Append(parameterInfo.GetType() + "   " + parameterInfo.Name);
                }
                strBuilder.Append(");");
                strBuilder.AppendLine();
                strBuilder.AppendLine(exception.Message);
                strBuilder.AppendLine();
                strBuilder.AppendLine();
                exception = exception.InnerException;
            }

            Log.LogError("ERR0001", strBuilder.ToString());

            if (ErrorOccur != null) ErrorOccur(this, System.EventArgs.Empty);
            //throw ex;
        }

        private static ExceptionHandler _instance;
        public static ExceptionHandler Instance
        {
            get { return _instance ?? (_instance = new ExceptionHandler()); }
        }
    }
}
