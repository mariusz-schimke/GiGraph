using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Edges
{
    /// <summary>
    ///     Represents the endpoint port, that is a point on a node an edge is attached to.
    /// </summary>
    public class DotEndpointPort : IDotEncodable
    {
        /// <summary>
        ///     Creates a new instance with no port properties specified.
        /// </summary>
        public DotEndpointPort()
        {
        }

        /// <summary>
        ///     Creates a new instance of the port, initialized with a port name.
        /// </summary>
        /// <param name="name">
        ///     Determines the edge placement to aim for the specified port. The corresponding node must either have record shape (
        ///     <see cref="DotNodeShape.Record" />, <see cref="DotNodeShape.RoundedRecord" />) with one of its fields having the given port
        ///     name, or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </param>
        public DotEndpointPort(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Creates a new instance of the port, initialized with a compass point.
        /// </summary>
        /// <param name="compassPoint">
        ///     Determines the edge placement to aim for the specified compass point on a node.
        /// </param>
        public DotEndpointPort(DotCompassPoint? compassPoint)
        {
            CompassPoint = compassPoint;
        }

        /// <summary>
        ///     Creates a new instance of the port, initialized with a port name and a compass point.
        /// </summary>
        /// <param name="name">
        ///     Determines the edge placement to aim for the specified port. The corresponding node must either have record shape (
        ///     <see cref="DotNodeShape.Record" />, <see cref="DotNodeShape.RoundedRecord" />) with one of its fields having the given port
        ///     name, or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
        /// </param>
        /// <param name="compassPoint">
        ///     Determines the edge placement to aim for the specified compass point on the <paramref name="name" /> port.
        /// </param>
        public DotEndpointPort(string name, DotCompassPoint? compassPoint)
            : this(name)
        {
            CompassPoint = compassPoint;
        }

        /// <summary>
        ///     Gets or sets a value that modifies the edge placement to aim for the specified port. If specified, the corresponding node
        ///     must either have a record shape (<see cref="DotNodeShape.Record" /> or <see cref="DotNodeShape.RoundedRecord" />) with one of
        ///     its fields having the given port name, or have an HTML-like label, one of whose components has a PORT attribute set to the
        ///     specified port name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets a value that modifies the edge placement to aim for the specified compass point on the <see cref="Name" />
        ///         port if specified, or on the node itself otherwise.
        ///     </para>
        ///     <para>
        ///         If no compass point is specified explicitly, the default value is <see cref="DotCompassPoint.Center" />.
        ///     </para>
        /// </summary>
        public virtual DotCompassPoint? CompassPoint { get; set; }

        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        /// <summary>
        ///     Creates a new endpoint port with no properties specified.
        /// </summary>
        public static DotEndpointPort Default()
        {
            return new DotEndpointPort();
        }

        public static implicit operator DotEndpointPort(string portName)
        {
            return portName is { } ? new DotEndpointPort(portName) : null;
        }

        public static implicit operator DotEndpointPort(DotCompassPoint? compassPoint)
        {
            return compassPoint.HasValue ? new DotEndpointPort(compassPoint.Value) : null;
        }

        protected internal virtual string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();
            var separator = string.Empty;

            if (Name is { })
            {
                result.Append(syntaxRules.IdentifierEscaper.Escape(Name));
                separator = ":";
            }

            if (CompassPoint.HasValue)
            {
                result.Append(separator);
                result.Append(DotCompassPointConverter.Convert(CompassPoint.Value));
            }

            return result.ToString();
        }
    }
}