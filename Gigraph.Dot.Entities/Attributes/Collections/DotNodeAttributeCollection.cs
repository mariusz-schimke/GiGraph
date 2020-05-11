using Gigraph.Dot.Entities.Attributes.ShapeAttributes;

namespace Gigraph.Dot.Entities.Attributes.Collections
{
    /// <summary>
    /// A collection of attributes assignable to nodes.
    /// </summary>
    public class DotNodeAttributeCollection : DotCommonEdgeNodeClusterAttributeCollection
    {
        /// <summary>
        /// Gets or sets the shape of the node.
        /// </summary>
        public virtual DotNodeShape? Shape
        {
            get => TryGet<DotNodeShapeAttribute>(DotNodeShapeAttribute.AttributeKey, out var result) ? (DotNodeShape)result : (DotNodeShape?)null;
            set => AddOrRemove(DotNodeShapeAttribute.AttributeKey, value, v => new DotNodeShapeAttribute(v.Value));
        }
    }
}
