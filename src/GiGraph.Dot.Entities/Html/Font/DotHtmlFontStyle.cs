using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML font style element.
    /// </summary>
    public abstract partial class DotHtmlFontStyle : DotHtmlElement
    {
        protected DotHtmlFontStyle(string tagName)
            : base(tagName, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlFontStyle(string tagName, string text, DotHorizontalAlignment? horizontalAlignment)
            : base(tagName, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
            SetContent(text, horizontalAlignment);
        }

        protected DotHtmlFontStyle(string tagName, DotAttributeCollection attributes)
            : base(tagName, attributes)
        {
        }
    }
}