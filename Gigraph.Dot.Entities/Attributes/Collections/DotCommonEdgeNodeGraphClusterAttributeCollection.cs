using Gigraph.Dot.Entities.Attributes.LabelAttributes;

namespace Gigraph.Dot.Entities.Attributes.Collections
{
    /// <summary>
    /// A common collection of attributes assignable to all types of graph elements except non-cluster subgraphs:
    /// edges, nodes, the root graph, cluster subgraphs.
    /// </summary>
    public abstract class DotCommonEdgeNodeGraphClusterAttributeCollection : DotAttributeCollection
    {
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
        /// <see cref="Label"/> and <see cref="LabelHtml"/> are actually the same attribute in a different format,
        /// so when one is set, the other is replaced.
        /// </para>
        /// </summary>
        public virtual string LabelHtml
        {
            get => TryGet<DotHtmlLabelAttribute>(DotLabelAttribute.AttributeKey, out var result) ? (string)result : null;
            set => AddOrRemove(DotLabelAttribute.AttributeKey, value, v => new DotHtmlLabelAttribute(v));
        }
    }
}
