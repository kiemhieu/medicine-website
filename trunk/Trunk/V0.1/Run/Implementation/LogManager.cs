using log4net;
using Medical.Forms.Enums;
using Medical.Forms.Interfaces;

namespace Run.Implementation
{
    public class LogManager : ILogManager
    {

        protected static readonly ILog Log = log4net.LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// Initializes a new instance of the <see cref="LogManager"/> class.
        /// </summary>
        public LogManager()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Logs the out put.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="logType">Type of the log.</param>
        /// <param name="param">The param.</param>
        public void LogOutPut(string messageId, LogType logType, params object[] param)
        {
            string message = this.MessageProvider.GetMessageByID(messageId).Content;
            switch (logType)
            {
                case LogType.Info:
                    Log.InfoFormat(message, param);
                    break;
                case LogType.Warning:
                    Log.WarnFormat(message, param);
                    break;
                case LogType.Error:
                    Log.ErrorFormat(message, param);
                    break;
                case LogType.Fatal:
                    Log.FatalFormat(message, param);
                    break;
                default:
                    break;
            }
        }

        public IMessageManager MessageProvider { get; set;  }

        public void LogInfo(string messageId, params object[] param)
        {
            LogOutPut(messageId, LogType.Info, param);
        }

        public void LogError(string messageId, params object[] param)
        {
            LogOutPut(messageId, LogType.Error, param);
        }

        public void LogWarning(string messageId, params object[] param)
        {
            LogOutPut(messageId, LogType.Warning, param);
        }
    }
}

