using Dotless.Attributes;
using Dotless.Core;

namespace Dotless.Nodes
{
    public class DotNode : IDotEntity
    {
        public string Id { get; set; }

        public DotAttributeCollection Attributes { get; } = new DotAttributeCollection();

        public DotNode(string id)
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
                    Attributes.SetAttribute(value);
                }
            }
        }
    }
}
