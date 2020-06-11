using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    /// Represents a group of graph nodes with a shared list of attributes.
    /// </summary>
    public class DotNodeGroup : DotNodeDefinition
    {
        protected readonly string[] _nodeIds;

        /// <summary>
        /// Gets the identifiers of nodes in the group.
        /// </summary>
        public virtual IEnumerable<string> NodeIds => _nodeIds;

        /// <summary>
        /// The attributes of the node group.
        /// </summary>
        public override IDotNodeAttributes Attributes => base.Attributes;

        protected DotNodeGroup(string[] nodeIds, IDotNodeAttributes attributes)
            : base(attributes)
        {
            _nodeIds = nodeIds.Any()
                ? nodeIds
                : throw new ArgumentException("At least one node identifier has to be specified for a node group.", nameof(nodeIds));
        }

        /// <summary>
        /// Creates a new node group initialized with the specified node identifiers.
        /// At least one identifier has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotNodeGroup(params string[] nodeIds)
            : this(nodeIds, new DotEntityAttributes())
        {
        }

        /// <summary>
        /// Creates a new node group initialized with the specified node identifiers.
        /// At least one identifier has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotNodeGroup(IEnumerable<string> nodeIds)
            : this(nodeIds.ToArray())
        {
        }

        protected override string GetOrderingKey()
        {
            return string.Join(" ", NodeIds.OrderBy(nodeId => nodeId));
        }
    }
}
