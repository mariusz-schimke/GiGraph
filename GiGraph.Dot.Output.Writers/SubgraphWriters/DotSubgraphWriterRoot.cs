using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.SubgraphWriters
{
    public class DotSubgraphWriterRoot : DotEntityWriter, IDotSubgraphWriterRoot
    {
        public DotSubgraphWriterRoot(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword)
        {
            return new DotSubgraphWriter(_tokenWriter, _context, preferExplicitSubgraphKeyword);
        }

        public virtual void EndSubgraph()
        {
            _tokenWriter.ClearLingerBuffer();
            EmptyLine();
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}