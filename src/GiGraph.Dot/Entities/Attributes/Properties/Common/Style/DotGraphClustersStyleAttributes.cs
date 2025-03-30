using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public abstract class DotStyleAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>
    where TEntityAttributeProperties : DotStyleAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    protected readonly DotStyleAttributeOptions _styleAttributeOptions;

    protected DotStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotStyleAttributeOptions styleAttributeOptions)
        : base(attributes, attributeKeyLookup)
    {
        _styleAttributeOptions = styleAttributeOptions;
    }
}