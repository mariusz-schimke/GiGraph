using GiGraph.Dot.Entities.Attributes.Collections.Graph;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotGraphSubgraphCollection : DotSubgraphCollection
    {
        public DotGraphSubgraphCollection(DotGraphSubgraphAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     Global graph attributes applied to subgraphs.
        /// </summary>
        public virtual DotGraphSubgraphAttributes Attributes { get; }
    }
}