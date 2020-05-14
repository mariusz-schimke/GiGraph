using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.SubgraphWriters
{
    public class DotSubgraphCollectionWriter : DotStatementWriter, IDotSubgraphCollectionWriter
    {
        public DotSubgraphCollectionWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, useStatementDelimiter: false)
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitSubgraphKeyword)
        {
            return new DotSubgraphWriter(_tokenWriter, _context, preferExplicitSubgraphKeyword);
        }

        public virtual void EndSubgraph()
        {
            EndStatement();
        }

        public override void EndStatement()
        {
            _tokenWriter.ClearLingerBuffer();

            _tokenWriter.LineBreak()
                        .LineBreak(linger: true)
                        .Indentation(_context.Level, linger: true);
        }
    }
}
