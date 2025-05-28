using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Extensions;

public static partial class DotEdgeEndpointRootAttributesExtension
{
    /// <summary>
    ///     <para>
    ///         Sets a compass point for the current endpoint.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="IDotEdgeEndpointAttributes.Port"/> property directly, using
    ///         <see cref="DotEndpointPort"/>.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current edge endpoint attributes instance.
    /// </param>
    /// <param name="compassPoint">
    ///     Specifies where on the node to attach the end of the edge. In the default case (<see cref="DotCompassPoint.Center"/>), the
    ///     edge is aimed towards the center of the node, and then clipped at the node boundary.
    /// </param>
    /// <remarks>
    ///     A port may be set by calling this method or <see cref="SetPort{T}"/>. Only one of them should be used, as both of them write
    ///     the same attribute.
    /// </remarks>
    public static T SetCompassPoint<T>(this T attributes, DotCompassPoint compassPoint)
        where T : IDotEdgeEndpointRootAttributes
    {
        attributes.Port = new DotEndpointPort(compassPoint);
        return attributes;
    }

    /// <summary>
    ///     <para>
    ///         Sets a port for the current endpoint.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="IDotEdgeEndpointAttributes.Port"/> property directly, using
    ///         <see cref="DotEndpointPort"/>.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current edge endpoint attributes instance.
    /// </param>
    /// <param name="name">
    ///     Determines the edge placement to aim for the specified port. The corresponding node must either have record shape (
    ///     <see cref="DotNodeShape.Record"/>, <see cref="DotNodeShape.RoundedRecord"/>) with one of its fields having the given port
    ///     name, or have an HTML-like label, one of whose components has a PORT attribute set to the specified port name.
    /// </param>
    /// <param name="compassPoint">
    ///     Specifies where on the node to attach the end of the edge. In the default case (<see cref="DotCompassPoint.Center"/>), the
    ///     edge is aimed towards the center of the node, and then clipped at the node boundary.
    /// </param>
    /// <remarks>
    ///     A port may be set by calling this method or <see cref="SetCompassPoint{T}"/>. Only one of them should be used, as both of
    ///     them write the same attribute.
    /// </remarks>
    public static T SetPort<T>(this T attributes, string name, DotCompassPoint? compassPoint = null)
        where T : IDotEdgeEndpointRootAttributes
    {
        attributes.Port = new DotEndpointPort(name, compassPoint);
        return attributes;
    }
}