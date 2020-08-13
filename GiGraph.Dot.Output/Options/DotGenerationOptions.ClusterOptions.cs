namespace GiGraph.Dot.Output.Options
{
    public partial class DotGenerationOptions
    {
        public class ClusterOptions
        {
            /// <summary>
            ///     Cluster is a subgraph with an identifier prefixed with the "cluster" keyword. This property determines what string to use
            ///     between that keyword and the actual identifier specified for a cluster instance. The default separator is space, which forms
            ///     an identifier in a format "cluster identifier", where 'identifier' is any string used as a cluster identifier.
            /// </summary>
            public virtual string ClusterIdSeparator { get; set; } = " ";
        }
    }
}