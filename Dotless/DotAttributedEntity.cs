using Dotless.Attributes;
using Dotless.Core;

namespace Dotless
{
    public abstract class DotAttributedEntity : IDotEntity
    {
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
