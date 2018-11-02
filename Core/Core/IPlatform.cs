using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Интерфейс для реализации платформы
    /// </summary>
    public interface IPlatform
    {
        /// <summary>
        /// Запуск платформы
        /// </summary>
        void Startup();
        /// <summary>
        /// Остановка платформы
        /// </summary>
        void Shutdown();
        /// <summary>
        /// Перезапуск
        /// </summary>
        void Restart();
        /// <summary>
        /// Возвращает список всех компонентов
        /// </summary>
        /// <returns>Список всех компонентов запущеных в платформе</returns>
        IList<IModule> GetModules();
    }

}
