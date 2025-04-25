using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

public abstract partial class DotEdgeEndpointAttributes
{
    /// <summary>
    ///     <para>
    ///         Sets an arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="Arrowhead"/> property directly, using <see cref="DotArrowhead"/>.
    ///     </para>
    /// </summary>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="filled">
    ///     Determines whether to use a filled version of the shape.
    /// </param>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public void SetArrowhead(DotArrowheadShape shape, bool filled = true, DotArrowheadParts visibleParts = DotArrowheadParts.Both)
    {
        Arrowhead = new DotArrowhead(shape, filled, visibleParts);
    }

    /// <summary>
    ///     <para>
    ///         Sets a composite arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="Arrowhead"/> property directly, using <see cref="DotCompositeArrowhead"/>.
    ///     </para>
    /// </summary>
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
    public void SetCompositeArrowhead(params IEnumerable<DotArrowhead> arrowheads)
    {
        Arrowhead = new DotCompositeArrowhead(arrowheads);
    }

    /// <summary>
    ///     <para>
    ///         Sets a composite arrowhead shape to be used at the current end of the edge.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="Arrowhead"/> property directly, using <see cref="DotCompositeArrowhead"/>.
    ///     </para>
    /// </summary>
    /// <param name="arrowheads">
    ///     The consecutive arrowheads to use. Note that the first arrowhead specified occurs closest to the node. Subsequent shapes, if
    ///     specified, occur further from the node. Also, a shape of <see cref="DotArrowheadShape.None"/> uses space, so it can be used
    ///     as a separator between two consecutive shapes.
    /// </param>
    public void SetCompositeArrowhead(params IEnumerable<DotArrowheadShape> arrowheads)
    {
        Arrowhead = new DotCompositeArrowhead(arrowheads);
    }
}