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
        public virtual bool? Solid { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dashed" /> style option state.
        /// </summary>
        public virtual bool? Dashed { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Dotted" /> style option state.
        /// </summary>
        public virtual bool? Dotted { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Bold" /> style option state.
        /// </summary>
        public virtual bool? Bold { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Invisible" /> style option state.
        /// </summary>
        public virtual bool? Invisible { get; set; }

        protected override void ReadOptions(DotStyles style)
        {
            Solid = style.HasFlag(DotStyles.Solid);
            Dashed = style.HasFlag(DotStyles.Dashed);
            Dotted = style.HasFlag(DotStyles.Dotted);
            Bold = style.HasFlag(DotStyles.Bold);
            Invisible = style.HasFlag(DotStyles.Invisible);
        }

        protected override void WriteOptions(ref DotStyles? style)
        {
            WriteOption(ref style, DotStyles.Solid, Solid);
            WriteOption(ref style, DotStyles.Dashed, Dashed);
            WriteOption(ref style, DotStyles.Dotted, Dotted);
            WriteOption(ref style, DotStyles.Bold, Bold);
            WriteOption(ref style, DotStyles.Invisible, Invisible);
        }
    }
}