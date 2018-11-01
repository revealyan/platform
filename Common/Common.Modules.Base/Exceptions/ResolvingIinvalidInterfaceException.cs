using System;
using System.Runtime.Serialization;

namespace Common.Modules.Base.Exceptions
{
    public class ResolvingIinvalidInterfaceException : ModuleException
    {
        #region core
        public Type Type { get; set; }
        #endregion

        #region init
        public ResolvingIinvalidInterfaceException(string module, Type type) : this(null, module, type)
        {
        }

        public ResolvingIinvalidInterfaceException(string message, string module, Type type) : this(message, null, module, type)
        {
        }

        public ResolvingIinvalidInterfaceException(string message, Exception innerException, string module, Type type) : base($"Некорректный тип при разрешении реализации модуля.{message}", innerException, module)
        {
            Type = type;
        }

        protected ResolvingIinvalidInterfaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion

    }
}
