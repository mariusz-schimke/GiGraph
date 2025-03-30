using System.Diagnostics.Contracts;

namespace GiGraph.Dot.Output.Text;

/// <summary>
///     Operating system-based new line constants.
/// </summary>
public static class DotNewLine
{
    /// <summary>
    ///     Windows new line string (carriage return and line feed: \r\n).
    /// </summary>
    public const string Windows = "\r\n";

    /// <summary>
    ///     Unix and Unix-like systems new line string (line feed: \n).
    /// </summary>
    public const string Unix = "\n";

    /// <summary>
    ///     Gets the line continuation character that can be used for string attributes in order to split text in the output DOT script
    ///     into multiple lines. Has to be followed by a line break. Does not affect the way the text is visualized (it's only for
    ///     formatting the output script, so the line continuation character and the line break do not appear in the visualization).
    /// </summary>
    public const string LineContinuationChar = "\\";

    /// <summary>
    ///     Gets the newline string defined for this environment.
    /// </summary>
    public static string SystemDefault => Environment.NewLine;

    /// <summary>
    ///     Returns a line continuation character followed by the system-default new line string. To be used for string attributes in
    ///     order to split text in the output DOT script into multiple lines. Does not affect the way the text is visualized (it's only
    ///     for formatting the output script, so the line continuation character and the line break do not appear in the visualization).
    /// </summary>
    [Pure]
    public static string LineContinuation() => LineContinuation(SystemDefault);

    /// <summary>
    ///     Returns a line continuation character followed by the specified new line string. To be used for string attributes in order to
    ///     split text in the output DOT script into multiple lines. Does not affect the way the text is visualized (it's only for
    ///     formatting the output script, so the line continuation character and the line break do not appear in the visualization).
    /// </summary>
    /// <param name="newLine">
    ///     The new line string to use.
    /// </param>
    [Pure]
    public static string LineContinuation(string newLine) => string.IsNullOrEmpty(newLine)
        ? throw new ArgumentNullException(nameof(newLine), "A new line string has to be specified for line continuation")
        : $"{LineContinuationChar}{newLine}";
}