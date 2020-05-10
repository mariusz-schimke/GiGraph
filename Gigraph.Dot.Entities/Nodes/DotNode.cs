namespace Gigraph.Dot.Entities.Nodes
{

    public class DotNode : DotAttributedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the node.
        /// </summary>
        public virtual string Id { get; set; }

        protected DotNode()
        {
        }

        /// <summary>
        /// The unique identifier of the node.
        /// </summary>
        /// <param name="id"></param>
        public DotNode(string id)
        {
            Id = id;
        }
    }
}
