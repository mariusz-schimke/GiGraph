namespace Dotless.Nodes
{

    public class DotNode : DotAttributedEntity
    {
        public string Id { get; set; }


        public DotNode(string id)
        {
            Id = id;
        }
    }
}
