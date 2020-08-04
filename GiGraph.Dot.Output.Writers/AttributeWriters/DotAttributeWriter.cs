using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.AttributeWriters
{
    public class DotAttributeWriter : DotEntityWriter, IDotAttributeWriter
    {
        public DotAttributeWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool enforceBlockComment)
            : base(tokenWriter, context, enforceBlockComment)
        {
        }

        public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
        {
            _tokenWriter.Identifier(key, quoteKey)
               .Space()
               .ValueAssignmentOperator()
               .Space()
               .Identifier(value, quoteValue);
        }

        public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool writeInBrackets)
        {
            _tokenWriter.Identifier(key, quoteKey)
               .Space()
               .ValueAssignmentOperator()
               .Space()
               .Html(value, writeInBrackets);
        }

        public override void EndComment()
        {
            if (_enforceBlockComment)
            {
                _tokenWriter.Space();
            }
            else
            {
                base.EndComment();
            }
        }
    }
}