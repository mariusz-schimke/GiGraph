namespace GiGraph.Dot.Output.Qualities;

public interface IDotOrderable
{
    /// <summary>
    ///     Gets the key by which the entity can be sorted in the output script among elements of the same type.
    /// </summary>
    string? OrderingKey { get; }
}