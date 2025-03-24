using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Output;

/// <summary>
///     Specifies the order in which nodes and edges are drawn in output.
/// </summary>
public enum DotOutputOrder
{
    /// <summary>
    ///     The simplest mode, but when the graph layout does not avoid edge-node overlap, this mode will sometimes have edges drawn over
    ///     nodes and sometimes on top of nodes.
    /// </summary>
    [DotAttributeValue("breadthfirst")]
    BreadthFirst,

    /// <summary>
    ///     When specified, all nodes are drawn first, followed by the edges. This guarantees an edge-node overlap will not be mistaken
    ///     for an edge ending at a node.
    /// </summary>
    [DotAttributeValue("nodesfirst")]
    NodesFirst,

    /// <summary>
    ///     When specified all edges appear beneath nodes, even if the resulting drawing is ambiguous. Usually used for aesthetic
    ///     reasons.
    /// </summary>
    [DotAttributeValue("edgesfirst")]
    EdgesFirst
}