using GiGraph.Dot.Entities.Attributes.Enums;
using System;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotSubgraphCollection : DotCommonSubgraphCollection<DotSubgraph>
    {
        /// <summary>
        /// Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(Action<DotSubgraph> init = null)
        {
            return DoAddSubgraph(id: null, rank: null, init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(DotRank rank, Action<DotSubgraph> init = null)
        {
            return DoAddSubgraph(id: null, rank, init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(string id, DotRank rank, Action<DotSubgraph> init = null)
        {
            return DoAddSubgraph(id, rank, init);
        }

        protected virtual DotSubgraph DoAddSubgraph(string id, DotRank? rank, Action<DotSubgraph> init)
        {
            return Add(new DotSubgraph(id, rank), init);
        }
    }
}
