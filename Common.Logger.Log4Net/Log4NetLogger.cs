using Common.Modules.Base;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Logger.Log4Net
{
    public class Log4NetLogger : BaseModule, ILogger
    {
        #region core
        private readonly ILog _log;
        private string _configurationPath;
        private object _locker = new object();
        #endregion

        #region init
        public Log4NetLogger(string name, IDictionary<string, string> parameters) : base(name, parameters)
        {
            RegisterInterface<ILogger>(this);
            _log = LogManager.GetLogger(typeof(Log4NetLogger));
        }
        #endregion

        #region BaseModule
        public override void Startup()
        {
            base.Startup();
            _configurationPath = Parameters["config"];
            if (!File.Exists(_configurationPath))
                throw new Exception("Нет файла конфигурации");
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo(_configurationPath));
        }
        #endregion

        #region ILogger

        #region Debug
        public void LogDebug(string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Info
        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Warn
        public void LogWarn(string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Error
        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(Exception exception, string message = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Fatal
        public void LogFatal(string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
