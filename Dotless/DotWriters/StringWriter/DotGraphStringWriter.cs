using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotGraphStringWriter : DotGraphBlockStringWriter, IDotGraphWriter
    {
        public DotGraphStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context)
            : base(writer, format, context)
        {
        }

        public virtual void WriteGraphDeclaration(string id, bool strict, bool quoteId)
        {
            if (strict)
            {
                _writer.Keyword("strict")
                       .Space();
            }

            if (_context.IsDirectedGraph)
            {
                _writer.Keyword("digraph")
                       .Space();
            }
            else
            {
                _writer.Keyword("graph")
                       .Space();
            }

            if (id != null)
            {
                _writer.Identifier(id, quoteId)
                       .Space();
            }
        }
    }
}
