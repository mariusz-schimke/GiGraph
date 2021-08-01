using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;

namespace GiGraph.Dot.Entities.Html.Rule
{
    /// <summary>
    ///     An HTML rule element.
    /// </summary>
    public abstract class DotHtmlRule : DotHtmlVoidElement
    {
        protected DotHtmlRule(string tagName)
            : base(tagName, new DotAttributeCollection(DotHtmlAttributeFactory.Instance))
        {
        }

        protected DotHtmlRule(string tagName, DotAttributeCollection attributes)
            : base(tagName, attributes)
        {
        }
    }
}