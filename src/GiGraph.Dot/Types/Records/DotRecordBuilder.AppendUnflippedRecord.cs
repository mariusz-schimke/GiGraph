using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

public partial class DotRecordBuilder
{
    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of a sub-record is
    ///     normally opposite to the layout of its parent record, but this method changes that behavior, and adds a sub-record with the
    ///     same layout direction as its parent. In terms of visualization, the effect is the same as when adding fields directly to the
    ///     parent record (see <see cref="AppendFields(GiGraph.Dot.Types.EscapeString.DotEscapeString[])"/>).
    /// </summary>
    /// <param name="fields">
    ///     The textual fields to append.
    /// </param>
    public virtual DotRecordBuilder AppendUnflippedSubrecord(params DotEscapeString?[] fields)
    {
        _fields.Add(new DotRecord(fields, flip: true));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of a sub-record is
    ///     normally opposite to the layout of its parent record, but this method changes that behavior, and adds a sub-record with the
    ///     same layout direction as its parent. In terms of visualization, the effect is the same as when adding fields directly to the
    ///     parent record (see <see cref="AppendFields(IEnumerable{GiGraph.Dot.Types.EscapeString.DotEscapeString})"/>).
    /// </summary>
    /// <param name="fields">
    ///     The textual fields to append.
    /// </param>
    public virtual DotRecordBuilder AppendUnflippedSubrecord(IEnumerable<DotEscapeString?> fields)
    {
        _fields.Add(new DotRecord(fields, flip: true));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of a sub-record is
    ///     normally opposite to the layout of its parent record, but this method changes that behavior, and adds a sub-record with the
    ///     same layout direction as its parent. In terms of visualization, the effect is the same as when adding fields directly to the
    ///     parent record (see <see cref="AppendFields(IEnumerable{string})"/>).
    /// </summary>
    /// <param name="fields">
    ///     The textual fields to append.
    /// </param>
    public virtual DotRecordBuilder AppendUnflippedSubrecord(IEnumerable<string?> fields)
    {
        _fields.Add(new DotRecord(fields, flip: true));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of a sub-record is
    ///     normally opposite to the layout of its parent record, but this method changes that behavior, and adds a sub-record with the
    ///     same layout direction as its parent. In terms of visualization, the effect is the same as when adding fields directly to the
    ///     parent record (see <see cref="AppendFields(GiGraph.Dot.Types.Records.DotRecordField[])"/>).
    /// </summary>
    /// <param name="fields">
    ///     The fields of the record to append (<see cref="DotRecordTextField"/>, <see cref="DotRecord"/>).
    /// </param>
    public virtual DotRecordBuilder AppendUnflippedSubrecord(params DotRecordField[] fields)
    {
        _fields.Add(new DotRecord(fields, flip: true));
        return this;
    }

    /// <summary>
    ///     Appends a sub-record to the record being built, composed of the specified fields. The layout direction of a sub-record is
    ///     normally opposite to the layout of its parent record, but this method changes that behavior, and adds a sub-record with the
    ///     same layout direction as its parent. In terms of visualization, the effect is the same as when adding fields directly to the
    ///     parent record (see <see cref="AppendFields(IEnumerable{GiGraph.Dot.Types.Records.DotRecordField})"/>)..
    /// </summary>
    /// <param name="fields">
    ///     The fields of the record to append (<see cref="DotRecordTextField"/>, <see cref="DotRecord"/>).
    /// </param>
    public virtual DotRecordBuilder AppendUnflippedSubrecord(IEnumerable<DotRecordField> fields)
    {
        _fields.Add(new DotRecord(fields, flip: true));
        return this;
    }

    /// <summary>
    ///     Appends a custom-composed sub-record to the record being built. The layout direction of a sub-record is normally opposite to
    ///     the layout of its parent record, but this method changes that behavior, and adds a sub-record with the same layout direction
    ///     as its parent.
    /// </summary>
    /// <param name="buildRecord">
    ///     The method delegate to build a record using the specified record builder.
    /// </param>
    public virtual DotRecordBuilder AppendUnflippedSubrecord(Action<DotRecordBuilder>? buildRecord) => AppendSubrecord(buildRecord, flip: true);
}