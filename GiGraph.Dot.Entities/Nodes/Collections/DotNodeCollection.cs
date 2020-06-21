using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Nodes.Collections
{
    public class DotNodeCollection : DotEntityWithIdCollection<DotNodeDefinition>, IDotEntity
    {
        public virtual string Notes { get; set; }

        protected DotNodeCollection(Func<string, Predicate<DotNodeDefinition>> matchIdPredicate)
            : base(matchIdPredicate)
        {
        }

        public DotNodeCollection() :
            base(matchIdPredicate: id => nodeDefinition => nodeDefinition is DotNode node && node.Id == id)
        {
        }

        /// <summary>
        /// Adds a node to the collection and initializes its attributes.
        /// </summary>
        /// <typeparam name="T">The type of node to add.</typeparam>
        /// <param name="node">The node to add.</param>
        /// <param name="initAttrs">An optional node attributes initializer delegate.</param>
        public virtual T Add<T>(T node, Action<IDotNodeAttributes> initAttrs)
            where T : DotNodeDefinition
        {
            Add(node);
            initAttrs?.Invoke(node.Attributes);
            return node;
        }

        /// <summary>
        /// Adds a node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">The identifier of the node to add.</param>
        /// <param name="initAttrs">An optional initializer delegate to call for the attributes of the created node.</param>
        public virtual DotNode Add(string id, Action<IDotNodeAttributes> initAttrs = null)
        {
            return Add(new DotNode(id), initAttrs);
        }

        /// <summary>
        /// Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNodeGroup Add(params string[] ids)
        {
            return Add(ids, initGroupAttrs: null);
        }

        /// <summary>
        /// Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="initGroupAttrs">An optional initializer delegate to call for the attributes of the created group.</param>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNodeGroup Add(Action<IDotNodeAttributes> initGroupAttrs, params string[] ids)
        {
            return Add(ids, initGroupAttrs);
        }

        /// <summary>
        /// Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initGroupAttrs">An optional initializer delegate to call for the attributes of the created group.</param>
        public virtual DotNodeGroup Add(IEnumerable<string> ids, Action<IDotNodeAttributes> initGroupAttrs = null)
        {
            return Add(new DotNodeGroup(ids), initGroupAttrs);
        }

        /// <summary>
        /// Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        public virtual DotNode[] AddRange(params string[] ids)
        {
            return AddRange(ids, initNode: null);
        }

        /// <summary>
        /// Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initNode">An optional initializer delegate to call for each created node.</param>
        public virtual DotNode[] AddRange(Action<DotNode> initNode, params string[] ids)
        {
            return AddRange(ids, initNode);
        }

        /// <summary>
        /// Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">The identifiers of the nodes to add.</param>
        /// <param name="initNode">An optional initializer delegate to call for each created node.</param>
        public virtual DotNode[] AddRange(IEnumerable<string> ids, Action<DotNode> initNode = null)
        {
            return ids.Select
                       (
                           id =>
                           {
                               var node = Add(id);
                               initNode?.Invoke(node);
                               return node;
                           }
                       )
                      .ToArray();
        }

        /// <summary>
        /// Gets a node with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the node to get.</param>
        public virtual DotNode Get(string id)
        {
            return GetAll(id).FirstOrDefault();
        }

        /// <summary>
        /// Gets all nodes with the specified identifier from the collection.
        /// </summary>
        /// <param name="id">The identifier of the nodes to get.</param>
        public virtual IEnumerable<DotNode> GetAll(string id)
        {
            return this.OfType<DotNode>()
                       .Where(node => node.Id == id);
        }
    }
}