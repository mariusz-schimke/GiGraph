using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Entities.Edges.Enums;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents a node as an edge endpoint. The node may be connected to another node represented by a second instance
    /// of the same <see cref="DotEndpoint"/> class, or to multiple nodes represented by the <see cref="DotEndpointGroup"/> class.
    /// To make such connection, use <see cref="DotEdge{TTail, THead}"/> (or one of its more specific descendants), or <see cref="DotEdgeSequence"/>.
    /// </summary>
    public class DotEndpoint : DotEndpointDefinition
    {
        /// <summary>
        /// Gets the node identifier.
        /// </summary>
        public virtual string NodeId { get; }

        /// <summary>
        /// Gets a value that modifies the edge placement to aim for the specified port. 
        /// If specified, the corresponding node, referred to by the <see cref="NodeId"/> property, must either have a record shape
        /// (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>) with one of its fields having the given port name,
        /// or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </summary>
        public virtual string PortName { get; set; }

        /// <summary>
        /// <para>
        ///     Gets a value that modifies the edge placement to aim for the specified compass point on the <see cref="PortName"/> if specified,
        ///     or on the node itself otherwise.
        /// </para>
        /// <para>
        ///     If no compass point is specified explicitly, the default value is <see cref="DotCompassPoint.Center"/>.
        /// </para>
        /// </summary>
        public virtual DotCompassPoint? CompassPoint { get; set; }

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
            PortName = portName;
            CompassPoint = compassPoint;
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