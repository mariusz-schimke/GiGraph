using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.AttributeWriters
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

        public override IDotCommentWriter BeginComment(bool preferBlockComment)
        {
            return new DotCommentWriter(_tokenWriter, preferBlockComment: true);
        }

        public override void EndComment()
        {
            _tokenWriter.Space();
        }
    }
}