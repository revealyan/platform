using Core.Entities;
using System.Collections.Generic;

namespace Core.Platforms.Configurations
{
    /// <summary>
    /// Базовая конфигурация для платформы
    /// </summary>
    public abstract class PlatformConfiguration : IConfiguration
    {
        #region core
        public string Name { get; set; }
        public IList<ModuleInfo> ModuleInfos { get; }
        #endregion

        #region init
        public PlatformConfiguration()
        {
            ModuleInfos = new List<ModuleInfo>();
        }
        #endregion

        #region IConfiguration
        public abstract void Load();
        #endregion
    }
}
