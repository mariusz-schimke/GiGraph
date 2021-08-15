using GiGraph.Dot.Entities.Clusters.Attributes;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public interface IDotGraphClusterAttributesRoot : IDotGraphClusterAttributes
    {
        /// <summary>
        ///     Style options. Note that the options are shared with those of the graph.
        /// </summary>
        DotClusterStyleAttributes Style { get; }
    }
}