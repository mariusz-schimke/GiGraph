using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Generators.Options
{
    public partial class DotGenerationOptions
    {
        public class ClusterOptions
        {
            /// <summary>
            /// Cluster is a subgraph with an identifier prefixed with the "cluster" keyword.
            /// This property determines what string to use between the keyword and the actual
            /// identifier specified for a <see cref="DotCluster"/> instance.
            /// The default separator is space, which forms an identifier in a format "cluster identifier",
            /// where 'identifier' is any string assigned to <see cref="DotCluster.Id"/> of a cluster.
            /// </summary>
            public string ClusterIdSeparator { get; set; } = " ";
        }
    }
}