using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font;

public partial class DotHtmlFont : IDotHtmlFontAttributes, IDotHasFontAttributes
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
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotHtmlFont Set(DotFont attributes) => this.Set(attributes.Name, attributes.Size, attributes.Color);
}