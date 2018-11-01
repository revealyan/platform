using System;
using System.Runtime.Serialization;

namespace Utils.Collections.Exceptions
{
    [Serializable]
    public class NodeNotFoundException : GraphException
    {

        public NodeNotFoundException(GraphNode node) : base(node)
        {
        }

        public NodeNotFoundException(string message) : base(message)
        {
        }

        public NodeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NodeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
