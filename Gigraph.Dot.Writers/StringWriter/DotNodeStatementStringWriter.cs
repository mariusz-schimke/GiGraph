using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.StringWriter
{
    public class DotNodeStatementStringWriter : DotStatementStringWriter, IDotNodeCollectionWriter
    {
        public DotNodeStatementStringWriter(DotStringWriter writer, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, context, useStatementDelimiter)
        {
        }

        public virtual IDotNodeWriter BeginNode()
        {
            return new DotNodeStringWriter(_writer, _context);
        }

        public void EndNode()
        {
            EndStatement();
        }
    }
}
