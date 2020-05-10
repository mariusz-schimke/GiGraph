using Gigraph.Dot.Entities.Attributes.ColorAttributes;
using System.Drawing;

namespace Gigraph.Dot.Entities.Attributes.Collections
{
    /// <summary>
    /// A collection of attributes assignable to graphs.
    /// </summary>
    public class DotGraphAttributeCollection : DotCommonEdgeNodeGraphClusterAttributeCollection
    {
        /// <summary>
        /// Gets or sets the background color of the graph.
        /// </summary>
        public virtual Color? BackgroundColor
        {
            get => TryGet<DotBackgroundColorAttribute>(DotBackgroundColorAttribute.AttributeKey, out var result) ? (Color)result : (Color?)null;
            set => AddOrRemove(DotBackgroundColorAttribute.AttributeKey, value, v => new DotBackgroundColorAttribute(v.Value));
        }
    }
}
