using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents an endpoint port, that is a point on a node where an edge is attached to.
    /// </summary>
    public class DotCompassPointAttribute : DotAttribute<DotCompassPoint>
    {
        /// <summary>
        ///     Creates a new endpoint port attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute (e.g. tailport, headport).
        /// </param>
        /// <param name="port">
        ///     The endpoint port to use as the value of the attribute.
        /// </param>
        public DotCompassPointAttribute(string key, DotCompassPoint port)
            : base(key, port)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return new DotEndpointPort(Value).GetDotEncoded(options, syntaxRules);
        }
    }
}