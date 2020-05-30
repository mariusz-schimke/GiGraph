using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Nodes.Collections
{
    public class DotCommonNodeCollection : DotEntityWithIdCollection<DotCommonNode>, IDotEntity
    {
        protected virtual T Add<T>(T node, Action<IDotNodeAttributes> initNode)
            where T : DotCommonNode
        {
            Add(node);
            initNode?.Invoke(node.Attributes);
            return node;
        }

        /// <summary>
        /// Adds a node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        /// <param name="initNode">An optional initializer delegate to call for the attributes of the created node.</param>
        public virtual DotNode Add(string id, Action<IDotNodeAttributes> initNode = null)
        {
            return Add(new DotNode(id), initNode);
        }

        /// <summary>
        /// Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNodeGroup Add(params string[] ids)
        {
            return Add(ids, initGroup: null);
        }

        /// <summary>
        /// Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="initGroup">An optional initializer delegate to call for the attributes of the created group.</param>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNodeGroup Add(Action<IDotNodeAttributes> initGroup, params string[] ids)
        {
            return Add(ids, initGroup);
        }

        /// <summary>
        /// Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initGroup">An optional initializer delegate to call for the attributes of the created group.</param>
        public virtual DotNodeGroup Add(IEnumerable<string> ids, Action<IDotNodeAttributes> initGroup = null)
        {
            return Add(new DotNodeGroup(ids), initGroup);
        }

        /// <summary>
        /// Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNode[] AddRange(params string[] ids)
        {
            return AddRange((IEnumerable<string>)ids);
        }

        /// <summary>
        /// Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initNode">An optional initializer delegate to call for the attributes of each created node.</param>
        public virtual DotNode[] AddRange(Action<IDotNodeAttributes> initNode, params string[] ids)
        {
            return AddRange(ids, initNode);
        }

        /// <summary>
        /// Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initNode">An optional initializer delegate to call for the attributes of each created node.</param>
        public virtual DotNode[] AddRange(IEnumerable<string> ids, Action<IDotNodeAttributes> initNode = null)
        {
            return ids.Select(id => Add(id, initNode)).ToArray();
        }

        /// <summary>
        /// Gets a node with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        public virtual DotNode Get(string id)
        {
            return this.OfType<DotNode>()
                       .FirstOrDefault(node => node.Id == id);
        }

        public override int IndexOf(string id)
        {
            return FindIndex(comonNode => comonNode is DotNode node && node.Id == id);
        }
    }
}
