using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Identifiers
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

            return _id is { }
                ? $"{cluster}{options.Clusters.ClusterIdSeparator}{_id}"
                : cluster;
        }

        public static implicit operator DotClusterId(string id)
        {
            return id is { } ? new DotClusterId(id) : null;
        }
    }
}