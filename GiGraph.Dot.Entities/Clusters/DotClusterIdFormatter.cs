using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Clusters
{
    public static class DotClusterIdFormatter
    {
        public static string Format(string id, DotGenerationOptions options)
        {
            const string cluster = "cluster";

            return id is { }
                ? $"{cluster}{options.Clusters.ClusterIdSeparator}{id}"
                : cluster;
        }
    }
}