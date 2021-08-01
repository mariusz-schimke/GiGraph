namespace GiGraph.Dot.Output.Writers.Nodes
{
    public class DotNodeStatementWriter : DotEntityStatementWriter, IDotNodeStatementWriter
    {
        public DotNodeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, useStatementDelimiter)
        {
        }

        public virtual IDotNodeWriter BeginNodeStatement()
        {
            return new DotNodeWriter(_tokenWriter, _configuration);
        }

        public virtual void EndNodeStatement()
        {
            EndStatement();
        }
    }
}