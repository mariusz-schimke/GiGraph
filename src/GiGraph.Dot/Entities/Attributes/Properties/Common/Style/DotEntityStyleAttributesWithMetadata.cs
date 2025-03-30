using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public abstract class DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
    DotStyleAttributeOptions styleAttributeOptions
)
    : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup)
    where TEntityAttributeProperties : DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    protected readonly DotStyleAttributeOptions _styleAttributeOptions = styleAttributeOptions;
}