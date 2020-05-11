using System;
using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Subgraphs
{
    public class DotCommonSubgraphCollection : IDotEntity, IEnumerable<DotCommonSubgraph>
    {
        protected readonly List<DotCommonSubgraph> _subgraphs = new List<DotCommonSubgraph>();

        /// <summary>
        /// Adds a subgraph to the collection.
        /// </summary>
        /// <param name="subgraph">The subgraph to add.</param>
        public virtual DotCommonSubgraph Add(DotCommonSubgraph subgraph)
        {
            _subgraphs.Add(subgraph);
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
        public int Remove(string id)
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
