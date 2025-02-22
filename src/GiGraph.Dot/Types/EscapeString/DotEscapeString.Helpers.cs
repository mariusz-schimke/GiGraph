using System.Diagnostics.CodeAnalysis;

namespace GiGraph.Dot.Types.EscapeString;

public abstract partial class DotEscapeString
{
    /// <summary>
    ///     Left-justifies the last line of the specified text. Note that if any text is further appended, it will start from a new line.
    /// </summary>
    /// <param name="text">
    ///     The text to justify.
    /// </param>
    public static DotEscapeString LeftJustifyLine(DotEscapeString? text) => text + LeftJustificationLineBreak;

    /// <summary>
    ///     Right-justifies the last line of the specified text. Note that if any text is further appended, it will start from a new
    ///     line.
    /// </summary>
    /// <param name="text">
    ///     The text to justify.
    /// </param>
    public static DotEscapeString RightJustifyLine(DotEscapeString? text) => text + RightJustificationLineBreak;

    /// <summary>
    ///     Creates a new instance initialized with the specified text. The text will be escaped on output DOT script generation to
    ///     ensure its correct rendering.
    /// </summary>
    /// <param name="value">
    ///     The string to use.
    /// </param>
    [return: NotNullIfNotNull(nameof(value))]
    public static DotEscapeString? FromString(string? value) => (DotUnescapedString?) value;

    /// <summary>
    ///     Creates a new instance initialized with escaped string. The string will not be modified in any way on output DOT script
    ///     generation, so it must follow the formatting rules described in the
    ///     <see href="https://www.graphviz.org/docs/attr-types/escString">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="value">
    ///     The string to use.
    /// </param>
    [return: NotNullIfNotNull(nameof(value))]
    public static DotEscapeString? FromEscapedString(string? value) => (DotEscapedString?) value;

    /// <summary>
    ///     Concatenates the specified escape strings.
    /// </summary>
    /// <param name="items">
    ///     The escape string items to concatenate.
    /// </param>
    public static DotEscapeString Concat(params DotEscapeString?[] items) => new DotConcatenatedEscapeString(items);

    /// <summary>
    ///     Concatenates the specified escape strings.
    /// </summary>
    /// <param name="items">
    ///     The escape string items to concatenate.
    /// </param>
    public static DotEscapeString Concat(IEnumerable<DotEscapeString?> items) => new DotConcatenatedEscapeString(items);

    /// <summary>
    ///     Concatenates the specified escape strings.
    /// </summary>
    /// <param name="items">
    ///     The escape string items to concatenate.
    /// </param>
    public static DotEscapeString Concat(params string?[] items) => new DotConcatenatedEscapeString(items);

    /// <summary>
    ///     Concatenates the specified escape strings.
    /// </summary>
    /// <param name="items">
    ///     The escape string items to concatenate.
    /// </param>
    public static DotEscapeString Concat(IEnumerable<string?> items) => new DotConcatenatedEscapeString(items);

    /// <summary>
    ///     Concatenates the specified escaped strings. The component strings will not be modified in any way on output DOT script
    ///     generation, so they must follow the formatting rules described in the
    ///     <see href="https://www.graphviz.org/docs/attr-types/escString">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="items">
    ///     The string to use.
    /// </param>
    public static DotEscapeString ConcatEscapedStrings(params string?[] items) => ConcatEscapedStrings((IEnumerable<string?>) items);

    /// <summary>
    ///     Concatenates the specified escaped strings. The component strings will not be modified in any way on output DOT script
    ///     generation, so they must follow the formatting rules described in the
    ///     <see href="https://www.graphviz.org/docs/attr-types/escString">
    ///         documentation
    ///     </see>
    ///     .
    /// </summary>
    /// <param name="items">
    ///     The string to use.
    /// </param>
    public static DotEscapeString ConcatEscapedStrings(IEnumerable<string?> items) =>
        new DotConcatenatedEscapeString(items.Select(FromEscapedString));
}