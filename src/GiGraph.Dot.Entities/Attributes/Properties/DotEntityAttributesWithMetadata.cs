using System;
using System.Linq.Expressions;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotEntityAttributesWithMetadata<TIEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties>
    {
        protected DotEntityAttributesWithMetadata(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets metadata of the DOT attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get attribute metadata for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual DotAttributeMetadata GetMetadata<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetKey(property);
            return DotAttributeKeys.MetadataDictionary[key];
        }
    }
}