using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public class DotAttributeStringWriter : DotEntityStringWriter, IDotAttributeWriter
    {
        public DotAttributeStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
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
