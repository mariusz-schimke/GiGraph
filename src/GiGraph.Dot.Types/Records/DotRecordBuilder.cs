using System.Collections.Generic;

namespace GiGraph.Dot.Types.Records;

/// <summary>
///     Facilitates building a record for use as a label.
/// </summary>
public partial class DotRecordBuilder
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
    ///     Gets the number of fields in this builder.
    /// </summary>
    public virtual int Count => _fields.Count;

    /// <summary>
    ///     Builds and returns a record.
    /// </summary>
    /// <param name="flip">
    ///     Determines whether to change orientation of the record.
    /// </param>
    public virtual DotRecord Build(bool flip = false)
    {
        return new DotRecord(_fields.ToArray(), flip);
    }
}