namespace GiGraph.Dot.Entities.Edges.Attributes;

public interface IDotEdgeLayoutAttributes
{
    /// <summary>
    ///     If true, allows edge labels to be less constrained in position. In particular, it may appear on top of other edges. Default:
    ///     false.
    /// </summary>
    bool? EnableLabelFloating { get; set; }

    /// <summary>
    ///     Minimum edge length (rank difference between head and tail). Dot only, default: 1, minimum: 0.
    /// </summary>
    int? MinLength { get; set; }

    /// <summary>
    ///     Preferred edge length, in inches (fdp, neato only). Default: 1.0 (neato), 0.3 (fdp).
    /// </summary>
    double? Length { get; set; }

    /// <summary>
    ///     Weight of the edge. In dot, the heavier the weight, the shorter, straighter and more vertical the edge is. Note that weights
    ///     in dot must be integers. For twopi, a weight of 0 indicates the edge should not be used in constructing a spanning tree from
    ///     the root. For other layouts, a larger weight encourages the layout to make the edge length closer to that specified by the
    ///     <see cref="Length"/> attribute. Default: 1. Minimum: 0 [int] (dot, twopi), 1 [double] (neato, fdp).
    /// </summary>
    double? Weight { get; set; }

    /// <summary>
    ///     Determines whether this edge should be included in node ranking during layout computation (i.e., whether it affects the
    ///     relative positioning of nodes along the rank axis). Applicable only to the dot layout engine (default: true). When set to
    ///     false, the edge is drawn, but does not influence the layout of connected nodes. See
    ///     <see href="https://graphviz.org/docs/attrs/constraint">
    ///         Graphviz documentation
    ///     </see>
    ///     for details.
    /// </summary>
    bool? IncludeInNodeRanking { get; set; }
}