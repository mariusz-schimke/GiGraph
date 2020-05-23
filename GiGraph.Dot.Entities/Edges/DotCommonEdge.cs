using GiGraph.Dot.Entities.Attributes.Collections;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotCommonEdge : IDotEntity
    {
        /// <summary>
        /// The attributes of the edge.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        /// <summary>
        /// Gets the identifiers of nodes of this edge chain.
        /// </summary>
        public abstract IEnumerable<string> NodeIds { get; }

        protected DotCommonEdge(IDotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }
    }
}
