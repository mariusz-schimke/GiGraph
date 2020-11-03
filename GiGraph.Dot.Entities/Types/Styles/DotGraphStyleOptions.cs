using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Graph style options.
    /// </summary>
    public class DotGraphStyleOptions : DotClusterStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        public DotGraphStyleOptions()
        {
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
    }
}