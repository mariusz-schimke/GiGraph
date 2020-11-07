using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    // TODO: uzupełnić opisy właściwości na podstawie DotStyles
    // TODO: style dotyczą kształtu (rounded, tapered), obwódki (dotted, dashed), wypełnienia (filled, radial, wedged, striped) -
    //       może trzeba coś z tym zrobić, żeby dało się to ustawiać tak, aby pozostałe atrybuty się resetowały.
    //       Dodatkowo, aby jasne było, która opcja czego dotyczy (kształtu/obwódki/wypełnienia).
    // TODO: metody SetFilled ustawiają jedną opcję, ale nie resetują pozostałych z tego samego kontekstu. 
    //       Może tak jest ok, ale można rozważyć zmianę.

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
        ///     Gets or sets the <see cref="DotStyles.Solid" /> style option state (default: false).
        /// </summary>
        public virtual bool Solid
        {
            get => HasOptions(DotStyles.Solid);
            set => ApplyOption(DotStyles.Solid, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dashed" /> style option state (default: false).
        /// </summary>
        public virtual bool Dashed
        {
            get => HasOptions(DotStyles.Dashed);
            set => ApplyOption(DotStyles.Dashed, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dotted" /> style option state (default: false).
        /// </summary>
        public virtual bool Dotted
        {
            get => HasOptions(DotStyles.Dotted);
            set => ApplyOption(DotStyles.Dotted, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Bold" /> style option state (default: false).
        /// </summary>
        public virtual bool Bold
        {
            get => HasOptions(DotStyles.Bold);
            set => ApplyOption(DotStyles.Bold, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Invisible" /> style option state (default: false).
        /// </summary>
        public virtual bool Invisible
        {
            get => HasOptions(DotStyles.Invisible);
            set => ApplyOption(DotStyles.Invisible, value);
        }
    }
}