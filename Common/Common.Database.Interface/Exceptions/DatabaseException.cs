using System;
using System.Runtime.Serialization;

namespace Common.Database.Interface.Exceptions
{
    public class DatabaseException : Exception
    {
        public DatabaseException(string message) : this(message, null)
        {
        }

        public DatabaseException(string message, Exception innerException) : base($"Ошибка базы данных.{message}", innerException)
        {
        }

        protected DatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
