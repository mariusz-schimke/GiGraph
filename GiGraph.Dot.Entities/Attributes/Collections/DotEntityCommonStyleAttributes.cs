using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract class DotEntityCommonStyleAttributes<TStyleOptions> : DotEntityStyleAttributes<TStyleOptions>
        where TStyleOptions : DotCommonStyleOptions
    {
        protected DotEntityCommonStyleAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityCommonStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Solid" /> style option state.
        /// </summary>
        public virtual bool Solid
        {
            get => HasOptions(DotStyles.Solid);
            set => ApplyOption(DotStyles.Solid, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dashed" /> style option state.
        /// </summary>
        public virtual bool Dashed
        {
            get => HasOptions(DotStyles.Dashed);
            set => ApplyOption(DotStyles.Dashed, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dotted" /> style option state.
        /// </summary>
        public virtual bool Dotted
        {
            get => HasOptions(DotStyles.Dotted);
            set => ApplyOption(DotStyles.Dotted, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Bold" /> style option state.
        /// </summary>
        public virtual bool Bold
        {
            get => HasOptions(DotStyles.Bold);
            set => ApplyOption(DotStyles.Bold, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Invisible" /> style option state.
        /// </summary>
        public virtual bool Invisible
        {
            get => HasOptions(DotStyles.Invisible);
            set => ApplyOption(DotStyles.Invisible, value);
        }
    }
}