using System.Collections.Generic;
using Utils.Collections;

namespace Core.Entities
{
    /// <summary>
    /// Сущность, несущая информацию о модуле
    /// </summary>
    public class ModuleInfo : GraphNode 
    {
        #region core
        /// <summary>
        /// Имя модуля в конфигурации
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Класс, который реализует интерфейс, реализует также IModule
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// Сборка, в которой находится класс
        /// </summary>
        public string Assembly { get; set; }
        /// <summary>
        /// Информация о зависимостях(также модули)
        /// </summary>
        public DependencyInfo[] DependecyInfos { get; set; }
        /// <summary>
        /// Параметры, необходимые для старта модуля
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }
        #endregion
        
        #region init
        public ModuleInfo()
        {
            DependecyInfos = new DependencyInfo[0];
            Parameters = new Dictionary<string, string>();
        }
        #endregion
        
        #region GraphNode
        public override bool Equals(object obj) => obj is ModuleInfo info && info.Name == Name && info.Assembly == Assembly && info.Implementation == Implementation;

        public override int GetHashCode()
        {
            var hashCode = -1761654656;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Class);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Assembly);
            return hashCode;
        }
        #endregion
    }
}
