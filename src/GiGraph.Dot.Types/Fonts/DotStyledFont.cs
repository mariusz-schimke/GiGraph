using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Types.Fonts
{
    /// <summary>
    ///     Font and style properties.
    /// </summary>
    public class DotStyledFont : DotFont
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="name">
        ///     Font name.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        /// <param name="style">
        ///     Font style.
        /// </param>
        public DotStyledFont(string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
            : base(name, size, color)
        {
            Style = style;
        }

        /// <summary>
        ///     Gets or sets font style.
        /// </summary>
        public virtual DotFontStyles? Style { get; set; }
    }
}