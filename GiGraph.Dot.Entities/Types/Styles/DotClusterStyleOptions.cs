using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Builds cluster style based on options.
    /// </summary>
    public class DotClusterStyleOptions : DotCommonStyleOptions
    {
        protected static readonly DotStyles ClusterStylesMask =
            CommonStylesMask |
            DotStyles.Rounded |
            DotStyles.Filled |
            DotStyles.Striped |
            DotStyles.Radial;

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        public DotClusterStyleOptions()
            : base(ClusterStylesMask)
        {
        }

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotClusterStyleOptions(DotStyles style)
            : base(style, ClusterStylesMask)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Rounded" /> style option state.
        /// </summary>
        public virtual bool? Rounded
        {
            get => GetOption(DotStyles.Rounded);
            set => SetOption(DotStyles.Rounded, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Filled" /> style option state.
        /// </summary>
        public virtual bool? Filled
        {
            get => GetOption(DotStyles.Filled);
            set => SetOption(DotStyles.Filled, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Striped" /> style option state.
        /// </summary>
        public virtual bool? Striped
        {
            get => GetOption(DotStyles.Striped);
            set => SetOption(DotStyles.Striped, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state.
        /// </summary>
        public virtual bool? Radial
        {
            get => GetOption(DotStyles.Radial);
            set => SetOption(DotStyles.Radial, value);
        }
    }
}