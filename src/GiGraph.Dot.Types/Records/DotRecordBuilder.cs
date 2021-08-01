using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records
{
    /// <summary>
    ///     Facilitates building a record for use as a label.
    /// </summary>
    public class DotRecordBuilder
    {
        protected const bool FlipDefault = false;
        protected readonly List<DotRecordField> _fields;

        /// <summary>
        ///     Creates a new record builder instance.
        /// </summary>
        public DotRecordBuilder()
        {
            _fields = new List<DotRecordField>();
        }

        /// <summary>
        ///     Creates a new record builder instance initialized with a list of fields.
        /// </summary>
        /// <param name="fields">
        ///     The record fields to initialize the instance with.
        /// </param>
        public DotRecordBuilder(IEnumerable<DotRecordField> fields)
        {
            _fields = new List<DotRecordField>(fields);
        }

        /// <summary>
        ///     Appends a field to the record being built.
        /// </summary>
        /// <param name="text">
        ///     The text of the field to append.
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
        ///     Appends fields to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        public virtual DotRecordBuilder AppendFields(params DotEscapeString[] fields)
        {
            AppendFields((IEnumerable<DotEscapeString>) fields);
            return this;
        }

        /// <summary>
        ///     Appends fields to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        public virtual DotRecordBuilder AppendFields(IEnumerable<DotEscapeString> fields)
        {
            _fields.AddRange(fields.Select(field => new DotRecordTextField(field)));
            return this;
        }

        /// <summary>
        ///     Appends fields to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        public virtual DotRecordBuilder AppendFields(IEnumerable<string> fields)
        {
            _fields.AddRange(fields.Select(field => new DotRecordTextField(field)));
            return this;
        }

        /// <summary>
        ///     Appends fields to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The fields to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
        /// </param>
        public virtual DotRecordBuilder AppendFields(params DotRecordField[] fields)
        {
            _fields.AddRange(fields);
            return this;
        }

        /// <summary>
        ///     Appends fields to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The fields to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
        /// </param>
        public virtual DotRecordBuilder AppendFields(IEnumerable<DotRecordField> fields)
        {
            _fields.AddRange(fields);
            return this;
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
        ///     Appends a sub-record to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(params DotEscapeString[] fields)
        {
            _fields.Add(new DotRecord(fields));
            return this;
        }

        /// <summary>
        ///     Appends a sub-record to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        /// <param name="flip">
        ///     Determines whether the the sub-record should be flipped. By default, a sub-record is oriented opposite to the orientation of
        ///     its parent record.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(IEnumerable<DotEscapeString> fields, bool flip = FlipDefault)
        {
            _fields.Add(new DotRecord(fields, flip));
            return this;
        }

        /// <summary>
        ///     Appends a sub-record to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        /// <param name="flip">
        ///     Determines whether the the sub-record should be flipped. By default, a sub-record is oriented opposite to the orientation of
        ///     its parent record.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(IEnumerable<string> fields, bool flip = FlipDefault)
        {
            _fields.Add(new DotRecord(fields, flip));
            return this;
        }

        /// <summary>
        ///     Appends sub-record to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The fields of the record to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
        /// </param>
        public virtual DotRecordBuilder AppendRecord(params DotRecordField[] fields)
        {
            _fields.Add(new DotRecord(fields));
            return this;
        }

        /// <summary>
        ///     Appends a sub-record to the record being built.
        /// </summary>
        /// <param name="fields">
        ///     The fields of the record to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
        /// </param>
        /// <param name="flip">
        ///     Determines whether the the sub-record should be flipped. By default, a sub-record is oriented opposite to the orientation of
        ///     its parent record.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(IEnumerable<DotRecordField> fields, bool flip = FlipDefault)
        {
            _fields.Add(new DotRecord(fields, flip));
            return this;
        }

        /// <summary>
        ///     Appends a sub-record to the record being built, by providing another record builder instance.
        /// </summary>
        /// <param name="buildRecord">
        ///     The method delegate to build a record using the specified record builder.
        /// </param>
        /// <param name="flip">
        ///     Determines whether the the sub-record should be flipped. By default, a sub-record is oriented opposite to the orientation of
        ///     its parent record.
        /// </param>
        public virtual DotRecordBuilder AppendRecord(Action<DotRecordBuilder> buildRecord, bool flip = false)
        {
            var builder = new DotRecordBuilder();
            buildRecord(builder);

            return AppendRecord(builder.ToRecord(flip));
        }

        /// <summary>
        ///     Appends sub-record to the record being built, with an orientation opposite to the orientation of its parent record.
        /// </summary>
        /// <param name="fields">
        ///     The textual fields to append.
        /// </param>
        public virtual DotRecordBuilder AppendFlippedRecord(params DotEscapeString[] fields)
        {
            _fields.Add(new DotRecord(fields, flip: true));
            return this;
        }

        /// <summary>
        ///     Appends sub-record to the record being built, with an orientation opposite to the orientation of its parent record.
        /// </summary>
        /// <param name="fields">
        ///     The fields of the record to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
        /// </param>
        public virtual DotRecordBuilder AppendFlippedRecord(params DotRecordField[] fields)
        {
            _fields.Add(new DotRecord(fields, flip: true));
            return this;
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