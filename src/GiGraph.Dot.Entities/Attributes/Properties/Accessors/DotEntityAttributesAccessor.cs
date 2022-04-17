using System;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties.Accessors;

public abstract class DotEntityAttributesAccessor : IDotEntityAttributesAccessor
{
    protected readonly DotEntityAttributes _attributes;

    protected DotEntityAttributesAccessor(DotEntityAttributes attributes)
    {
        _attributes = attributes;
    }

    Type IDotEntityAttributesAccessor.InterfaceType => GetInterfaceType();
    DotEntityAttributes IDotEntityAttributesAccessor.Implementation => _attributes;
    string IDotEntityAttributesAccessor.GetPropertyKey(PropertyInfo property) => _attributes.GetKey(property);

    protected abstract Type GetInterfaceType();
}