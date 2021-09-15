using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public class DotEntityRootAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>, IDotAnnotatable
        where TEntityAttributeProperties : DotEntityAttributes, TIEntityAttributeProperties
    {
        public DotEntityRootAttributes(TEntityAttributeProperties implementation)
            : base(implementation)
        {
        }

        /// <summary>
        ///     Gets the underlying collection of attributes applied to the element.
        /// </summary>
        public new DotAttributeCollection Collection => _attributes;

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public string Annotation
        {
            get => _attributes.Annotation;
            set => _attributes.Annotation = value;
        }
    }
}