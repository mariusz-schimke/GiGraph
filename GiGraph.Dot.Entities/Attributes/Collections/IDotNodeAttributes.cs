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
        /// Gets or sets the color of the node.
        /// </summary>
        Color? Color { get; set; }

        /// <summary>
        /// Gets or sets the shape of the node.
        /// </summary>
        DotNodeShape? Shape { get; set; }
    }
}
