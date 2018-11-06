using Common.Logger.Interface;
using Common.Modules.Base;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Common.Logger.Log4Net
{
    public class Log4NetLogger : BaseModule, ILogger
    {
        #region core
        private ILog _log;
        private string _configurationPath;
        private string _loggerName;
        private readonly object _locker = new object();
        #endregion

        #region init
        public Log4NetLogger(string name, IDictionary<string, string> parameters) : base(name, parameters)
        {
            RegisterInterface<ILogger>(this);
        }
        #endregion

        #region BaseModule
        public override void Startup()
        {
            base.Startup();
            _configurationPath = Parameters["config"];
            _loggerName = Parameters["loggerName"];
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetAssembly(typeof(Log4NetLogger))), new FileInfo(_configurationPath));

            _configurationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Substring(Assembly.GetExecutingAssembly().CodeBase.IndexOf("file") + 8)) + @"\" + _configurationPath;
            if (!File.Exists(_configurationPath))
                throw new Exception("Нет файла конфигурации");
            var fileInfo = new FileInfo(_configurationPath);
            XmlConfigurator.Configure(fileInfo);
            _log = LogManager.GetLogger(_loggerName);
        }
        public override void Shutdown()
        {
            base.Shutdown();
        }
        #endregion

        #region ILogger

        #region Debug
        public void LogDebug(string message)
        {
            lock (_locker)
            {
                _log.Debug(message);
            }
        }
        #endregion

        #region Info
        public void LogInfo(string message)
        {
            lock (_locker)
            {
                _log.Info(message);
            }
        }
        #endregion

        #region Warn
        public void LogWarn(string message)
        {
            lock (_locker)
            {
                _log.Warn(message);
            }
        }
        #endregion

        #region Error
        public void LogError(string message)
        {
            lock (_locker)
            {
                _log.Error(message);
            }
        }

        public void LogError(Exception exception, string message = null)
        {
            lock (_locker)
            {
                _log.Error(message, exception);
            }
        }
        #endregion

        #region Fatal
        public void LogFatal(string message)
        {
            lock (_locker)
            {
                _log.Fatal(message);
            }
        }
        #endregion

        #endregion
    }
}
