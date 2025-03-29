using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Extensions;

public static class DotGraphSectionExtension
{
    /// <summary>
    ///     Sets a background color.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="color">
    ///     The color to use.
    /// </param>
    public static void SetBackground(this DotGraphSection @this, DotColor color)
    {
        @this.Canvas.BackgroundColor = color;
    }

    /// <summary>
    ///     Sets a gradient background color. Note that the fill style set by this method (as opposed to the color) applies not only to
    ///     the root graph, but also to clusters (globally) since this is a root graph's attribute. So if radial fill style was
    ///     previously specified on the clusters collection, it will be removed by this method.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill. Note that this attribute also applies to clusters.
    /// </param>
    public static void SetGradientBackground(this DotGraphSection @this, DotGradientColor color, int? angle = null)
    {
        @this.SetGradientBackground(color, angle, radial: false);
    }

    /// <summary>
    ///     <para>
    ///         Sets a gradient background color. Note that the fill style set by this method (as opposed to the color) applies not only
    ///         to the root graph, but also to clusters (globally) since this is a root graph's attribute. So if radial fill style was
    ///         previously specified on the clusters collection, it will be removed by this method.
    ///     </para>
    ///     <para>
    ///         Also, if at least one weighted color is specified (see <see cref="DotWeightedColor" />), a degenerate linear gradient
    ///         fill will be done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight" />
    ///         specifying how much of region is filled with each color.
    ///     </para>
    /// </summary>
    /// <param name="this">
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
    public static void SetGradientBackground(this DotGraphSection @this, DotColor startColor, DotColor endColor, int? angle = null)
    {
        @this.SetGradientBackground(new DotGradientColor(startColor, endColor), angle);
    }

    /// <summary>
    ///     Sets a radial gradient background color. Note that the radial fill style set by this method (as opposed to the color) applies
    ///     not only to the root graph, but also to clusters (globally) since this is a root graph's attribute.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the background for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill. Note that this attribute also applies to clusters.
    /// </param>
    public static void SetRadialGradientBackground(this DotGraphSection @this, DotGradientColor color, int? angle = null)
    {
        @this.SetGradientBackground(color, angle, radial: true);
    }

    /// <summary>
    ///     Sets a radial gradient background color. Note that the radial fill style set by this method (as opposed to the color) applies
    ///     not only to the root graph, but also to clusters (globally) since this is a root graph's attribute.
    /// </summary>
    /// <param name="this">
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
    public static void SetRadialGradientBackground(this DotGraphSection @this, DotColor startColor, DotColor endColor, int? angle = null)
    {
        @this.SetRadialGradientBackground(new DotGradientColor(startColor, endColor), angle);
    }

    private static void SetGradientBackground(this DotGraphSection @this, DotGradientColor color, int? angle, bool? radial)
    {
        switch (radial)
        {
            // the style may also be set from the Clusters collection on graph, and radial is the only attribute
            // that applies to graph background and to cluster fill
            case true:
                @this.Canvas.FillStyle = DotClusterFillStyle.Radial;
                break;

            case false when @this.Canvas.FillStyle == DotClusterFillStyle.Radial:
                @this.Canvas.FillStyle = DotClusterFillStyle.None;
                break;
        }

        @this.Canvas.BackgroundColor = color;
        @this.Canvas.GradientFillAngle = angle;
    }
}