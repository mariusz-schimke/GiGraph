using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public interface IDotNodeLabelOptionsAttributes
{
    /// <summary>
    ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Center"/>). This attribute is used only when the
    ///     height of the node is larger than the height of its label.
    /// </summary>
    DotVerticalAlignment? VerticalAlignment { get; set; }

    /// <summary>
    ///     Specifies space left around the node's label. By default, the value is (0.11, 0.055).
    /// </summary>
    DotPoint? Margin { get; set; }

    /// <summary>
    ///     <para>
    ///         Determines whether to justify multiline text vs the previous text line rather than the side of the container (default:
    ///         false).
    ///     </para>
    ///     <para>
    ///         By default, the justification of multi-line labels is done within the largest context that makes sense. Thus, in the
    ///         label of a polygonal node, a left-justified line will align with the left side of the node (shifted by the prescribed
    ///         margin). In record nodes, left-justified line will line up with the left side of the enclosing column of fields. If
    ///         <see cref="DisableJustification"/> is true, multi-line labels will be justified in the context of itself. For example, if
    ///         <see cref="DisableJustification"/> is set, the first label line is long, and the second is shorter and left-justified,
    ///         the second will align with the left-most character in the first line, regardless of how large the node might be.
    ///     </para>
    /// </summary>
    bool? DisableJustification { get; set; }
}