using System.Text;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Layout;

namespace GiGraph.Dot.Types.Records;

/// <summary>
///     Represents a record that can be used as the label of a
///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
///         record-shaped node
///     </see>
///     .
/// </summary>
public class DotRecord : DotRecordField
{
    protected const bool FlipDefault = false;

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    public DotRecord(bool flip, params DotRecordField[] fields)
    {
        Fields = fields ?? throw new ArgumentNullException(nameof(fields), "Field collection must not be null.");
        Flip = flip;
    }

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    public DotRecord(params DotRecordField[] fields)
        : this(FlipDefault, fields)
    {
    }

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    public DotRecord(IEnumerable<DotRecordField> fields, bool flip = FlipDefault)
        : this(flip, fields.ToArray())
    {
    }

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    public DotRecord(bool flip, params DotEscapeString[] fields)
        : this(fields, flip)
    {
    }

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    public DotRecord(params DotEscapeString[] fields)
        : this(fields, FlipDefault)
    {
    }

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    public DotRecord(IEnumerable<DotEscapeString> fields, bool flip = FlipDefault)
        : this(fields.Select(field => new DotRecordTextField(field)), flip)
    {
    }

    /// <summary>
    ///     Creates a new record instance.
    /// </summary>
    /// <param name="fields">
    ///     The fields to initialize the record with.
    /// </param>
    /// <param name="flip">
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </param>
    public DotRecord(IEnumerable<string> fields, bool flip = FlipDefault)
        : this(fields.Select(field => new DotRecordTextField(field)), flip)
    {
    }

    /// <summary>
    ///     Gets the fields of the record.
    /// </summary>
    public DotRecordField[] Fields { get; }

    /// <summary>
    ///     Determines whether the orientation of the record should be changed from horizontal to vertical, or the other way round. The
    ///     initial orientation of a record-shaped node depends on the layout direction of the graph. If set to
    ///     <see cref="DotLayoutDirection.TopToBottom" /> (the default) or <see cref="DotLayoutDirection.BottomToTop" />, corresponding
    ///     to vertical layouts, the top-level fields in a record are displayed horizontally. If, however, the direction is
    ///     <see cref="DotLayoutDirection.LeftToRight" /> or <see cref="DotLayoutDirection.RightToLeft" />, corresponding to horizontal
    ///     layouts, the top-level fields are displayed vertically.
    /// </summary>
    public bool Flip { get; init; }

    protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules, bool hasParent)
    {
        var result = new StringBuilder();

        var braces = new[] { hasParent, Flip }.Where(x => x).ToList();
        var fields = Fields.Select(field => field.GetDotEncoded(options, syntaxRules, hasParent: true));

        braces.ForEach(_ => result.Append("{ "));
        result.Append(string.Join(" | ", fields));
        braces.ForEach(_ => result.Append(" }"));

        return result.ToString();
    }
}