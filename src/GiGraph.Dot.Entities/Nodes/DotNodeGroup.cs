using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Nodes.Attributes;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    ///     Represents a group of graph nodes with a shared list of attributes.
    /// </summary>
    public class DotNodeGroup : DotNodeDefinition
    {
        protected DotNodeGroup(string[] nodeIds, DotNodeAttributes attributes)
            : base(attributes)
        {
            if (nodeIds is null)
            {
                throw new ArgumentNullException(nameof(nodeIds), "Node identifier collection must not be null.");
            }

            Ids = nodeIds.Any()
                ? nodeIds
                : throw new ArgumentException("At least one node identifier has to be specified for a node group.", nameof(nodeIds));
        }

        /// <summary>
        ///     Creates a new node group initialized with the specified node identifiers. At least one identifier has to be specified.
        /// </summary>
        /// <param name="nodeIds">
        ///     The node identifiers to initialize the instance with.
        /// </param>
        public DotNodeGroup(params string[] nodeIds)
            : this(nodeIds, new DotNodeAttributes())
        {
        }

        /// <summary>
        ///     Creates a new node group initialized with the specified node identifiers. At least one identifier has to be specified.
        /// </summary>
        /// <param name="nodeIds">
        ///     The node identifiers to initialize the instance with.
        /// </param>
        public DotNodeGroup(IEnumerable<string> nodeIds)
            : this(nodeIds?.ToArray())
        {
        }

        /// <summary>
        ///     Gets the identifiers of nodes in the group.
        /// </summary>
        public virtual string[] Ids { get; }

        /// <summary>
        ///     The attributes of the node group.
        /// </summary>
        public override DotNodeAttributes Attributes => base.Attributes;

        protected override string GetOrderingKey()
        {
            return string.Join(" ", Ids.OrderBy(nodeId => nodeId));
        }
    }
}