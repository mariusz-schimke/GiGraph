using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents a logical head or tail of an edge. When the <see cref="DotGraphClusterAttributes.AllowEdgeClipping" /> attribute
    ///     for clusters is true, if the current attribute is defined and is the identifier of a cluster containing
    ///     the real head/tail, the edge is clipped to the boundary of the cluster.
    /// </summary>
    public class DotClusterIdAttribute : DotAttribute<string>
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="clusterId">
        ///     The identifier of the cluster to use as a logical head or tail of the edge.
        /// </param>
        public DotClusterIdAttribute(string key, string clusterId)
            : base(key, clusterId)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            // keep this value coherent with the format the cluster generator uses to generate cluster identifier
            return syntaxRules.IdentifierEscaper.Escape(DotClusterIdFormatter.Format(Value, options));
        }
    }
}