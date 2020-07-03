using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotEdgeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotEdgeDefinition(IDotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the attributes of the edge.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        /// <summary>
        ///     Gets the edge endpoints.
        /// </summary>
        public abstract IEnumerable<DotEndpointDefinition> Endpoints { get; }

        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();

        protected abstract string GetOrderingKey();
    }
}