namespace GiGraph.Dot.Output.Writers.Attributes.Graph
{
    public class DotGlobalGraphAttributeStatementWriter : DotEntityWriter, IDotGlobalGraphAttributeStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotGlobalGraphAttributeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotAttributeWriter BeginAttributeStatement()
        {
            return new DotAttributeWriter(_tokenWriter, _configuration, enforceBlockComment: false);
        }

        public virtual void EndAttributeStatement()
        {
            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            LineBreak();
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}