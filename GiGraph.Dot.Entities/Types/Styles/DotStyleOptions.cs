using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotStyleOptions
    {
        protected DotStyleOptions(DotStyles style)
        {
            ReadOptions(style);
        }

        protected DotStyleOptions()
        {
        }

        /// <summary>
        ///     Applies the style options to the specified base style and returns the result.
        /// </summary>
        /// <param name="style">
        ///     The base style to apply the options to.
        /// </param>
        public virtual DotStyles? ApplyTo(DotStyles? style)
        {
            WriteOptions(ref style);
            return style;
        }

        /// <summary>
        ///     Returns the options as style flags.
        /// </summary>
        public virtual DotStyles? ToStyle()
        {
            return ApplyTo(null);
        }

        protected abstract void ReadOptions(DotStyles style);
        protected abstract void WriteOptions(ref DotStyles? style);

        protected virtual void WriteOption(ref DotStyles? style, DotStyles option, bool? set)
        {
            if (set.HasValue)
            {
                style ??= DotStyles.Default;
            }

            if (set == true)
            {
                style |= option;
            }
            else if (set == false)
            {
                style &= ~option;
            }
        }
    }
}