using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphFontAttributes : IDotFontAttributes
    {
        /// <summary>
        ///     Gets or sets the directory list used by libgd to search for bitmap fonts if Graphviz was not built with the fontconfig
        ///     library. If <see cref="Directories" /> is not set, the environment variable DOTFONTPATH is checked. If that is not set,
        ///     GDFONTPATH is checked. If not set, libgd uses its compiled-in font path. The default path is system dependent.
        /// </summary>
        string Directories { get; set; }

        /// <summary>
        ///     Allows user control of how basic font names are represented in SVG output (svg only; default:
        ///     <see cref="DotFontConvention.Svg" />).
        /// </summary>
        DotFontConvention? Convention { get; set; }
    }
}