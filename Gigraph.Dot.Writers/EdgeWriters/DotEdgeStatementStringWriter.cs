using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.EdgeWriters
{
    public class DotEdgeStatementStringWriter : DotStatementStringWriter, IDotEdgeCollectionWriter
    {
        public DotEdgeStatementStringWriter(DotStringWriter writer, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, context, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginEdge()
        {
            return new DotEdgeStringWriter(_writer, _context);
        }

        public virtual void EndEdge()
        {
            EndStatement();
        }
    }
}
