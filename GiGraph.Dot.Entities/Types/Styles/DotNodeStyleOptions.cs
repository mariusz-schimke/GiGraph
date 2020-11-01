using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Node style options.
    /// </summary>
    public class DotNodeStyleOptions : DotCommonStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        public DotNodeStyleOptions()
        {
        }

        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotNodeStyleOptions(DotStyles style)
            : base(style)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Rounded" /> style option state.
        /// </summary>
        public virtual bool? Rounded { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Diagonals" /> style option state.
        /// </summary>
        public virtual bool? Diagonals { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Filled" /> style option state.
        /// </summary>
        public virtual bool? Filled { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Striped" /> style option state.
        /// </summary>
        public virtual bool? Striped { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Wedged" /> style option state.
        /// </summary>
        public virtual bool? Wedged { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state.
        /// </summary>
        public virtual bool? Radial { get; set; }

        protected override void ReadOptions(DotStyles style)
        {
            base.ReadOptions(style);

            Rounded = style.HasFlag(DotStyles.Rounded);
            Diagonals = style.HasFlag(DotStyles.Diagonals);
            Filled = style.HasFlag(DotStyles.Filled);
            Striped = style.HasFlag(DotStyles.Striped);
            Wedged = style.HasFlag(DotStyles.Wedged);
            Radial = style.HasFlag(DotStyles.Radial);
        }

        protected override void WriteOptions(ref DotStyles? style)
        {
            base.WriteOptions(ref style);

            WriteOption(ref style, DotStyles.Rounded, Rounded);
            WriteOption(ref style, DotStyles.Diagonals, Diagonals);
            WriteOption(ref style, DotStyles.Filled, Filled);
            WriteOption(ref style, DotStyles.Striped, Striped);
            WriteOption(ref style, DotStyles.Wedged, Wedged);
            WriteOption(ref style, DotStyles.Radial, Radial);
        }
    }
}