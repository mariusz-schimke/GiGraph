using System;
using GiGraph.Dot.Entities.Collections;

namespace GiGraph.Dot.Entities.Graphs.Collections
{
    public class DotCommonGraphCollection<T> : DotEntityWithIdCollection<T>, IDotEntity, IDotAnnotatable
        where T : DotCommonGraph
    {
        protected DotCommonGraphCollection(Func<string, Predicate<T>> matchIdPredicate)
            : base(matchIdPredicate)
        {
        }

        public DotCommonGraphCollection()
            : base(matchIdPredicate: id => subgraph => subgraph.Id == id)
        {
        }

        public virtual string Annotation { get; set; }

        /// <summary>
        ///     Adds a subgraph to the collection and initializes it.
        /// </summary>
        /// <param name="subgraph">
        ///     The subgraph to add.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate.
        /// </param>
        public virtual T Add(T subgraph, Action<T> init)
        {
            Add(subgraph);
            init?.Invoke(subgraph);
            return subgraph;
        }

        /// <summary>
        ///     Gets a subgraphs with the specified identifier from the collection.
        /// </summary>
        public virtual T Get(string id)
        {
            return Find(_matchIdPredicate(id));
        }
    }
}