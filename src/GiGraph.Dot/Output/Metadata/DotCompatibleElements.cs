namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     Determines types of graph elements that an attribute may be applied to.
/// </summary>
[Flags]
public enum DotCompatibleElements
{
    /// <summary>
    ///     The attribute is applicable to the root graph.
    /// </summary>
    Graph = 1 << 0,

    /// <summary>
    ///     The attribute is applicable to subgraphs.
    /// </summary>
    Subgraph = 1 << 1,

    /// <summary>
    ///     The attribute is applicable to clusters.
    /// </summary>
    Cluster = 1 << 2,

    /// <summary>
    ///     The attribute is applicable to nodes.
    /// </summary>
    Node = 1 << 3,

    /// <summary>
    ///     The attribute is applicable to edges.
    /// </summary>
    Edge = 1 << 4
}