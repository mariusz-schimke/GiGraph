using System.Text;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Arrowheads;

/// <summary>
///     Defines an arrowhead shape. See the
///     <see href="https://www.graphviz.org/doc/info/arrows.html">
///         documentation
///     </see>
///     to view what shape configurations are supported.
/// </summary>
/// <param name="Shape">
///     Determines the shape of the arrowhead to use.
/// </param>
public record DotArrowhead(DotArrowheadShape Shape) : DotArrowheadDefinition
{
    /// <summary>
    ///     Creates and initializes a new arrowhead definition instance.
    /// </summary>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="filled">
    ///     Determines whether to use a filled version of the shape.
    /// </param>
    public DotArrowhead(DotArrowheadShape shape, bool filled)
        : this(shape)
    {
        IsFilled = filled;
    }

    /// <summary>
    ///     Creates and initializes a new arrowhead definition instance.
    /// </summary>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public DotArrowhead(DotArrowheadShape shape, DotArrowheadParts visibleParts)
        : this(shape)
    {
        VisibleParts = visibleParts;
    }

    /// <summary>
    ///     Creates and initializes a new arrowhead definition instance.
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
    public DotArrowhead(DotArrowheadShape shape, bool filled, DotArrowheadParts visibleParts)
        : this(shape)
    {
        IsFilled = filled;
        VisibleParts = visibleParts;
    }

    /// <summary>
    ///     The shape of the arrowhead.
    /// </summary>
    public DotArrowheadShape Shape { get; init; } = Shape;

    /// <summary>
    ///     Determines whether to use a filled version of the shape.
    /// </summary>
    public bool IsFilled { get; init; } = true;

    /// <summary>
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </summary>
    public DotArrowheadParts VisibleParts { get; init; } = DotArrowheadParts.Both;

    protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var result = new StringBuilder();

        if (!IsFilled)
        {
            result.Append("o");
        }

        // clips the shape, leaving visible only the part to the left or to the right of the edge
        result.Append(DotAttributeValue.Get(VisibleParts));

        result.Append(DotAttributeValue.Get(Shape));

        return result.ToString();
    }

    /// <summary>
    ///     Creates a filled arrowhead with the <see cref="DotArrowheadShape.Normal" /> shape.
    /// </summary>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public static DotArrowhead Filled(DotArrowheadParts visibleParts = DotArrowheadParts.Both) => Filled(DotArrowheadShape.Normal, visibleParts);

    /// <summary>
    ///     Creates a filled arrowhead with the specified shape.
    /// </summary>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public static DotArrowhead Filled(DotArrowheadShape shape, DotArrowheadParts visibleParts = DotArrowheadParts.Both) => new(shape, filled: true, visibleParts);

    /// <summary>
    ///     Creates a non-filled arrowhead with the <see cref="DotArrowheadShape.Normal" /> shape.
    /// </summary>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public static DotArrowhead Empty(DotArrowheadParts visibleParts = DotArrowheadParts.Both) => Empty(DotArrowheadShape.Normal, visibleParts);

    /// <summary>
    ///     Creates a non-filled arrowhead with the specified shape.
    /// </summary>
    /// <param name="shape">
    ///     Determines the shape of the arrowhead to use.
    /// </param>
    /// <param name="visibleParts">
    ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
    /// </param>
    public static DotArrowhead Empty(DotArrowheadShape shape, DotArrowheadParts visibleParts = DotArrowheadParts.Both) => new(shape, filled: false, visibleParts);

    public static implicit operator DotArrowhead(DotArrowheadShape? shape) => shape.HasValue ? new DotArrowhead(shape.Value) : null;
}