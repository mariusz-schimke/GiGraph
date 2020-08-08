using GiGraph.Dot.Entities.Attributes.Collections;

namespace GiGraph.Dot.Entities
{
    public interface IDotHasAttributes
    {
        IDotAttributeCollection Attributes { get; }
    }
}