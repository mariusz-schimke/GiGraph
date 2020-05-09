using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotEdgeStatementStringWriter : DotStatementStringWriter, IDotEdgeCollectionWriter
    {
        public DotEdgeStatementStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, format, context, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginEdge()
        {
            return new DotEdgeStringWriter(_writer, _format, _context);
        }

        public virtual void EndEdge()
        {
            EndStatement();
        }
    }
}
