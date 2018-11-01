using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Platforms.Configurations
{
    /// <summary>
    /// Конфигурация платформы загружается из файловой системы
    /// </summary>
    public class FilePlatformConfiguration : PlatformConfiguration
    {
        #region core


        private readonly string _configPath;
        #endregion

        #region init
        public FilePlatformConfiguration(string configPath) : base()
        {
            _configPath = configPath;
        }
        #endregion

        #region PlatformConfiguration
        public override void Load()
        {
            if (!File.Exists(_configPath))
                throw new InvalidConfigurationException($"Не найден файл конфигурации {_configPath}", this);
            var content = File.ReadAllText(_configPath, Encoding.UTF8);
            //TODO : закончить считывание конфигурации
        }
        #endregion
    }
}
