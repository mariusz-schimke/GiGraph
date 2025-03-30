namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphClustersRootAttributes : IDotGraphClustersAttributes
{
    /// <summary>
    ///     Style attributes.
    /// </summary>
    DotGraphClustersStyleAttributes Style { get; }
}