namespace GiGraph.Dot.Output.Options;

/// <summary>
///     Specifies syntax-related options for generating the DOT output.
/// </summary>
public partial class DotSyntaxOptions
{
    /// <summary>
    ///     Gets the default syntax options.
    /// </summary>
    public static DotSyntaxOptions Default { get; } = new();

    /// <summary>
    ///     Attribute options.
    /// </summary>
    public AttributeOptions Attributes { get; protected set; } = new();

    /// <summary>
    ///     Root graph options.
    /// </summary>
    public GraphOptions Graph { get; protected set; } = new();

    /// <summary>
    ///     Subgraph options.
    /// </summary>
    public SubgraphOptions Subgraphs { get; protected set; } = new();

    /// <summary>
    ///     Cluster options.
    /// </summary>
    public ClusterOptions Clusters { get; protected set; } = new();

    /// <summary>
    ///     Edge options.
    /// </summary>
    public EdgeOptions Edges { get; protected set; } = new();

    /// <summary>
    ///     Color options.
    /// </summary>
    public ColorOptions Colors { get; protected set; } = new();

    /// <summary>
    ///     Comment options.
    /// </summary>
    public CommentOptions Comments { get; protected set; } = new();

    /// <summary>
    ///     When set, identifiers will always be quoted, even if it is not required.
    /// </summary>
    public bool PreferQuotedIdentifiers { get; set; }

    /// <summary>
    ///     When set, all statements within the graph will be followed by a delimiter (;).
    /// </summary>
    public bool PreferStatementDelimiter { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating if graph elements should be sorted in the DOT output. This setting affects attributes,
    ///     nodes, edges, subgraphs, and clusters. If false, all elements will be rendered in the order they were added to individual
    ///     graph element collections.
    ///     <para>
    ///         Useful when the DOT output is going to be compared to its other versions, so that there are as few differences
    ///         between the scripts as possible. However, this option should be used with care because the order of elements in the
    ///         DOT output may affect the order they are visualized, if that matters.
    ///     </para>
    /// </summary>
    public bool SortElements { get; set; }
}