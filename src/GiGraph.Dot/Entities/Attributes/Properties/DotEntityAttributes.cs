using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties;

public abstract class DotEntityAttributes : IDotEntityAttributes
{
    protected readonly Lazy<DotMemberAttributeKeyLookup> _attributeKeyLookup;
    protected readonly DotAttributeCollection _attributes;

    protected DotEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
    {
        _attributes = attributes;
        _attributeKeyLookup = attributeKeyLookup;
    }

    internal DotAttributeCollection Collection => _attributes;

    IDotEntityAttributesAccessor IDotEntityAttributes.Accessor => GetAccessor();
    protected abstract DotEntityAttributesAccessor GetAccessor();

    protected internal virtual string GetKey(PropertyInfo property) =>
        // the lookup contains only interface properties and property accessors of implementing classes
        _attributeKeyLookup.Value.GetPropertyKey(property);
}