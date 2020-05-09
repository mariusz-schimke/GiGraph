using Dotless.DotWriters.Contexts;
using Dotless.DotWriters.Options;

namespace Dotless.DotWriters.StringWriter
{
    public class DotNodeStatementStringWriter : DotStatementStringWriter, IDotNodeCollectionWriter
    {
        public DotNodeStatementStringWriter(DotStringWriter writer, DotFormattingOptions format, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(writer, format, context, useStatementDelimiter)
        {
        }

        public virtual IDotNodeWriter BeginNode()
        {
            return new DotNodeStringWriter(_writer, _format, _context);
        }

        public void EndNode()
        {
            EndStatement();
        }
    }
}
