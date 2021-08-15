﻿using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract partial class DotEdgeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
    {
        protected DotEdgeDefinition(DotEdgeRootAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the attributes of the edge.
        /// </summary>
        public virtual DotEdgeRootAttributes Attributes { get; }

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