using Core.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Common.Modules.Base.Exceptions
{
    public class ModuleException : PlatformException
    {
        #region core
        public string Module { get; }
        #endregion

        #region init
        public ModuleException(string module) : this(null, module)
        {
        }

        public ModuleException(string message, string module) : this(message, null, module)
        {
        }

        public ModuleException(string message, Exception innerException, string module) : base($"Произошла ошибка в модуле платформы({module}).{message}", innerException)
        {
            Module = module;
        }

        protected ModuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
