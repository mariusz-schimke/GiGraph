using System;
using System.Linq;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.EnumHelpers;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font.Styles;

/// <summary>
///     An HTML font style element.
/// </summary>
public abstract partial class DotHtmlFontStyle : DotHtmlElement
{
    protected DotHtmlFontStyle(string tagName)
        : base(tagName, new DotHtmlAttributeCollection())
    {
    }

    protected DotHtmlFontStyle(string tagName, string text, DotHorizontalAlignment? lineAlignment)
        : base(tagName, new DotHtmlAttributeCollection())
    {
        SetContent(text, lineAlignment);
    }

    protected DotHtmlFontStyle(string tagName, DotHtmlAttributeCollection attributes)
        : base(tagName, attributes)
    {
    }

    /// <summary>
    ///     Creates an appropriate nested structure of HTML tags based on the specified font style. Returns null for the
    ///     <see cref="DotFontStyles.Normal" /> font style.
    /// </summary>
    /// <param name="style">
    ///     The style to apply to the entities.
    /// </param>
    /// <param name="contentElement">
    ///     The bottom-level element to embed content in. Returns null for the <see cref="DotFontStyles.Normal" /> font style.
    /// </param>
    public static DotHtmlFontStyle FromStyle(DotFontStyles style, out DotHtmlFontStyle contentElement)
    {
        DotHtmlFontStyle result = null;
        contentElement = null;

        var metadata = new DotEnumMetadata(style.GetType());
        foreach (var styleFlag in metadata.GetSetFlags(style).Cast<DotFontStyles>())
        {
            DotHtmlFontStyle styleElement = styleFlag switch
            {
                DotFontStyles.Bold => new DotHtmlBold(),
                DotFontStyles.Italic => new DotHtmlItalic(),
                DotFontStyles.Underline => new DotHtmlUnderline(),
                DotFontStyles.Overline => new DotHtmlOverline(),
                DotFontStyles.Subscript => new DotHtmlSubscript(),
                DotFontStyles.Superscript => new DotHtmlSuperscript(),
                DotFontStyles.Strikethrough => new DotHtmlStrikethrough(),
                _ => throw new ArgumentOutOfRangeException(nameof(style), styleFlag, "Invalid font style flag")
            };

            contentElement?.Content.Add(styleElement);
            contentElement = styleElement;
            result ??= contentElement;
        }

        return result;
    }
}