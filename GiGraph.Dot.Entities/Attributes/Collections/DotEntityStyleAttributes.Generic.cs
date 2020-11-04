using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract class DotEntityStyleAttributes<TStyleOptions> : DotEntityStyleAttributes
        where TStyleOptions : DotStyleOptions
    {
        protected DotEntityStyleAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Applies the specified style options to the element.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Apply(TStyleOptions options)
        {
            Value = options.ApplyTo(Value);
        }
    }
}