using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotSubgraphCollectionWriter : DotStatementWriter, IDotSubgraphCollectionWriter
    {
        public DotSubgraphCollectionWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, useStatementDelimiter: false)
        {
        }

        public virtual IDotSubgraphWriter BeginSubgraph()
        {
            return new DotSubgraphWriter(_tokenWriter, _context);
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
