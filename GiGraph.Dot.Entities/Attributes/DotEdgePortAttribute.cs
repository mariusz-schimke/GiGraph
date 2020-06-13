using System;
using System.Text;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Represents the edge port, that is a point on a node where the edge is attached to.
    /// </summary>
    public class DotEdgePortAttribute : DotAttribute<DotEdgePort>
    {
        /// <summary>
        /// Creates a new edge port attribute instance.
        /// </summary>
        /// <param name="key">The key of the attribute (e.g. tailport, headport).</param>
        /// <param name="port">The edge port to use as the value of the attribute.</param>
        public DotEdgePortAttribute(string key, DotEdgePort port)
            : base(key, port)
        {
            if (port is null)
            {
                throw new ArgumentNullException(nameof(port), "Edge port cannot be null.");
            }
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            var result = new StringBuilder();
            var separator = string.Empty;

            if (Value.PortName is { })
            {
                result.Append(Value.PortName);
                separator = ":";
            }

            if (Value.CompassPoint.HasValue)
            {
                result.Append(separator);
                result.Append(DotCompassPointConverter.Convert(Value.CompassPoint.Value));
            }

            return result.ToString();
        }
    }
}