using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public class DotCommonSubgraphCollection : IDotEntity, ICollection<DotCommonSubgraph>
    {
        protected readonly List<DotCommonSubgraph> _subgraphs = new List<DotCommonSubgraph>();

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public virtual int Count => _subgraphs.Count;

        bool ICollection<DotCommonSubgraph>.IsReadOnly => ((ICollection<DotCommonSubgraph>)_subgraphs).IsReadOnly;

        /// <summary>
        /// Adds a subgraph to the collection.
        /// </summary>
        /// <typeparam name="T">The type of subgraph added.</typeparam>
        /// <param name="subgraph">The subgraph to add.</param>
        public virtual T Add<T>(T subgraph)
            where T : DotCommonSubgraph
        {
            _subgraphs.Add(subgraph);
            return subgraph;
        }

        void ICollection<DotCommonSubgraph>.Add(DotCommonSubgraph item)
        {
            Add(item);
        }

        /// <summary>
        /// Adds the specified subgraphs to the collection.
        /// </summary>
        /// <param name="subgraphs">The subgraphs to add.</param>
        public virtual void AddRange(IEnumerable<DotCommonSubgraph> subgraphs)
        {
            _subgraphs.AddRange(subgraphs);
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
        /// <param name="id">The unique identifier of the cluster. If no identifier is specified for multiple clusters,
        /// they will be treated as one cluster when visualized.</param>
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
        /// Gets a subgraphs with the specified identifier from the collection.
        /// </summary>
        public virtual DotCommonSubgraph Get(string id)
        {
            return _subgraphs.FirstOrDefault(subgraph => subgraph.Id == id);
        }

        /// <summary>
        /// Gets all subgraphs of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of subgraphs to get.</typeparam>
        public virtual IEnumerable<T> GetAll<T>()
            where T : DotCommonSubgraph
        {
            return _subgraphs.Where(subgraph => subgraph is T).Cast<T>();
        }

        /// <summary>
        /// Gets all clusters from the collection.
        /// </summary>
        public virtual IEnumerable<DotCluster> GetClusters()
        {
            return GetAll<DotCluster>();
        }

        /// <summary>
        /// Gets all subgraphs from the collection.
        /// </summary>
        public virtual IEnumerable<DotSubgraph> GetSubgraphs()
        {
            return GetAll<DotSubgraph>();
        }

        /// <summary>
        /// Determines whether the specified subgraph is in the collection.
        /// </summary>
        /// <param name="item">The subgraph to locate in the collection.</param>
        public virtual bool Contains(DotCommonSubgraph item)
        {
            return _subgraphs.Contains(item);
        }

        /// <summary>
        /// Determines whether the specified subgraph is in the collection.
        /// </summary>
        /// <param name="id">The identifier of the subgraph to locate in the collection.</param>
        public virtual bool Contains(string id)
        {
            return _subgraphs.Any(subgraph => subgraph.Id == id);
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

        bool ICollection<DotCommonSubgraph>.Remove(DotCommonSubgraph item)
        {
            return Remove(item) > 0;
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
        /// Removes all clusters from the collection.
        /// </summary>
        public virtual int RemoveClusters()
        {
            return RemoveAll(s => s is DotCluster);
        }

        /// <summary>
        /// Removes all subgraphs from the collection.
        /// </summary>
        public virtual int RemoveSubgraphs()
        {
            return RemoveAll(s => s is DotSubgraph);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public virtual void Clear()
        {
            _subgraphs.Clear();
        }

        public virtual void CopyTo(DotCommonSubgraph[] array, int arrayIndex)
        {
            _subgraphs.CopyTo(array, arrayIndex);
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
