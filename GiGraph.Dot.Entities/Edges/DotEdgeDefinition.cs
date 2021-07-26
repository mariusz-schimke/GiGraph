using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotEdgeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotEdgeDefinition(DotEdgeAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the attributes of the edge.
        /// </summary>
        public virtual DotEdgeAttributes Attributes { get; }

        /// <summary>
        ///     Gets the endpoints of the edge.
        /// </summary>
        public abstract DotEndpointDefinition[] Endpoints { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        string IDotOrderable.OrderingKey => GetOrderingKey();

        protected abstract string GetOrderingKey();
    }
}