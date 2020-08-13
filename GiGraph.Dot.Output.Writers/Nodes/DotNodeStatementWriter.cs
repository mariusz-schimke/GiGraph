namespace GiGraph.Dot.Output.Writers.Nodes
{
    public class DotNodeStatementWriter : DotEntityStatementWriter, IDotNodeStatementWriter
    {
        public DotNodeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
        {
        }

        public virtual IDotNodeWriter BeginNodeStatement()
        {
            return new DotNodeWriter(_tokenWriter, _context);
        }

        public virtual void EndNodeStatement()
        {
            EndStatement();
        }
    }
}