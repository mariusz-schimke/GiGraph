using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotNestedEntityAttributes<TIEntityAttributeProperties> : DotEntityAttributes
    {
        protected DotNestedEntityAttributes(DotEntityAttributesAccessor<TIEntityAttributeProperties> attributes)
            : base(attributes)
        {
            Attributes = attributes;
        }

        protected DotNestedEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
            Attributes = new DotEntityAttributesAccessor<TIEntityAttributeProperties>(parent: this);
        }

        /// <summary>
        ///     Provides access to individual attributes in the current context.
        /// </summary>
        public virtual DotEntityAttributesAccessor<TIEntityAttributeProperties> Attributes { get; }
    }
}