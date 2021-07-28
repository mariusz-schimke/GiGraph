using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Identifiers;

namespace GiGraph.Dot.Types.Clusters
{
    /// <summary>
    ///     Represents cluster identifier.
    /// </summary>
    public class DotClusterId : DotId
    {
        /// <summary>
        ///     Creates a new cluster identifier.
        /// </summary>
        /// <param name="id">
        ///     The identifier to use.
        /// </param>
        public DotClusterId(string id)
            : base(id)
        {
        }

        protected override string FormatId(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            const string cluster = "cluster";

            return _id is not null
                ? $"{cluster}{options.Clusters.ClusterIdSeparator}{_id}"
                : cluster;
        }

        public static implicit operator DotClusterId(string id)
        {
            return id is not null ? new DotClusterId(id) : null;
        }
    }
}