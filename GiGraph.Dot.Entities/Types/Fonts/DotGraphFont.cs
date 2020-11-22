using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Types.Fonts
{
    /// <summary>
    ///     Font properties (graph specific).
    /// </summary>
    public class DotGraphFont : DotFont
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
        /// <param name="directories">
        ///     The directory list to search for fonts.
        /// </param>
        public DotGraphFont(string name = null, double? size = null, DotColor color = null, string directories = null)
            : base(name, size, color)
        {
            Directories = directories;
        }

        /// <summary>
        ///     Gets or sets the directory list to search for fonts.
        /// </summary>
        public virtual string Directories { get; set; }
    }
}