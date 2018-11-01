using System;
using System.Runtime.Serialization;

namespace Common.Modules.Base.Exceptions
{
    public class RegisteringInvalidInterfaceException : ModuleException
    {
        #region core
        public Type Type { get; set; }
        #endregion

        #region init
        public RegisteringInvalidInterfaceException(string module, Type type) : this(null, module, type)
        {
        }

        public RegisteringInvalidInterfaceException(string message, string module, Type type) : this(message, null, module, type)
        {
        }

        public RegisteringInvalidInterfaceException(string message, Exception innerException, string module, Type type) : base($"Некорректный тип при регистрации.{message}", innerException, module)
        {
            Type = type;
        }

        protected RegisteringInvalidInterfaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion

    }
}
