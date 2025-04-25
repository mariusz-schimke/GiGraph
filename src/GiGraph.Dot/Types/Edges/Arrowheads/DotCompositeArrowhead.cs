using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Arrowheads;

/// <summary>
///     Defines an arrowhead composed of multiple shapes.
/// </summary>
public class DotCompositeArrowhead : DotArrowheadDefinition
{
    /// <summary>
    ///     Defines an arrowhead composed of multiple shapes.
    /// </summary>
    /// <param name="arrowheads">
    ///     <para>
    ///         The consecutive arrowheads to use. Note that the first arrowhead specified occurs closest to the node. Subsequent shapes,
    ///         if specified, occur further from the node. Also, a shape of <see cref="DotArrowheadShape.None"/> uses space, so it can be
    ///         used as a separator between two consecutive shapes.
    ///     </para>
    ///     <para>
    ///         You can use <see cref="DotArrowheadShape"/> as well as <see cref="DotArrowhead"/> (<see cref="DotArrowheadShape"/> is
    ///         implicitly convertible to <see cref="DotArrowhead"/>).
    ///     </para>
    /// </param>
    public DotCompositeArrowhead(params DotArrowhead[] arrowheads)
    {
        Arrowheads = arrowheads ?? throw new ArgumentNullException(nameof(arrowheads), "Arrowhead collection must not be null.");
    }

    /// <summary>
    ///     Creates a new arrowhead definition and initializes it with a collection of arrowheads.
    /// </summary>
    /// <param name="arrowheads">
    ///     The consecutive arrowheads to use. Note that the first arrowhead specified occurs closest to the node. Subsequent shapes, if
    ///     specified, occur further from the node. Also, a shape of <see cref="DotArrowheadShape.None"/> uses space, so it can be used
    ///     as a separator between two consecutive shapes.
    /// </param>
    public DotCompositeArrowhead(IEnumerable<DotArrowhead> arrowheads)
        : this(arrowheads.ToArray())
    {
    }

    /// <summary>
    ///     Creates a new arrowhead definition and initializes it with a collection of arrowheads with the specified shapes.
    /// </summary>
    /// <param name="shapes">
    ///     The consecutive shapes of the arrowheads to use. Note that the first arrowhead specified occurs closest to the node.
    ///     Subsequent shapes, if specified, occur further from the node. Also, a shape of <see cref="DotArrowheadShape.None"/> uses
    ///     space, so it can be used as a separator between two consecutive shapes.
    /// </param>
    public DotCompositeArrowhead(IEnumerable<DotArrowheadShape> shapes)
        : this(shapes.Select(shape => new DotArrowhead(shape)).ToArray())
    {
    }

    /// <summary>
    ///     Gets the component arrowheads.
    /// </summary>
    public DotArrowhead[] Arrowheads { get; }

    protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return string.Join(string.Empty, Arrowheads.Select(arrowhead => arrowhead.GetDotEncoded(options, syntaxRules)));
    }
}