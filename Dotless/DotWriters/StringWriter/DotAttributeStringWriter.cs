using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotAttributeStringWriter : DotEntityStringWriter, IDotAttributeWriter
    {
        public DotAttributeStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
        {
            _writer.Identifier(key, quoteKey)
                   .Space()
                   .ValueAssignmentOperator()
                   .Space()
                   .TextValue(value, quoteValue);
        }

        public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue)
        {
            _writer.Identifier(key, quoteKey)
                   .Space()
                   .ValueAssignmentOperator()
                   .Space()
                   .HtmlValue(value, braceValue);
        }
    }
}
