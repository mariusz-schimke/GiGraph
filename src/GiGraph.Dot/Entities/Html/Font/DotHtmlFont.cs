using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Entities.Html.Font.Attributes;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font;

/// <summary>
///     An HTML &lt;font&gt; element. Supports <see cref="DotHtmlTable" />, text and text styling elements as the content.
/// </summary>
public partial class DotHtmlFont : DotHtmlElement
{
    /// <summary>
    ///     Initializes a new font element instance.
    /// </summary>
    /// <param name="name">
    ///     Specifies the font to use within the scope of the current element.
    /// </param>
    /// <param name="size">
    ///     Specifies the size of the font, in points, to use within the scope of the current element.
    /// </param>
    /// <param name="color">
    ///     Sets the color of the font within the scope of the current element.
    /// </param>
    public DotHtmlFont(string? name = null, double? size = null, DotColor? color = null)
        : this(new DotHtmlAttributeCollection())
    {
        if (name is not null)
        {
            Name = name;
        }

        if (size.HasValue)
        {
            Size = size;
        }

        if (color is not null)
        {
            Color = color;
        }
    }

    /// <summary>
    ///     Initializes a new font element instance.
    /// </summary>
    /// <param name="font">
    ///     The font to set.
    /// </param>
    public DotHtmlFont(DotFont font)
        : this(font.Name, font.Size, font.Color)
    {
    }

    /// <summary>
    ///     Initializes a new font element instance.
    /// </summary>
    /// <param name="source">
    ///     The font to set.
    /// </param>
    public DotHtmlFont(IDotHtmlFontAttributes source)
        : this(source.Name, source.Size, source.Color)
    {
    }

    protected DotHtmlFont(DotHtmlAttributeCollection attributes)
        : this(new DotHtmlFontAttributes(attributes))
    {
    }

    protected DotHtmlFont(DotHtmlFontAttributes attributes)
        : base("font", attributes.Collection)
    {
        Attributes = new DotHtmlElementRootAttributesAccessor<IDotHtmlFontAttributes, DotHtmlFontAttributes>(attributes);
    }

    /// <summary>
    ///     Provides access to the attributes of the font.
    /// </summary>
    public new DotHtmlElementRootAttributesAccessor<IDotHtmlFontAttributes, DotHtmlFontAttributes> Attributes { get; }

    /// <summary>
    ///     Creates an appropriate nested structure of HTML tags based on the specified font and style.
    /// </summary>
    /// <param name="font">
    ///     The font and/or style to apply.
    /// </param>
    /// <param name="contentElement">
    ///     The bottom-level element to embed content in.
    /// </param>
    public static DotHtmlFont FromStyledFont(DotStyledFont font, out DotHtmlElement contentElement)
    {
        var fontElement = new DotHtmlFont(font);
        contentElement = fontElement;

        if (font.Style.HasValue && DotHtmlFontStyle.FromStyle(font.Style.Value, out var styleContentElement) is { } styleRoot)
        {
            fontElement.SetContent(styleRoot);
            contentElement = styleContentElement!;
        }

        return fontElement;
    }
}