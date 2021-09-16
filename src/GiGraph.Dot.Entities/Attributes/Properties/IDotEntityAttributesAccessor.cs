using System;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public interface IDotEntityAttributesAccessor
    {
        Type InterfaceType { get; }
        DotEntityAttributes Implementation { get; }
    }
}