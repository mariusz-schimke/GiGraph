using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font.Styles;

/// <summary>
///     An HTML bold text element (&lt;b&gt;).
/// </summary>
public class DotHtmlBold : DotHtmlFontStyle
{
    protected const string TagName = "b";

    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotHtmlBold()
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
    public DotHtmlBold(string text, DotHorizontalAlignment? lineAlignment = null)
        : base(TagName, text, lineAlignment)
    {
    }

    protected DotHtmlBold(DotHtmlAttributeCollection attributes)
        : base(TagName, attributes)
    {
    }
}