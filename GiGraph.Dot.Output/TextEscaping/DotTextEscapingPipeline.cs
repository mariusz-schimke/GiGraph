using System.Collections.Generic;

namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes text in multiple steps.
    /// </summary>
    public class DotTextEscapingPipeline : List<IDotTextEscaper>, IDotTextEscaper
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

        public virtual string Escape(string value)
        {
            foreach (var escaper in this)
            {
                value = escaper.Escape(value);
            }

            return value;
        }

        /// <summary>
        ///     Creates a new pipeline that does not modify the input string in any way.
        /// </summary>
        public static DotTextEscapingPipeline None()
        {
            return new DotTextEscapingPipeline();
        }

        /// <summary>
        ///     Creates a new pipeline that escapes backslashes and quotation marks.
        /// </summary>
        public static DotTextEscapingPipeline ForString()
        {
            return new DotTextEscapingPipeline
            (
                // When a string ends with a backslash ("...\"), the closing quotation mark is interpreted as a content character,
                // so the backslash has to be escaped.

                // In quoted strings in DOT, the only escaped character is double-quote ("). That is, in quoted strings, the dyad \" is converted to ";
                // all other characters are left unchanged. In particular, \\ remains \\. Layout engines may apply additional escape sequences.
                // https://graphviz.org/doc/info/lang.html
                new DotTrailingBackslashHtmlEscaper(),
                new DotQuotationMarkEscaper()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes backslashes, quotation marks, and line breaks.
        /// </summary>
        public static DotTextEscapingPipeline ForEscapeString()
        {
            return new DotTextEscapingPipeline(
                new DotBackslashEscaper(),
                new DotQuotationMarkEscaper(),
                new DotWindowsNewLineEscaper(),
                new DotCarriageReturnEscaper(),
                new DotUnixNewLineEscaper()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes fields of record labels (backslashes, quotation marks, line breaks; angle and curly
        ///     brackets, vertical bars, and spaces).
        /// </summary>
        public static DotTextEscapingPipeline ForRecordLabelField()
        {
            return new DotTextEscapingPipeline(
                ForEscapeString(),
                CommonForRecordLabel()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes ports of record labels (backslashes, quotation marks; angle and curly brackets, vertical
        ///     bars, and spaces).
        /// </summary>
        public static DotTextEscapingPipeline ForRecordLabelPort()
        {
            return new DotTextEscapingPipeline(
                // when a port string ends with a backslash (<...\>), the closing angle bracket is interpreted as a content character,
                // so the backslash has to be escaped
                ForString(),
                CommonForRecordLabel()
            );
        }

        private static IDotTextEscaper CommonForRecordLabel()
        {
            return new DotTextEscapingPipeline
            (
                new DotAngleBracketsEscaper(),
                new DotCurlyBracketsEscaper(),
                new DotVerticalBarEscaper(),
                new DotSpaceEscaper()
            );
        }
    }
}