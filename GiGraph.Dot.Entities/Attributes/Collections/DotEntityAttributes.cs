using GiGraph.Dot.Entities.Attributes.ColorAttributes;
using GiGraph.Dot.Entities.Attributes.LabelAttributes;
using GiGraph.Dot.Entities.Attributes.ShapeAttributes;
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
            get => TryGet<DotBackgroundColorAttribute>(DotBackgroundColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotBackgroundColorAttribute.AttributeKey, value, v => new DotBackgroundColorAttribute(v.Value));
        }

        /// <summary>
        /// Gets or sets the shape of the node.
        /// </summary>
        public virtual DotNodeShape? Shape
        {
            get => TryGet<DotNodeShapeAttribute>(DotNodeShapeAttribute.AttributeKey, out var result) ? (DotNodeShape)result : (DotNodeShape?)null;
            set => AddOrRemove(DotNodeShapeAttribute.AttributeKey, value, v => new DotNodeShapeAttribute(v.Value));
        }

        /// <summary>
        /// Gets or sets the color of the element.
        /// </summary>
        public virtual Color? Color
        {
            get => TryGet<DotColorAttribute>(DotColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotColorAttribute.AttributeKey, value, v => new DotColorAttribute(v.Value));
        }

        /// <summary>
        /// Gets or sets the label to display on the element.
        /// </summary>
        public virtual string Label
        {
            get => TryGet<DotTextLabelAttribute>(DotLabelAttribute.AttributeKey, out var result) ? result : (string)null;
            set => AddOrRemove(DotLabelAttribute.AttributeKey, value, v => new DotTextLabelAttribute(v));
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
            get => TryGet<DotHtmlLabelAttribute>(DotLabelAttribute.AttributeKey, out var result) ? (string)result : null;
            set => AddOrRemove(DotLabelAttribute.AttributeKey, value, v => new DotHtmlLabelAttribute(v));
        }
    }
}
