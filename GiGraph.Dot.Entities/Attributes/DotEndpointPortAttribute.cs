using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents an endpoint port, that is a point on a node where an edge is attached to.
    /// </summary>
    public class DotEndpointPortAttribute : DotAttribute<DotEndpointPort>
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
        public DotEndpointPortAttribute(string key, DotEndpointPort port)
            : base(key, port)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncoded(options, syntaxRules);
        }
    }
}