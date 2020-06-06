using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Entities.Edges.Enums;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents a node as an edge endpoint.
    /// This node may be connected to another node represented by a second instance of the same
    /// <see cref="DotEndpoint"/> class, or to multiple nodes represented by the <see cref="DotEndpointGroup"/> class.
    /// To make such connection, use <see cref="DotEdge{TTail, THead}"/> (or one of its more specific descendants),
    /// or <see cref="DotEdgeSequence"/>.
    /// </summary>
    public class DotEndpoint : DotCommonEndpoint
    {
        protected string _nodeId;

        /// <summary>
        /// The node identifier.
        /// </summary>
        public virtual string NodeId
        {
            get => _nodeId;
            set => _nodeId = value ?? throw new ArgumentNullException(nameof(NodeId), "Node identifier cannot be null.");
        }

        /// <summary>
        /// Gets a value that modifies the edge placement to aim for the specified port. 
        /// If specified, the corresponding node, referred to by the <see cref="NodeId"/> property, must either have record shape
        /// (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>) with one of its fields having the given portname,
        /// or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// Gets a value that modifies the edge placement to aim for the specified compass point on the <see cref="PortName"/> if specified,
        /// or on the node itself otherwise.
        /// <para>
        ///     If no compass point is specified explicitly with a <see cref="PortName"/>,
        ///     the default value is <see cref="DotCompassPoint.Center"/>.
        /// </para>
        /// </summary>
        public DotCompassPoint? CompassPoint { get; set; }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="portName">
        ///     Determines the edge placement to aim for the specified port. 
        ///     If specified, the corresponding node <paramref name="nodeId"/> must either have record shape (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>)
        ///     with one of its fields having the given portname, or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </param>
        /// <param name="compassPoint">
        ///     Determines the edge placement to aim for the specified compass point on the
        ///     <paramref name="portName"/> if specified, or on the node itself otherwise.
        ///     If no compass point is specified explicitly with a <paramref name="portName"/>,
        ///     the default value is <see cref="DotCompassPoint.Center"/>.
        /// </param>
        public DotEndpoint(string nodeId, string portName, DotCompassPoint? compassPoint = null)
        {
            NodeId = nodeId;
            PortName = portName;
            CompassPoint = compassPoint;
        }


        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="compassPoint">Determines the edge placement to aim for the specified compass point on the node.
        /// If no compass point is specified explicitly with a <see cref="PortName"/>,
        /// the default value is <see cref="DotCompassPoint.Center"/>.</param>
        public DotEndpoint(string nodeId, DotCompassPoint? compassPoint = null)
            : this(nodeId, portName: null, compassPoint)
        {
        }

        protected override string GetOrderingKey()
        {
            return _nodeId;
        }
    }
}
