using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Nodes
{
    /// <summary>
    /// Represents a group of graph nodes with a shared list of attributes.
    /// </summary>
    public class DotNodeGroup : DotCommonNode, IDotEntityWithIds
    {
        /// <summary>
        /// Gets the identifiers of nodes in the group.
        /// </summary>
        public virtual IEnumerable<string> NodeIds { get; }

        IEnumerable<string> IDotEntityWithIds.Ids => NodeIds;

        /// <summary>
        /// The attributes of the node group.
        /// </summary>
        public override IDotNodeAttributes Attributes => base.Attributes;

        protected DotNodeGroup(ICollection<string> nodeIds, IDotNodeAttributes attributes)
            : base(attributes)
        {
            NodeIds = nodeIds.Any()
                ? nodeIds
                : throw new ArgumentException("At least one node identifier has to be specified for a node group.", nameof(nodeIds));
        }

        /// <summary>
        /// Creates a new node group initialized with the specified node identifiers.
        /// At least one identifier has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotNodeGroup(params string[] nodeIds)
            : this((IEnumerable<string>)nodeIds)
        {
        }

        /// <summary>
        /// Creates a new node group initialized with the specified node identifiers.
        /// At least one identifier has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotNodeGroup(IEnumerable<string> nodeIds)
            : this(new List<string>(nodeIds), new DotEntityAttributes())
        {
        }
    }
}
