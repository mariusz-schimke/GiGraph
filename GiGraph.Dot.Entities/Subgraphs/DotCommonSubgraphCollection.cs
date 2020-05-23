using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public class DotCommonSubgraphCollection : IDotEntity, IEnumerable<DotCommonSubgraph>
    {
        protected readonly List<DotCommonSubgraph> _subgraphs = new List<DotCommonSubgraph>();

        /// <summary>
        /// Adds a subgraph to the collection.
        /// </summary>
        /// <param name="subgraph">The subgraph to add.</param>
        public virtual T Add<T>(T subgraph)
            where T : DotCommonSubgraph
        {
            _subgraphs.Add(subgraph);
            return subgraph;
        }

        /// <summary>
        /// Adds a new cluster subgraph to the collection.
        /// </summary>
        /// <param name="init">An optional initialization delegate.</param>
        public virtual DotCluster AddCluster(Action<DotCluster> init = null)
        {
            return AddCluster(id: null, init);
        }

        /// <summary>
        /// Adds a new cluster subgraph to the collection.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="init">An optional initialization delegate.</param>
        public virtual DotCluster AddCluster(string id, Action<DotCluster> init = null)
        {
            var cluster = Add(new DotCluster(id));
            init?.Invoke(cluster);
            return cluster;
        }

        /// <summary>
        /// Adds a new subgraph to the collection.
        /// </summary>
        /// <param name="init">An optional initialization delegate.</param>
        public virtual DotSubgraph AddSubgraph(Action<DotSubgraph> init = null)
        {
            return DoAddSubgraph(id: null, rank: null, init);
        }

        /// <summary>
        /// Adds a new subgraph to the collection.
        /// </summary>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional initialization delegate.</param>
        public virtual DotSubgraph AddSubgraph(DotRank rank, Action<DotSubgraph> init = null)
        {
            return DoAddSubgraph(id: null, rank, init);
        }

        /// <summary>
        /// Adds a new subgraph to the collection.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        /// <param name="rank">The rank attribute to assign to the subgraph.</param>
        /// <param name="init">An optional initialization delegate.</param>
        public virtual DotSubgraph AddSubgraph(string id, DotRank rank, Action<DotSubgraph> init = null)
        {
            return DoAddSubgraph(id, rank, init);
        }

        protected virtual DotSubgraph DoAddSubgraph(string id, DotRank? rank, Action<DotSubgraph> init)
        {
            var subgraph = Add(new DotSubgraph(id, rank));
            init?.Invoke(subgraph);
            return subgraph;
        }

        /// <summary>
        /// Removes the specified subgraph from the collection if found.
        /// </summary>
        /// <param name="subgraph">The subgraph to remove.</param>
        public virtual int Remove(DotCommonSubgraph subgraph)
        {
            var result = 0;

            while (_subgraphs.Remove(subgraph))
            {
                result++;
            }

            return result;
        }

        /// <summary>
        /// Removes the specified subgraph from the collection if found.
        /// </summary>
        /// <param name="id">The identifier of the subgraph to remove.</param>
        public virtual int Remove(string id)
        {
            return RemoveAll(subgraph => subgraph.Id == id);
        }

        /// <summary>
        /// Removes all subgraphs matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching subgraphs.</param>
        public virtual int RemoveAll(Predicate<DotCommonSubgraph> match)
        {
            return _subgraphs.RemoveAll(match);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public virtual void Clear()
        {
            _subgraphs.Clear();
        }

        public virtual IEnumerator<DotCommonSubgraph> GetEnumerator()
        {
            return ((IEnumerable<DotCommonSubgraph>)_subgraphs).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotCommonSubgraph>)_subgraphs).GetEnumerator();
        }
    }
}
