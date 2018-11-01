using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    /// <summary>
    /// Базовый класс для исключений платформы
    /// </summary>
    public class PlatformException : Exception
    {
        #region init
        public PlatformException()
        {
        }

        public PlatformException(string message) : base(message)
        {
        }

        public PlatformException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PlatformException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
