namespace Gigraph.Dot.Entities.Graphs
{
    public class DotSubgraph : DotGraphBody
    {
        public string Id { get; set; }
        public bool IsCluster { get; set; } = true;
    }
}
