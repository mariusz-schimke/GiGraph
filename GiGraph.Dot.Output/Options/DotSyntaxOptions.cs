namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     Specifies syntax-related options for generating the output DOT script.
    /// </summary>
    public partial class DotSyntaxOptions
    {
        /// <summary>
        ///     Attribute options.
        /// </summary>
        public virtual AttributeOptions Attributes { get; protected set; } = new AttributeOptions();

        /// <summary>
        ///     Subgraph options.
        /// </summary>
        public virtual SubgraphOptions Subgraphs { get; protected set; } = new SubgraphOptions();

        /// <summary>
        ///     Cluster options.
        /// </summary>
        public virtual ClusterOptions Clusters { get; protected set; } = new ClusterOptions();

        /// <summary>
        ///     Edge options.
        /// </summary>
        public virtual EdgeOptions Edges { get; protected set; } = new EdgeOptions();

        /// <summary>
        ///     Color options.
        /// </summary>
        public virtual ColorOptions Colors { get; protected set; } = new ColorOptions();

        /// <summary>
        ///     Comment options.
        /// </summary>
        public virtual CommentOptions Comments { get; protected set; } = new CommentOptions();

        /// <summary>
        ///     When set, identifiers will always be quoted, even if it is not required.
        /// </summary>
        public virtual bool PreferQuotedIdentifiers { get; set; } = false;

        /// <summary>
        ///     When set, all statements within the graph will be followed by a delimiter (;).
        /// </summary>
        public virtual bool PreferStatementDelimiter { get; set; } = false;

        /// <summary>
        ///     Gets or sets a value indicating if graph elements should be sorted in the output DOT script. This setting affects attributes,
        ///     nodes, edges, subgraphs, and clusters. If false, all elements will be rendered in the order they were added to individual
        ///     graph element collections.
        ///     <para>
        ///         Useful when the output DOT script is going to be compared to its other versions, so that there are as few differences
        ///         between the scripts as possible. However, this option should be used with care because the order of elements in the
        ///         script may affect the order they are visualized, if that matters.
        ///     </para>
        /// </summary>
        public virtual bool SortElements { get; set; } = false;
    }
}