using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions;

// see also DotHasLineStyleAttributesExtension which is pretty much the same
// mind that DotColor is accepted here (rather than the complex DotColorDefinition) because the border can have only one, plain color, so it could be misleading if the complex type was accepted

public static class DotHasBorderStyleAttributesExtension
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
    public static T SetBorderStyle<T>(this T entity, DotBorderStyle style, double? width)
        where T : IDotHasBorderStyleAttributes
    {
        entity.BorderStyle = style;
        entity.BorderWidth = width;
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
    public static T SetBorderStyle<T>(this T entity, DotBorderStyle style, double? width, DotColor? color)
        where T : IDotHasBorderStyleAttributes
    {
        entity.Color = color;
        return entity.SetBorderStyle(style, width);
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
    public static T SetBorderStyle<T>(this T entity, DotBorderStyle style, DotBorderWeight weight)
        where T : IDotHasBorderStyleAttributes
    {
        entity.BorderStyle = style;
        entity.BorderWeight = weight;
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
    public static T SetBorderStyle<T>(this T entity, DotBorderStyle style, DotBorderWeight weight, DotColor? color)
        where T : IDotHasBorderStyleAttributes
    {
        entity.Color = color;
        return entity.SetBorderStyle(style, weight);
    }
}