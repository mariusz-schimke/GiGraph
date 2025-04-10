namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxOptions
{
    public class ClusterOptions
    {
        /// <summary>
        ///     Determines how subgraphs are marked semantically as clusters. Since clusters are written as subgraphs in DOT syntax, this
        ///     setting controls how they are identified as clusters by Graphviz. If set to <see cref="DotClusterDiscriminator.Attribute"/>,
        ///     the subgraph will include the "cluster" attribute to mark it as a cluster. If set to
        ///     <see cref="DotClusterDiscriminator.IdPrefix"/> (default), the subgraph's ID will be prefixed with "cluster" instead. See
        ///     <see cref="IdPrefixSeparator"/> for details related to the ID prefix option.
        /// </summary>
        public DotClusterDiscriminator Discriminator { get; set; } = DotClusterDiscriminator.IdPrefix;

        /// <summary>
        ///     Cluster is a subgraph with its identifier prefixed with the "cluster" keyword or with its "cluster" attribute set to
        ///     <see langword="true"/>. When using the prefixing option, this property determines what string to use between the "cluster"
        ///     keyword and the actual identifier specified for a cluster instance. The default separator is a single space, which forms an
        ///     identifier in a format "cluster identifier", where 'identifier' is any string used as the identifier of the cluster.
        /// </summary>
        public string IdPrefixSeparator { get; set; } = " ";

        /// <summary>
        ///     When true, cluster attributes will be written as separate statements. When false, the "graph [attr_list]" format will be used
        ///     instead.
        /// </summary>
        public bool AttributesAsStatements { get; set; } = true;
    }
}