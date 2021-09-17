using System;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties.Accessors
{
    public interface IDotEntityAttributesAccessor
    {
        Type InterfaceType { get; }
        DotEntityAttributes Implementation { get; }
        string GetPropertyKey(PropertyInfo property);
    }
}