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
    }
}
