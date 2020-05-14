using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public class DotEdgeStatementWriter : DotEntityStatementWriter, IDotEdgeCollectionWriter
    {
        public DotEdgeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginEdge()
        {
            return new DotEdgeWriter(_tokenWriter, _context);
        }

        public virtual void EndEdge()
        {
            EndStatement();
        }
    }
}
