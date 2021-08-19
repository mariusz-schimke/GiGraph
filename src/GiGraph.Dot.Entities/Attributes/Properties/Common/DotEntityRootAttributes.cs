using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public abstract class DotEntityRootAttributes<TIEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties>, IDotAnnotatable
    {
        protected DotEntityRootAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets the underlying collection of attributes applied to the element.
        /// </summary>
        public virtual DotAttributeCollection Collection => _attributes;

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation
        {
            get => _attributes.Annotation;
            set => _attributes.Annotation = value;
        }
    }
}