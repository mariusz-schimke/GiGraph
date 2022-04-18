using System;
using System.Collections.Generic;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

public partial class DotRecordBuilder
{
    /// <summary>
    ///     Appends a sub-record to the record being built.
    /// </summary>
    /// <param name="subrecord">
    ///     The sub-record to append.
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(DotRecord subrecord)
    {
        _fields.Add(subrecord);
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of the sub-record will
    ///     be opposite to the layout of its parent record.
    /// </summary>
    /// <param name="fields">
    ///     The textual fields to append.
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(params DotEscapeString[] fields)
    {
        _fields.Add(new DotRecord(fields, flip: false));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of the sub-record will
    ///     be opposite to the layout of its parent record.
    /// </summary>
    /// <param name="fields">
    ///     The textual fields to append.
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(IEnumerable<DotEscapeString> fields)
    {
        _fields.Add(new DotRecord(fields, flip: false));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of the sub-record will
    ///     be opposite to the layout of its parent record.
    /// </summary>
    /// <param name="fields">
    ///     The textual fields to append.
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(IEnumerable<string> fields)
    {
        _fields.Add(new DotRecord(fields, flip: false));
        return this;
    }

    /// <summary>
    ///     Appends sub-record to the record being built, composed of the specified fields. The layout direction of the sub-record will
    ///     be opposite to the layout of its parent record.
    /// </summary>
    /// <param name="fields">
    ///     The fields of the record to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(params DotRecordField[] fields)
    {
        _fields.Add(new DotRecord(fields, flip: false));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of the sub-record will
    ///     be opposite to the layout of its parent record.
    /// </summary>
    /// <param name="fields">
    ///     The fields of the record to append (<see cref="DotRecordTextField" />, <see cref="DotRecord" />).
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(IEnumerable<DotRecordField> fields)
    {
        _fields.Add(new DotRecord(fields, flip: false));
        return this;
    }

    /// <summary>
    ///     Appends a custom-composed sub-record to the record being built. The layout direction of the sub-record will be opposite to
    ///     the layout of its parent record.
    /// </summary>
    /// <param name="buildRecord">
    ///     The method delegate to build a record using the specified record builder.
    /// </param>
    public virtual DotRecordBuilder AppendSubrecord(Action<DotRecordBuilder> buildRecord)
    {
        return AppendSubrecord(buildRecord, flip: false);
    }

    protected virtual DotRecordBuilder AppendSubrecord(Action<DotRecordBuilder> buildRecord, bool flip)
    {
        var builder = new DotRecordBuilder();
        buildRecord(builder);

        return AppendSubrecord(builder.Build(flip));
    }
}