using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Nodes.Style;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public interface IDotNodeStyleAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the color to use for the node (default: <see cref="System.Drawing.Color.Black"/>).
    ///     </para>
    ///     <para>
    ///         If <see cref="DotGradientColor"/> is used, with no weighted colors in its parameters (<see cref="DotColor"/> items only),
    ///         and a <see cref="DotNodeFillStyle.Filled"/> fill style is specified for the node, a linear gradient fill is done.
    ///     </para>
    ///     <para>
    ///         If <see cref="DotGradientColor"/> is used with weighted colors (see <see cref="DotWeightedColor"/>), a degenerate linear
    ///         gradient fill is done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight"/>
    ///         specifying how much of region is filled with each color.
    ///     </para>
    ///     <para>
    ///         If a <see cref="DotNodeFillStyle.Radial"/> fill style is specified for the node, then a radial gradient fill is done. See
    ///         also the <see cref="GradientFillAngle"/> attribute for setting a gradient angle.
    ///     </para>
    ///     <para>
    ///         These fills work with any shape. For certain shapes, fill style can be set to do fills using more than 2 colors (set the
    ///         fill style to <see cref="DotNodeFillStyle.Striped"/> or <see cref="DotNodeFillStyle.Wedged"/> style, and use
    ///         <see cref="DotMulticolor"/> as a color list definition).
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
    ///     <para>
    ///         Gets or sets the color used to fill the background of the node, assuming that the fill style of the node is
    ///         <see cref="DotNodeFillStyle.Filled"/> (default: <see cref="System.Drawing.Color.LightGray"/>). If <see cref="FillColor"/>
    ///         is not defined, <see cref="Color"/> is used. If it is not defined too, the default is used, except for
    ///         <see cref="IDotNodeAttributes.Shape"/> of <see cref="DotNodeShape.Point"/>, or when the output format is MIF, which use
    ///         black by default.
    ///     </para>
    ///     <para>
    ///         When <see cref="DotGradientColor"/> is used, a gradient fill is generated. By default, this is a linear fill; applying
    ///         the <see cref="DotNodeFillStyle.Radial"/> fill style to the node will cause a radial fill. If the second color is
    ///         <see cref="System.Drawing.Color.Empty"/>, the default color is used for it. See also the <see cref="GradientFillAngle"/>
    ///         attribute for setting a gradient angle.
    ///     </para>
    /// </summary>
    DotColorDefinition? FillColor { get; set; }

    /// <summary>
    ///     If a gradient fill is being used, this determines the angle of the fill. For linear fills, the colors transform along a line
    ///     specified by the angle and the center of the object. For radial fills, a value of zero causes the colors to transform
    ///     radially from the center; for non-zero values, the colors transform from a point near the object's periphery as specified by
    ///     the value. If unset, the default angle is 0.
    /// </summary>
    int? GradientFillAngle { get; set; }

    /// <summary>
    ///     Specifies the width of the pen, in points, used to draw lines and curves. The value has no effect on text. Default: 1.0,
    ///     minimum: 0.0.
    /// </summary>
    double? BorderWidth { get; set; }

    /// <summary>
    ///     Sets the number of peripheries used in polygonal node shapes (<see cref="IDotNodeAttributes.Shape"/>). The default value is
    ///     shape dependent, the minimum value is 0. Note that user-defined shapes (see
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#epsf">
    ///         documentation
    ///     </see>
    ///     ) are treated as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a
    ///     bounding rectangle. Setting peripheries to 0 will turn this off.
    /// </summary>
    int? Peripheries { get; set; }
}