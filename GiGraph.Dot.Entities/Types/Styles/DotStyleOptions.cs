using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotStyleOptions
    {
        protected readonly DotStyles _mask;

        protected DotStyleOptions(DotStyles mask)
        {
            _mask = mask;
        }

        protected DotStyleOptions(DotStyles style, DotStyles mask)
            : this(mask)
        {
            Style = style;
        }

        /// <summary>
        ///     Gets or sets the final style.
        /// </summary>
        public virtual DotStyles? Style { get; set; }

        /// <summary>
        ///     Sets the style to <see cref="DotStyles.Default" />.
        /// </summary>
        public virtual void SetDefault()
        {
            Style = DotStyles.Default;
        }

        protected virtual bool GetOption(DotStyles option)
        {
            return Style.HasValue && Style.Value.HasFlag(option);
        }

        /// <summary>
        ///     Applies the style options to the specified base style and returns the result.
        /// </summary>
        /// <param name="style">
        ///     The base style to apply the options to.
        /// </param>
        public virtual DotStyles? ApplyTo(DotStyles? style)
        {
            return Style.HasValue
                ? ((style ?? DotStyles.Default) & ~_mask) | (Style & _mask)
                : style;
        }

        protected virtual void SetOption(DotStyles option, bool? set)
        {
            if (set.HasValue)
            {
                Style ??= DotStyles.Default;
            }

            if (set == true)
            {
                Style |= option;
            }
            else if (set == false)
            {
                Style &= ~option;
            }
        }
    }
}