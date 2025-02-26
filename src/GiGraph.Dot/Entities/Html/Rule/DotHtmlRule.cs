using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Rule;

/// <summary>
///     An HTML rule element.
/// </summary>
public abstract class DotHtmlRule : DotHtmlVoidElement
{
    protected DotHtmlRule(string tagName)
        : base(tagName, new DotHtmlAttributeCollection())
    {
    }

    /// <summary>
    ///     Gets a static instance of a vertical rule element.
    /// </summary>
    public static DotHtmlEntity Vertical => DotHtmlVerticalRule.Instance;

    /// <summary>
    ///     Gets a static instance of a horizontal rule element.
    /// </summary>
    public static DotHtmlEntity Horizontal => DotHtmlHorizontalRule.Instance;
}