using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.AttributeWriters
{
    public class DotAttributeWriter : DotEntityWriter, IDotAttributeWriter
    {
        public DotAttributeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
        {
            _tokenWriter.Identifier(key, quoteKey)
                        .Space()
                        .ValueAssignmentOperator()
                        .Space()
                        .TextValue(value, quoteValue);
        }

        public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue)
        {
            _tokenWriter.Identifier(key, quoteKey)
                        .Space()
                        .ValueAssignmentOperator()
                        .Space()
                        .HtmlValue(value, braceValue);
        }
    }
}
