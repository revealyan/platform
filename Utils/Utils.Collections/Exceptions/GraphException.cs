using System;
using System.Runtime.Serialization;

namespace Utils.Collections.Exceptions
{
    [Serializable]
    public class GraphException : Exception
    {
        public GraphNode Node { get; set; }

        public GraphException(GraphNode node) : this(node, "")
        {
        }

        public GraphException(GraphNode node, string message) : base(message)
        {
            Node = node;
        }

        public GraphException(string message) : base(message)
        {
        }

        public GraphException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GraphException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
