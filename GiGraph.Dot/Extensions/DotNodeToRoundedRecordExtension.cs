using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="DotNode" />.
    /// </summary>
    public static class DotNodeToRoundedRecordExtension
    {
        /// <summary>
        ///     Converts the current node to a rounded record node.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="record">
        ///     The record to use as the label of the node.
        /// </param>
        public static void ToRoundedRecord(this DotNode node, DotRecord record)
        {
            node.Attributes.Shape = DotNodeShape.RoundedRecord;
            node.Attributes.Label = record;
        }

        /// <summary>
        ///     Converts the current node to a rounded record node composed using a builder.
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
        public static void ToRoundedRecord(this DotNode node, Action<DotRecordBuilder> buildRecord, bool flip = false)
        {
            var builder = new DotRecordBuilder();
            buildRecord(builder);

            ToRoundedRecord(node, builder.ToRecord(flip));
        }

        /// <summary>
        ///     Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use. Pass <see cref="T:string" /> (implicitly convertible to <see cref="DotRecordTextField" />), or
        ///     <see cref="T:string[]" /> (implicitly convertible to <see cref="DotRecord" />).
        /// </param>
        public static void ToRoundedRecord(this DotNode node, params DotRecordField[] fields)
        {
            ToRoundedRecord(node, new DotRecord(fields));
        }

        /// <summary>
        ///     Converts the current node to a rounded record node composed of the specified fields.
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
        public static void ToRoundedRecord(this DotNode node, IEnumerable<DotRecordField> fields, bool flip = false)
        {
            ToRoundedRecord(node, new DotRecord(fields, flip));
        }

        /// <summary>
        ///     Converts the current node to a flipped rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use. Pass <see cref="T:string" /> (implicitly convertible to <see cref="DotRecordTextField" />), or
        ///     <see cref="T:string[]" /> (implicitly convertible to <see cref="DotRecord" />).
        /// </param>
        public static void ToFlippedRoundedRecord(this DotNode node, params DotRecordField[] fields)
        {
            ToRoundedRecord(node, new DotRecord(flip: true, fields));
        }

        /// <summary>
        ///     Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use.
        /// </param>
        public static void ToRoundedRecord(this DotNode node, params DotEscapeString[] fields)
        {
            ToRoundedRecord(node, new DotRecord(fields));
        }

        /// <summary>
        ///     Converts the current node to a rounded record node composed of the specified fields.
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
        public static void ToRoundedRecord(this DotNode node, IEnumerable<string> fields, bool flip = false)
        {
            ToRoundedRecord(node, new DotRecord(fields, flip));
        }

        /// <summary>
        ///     Converts the current node to a rounded record node composed of the specified fields.
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
        public static void ToRoundedRecord(this DotNode node, IEnumerable<DotEscapeString> fields, bool flip = false)
        {
            ToRoundedRecord(node, new DotRecord(fields, flip));
        }

        /// <summary>
        ///     Converts the current node to a flipped rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">
        ///     The current node.
        /// </param>
        /// <param name="fields">
        ///     The record fields to use.
        /// </param>
        public static void ToFlippedRoundedRecord(this DotNode node, params DotEscapeString[] fields)
        {
            ToRoundedRecord(node, new DotRecord(flip: true, fields));
        }
    }
}