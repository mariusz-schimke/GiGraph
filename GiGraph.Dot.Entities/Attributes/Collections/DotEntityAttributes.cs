using GiGraph.Dot.Entities.Attributes.Enums;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityAttributes : DotAttributeCollection,
        IDotGraphAttributes,
        IDotSubgraphAttributes,
        IDotClusterAttributes,
        IDotNodeAttributes,
        IDotEdgeAttributes
    {
        /// <summary>
        /// Gets or sets the background color of the graph.
        /// </summary>
        public virtual Color? BackgroundColor
        {
            get => TryGet<DotColorAttribute>("bgcolor", out var result) ? result : (Color?)null;
            set => AddOrRemove("bgcolor", value, v => new DotColorAttribute("bgcolor", v.Value));
        }

        /// <summary>
        /// Gets or sets the shape of the node.
        /// </summary>
        public virtual DotNodeShape? Shape
        {
            get => TryGet<DotNodeShapeAttribute>("shape", out var result) ? (DotNodeShape)result : (DotNodeShape?)null;
            set => AddOrRemove("shape", value, v => new DotNodeShapeAttribute("shape", v.Value));
        }

        /// <summary>
        /// Gets or sets the color of the element.
        /// </summary>
        public virtual Color? Color
        {
            get => TryGet<DotColorAttribute>("color", out var result) ? result : (Color?)null;
            set => AddOrRemove("color", value, v => new DotColorAttribute("color", v.Value));
        }

        /// <summary>
        /// Gets or sets the label to display on the element.
        /// </summary>
        public virtual string Label
        {
            get => TryGet<DotStringAttribute>("label", out var result) ? result : (string)null;
            set => AddOrRemove("label", value, v => new DotStringAttribute("label", v));
        }

        /// <summary>
        /// Gets or sets the label in HTML format to display on the element.
        /// <para>
        ///     <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        ///     so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        public virtual string LabelHtml
        {
            get => TryGet<DotHtmlAttribute>("label", out var result) ? (string)result : null;
            set => AddOrRemove("label", value, v => new DotHtmlAttribute("label", v));
        }
    }
}
