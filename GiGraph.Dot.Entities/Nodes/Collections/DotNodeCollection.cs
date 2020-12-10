using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections.Node;

namespace GiGraph.Dot.Entities.Nodes.Collections
{
    public class DotNodeCollection : List<DotNodeDefinition>, IDotEntity, IDotAnnotatable
    {
        protected DotNodeCollection(DotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        public DotNodeCollection()
            : this(new DotNodeAttributes())
        {
        }

        /// <summary>
        ///     Gets the attributes to apply by default to all nodes of the graph.
        /// </summary>
        public virtual DotNodeAttributes Attributes { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        /// <summary>
        ///     Adds a node to the collection and initializes its attributes.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of node to add.
        /// </typeparam>
        /// <param name="node">
        ///     The node to add.
        /// </param>
        /// <param name="initAttrs">
        ///     An optional node attributes initializer delegate.
        /// </param>
        public virtual T Add<T>(T node, Action<DotNodeAttributes> initAttrs)
            where T : DotNodeDefinition
        {
            Add(node);
            initAttrs?.Invoke(node.Attributes);
            return node;
        }

        /// <summary>
        ///     Adds a node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">
        ///     The identifier of the node to add.
        /// </param>
        /// <param name="initAttrs">
        ///     An optional initializer delegate to call for the attributes of the created node.
        /// </param>
        public virtual DotNode Add(string id, Action<DotNodeAttributes> initAttrs = null)
        {
            return Add(new DotNode(id), initAttrs);
        }

        /// <summary>
        ///     Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        public virtual DotNodeGroup Add(params string[] ids)
        {
            return Add(ids, initGroupAttrs: null);
        }

        /// <summary>
        ///     Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="initGroupAttrs">
        ///     An optional initializer delegate to call for the attributes of the created group.
        /// </param>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        public virtual DotNodeGroup Add(Action<DotNodeAttributes> initGroupAttrs, params string[] ids)
        {
            return Add(ids, initGroupAttrs);
        }

        /// <summary>
        ///     Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        /// <param name="initGroupAttrs">
        ///     An optional initializer delegate to call for the attributes of the created group.
        /// </param>
        public virtual DotNodeGroup Add(IEnumerable<string> ids, Action<DotNodeAttributes> initGroupAttrs = null)
        {
            return Add(new DotNodeGroup(ids), initGroupAttrs);
        }

        /// <summary>
        ///     Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        public virtual DotNode[] AddRange(params string[] ids)
        {
            return AddRange(ids, initNode: null);
        }

        /// <summary>
        ///     Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        /// <param name="initNode">
        ///     An optional initializer delegate to call for each created node.
        /// </param>
        public virtual DotNode[] AddRange(Action<DotNode> initNode, params string[] ids)
        {
            return AddRange(ids, initNode);
        }

        /// <summary>
        ///     Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        /// <param name="initNode">
        ///     An optional initializer delegate to call for each created node.
        /// </param>
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
    }
}