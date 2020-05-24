using GiGraph.Dot.Entities.Attributes.Collections;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotCommonEdge : IDotEntityWithIds
    {
        /// <summary>
        /// The attributes of the edge or the edge chain.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        IEnumerable<string> IDotEntityWithIds.Ids => GetNodeIds();

        protected DotCommonEdge(IDotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the identifiers of the nodes of this edge or edge chain.
        /// </summary>
        protected abstract IEnumerable<string> GetNodeIds();
    }
}
