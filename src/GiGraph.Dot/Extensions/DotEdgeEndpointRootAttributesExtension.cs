using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Extensions;

public static class DotEdgeEndpointRootAttributesExtension
{
    /// <summary>
    ///     <para>
    ///         Sets an arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="IDotEdgeEndpointAttributes.Arrowhead"/> property directly, using
    ///         <see cref="DotArrowhead"/>.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current edge endpoint attributes instance.
    /// </param>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="filled">
    ///     Determines whether to use a filled version of the shape.
    /// </param>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public static T SetArrowhead<T>(
        this T attributes,
        DotArrowheadShape shape = DotArrowheadShape.Normal,
        bool filled = true,
        DotArrowheadParts visibleParts = DotArrowheadParts.Both
    )
        where T : IDotEdgeEndpointRootAttributes
    {
        attributes.Arrowhead = new DotArrowhead(shape, filled, visibleParts);
        return attributes;
    }

    /// <summary>
    ///     <para>
    ///         Sets an empty arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="IDotEdgeEndpointAttributes.Arrowhead"/> property directly, using
    ///         <see cref="DotArrowhead"/>.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current edge endpoint attributes instance.
    /// </param>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public static T SetEmptyArrowhead<T>(
        this T attributes,
        DotArrowheadShape shape = DotArrowheadShape.Normal,
        DotArrowheadParts visibleParts = DotArrowheadParts.Both
    )
        where T : IDotEdgeEndpointRootAttributes =>
        attributes.SetArrowhead(shape, filled: false, visibleParts);

    /// <summary>
    ///     <para>
    ///         Sets a composite arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="IDotEdgeEndpointAttributes.Arrowhead"/> property directly, using
    ///         <see cref="DotCompositeArrowhead"/>.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current edge endpoint attributes instance.
    /// </param>
    /// <param name="arrowheads">
    ///     <para>
    ///         The consecutive arrowheads to use. Note that the first arrowhead specified occurs closest to the node. Subsequent shapes,
    ///         if specified, occur further from the node. Also, a shape of <see cref="DotArrowheadShape.None"/> uses space, so it can be
    ///         used as a separator between two consecutive shapes.
    ///     </para>
    ///     <para>
    ///         For ease of use, you can specify a mix of <see cref="DotArrowhead"/> instances and <see cref="DotArrowheadShape"/> enum
    ///         values as params because they are implicitly convertible to <see cref="DotArrowhead"/>.
    ///     </para>
    /// </param>
    /// <example>
    ///     SetCompositeArrowhead(DotArrowheadShape.Dot, new DotArrowhead(DotArrowheadShape.Vee, filled: false))
    /// </example>
    public static T SetCompositeArrowhead<T>(this T attributes, params DotArrowhead[] arrowheads)
        where T : IDotEdgeEndpointRootAttributes
    {
        attributes.Arrowhead = new DotCompositeArrowhead(arrowheads);
        return attributes;
    }

    /// <summary>
    ///     <para>
    ///         Sets a composite arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="IDotEdgeEndpointAttributes.Arrowhead"/> property directly, using
    ///         <see cref="DotCompositeArrowhead"/>.
    ///     </para>
    /// </summary>
    /// <param name="attributes">
    ///     The current edge endpoint attributes instance.
    /// </param>
    /// <param name="arrowheads">
    ///     The consecutive arrowheads to use. Note that the first arrowhead specified occurs closest to the node. Subsequent shapes, if
    ///     specified, occur further from the node. Also, a shape of <see cref="DotArrowheadShape.None"/> uses space, so it can be used
    ///     as a separator between two consecutive shapes.
    /// </param>
    public static T SetCompositeArrowhead<T>(this T attributes, params DotArrowheadShape[] arrowheads)
        where T : IDotEdgeEndpointRootAttributes
    {
        attributes.Arrowhead = new DotCompositeArrowhead(arrowheads);
        return attributes;
    }
}