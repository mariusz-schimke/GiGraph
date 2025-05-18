using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public interface IDotEdgeStyleAttributes : IDotEntityStyleAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the color to use for the edge (default: <see cref="System.Drawing.Color.Black"/>).
    ///     </para>
    ///     <para>
    ///         If <see cref="DotMulticolor"/> is used, with no weighted colors in its color collection (<see cref="DotColor"/> items
    ///         only), the edge is drawn using parallel splines or lines, one for each color in the list, in the order given. The head
    ///         arrow, if any, is drawn using the first color in the list, and the tail arrow, if any, the second color. This supports
    ///         the common case of drawing opposing edges, but using parallel splines instead of separately routed multiedges.
    ///     </para>
    ///     <para>
    ///         If <see cref="DotMulticolor"/> is used with at least one weighted color (<see cref="DotWeightedColor"/>), the colors are
    ///         drawn in series, with each color being given roughly its specified fraction of the edge, expressed by the
    ///         <see cref="DotWeightedColor.Weight"/> property.
    ///     </para>
    /// </summary>
    DotColorDefinition? Color { get; set; }

    /// <summary>
    ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
    ///     is set, the standard <see cref="DotColorSchemes.X11"/> naming is used. For example, if
    ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9"/> Brewer color scheme is used, then a color named "7", e.g.
    ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes"/> for
    ///     supported scheme names.
    /// </summary>
    string? ColorScheme { get; set; }

    /// <summary>
    ///     Gets or sets the color used to fill the arrowhead, assuming it has a filled style. If <see cref="FillColor"/> is not defined,
    ///     <see cref="Color"/> is used. If it is not defined too, the default is used, except when the output format is MIF, which use
    ///     black by default.
    /// </summary>
    DotColorDefinition? FillColor { get; set; }

    /// <summary>
    ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges. The value has no
    ///     effect on text. Default: 1.0, minimum: 0.0.
    /// </summary>
    double? LineWidth { get; set; }

    /// <summary>
    ///     Gets or sets the multiplicative scale factor for arrowheads (default: 1.0, minimum: 0.0).
    /// </summary>
    double? ArrowheadScale { get; set; }
}