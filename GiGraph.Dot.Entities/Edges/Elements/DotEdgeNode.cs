using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes.Enums;
using System;

namespace GiGraph.Dot.Entities.Edges.Elements
{
    /// <summary>
    /// Represents a node as a head or a tail of an edge.
    /// </summary>
    public class DotEdgeNode : DotEdgeElement
    {
        protected readonly string _id;

        /// <summary>
        /// The node identifier.
        /// </summary>
        public virtual string Id => _id;

        /// <summary>
        /// Gets a value that modifies the edge placement to aim for the specified port. 
        /// If specified, the corresponding node, referred to by the <see cref="Id"/> property, must either have record shape
        /// (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>) with one of its fields having the given portname,
        /// or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </summary>
        public string PortName { get; }

        /// <summary>
        /// Gets a value that modifies the edge placement to aim for the specified compass point on the <see cref="PortName"/> if specified,
        /// or on the node itself otherwise.
        /// <para>
        ///     If no compass point is specified explicitly with a <see cref="PortName"/>,
        ///     the default value is <see cref="DotCompassPoint.Center"/>.
        /// </para>
        /// </summary>
        public DotCompassPoint? CompassPoint { get; }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="id">The node identifier.</param>
        /// <param name="portName">
        ///     Determines the edge placement to aim for the specified port. 
        ///     If specified, the corresponding node <paramref name="id"/> must either have record shape (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>)
        ///     with one of its fields having the given portname, or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </param>
        /// <param name="compassPoint">
        ///     Determines the edge placement to aim for the specified compass point on the
        ///     <paramref name="portName"/> if specified, or on the node itself otherwise.
        ///     If no compass point is specified explicitly with a <paramref name="portName"/>,
        ///     the default value is <see cref="DotCompassPoint.Center"/>.
        /// </param>
        public DotEdgeNode(string id, string portName = null, DotCompassPoint? compassPoint = null)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id), "Node identifier cannot be null.");

            PortName = portName;
            CompassPoint = compassPoint;
        }
    }
}
