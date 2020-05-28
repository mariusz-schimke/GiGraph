using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Nodes
{
    public class DotCommonNodeCollection : IDotEntity, ICollection<DotCommonNode>
    {
        protected readonly List<DotCommonNode> _nodes = new List<DotCommonNode>();

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public virtual int Count => _nodes.Count;

        bool ICollection<DotCommonNode>.IsReadOnly => ((ICollection<DotCommonNode>)_nodes).IsReadOnly;

        /// <summary>
        /// Adds a node to the collection.
        /// </summary>
        /// <typeparam name="T">The type of the node added.</typeparam>
        /// <param name="node">The node to add.</param>
        public virtual T Add<T>(T node)
            where T : DotCommonNode
        {
            return Add(node, initNode: null);
        }

        protected virtual T Add<T>(T node, Action<IDotNodeAttributes> initNode)
            where T : DotCommonNode
        {
            _nodes.Add(node);
            initNode?.Invoke(node.Attributes);
            return node;
        }

        void ICollection<DotCommonNode>.Add(DotCommonNode item)
        {
            Add(item);
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        /// <param name="initNode">An optional node initializer delegate.</param>
        public virtual DotNode Add(string id, Action<IDotNodeAttributes> initNode = null)
        {
            return Add(new DotNode(id), initNode);
        }

        /// <summary>
        /// Adds new nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNodeGroup Add(params string[] ids)
        {
            return Add(ids, initNode: null);
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="initNode">An optional node initializer delegate to call for each provided ID.</param>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNodeGroup Add(Action<IDotNodeAttributes> initNode, params string[] ids)
        {
            return Add(ids, initNode);
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initNode">An optional node initializer delegate to call for each provided ID.</param>
        public virtual DotNodeGroup Add(IEnumerable<string> ids, Action<IDotNodeAttributes> initNode = null)
        {
            return Add(new DotNodeGroup(ids), initNode);
        }

        /// <summary>
        /// Adds the specified nodes to the collection.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        public virtual void AddRange(IEnumerable<DotCommonNode> nodes)
        {
            _nodes.AddRange(nodes);
        }

        /// <summary>
        /// Gets a node with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        public virtual DotNode Get(string id)
        {
            return _nodes.OfType<DotNode>().FirstOrDefault(node => node.Id == id);
        }

        /// <summary>
        /// Determines whether the specified node is in the collection.
        /// </summary>
        /// <param name="item">The node to locate in the collection.</param>
        public virtual bool Contains(DotCommonNode item)
        {
            return _nodes.Contains(item);
        }

        /// <summary>
        /// Determines whether the specified node is in the collection.
        /// </summary>
        /// <param name="id">The identifier of the node to locate in the collection.</param>
        public virtual bool Contains(string id)
        {
            return _nodes.OfType<DotNode>().Any(node => node.Id == id);
        }

        /// <summary>
        /// Removes the specified node from the collection if found.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        public virtual int Remove(DotCommonNode node)
        {
            var result = 0;

            while (_nodes.Remove(node))
            {
                result++;
            }

            return result;
        }

        bool ICollection<DotCommonNode>.Remove(DotCommonNode item)
        {
            return Remove(item) > 0;
        }

        /// <summary>
        /// Removes the specified node from the collection if found.
        /// </summary>
        /// <param name="id">The identifier of the node to remove.</param>
        public virtual int Remove(string id)
        {
            return RemoveAll(commonNode => commonNode is DotNode node && node.Id == id);
        }

        /// <summary>
        /// Removes all nodes matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching nodes.</param>
        public virtual int RemoveAll(Predicate<DotCommonNode> match)
        {
            return _nodes.RemoveAll(match);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public virtual void Clear()
        {
            _nodes.Clear();
        }

        public virtual void CopyTo(DotCommonNode[] array, int arrayIndex)
        {
            _nodes.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<DotCommonNode> GetEnumerator()
        {
            return ((IEnumerable<DotCommonNode>)_nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotCommonNode>)_nodes).GetEnumerator();
        }
    }
}
