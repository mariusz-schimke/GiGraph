using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Text.Escaping.Html;

namespace GiGraph.Dot.Output.Text.Escaping.Pipelines;

/// <summary>
///     Escapes text in multiple steps.
/// </summary>
public partial class DotTextEscapingPipeline : List<IDotTextEscaper>, IDotTextEscaper
{
    /// <summary>
    ///     Creates an empty text escaping pipeline.
    /// </summary>
    public DotTextEscapingPipeline()
    {
    }

    /// <summary>
    ///     Creates a new pipeline initialized with the specified text escapers.
    /// </summary>
    /// <param name="escapers">
    ///     The text escapers to use.
    /// </param>
    public DotTextEscapingPipeline(params IDotTextEscaper[] escapers)
        : base(escapers)
    {
    }

    /// <summary>
    ///     Creates a text escaping pipeline initialized with the specified collection of text escapers.
    /// </summary>
    /// <param name="escapers">
    ///     The text escapers to initialize the pipeline with.
    /// </param>
    public DotTextEscapingPipeline(IEnumerable<IDotTextEscaper> escapers)
        : base(escapers)
    {
    }

    public virtual string? Escape(string? value) => this.Aggregate(value, (current, escaper) => escaper.Escape(current));

    /// <summary>
    ///     Creates a new pipeline that does not modify the input string in any way.
    /// </summary>
    public static DotTextEscapingPipeline None() => [];

    /// <summary>
    ///     Creates a new pipeline that escapes backslashes and quotation marks.
    /// </summary>
    public static DotTextEscapingPipeline ForString() =>
        new(
            // When a string ends with a backslash ("...\"), the closing quotation mark is interpreted as a content character,
            // so the backslash has to be escaped.

            // In quoted strings in DOT, the only escaped character is double-quote ("). That is, in quoted strings, the dyad \" is converted to ";
            // all other characters are left unchanged. In particular, \\ remains \\. Layout engines may apply additional escape sequences.
            // https://www.graphviz.org/doc/info/lang.html
            new DotTrailingBackslashHtmlEscaper(),
            new DotQuotationMarkEscaper()
        );

    /// <summary>
    ///     Creates a new pipeline that escapes backslashes, quotation marks, and line breaks.
    /// </summary>
    public static DotTextEscapingPipeline ForEscapeString() => new(CommonForEscapeString(), new DotQuotationMarkEscaper());

    protected static DotTextEscapingPipeline CommonForEscapeString() =>
        new(
            new DotBackslashEscaper(),
            new DotWindowsNewLineEscaper(),
            new DotCarriageReturnEscaper(),
            new DotUnixNewLineEscaper()
        );
}