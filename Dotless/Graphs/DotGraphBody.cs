using Dotless.Nodes;

namespace Dotless.Graphs
{
    public abstract class DotGraphBody : DotAttributedEntity
    {
        public DotNodeCollection Nodes { get; } = new DotNodeCollection();
    }
}
