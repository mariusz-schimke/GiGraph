using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotClusterAttributes : IDotAttributeCollection
    {
        /// <summary>
        /// Gets or sets the label to display on the cluster.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the cluster.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        string LabelHtml { get; set; }

        /// <summary>
        /// Gets or sets the color of the cluster (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="DotColorList"/> is used, with no weighted colors in its color collection (<see cref="DotColor"/> items only),
        /// and the <see cref="Style"/> is <see cref="DotStyle.Filled"/>, a linear gradient fill is done using the first two colors.
        /// If weighted colors are present (see <see cref="DotWeightedColor"/>), a degenerate linear gradient fill is done.
        /// This essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight"/> specifying how much of region is filled with each color.
        /// If the <see cref="Style"/> attribute contains the value <see cref="DotStyle.Radial"/>, then a radial gradient fill is done.
        /// These fills work with any shape. For certain shapes, the <see cref="Style"/> attribute can be set to do fills using more than 2 colors
        /// (see <see cref="DotStyle.Striped"/>).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        /// Gets or sets the background color of the cluster (default: none).
        /// Used as the initial background for the cluster. If the <see cref="Style"/> attribute of the cluster
        /// contains the <see cref="DotStyle.Filled"/> style, the cluster's <see cref="FillColor"/> will overlay the background color.
        /// <para>
        /// When <see cref="DotColorList"/> is used, a gradient fill is generated. By default, this is a linear fill;
        /// setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        /// At present, only two colors are used. If the second color is <see cref="System.Drawing.Color.Empty"/>,
        /// the default color is used for it. See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        /// </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the color used to fill the background of the cluster, assuming that <see cref="Style"/> is <see cref="DotStyle.Filled"/>.
        /// If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used. 
        /// If <see cref="Color"/> is not defined, <see cref="BackgroundColor"/> is used.
        /// If it is not defined too, the default is used, except when the output format is MIF, which use black by default.
        /// <para>
        /// When <see cref="DotColorList"/> is used, a gradient fill is generated. By default, this is a linear fill; 
        /// setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        /// At present, only two colors are used. If the second color is missing, the default color is used for it.
        /// See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        /// Note that a cluster inherits the root graph's attributes if defined. 
        /// Thus, if the root graph has defined a fill color (<see cref="IDotGraphAttributes.FillColor"/>), this will override a 
        /// <see cref="Color"/> or <see cref="BackgroundColor"/> attribute set for the cluster.
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
        /// Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges and clusters.
        /// The value is inherited by subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        /// Color used to draw the bounding box around the cluster (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="PenColor"/> is not defined, <see cref="Color"/> is used. If this is not defined, the default is used.
        /// Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a pen color
        /// (<see cref="IDotGraphAttributes.PenColor"/>), this will override a <see cref="Color"/> or <see cref="BackgroundColor"/>
        /// attribute set for the cluster.
        /// </summary>
        Color? PenColor { get; set; }

        /// <summary>
        /// Sets the style of the cluster (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        /// to learn which styles are applicable to this element type.
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Rounded"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }
    }
}