using System;
using System.Runtime.Serialization;
using Utils.Collections.Graphs;

namespace Utils.Collections.Exceptions
{
    [Serializable]
    public class DuplicateLinkException : GraphException
    {
        private static string ATTENTION_MESSAGE = $"Если ошибка возникает на разных сущностях, то необохдимо проверить метод GetHashCode у текущего наследника {typeof(GraphNode).FullName}";

        public DuplicateLinkException() : base(ATTENTION_MESSAGE)
        {
        }

        public DuplicateLinkException(GraphNode addingNode) : base(addingNode, ATTENTION_MESSAGE)
        {
        }

        public DuplicateLinkException(string message) : base($"{message}. {ATTENTION_MESSAGE}")
        {
        }

        public DuplicateLinkException(string message, Exception innerException) : base($"{message}. {ATTENTION_MESSAGE}", innerException)
        {
        }

        protected DuplicateLinkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
