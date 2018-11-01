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
    }

}
