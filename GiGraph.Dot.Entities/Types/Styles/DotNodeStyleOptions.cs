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
        public virtual bool Rounded
        {
            get => _style.HasFlag(DotStyles.Rounded);
            set => SetOption(DotStyles.Rounded, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Diagonals" /> style option state.
        /// </summary>
        public virtual bool Diagonals
        {
            get => _style.HasFlag(DotStyles.Diagonals);
            set => SetOption(DotStyles.Diagonals, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Filled" /> style option state.
        /// </summary>
        public virtual bool Filled
        {
            get => _style.HasFlag(DotStyles.Filled);
            set => SetOption(DotStyles.Filled, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Striped" /> style option state.
        /// </summary>
        public virtual bool Striped
        {
            get => _style.HasFlag(DotStyles.Striped);
            set => SetOption(DotStyles.Striped, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Wedged" /> style option state.
        /// </summary>
        public virtual bool Wedged
        {
            get => _style.HasFlag(DotStyles.Wedged);
            set => SetOption(DotStyles.Wedged, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state.
        /// </summary>
        public virtual bool Radial
        {
            get => _style.HasFlag(DotStyles.Radial);
            set => SetOption(DotStyles.Radial, value);
        }
    }
}