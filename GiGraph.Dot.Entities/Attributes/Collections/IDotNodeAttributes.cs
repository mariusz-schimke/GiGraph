using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotNodeAttributes : IDotAttributeCollection
    {
        /// <summary>
        /// Gets or sets the label to display on the node.
        /// It can be plain text, HTML (<see cref="DotLabelHtml"/>) or a record (TODO).
        /// </summary>
        DotLabelString Label { get; set; }

        /// <summary>
        /// Gets or sets the color of the node (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="DotColorList"/> is used, with no weighted colors in its color collection (<see cref="DotColor"/> items only),
        /// and the <see cref="Style"/> is <see cref="DotStyle.Filled"/>, a linear gradient fill is done using the first two colors.
        /// If weighted colors are present (see <see cref="DotWeightedColor"/>), a degenerate linear gradient fill is done.
        /// This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight"/> specifying how much of region is filled with each color.
        /// If the <see cref="Style"/> attribute contains the value <see cref="DotStyle.Radial"/>, then a radial gradient fill is done.
        /// These fills work with any shape. For certain shapes, the <see cref="Style"/> attribute can be set to do fills using more than 2 colors
        /// (see <see cref="DotStyle.Striped"/> and <see cref="DotStyle.Wedged"/>).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        /// <para>
        ///     Gets or sets the color used to fill the background of the node, assuming that <see cref="Style"/> is <see cref="DotStyle.Filled"/>.
        ///     If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used. 
        ///     If it is not defined too, the default is used, except for <see cref="Shape"/> of <see cref="DotShape.Point"/>,
        ///     or when the output format is MIF, which use black by default.
        /// </para>
        /// <para>
        ///     If <see cref="DotColorList"/> is used, a gradient fill is generated. By default, this is a linear fill; 
        ///     setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        ///     At present, only two colors are used. If the second color is missing, the default color is used for it.
        ///     See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        /// </para>
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        /// If a gradient fill is being used, this determines the angle of the fill. 
        /// For linear fills, the colors transform along a line specified by the angle and the center of the object.
        /// For radial fills, a value of zero causes the colors to transform radially from the center;
        /// for non-zero values, the colors transform from a point near the object's periphery as specified by the value.
        /// If unset, the default angle is 0.
        /// </summary>
        int? GradientAngle { get; set; }

        /// <summary>
        /// Specifies the width of the pen, in points, used to draw lines and curves.
        /// The value has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        /// Gets or sets the shape of the node (default: <see cref="DotShape.Ellipse"/>).
        /// </summary>
        DotShape? Shape { get; set; }

        /// <summary>
        /// <para>
        ///     Sets the style of the node (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        ///     to learn which styles are applicable to this element type.
        /// </para>
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Solid"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }

        /// <summary>
        /// Gets or sets the color used for text (default: <see cref="System.Drawing.Color.Black"/>).
        /// </summary>
        Color? FontColor { get; set; }

        /// <summary>
        /// <para>
        ///     Gets or sets the font used for text (default: "Times-Roman"). This very much depends on the output format and,
        ///     for non-bitmap output such as PostScript or SVG, the availability of the font when the graph is displayed or printed.
        ///     As such, it is best to rely on font faces that are generally available, such as Times-Roman, Helvetica or Courier.
        /// </para>
        /// <para>
        ///     How font names are resolved also depends on the underlying library that handles font name resolution.
        ///     If Graphviz was built using the fontconfig library, the latter library will be used to search for the font.
        ///     See the commands fc-list, fc-match and the other fontconfig commands for how names are resolved and which fonts are available.
        ///     Other systems may provide their own font package, such as Quartz for OS X.
        /// </para>
        /// <para>
        ///     Note that various font attributes, such as weight and slant, can be built into the font name.
        ///     Unfortunately, the syntax varies depending on which font system is dominant.
        ///     Thus, using <see cref="FontName"/> = "times bold italic" will produce a bold, slanted Times font using Pango,
        ///     the usual main font library. Alternatively, <see cref="FontName"/> = "times:italic" will produce a slanted Times font
        ///     from fontconfig, while <see cref="FontName"/> = "times-bold" will resolve to a bold Times using Quartz.
        ///     You will need to ascertain which package is used by your Graphviz system and refer to the relevant documentation.
        /// </para>
        /// <para>
        ///     If Graphviz is not built with a high-level font library, <see cref="FontName"/> will be considered the name
        ///     of a Type 1 or True Type font file. If you specify <see cref="FontName"/> = "schlbk", the tool will look
        ///     for a file named schlbk.ttf or schlbk.pfa or schlbk.pfb in one of the directories specified
        ///     by the <see cref="IDotGraphAttributes.FontPath"/> attribute. The lookup does support various aliases for the common fonts.
        /// </para>
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        /// Gets or sets the font size used for text (in points; 72 points per inch). Default: 14.0, minimum: 1.0.
        /// </summary>
        double? FontSize { get; set; }
    }
}