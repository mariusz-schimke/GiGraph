using GiGraph.Dot.Entities.Attributes.Collections;

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