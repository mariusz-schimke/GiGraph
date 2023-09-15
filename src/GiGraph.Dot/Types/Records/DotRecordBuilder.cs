using System.Collections.Generic;
using GiGraph.Dot.Types.Layout;

namespace GiGraph.Dot.Types.Records;

/// <summary>
///     Facilitates building a record for use as a label.
/// </summary>
public partial class DotRecordBuilder
{
    protected readonly List<DotRecordField> _fields;

    /// <summary>
    ///     Creates a new record builder instance.
    /// </summary>
    public DotRecordBuilder()
    {
        _fields = new();
    }

    /// <summary>
    ///     Creates a new record builder instance initialized with a list of fields.
    /// </summary>
    /// <param name="fields">
    ///     The record fields to initialize the instance with.
    /// </param>
    public DotRecordBuilder(IEnumerable<DotRecordField> fields)
    {
        _fields = new(fields);
    }

    /// <summary>
    ///     Gets the number of fields in this builder.
    /// </summary>
    public virtual int Count => _fields.Count;

    /// <summary>
    ///     Builds and returns a record.
    /// </summary>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    public virtual DotRecord Build(bool flip = false) => new(_fields.ToArray(), flip);
}