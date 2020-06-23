using GiGraph.Dot.Output.Writers.Contexts;

namespace GiGraph.Dot.Output.Writers.CommonEntityWriters
{
    public abstract class DotEntityStatementWriter : DotEntityWriter
    {
        protected readonly bool _useStatementDelimiter;

        protected DotEntityStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context, bool useStatementDelimiter)
            : base(tokenWriter, context, enforceBlockComment: true)
        {
            _useStatementDelimiter = useStatementDelimiter;
        }

        public virtual void EndStatement()
        {
            _tokenWriter.ClearLingerBuffer();

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