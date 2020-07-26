using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides helper methods for <see cref="DotNode" />.
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
        public static void ToRecord(this DotNode node, DotRecord record)
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
        public static void ToRecord(this DotNode node, Action<DotRecordBuilder> buildRecord, bool flip = false)
        {
            var builder = new DotRecordBuilder();
            buildRecord(builder);

            ToRecord(node, builder.ToRecord(flip));
        }

        /// <summary>
        ///     Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use. Pass <see cref="T:string" /> (implicitly convertible to <see cref="DotRecordTextField" />), or
        ///     <see cref="T:string[]" /> (implicitly convertible to <see cref="DotRecord" />).
        /// </param>
        public static void ToRecord(this DotNode node, params DotRecordField[] fields)
        {
            ToRecord(node, new DotRecord(fields));
        }

        /// <summary>
        ///     Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use. Pass <see cref="T:string" /> (implicitly convertible to <see cref="DotRecordTextField" />), or
        ///     <see cref="T:string[]" /> (implicitly convertible to <see cref="DotRecord" />).
        /// </param>
        /// <param name="flip">
        ///     Determines whether to change orientation of the record.
        /// </param>
        public static void ToRecord(this DotNode node, IEnumerable<DotRecordField> fields, bool flip = false)
        {
            ToRecord(node, new DotRecord(fields, flip));
        }

        /// <summary>
        ///     Converts the current node to a flipped record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use. Pass <see cref="T:string" /> (implicitly convertible to <see cref="DotRecordTextField" />), or
        ///     <see cref="T:string[]" /> (implicitly convertible to <see cref="DotRecord" />).
        /// </param>
        public static void ToFlippedRecord(this DotNode node, params DotRecordField[] fields)
        {
            ToRecord(node, new DotRecord(flip: true, fields));
        }

        /// <summary>
        ///     Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use.
        /// </param>
        public static void ToRecord(this DotNode node, params DotEscapeString[] fields)
        {
            ToRecord(node, new DotRecord(fields));
        }

        /// <summary>
        ///     Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use.
        /// </param>
        /// <param name="flip">
        ///     Determines whether to change orientation of the record.
        /// </param>
        public static void ToRecord(this DotNode node, IEnumerable<string> fields, bool flip = false)
        {
            ToRecord(node, new DotRecord(fields, flip));
        }

        /// <summary>
        ///     Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use.
        /// </param>
        /// <param name="flip">
        ///     Determines whether to change orientation of the record.
        /// </param>
        public static void ToRecord(this DotNode node, IEnumerable<DotEscapeString> fields, bool flip = false)
        {
            ToRecord(node, new DotRecord(fields, flip));
        }

        /// <summary>
        ///     Converts the current node to a flipped record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use.
        /// </param>
        public static void ToFlippedRecord(this DotNode node, params DotEscapeString[] fields)
        {
            ToRecord(node, new DotRecord(flip: true, fields));
        }
    }
}