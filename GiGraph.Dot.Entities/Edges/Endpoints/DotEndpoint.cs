using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents a node as an edge endpoint. The node may be connected to another node represented by a second instance
    /// of the same <see cref="DotEndpoint"/> class, or to multiple nodes represented by the <see cref="DotEndpointGroup"/> class.
    /// To make such connection, use <see cref="DotEdge{TTail, THead}"/> (or one of its more specific descendants), or <see cref="DotEdgeSequence"/>.
    /// </summary>
    public class DotEndpoint : DotEndpointDefinition
    {
        protected DotEndpointPort _port;

        /// <summary>
        /// Gets the node identifier.
        /// </summary>
        public virtual string NodeId { get; }

        /// <summary>
        /// Gets or sets the endpoint port, that is a point on a node where an edge is attached to.
        /// </summary>
        public virtual DotEndpointPort Port
        {
            get => _port;
            set => _port = value ?? throw new ArgumentNullException(nameof(Port), "Port cannot be null.");
        }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="portName">
        /// Determines the edge placement to aim for the specified port. 
        /// If specified, the corresponding node, referred to by the <paramref name="nodeId"/> parameter,
        /// must either have a record shape (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>)
        /// with one of its fields having the given port name, or have an HTML-like label, one of whose components
        /// has a PORT attribute set to the specified port name.
        /// </param>
        /// <param name="compassPoint">
        /// Determines the edge placement to aim for the specified compass point on the <paramref name="portName"/> if specified,
        /// or on the node itself otherwise. If no compass point is specified explicitly, the default value is <see cref="DotCompassPoint.Center"/>.
        /// </param>
        public DotEndpoint(string nodeId, string portName, DotCompassPoint? compassPoint = null)
        {
            NodeId = nodeId ?? throw new ArgumentNullException(nameof(nodeId), "Node identifier cannot be null.");
            Port = new DotEndpointPort(portName)
            {
                CompassPoint = compassPoint
            };
        }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="compassPoint">Determines the edge placement to aim for the specified compass point on the node.
        /// If no compass point is specified explicitly, the default value is <see cref="DotCompassPoint.Center"/>.</param>
        public DotEndpoint(string nodeId, DotCompassPoint? compassPoint = null)
            : this(nodeId, portName: null, compassPoint)
        {
        }

        protected override string GetOrderingKey()
        {
            return NodeId;
        }
    }
}