using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties;

/// <summary>
///     This class only indicates that the descendants provide access to attributes that have metadata available. This is true for
///     DOT attributes, but not for HTML element attributes.
/// </summary>
public abstract class DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
    : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup)
    where TEntityAttributeProperties : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties;