using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

public static class DotFillableExtension
{
    /// <summary>
    ///     Sets a plain-color fill.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="color">
    ///     The color to use.
    /// </param>
    public static void SetPlainColorFill<T>(this T @this, DotColor color)
        where T : IDotFillable
    {
        @this.SetFillStyle(DotFillStyle.Regular);
        @this.SetFillColor(color);
    }

    /// <summary>
    ///     Sets a gradient fill.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill.
    /// </param>
    public static void SetGradientFill<T>(this T @this, DotGradientColor color, int? angle = null)
        where T : IDotFillable
    {
        @this.SetGradientFill(color, angle, radial: false);
    }

    /// <summary>
    ///     <para>
    ///         Sets a gradient fill.
    ///     </para>
    ///     <para>
    ///         Note that if at least one weighted color is specified (see <see cref="DotWeightedColor" />), a degenerate linear gradient
    ///         fill is done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight" /> specifying
    ///         how much of region is filled with each color.
    ///     </para>
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="startColor">
    ///     The start color of the gradient fill.
    /// </param>
    /// <param name="endColor">
    ///     The end color of the gradient fill.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill.
    /// </param>
    public static void SetGradientFill<T>(this T @this, DotColor startColor, DotColor endColor, int? angle = null)
        where T : IDotFillable
    {
        @this.SetGradientFill(new DotGradientColor(startColor, endColor), angle);
    }

    /// <summary>
    ///     Sets a radial gradient fill.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill.
    /// </param>
    public static void SetRadialGradientFill<T>(this T @this, DotGradientColor color, int? angle = null)
        where T : IDotFillable
    {
        @this.SetGradientFill(color, angle, radial: true);
    }

    /// <summary>
    ///     Sets a radial gradient fill.
    /// </summary>
    /// <param name="this">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="startColor">
    ///     The start color of the gradient fill.
    /// </param>
    /// <param name="endColor">
    ///     The end color of the gradient fill.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill.
    /// </param>
    public static void SetRadialGradientFill<T>(this T @this, DotColor startColor, DotColor endColor, int? angle = null)
        where T : IDotFillable
    {
        @this.SetRadialGradientFill(new DotGradientColor(startColor, endColor), angle);
    }

    private static void SetGradientFill<T>(this T @this, DotGradientColor color, int? angle, bool radial)
        where T : IDotFillable
    {
        @this.SetFillStyle(radial ? DotFillStyle.Radial : DotFillStyle.Regular);
        @this.SetFillColor(color);
        @this.SetGradientFillAngle(angle);
    }
}