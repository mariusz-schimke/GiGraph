using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public partial class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        /// <summary>
        /// Adds a sequence of edges that join consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdgeSequence AddSequence(params string[] nodeIds)
        {
            return AddSequence(nodeIds, initEdge: null);
        }

        /// <summary>
        /// Adds a sequence of edges that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdgeSequence AddSequence(Action<IDotEdgeAttributes> initEdge, params string[] nodeIds)
        {
            return AddSequence(nodeIds, initEdge);
        }

        /// <summary>
        /// Adds a sequence of edges that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotEdgeSequence AddSequence(IEnumerable<string> nodeIds, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(DotEdgeSequence.FromNodes(nodeIds), initEdge);
        }
    }
}
