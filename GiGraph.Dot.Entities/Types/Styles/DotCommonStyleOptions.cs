using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotCommonStyleOptions : DotStyleOptions
    {
        protected static readonly DotStyles CommonStylesMask =
            DotStyles.Solid |
            DotStyles.Dashed |
            DotStyles.Dotted |
            DotStyles.Bold |
            DotStyles.Invisible;

        protected DotCommonStyleOptions(DotStyles mask)
            : base(mask)
        {
        }

        protected DotCommonStyleOptions(DotStyles style, DotStyles mask)
            : base(style, mask)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Solid" /> style option state.
        /// </summary>
        public virtual bool? Solid
        {
            get => GetOption(DotStyles.Solid);
            set => SetOption(DotStyles.Solid, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dashed" /> style option state.
        /// </summary>
        public virtual bool? Dashed
        {
            get => GetOption(DotStyles.Dashed);
            set => SetOption(DotStyles.Dashed, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dotted" /> style option state.
        /// </summary>
        public virtual bool? Dotted
        {
            get => GetOption(DotStyles.Dotted);
            set => SetOption(DotStyles.Dotted, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Bold" /> style option state.
        /// </summary>
        public virtual bool? Bold
        {
            get => GetOption(DotStyles.Bold);
            set => SetOption(DotStyles.Bold, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Invisible" /> style option state.
        /// </summary>
        public virtual bool? Invisible
        {
            get => GetOption(DotStyles.Invisible);
            set => SetOption(DotStyles.Invisible, value);
        }
    }
}