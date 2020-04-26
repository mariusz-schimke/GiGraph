using Dotless.Core;

namespace Dotless.GraphElements
{
    public abstract class GraphElement : IEntity
    {
        public AttributeCollection Attributes { get; } = new AttributeCollection();
    }
}
