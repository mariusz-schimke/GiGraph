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
            : base(matchIdPredicate: id => graph => graph.Id == id)
        {
        }

        public virtual string Annotation { get; set; }

        /// <summary>
        ///     Adds a graph to the collection and initializes it.
        /// </summary>
        /// <param name="graph">
        ///     The graph to add.
        /// </param>
        /// <param name="init">
        ///     An optional graph initializer delegate.
        /// </param>
        public virtual T Add(T graph, Action<T> init)
        {
            Add(graph);
            init?.Invoke(graph);
            return graph;
        }

        /// <summary>
        ///     Gets a graph with the specified identifier from the collection.
        /// </summary>
        public virtual T Get(string id)
        {
            return Find(_matchIdPredicate(id));
        }
    }
}