using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotStyleOptions
    {
        protected DotStyles _style;

        protected DotStyleOptions(DotStyles style)
        {
            _style = style;
        }

        protected DotStyleOptions()
            : this(DotStyles.Default)
        {
        }

        /// <summary>
        ///     Returns the options as style flags.
        /// </summary>
        public virtual DotStyles ToStyle()
        {
            return _style;
        }

        protected virtual void SetOption(DotStyles option, bool set)
        {
            if (set)
            {
                _style |= option;
            }
            else
            {
                _style &= ~option;
            }
        }
    }
}