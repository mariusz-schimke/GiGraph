using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Builds node style based on options.
    /// </summary>
    public class DotNodeStyleOptions : DotCommonStyleOptions
    {
        protected static readonly DotStyles NodeStylesMask =
            CommonStylesMask |
            DotStyles.Rounded |
            DotStyles.Diagonals |
            DotStyles.Filled |
            DotStyles.Striped |
            DotStyles.Wedged |
            DotStyles.Radial;

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        public DotNodeStyleOptions()
            : base(NodeStylesMask)
        {
        }

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotNodeStyleOptions(DotStyles style)
            : base(style, NodeStylesMask)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Rounded" /> state option state.
        /// </summary>
        public virtual bool? Rounded
        {
            get => GetOption(DotStyles.Rounded);
            set => SetOption(DotStyles.Rounded, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Diagonals" /> state option state.
        /// </summary>
        public virtual bool? Diagonals
        {
            get => GetOption(DotStyles.Diagonals);
            set => SetOption(DotStyles.Diagonals, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Filled" /> state option state.
        /// </summary>
        public virtual bool? Filled
        {
            get => GetOption(DotStyles.Filled);
            set => SetOption(DotStyles.Filled, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Striped" /> state option state.
        /// </summary>
        public virtual bool? Striped
        {
            get => GetOption(DotStyles.Striped);
            set => SetOption(DotStyles.Striped, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Wedged" /> state option state.
        /// </summary>
        public virtual bool? Wedged
        {
            get => GetOption(DotStyles.Wedged);
            set => SetOption(DotStyles.Wedged, value);
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> state option state.
        /// </summary>
        public virtual bool? Radial
        {
            get => GetOption(DotStyles.Radial);
            set => SetOption(DotStyles.Radial, value);
        }
    }
}