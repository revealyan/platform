using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class InvalidConfigurationException : ConfigurationException
    {
        #region init
        public InvalidConfigurationException(IConfiguration configuration) : this(null, configuration)
        {
        }

        public InvalidConfigurationException(string message, IConfiguration configuration) : this(message, null, configuration)
        {
        }

        public InvalidConfigurationException(string message, Exception innerException, IConfiguration configuration) : base($"Некорректная конфигурация. {message}", innerException, configuration)
        {
        }

        protected InvalidConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
