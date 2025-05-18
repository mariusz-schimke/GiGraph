using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font;

public partial class DotHtmlFont : IDotHtmlFontAttributes
{
    /// <inheritdoc cref="IDotHtmlFontAttributes.Name"/>
    public virtual string? Name
    {
        get => Attributes.Implementation.Name;
        set => Attributes.Implementation.Name = value;
    }

    /// <inheritdoc cref="IDotHtmlFontAttributes.Size"/>
    public virtual double? Size
    {
        get => Attributes.Implementation.Size;
        set => Attributes.Implementation.Size = value;
    }

    /// <inheritdoc cref="IDotHtmlFontAttributes.Color"/>
    public virtual DotColor? Color
    {
        get => Attributes.Implementation.Color;
        set => Attributes.Implementation.Color = value;
    }

    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="name">
    ///     Font name.
    /// </param>
    /// <param name="size">
    ///     Font size.
    /// </param>
    /// <param name="color">
    ///     Font color.
    /// </param>
    public virtual DotHtmlFont Set(string? name = null, double? size = null, DotColor? color = null)
    {
        Size = size;
        Color = color;
        Name = name;
        return this;
    }

    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotHtmlFont Set(DotFont attributes) => Set(attributes.Name, attributes.Size, attributes.Color);
}