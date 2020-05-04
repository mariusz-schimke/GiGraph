using Dotless.Attributes;
using Dotless.Core;
using Dotless.Nodes;

namespace Dotless.Graphs
{
    public abstract class DotGraphBody : IDotEntity
    {
        public DotNodeCollection Nodes { get; } = new DotNodeCollection();
        public DotAttributeCollection Attributes { get; } = new DotAttributeCollection();
    }
}
