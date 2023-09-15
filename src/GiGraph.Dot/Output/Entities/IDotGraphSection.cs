using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Entities;

public interface IDotGraphSection : IDotEntity
{
    /// <summary>
    ///     Gets the collection of attributes of the graph section.
    /// </summary>
    DotAttributeCollection GetAttributes(DotSyntaxOptions options);
}