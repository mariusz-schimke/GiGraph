using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Graphs
{
    public interface IDotCommonGraphSection : IDotEntity
    {
        /// <summary>
        ///     Gets the collection of attributes of the section.
        /// </summary>
        DotAttributeCollection Attributes { get; }
    }
}