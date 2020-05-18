using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotNodeAttributes : IDotAttributeCollection
    {
        /// <summary>
        /// Gets or sets the label to display on the node.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the node.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        string LabelHtml { get; set; }

        /// <summary>
        /// Gets or sets the color of the node (default: <see cref="Color.Black"/>).
        /// </summary>
        Color? Color { get; set; }

        /// <summary>
        /// Gets or sets the color used to fill the background of the node, assuming that <see cref="Style"/> is <see cref="DotStyle.Filled"/>.
        /// If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used. 
        /// If it is not defined too, the default is used, except for <see cref="Shape"/> of <see cref="DotShape.Point"/>,
        /// or when the output format is MIF, which use black by default.
        /// <para>
        ///     If the value is a color list, a gradient fill is used. By default, this is a linear fill; 
        ///     setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        ///     At present, only two colors are used. If the second color is missing, the default color is used for it.
        ///     See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        /// </para>
        /// </summary>
        Color? FillColor { get; set; }

        /// <summary>
        /// If a gradient fill is being used, this determines the angle of the fill. 
        /// For linear fills, the colors transform along a line specified by the angle and the center of the object.
        /// For radial fills, a value of zero causes the colors to transform radially from the center;
        /// for non-zero values, the colors transform from a point near the object's periphery as specified by the value.
        /// If unset, the default angle is 0.
        /// </summary>
        int? GradientAngle { get; set; }

        /// <summary>
        /// Gets or sets the shape of the node (default: <see cref="DotShape.Ellipse"/>).
        /// </summary>
        DotShape? Shape { get; set; }

        /// <summary>
        /// Sets the style of the node (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        /// to learn which styles are applicable to this element type.
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Solid"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }
    }
}
