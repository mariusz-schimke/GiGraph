using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotCommonStyleOptions : DotStyleOptions
    {
        protected DotCommonStyleOptions(DotStyles style)
            : base(style)
        {
        }

        protected DotCommonStyleOptions()
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Solid" /> style option state.
        /// </summary>
        public virtual bool Solid
        {
            get => _style.HasFlag(DotStyles.Solid);
            set => SetOption(DotStyles.Solid, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dashed" /> style option state.
        /// </summary>
        public virtual bool Dashed
        {
            get => _style.HasFlag(DotStyles.Dashed);
            set => SetOption(DotStyles.Dashed, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dotted" /> style option state.
        /// </summary>
        public virtual bool Dotted
        {
            get => _style.HasFlag(DotStyles.Dotted);
            set => SetOption(DotStyles.Dotted, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Bold" /> style option state.
        /// </summary>
        public virtual bool Bold
        {
            get => _style.HasFlag(DotStyles.Bold);
            set => SetOption(DotStyles.Bold, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Invisible" /> style option state.
        /// </summary>
        public virtual bool Invisible
        {
            get => _style.HasFlag(DotStyles.Invisible);
            set => SetOption(DotStyles.Invisible, value);
        }
    }
}