using GiGraph.Dot.Output.Writers.Attributes;

namespace GiGraph.Dot.Output.Writers.Graphs.Attributes
{
    public class DotGlobalGraphAttributeStatementWriter : DotEntityStatementWriter, IDotGlobalGraphAttributeStatementWriter
    {
        public DotGlobalGraphAttributeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, useStatementDelimiter)
        {
        }

        public virtual IDotAttributeWriter BeginAttributeStatement()
        {
            return new DotAttributeWriter(_tokenWriter, _configuration);
        }

        public virtual void EndAttributeStatement()
        {
            EndStatement();
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}