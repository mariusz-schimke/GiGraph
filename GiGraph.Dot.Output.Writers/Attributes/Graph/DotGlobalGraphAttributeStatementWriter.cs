namespace GiGraph.Dot.Output.Writers.Attributes.Graph
{
    public class DotGlobalGraphAttributeStatementWriter : DotEntityWriter, IDotGlobalGraphAttributeStatementWriter
    {
        protected readonly bool _useStatementDelimiter;

        public DotGlobalGraphAttributeStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual IDotAttributeWriter BeginAttributeStatement()
        {
            return new DotAttributeWriter(_tokenWriter, _context, enforceBlockComment: false);
        }

        public virtual void EndAttributeStatement()
        {
            if (_useStatementDelimiter)
            {
                _tokenWriter.StatementEnd();
            }

            _tokenWriter.LineBreak()
               .Indentation(linger: true);
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}