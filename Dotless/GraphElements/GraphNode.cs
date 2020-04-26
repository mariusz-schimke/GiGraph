using Dotless.Attributes;

namespace Dotless.GraphElements
{
    public class GraphNode : GraphElement
    {
        public string Id { get; set; }

        public GraphNode(string id)
        {
            Id = id;
        }

        public virtual Label? Label
        {
            get => (Label?)Attributes.TryGet<Label>(Label.AttributeKey);
            set
            {
                if (value is null)
                {
                    Attributes.Remove(Label.AttributeKey);
                }
                else
                {
                    Attributes.Include(value);
                }
            }
        }
    }
}
