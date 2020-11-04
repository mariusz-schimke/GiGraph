using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Graph style options.
    /// </summary>
    public class DotGraphStyleOptions : DotStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="radial">
        ///     The <see cref="DotStyles.Radial" /> style option state. This option is applied to graph, and is inherited by clusters.
        /// </param>
        public DotGraphStyleOptions(bool? radial = null)
        {
            Radial = radial;
        }

        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotGraphStyleOptions(DotStyles style)
            : base(style)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state. This option is applied to graph, and is inherited by
        ///     clusters.
        /// </summary>
        public virtual bool? Radial { get; set; }

        protected override void ReadOptions(DotStyles style)
        {
            Radial = style.HasFlag(DotStyles.Radial);
        }

        protected override void WriteOptions(ref DotStyles? style)
        {
            WriteOption(ref style, DotStyles.Radial, Radial);
        }
    }
}