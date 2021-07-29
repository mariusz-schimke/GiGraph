using System;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="DotNode" />.
    /// </summary>
    public static class DotNodeToRecordExtension
    {
        /// <summary>
        ///     Converts the current node to a record node.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="record">
        ///     The record to use as the label of the node.
        /// </param>
        public static void ToRecordNode(this DotNode node, DotRecord record)
        {
            node.Attributes.Shape = DotNodeShape.Record;
            node.Attributes.Label = record;
        }

        /// <summary>
        ///     Converts the current node to a record node composed using a builder.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="buildRecord">
        ///     A method delegate that provides a record built with a specified builder.
        /// </param>
        /// <param name="flip">
        ///     Determines whether to change orientation of the record.
        /// </param>
        public static void ToRecordNode(this DotNode node, Action<DotRecordBuilder> buildRecord, bool flip = false)
        {
            var builder = new DotRecordBuilder();
            buildRecord(builder);

            ToRecordNode(node, builder.ToRecord(flip));
        }
    }
}