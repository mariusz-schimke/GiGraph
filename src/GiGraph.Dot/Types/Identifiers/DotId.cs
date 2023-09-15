using System;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Identifiers;

/// <summary>
///     Represents element identifier.
/// </summary>
public class DotId : IDotEncodable
{
    protected readonly string _id;

    /// <summary>
    ///     Creates a new element identifier.
    /// </summary>
    /// <param name="id">
    ///     The identifier to use.
    /// </param>
    public DotId(string id)
    {
        _id = id;
    }

    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    public override string ToString() => _id;

    protected virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) =>
        // use the same identifier escaping pipeline as the one used by entity generators
        syntaxRules.IdentifierEscaper.Escape(FormatId(options, syntaxRules));

    protected virtual string FormatId(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _id;

    public static implicit operator string(DotId id) => id?._id;

    public static implicit operator DotId(string id) => id is not null ? new DotId(id) : null;

    public override bool Equals(object obj) =>
        obj is DotId id &&
        id._id == _id &&
        id.GetType() == GetType();

    public override int GetHashCode() => Tuple.Create(_id, GetType()).GetHashCode();
}