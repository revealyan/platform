using Core.Exceptions;
using System.IO;
using System.Text;
using Utils.Runtime;

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
            var container = FormatConverter.FromJson<FileConfigurationContainer>(content);
            Name = container.Name;
            foreach (var info in container.Modules)
            {
                ModuleInfos.Add(info);
            }
        }
        #endregion
    }
}
