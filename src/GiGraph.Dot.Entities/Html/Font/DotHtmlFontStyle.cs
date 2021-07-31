using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Text;

namespace GiGraph.Dot.Entities.Html.Font
{
    /// <summary>
    ///     An HTML font style element.
    /// </summary>
    public abstract class DotHtmlFontStyle : DotHtmlElement
    {
        protected DotHtmlFontStyle(string tagName)
            : base(tagName, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlFontStyle(string tagName, DotAttributeCollection attributes)
            : base(tagName, attributes)
        {
        }

        protected virtual void AppendText(string text)
        {
            Children.Add(new DotHtmlText(text));
        }
    }
}