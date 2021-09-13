using System;
using System.Linq.Expressions;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Extensions
{
    public static class DotEntityAttributesExtension
    {
        /// <summary>
        ///     Gets the metadata of the DOT attribute specified by the property expression.
        /// </summary>
        /// <param name="this">
        ///     The current attribute collection context whose property to get the metadata for.
        /// </param>
        /// <param name="property">
        ///     The property to get attribute metadata for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        /// <typeparam name="TInterface">
        ///     An interface that provides access to properties that represent DOT attributes.
        /// </typeparam>
        /// <typeparam name="TImplementation">
        ///     The implementation of the <typeparamref name="TInterface" /> interface.
        /// </typeparam>
        public static DotAttributeMetadata GetMetadata<TInterface, TImplementation, TProperty>(
            this DotEntityAttributesAccessor<TInterface, TImplementation> @this, Expression<Func<TInterface, TProperty>> property
        )
            where TImplementation : DotEntityAttributes, TInterface
        {
            var key = @this.GetKey(property);
            return DotAttributeKeys.MetadataDictionary[key];
        }
    }
}