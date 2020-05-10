using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Nodes;

namespace Gigraph.Dot.Entities.Graphs
{
    public abstract class DotGraphBody : DotAttributedEntity
    {
        public virtual DotNodeCollection Nodes { get; } = new DotNodeCollection();
        public virtual DotEdgeCollection Edges { get; } = new DotEdgeCollection();
    }
}
