using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font.Styles;

/// <summary>
///     An HTML underlined text element (&lt;u&gt;).
/// </summary>
public class DotHtmlUnderline : DotHtmlFontStyle
{
    protected const string TagName = "u";

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotHtmlUnderline()
        : base(TagName)
    {
    }

    /// <summary>
    ///     Creates a new instance with the specified text as its content.
    /// </summary>
    /// <param name="text">
    ///     The text to set as the content.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    public DotHtmlUnderline(string? text, DotHorizontalAlignment? lineAlignment = null)
        : base(TagName, text, lineAlignment)
    {
    }

    protected DotHtmlUnderline(DotHtmlAttributeCollection attributes)
        : base(TagName, attributes)
    {
    }
}