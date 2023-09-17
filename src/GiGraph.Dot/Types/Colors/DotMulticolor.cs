using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Colors;

/// <summary>
///     Represents a list of colors that may be used to generate gradient fill, multicolor stripes or wedges, or multicolor edges.
/// </summary>
public record DotMulticolor : DotColorDefinition
{
    /// <summary>
    ///     <para>
    ///         Creates a new color list rendered in a specific way depending on how many colors are specified, whether they have
    ///         weights, and what type of element the color list is applied to.
    ///     </para>
    ///     <para>
    ///         The returned color list will be rendered as gradient fill when two colors with no weights (<see cref="DotColor" />) are
    ///         specified (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge. When a
    ///         weight is specified for either of the colors (<see cref="DotWeightedColor" />), the returned color list will be rendered
    ///         as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment spline, when applied to an edge
    ///         (with color proportions determined by the weight in both cases).
    ///     </para>
    ///     <para>
    ///         When more than two colors are specified, they will be rendered as parallel splines if used for edges (when no weights are
    ///         present), or as multicolor segments (when at least one weighted color is present). When used for rectangularly-shaped
    ///         nodes or clusters with the <see cref="DotStyles.Striped" /> style, the returned color list will be rendered as a striped
    ///         multicolor fill, or as a wedged multicolor fill, when used for elliptically-shaped nodes with the
    ///         <see cref="DotStyles.Wedged" /> style.
    ///     </para>
    /// </summary>
    /// <param name="colors">
    ///     The colors to initialize the instance with. The supported types are <see cref="DotColor" /> (with no weight) and
    ///     <see cref="DotWeightedColor" /> (with weight). If only weighted colors are provided, the weights must sum to at most 1. If
    ///     both colors with and without weights are provided, the sum of the weighted ones should be below 1, as otherwise those without
    ///     weights will be ignored by the visualization tool.
    /// </param>
    public DotMulticolor(params DotColor[] colors)
    {
        Colors = colors ?? throw new ArgumentNullException(nameof(colors), "Color collection must not be null.");
    }

    /// <summary>
    ///     <para>
    ///         Creates a new color list rendered in a specific way depending on how many colors are specified, whether they have
    ///         weights, and what type of element the color list is applied to.
    ///     </para>
    ///     <para>
    ///         The returned color list will be rendered as gradient fill when two colors with no weights (<see cref="DotColor" />) are
    ///         specified (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge. When a
    ///         weight is specified for either of the colors (<see cref="DotWeightedColor" />), the returned color list will be rendered
    ///         as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment spline, when applied to an edge
    ///         (with color proportions determined by the weight in both cases).
    ///     </para>
    ///     <para>
    ///         When more than two colors are specified, they will be rendered as parallel splines if used for edges (when no weights are
    ///         present), or as multicolor segments (when at least one weighted color is present). When used for rectangularly-shaped
    ///         nodes or clusters with the <see cref="DotStyles.Striped" /> style, the returned color list will be rendered as a striped
    ///         multicolor fill, or as a wedged multicolor fill, when used for elliptically-shaped nodes with the
    ///         <see cref="DotStyles.Wedged" /> style.
    ///     </para>
    /// </summary>
    /// <param name="colors">
    ///     The colors to initialize the instance with. The supported types are <see cref="DotColor" /> (with no weight) and
    ///     <see cref="DotWeightedColor" /> (with weight). If only weighted colors are provided, the weights must sum to at most 1. If
    ///     both colors with and without weights are provided, the sum of the weighted ones should be below 1, as otherwise those without
    ///     weights will be ignored by the visualization tool.
    /// </param>
    public DotMulticolor(IEnumerable<DotColor> colors)
        : this(colors?.ToArray())
    {
    }

    /// <summary>
    ///     <para>
    ///         Creates a new color list rendered in a specific way depending on how many colors are specified, and what type of element
    ///         the color list is applied to.
    ///     </para>
    ///     <para>
    ///         The returned color list will be rendered as gradient fill when only two colors are specified (refers to the root graph,
    ///         nodes, and clusters), or as two parallel splines when applied to an edge.
    ///     </para>
    ///     <para>
    ///         When more than two colors are specified, they will be rendered as parallel splines, if used for edges; when used for
    ///         rectangularly-shaped nodes or clusters with the <see cref="DotStyles.Striped" /> style, the returned color list will be
    ///         rendered as a striped multicolor fill, or as a wedged multicolor fill, when used for elliptically-shaped nodes with the
    ///         <see cref="DotStyles.Wedged" /> style.
    ///     </para>
    /// </summary>
    /// <param name="colors">
    ///     The colors to initialize the instance with.
    /// </param>
    /// <param name="scheme">
    ///     <para>
    ///         The color scheme to evaluate named colors with if any such are specified. See <see cref="DotColorSchemes" /> for
    ///         supported scheme names.
    ///     </para>
    ///     <para>
    ///         Pass null to use the color scheme set on the current element, or to use the default scheme if none was set. Pass
    ///         <see cref="DotColorSchemes.Default" /> to make named colors be evaluated using the default
    ///         <see cref="DotColorSchemes.X11" /> naming.
    ///     </para>
    /// </param>
    public DotMulticolor(IEnumerable<Color> colors, string scheme = null)
        : this(colors?.Select(c => new DotColor(c, scheme)))
    {
    }

    /// <summary>
    ///     Gets the colors of the color list (<see cref="DotColor" />, <see cref="DotWeightedColor" />).
    /// </summary>
    public DotColor[] Colors { get; }

    protected internal override string GetDotEncodedColor(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var colors = Colors.Select(color => color.GetDotEncodedColor(options, syntaxRules));
        return string.Join(":", colors);
    }

    /// <summary>
    ///     Creates a new color definition visualized as a dual-color fill (refers to the root graph, nodes, and clusters), or as a
    ///     two-segment spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
    /// </summary>
    /// <param name="color1">
    ///     The first color to initialize the instance with.
    /// </param>
    /// <param name="weight1">
    ///     The proportion of the area to cover with the first color (it must be in the range 0 ≤ weight &lt; 1).
    /// </param>
    /// <param name="color2">
    ///     The second color to initialize the instance with.
    /// </param>
    /// <param name="weight2">
    ///     The proportion of the area to cover with the second color (it must be in the range 0 ≤ weight &lt; 1).
    /// </param>
    public static DotMulticolor Dual(DotColor color1, double weight1, DotColor color2, double weight2) =>
        new(new DotWeightedColor(color1, weight1), new DotWeightedColor(color2, weight2));

    /// <summary>
    ///     Creates a new color definition visualized as a dual-color fill (refers to the root graph, nodes, and clusters), or as a
    ///     two-segment spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
    /// </summary>
    /// <param name="color1">
    ///     The first color to initialize the instance with.
    /// </param>
    /// <param name="weight1">
    ///     The proportion of the area to cover with the first color (it must be in the range 0 ≤ weight &lt; 1).
    /// </param>
    /// <param name="color2">
    ///     The second color to initialize the instance with.
    /// </param>
    public static DotMulticolor Dual(DotColor color1, double weight1, DotColor color2) => new(new DotWeightedColor(color1, weight1), color2);

    /// <summary>
    ///     Creates a new color definition visualized as a dual-color fill (refers to the root graph, nodes, and clusters), or as a
    ///     two-segment spline, when applied to an edge. In both cases the proportions of the colors are determined by their weights.
    /// </summary>
    /// <param name="color1">
    ///     The first color to initialize the instance with.
    /// </param>
    /// <param name="color2">
    ///     The second color to initialize the instance with.
    /// </param>
    /// <param name="weight2">
    ///     The proportion of the area to cover with the second color (it must be in the range 0 ≤ weight &lt; 1).
    /// </param>
    public static DotMulticolor Dual(DotColor color1, DotColor color2, double weight2) => new(color1, new DotWeightedColor(color2, weight2));
}