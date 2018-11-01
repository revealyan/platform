namespace Core.Enums
{
    /// <summary>
    /// Состояние плаформы
    /// </summary>
    public enum PlatformState
    {
        /// <summary>
        /// Создается
        /// </summary>
        Creating,
        /// <summary>
        /// Создана
        /// </summary>
        Created,
        /// <summary>
        /// Запускается
        /// </summary>
        StartingUp,
        /// <summary>
        /// Запущена
        /// </summary>
        StartedUp,
        /// <summary>
        /// Останавливается
        /// </summary>
        ShuttingDown,
        /// <summary>
        /// Остановлена
        /// </summary>
        ShuttedDown,
        /// <summary>
        /// Остановлена, произошла ошибка
        /// </summary>
        ErrorOccured,
        /// <summary>
        /// Перезапуск
        /// </summary>
        Restarting,
    }
}
