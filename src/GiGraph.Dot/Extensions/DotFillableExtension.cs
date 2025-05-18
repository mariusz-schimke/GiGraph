using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

public static class DotFillableExtension
{
    /// <summary>
    ///     Sets a plain-color fill.
    /// </summary>
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="color">
    ///     The color to use.
    /// </param>
    public static T SetPlainFill<T>(this T entity, DotColor color)
        where T : IDotFillable
    {
        entity.SetFillStyle(DotFillStyle.Regular);
        entity.SetFillColor(color);
        return entity;
    }

    /// <summary>
    ///     Sets a gradient fill.
    /// </summary>
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill.
    /// </param>
    public static T SetGradientFill<T>(this T entity, DotGradientColor color, int? angle = null)
        where T : IDotFillable =>
        entity.SetGradientFill(color, angle, radial: false);

    /// <summary>
    ///     <para>
    ///         Sets a gradient fill.
    ///     </para>
    ///     <para>
    ///         Note that if at least one weighted color is specified (see <see cref="DotWeightedColor"/>), a degenerate linear gradient
    ///         fill is done. This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight"/> specifying
    ///         how much of region is filled with each color.
    ///     </para>
    /// </summary>
    /// <param name="entity">
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
    public static T SetGradientFill<T>(this T entity, DotColor startColor, DotColor endColor, int? angle = null)
        where T : IDotFillable =>
        entity.SetGradientFill(new DotGradientColor(startColor, endColor), angle);

    /// <summary>
    ///     Sets a radial gradient fill.
    /// </summary>
    /// <param name="entity">
    ///     The current context to set the fill for.
    /// </param>
    /// <param name="color">
    ///     The gradient color definition to use.
    /// </param>
    /// <param name="angle">
    ///     The angle of the fill.
    /// </param>
    public static T SetRadialGradientFill<T>(this T entity, DotGradientColor color, int? angle = null)
        where T : IDotFillable =>
        entity.SetGradientFill(color, angle, radial: true);

    /// <summary>
    ///     Sets a radial gradient fill.
    /// </summary>
    /// <param name="entity">
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
    public static T SetRadialGradientFill<T>(this T entity, DotColor startColor, DotColor endColor, int? angle = null)
        where T : IDotFillable =>
        entity.SetRadialGradientFill(new DotGradientColor(startColor, endColor), angle);

    private static T SetGradientFill<T>(this T entity, DotGradientColor color, int? angle, bool radial)
        where T : IDotFillable
    {
        entity.SetFillStyle(radial ? DotFillStyle.Radial : DotFillStyle.Regular);
        entity.SetFillColor(color);
        entity.SetGradientFillAngle(angle);
        return entity;
    }
}