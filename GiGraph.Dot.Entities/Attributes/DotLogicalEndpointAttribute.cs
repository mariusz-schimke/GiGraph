using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Represents a logical head or tail of an edge.
    /// When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
    /// if the current attribute is defined and is the identifier of a cluster containing the real head/tail,
    /// the edge is clipped to the boundary of the cluster.
    /// </summary>
    public class DotLogicalEndpointAttribute : DotCommonAttribute<string>
    {
        /// <summary>
        /// Creates a new attribute instance.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="clusterId">The identifier of the cluster to use as a logical head or tail of the edge.</param>
        public DotLogicalEndpointAttribute(string key, string clusterId)
            : base(key, clusterId)
        {
        }

        protected override string GetDotEncodedValue()
        {
            // keep this value coherent with the format the cluster generator uses to generate cluster identifier,
            // and use the same identifier escaping pipeline
            return $"cluster {Value}";
        }
    }
}
