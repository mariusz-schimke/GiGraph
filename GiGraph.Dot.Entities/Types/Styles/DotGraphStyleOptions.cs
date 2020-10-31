using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Builds graph style based on options.
    /// </summary>
    public class DotGraphStyleOptions : DotStyleOptions
    {
        protected static readonly DotStyles GraphStylesMask = DotStyles.Radial;

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        /// <param name="radial">
        ///     The <see cref="DotStyles.Radial" /> style option state. This option is applied to graph, and is inherited by clusters.
        /// </param>
        public DotGraphStyleOptions(bool? radial = null)
            : base(GraphStylesMask)
        {
            Radial = radial;
        }

        /// <summary>
        ///     Creates and initializes a new builder instance.
        /// </summary>
        /// <param name="style">
        ///     The initial style.
        /// </param>
        public DotGraphStyleOptions(DotStyles style)
            : base(style, GraphStylesMask)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state. This option is applied to graph, and is inherited by
        ///     clusters.
        /// </summary>
        public virtual bool? Radial
        {
            get => GetOption(DotStyles.Radial);
            set => SetOption(DotStyles.Radial, value);
        }
    }
}