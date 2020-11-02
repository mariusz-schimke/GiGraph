using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Cluster style options.
    /// </summary>
    public class DotClusterStyleOptions : DotCommonStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        public DotClusterStyleOptions()
        {
        }

        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style. 
        /// </param>
        public DotClusterStyleOptions(DotStyles style)
            : base(style)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Rounded" /> style option state.
        /// </summary>
        public virtual bool? Rounded { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Filled" /> style option state.
        /// </summary>
        public virtual bool? Filled { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Striped" /> style option state.
        /// </summary>
        public virtual bool? Striped { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state.
        /// </summary>
        public virtual bool? Radial { get; set; }

        protected override void ReadOptions(DotStyles style)
        {
            base.ReadOptions(style);

            Rounded = style.HasFlag(DotStyles.Rounded);
            Filled = style.HasFlag(DotStyles.Filled);
            Striped = style.HasFlag(DotStyles.Striped);
            Radial = style.HasFlag(DotStyles.Radial);
        }

        protected override void WriteOptions(ref DotStyles? style)
        {
            base.WriteOptions(ref style);

            WriteOption(ref style, DotStyles.Rounded, Rounded);
            WriteOption(ref style, DotStyles.Filled, Filled);
            WriteOption(ref style, DotStyles.Striped, Striped);
            WriteOption(ref style, DotStyles.Radial, Radial);
        }
    }
}