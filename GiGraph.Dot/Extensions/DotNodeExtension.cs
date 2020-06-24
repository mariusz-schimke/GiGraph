using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Records;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    /// Provides helper methods for <see cref="DotNode"/>.
    /// </summary>
    public static class DotNodeExtension
    {
        /// <summary>
        /// Converts the current node to a record node.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="record">The record to use as the label of the node.</param>
        public static void ToRecord(this DotNode node, DotRecord record)
        {
            ToRecord(node, record, rounded: false);
        }

        /// <summary>
        /// Converts the current node to a rounded record node.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="record">The record to use as the label of the node.</param>
        public static void ToRoundedRecord(this DotNode node, DotRecord record)
        {
            ToRecord(node, record, rounded: true);
        }

        /// <summary>
        /// Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRecord(this DotNode node, params DotRecordField[] fields)
        {
            ToRecord(node, new DotRecord(fields), rounded: false);
        }

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRoundedRecord(this DotNode node, params DotRecordField[] fields)
        {
            ToRecord(node, new DotRecord(fields), rounded: true);
        }

        /// <summary>
        /// Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRecord(this DotNode node, bool flip, params DotRecordField[] fields)
        {
            ToRecord(node, new DotRecord(flip, fields), rounded: false);
        }

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use. Pass <see cref="T:string"/> (implicitly convertible to <see cref="DotRecordTextField"/>),
        /// or <see cref="T:string[]"/> (implicitly convertible to <see cref="DotRecord"/>).</param>
        public static void ToRoundedRecord(this DotNode node, bool flip, params DotRecordField[] fields)
        {
            ToRecord(node, new DotRecord(flip, fields), rounded: true);
        }

        /// <summary>
        /// Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRecord(this DotNode node, params string[] fields)
        {
            ToRecord(node, new DotRecord(fields), rounded: false);
        }

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRoundedRecord(this DotNode node, params string[] fields)
        {
            ToRecord(node, new DotRecord(fields), rounded: true);
        }

        /// <summary>
        /// Converts the current node to a record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRecord(this DotNode node, bool flip, params string[] fields)
        {
            ToRecord(node, new DotRecord(flip, fields), rounded: false);
        }

        /// <summary>
        /// Converts the current node to a rounded record node composed of the specified fields.
        /// </summary>
        /// <param name="node">The current node.</param>
        /// <param name="flip">Determines whether to change orientation of the record.</param>
        /// <param name="fields">The record fields to use.</param>
        public static void ToRoundedRecord(this DotNode node, bool flip, params string[] fields)
        {
            ToRecord(node, new DotRecord(flip, fields), rounded: true);
        }

        private static void ToRecord(DotNode node, DotRecord record, bool rounded)
        {
            node.Attributes.Shape = rounded ? DotShape.RoundedRecord : DotShape.Record;
            node.Attributes.Label = record;
        }
    }
}