using Gigraph.Dot.Entities.Graphs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Subgraphs
{
    public abstract class DotGenericSubgraphCollection<TSubgraph> : IDotEntity, IEnumerable<TSubgraph>
        where TSubgraph : DotGraphBody
    {
        protected readonly List<TSubgraph> _subgraphs = new List<TSubgraph>();

        /// <summary>
        /// Adds a subgraph to the collection.
        /// </summary>
        /// <param name="subgraph">The subgraph to add.</param>
        public virtual TSubgraph Add(TSubgraph subgraph)
        {
            _subgraphs.Add(subgraph);
            return subgraph;
        }

        /// <summary>
        /// Removes the specified subgraph from the collection if found.
        /// </summary>
        /// <param name="subgraph">The subgraph to remove.</param>
        public virtual int Remove(TSubgraph subgraph)
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
        public abstract int Remove(string id);

        /// <summary>
        /// Removes all subgraphs matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching subgraphs.</param>
        public virtual int RemoveAll(Predicate<TSubgraph> match)
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

        public virtual IEnumerator<TSubgraph> GetEnumerator()
        {
            return ((IEnumerable<TSubgraph>)_subgraphs).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TSubgraph>)_subgraphs).GetEnumerator();
        }
    }
}
