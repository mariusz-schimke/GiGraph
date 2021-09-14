using System;
using System.Collections.Generic;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Graphs.Collections
{
    public class DotCommonGraphCollection<TGraph> : List<TGraph>, IDotEntity, IDotAnnotatable
        where TGraph : IDotGraph
    {
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
            init?.Invoke(graph);
            Add(graph);
            return graph;
        }
    }
}