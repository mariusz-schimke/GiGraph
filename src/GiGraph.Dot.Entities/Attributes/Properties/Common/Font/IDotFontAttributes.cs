using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Font
{
    public interface IDotFontAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the font used for text (default: "Times-Roman"). This very much depends on the output format and, for
        ///         non-bitmap output such as PostScript or SVG, the availability of the font when the graph is displayed or printed. As
        ///         such, it is best to rely on font faces that are generally available, such as Times-Roman, Helvetica or Courier.
        ///     </para>
        ///     <para>
        ///         How font names are resolved also depends on the underlying library that handles font name resolution. If Graphviz was
        ///         built using the fontconfig library, the latter library will be used to search for the font. See the commands fc-list,
        ///         fc-match and the other fontconfig commands for how names are resolved and which fonts are available. Other systems may
        ///         provide their own font package, such as Quartz for OS X.
        ///     </para>
        ///     <para>
        ///         Note that various font attributes, such as weight and slant, can be built into the font name. Unfortunately, the syntax
        ///         varies depending on which font system is dominant. Thus, using <see cref="Name" /> = "times bold italic" will produce a
        ///         bold, slanted Times font using Pango, the usual main font library. Alternatively, <see cref="Name" /> = "times:italic"
        ///         will produce a slanted Times font from fontconfig, while <see cref="Name" /> = "times-bold" will resolve to a bold Times
        ///         using Quartz. You will need to ascertain which package is used by your Graphviz system and refer to the relevant
        ///         documentation.
        ///     </para>
        ///     <para>
        ///         If Graphviz is not built with a high-level font library, <see cref="Name" /> will be considered the name of a Type 1 or
        ///         True Type font file. If you specify <see cref="Name" /> = "schlbk", the tool will look for a file named schlbk.ttf or
        ///         schlbk.pfa or schlbk.pfb in one of the directories specified by the <see cref="DotGraphFontAttributes.Directories" />
        ///         attribute of graph <see cref="IDotGraphAttributesRoot.Font" />. The lookup does support various aliases for the common
        ///         fonts.
        ///     </para>
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the font size used for text (in points; 72 points per inch). Default: 14.0, minimum: 1.0.
        /// </summary>
        double? Size { get; set; }

        /// <summary>
        ///     Gets or sets the color used for text (default: <see cref="System.Drawing.Color.Black" />).
        /// </summary>
        DotColor Color { get; set; }
    }
}