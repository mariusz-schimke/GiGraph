using Dotless.Attributes;
using Dotless.Core;
using Dotless.Nodes;

namespace Dotless.Graphs
{
    public abstract class DotGraphBody : IDotEntity
    {
        public DotNodeCollection Nodes { get; } = new DotNodeCollection();
        public DotAttributeCollection Attributes { get; } = new DotAttributeCollection();

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
