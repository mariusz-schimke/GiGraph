using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Records
{
    /// <summary>
    ///     Facilitates building a record for use as a label.
    /// </summary>
    public class DotRecordBuilder
    {
        protected readonly List<DotRecordField> _fields = new List<DotRecordField>();

        /// <summary>
        ///     Appends a field to the record being built.
        /// </summary>
        /// <param name="text">
        ///     The record to append.
        /// </param>
        /// <param name="portName">
        ///     The port name, that is a name that can be referred to from an edge endpoint in order to attach the end of the edge to the
        ///     appended field.
        /// </param>
        public virtual DotRecordBuilder AppendField(DotEscapeString text, string portName = null)
        {
            _fields.Add(new DotRecordTextField(text, portName));
            return this;
        }

        /// <summary>
        ///     Appends a field to the record being built.
        /// </summary>
        /// <param name="formatText">
        ///     The method delegate to generate formatted text for the field, using the specified text formatter.
        /// </param>
        /// <param name="portName">
        ///     The port name, that is a name that can be referred to from an edge endpoint in order to attach the end of the edge to the
        ///     appended field.
        /// </param>
        public virtual DotRecordBuilder AppendField(Action<DotTextFormatter> formatText, string portName = null)
        {
            var formatter = new DotTextFormatter();
            formatText(formatter);

            return AppendField(formatter.ToFormattedText(), portName);
        }

        /// <summary>
        ///     Appends a sub-record to the record being built.
        /// </summary>
        /// <param name="record">
        ///     The record to append.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(DotRecord record)
        {
            _fields.Add(record);
            return this;
        }

        /// <summary>
        ///     Appends a sub-record to the record being built, by providing another record builder instance.
        /// </summary>
        /// <param name="buildRecord">
        ///     The method delegate to build a record using the specified record builder.
        /// </param>
        /// <param name="flip">
        ///     Determines whether to change orientation of the record.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(Action<DotRecordBuilder> buildRecord, bool flip = false)
        {
            var builder = new DotRecordBuilder();
            buildRecord(builder);

            return AppendRecord(builder.ToRecord(flip));
        }

        /// <summary>
        ///     Builds and returns a record.
        /// </summary>
        /// <param name="flip">
        ///     Determines whether to change orientation of the record.
        /// </param>
        public virtual DotRecord ToRecord(bool flip = false)
        {
            return new DotRecord(_fields.ToArray(), flip);
        }
    }
}