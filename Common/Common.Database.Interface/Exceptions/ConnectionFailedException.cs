using System;
using System.Runtime.Serialization;

namespace Common.Database.Interface.Exceptions
{
    public class ConnectionFailedException : DatabaseException
    {
        public ConnectionFailedException(string message) : this(message, null)
        {
        }

        public ConnectionFailedException(string message, Exception innerException) : base($"Не удалось подключится к БД.{message}", innerException)
        {
        }

        protected ConnectionFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
