using System;
using GiGraph.Dot.Entities.Collections;

namespace GiGraph.Dot.Entities.Graphs.Collections
{
    public class DotCommonGraphCollection<TGraph> : DotEntityWithIdCollection<TGraph>, IDotEntity, IDotAnnotatable
        where TGraph : IDotCommonGraph
    {
        protected DotCommonGraphCollection(Func<string, Predicate<TGraph>> matchIdPredicate)
            : base(matchIdPredicate)
        {
        }

        public DotCommonGraphCollection()
            : base(matchIdPredicate: id => graph => graph.Id == id)
        {
        }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
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
        public virtual TGraph Add(TGraph graph, Action<TGraph> init)
        {
            Add(graph);
            init?.Invoke(graph);
            return graph;
        }

        /// <summary>
        ///     Gets a graph with the specified identifier from the collection.
        /// </summary>
        public virtual TGraph Get(string id)
        {
            return Find(_matchIdPredicate(id));
        }
    }
}