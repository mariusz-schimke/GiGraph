using System;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Entities.Labels;

/// <summary>
///     Represents a record label. The value is a compatible record string following the rules described in the
///     <see href="http://www.graphviz.org/doc/info/shapes.html#record">
///         documentation
///     </see>
///     .
/// </summary>
public class DotRecordLabel : DotLabel
{
    protected readonly DotRecord _record;

    /// <summary>
    ///     Creates a new record label.
    /// </summary>
    /// <param name="record">
    ///     The record to use.
    /// </param>
    public DotRecordLabel(DotRecord record)
    {
        _record = record ?? throw new ArgumentNullException(nameof(record), "Record must not be null.");
    }

    protected override string GetDotEncodedString(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return ((IDotEncodable) _record)?.GetDotEncodedValue(options, syntaxRules);
    }
}