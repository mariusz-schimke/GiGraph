using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Types.EscapeString;

/// <summary>
///     Represents the DOT escape string (<see href="https://www.graphviz.org/docs/attr-types/escString" />).
/// </summary>
public abstract partial class DotEscapeString : IDotEscapable
{
    string IDotEscapable.GetEscaped(IDotTextEscaper textEscaper) => GetEscapedString(textEscaper);

    protected internal abstract string GetRawString();
    protected internal abstract string GetEscapedString(IDotTextEscaper textEscaper);

    /// <summary>
    ///     Returns the underlying string.
    /// </summary>
    public override string ToString() => GetRawString();

    public static implicit operator DotEscapeString(string value) => (DotUnescapedString) value;

    public static implicit operator string(DotEscapeString value) => value?.GetRawString();

    public static DotEscapeString operator +(DotEscapeString value1, DotEscapeString value2) => new DotConcatenatedEscapeString(value1, value2);
}