using Core.Entities;
using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    /// <summary>
    /// Базовый класс исключений для модулей
    /// </summary>
    public class ModuleException : PlatformException
    {
        #region core
        /// <summary>
        /// Информация о модулей, который учавствует в исключении
        /// </summary>
        public ModuleInfo Module { get; set; }
        #endregion

        #region init
        public ModuleException(ModuleInfo moduleInfo): this(null, moduleInfo)
        {
        }

        public ModuleException(string message, ModuleInfo moduleInfo) : this(message, null, moduleInfo)
        {
        }

        public ModuleException(string message, Exception innerException, ModuleInfo moduleInfo) : base(message, innerException)
        {
            Module = moduleInfo;
        }

        protected ModuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
