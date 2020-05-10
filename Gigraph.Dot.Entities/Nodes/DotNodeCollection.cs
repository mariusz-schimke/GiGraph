using System;
using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Nodes
{
    public class DotNodeCollection : IDotEntity, IEnumerable<DotNode>
    {
        protected readonly List<DotNode> _nodes = new List<DotNode>();

        /// <summary>
        /// Adds a node to the collection.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public virtual DotNode Add(DotNode node)
        {
            _nodes.Add(node);
            return node;
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
