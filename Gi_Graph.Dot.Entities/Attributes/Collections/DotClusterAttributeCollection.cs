using GiGraph.Dot.Entities.Attributes.ColorAttributes;
using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    /// <summary>
    /// A collection of attributes assignable to cluster subgraphs.
    /// </summary>
    public class DotClusterAttributeCollection : DotCommonEdgeNodeClusterAttributeCollection
    {
        /// <summary>
        /// Gets or sets the background color of the cluster.
        /// </summary>
        public virtual Color? BackgroundColor
        {
            get => TryGet<DotBackgroundColorAttribute>(DotBackgroundColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotBackgroundColorAttribute.AttributeKey, value, v => new DotBackgroundColorAttribute(v.Value));
        }
    }
}
