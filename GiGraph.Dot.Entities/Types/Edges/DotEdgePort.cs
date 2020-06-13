using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;

namespace GiGraph.Dot.Entities.Types.Edges
{
    /// <summary>
    /// Represents the edge port, that is a point on a node where the edge is attached to.
    /// </summary>
    public class DotEdgePort
    {
        /// <summary>
        /// Gets a value that modifies the edge placement to aim for the specified port. If specified, the corresponding node
        /// must either have a record shape (<see cref="DotShape.Record"/> or <see cref="DotShape.MRecord"/>)
        /// with one of its fields having the given port name, or have an HTML-like label, one of whose components
        /// has a PORT attribute set to the specified port name.
        /// </summary>
        public virtual string PortName { get; }

        /// <summary>
        /// <para>
        ///     Gets a value that modifies the edge placement to aim for the specified compass point on the <see cref="PortName"/>
        ///     if specified, or on the node itself otherwise.
        /// </para>
        /// <para>
        ///     If no compass point is specified explicitly, the default value is <see cref="DotCompassPoint.Center"/>.
        /// </para>
        /// </summary>
        public virtual DotCompassPoint? CompassPoint { get; }

        /// <summary>
        /// Creates a new instance of the port.
        /// </summary>
        /// <param name="portName">
        /// Determines the edge placement to aim for the specified port. If specified, the corresponding node
        /// must either have record shape (<see cref="DotShape.Record"/>, <see cref="DotShape.MRecord"/>)
        /// with one of its fields having the given port name, or have an HTML-like label, one of whose components
        /// has a PORT attribute set to the specified port name.
        /// </param>
        /// <param name="compassPoint">
        /// Determines the edge placement to aim for the specified compass point on the <paramref name="portName"/> if specified,
        /// or on the node itself otherwise. If no compass point is specified explicitly, the default value is <see cref="DotCompassPoint.Center"/>.
        /// </param>
        public DotEdgePort(string portName, DotCompassPoint? compassPoint = null)
        {
            if (portName is null && compassPoint is null)
            {
                throw new ArgumentNullException(
                    $"{nameof(portName)} / {nameof(compassPoint)}",
                    "At least a port name or a compass point has to be specified for an edge port.");
            }

            PortName = portName;
            CompassPoint = compassPoint;
        }

        /// <summary>
        /// Creates a new instance of the port initialized with a compass point.
        /// </summary>
        /// <param name="compassPoint">Determines the edge placement to aim for the specified compass point on a node.</param>
        public DotEdgePort(DotCompassPoint compassPoint)
            : this(portName: null, compassPoint)
        {
        }

        public static implicit operator DotEdgePort(string portName)
        {
            return portName is {} ? new DotEdgePort(portName) : null;
        }

        public static implicit operator DotEdgePort(DotCompassPoint? compassPoint)
        {
            return compassPoint.HasValue ? new DotEdgePort(compassPoint.Value) : null;
        }
    }
}