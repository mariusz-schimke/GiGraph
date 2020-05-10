using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public class DotGraphStringWriter : DotGraphBlockStringWriter, IDotGraphWriter
    {
        public DotGraphStringWriter(DotStringWriter writer, DotEntityWriterContext context)
            : base(writer, context)
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
