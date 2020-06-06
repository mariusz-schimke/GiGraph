using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.SubgraphWriters
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
