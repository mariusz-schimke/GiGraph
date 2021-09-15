using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotNestedEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributes
        where TEntityAttributeProperties : DotEntityAttributes, TIEntityAttributeProperties
    {
        static DotNestedEntityAttributes()
        {
            if (!typeof(TIEntityAttributeProperties).IsInterface)
            {
                throw new ArgumentException($"The type {typeof(TIEntityAttributeProperties).Name} specified as the type parameter is not an interface.", nameof(TIEntityAttributeProperties));
            }
        }

        protected DotNestedEntityAttributes(TEntityAttributeProperties implementation)
            : base(implementation)
        {
            Attributes = new DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>(implementation);
        }

        protected DotNestedEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
            if (this is not TEntityAttributeProperties implementation)
            {
                throw new ArgumentException($"The type {GetType().Name} is not assignable to the {typeof(TEntityAttributeProperties).Name} type specified as the type parameter.", nameof(TEntityAttributeProperties));
            }

            Attributes = new DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>(implementation);
        }

        /// <summary>
        ///     Provides access to individual attributes in the current context.
        /// </summary>
        public virtual DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties> Attributes { get; }
    }
}