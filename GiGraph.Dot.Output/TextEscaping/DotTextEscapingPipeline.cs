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
                // When a single backslash is quoted ("\"), it is misinterpreted as an escape character for the closing quotation mark,
                // so it has to be escaped ("\\"). Escaping backslashes seems to be redundant apart from that specific case
                // (unless this is an escString type attribute).
                new DotBackslashEscaper(),
                // quotation mark would make a quoted string invalid, so has to be escaped
                new DotQuotationMarkEscaper()
            );
        }

        /// <summary>
        ///     Creates a new pipeline that escapes backslashes, quotation marks, and line breaks.
        /// </summary>
        public static DotTextEscapingPipeline ForEscapeString()
        {
            return new DotTextEscapingPipeline(
                ForString(),
                new DotLineBreakEscaper()
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