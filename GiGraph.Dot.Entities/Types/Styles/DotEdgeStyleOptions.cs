using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Builds edge style based on options.
    /// </summary>
    public class DotEdgeStyleOptions : DotCommonStyleOptions
    {
        protected static readonly DotStyles EdgeStylesMask = CommonStylesMask | DotStyles.Tapered;

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        public DotEdgeStyleOptions()
            : base(EdgeStylesMask)
        {
        }

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotEdgeStyleOptions(DotStyles style)
            : base(style, EdgeStylesMask)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Tapered" /> style option state.
        /// </summary>
        public virtual bool? Tapered
        {
            get => GetOption(DotStyles.Tapered);
            set => SetOption(DotStyles.Tapered, value);
        }
    }
}