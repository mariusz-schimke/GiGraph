namespace GiGraph.Dot.Output.Entities;

public interface IDotGraphSection : IDotEntity
{
    /// <summary>
    ///     Gets the collection of attributes of the graph section.
    /// </summary>
    IDotAttributeCollection Attributes { get; }
}