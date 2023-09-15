namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxOptions
{
    public class ClusterOptions
    {
        /// <summary>
        ///     When set to <see langword="true" />, subgraphs will have the "cluster" attribute set in order to turn them semantically into
        ///     clusters. When set to <see langword="false" /> (default), on the other hand, they will have their identifiers prefixed with
        ///     the "cluster" keyword for this purpose. See also <see cref="ClusterIdSeparator" /> as the context for the latter option.
        /// </summary>
        public bool PreferClusterAttribute { get; set; } = false;

        /// <summary>
        ///     Cluster is a subgraph with its identifier prefixed with the "cluster" keyword or with its "cluster" attribute set to
        ///     <see langword="true" />. When using the prefixing option, this property determines what string to use between the "cluster"
        ///     keyword and the actual identifier specified for a cluster instance. The default separator is space, which forms an identifier
        ///     in a format "cluster identifier", where 'identifier' is any string used as the identifier of the cluster.
        /// </summary>
        public string ClusterIdSeparator { get; set; } = " ";

        /// <summary>
        ///     When true, cluster attributes will be written as separate statements. When false, the "graph [attr_list]" format will be used
        ///     instead.
        /// </summary>
        public bool AttributesAsStatements { get; set; } = true;
    }
}