using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

// see also DotHasBorderStyleAttributesExtension which is pretty much the same
// mind that DotColorDefinition is accepted here (rather than the simple DotColor) because complex colors impact the way the line is visualized (multicolor or multiline)

public static class DotHasLineStyleAttributesExtension
{
    /// <summary>
    ///     Sets border style.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="style">
    ///     The border style to set.
    /// </param>
    /// <param name="width">
    ///     The border width to set.
    /// </param>
    public static T SetLineStyle<T>(this T entity, DotLineStyle style, double? width)
        where T : IDotHasLineStyleAttributes
    {
        entity.LineStyle = style;
        entity.LineWidth = width;
        return entity;
    }

    /// <summary>
    ///     Sets border style.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="style">
    ///     The border style to set.
    /// </param>
    /// <param name="width">
    ///     The border width to set.
    /// </param>
    /// <param name="color">
    ///     The color to set for the border. Note: this color also acts as the fill color if a fill style is specified, unless a fill
    ///     color is specified separately. To ensure the color is used only for the border, set both the color and a fill color, or don't
    ///     apply a filled style.
    /// </param>
    public static T SetLineStyle<T>(this T entity, DotLineStyle style, double? width, DotColorDefinition? color)
        where T : IDotHasLineStyleAttributes
    {
        entity.LineColor = color;
        return entity.SetLineStyle(style, width);
    }

    /// <summary>
    ///     Sets border style.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="style">
    ///     The border style to set.
    /// </param>
    /// <param name="weight">
    ///     The border weight to set.
    /// </param>
    public static T SetLineStyle<T>(this T entity, DotLineStyle style, DotLineWeight weight)
        where T : IDotHasLineStyleAttributes
    {
        entity.LineStyle = style;
        entity.LineWeight = weight;
        return entity;
    }

    /// <summary>
    ///     Sets border style.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="style">
    ///     The border style to set.
    /// </param>
    /// <param name="weight">
    ///     The border weight to set.
    /// </param>
    /// <param name="color">
    ///     The color to set for the border. Note: this color also acts as the fill color if a fill style is specified, unless a fill
    ///     color is specified separately. To ensure the color is used only for the border, set both the color and a fill color, or don't
    ///     apply a filled style.
    /// </param>
    public static T SetLineStyle<T>(this T entity, DotLineStyle style, DotLineWeight weight, DotColorDefinition? color)
        where T : IDotHasLineStyleAttributes
    {
        entity.LineColor = color;
        return entity.SetLineStyle(style, weight);
    }
}