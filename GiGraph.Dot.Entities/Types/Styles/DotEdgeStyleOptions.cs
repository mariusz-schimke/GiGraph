using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Edge style options.
    /// </summary>
    public class DotEdgeStyleOptions : DotCommonStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        public DotEdgeStyleOptions()
        {
        }

        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotEdgeStyleOptions(DotStyles style)
            : base(style)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Tapered" /> style option state.
        /// </summary>
        public virtual bool? Tapered { get; set; }

        protected override void ReadOptions(DotStyles style)
        {
            base.ReadOptions(style);
            Tapered = style.HasFlag(DotStyles.Tapered);
        }

        protected override void WriteOptions(ref DotStyles? style)
        {
            base.WriteOptions(ref style);
            WriteOption(ref style, DotStyles.Tapered, Tapered);
        }
    }
}