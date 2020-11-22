using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Types.Fonts
{
    /// <summary>
    ///     Font properties.
    /// </summary>
    public class DotFont
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
        public DotFont(string name = null, double? size = null, DotColor color = null)
        {
            Name = name;
            Size = size;
            Color = color;
        }

        /// <summary>
        ///     Gets or sets font name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     Gets or sets font size.
        /// </summary>
        public virtual double? Size { get; set; }

        /// <summary>
        ///     Gets or sets font color.
        /// </summary>
        public virtual DotColor Color { get; set; }
    }
}