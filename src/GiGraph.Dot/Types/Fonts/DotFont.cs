using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Types.Fonts;

/// <summary>
///     Font attributes.
/// </summary>
/// <param name="Name">
///     Font name.
/// </param>
/// <param name="Size">
///     Font size.
/// </param>
/// <param name="Color">
///     Font color.
/// </param>
public record DotFont(string? Name = null, double? Size = null, DotColor? Color = null)
{
    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="size">
    ///     Font size.
    /// </param>
    /// <param name="color">
    ///     Font color.
    /// </param>
    public DotFont(double size, DotColor? color = null)
        : this(Name: null, size, color)
    {
    }

    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="color">
    ///     Font color.
    /// </param>
    /// <param name="name">
    ///     Font name.
    /// </param>
    public DotFont(DotColor? color, string? name = null)
        : this(name, Size: null, color)
    {
    }

    /// <summary>
    ///     The font name.
    /// </summary>
    public string? Name { get; init; } = Name;

    /// <summary>
    ///     The font size.
    /// </summary>
    public double? Size { get; init; } = Size;

    /// <summary>
    ///     The font color.
    /// </summary>
    public DotColor? Color { get; init; } = Color;
}