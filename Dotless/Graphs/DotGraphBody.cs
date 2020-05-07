using Dotless.Edges;
using Dotless.Nodes;

namespace Dotless.Graphs
{
    public abstract class DotGraphBody : DotAttributedEntity
    {
        public DotNodeCollection Nodes { get; } = new DotNodeCollection();
        public DotEdgeCollection Edges { get; } = new DotEdgeCollection();
    }
}
