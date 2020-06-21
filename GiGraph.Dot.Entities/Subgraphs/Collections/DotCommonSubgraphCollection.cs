using GiGraph.Dot.Entities.Collections;
using System;

namespace GiGraph.Dot.Entities.Subgraphs.Collections
{
    public class DotCommonSubgraphCollection<T> : DotEntityWithIdCollection<T>, IDotEntity
        where T : DotCommonSubgraph
    {
        public virtual string Notes { get; set; }
        
        protected DotCommonSubgraphCollection(Func<string, Predicate<T>> matchIdPredicate)
            : base(matchIdPredicate)
        {
        }

        public DotCommonSubgraphCollection()
            : base(matchIdPredicate: id => subgraph => subgraph.Id == id)
        {
        }

        /// <summary>
        /// Adds a subgraph to the collection and initializes it.
        /// </summary>
        /// <param name="subgraph">The subgraph to add.</param>
        /// <param name="init">An optional initializer delegate.</param>
        public virtual T Add(T subgraph, Action<T> init)
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
            return Find(_matchIdPredicate(id));
        }
    }
}
