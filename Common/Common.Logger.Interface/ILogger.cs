using System;

namespace Common.Logger.Interface
{
    public interface ILogger
    {
        #region Debug
        void LogDebug(string message);
        #endregion

        #region Info
        void LogInfo(string message);
        #endregion

        #region Warn
        void LogWarn(string message);
        #endregion

        #region Error
        void LogError(string message);
        void LogError(Exception exception, string message = null);
        #endregion

        #region Fatal
        void LogFatal(string message);
        #endregion
    }
}
