using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html.Attributes.Properties;

public abstract class DotHtmlElementAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
    : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup)
    where TEntityAttributeProperties : DotHtmlElementAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    internal new DotHtmlAttributeCollection Collection => (DotHtmlAttributeCollection) _attributes;
}