using System;
using System.Collections.Generic;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

public partial class DotRecordBuilder
{
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

        return AppendRecord(builder.Build(flip));
    }
}