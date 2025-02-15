using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Types.Records;

/// <summary>
///     Represents a field of a record (<see cref="DotRecord" />). It can either be text (<see cref="DotRecordTextField" />), or
///     another record (<see cref="DotRecord" />). A record can be used as the label of a
///     <see href="https://www.graphviz.org/doc/info/shapes.html#record">
///         record-shaped node
///     </see>
///     .
/// </summary>
public abstract record DotRecordField : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncoded(options, syntaxRules, hasParent: false);

    protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules, bool hasParent);

    [return: NotNullIfNotNull(nameof(text))]
    public static implicit operator DotRecordField?(string? text) => new DotRecordTextField(text);

    [return: NotNullIfNotNull(nameof(text))]
    public static implicit operator DotRecordField?(DotEscapeString? text) => new DotRecordTextField(text);
}