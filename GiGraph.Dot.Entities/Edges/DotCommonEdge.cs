using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Elements;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotCommonEdge : IDotEntity
    {
        /// <summary>
        /// The attributes of the edge or the edge chain.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        protected DotCommonEdge(IDotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// Gets the elements (head(s) and tail(s)) of this edge.
        /// </summary>
        protected abstract IEnumerable<DotEdgeElement> GetElements();
    }
}
