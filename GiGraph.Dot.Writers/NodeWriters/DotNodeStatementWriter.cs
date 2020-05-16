using GiGraph.Dot.Writers.CommonEntityWriters;
using GiGraph.Dot.Writers.Contexts;

namespace GiGraph.Dot.Writers.NodeWriters
{
    public class DotNodeStatementWriter : DotEntityStatementWriter, IDotNodeStatementWriter
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
