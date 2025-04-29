using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;

public interface IDotLabelOptionsAttributes
{
    /// <summary>
    ///     Justification for the label. Note that clusters inherit attributes from their parent. Thus, if the root graph sets this
    ///     attribute to <see cref="DotHorizontalAlignment.Left"/>, clusters inherit this value. Default:
    ///     <see cref="DotHorizontalAlignment.Center"/>.
    /// </summary>
    DotHorizontalAlignment? HorizontalAlignment { get; set; }

    /// <summary>
    ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Top"/>; only <see cref="DotVerticalAlignment.Top"/>
    ///     and <see cref="DotVerticalAlignment.Bottom"/> are allowed). Note that clusters inherit attributes from their parent. Thus, if
    ///     the root graph sets this attribute to <see cref="DotVerticalAlignment.Bottom"/>, clusters inherits this value.
    /// </summary>
    DotVerticalAlignment? VerticalAlignment { get; set; }

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