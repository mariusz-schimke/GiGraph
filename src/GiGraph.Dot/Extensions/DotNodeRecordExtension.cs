using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Types.Graphs.Layout;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Extensions;
// It extends DotNodeDefinition not DotNode because these extensions still make sense for DotNodeGroup
// (a record may use placeholders, so even if the same record is assigned to all nodes in the group,
// all of them will have different labels when visualized).

/// <summary>
///     Provides extension methods for <see cref="DotNodeDefinition"/>.
/// </summary>
public static class DotNodeRecordExtension
{
    /// <summary>
    ///     Converts the current node to a record-shaped node with the specified content.
    /// </summary>
    /// <param name="node">
    ///     The current node.
    /// </param>
    /// <param name="record">
    ///     The record to use as the label of the node.
    /// </param>
    public static void SetRecordAsLabel(this DotNodeDefinition node, DotRecord? record)
    {
        node.Shape = DotNodeShape.Record;
        node.Label = record;
    }

    /// <summary>
    ///     Converts the current node to a record-shaped node with content composed using a builder.
    /// </summary>
    /// <param name="node">
    ///     The current node.
    /// </param>
    /// <param name="buildRecord">
    ///     A method delegate that provides a record builder to compose the node's content.
    /// </param>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom"/> (the default) or <see cref="DotLayoutDirection.BottomToTop"/>, corresponding to
    ///     vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight"/> or <see cref="DotLayoutDirection.RightToLeft"/>, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    public static void SetRecordAsLabel(this DotNodeDefinition node, Action<DotRecordBuilder> buildRecord, bool flip = false)
    {
        var builder = new DotRecordBuilder();
        buildRecord(builder);

        SetRecordAsLabel(node, builder.Build(flip));
    }
}