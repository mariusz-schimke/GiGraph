using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Extensions;

public static class DotGraphStyleAttributesExtension
{
    /// <summary>
    ///     Sets a background color.
    /// </summary>
    /// <param name="attributes">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="color">
    ///     The color to use.
    /// </param>
    public static DotGraphStyleAttributes SetBackground(this DotGraphStyleAttributes attributes, DotColor color)
    {
        attributes.BackgroundColor = color;
        return attributes;
    }

    /// <summary>
    ///     Sets a gradient background color. Note that the fill style set by this method (as opposed to the color) applies not only to
    ///     the root graph, but also to clusters (globally) since this is a root graph's attribute. So if radial fill style was
    ///     previously specified on the clusters collection, it will be removed by this method.
    /// </summary>
    /// <param name="attributes">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill. Note that this attribute also applies to clusters.
    /// </param>
    public static DotGraphStyleAttributes SetGradientBackground(this DotGraphStyleAttributes attributes, DotGradientColor color, int? angle = null) =>
        attributes.SetGradientBackground(color, angle, radial: false);

    /// <summary>
    ///     <para>
    ///         Sets a gradient background color. Note that the fill style set by this method (as opposed to the color) applies not only
    ///         to the root graph, but also to clusters (globally) since this is a root graph's attribute. So if radial fill style was
    ///         previously specified on the clusters collection, it will be removed by this method.
    ///     </para>
    ///     <para>
    ///         Also, if at least one weighted color is specified (see <see cref="DotWeightedColor"/>), a degenerate linear gradient fill
    ///         will be done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight"/> specifying
    ///         how much of region is filled with each color.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="startColor">
    ///     The start color of the gradient fill.
    /// </param>
    /// <param name="endColor">
    ///     The end color of the gradient fill.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill. Note that this attribute also applies to clusters.
    /// </param>
    public static DotGraphStyleAttributes SetGradientBackground(this DotGraphStyleAttributes attributes, DotColor startColor, DotColor endColor, int? angle = null) =>
        attributes.SetGradientBackground(new DotGradientColor(startColor, endColor), angle);

    /// <summary>
    ///     Sets a radial gradient background color. Note that the radial fill style set by this method (as opposed to the color) applies
    ///     not only to the root graph, but also to clusters (globally) since this is a root graph's attribute.
    /// </summary>
    /// <param name="attributes">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill. Note that this attribute also applies to clusters.
    /// </param>
    public static DotGraphStyleAttributes SetRadialGradientBackground(this DotGraphStyleAttributes attributes, DotGradientColor color, int? angle = null) =>
        attributes.SetGradientBackground(color, angle, radial: true);

    /// <summary>
    ///     Sets a radial gradient background color. Note that the radial fill style set by this method (as opposed to the color) applies
    ///     not only to the root graph, but also to clusters (globally) since this is a root graph's attribute.
    /// </summary>
    /// <param name="attributes">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="startColor">
    ///     The start color of the gradient fill.
    /// </param>
    /// <param name="endColor">
    ///     The end color of the gradient fill.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill. Note that this attribute also applies to clusters.
    /// </param>
    public static DotGraphStyleAttributes SetRadialGradientBackground(this DotGraphStyleAttributes attributes, DotColor startColor, DotColor endColor, int? angle = null) =>
        attributes.SetRadialGradientBackground(new DotGradientColor(startColor, endColor), angle);

    private static DotGraphStyleAttributes SetGradientBackground(this DotGraphStyleAttributes attributes, DotGradientColor color, int? angle, bool? radial)
    {
        switch (radial)
        {
            // the style may also be set from the Clusters collection on graph, and radial is the only attribute
            // that applies to graph background and to cluster fill
            case true:
                attributes.FillStyle = DotClusterFillStyle.Radial;
                break;

            case false when attributes.FillStyle == DotClusterFillStyle.Radial:
                attributes.FillStyle = DotClusterFillStyle.None;
                break;
        }

        attributes.BackgroundColor = color;
        attributes.GradientFillAngle = angle;
        return attributes;
    }
}