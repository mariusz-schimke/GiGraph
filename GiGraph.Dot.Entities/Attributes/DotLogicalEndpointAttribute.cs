using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Represents a logical head or tail of an edge.
    /// When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
    /// if the current attribute is defined and is the identifier of a cluster containing the real head/tail,
    /// the edge is clipped to the boundary of the cluster.
    /// </summary>
    public class DotLogicalEndpointAttribute : DotAttribute<string>
    {
        protected readonly IDotTextEscaper _valueEscaper;

        protected DotLogicalEndpointAttribute(string key, string value, IDotTextEscaper valueEscaper)
            : base(key, value)
        {
            // use the same value escaping pipeline as the cluster generator uses for escaping cluster identifier
            _valueEscaper = valueEscaper ?? DotTextEscapingPipeline.ForIdentifier();
        }

        /// <summary>
        /// Creates a new attribute instance.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="clusterId">The identifier of the cluster to use as a logical head or tail of the edge.</param>
        public DotLogicalEndpointAttribute(string key, string clusterId)
            : this(key, clusterId, valueEscaper: null)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options)
        {
            // keep this value coherent with the format the cluster generator uses to generate cluster identifier
            return _valueEscaper.Escape(
                DotClusterIdFormatter.Format(Value, options));
        }
    }
}