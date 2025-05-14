using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties;

public abstract class DotEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
    : IDotEntityAttributes
{
    protected readonly Lazy<DotMemberAttributeKeyLookup> _attributeKeyLookup = attributeKeyLookup;
    protected readonly DotAttributeCollection _attributes = attributes;

    internal DotAttributeCollection Collection => _attributes;

    IDotEntityAttributesAccessor IDotEntityAttributes.Accessor => GetAccessor();
    protected abstract DotEntityAttributesAccessor GetAccessor();

    protected internal virtual string GetKey(PropertyInfo property) =>
        // the lookup maps only property setters
        _attributeKeyLookup.Value.GetPropertyAccessorKey(property.SetMethod!);
}