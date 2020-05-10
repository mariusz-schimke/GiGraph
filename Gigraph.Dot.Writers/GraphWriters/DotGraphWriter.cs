using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.GraphWriters
{
    public class DotGraphWriter : DotGraphBlockWriter, IDotGraphWriter
    {
        public DotGraphWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual void WriteGraphDeclaration(string id, bool strict, bool quoteId)
        {
            if (strict)
            {
                _tokenWriter.Keyword("strict")
                       .Space();
            }

            if (_context.IsDirectedGraph)
            {
                _tokenWriter.Keyword("digraph")
                       .Space();
            }
            else
            {
                _tokenWriter.Keyword("graph")
                       .Space();
            }

            if (id != null)
            {
                _tokenWriter.Identifier(id, quoteId)
                       .Space();
            }
        }
    }
}
