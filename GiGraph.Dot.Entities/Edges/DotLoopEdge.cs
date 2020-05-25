using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a loop edge that connects a node to itself (also called a self-loop or a buckle).
    /// <para>
    ///     If you would like to control the port (<see cref="DotNodeEndpoint.PortName"/>) and/or
    ///     the compass point (<see cref="DotNodeEndpoint.CompassPoint"/>) of the head and the tail of the edge
    ///     that connects the node to itself, please use a <see cref="DotOneToOneEdge"/> edge with the same node identifier
    ///     used for the head and the tail, but with different ports and/or compass points specified for each.
    /// </para>
    /// </summary>
    public class DotLoopEdge : DotCommonEdge
    {
        /// <summary>
        /// Gets or sets the node to connect to itself.
        /// </summary>
        public virtual DotNodeEndpoint Node { get; set; }

        /// <summary>
        /// Gets the nodes this edge connects. For coherence, returns two items, both being the same instance of <see cref="Node"/>.
        /// </summary>
        public override IEnumerable<DotEndpoint> Endpoints => new DotEndpoint[] { Node, Node };

        protected DotLoopEdge(DotNodeEndpoint node, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Node = node;
        }

        /// <summary>
        /// Creates a new loop edge instance.
        /// </summary>
        /// <param name="node">The node the edge should connect to itself.</param>
        public DotLoopEdge(DotNodeEndpoint node)
            : this(node, new DotEntityAttributes())
        {
        }

        /// <summary>
        /// Creates a new loop edge instance.
        /// </summary>
        /// <param name="nodeId">The identifier of the node the edge should connect to itself.</param>
        public DotLoopEdge(string nodeId)
            : this(new DotNodeEndpoint(nodeId))
        {
        }
    }
}
