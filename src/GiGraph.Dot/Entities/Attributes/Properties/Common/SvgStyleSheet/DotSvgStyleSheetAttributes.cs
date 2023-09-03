using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

public class DotSvgStyleSheetAttributes : DotSvgStyleSheetAttributes<IDotSvgStyleSheetAttributes, DotSvgStyleSheetAttributes>
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSvgStyleSheetAttributes, IDotSvgStyleSheetAttributes>().BuildLazy();

    public DotSvgStyleSheetAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotSvgStyleSheetAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }
}