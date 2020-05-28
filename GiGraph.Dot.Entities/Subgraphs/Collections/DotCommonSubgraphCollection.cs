using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public abstract class DotCommonSubgraphCollection<T> : IDotEntity, ICollection<T>
        where T : DotCommonSubgraph
    {
        protected readonly List<T> _subgraphs = new List<T>();

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public virtual int Count => _subgraphs.Count;

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)_subgraphs).IsReadOnly;

        /// <summary>
        /// Adds a subgraph to the collection.
        /// </summary>
        /// <param name="subgraph">The subgraph to add.</param>
        public virtual T Add(T subgraph)
        {
            return Add(subgraph, init: null);
        }

        protected virtual T Add(T subgraph, Action<T> init)
        {
            _subgraphs.Add(subgraph);
            init?.Invoke(subgraph);
            return subgraph;
        }

        void ICollection<T>.Add(T item)
        {
            Add(item);
        }

        /// <summary>
        /// Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="nodeIds">Optional node identifiers to initialize the subgraph with.</param>
        public virtual T Add(params string[] nodeIds)
        {
            return AddSubgraph(id: null, nodeIds, init: null);
        }

        /// <summary>
        /// Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        /// <param name="nodeIds">Optional node identifiers to initialize the subgraph with.</param>
        public virtual T Add(Action<T> init, params string[] nodeIds)
        {
            return AddSubgraph(id: null, nodeIds, init);
        }

        /// <summary>
        /// Adds a new subgraph to the collection, and returns it.
        /// </summary>
        /// <param name="nodeIds">A node identifier collection to initialize the subgraph with.</param>
        /// <param name="init">An optional subgraph initialization delegate.</param>
        public virtual T Add(IEnumerable<string> nodeIds, Action<T> init = null)
        {
            return AddSubgraph(id: null, nodeIds, init);
        }

        protected abstract T AddSubgraph(string id, IEnumerable<string> nodeIds, Action<T> init);

        /// <summary>
        /// Adds the specified subgraphs to the collection.
        /// </summary>
        /// <param name="subgraphs">The subgraphs to add.</param>
        public virtual void AddRange(IEnumerable<T> subgraphs)
        {
            _subgraphs.AddRange(subgraphs);
        }

        /// <summary>
        /// Gets a subgraphs with the specified identifier from the collection.
        /// </summary>
        public virtual T Get(string id)
        {
            return _subgraphs.FirstOrDefault(subgraph => subgraph.Id == id);
        }

        /// <summary>
        /// Determines whether the specified subgraph is in the collection.
        /// </summary>
        /// <param name="item">The subgraph to locate in the collection.</param>
        public virtual bool Contains(T item)
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
        public virtual int Remove(T subgraph)
        {
            var result = 0;

            while (_subgraphs.Remove(subgraph))
            {
                result++;
            }

            return result;
        }

        bool ICollection<T>.Remove(T item)
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
        public virtual int RemoveAll(Predicate<T> match)
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

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            _subgraphs.CopyTo(array, arrayIndex);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_subgraphs).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_subgraphs).GetEnumerator();
        }
    }
}
