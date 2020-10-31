using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Types.Fonts
{
    /// <summary>
    ///     Font properties.
    /// </summary>
    public class DotFont
    {
        /// <summary>
        ///     Gets or sets font name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets font size.
        /// </summary>
        public double? Size { get; set; }

        /// <summary>
        ///     Gets or sets font color.
        /// </summary>
        public DotColor Color { get; set; }
    }
}