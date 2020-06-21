using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotEdgeDefinition : IDotOrderableEntity
    {
        /// <summary>
        /// Gets the attributes of the edge.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        /// <summary>
        /// Gets the edge endpoints.
        /// </summary>
        public abstract IEnumerable<DotEndpointDefinition> Endpoints { get; }

        public virtual string Notes { get; set; }
        
        string IDotOrderableEntity.OrderingKey => GetOrderingKey();

        protected DotEdgeDefinition(IDotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }

        protected abstract string GetOrderingKey();
    }
}