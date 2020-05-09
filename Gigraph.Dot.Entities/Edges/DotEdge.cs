namespace Gigraph.Dot.Entities.Edges
{
    public class DotEdge : DotAttributedEntity
    {
        public string LeftNodeId { get; set; }
        public string RightNodeId { get; set; }

        public DotEdge(string leftNodeId, string rightNodeId)
        {
            LeftNodeId = leftNodeId;
            RightNodeId = rightNodeId;
        }
    }
}
