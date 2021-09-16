using System;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotEntityAttributesAccessor : DotEntityAttributes, IDotEntityAttributesAccessor
    {
        protected DotEntityAttributesAccessor(DotEntityAttributes source)
            : base(source)
        {
        }

        Type IDotEntityAttributesAccessor.InterfaceType => GetInterfaceType();
        DotEntityAttributes IDotEntityAttributesAccessor.Implementation => GetImplementation();
        string IDotEntityAttributesAccessor.GetPropertyKey(PropertyInfo property) => GetPropertyKey(property);

        protected abstract Type GetInterfaceType();
        protected abstract DotEntityAttributes GetImplementation();

        protected virtual string GetPropertyKey(PropertyInfo property)
        {
            // the lookup contains only interface properties and property accessors of implementing classes
            return _attributeKeyLookup.Value.GetPropertyKey(property);
        }
    }
}