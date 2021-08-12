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
        /// <param name="style">
        ///     Font style.
        /// </param>
        /// <param name="name">
        ///     Font name.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        public DotStyledFont(DotFontStyles? style = null, string name = null, double? size = null, DotColor color = null)
            : base(name, size, color)
        {
            Style = style;
        }

        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="style">
        ///     Font style.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        public DotStyledFont(DotFontStyles? style, double? size, DotColor color = null)
            : this(style, name: null, size, color)
        {
        }

        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="style">
        ///     Font style.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        /// <param name="name">
        ///     Font name.
        /// </param>
        public DotStyledFont(DotFontStyles? style, DotColor color, string name = null)
            : this(style, name, size: null, color)
        {
        }

        /// <summary>
        ///     Gets or sets font style.
        /// </summary>
        public virtual DotFontStyles? Style { get; set; }
    }
}