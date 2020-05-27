using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotCommonEdge : IDotEntity
    {
        /// <summary>
        /// Gets the attributes of the edge.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        protected DotCommonEdge(IDotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the edge endpoints.
        /// </summary>
        public abstract IEnumerable<DotCommonEndpoint> Endpoints { get; }
    }
}
