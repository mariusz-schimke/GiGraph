using System;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotEntityAttributesAccessor : IDotEntityAttributesAccessor
    {
        protected readonly DotEntityAttributes _attributes;

        protected DotEntityAttributesAccessor(DotEntityAttributes attributes)
        {
            _attributes = attributes;
        }

        Type IDotEntityAttributesAccessor.InterfaceType => GetInterfaceType();
        DotEntityAttributes IDotEntityAttributesAccessor.Implementation => _attributes;

        protected abstract Type GetInterfaceType();
    }
}