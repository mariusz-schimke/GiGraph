using System.Collections.Generic;

namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes text in multiple steps.
    /// </summary>
    public class DotTextEscapingPipeline : List<IDotTextEscaper>, IDotTextEscaper
    {
        /// <summary>
        /// Creates an empty text escaping pipeline.
        /// </summary>
        public DotTextEscapingPipeline()
        {
        }

        /// <summary>
        /// Creates a text escaping pipeline initialized with the specified collection of text escapers.
        /// </summary>
        /// <param name="collection">The text escapers to initialize the pipeline with.</param>
        public DotTextEscapingPipeline(IEnumerable<IDotTextEscaper> collection) : base(collection)
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
        /// Creates a new pipeline initialized with the specified text escapers.
        /// </summary>
        /// <param name="escaper">The text escapers to use.</param>
        public virtual DotTextEscapingPipeline From(params IDotTextEscaper[] escaper)
        {
            return new DotTextEscapingPipeline(escaper);
        }

        /// <summary>
        /// Creates a new pipeline that does not modify the input string in any way.
        /// </summary>
        public static DotTextEscapingPipeline None()
        {
            return new DotTextEscapingPipeline();
        }

        /// <summary>
        /// Creates a new pipeline to use for escaping strings (e.g. the value of the string attribute).
        /// </summary>
        public static DotTextEscapingPipeline ForString()
        {
            return new DotTextEscapingPipeline
            {
                new DotHtmlEscaper(),
                new DotBackslashEscaper(),
                new DotQuotationMarkEscaper(),
                new DotLineBreakEscaper()
            };
        }

        /// <summary>
        /// Creates a new pipeline to use for escaping identifiers.
        /// </summary>
        public static DotTextEscapingPipeline ForIdentifier()
        {
            return ForString();
        }
        
        /// <summary>
        /// Creates a new pipeline to use for escaping strings in record node fields.
        /// </summary>
        public static DotTextEscapingPipeline ForRecordNodeField()
        {
            return new DotTextEscapingPipeline(ForString())
            {
                new DotAngleBracketsEscaper(),
                new DotCurlyBracketsEscaper(),
                new DotVerticalBarEscaper(),
                new DotSpaceEscaper()
            };
        }
    }
}