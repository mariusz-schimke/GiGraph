using GiGraph.Dot.Entities.Collections;
using System;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotCommonSubgraphCollection<T> : DotEntityWithIdCollection<T>, IDotEntity
        where T : DotCommonSubgraph
    {
        protected virtual T Add(T subgraph, Action<T> init)
        {
            Add(subgraph);
            init?.Invoke(subgraph);
            return subgraph;
        }

        /// <summary>
        /// Gets a subgraphs with the specified identifier from the collection.
        /// </summary>
        public virtual T Get(string id)
        {
            var index = IndexOf(id);
            return index >= 0 ? this[index] : null;
        }

        public override int IndexOf(string id)
        {
            return FindIndex(subgraph => subgraph.Id == id);
        }
    }
}
