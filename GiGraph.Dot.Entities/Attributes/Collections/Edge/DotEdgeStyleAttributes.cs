using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeStyleAttributes : DotEntityCommonStyleAttributes<DotEdgeStyleOptions>
    {
        protected DotEdgeStyleAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Tapered" /> style option state (default: false).
        /// </summary>
        public virtual bool Tapered
        {
            get => HasOptions(DotStyles.Tapered);
            set => ApplyOption(DotStyles.Tapered, value);
        }
    }
}