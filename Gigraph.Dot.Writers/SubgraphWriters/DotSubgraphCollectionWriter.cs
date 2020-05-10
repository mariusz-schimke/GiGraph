using Gigraph.Dot.Writers.Contexts;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotSubgraphCollectionWriter : DotStatementWriter, IDotSubgraphCollectionWriter
    {
        public DotSubgraphCollectionWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
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
    }
}
