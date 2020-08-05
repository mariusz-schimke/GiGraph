namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEdgeStatementWriter : DotEntityStatementWriter, IDotEdgeStatementWriter
    {
        public DotEdgeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginSequence()
        {
            return new DotEdgeWriter(_tokenWriter, _context);
        }

        public virtual void EndSequence()
        {
            EndStatement();
        }
    }
}