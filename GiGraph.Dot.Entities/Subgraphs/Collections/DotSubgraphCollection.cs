using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotSubgraphCollection : DotCommonSubgraphCollection<DotSubgraph>
    {
        /// <summary>
        /// Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(DotRank rank, Action<DotSubgraph> init = null)
        {
            return AddSubgraph(id: null, rank, Enumerable.Empty<string>(), init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="nodeIds">A node identifier collection to initialize the subgraph with.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(DotRank rank, IEnumerable<string> nodeIds, Action<DotSubgraph> init = null)
        {
            return AddSubgraph(id: null, rank, nodeIds, init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="nodeIds">Optional node identifiers to initialize the subgraph with.</param>
        public virtual DotSubgraph Add(DotRank rank, params string[] nodeIds)
        {
            return AddSubgraph(id: null, rank, nodeIds, init: null);
        }

        /// <summary>
        /// Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        /// <param name="nodeIds">Optional node identifiers to initialize the subgraph with.</param>
        public virtual DotSubgraph Add(DotRank rank, Action<DotSubgraph> init, params string[] nodeIds)
        {
            return AddSubgraph(id: null, rank, nodeIds, init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(string id, DotRank rank, Action<DotSubgraph> init = null)
        {
            return AddSubgraph(id, rank, Enumerable.Empty<string>(), init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="nodeIds">A node identifier collection to initialize the subgraph with.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual DotSubgraph Add(string id, DotRank rank, IEnumerable<string> nodeIds, Action<DotSubgraph> init = null)
        {
            return AddSubgraph(id, rank, nodeIds, init);
        }

        /// <summary>
        /// Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="nodeIds">Optional node identifiers to initialize the subgraph with.</param>
        public virtual DotSubgraph Add(string id, DotRank rank, params string[] nodeIds)
        {
            return AddSubgraph(id, rank, nodeIds, init: null);
        }

        /// <summary>
        /// Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        /// <param name="nodeIds">Optional node identifiers to initialize the subgraph with.</param>
        public virtual DotSubgraph Add(string id, DotRank rank, Action<DotSubgraph> init, params string[] nodeIds)
        {
            return AddSubgraph(id, rank, nodeIds, init);
        }

        protected override DotSubgraph AddSubgraph(string id, IEnumerable<string> nodeIds, Action<DotSubgraph> init)
        {
            return AddSubgraph(id, rank: null, nodeIds, init);
        }

        protected virtual DotSubgraph AddSubgraph(string id, DotRank? rank, IEnumerable<string> nodeIds, Action<DotSubgraph> init)
        {
            return Add(DotSubgraph.FromNodes(nodeIds, rank, id), init);
        }
    }
}
