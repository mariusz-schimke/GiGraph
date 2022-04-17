using GiGraph.Dot.Entities.Attributes.Properties.Accessors;

namespace GiGraph.Dot.Entities.Attributes.Properties;

public interface IDotEntityAttributes
{
    /// <summary>
    ///     Gets an accessor that provides access to attributes through property expressions.
    /// </summary>
    DotEntityAttributesAccessor Accessor { get; }
}