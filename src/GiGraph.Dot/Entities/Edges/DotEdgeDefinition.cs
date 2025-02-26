﻿using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges;

public abstract partial class DotEdgeDefinition : IDotEntity, IDotAnnotatable, IDotOrderable
{
    protected DotEdgeDefinition(DotEndpointDefinition[] endpoints, DotEdgeRootAttributes attributes)
    {
        Endpoints = endpoints is null
            ? throw new ArgumentNullException(nameof(endpoints), "Endpoint collection must not be null.")
            : endpoints.Length > 1
                ? endpoints
                : throw new ArgumentException("At least a pair of endpoints has to be specified.", nameof(endpoints));

        Attributes = new DotEntityRootAttributesAccessor<IDotEdgeAttributes, DotEdgeRootAttributes>(attributes);
    }

    /// <summary>
    ///     Provides access to the attributes of the edge.
    /// </summary>
    public DotEntityRootAttributesAccessor<IDotEdgeAttributes, DotEdgeRootAttributes> Attributes { get; }

    /// <summary>
    ///     Gets the endpoints of the edge.
    /// </summary>
    public DotEndpointDefinition[] Endpoints { get; }

    /// <inheritdoc cref="IDotAnnotatable.Annotation" />
    public virtual string? Annotation { get; set; }

    string IDotOrderable.OrderingKey => GetOrderingKey();

    protected abstract string GetOrderingKey();
}