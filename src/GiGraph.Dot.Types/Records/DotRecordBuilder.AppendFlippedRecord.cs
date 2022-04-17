using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

public partial class DotRecordBuilder
{
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
}