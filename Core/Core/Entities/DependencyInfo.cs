namespace Core.Entities
{
    /// <summary>
    /// Сущность несущая информацию о зависимости модуля
    /// </summary>
    public class DependencyInfo
    {
        /// <summary>
        /// Имя модуля в конфигурации
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Интерфейс, который реализует класс модуля
        /// </summary>
        public string Interface { get; set; }
        /// <summary>
        /// Сборка, в которой находится модуль
        /// </summary>
        public string Assembly { get; set; }
    }
}
