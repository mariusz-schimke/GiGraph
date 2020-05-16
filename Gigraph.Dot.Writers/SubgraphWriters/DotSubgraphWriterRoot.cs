using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public class DotSubgraphWriterRoot : DotEntityWriter, IDotSubgraphWriterRoot
    {
        public DotSubgraphWriterRoot(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context)
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword)
        {
            return new DotSubgraphWriter(_tokenWriter, _context, preferExplicitSubgraphKeyword);
        }

        public virtual void EndSubgraph()
        {
            _tokenWriter.ClearLingerBuffer();

            _tokenWriter.LineBreak()
                        .LineBreak(linger: true)
                        .Indentation(_context.Level, linger: true);
        }
    }
}
