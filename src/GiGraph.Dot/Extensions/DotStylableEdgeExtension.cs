using System.Drawing;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

public static class DotStylableEdgeExtension
{
    /// <summary>
    ///     Tapers the edge's line. It starts with the specified width and tapers to width 1, in points.
    /// </summary>
    /// <param name="edge">
    ///     The current context to set the style for.
    /// </param>
    /// <param name="startWidth">
    ///     The width to start with.
    /// </param>
    public static T SetTaperedLineStyle<T>(this T edge, double startWidth)
        where T : IDotStylableEdge
    {
        edge.SetLineStyle(DotLineStyle.Tapered);
        edge.SetLineWidth(startWidth);
        return edge;
    }

    /// <summary>
    ///     Composes the edge's line from segments with the specified colors. At least one of the colors has to have a weight specified
    ///     (use <see cref="DotWeightedColor"/>).
    /// </summary>
    /// <param name="edge">
    ///     The current context to set the style for.
    /// </param>
    /// <param name="segments">
    ///     The colors to assign to consecutive segments of the edge. At least one of the colors has to have a weight specified (see
    ///     <see cref="DotWeightedColor"/>), that determines the proportion of the area covered with the specified color. If only
    ///     weighted colors are provided, the weights must sum to at most 1. If both colors with and without weights are provided, the
    ///     sum of the weighted ones should be below 1, as otherwise those without weights will be ignored by the visualization tool.
    /// </param>
    public static T SetSegmentedLineStyle<T>(this T edge, params DotColor[] segments)
        where T : IDotStylableEdge =>
        edge.SetSegmentedLineStyle(new DotMulticolor(segments));

    /// <summary>
    ///     Composes the edge's line from segments with the specified colors. At least one of the colors has to have a weight specified
    ///     (use <see cref="DotWeightedColor"/>).
    /// </summary>
    /// <param name="edge">
    ///     The current context to set the style for.
    /// </param>
    /// <param name="segments">
    ///     The colors to assign to consecutive segments of the edge. At least one of the colors has to have a weight specified (see
    ///     <see cref="DotWeightedColor"/>), that determines the proportion of the area covered with the specified color. If only
    ///     weighted colors are provided, the weights must sum to at most 1. If both colors with and without weights are provided, the
    ///     sum of the weighted ones should be below 1, as otherwise those without weights will be ignored by the visualization tool.
    /// </param>
    public static T SetSegmentedLineStyle<T>(this T edge, DotMulticolor segments)
        where T : IDotStylableEdge
    {
        if (!segments.Colors.Any(item => item is DotWeightedColor))
        {
            throw new ArgumentException("At least one color has to have a weight specified.", nameof(segments));
        }

        edge.SetLineColor(segments);
        return edge;
    }

    /// <summary>
    ///     Converts the edge to multiple parallel lines.
    /// </summary>
    /// <param name="edge">
    ///     The current context to set the style for.
    /// </param>
    /// <param name="lineCount">
    ///     The number of parallel lines to compose the edge of.
    /// </param>
    /// <param name="color">
    ///     The color to assign to individual lines the edge will be composed of. If not specified,
    ///     <see cref="System.Drawing.Color.Black"/> is used.
    /// </param>
    public static T SetParallelLineStyle<T>(this T edge, int lineCount, DotColor? color = null)
        where T : IDotStylableEdge
    {
        var colors = Enumerable.Range(0, lineCount).Select(_ => color ??= Color.Black);
        return edge.SetParallelLineStyle(colors.ToArray());
    }

    /// <summary>
    ///     Converts the edge to multiple parallel lines if at least two colors are specified.
    /// </summary>
    /// <param name="edge">
    ///     The current context to set the style for.
    /// </param>
    /// <param name="lines">
    ///     The colors to assign to individual lines the edge will be composed of. Note that weighted colors (
    ///     <see cref="DotWeightedColor"/>) must not be used among the colors.
    /// </param>
    public static T SetParallelLineStyle<T>(this T edge, params DotColor[] lines)
        where T : IDotStylableEdge =>
        edge.SetParallelLineStyle(new DotMulticolor(lines));

    /// <summary>
    ///     Converts the edge to multiple parallel lines.
    /// </summary>
    /// <param name="edge">
    ///     The current context to set the style for.
    /// </param>
    /// <param name="lines">
    ///     The colors to assign to individual lines the edge will be composed of. Note that weighted colors (
    ///     <see cref="DotWeightedColor"/>) must not be used among the colors.
    /// </param>
    public static T SetParallelLineStyle<T>(this T edge, DotMulticolor lines)
        where T : IDotStylableEdge
    {
        if (lines.Colors.Any(color => color is DotWeightedColor))
        {
            throw new ArgumentException("Weighted colors cannot be applied to multiline edges.", nameof(lines));
        }

        edge.SetLineColor(lines);
        return edge;
    }
}