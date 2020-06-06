using System.Collections.Generic;

namespace GiGraph.Dot.Generators.TextEscaping
{
    public class TextEscapingPipeline : List<IDotTextEscaper>
    {
        public TextEscapingPipeline()
        {
        }

        public TextEscapingPipeline(IEnumerable<IDotTextEscaper> collection) : base(collection)
        {
        }

        public TextEscapingPipeline(int capacity) : base(capacity)
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

        public virtual TextEscapingPipeline BuildFrom(params IDotTextEscaper[] escaper)
        {
            return new TextEscapingPipeline(escaper);
        }

        public static TextEscapingPipeline None()
        {
            return new TextEscapingPipeline();
        }

        public static TextEscapingPipeline Default()
        {
            return new TextEscapingPipeline
            {
                new DotHtmlEscaper(),
                new DotBackslashEscaper(),
                new DotQuotationMarkEscaper(),
                new DotLineBreakEscaper()
            };
        }

        public static TextEscapingPipeline ForGraphId()
        {
            return new TextEscapingPipeline
            {
                new DotHtmlEscaper(),
                new DotQuotationMarkEscaper(),
                new DotLineBreakEscaper()
            };
        }
    }
}
