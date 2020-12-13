using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs.Collections;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotSubgraphCollection : DotCommonGraphCollection<DotSubgraph>
    {
        /// <summary>
        ///     Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="init">
        ///     An optional subgraph initialization delegate.
        /// </param>
        public virtual DotSubgraph Add(Action<DotSubgraph> init = null)
        {
            return AddSubgraph(nodeIds: Enumerable.Empty<string>(), init: init);
        }

        /// <summary>
        ///     Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="nodeIds">
        ///     Optional node identifiers to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(params string[] nodeIds)
        {
            return AddSubgraph(nodeIds);
        }

        /// <summary>
        ///     Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     Optional node identifiers to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(DotRank? rank, params string[] nodeIds)
        {
            return AddSubgraph(nodeIds, rank: rank);
        }

        /// <summary>
        ///     Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     Optional node identifiers to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(string id, DotRank? rank, params string[] nodeIds)
        {
            return AddSubgraph(nodeIds, id, rank);
        }

        /// <summary>
        ///     Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="nodeIds">
        ///     A node identifier collection to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(IEnumerable<string> nodeIds)
        {
            return AddSubgraph(nodeIds);
        }

        /// <summary>
        ///     Adds a new subgraph with the specified rank to the collection, and returns it.
        /// </summary>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     A node identifier collection to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(DotRank? rank, IEnumerable<string> nodeIds)
        {
            return AddSubgraph(nodeIds, rank: rank);
        }

        /// <summary>
        ///     Adds a new subgraph with the specified identifier and rank to the collection, and returns it.
        /// </summary>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     A node identifier collection to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(string id, DotRank? rank, IEnumerable<string> nodeIds)
        {
            return AddSubgraph(nodeIds, id, rank);
        }

        /// <summary>
        ///     Adds a new subgraph with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     A node identifier collection to populate the subgraph with.
        /// </param>
        public virtual DotSubgraph Add(string id, IEnumerable<string> nodeIds)
        {
            return AddSubgraph(nodeIds, id);
        }

        protected virtual DotSubgraph AddSubgraph(IEnumerable<string> nodeIds, string id = null, DotRank? rank = null, Action<DotSubgraph> init = null)
        {
            return Add(DotSubgraph.FromNodes(nodeIds, rank, id), init);
        }
    }
}