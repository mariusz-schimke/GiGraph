using GiGraph.Dot.Entities.Attributes.Properties.Accessors;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public interface IDotEntityAttributes
    {
        DotEntityAttributesAccessor Accessor { get; }
    }
}