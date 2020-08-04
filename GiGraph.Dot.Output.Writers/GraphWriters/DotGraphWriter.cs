using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.GraphWriters
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
                _tokenWriter.Keyword("digraph");
            }
            else
            {
                _tokenWriter.Keyword("graph");
            }

            if (id != null)
            {
                _tokenWriter.Space()
                   .Identifier(id, quoteId);
            }

            _tokenWriter.LineBreak()
               .Indentation();
        }
    }
}