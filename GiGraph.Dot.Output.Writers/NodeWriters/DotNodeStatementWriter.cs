using GiGraph.Dot.Output.Writers.CommonEntityWriters;
using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.NodeWriters
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