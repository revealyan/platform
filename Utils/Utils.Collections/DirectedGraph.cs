using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils.Collections.Exceptions;

namespace Utils.Collections
{
    public class DirectedGraph
    {
        #region core
        /// <summary>
        /// таблица связности
        /// </summary>
        private readonly Hashtable _adjacency;
        /// <summary>
        /// Таблица обратной связности
        /// </summary>
        private readonly Hashtable _revertAdjacency;
        /// <summary>
        /// Сет рутов
        /// </summary>
        private readonly HashSet<GraphNode> _rootLink;
        #endregion

        #region public info
        public int CountNodes { get => _adjacency.Count; }
        public IReadOnlyList<GraphNode> GraphNodes { get => _adjacency.Keys.Cast<GraphNode>().ToList().AsReadOnly(); }
        #endregion

        #region init
        public DirectedGraph()
        {
            _adjacency = new Hashtable();
            _revertAdjacency = new Hashtable();
            _rootLink = new HashSet<GraphNode>();
        }
        public DirectedGraph(GraphNode[] nodes)
        {
            _adjacency = new Hashtable();
            _revertAdjacency = new Hashtable();
            _rootLink = new HashSet<GraphNode>(nodes);
            for (int i = 0; i < nodes.Length; i++)
            {
                _adjacency.Add(nodes[i], new HashSet<GraphNode>());
                _revertAdjacency.Add(nodes[i], new HashSet<GraphNode>());
            }
        }
        #endregion

        #region collection method
        public virtual void AddRoot(GraphNode root) => AddTo(null, root);
        public virtual void AddTo(GraphNode parentNode, GraphNode childNode)
        {
            if (parentNode == null)
            {
                if (_adjacency.ContainsKey(childNode))
                    throw new DuplicateLinkException(childNode);
                _rootLink.Add(childNode);
                _adjacency.Add(childNode, new HashSet<GraphNode>());
                _revertAdjacency.Add(childNode, new HashSet<GraphNode>());
                return;
            }
            else
            {
                if (_adjacency.ContainsKey(parentNode))
                {
                    var ch = (HashSet<GraphNode>)_adjacency[parentNode];
                    if (ch.Contains(childNode))
                        throw new DuplicateLinkException(childNode);
                    else
                    {
                        if (!_adjacency.ContainsKey(childNode))
                            _adjacency.Add(childNode, new HashSet<GraphNode>());
                        if (!_revertAdjacency.ContainsKey(childNode))
                            _revertAdjacency.Add(childNode, new HashSet<GraphNode>());
                        ch.Add(childNode);
                        (_revertAdjacency[childNode] as HashSet<GraphNode>).Add(parentNode);
                        if (_rootLink.Contains(childNode))
                            _rootLink.Remove(childNode);
                    }
                }
                else throw new NodeNotFoundException(parentNode);
            }
        }


        public virtual bool HasCycles()
        {
            int i = 0;
            Dictionary<int, GraphNode> nodes = _adjacency.Keys.Cast<GraphNode>().ToDictionary(x => i++, x => x);
            Dictionary<GraphNode, bool?> visited = nodes.Values.Cast<GraphNode>().ToDictionary(x => x, x => (bool?)null);
            bool result = false;
            void DFS(GraphNode u)
            {
                visited[u] = false;
                foreach (var v in _adjacency[u] as HashSet<GraphNode>)
                {
                    if (visited[v] == null)
                        DFS(v);
                    else if (visited[v] == false)
                    {
                        result = true;
                        break;
                    }
                }
                visited[u] = true;
            }
            foreach (var u in nodes)
            {
                if (!result)
                {
                    if (visited[u.Value] == null)
                        DFS(u.Value);
                }
                else break;
            }
            return result;
        }
        public virtual bool HasWay(GraphNode from, GraphNode to)
        {
            if (!_adjacency.ContainsKey(from))
                throw new NodeNotFoundException(from);
            if (!_adjacency.ContainsKey(to))
                throw new NodeNotFoundException(to);
            int i = 0;
            Dictionary<int, GraphNode> nodes = _adjacency.Keys.Cast<GraphNode>().ToDictionary(x => i++, x => x);
            Dictionary<GraphNode, bool> visited = nodes.Values.Cast<GraphNode>().ToDictionary(x => x, x => false);
            bool DFS(GraphNode u, GraphNode t)
            {
                if (u.Equals(t))
                    return true;
                visited[u] = true;
                foreach (var v in _adjacency[u] as HashSet<GraphNode>)
                {
                    if (!visited[v])
                        if (DFS(v, t))
                            return true;
                }
                return false;
            }
            return DFS(from, to);
        }
        public virtual bool HasParentChildRelationship(GraphNode prospectiveParent, GraphNode prospectiveChild) => _adjacency.ContainsKey(prospectiveParent) &&
                                                                                       _adjacency.ContainsKey(prospectiveChild) &&
                                                                                      (_adjacency[prospectiveParent] as HashSet<GraphNode>).Contains(prospectiveChild);

        public virtual IList<GraphNode> GetRoots() => GetChilds(null);
        public virtual IList<GraphNode> GetChilds(GraphNode parent)
        {
            if (parent == null)
                return _rootLink.ToList();
            if (!_adjacency.ContainsKey(parent))
                throw new NodeNotFoundException(parent);
            return (_adjacency[parent] as HashSet<GraphNode>).ToList();
        }
        public virtual IList<GraphNode> GetParents(GraphNode child)
        {
            var res = new List<GraphNode>();
            if (!_adjacency.ContainsKey(child))
                throw new NodeNotFoundException(child);
            return (_revertAdjacency[child] as HashSet<GraphNode>).ToList();
        }
        #endregion

        /// <summary>
        /// от модулей не имеющих зависимостей к корневым модулям, которых нет в зависимостях
        /// </summary>
        /// <returns></returns>
        public Queue<GraphNode> ToQueue()
        {
            var res = new Queue<GraphNode>();
            if (HasCycles())
                return null;
            void PushNext(GraphNode current)
            {
                foreach (var next in _adjacency[current] as HashSet<GraphNode>)
                {
                    PushNext(next);
                    res.Enqueue(next);
                }
            }
            foreach (var root in _rootLink)
            {
                PushNext(root);
                res.Enqueue(root);
            }
            return res;
        }
    }
}
