using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public class DotEntityRootAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>, IDotAnnotatable
        where TEntityAttributeProperties : DotEntityAttributes, TIEntityAttributeProperties
    {
        public DotEntityRootAttributes(TEntityAttributeProperties attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets the underlying collection of attributes applied to the element.
        /// </summary>
        public DotAttributeCollection Collection => _attributes.Collection;

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public string Annotation
        {
            get => _attributes.Collection.Annotation;
            set => _attributes.Collection.Annotation = value;
        }
    }
}