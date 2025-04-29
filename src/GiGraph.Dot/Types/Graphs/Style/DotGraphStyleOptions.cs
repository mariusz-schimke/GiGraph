using GiGraph.Dot.Types.Clusters.Style;

namespace GiGraph.Dot.Types.Graphs.Style;

/// <summary>
///     Graph style options.
/// </summary>
/// <param name="FillStyle">
///     The fill style for graph and clusters. The only option applicable to the root graph is
///     <see cref="DotClusterFillStyle.Radial"/> .
/// </param>
public record DotGraphStyleOptions(DotClusterFillStyle? FillStyle = null);