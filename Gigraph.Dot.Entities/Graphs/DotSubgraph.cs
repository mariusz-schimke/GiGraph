namespace Gigraph.Dot.Entities.Graphs
{
    public class DotSubgraph : DotGraphBody
    {
        public virtual string Id { get; set; }
        public virtual bool IsCluster { get; set; } = true;
    }
}
