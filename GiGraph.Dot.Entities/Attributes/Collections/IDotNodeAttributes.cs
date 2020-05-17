﻿using GiGraph.Dot.Entities.Attributes.Enums;
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
