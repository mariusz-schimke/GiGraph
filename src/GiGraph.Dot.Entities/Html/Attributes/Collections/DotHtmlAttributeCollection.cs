using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;

namespace GiGraph.Dot.Entities.Html.Attributes.Collections
{
    public class DotHtmlAttributeCollection : DotAttributeCollection
    {
        public DotHtmlAttributeCollection(DotHtmlAttributeFactory attributeFactory)
            : base(attributeFactory)
        {
        }

        public DotHtmlAttributeCollection()
            : base(DotHtmlAttributeFactory.Instance)
        {
        }
    }
}