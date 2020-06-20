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
        /// Creates a new pipeline initialized with the specified text escapers.
        /// </summary>
        /// <param name="escapers">The text escapers to use.</param>
        public DotTextEscapingPipeline(params IDotTextEscaper[] escapers)
            : base(escapers)
        {
        }

        /// <summary>
        /// Creates a text escaping pipeline initialized with the specified collection of text escapers.
        /// </summary>
        /// <param name="escapers">The text escapers to initialize the pipeline with.</param>
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
        /// Creates a new pipeline that does not modify the input string in any way.
        /// </summary>
        public static DotTextEscapingPipeline None()
        {
            return new DotTextEscapingPipeline();
        }
    }
}