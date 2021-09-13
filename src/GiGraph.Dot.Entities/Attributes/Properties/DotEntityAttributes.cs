using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract partial class DotEntityAttributes
    {
        protected readonly Lazy<DotMemberAttributeKeyLookup> _attributeKeyLookup;
        protected readonly DotAttributeCollection _attributes;

        protected DotEntityAttributes(DotEntityAttributes source)
            : this(source._attributes, source._attributeKeyLookup)
        {
        }

        protected DotEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        {
            _attributes = attributes;
            _attributeKeyLookup = attributeKeyLookup;
        }

        protected virtual string GetKey(MethodBase accessor)
        {
            return _attributeKeyLookup.Value.GetPropertyAccessorKey((MethodInfo) accessor);
        }
    }
}