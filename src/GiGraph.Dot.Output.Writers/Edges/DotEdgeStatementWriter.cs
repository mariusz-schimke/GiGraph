using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Edges
{
    public class DotEdgeStatementWriter : DotEntityStatementWriter, IDotEdgeStatementWriter
    {
        public DotEdgeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, useStatementDelimiter)
        {
        }

        public virtual IDotEdgeWriter BeginEdgeStatement()
        {
            return new DotEdgeWriter(_paddedEntityWriter.BeginEntity(), _configuration);
        }

        public virtual void EndEdgeStatement()
        {
            EndStatement();
        }
    }
}