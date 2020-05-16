using GiGraph.Dot.Entities.Attributes.ColorAttributes;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    /// <summary>
    /// A common collection of attributes assignable to the following types of graph elements:
    /// edges, nodes, and cluster subgraphs.
    /// </summary>
    public abstract class DotCommonEdgeNodeClusterAttributeCollection : DotCommonEdgeNodeGraphClusterAttributeCollection
    {
        /// <summary>
        /// Gets or sets the color of the element.
        /// </summary>
        public virtual Color? Color
        {
            get => TryGet<DotColorAttribute>(DotColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotColorAttribute.AttributeKey, value, v => new DotColorAttribute(v.Value));
        }
    }
}
