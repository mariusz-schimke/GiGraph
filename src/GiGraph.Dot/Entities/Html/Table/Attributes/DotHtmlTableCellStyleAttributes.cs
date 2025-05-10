using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public class DotHtmlTableCellStyleAttributes : DotHtmlTableTableCellCommonStyleAttributes<IDotHtmlTableCellStyleAttributes, DotHtmlTableCellStyleAttributes>, IDotHtmlTableCellStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableCellStyleAttributes, IDotHtmlTableCellStyleAttributes>().BuildLazy();

    public DotHtmlTableCellStyleAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableCellStyleAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }
}