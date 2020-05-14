using Gigraph.Dot.Writers.CommonEntityWriters;
using Gigraph.Dot.Writers.Contexts;

namespace Gigraph.Dot.Writers.NodeWriters
{
    public class DotNodeStatementWriter : DotEntityStatementWriter, IDotNodeCollectionWriter
    {
        public DotNodeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
        {
        }

        public virtual IDotNodeWriter BeginNode()
        {
            return new DotNodeWriter(_tokenWriter, _context);
        }

        public virtual void EndNode()
        {
            EndStatement();
        }
    }
}
