using System;
using System.Runtime.Serialization;

namespace Core.Exceptions
{
    public class ConfigurationException : PlatformException
    {
        #region core
        public IConfiguration Configuration { get; }
        #endregion

        #region init
        public ConfigurationException(IConfiguration configuration): this(null, configuration)
        {
        }

        public ConfigurationException(string message, IConfiguration configuration) : this(message, null, configuration)
        {
        }

        public ConfigurationException(string message, Exception innerException, IConfiguration configuration) : base(message, innerException)
        {
            Configuration = configuration;
        }

        protected ConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion

    }
}
