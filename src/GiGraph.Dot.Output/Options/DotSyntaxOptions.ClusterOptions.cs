namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class ClusterOptions
        {
            /// <summary>
            ///     Cluster is a subgraph with an identifier prefixed with the "cluster" keyword. This property determines what string to use
            ///     between that keyword and the actual identifier specified for a cluster instance. The default separator is space, which forms
            ///     an identifier in a format "cluster identifier", where 'identifier' is any string used as a cluster identifier.
            /// </summary>
            public string ClusterIdSeparator { get; set; } = " ";

            /// <summary>
            ///     When true, cluster attributes will be written as separate statements. When false, the "graph [attr_list]" format will be used
            ///     instead.
            /// </summary>
            public bool AttributesAsStatements { get; set; } = true;
        }
    }
}