using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Attributes.Properties;

namespace GiGraph.Dot.Entities.Html.Table.Attributes
{
    public class DotHtmlTableRowAttributes : DotHtmlElementRootAttributes<IDotHtmlTableRowAttributes>, IDotHtmlTableRowAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup HtmlTableRowAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableRowAttributes, IDotHtmlTableRowAttributes>().Build();

        protected DotHtmlTableRowAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlTableRowAttributes()
            : this(new DotAttributeCollection(DotHtmlAttributeFactory.Instance), HtmlTableRowAttributesKeyLookup)
        {
        }
    }
}