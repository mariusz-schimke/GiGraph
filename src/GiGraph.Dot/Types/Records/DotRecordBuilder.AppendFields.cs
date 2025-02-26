using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

public partial class DotRecordBuilder
{
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
}