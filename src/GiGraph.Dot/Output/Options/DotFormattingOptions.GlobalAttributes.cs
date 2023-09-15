namespace GiGraph.Dot.Output.Options;

public partial class DotFormattingOptions
{
    public class GlobalAttributesOptions
    {
        /// <summary>
        ///     Gets or sets a value indicating if graph, cluster and subgraph attributes should be written inline (assuming that their
        ///     corresponding <see cref="DotSyntaxOptions.GraphOptions.AttributesAsStatements" />,
        ///     <see cref="DotSyntaxOptions.ClusterOptions.AttributesAsStatements" />, or
        ///     <see cref="DotSyntaxOptions.SubgraphOptions.AttributesAsStatements" /> option of <see cref="DotSyntaxOptions" /> is false).
        /// </summary>
        public bool SingleLineGraphAttributeList { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating if global node attributes in the root graph, clusters, and subgraphs should be written as a
        ///     single line.
        /// </summary>
        public bool SingleLineNodeAttributeList { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating if global edge attributes in the root graph, clusters, and subgraphs should be written as a
        ///     single line.
        /// </summary>
        public bool SingleLineEdgeAttributeList { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating if global graph, node, and edge attributes in the root graph, clusters, and subgraphs should
        ///     be written as single lines.
        /// </summary>
        public bool SingleLineAttributeLists
        {
            get => SingleLineGraphAttributeList && SingleLineNodeAttributeList && SingleLineEdgeAttributeList;
            set => SingleLineGraphAttributeList = SingleLineNodeAttributeList = SingleLineEdgeAttributeList = value;
        }
    }
}