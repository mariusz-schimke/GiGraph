namespace Gigraph.Dot.Entities.Nodes
{

    public class DotNode : DotAttributedEntity
    {
        public virtual string Id { get; set; }

        public DotNode(string id)
        {
            Id = id;
        }
    }
}
