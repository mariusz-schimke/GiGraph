using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Types.Graphs
{
    /// <summary>
    ///     Font properties (graph specific).
    /// </summary>
    /// <param name="Name">
    ///     Font name.
    /// </param>
    /// <param name="Size">
    ///     Font size.
    /// </param>
    /// <param name="Color">
    ///     Font color.
    /// </param>
    /// <param name="Directories">
    ///     The directory list to search for fonts.
    /// </param>
    /// <param name="Convention">
    ///     The font convention to use.
    /// </param>
    public record DotGraphFont(string Name = null, double? Size = null, DotColor Color = null, string Directories = null, DotFontConvention? Convention = null)
        : DotFont(Name, Size, Color)
    {
        /// <summary>
        ///     The directory list to search for fonts.
        /// </summary>
        public virtual string Directories { get; init; } = Directories;

        /// <summary>
        ///     The font convention to use.
        /// </summary>
        public virtual DotFontConvention? Convention { get; init; } = Convention;
    }
}