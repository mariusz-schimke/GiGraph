using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphStyleAttributes : IDotEntityStyleAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the background color of the graph (default: none). Used as the background for entire canvas.
    ///     </para>
    ///     <para>
    ///         When <see cref="DotGradientColor"/> is used, a gradient fill is generated. By default, this is a linear fill; applying
    ///         the <see cref="DotClusterFillStyle.Radial"/> fill style to the graph will cause a radial fill. If the second color is
    ///         <see cref="System.Drawing.Color.Empty"/>, the default color is used for it. See also the <see cref="GradientFillAngle"/>
    ///         attribute for setting a gradient angle.
    ///     </para>
    ///     <para>
    ///         For certain output formats, such as PostScript, no fill is done for the root graph unless background color is explicitly
    ///         set. For bitmap formats, however, the bits need to be initialized to something, so the canvas is filled with white by
    ///         default. This means that if the bitmap output is included in some other document, all of the bits within the bitmap
    ///         bounding box will be set, overwriting whatever color or graphics were already on the page. If this effect is not desired,
    ///         and you only want to set bits explicitly assigned in drawing the graph, set <see cref="BackgroundColor"/> =
    ///         <see cref="System.Drawing.Color.Transparent"/>.
    ///     </para>
    /// </summary>
    DotColorDefinition? BackgroundColor { get; set; }

    /// <summary>
    ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
    ///     is set, the standard <see cref="DotColorSchemes.X11"/> naming is used. For example, if
    ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9"/> Brewer color scheme is used, then a color named "7", e.g.
    ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes"/> for
    ///     supported scheme names.
    /// </summary>
    string? ColorScheme { get; set; }

    /// <summary>
    ///     If a gradient fill is being used, this determines the angle of the fill. For linear fills, the colors transform along a line
    ///     specified by the angle and the center of the object. For radial fills, a value of zero causes the colors to transform
    ///     radially from the center; for non-zero values, the colors transform from a point near the object's periphery as specified by
    ///     the value. If unset, the default angle is 0.
    /// </summary>
    int? GradientFillAngle { get; set; }
}