namespace Gigraph.Dot.Entities.Subgraphs
{
    public class DotClusterCollection : DotGenericSubgraphCollection<DotCluster>
    {
        public override int Remove(string id)
        {
            return RemoveAll(subgraph => subgraph.Id == id);
        }
    }
}
