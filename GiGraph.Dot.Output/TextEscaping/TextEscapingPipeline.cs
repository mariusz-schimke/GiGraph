using System.Collections.Generic;

namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes text.
    /// </summary>
    public class TextEscapingPipeline : List<IDotTextEscaper>, IDotTextEscaper
    {
        /// <summary>
        /// Creates an empty text escaping pipeline.
        /// </summary>
        public TextEscapingPipeline()
        {
        }

        /// <summary>
        /// Creates a text escaping pipeline initialized with the specified collection of text escapers.
        /// </summary>
        /// <param name="collection">The text escapers to initialize the pipeline with.</param>
        public TextEscapingPipeline(IEnumerable<IDotTextEscaper> collection) : base(collection)
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
        public virtual TextEscapingPipeline From(params IDotTextEscaper[] escaper)
        {
            return new TextEscapingPipeline(escaper);
        }

        /// <summary>
        /// Creates a new pipeline that does not modify the input string in any way.
        /// </summary>
        public static TextEscapingPipeline None()
        {
            return new TextEscapingPipeline();
        }

        /// <summary>
        /// Creates a new pipeline to use for escaping strings (e.g. the value of the string attribute).
        /// </summary>
        public static TextEscapingPipeline ForString()
        {
            return new TextEscapingPipeline
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
        public static TextEscapingPipeline ForIdentifier()
        {
            return ForString();
        }
    }
}