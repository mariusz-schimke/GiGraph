﻿using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotGraphAttributes : IDotAttributeCollection
    {
        /// <summary>
        /// Gets or sets the label to display on the graph.
        /// </summary>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the graph.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        string LabelHtml { get; set; }

        /// <summary>
        /// Gets or sets the background color of the graph (default: none).
        /// </summary>
        Color? BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the direction of graph layout (default: <see cref="DotRankDirection.TopToBottom"/>).
        /// </summary>
        DotRankDirection? Layout { get; set; }

        /// <summary>
        /// Sets the style of the graph (default: null). See the descriptions of individual <see cref="DotStyle"/> values
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
