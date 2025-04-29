using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Types.Fonts;

/// <summary>
///     Font and style attributes.
/// </summary>
/// <param name="Style">
///     Font style.
/// </param>
/// <param name="Name">
///     Font name.
/// </param>
/// <param name="Size">
///     Font size.
/// </param>
/// <param name="Color">
///     Font color.
/// </param>
public record DotStyledFont(DotFontStyles? Style = null, string? Name = null, double? Size = null, DotColor? Color = null)
    : DotFont(Name, Size, Color)
{
    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="style">
    ///     Font style.
    /// </param>
    /// <param name="size">
    ///     Font size.
    /// </param>
    /// <param name="color">
    ///     Font color.
    /// </param>
    public DotStyledFont(DotFontStyles? style, double? size, DotColor? color = null)
        : this(style, Name: null, size, color)
    {
    }

    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="style">
    ///     Font style.
    /// </param>
    /// <param name="color">
    ///     Font color.
    /// </param>
    /// <param name="name">
    ///     Font name.
    /// </param>
    public DotStyledFont(DotFontStyles? style, DotColor? color, string? name = null)
        : this(style, name, Size: null, color)
    {
    }

    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="font">
    ///     A source font to copy attributes from.
    /// </param>
    /// <param name="style">
    ///     Font style.
    /// </param>
    public DotStyledFont(DotFont font, DotFontStyles? style = null)
        : this(style, font.Name, font.Size, font.Color)
    {
    }
}