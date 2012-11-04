using Medical.Forms.Enums;

namespace Medical.Forms.Interfaces
{
    public interface ILogManager
    {
        IMessageManager MessageProvider { get; set; }

        void LogOutPut(string messageId, LogType logType, params object[] param);
        void LogInfo(string messageId, params object[] param);
        void LogError(string messageId, params object[] param);
        void LogWarning(string messageId, params object[] param);
    }


}
