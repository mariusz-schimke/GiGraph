﻿using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Nodes
{
    public class DotNodeCollection : IDotEntity, ICollection<DotNode>
    {
        protected readonly List<DotNode> _nodes = new List<DotNode>();

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public virtual int Count => _nodes.Count;

        bool ICollection<DotNode>.IsReadOnly => ((ICollection<DotNode>)_nodes).IsReadOnly;

        /// <summary>
        /// Adds a node to the collection.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public virtual DotNode Add(DotNode node)
        {
            _nodes.Add(node);
            return node;
        }

        void ICollection<DotNode>.Add(DotNode item)
        {
            Add(item);
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        public virtual DotNode Add(string id)
        {
            return Add(new DotNode(id));
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        /// <param name="initNode">An optional node initializer delegate.</param>
        public virtual DotNode Add(string id, Action<IDotNodeAttributes> initNode)
        {
            var node = Add(id);
            initNode?.Invoke(node.Attributes);
            return node;
        }

        /// <summary>
        /// Adds new nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNode[] Add(params string[] ids)
        {
            return Add((IEnumerable<string>)ids);
        }

        /// <summary>
        /// Adds new nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNode[] Add(IEnumerable<string> ids)
        {
            return Add(initNode: null, ids);
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="initNode">An optional node initializer delegate to call for each provided ID.</param>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNode[] Add(Action<IDotNodeAttributes> initNode, params string[] ids)
        {
            return Add(initNode, (IEnumerable<string>)ids);
        }

        /// <summary>
        /// Adds a new node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="initNode">An optional node initializer delegate to call for each provided ID.</param>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNode[] Add(Action<IDotNodeAttributes> initNode, IEnumerable<string> ids)
        {
            var nodes = new List<DotNode>();

            foreach (var id in ids)
            {
                nodes.Add(Add(id, initNode));
            }

            return nodes.ToArray();
        }

        /// <summary>
        /// Adds the specified nodes to the collection.
        /// </summary>
        /// <param name="nodes">The nodes to add.</param>
        public virtual void AddRange(IEnumerable<DotNode> nodes)
        {
            _nodes.AddRange(nodes);
        }

        /// <summary>
        /// Gets a node with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        public virtual DotNode Get(string id)
        {
            return _nodes.FirstOrDefault(node => node.Id == id);
        }

        /// <summary>
        /// Determines whether the specified node is in the collection.
        /// </summary>
        /// <param name="item">The node to locate in the collection.</param>
        public virtual bool Contains(DotNode item)
        {
            return _nodes.Contains(item);
        }

        /// <summary>
        /// Determines whether the specified node is in the collection.
        /// </summary>
        /// <param name="id">The identifier of the node to locate in the collection.</param>
        public virtual bool Contains(string id)
        {
            return _nodes.Any(node => node.Id == id);
        }

        /// <summary>
        /// Removes the specified node from the collection if found.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        public virtual int Remove(DotNode node)
        {
            var result = 0;

            while (_nodes.Remove(node))
            {
                result++;
            }

            return result;
        }

        bool ICollection<DotNode>.Remove(DotNode item)
        {
            return Remove(item) > 0;
        }

        /// <summary>
        /// Removes the specified node from the collection if found.
        /// </summary>
        /// <param name="id">The identifier of the node to remove.</param>
        public virtual int Remove(string id)
        {
            return RemoveAll(node => node.Id == id);
        }

        /// <summary>
        /// Removes all nodes matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching nodes.</param>
        public virtual int RemoveAll(Predicate<DotNode> match)
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

        public virtual void CopyTo(DotNode[] array, int arrayIndex)
        {
            _nodes.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<DotNode> GetEnumerator()
        {
            return ((IEnumerable<DotNode>)_nodes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotNode>)_nodes).GetEnumerator();
        }
    }
}
