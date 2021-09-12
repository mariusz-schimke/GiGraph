using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotNestedEntityAttributes<TIEntityAttributeProperties> : DotEntityAttributes
    {
        static DotNestedEntityAttributes()
        {
            if (!typeof(TIEntityAttributeProperties).IsInterface)
            {
                throw new ArgumentException($"The type {typeof(TIEntityAttributeProperties).Name} specified as the type parameter is not an interface.", nameof(TIEntityAttributeProperties));
            }
        }

        protected DotNestedEntityAttributes(DotEntityAttributesAccessor<TIEntityAttributeProperties> attributes)
            : base(attributes)
        {
            ValidateCurrentType();
            Attributes = attributes;
        }

        protected DotNestedEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
            ValidateCurrentType();
            Attributes = new DotEntityAttributesAccessor<TIEntityAttributeProperties>(parent: this);
        }

        /// <summary>
        ///     Provides access to individual attributes in the current context.
        /// </summary>
        public virtual DotEntityAttributesAccessor<TIEntityAttributeProperties> Attributes { get; }

        protected virtual void ValidateCurrentType()
        {
            if (this is not TIEntityAttributeProperties)
            {
                throw new Exception($"The type {GetType().Name} does not implement the {typeof(TIEntityAttributeProperties).Name} interface.");
            }
        }
    }
}