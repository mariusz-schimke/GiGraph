using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

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
        /// Gets or sets the color of the cluster (default: <see cref="Color.Black"/>).
        /// </summary>
        Color? Color { get; set; }

        /// <summary>
        /// Gets or sets the color used to fill the background of the cluster, assuming that <see cref="Style"/> is <see cref="DotStyle.Filled"/>.
        /// If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used. 
        /// If <see cref="Color"/> is not defined, <see cref="BackgroundColor"/> is used.
        /// If it is not defined too, the default is used, except when the output format is MIF, which use black by default.
        /// <para>
        ///     If the value is a color list, a gradient fill is used. By default, this is a linear fill; 
        ///     setting <see cref="Style"/> to <see cref="DotStyle.Radial"/> will cause a radial fill.
        ///     At present, only two colors are used. If the second color is missing, the default color is used for it.
        ///     See also the <see cref="GradientAngle"/> attribute for setting the gradient angle.
        ///     Note that a cluster inherits the root graph's attributes if defined. 
        ///     Thus, if the root graph has defined a fillcolor, this will override a 
        ///     <see cref="Color"/> or <see cref="BackgroundColor"/> attribute set for the cluster.
        /// </para>
        /// </summary>
        Color? FillColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the cluster (default: none).
        /// </summary>
        Color? BackgroundColor { get; set; }

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
