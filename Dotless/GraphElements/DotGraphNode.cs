using Dotless.Attributes;
using Dotless.Core;

namespace Dotless.GraphElements
{
    public class DotGraphNode : IDotEntity
    {
        public string Id { get; set; }

        public DotNodeAttributes Attributes { get; } = new DotNodeAttributes();

        public DotGraphNode(string id)
        {
            Id = id;
        }

        public virtual DotLabel? Label
        {
            get => (DotLabel?)Attributes.TryGet<DotLabel>(DotLabel.AttributeKey);
            set
            {
                if (value is null)
                {
                    Attributes.Remove(DotLabel.AttributeKey);
                }
                else
                {
                    Attributes.Include(value);
                }
            }
        }
    }
}
